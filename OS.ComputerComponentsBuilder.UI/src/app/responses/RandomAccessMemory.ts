import {IComponent} from "../abstractions/IComponent";

export class RandomAccessMemory implements IComponent {
  id: string;
  componentType: string;
  name: string;
  price: number;
  producer: string;
  count: number;
  volume: number;
  fullVolume: number;
  memoryType: string;
  formFactor: string;
  clockFrequency: string;
  registerMemory: boolean;
  eccMemory: boolean;
}
