import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from "@angular/common/http";
import { CommonModule} from "@angular/common";
import { MatSelectModule } from "@angular/material/select";
import { MatInputModule } from "@angular/material/input";
import { NgxMatSelectSearchModule } from 'ngx-mat-select-search';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatToolbarModule } from '@angular/material/toolbar';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ConfiguratorFormComponent } from './components/configurator-form/configurator-form.component';
import { FormsModule, ReactiveFormsModule} from "@angular/forms";
import { ConfigurationComponent } from './components/configuration/configuration.component';
import { CpuDetailsComponent } from './components/cpu-details/cpu-details.component';
import { GpuDetailsComponent } from './components/gpu-details/gpu-details.component';
import { RamDetailsComponent } from './components/ram-details/ram-details.component';
import { MotherboardDetailsComponent } from './components/motherboard-details/motherboard-details.component';
import { StorageDetailsComponent } from './components/storage-details/storage-details.component';
import { EditConfigurationComponent } from './components/edit-configuration/edit-configuration.component';

@NgModule({
  declarations: [
    AppComponent,
    ConfiguratorFormComponent,
    ConfigurationComponent,
    CpuDetailsComponent,
    GpuDetailsComponent,
    RamDetailsComponent,
    MotherboardDetailsComponent,
    StorageDetailsComponent,
    EditConfigurationComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    MatInputModule,
    FormsModule,
    MatSelectModule,
    MatToolbarModule,
    MatFormFieldModule,
    MatIconModule,
    NgxMatSelectSearchModule,
    HttpClientModule,
    CommonModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
