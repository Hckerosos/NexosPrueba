import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { PacienteService } from './servicios/paciente/paciente.service';
import { HttpClientModule } from '@angular/common/http';
import { PacienteInsertarComponent } from './paciente/paciente-insertar/paciente-insertar.component';
import { FormsModule } from '@angular/forms';
import { DoctorService } from './servicios/doctor/doctor.service';

@NgModule({
  declarations: [
    AppComponent,
    PacienteInsertarComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule

  ],
  providers: [PacienteService ,DoctorService],
  bootstrap: [AppComponent]
})
export class AppModule { }
