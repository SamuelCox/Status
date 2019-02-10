import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { TokenService } from './token.service';
import { HttpClient } from '@angular/common/http';
import { environment } from '../environments/environment';
import { LoginResult } from './models/loginresult';
import { Login } from './models/login';
import { RegisterModel } from './models/registermodel';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  userName: string;

  constructor(private tokenService : TokenService, private http : HttpClient) { }

  login(loginModel : Login) : Observable<LoginResult> {
    let url = environment.apiUrl + "/auth/login";
    this.userName = loginModel.username;
    return this.http.post<LoginResult>(url, loginModel);
  }

  logout() : Observable<LoginResult> {
    let url = environment.apiUrl + "/auth/logout";
    return this.http.post<LoginResult>(url, null);
  }

  register(registerModel : RegisterModel) : Observable<LoginResult> {
    let url = environment.apiUrl + "/auth/register";
    this.userName = registerModel.username;
    return this.http.put<LoginResult>(url, registerModel);
  }

}
