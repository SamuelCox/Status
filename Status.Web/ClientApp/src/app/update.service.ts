import { Injectable } from '@angular/core';
import { Update } from './models/update';
import { of, Observable } from 'rxjs';
import { environment } from '../environments/environment';
import { TokenService } from './token.service';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class UpdateService {

  constructor(private tokenService : TokenService, private http : HttpClient) { }

  getUpdates(page : number, pageSize : number) : Observable<Update[]> {
    let url = environment.apiUrl + "/update?page=" + page + "&pageSize=" + pageSize;
    return this.http.get<Update[]>(url, { headers: this.tokenService.getHeaders()})
  }

  postUpdate(update : Update) : Observable<boolean> {
    let url = environment.apiUrl + "/update";
    return this.http.post<boolean>(url, update, { headers : this.tokenService.getHeaders()});
  }
}
