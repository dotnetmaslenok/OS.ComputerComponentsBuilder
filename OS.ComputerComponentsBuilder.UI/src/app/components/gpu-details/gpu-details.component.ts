import { Component, OnInit } from '@angular/core';
import { GraphicsProcessingUnit } from 'src/app/responses/GraphicsProcessingUnit';

@Component({
  selector: 'app-gpu-details',
  templateUrl: './gpu-details.component.html',
  styleUrls: ['./gpu-details.component.css']
})
export class GpuDetailsComponent implements OnInit {

  public selectedGpu: GraphicsProcessingUnit;
  constructor() { }

  ngOnInit(): void {
    this.selectedGpu = history.state.selectedComponent
    if (!this.selectedGpu) {
      this.selectedGpu = JSON.parse(localStorage.getItem('selectedComponent') as string) as GraphicsProcessingUnit;
    }
  }
}
