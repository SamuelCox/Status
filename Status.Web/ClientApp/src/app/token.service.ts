import { Injectable } from '@angular/core';
import { LocalStorageService } from 'angular-2-local-storage';
import { HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class TokenService {

  constructor(private localStorageService: LocalStorageService) { }

  
  public get token() : string {
    return this.localStorageService.get<string>("jwt");
  }

  
  public set token(v : string) {
    this.localStorageService.set("jwt", v);
  }

  getHeaders() : HttpHeaders {
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': this.token
    })
    return headers;
  }
  
  
}
