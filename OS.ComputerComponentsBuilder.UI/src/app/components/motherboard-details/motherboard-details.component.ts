import { Component, OnInit } from '@angular/core';
import { Motherboard } from 'src/app/responses/Motherboard';

@Component({
  selector: 'app-motherboard-details',
  templateUrl: './motherboard-details.component.html',
  styleUrls: ['./motherboard-details.component.css']
})
export class MotherboardDetailsComponent implements OnInit {

  public selectedMotherboard: Motherboard;
  constructor() { }

  ngOnInit(): void {
    this.selectedMotherboard = history.state.selectedComponent
    if (!this.selectedMotherboard) {
      this.selectedMotherboard = JSON.parse(localStorage.getItem('selectedComponent') as string) as Motherboard;
    }
  }

}
