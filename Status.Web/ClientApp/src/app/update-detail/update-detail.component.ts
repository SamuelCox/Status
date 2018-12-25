import { Component, OnInit } from '@angular/core';
import { Update } from '../models/update';
import { Input } from '@angular/core';

@Component({
  selector: 'app-update-detail',
  templateUrl: './update-detail.component.html',
  styleUrls: ['./update-detail.component.css']
})
export class UpdateDetailComponent implements OnInit {

  @Input()
  update : Update;

  constructor() { }

  ngOnInit() {
  }

}
