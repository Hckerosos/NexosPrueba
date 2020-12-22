import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { DoctorPaciente } from 'src/app/models/doctor-paciente/doctor-paciente';
import { Doctor } from 'src/app/models/doctor/doctor';
import { Paciente } from 'src/app/models/paciente/paciente';
import { DoctorService } from 'src/app/servicios/doctor/doctor.service';
import { PacienteService } from 'src/app/servicios/paciente/paciente.service';
import $ from 'jquery';

@Component({
  selector: 'app-paciente-insertar',
  templateUrl: './paciente-insertar.component.html',
  styleUrls: ['./paciente-insertar.component.css']
})
export class PacienteInsertarComponent implements OnInit {

  constructor(private servicio: PacienteService, private servicioDoctor: DoctorService) { }
  _lista: Paciente[]
  _listaDoctor: Doctor[]
  _llistaDoctorPaciente: DoctorPaciente[]
  seleccionarPaciente: Paciente = new Paciente()
  _DoctorPaciente: DoctorPaciente = new DoctorPaciente()


  ngOnInit(): void {
    this.LimpiarPaciente()
    this.obtenerListaDoctorePaciente()
    this.obtenerListaPacientes()
    this.obtenerListaDoctores()
  }

  ComprobarChecked() {
    $('input').attr('checked', false)
    this._llistaDoctorPaciente.forEach(element => {
      if (element.paciente===this.seleccionarPaciente.idPaciente) {
        $(`#${element.doctor}`).attr('checked', true)
          console.log(element)
      }
    });


  }

  AgregarEditar() {
    if (this.seleccionarPaciente.idPaciente === 0) {
      this.InsertarPaciente()
    }
  }

  obtenerListaPacientes() {
    this.servicio.ObtenerListaPaciente().subscribe(

      (rslt) => {
        this._lista = rslt.objeto.reverse()
      },

      (error: HttpErrorResponse) => {

        console.log(error.message)

      }

    )
  }

  obtenerListaDoctores() {
    this.servicioDoctor.ObtenerListaDoctor().subscribe(

      (rslt) => {
        this._listaDoctor = rslt.lista
      },

      (error: HttpErrorResponse) => {

        console.log(error.message)

      }

    )
  }
  obtenerListaDoctorePaciente() {
    this.servicio.ObtenerListaDoctorPaciente().subscribe(

      (rslt) => {
        this._llistaDoctorPaciente = rslt.objeto
        this.ComprobarChecked()
      },

      (error: HttpErrorResponse) => {

        console.log(error.message)

      }

    )
  }

  LimpiarPaciente() {
    this.seleccionarPaciente = new Paciente()
    this.seleccionarPaciente.idPaciente = 0
    $('input').attr('checked', false)
  }

  ActualizarPaciente() {
    this.ActualizarPacienteServicio()
  }
  EliminarPaciente() {
    this.EliminarPacienteServicio();

  }


  InsertarPaciente() {
    this.servicio.InsertarPaciente(this.seleccionarPaciente).subscribe(

      (rslt) => {
        this.obtenerListaPacientes()
        this.LimpiarPaciente()
      },

      (error: HttpErrorResponse) => {

        console.log(error.message)

      }
    )
  }

  ActualizarPacienteServicio() {
    this.servicio.ActualizarPaciente(this.seleccionarPaciente.idPaciente, this.seleccionarPaciente).subscribe(

      (rslt) => {
        this.obtenerListaPacientes()
        this.LimpiarPaciente()
      },

      (error: HttpErrorResponse) => {

        console.log(error.message)

      }
    )
  }

  EliminarPacienteServicio() {
    this.servicio.EliminarPaciente(this.seleccionarPaciente.idPaciente).subscribe(

      (rslt) => {
        this.obtenerListaPacientes()
        console.log(this.seleccionarPaciente.idPaciente,rslt)
      },

      (error: HttpErrorResponse) => {

        console.log(error.message)

      }
    )
  }
  RegistrarDoctorPacienteService() {
    this.servicio.RegistrarDoctorPaciente(this._DoctorPaciente).subscribe(
      (rslt) => {
        console.log(this._DoctorPaciente)
        this.obtenerListaPacientes()
      },

      (error: HttpErrorResponse) => {

        console.log(error.message)

      }
    )
  }

  EditarPaciente(paciente: Paciente) {
    this.seleccionarPaciente = paciente
    this.obtenerListaDoctorePaciente()
  }
  AgregarDoctor(event: any, doctor: Doctor) {
    if (event.target.checked) {
      this._DoctorPaciente.paciente = this.seleccionarPaciente.idPaciente
      this._DoctorPaciente.doctor = doctor.idDoctor
      this.RegistrarDoctorPacienteService()
    }

    else
      console.log("no", doctor)
  }

}

