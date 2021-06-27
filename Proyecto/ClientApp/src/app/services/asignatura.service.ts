import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { tap, catchError } from 'rxjs/operators';
import { HandleHttpErrorService } from '../@base/handle-http-error.service';
import { Asignatura } from '../models/asignatura';

@Injectable({
  providedIn: 'root'
})
export class AsignaturaService {

  baseUrl:string;
  constructor(private http:HttpClient,@Inject('BASE_URL') baseUrl: string,private handleError:HandleHttpErrorService) {this.baseUrl = baseUrl }

  registrar(asignatura:Asignatura):Observable<Asignatura>
  {
    return this.http.post<Asignatura>(this.baseUrl + 'api/Asignatura',asignatura).pipe(
      tap(_=> this.handleError.log('Datos enviados')),
      catchError(this.handleError.handleError<Asignatura>('Asignatura Registrada',null))
    );
  }

  consultar():Observable<Asignatura[]>
  {
    return this.http.get<Asignatura[]>(this.baseUrl + 'api/Asignatura').pipe(
      tap(_=> this.handleError.log('Datos enviados')),
      catchError(this.handleError.handleError<Asignatura[]>('Consulta asignaturas',null))
    );
  }
}
