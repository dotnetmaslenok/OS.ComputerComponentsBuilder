import {IComponent} from "../abstractions/IComponent";

export class Storage implements IComponent {
  id: string;
  componentType: string;
  name: string;
  price: number;
  producer: string;
  volume: number;
  type: string;
  readingSpeed: number;
  writingSpeed: number;
  connectionConnector: string;
  memoryStructure?: string;
  writingTechnology?: string;
}
