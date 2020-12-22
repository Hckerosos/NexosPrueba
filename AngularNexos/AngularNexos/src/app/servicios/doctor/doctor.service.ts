import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { RespuestaDoctor } from 'src/app/models/doctor/respuesta-doctor';


@Injectable({
  providedIn: 'root'
})
export class DoctorService {

  constructor(private http: HttpClient) { }

  public ObtenerListaDoctor(): Observable<RespuestaDoctor> {

    return this.http.get<RespuestaDoctor>(

      environment.apiUrl + `/api/doctor`,

    )

  }

}
