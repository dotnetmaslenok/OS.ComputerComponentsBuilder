import {Component, OnDestroy, OnInit, Type} from '@angular/core';
import {ComputerConfiguration} from "../../responses/ComputerConfiguration";
import {NavigationEnd, Router} from "@angular/router";
import {IComponent} from "../../abstractions/IComponent";
import {HttpClient} from "@angular/common/http";
import { ComputerConfigurationBuilderEndpoints } from 'src/app/apiEndpoints/computerConfigurationBuilderEndpoints';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-configuration',
  templateUrl: './configuration.component.html',
  styleUrls: ['./configuration.component.css']
})
export class ConfigurationComponent implements OnInit, OnDestroy {

  someSubscription: Subscription;
  constructor(
    private _router: Router,
    private _httpClient: HttpClient) {
      this._router.routeReuseStrategy.shouldReuseRoute = function () {
        return false;
      };
      this.someSubscription = this._router.events.subscribe((event) => {
        if (event instanceof NavigationEnd) {
          this._router.navigated = false;
        }
      });
     }
  ngOnDestroy(): void {
    if (this.someSubscription) {
      this.someSubscription.unsubscribe();
    }
  }

  computerConfiguration: ComputerConfiguration;
  newComputerConfiguration: ComputerConfiguration;
  computerConfigurationMap = new Map();
  storageMap = new Map();
  totalPrice: number = 0;
  computerConfigurationComponentTypes: string[] = ["cpu", "gpu", "motherboard", "ram", "storage"];

  ngOnInit(): void {
    this.computerConfiguration = history.state.configuration as ComputerConfiguration;

    if (!this.computerConfiguration) {
      this.computerConfiguration = JSON.parse(localStorage.getItem('configuration') as string) as ComputerConfiguration;
    }

    let key: number = 1;
    for (let component of Object.values(this.computerConfiguration).slice(1, Object.values(this.computerConfiguration).length - 1)) {
      this.computerConfigurationMap.set(key, component);
      this.totalPrice += component.price;
      key++;
    }

    for (let storage of this.computerConfiguration.storage) {
      storage.componentType = `${this.computerConfigurationComponentTypes[this.computerConfigurationComponentTypes.length - 1]}`;
      this.storageMap.set(key, storage);
      this.totalPrice += storage.price;
      key++;
    }
  }

  showComputerComponentDetails(component: IComponent) {
    this.findComputerComponent(component, 'details');
  }

  private findComputerComponent(component: IComponent, urlPostfix: string) {
    this._httpClient.get<IComponent>(`${ComputerConfigurationBuilderEndpoints.BaseUrl}/${component.componentType}/${component.id}`)
    .subscribe((response: IComponent) => {
      localStorage.setItem('selectedComponent', JSON.stringify(response));
      this._router.navigateByUrl(`${component.componentType}-${urlPostfix}`, {state: {selectedComponent: response}});
    })
  }
}
