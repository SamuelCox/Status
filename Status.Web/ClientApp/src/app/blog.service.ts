import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { BlogPreview } from './models/blog-preview';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from '../environments/environment';
import { Blog } from './models/blog';
import { TokenService } from './token.service';

@Injectable({
  providedIn: 'root'
})
export class BlogService {

  constructor(private http: HttpClient, private tokenService: TokenService) { }

  getBlogPreviews(pageNumber: number, pageSize: number): Observable<BlogPreview[]> {
    let httpParams = new HttpParams();
    httpParams = httpParams.append('PageNumber', pageNumber.toString());
    httpParams = httpParams.append('PageSize', pageSize.toString());
    let url = environment.apiUrl + '/blogPreview';
    return this.http.get<BlogPreview[]>(url, { params: httpParams, headers: this.tokenService.getHeaders()});
  }

  getBlog(id: number): Observable<Blog> {    
    let url = environment.apiUrl + '/blog';
    let httpParams = new HttpParams();
    httpParams = httpParams.append('id', id.toString());
    return this.http.get<Blog>(url, { params: httpParams, headers: this.tokenService.getHeaders()});
  }

  createBlog(blog: Blog): Observable<Blog> {
    let url = environment.apiUrl + '/blog';
    return this.http.post<Blog>(url, blog, { headers : this.tokenService.getHeaders()});
  }
}
