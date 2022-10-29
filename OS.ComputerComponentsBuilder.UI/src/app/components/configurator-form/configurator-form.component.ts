import {Component, OnInit} from '@angular/core';
import {FormBuilder, FormControl, FormGroup} from "@angular/forms";
import {HttpClient} from "@angular/common/http";
import {ComputerConfigurationBuilderEndpoints} from "../../apiEndpoints/computerConfigurationBuilderEndpoints";
import {ComputerConfiguration} from "../../responses/ComputerConfiguration";
import {Router} from "@angular/router";

@Component({
  selector: 'app-configurator-form',
  templateUrl: './configurator-form.component.html',
  styleUrls: ['./configurator-form.component.css']
})
export class ConfiguratorFormComponent implements OnInit {

  constructor(
    private _formBuilder: FormBuilder,
    private _httpClient: HttpClient,
    private _router: Router) { }

  configuratorFormGroup: FormGroup;
  computerTypeKeys: string[] = ["Office Computer", "Gaming Computer", "Gaming Laptop", "Workstation", "Home Media Server"];

  ngOnInit(): void {
    this.configuratorFormGroup = this._formBuilder.group({
      price: new FormControl<number>(0),
      type: new FormControl<string>("Office Computer"),
    })
  }

  onConfiguratorFormSubmit() {
    let index = 0;
    let computerConfigurationComponentTypes: string[] = ["cpu", "gpu", "motherboard", "ram", "storage"];

    this._httpClient.post<ComputerConfiguration>(`${ComputerConfigurationBuilderEndpoints.BuildConfiguration}`, this.configuratorFormGroup.value)
      .subscribe((response:ComputerConfiguration) => {
        for (let component of Object.values(response).slice(1, Object.values(response).length - 1)) {
          component.componentType = computerConfigurationComponentTypes[index];
          index++;
        }
        localStorage.setItem('configuration', JSON.stringify(response));
        this._router.navigate(['/configuration']);
      });
  }
}
