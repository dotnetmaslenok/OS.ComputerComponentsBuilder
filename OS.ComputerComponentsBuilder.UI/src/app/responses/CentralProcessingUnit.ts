import {IComponent} from "../abstractions/IComponent";

export class CentralProcessingUnit implements IComponent {
  id: string;
  componentType: string;
  name: string;
  price: number;
  producer: string;
  cores: number;
  threads: number;
  baseClockFrequency: number;
  maxClockFrequency: number;
  socket: string;
  technicalProcess: string;
}
