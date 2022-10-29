import { Component, OnInit } from '@angular/core';
import { CentralProcessingUnit } from 'src/app/responses/CentralProcessingUnit';

@Component({
  selector: 'app-cpu-details',
  templateUrl: './cpu-details.component.html',
  styleUrls: ['./cpu-details.component.css']
})
export class CpuDetailsComponent implements OnInit {

  public selectedCpu: CentralProcessingUnit;
  constructor() { }

  ngOnInit(): void {
    this.selectedCpu = history.state.selectedComponent;
    if (!this.selectedCpu) {
      this.selectedCpu = JSON.parse(localStorage.getItem('selectedComponent') as string) as CentralProcessingUnit;
    }
  }

}
