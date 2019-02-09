import { Component, OnInit } from '@angular/core';
import { BlogService } from '../blog.service';
import { Blog } from '../models/blog';

@Component({
  selector: 'app-create-blog',
  templateUrl: './create-blog.component.html',
  styleUrls: ['./create-blog.component.css']
})
export class CreateBlogComponent implements OnInit {

  text: string;

  constructor(private blogService: BlogService) { }

  ngOnInit() {
  }

  createBlog() {
    const blog = new Blog();
    blog.text = this.text;
    blog.createdDate = new Date().toISOString();
    this.blogService.createBlog(blog).subscribe();
  }

}
