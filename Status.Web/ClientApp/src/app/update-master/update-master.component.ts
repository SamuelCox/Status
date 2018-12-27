import { Component, OnInit } from '@angular/core';
import { Update } from '../models/update';
import { UpdateService } from '../update.service';

@Component({
  selector: 'app-update-master',
  templateUrl: './update-master.component.html',
  styleUrls: ['./update-master.component.css']
})
export class UpdateMasterComponent implements OnInit {

  updates : Update[];
  currentPageNumber : number = 1;
  pageSize : number = 99;

  constructor(private updateService : UpdateService) { }

  ngOnInit() {
    this.updateService.getUpdates(1, 99).subscribe( x => this.updates = x );
  }

  onPost(update : Update) {
    this.updates.unshift(update);
  }

  loadUpdates() {
    this.updateService.getUpdates(this.currentPageNumber, this.pageSize).subscribe( x => { 
      this.updates = this.updates.concat(x)
      this.currentPageNumber++;      
    });
  }

}
