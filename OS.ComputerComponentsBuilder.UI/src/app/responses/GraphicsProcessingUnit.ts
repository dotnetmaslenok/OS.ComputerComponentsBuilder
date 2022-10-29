import {IComponent} from "../abstractions/IComponent";

export class GraphicsProcessingUnit implements IComponent {
  id: string;
  componentType: string;
  name: string;
  price: number;
  producer: string;
  microarchitecture: string;
  technicalProcess: string;
  videoMemorySize: string;
  memoryType: string;
  memoryFrequency: string;
  busWidth: string;
}
