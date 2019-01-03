import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { FormGroup } from '@angular/forms';
import { Validators } from '@angular/forms';
import { UpdateService } from '../update.service';
import { EventEmitter } from '@angular/core';
import { Update } from '../models/update';
import { Output } from '@angular/core';

@Component({
  selector: 'app-create-update',
  templateUrl: './create-update.component.html',
  styleUrls: ['./create-update.component.css']
})
export class CreateUpdateComponent implements OnInit {

  createUpdateForm : FormGroup;
  submitted : boolean = false;
  @Output() 
  postUpdateEvent = new EventEmitter<Update>();

  constructor(private formBuilder : FormBuilder, 
              private updateService : UpdateService) { }

  ngOnInit() {
    this.createUpdateForm = this.formBuilder.group({
      createUpdate : ['', Validators.required]
    });  
  }

  onSubmit() {
    let update = new Update();
    update.text = this.createUpdateForm.controls.createUpdate.value;    
    update.createdDate = new Date().toISOString();
    this.postUpdateEvent.emit(update);
  }

}
