import { async, debounceTime, filter, Observable, switchMap, takeUntil, timeout } from 'rxjs'
import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { CentralProcessingUnit } from 'src/app/responses/CentralProcessingUnit';
import { ComputerConfigurationBuilderEndpoints } from 'src/app/apiEndpoints/computerConfigurationBuilderEndpoints';
import { GraphicsProcessingUnit } from 'src/app/responses/GraphicsProcessingUnit';
import { RandomAccessMemory } from 'src/app/responses/RandomAccessMemory';
import { Motherboard } from 'src/app/responses/Motherboard';
import { Storage } from 'src/app/responses/Storage';
import { ComputerConfiguration } from 'src/app/responses/ComputerConfiguration';
import { IComponent } from 'src/app/abstractions/IComponent';
import { Router } from '@angular/router';

@Component({
  selector: 'app-edit-cpu',
  templateUrl: './edit-configuration.component.html',
  styleUrls: ['./edit-configuration.component.css']
})
export class EditConfigurationComponent implements OnInit {

  cpuFilter: FormControl = new FormControl('');
  gpuFilter: FormControl = new FormControl('');
  ramFilter: FormControl = new FormControl('');
  motherboardFilter: FormControl = new FormControl('');
  storageFilter: FormControl = new FormControl('');
  additionalStorageFilter: FormControl = new FormControl('')

  cpus$: Observable<CentralProcessingUnit[]>;
  gpus$: Observable<GraphicsProcessingUnit[]>;
  rams$: Observable<RandomAccessMemory[]>;
  motherboards$: Observable<Motherboard[]>;
  storages$: Observable<Storage[]>;
  additionalStorages$: Observable<Storage[]>;

  editConfigurationFormGroup: FormGroup;
  currentConfiguration: ComputerConfiguration;
  constructor(
    private _formBuilder: FormBuilder,
    private _httpClient: HttpClient,
    private _router: Router) {}

  ngOnInit(): void {
    this.currentConfiguration = JSON.parse(localStorage.getItem('configuration') as string) as ComputerConfiguration;

    this.editConfigurationFormGroup = this._formBuilder.group({
      cpuControl: new FormControl<string>(''),
      gpuControl: new FormControl<string>(''),
      motherboardControl: new FormControl<string>(''),
      ramControl: new FormControl<string>(''),
      storageControl: new FormControl<string>(''),
      additionalStorageControl: new FormControl<string>(''),
    })

    this.cpus$ = this.cpuFilter.valueChanges
      .pipe(
        filter(term => !!term),
        debounceTime(500),
        switchMap((term: string) => this.searchCpu(term)),
      )

    this.gpus$ = this.gpuFilter.valueChanges
    .pipe(
      filter(term => !!term),
      debounceTime(500),
      switchMap((term: string) => this.searchGpu(term)),
    )

    this.rams$ = this.ramFilter.valueChanges
    .pipe(
      filter(term => !!term),
      debounceTime(500),
      switchMap((term: string) => this.searchRam  (term)),
    )

    this.motherboards$ = this.motherboardFilter.valueChanges
    .pipe(
      filter(term => !!term),
      debounceTime(500),
      switchMap((term: string) => this.searchMotherboard(term)),
    )

    this.storages$ = this.storageFilter.valueChanges
    .pipe(
      filter(term => !!term),
      debounceTime(500),
      switchMap((term: string) => this.searchStorage(term)),
    )

    this.additionalStorages$ = this.additionalStorageFilter.valueChanges
    .pipe(
      filter(term => !!term),
      debounceTime(500),
      switchMap((term: string) => this.searchStorage(term)),
    )
  }

  searchCpu(term: string) : Observable<CentralProcessingUnit[]>  {
    return this._httpClient.get<CentralProcessingUnit[]>(`${ComputerConfigurationBuilderEndpoints.SearchCpus}?q=${term}`)
  }

  searchGpu(term: string) : Observable<GraphicsProcessingUnit[]> {
    return this._httpClient.get<GraphicsProcessingUnit[]>(`${ComputerConfigurationBuilderEndpoints.SearchGpus}?q=${term}`);
  }

  searchRam(term: string) : Observable<RandomAccessMemory[]> {
    return this._httpClient.get<RandomAccessMemory[]>(`${ComputerConfigurationBuilderEndpoints.SearchRams}?q=${term}`);
  }

  searchMotherboard(term: string) : Observable<Motherboard[]> {
    return this._httpClient.get<Motherboard[]>(`${ComputerConfigurationBuilderEndpoints.SearchMotherboards}?q=${term}`);
  }

  searchStorage(term: string, type?: string) : Observable<Storage[]> {
    return this._httpClient.get<Storage[]>(`${ComputerConfigurationBuilderEndpoints.SearchStorages}?q=${term}`);
  }

  editConfiguration() {
    let cpuId = this.editConfigurationFormGroup.get('cpuControl')?.value;
    let gpuId = this.editConfigurationFormGroup.get('gpuControl')?.value;
    let motherboardId = this.editConfigurationFormGroup.get('motherboardControl')?.value;
    let ramId = this.editConfigurationFormGroup.get('ramControl')?.value;
    let storageId = this.editConfigurationFormGroup.get('storageControl')?.value;
    let additionalStorageId = this.editConfigurationFormGroup.get('additionalStorageControl')?.value;
    if (cpuId && cpuId !== this.currentConfiguration.cpu.id
        || gpuId && gpuId !== this.currentConfiguration.gpu.id
        || motherboardId && motherboardId !== this.currentConfiguration.motherboard.id
        || ramId && ramId !== this.currentConfiguration.ram.id
        || storageId && storageId !== this.currentConfiguration.storage[0].id
        || additionalStorageId !== this.currentConfiguration.storage[1]?.id) {
      let queryParams: string = '?';
      let queryParamsCount: number = 0;
      if (cpuId) {
        queryParams += `c=${cpuId}`;
        queryParamsCount++;
      }
      if (gpuId) {
        if (queryParamsCount > 0) {
          queryParams += `&g=${gpuId}`;
        }
        else {
          queryParams += `g=${gpuId}`;
        }

        queryParamsCount++;
      }
      if (motherboardId) {
        if (queryParamsCount > 0) {
          queryParams += `&m=${motherboardId}`;
        }
        else {
          queryParams += `m=${motherboardId}`;
        }

        queryParamsCount++;
      }
      if (ramId) {
        if (queryParamsCount > 0) {
          queryParams += `&r=${ramId}`;
        }
        else {
          queryParams += `r=${ramId}`;
        }

        queryParamsCount++;
      }
      if (storageId) {
        if (queryParamsCount > 0) {
          queryParams += `&s=${storageId}`;
        }
        else {
          queryParams += `s=${storageId}`;
        }

        queryParamsCount++;
      }
      if (additionalStorageId) {
        if (queryParamsCount > 0) {
          queryParams += `&s2=${additionalStorageId}`;
        }
        else {
          queryParams += `s2=${additionalStorageId}`;
        }

        queryParamsCount++;
      }
      this._httpClient.get<ComputerConfiguration>(`${ComputerConfigurationBuilderEndpoints.BaseUrl}/computerconfiguration/rebuild${queryParams}`)
      .subscribe((configuration: ComputerConfiguration) => {

        configuration.type = this.currentConfiguration.type;

        if (!configuration.cpu) {
          configuration.cpu = this.currentConfiguration.cpu;
        }
        if (!configuration.gpu) {
          configuration.gpu = this.currentConfiguration.gpu;
        }
        if (!configuration.motherboard) {
          configuration.motherboard = this.currentConfiguration.motherboard;
        }
        if (!configuration.ram) {
          configuration.ram = this.currentConfiguration.ram;
        }
        if (!configuration.storage[0] && this.currentConfiguration.storage[0]) {
          configuration.storage[0] = this.currentConfiguration.storage[0];
        }
        if (!configuration.storage[1] && this.currentConfiguration.storage[1]) {
          configuration.storage[1] = this.currentConfiguration.storage[1];
        }

        configuration.cpu.componentType = 'cpu';
        configuration.gpu.componentType = 'gpu';
        configuration.motherboard.componentType = 'motherboard';
        configuration.ram.componentType = 'ram';
        configuration.storage[0].componentType = configuration.storage[0].type + 'storage';
        configuration.storage[1].componentType = configuration.storage[1].type + 'storage';

        localStorage.setItem('configuration', JSON.stringify(configuration));
        console.log(configuration);
        this._router.navigateByUrl('/configuration', {state: {configuration: configuration}});
    });
    }
  }

  editCpu(id: string) : Observable<CentralProcessingUnit> {
    return this._httpClient.get<CentralProcessingUnit>(`${ComputerConfigurationBuilderEndpoints.BaseUrl}/${this.currentConfiguration.cpu.componentType}/${id}`);
  }

  editGpu(id: string) : Observable<GraphicsProcessingUnit> {
    return this._httpClient.get<GraphicsProcessingUnit>(`${ComputerConfigurationBuilderEndpoints.BaseUrl}/${this.currentConfiguration.gpu.componentType}/${id}`);
  }

  editMotherboard(id: string) : Observable<Motherboard> {
    return this._httpClient.get<Motherboard>(`${ComputerConfigurationBuilderEndpoints.BaseUrl}/${this.currentConfiguration.motherboard.componentType}/${id}`);
  }

  editRam(id: string) : Observable<RandomAccessMemory> {
    return this._httpClient.get<RandomAccessMemory>(`${ComputerConfigurationBuilderEndpoints.BaseUrl}/${this.currentConfiguration.ram.componentType}/${id}`);
  }
}
