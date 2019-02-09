import { Component, OnInit } from '@angular/core';
import { BlogPreview } from '../models/blog-preview';
import { BlogService } from '../blog.service';

@Component({
  selector: 'app-blog-master',
  templateUrl: './blog-master.component.html',
  styleUrls: ['./blog-master.component.css']
})
export class BlogMasterComponent implements OnInit {

  blogPreviews: BlogPreview[];
  private currentPageNumber: number = 1;
  private pageSize = 99;

  constructor(private blogService: BlogService) { }

  ngOnInit() {
    this.blogService.getBlogPreviews(this.currentPageNumber, this.pageSize).subscribe(x => this.blogPreviews = x);
    this.currentPageNumber++;
  }

}
