import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { FormGroup } from '@angular/forms';
import { Validators } from '@angular/forms';
import { Router } from '@angular/router';

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
              private router: Router) { }

  ngOnInit() {
    this.registerForm = this.formBuilder.group({
      username : ['', Validators.required],
      password : ['', Validators.required],
      profilePic : [null]
    })
  }

  onSubmit() {
    this.submitted = true;
    this.router.navigate(['/updates']);
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
