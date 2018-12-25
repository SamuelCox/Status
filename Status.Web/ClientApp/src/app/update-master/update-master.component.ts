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

  constructor(private updateService : UpdateService) { }

  ngOnInit() {
    this.updateService.getUpdates(1, 99).subscribe( x => this.updates = x );
  }

}
