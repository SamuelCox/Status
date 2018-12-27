import { Component, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { FormBuilder } from '@angular/forms';
import { Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../auth.service';
import { Login } from '../models/login'
import { TokenService } from '../token.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  loginForm : FormGroup;
  submitted : boolean = false;

  constructor(private formBuilder: FormBuilder,
              private router: Router,
              private authService : AuthService,
              private tokenService : TokenService) {    
   }

  ngOnInit() {
    this.loginForm = this.formBuilder.group({
      username: ['', Validators.required],
      password: ['', Validators.required]
    });
  }

  onSubmit() {
    this.submitted = true;
    let loginModel = new Login();
    loginModel.username = this.loginForm.controls.username.value;
    loginModel.password = this.loginForm.controls.password.value;
    this.authService.login(loginModel).subscribe(x => {
      if (x.success) {
        this.tokenService.token = x.token;
        this.router.navigate(['/updates']);
      }
      else {
        this.router.navigate(['/login']);
      }
    });
    
  }

}
