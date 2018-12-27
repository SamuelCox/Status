import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { FormGroup } from '@angular/forms';
import { Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../auth.service';
import { RegisterModel } from '../models/registermodel';
import { TokenService } from '../token.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  registerForm : FormGroup;
  submitted : boolean = false;
  profilePic : File;

  constructor(private formBuilder: FormBuilder,
              private router: Router,
              private authService : AuthService,
              private tokenService : TokenService) { }

  ngOnInit() {
    this.registerForm = this.formBuilder.group({
      username : ['', Validators.required],
      password : ['', Validators.required],
      profilePic : [null]
    })
  }

  onSubmit() {
    this.submitted = true;
    if (this.registerForm.valid)
    {
      let registerModel = new RegisterModel();
      registerModel.username = this.registerForm.controls.username.value;
      registerModel.password = this.registerForm.controls.password.value;
      this.authService.register(registerModel).subscribe(x => {
        this.tokenService.token = x.token;
        this.router.navigate(['/updates']);
      });
    }
    
  }

  onFileChange(event) {
    let reader = new FileReader();

    if(event.target.files && event.target.files.length) {
      const [file] = event.target.files;
      reader.readAsDataURL(file);

      reader.onload = () => {
        this.registerForm.patchValue({
          file: reader.result
        });
      }
    }
  }

}
