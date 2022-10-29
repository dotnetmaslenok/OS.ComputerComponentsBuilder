import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {ConfiguratorFormComponent} from "./components/configurator-form/configurator-form.component";
import {ConfigurationComponent} from "./components/configuration/configuration.component";
import { CpuDetailsComponent } from './components/cpu-details/cpu-details.component';
import { GpuDetailsComponent } from './components/gpu-details/gpu-details.component';
import { RamDetailsComponent } from './components/ram-details/ram-details.component';
import { MotherboardDetailsComponent } from './components/motherboard-details/motherboard-details.component';
import { StorageDetailsComponent } from './components/storage-details/storage-details.component';
import { EditConfigurationComponent } from './components/edit-configuration/edit-configuration.component';

const routes: Routes = [
  {path: '', redirectTo: '/configurator', pathMatch:"full"},
  {path: 'configurator', component: ConfiguratorFormComponent},
  {path: 'configuration', component: ConfigurationComponent},
  {path: 'cpu-details', component: CpuDetailsComponent},
  {path: 'gpu-details', component: GpuDetailsComponent},
  {path: 'ram-details', component: RamDetailsComponent},
  {path: 'motherboard-details', component: MotherboardDetailsComponent},
  {path: 'storage-details', component: StorageDetailsComponent},
  {path: 'edit-configuration', component: EditConfigurationComponent},
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes)
  ],
  exports: [
    RouterModule,
  ]
})
export class AppRoutingModule { }
