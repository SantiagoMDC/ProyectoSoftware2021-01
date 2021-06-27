import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';
import { HandleHttpErrorService } from '../@base/handle-http-error.service';
import { Ambiental } from '../models/ambiental';

@Injectable({
  providedIn: 'root'
})
export class AmbientalService {
  baseUrl: string;
 
  constructor(private http:HttpClient,@Inject('BASE_URL') baseUrl: string,private handleErrorService:HandleHttpErrorService) { this.baseUrl = baseUrl}

  Consultar(): Observable<Ambiental[]>{
    return this.http.get<Ambiental[]>(this.baseUrl + 'api/Ambiental')
    .pipe(
        tap(_ => this.handleErrorService.log('Datos enviados')),
        catchError(this.handleErrorService.handleError<Ambiental[]>('Consulta Ambiental', null))
      );
    
  }
  
  registrar(ambiental:Ambiental):Observable<Ambiental>{
    return this.http.post<Ambiental>(this.baseUrl + 'api/Ambiental',ambiental).pipe(tap(_=> this.handleErrorService.log('Datos enviados')),
      catchError(this.handleErrorService.handleError<Ambiental>('Componente Ambiental Registrado',null)));
  }

  buscarIdentificacion(codigo:string):Observable<Ambiental>
  {
    return this.http.get<Ambiental>(this.baseUrl + 'api/Ambiental/' + codigo).pipe(
      catchError(this.handleErrorService.handleError<Ambiental>('Consulta codigo', null))
    );
  }

  




}