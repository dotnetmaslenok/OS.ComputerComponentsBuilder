export class ComputerConfigurationBuilderEndpoints {
  public static readonly BaseUrl: string = 'https://localhost:7065';
  public static readonly BuildConfiguration: string = 'https://localhost:7065/ComputerConfiguration/build-configuration';
  public static readonly GetCpu: string = 'https://localhost:7065/Cpu';
  public static readonly GetGpu: string = 'https://localhost:7065/Gpu';
  public static readonly GetRam: string = 'https://localhost:7065/Ram';
  public static readonly GetMotherboard: string = 'https://localhost:7065/Motherboard';
  public static readonly GetStorage: string = 'https://localhost:7065/Storage';
  public static readonly SearchCpus: string = 'https://localhost:7065/cpu/search';
  public static readonly SearchGpus: string = 'https://localhost:7065/gpu/search';
  public static readonly SearchRams: string = 'https://localhost:7065/ram/search';
  public static readonly SearchMotherboards: string = 'https://localhost:7065/motherboard/search';
  public static readonly SearchStorages: string = 'https://localhost:7065/storage/search';
}
