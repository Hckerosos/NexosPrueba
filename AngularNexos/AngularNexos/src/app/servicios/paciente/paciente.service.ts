import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Respuesta } from 'src/app/models/paciente/respuesta';
import { Paciente } from 'src/app/models/paciente/paciente';
import { DoctorPaciente, RespuestaDoctorPaciente } from 'src/app/models/doctor-paciente/doctor-paciente';
import { RespuestaDoctor } from 'src/app/models/doctor/respuesta-doctor';

@Injectable({
  providedIn: 'root'
})
export class PacienteService {

  constructor(private http: HttpClient) {


   }
l
  public ObtenerListaPaciente(): Observable<Respuesta> {

    return this.http.get<Respuesta>(

      environment.apiUrl + `/api/paciente`,

    )

  }

  public ObtenerListaDoctorPaciente(): Observable<RespuestaDoctorPaciente> {

    return this.http.get<RespuestaDoctorPaciente>(

      environment.apiUrl + `/api/paciente/doctor`,

    )

  }

  public InsertarPaciente(paciente :Paciente  ): Observable<Respuesta> {

    return this.http.post<Respuesta>(

      environment.apiUrl + `/api/paciente`, paciente

    )

  }

  public ActualizarPaciente(id:number,paciente: Paciente): Observable<Respuesta> {

    return this.http.put<Respuesta>(

      environment.apiUrl + `/api/paciente/${id}`, paciente

    )

  }

  public EliminarPaciente(id: number): Observable<Respuesta> {

    return this.http.delete<Respuesta>(

      environment.apiUrl + `/api/paciente/${id}`,

    )

  }

  public RegistrarDoctorPaciente(paciente: DoctorPaciente): Observable<Respuesta> {

    return this.http.post<Respuesta>(

      environment.apiUrl + `/api/paciente/doctorpaciente/`, paciente

    )

  }

}
