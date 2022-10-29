import { Component, OnInit } from '@angular/core';
import { Storage } from 'src/app/responses/Storage';

@Component({
  selector: 'app-storage-details',
  templateUrl: './storage-details.component.html',
  styleUrls: ['./storage-details.component.css']
})
export class StorageDetailsComponent implements OnInit {

  public selectedStorage: Storage;
  constructor() { }

  ngOnInit(): void {
    this.selectedStorage = history.state.selectedComponent
    if (!this.selectedStorage) {
      this.selectedStorage = JSON.parse(localStorage.getItem('selectedComponent') as string) as Storage;
    }
  }

}
