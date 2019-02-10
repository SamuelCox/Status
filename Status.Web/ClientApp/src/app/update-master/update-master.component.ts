import { Component, OnInit } from '@angular/core';
import { Update } from '../models/update';
import { UpdateService } from '../update.service';
import { AuthService } from '../auth.service';
import { User } from '../models/user';

@Component({
  selector: 'app-update-master',
  templateUrl: './update-master.component.html',
  styleUrls: ['./update-master.component.css']
})
export class UpdateMasterComponent implements OnInit {

  updates : Update[];
  currentPageNumber : number = 0;
  pageSize : number = 99;

  constructor(private updateService : UpdateService, private authService: AuthService) { }

  ngOnInit() {
    this.updateService.getUpdates(this.currentPageNumber, this.pageSize).subscribe( x => this.updates = x );
  }

  onPost(update : Update) {
    update.creator = new User();
    update.creator.userName = this.authService.userName;
    this.updateService.postUpdate(update).subscribe(x => {
      if (this.updates.length == 0)
      {
        this.updates.push(update);
      }
      else {
        this.updates.unshift(update)
      }
      
    })
    ;
  }

  loadUpdates() {
    this.updateService.getUpdates(this.currentPageNumber, this.pageSize).subscribe( x => { 
      this.updates = this.updates.concat(x)
      this.currentPageNumber++;      
    });
  }

}
