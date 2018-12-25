import { Injectable } from '@angular/core';
import { Update } from './models/update';
import { of, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UpdateService {

  constructor() { }

  getUpdates(page : number, pageSize : number) : Observable<Update[]> {
    return of([{text: "Test Update", createdBy: "Sam", createdDate:"25/12/2018"},
    {text: "Test Update", createdBy: "Sam", createdDate:"25/12/2018"},
    {text: "Test Update", createdBy: "Sam", createdDate:"25/12/2018"},
    {text: "Test Update", createdBy: "Sam", createdDate:"25/12/2018"}]);
  }
}
