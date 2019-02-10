import { Component, OnInit } from '@angular/core';
import { BlogPreview } from '../models/blog-preview';
import { BlogService } from '../blog.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-blog-master',
  templateUrl: './blog-master.component.html',
  styleUrls: ['./blog-master.component.css']
})
export class BlogMasterComponent implements OnInit {

  blogPreviews: BlogPreview[];
  private currentPageNumber: number = 0;
  private pageSize = 99;

  constructor(private blogService: BlogService, private router: Router) { }

  ngOnInit() {
    this.blogService.getBlogPreviews(this.currentPageNumber, this.pageSize).subscribe(x => this.blogPreviews = x);
    this.currentPageNumber++;
  }

  redirectToCreate() {
    this.router.navigateByUrl('/createblog');
  }

}
