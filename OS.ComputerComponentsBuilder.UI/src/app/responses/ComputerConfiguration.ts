import {CentralProcessingUnit} from "./CentralProcessingUnit";
import {GraphicsProcessingUnit} from "./GraphicsProcessingUnit";
import {Motherboard} from "./Motherboard";
import {RandomAccessMemory} from "./RandomAccessMemory";
import {Storage} from "./Storage";

export class ComputerConfiguration {
  type: string;
  cpu: CentralProcessingUnit;
  gpu: GraphicsProcessingUnit;
  motherboard: Motherboard;
  ram: RandomAccessMemory;
  storage: Storage[];
}
