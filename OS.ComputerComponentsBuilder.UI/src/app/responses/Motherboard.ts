import {IComponent} from "../abstractions/IComponent";

export class Motherboard implements IComponent {
  id: string;
  componentType: string;
  name: string;
  price: number;
  producer: string;
  formFactor: string;
  chipset: string;
  socket: string;
  memoryType: string;
  memorySpeed: number;
  numberOfMemorySlots: number;
  maxMemoryVolume: number;
}
