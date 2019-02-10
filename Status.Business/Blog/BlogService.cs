using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HtmlAgilityPack;
using Status.DomainModel.Models;
using Status.DomainModel.Repositories;
using Status.DomainModel.Requests;

namespace Status.Business.Blog
{
    public class BlogService : IBlogService
    {
        private readonly IBlogRepository _blogRepository;        

        public BlogService(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public List<BlogPreview> GetBlogPreviews(PagedRequest pagedRequest)
        {
            var blogs = GetAllBlogs(pagedRequest);
            var blogPreviews = blogs.Select(x =>
                new BlogPreview
                {
                    Id = x.Id,
                    PreviewText = GetPreviewText(x.Text),
                    Title = x.Title,
                    CreatedDate = x.CreatedDate,
                    Creator = x.Creator
                }
            );
            return blogPreviews.ToList();
        }

        public DomainModel.Models.Blog GetBlog(int id)
        {
            return _blogRepository.GetBlog(id);
        }

        public async Task CreateBlog(DomainModel.Models.Blog blog)
        {
            var titleIndex = blog.Text?.IndexOf("<h1>");
            if (titleIndex >= 0)
            {
                var endIndex = blog.Text.IndexOf("</h1>") - 5;
                blog.Title = blog.Text.Substring(titleIndex.Value + 4, endIndex);
            }
            await _blogRepository.CreateBlog(blog);
        }

        private IQueryable<DomainModel.Models.Blog> GetAllBlogs(PagedRequest pagedRequest)
        {
            return _blogRepository.GetBlogs().Skip(pagedRequest.PageNumber * pagedRequest.PageSize)
                .Take(pagedRequest.PageSize);
        }

        private string GetPreviewText(string originalText)
        {
            var strippedText = StripHtmlTags(originalText);
            if (strippedText.Length > 100)
            {
                return strippedText.Substring(0, 100) + "...";
            }

            return strippedText;
        }        

        private string StripHtmlTags(string data)
        {
            if (string.IsNullOrEmpty(data))
            {
                return string.Empty;
            }

            var document = new HtmlDocument();
            document.LoadHtml(data);            

            var nodes = new Queue<HtmlNode>(document.DocumentNode.SelectNodes("./*|./text()"));
            while (nodes.Count > 0)
            {
                var node = nodes.Dequeue();
                var parentNode = node.ParentNode;

                if (node.Name != "#text")
                {
                    var childNodes = node.SelectNodes("./*|./text()");

                    if (childNodes != null)
                    {
                        foreach (var child in childNodes)
                        {
                            nodes.Enqueue(child);
                            parentNode.InsertBefore(child, node);
                        }
                    }

                    parentNode.RemoveChild(node);

                }
            }

            return document.DocumentNode.InnerHtml;
        }
    }
}
