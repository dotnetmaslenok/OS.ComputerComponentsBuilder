import { Component, OnInit } from '@angular/core';
import { RandomAccessMemory } from 'src/app/responses/RandomAccessMemory';

@Component({
  selector: 'app-ram-details',
  templateUrl: './ram-details.component.html',
  styleUrls: ['./ram-details.component.css']
})
export class RamDetailsComponent implements OnInit {

  public selectedRam: RandomAccessMemory;
  constructor() { }

  ngOnInit(): void {
    this.selectedRam = history.state.selectedComponent
    if (!this.selectedRam) {
      this.selectedRam = JSON.parse(localStorage.getItem('selectedComponent') as string) as RandomAccessMemory;
    }
  }

}
