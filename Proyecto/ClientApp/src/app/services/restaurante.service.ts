import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';
import { HandleHttpErrorService } from '../@base/handle-http-error.service';
import { Restaurante } from '../models/restaurante';

@Injectable({
  providedIn: 'root'
})
export class RestauranteService {
  baseUrl: string;
 
  constructor(private http:HttpClient,@Inject('BASE_URL') baseUrl: string,private handleErrorService:HandleHttpErrorService) { this.baseUrl = baseUrl}

  Consultar(): Observable<Restaurante[]>{
    return this.http.get<Restaurante[]>(this.baseUrl + 'api/Restaurante')
    .pipe(
        tap(_ => this.handleErrorService.log('Datos enviados')),
        catchError(this.handleErrorService.handleError<Restaurante[]>('Consulta Restaurante', null))
      );
    
  }
  
  registrar(restaurante:Restaurante):Observable<Restaurante>{
    return this.http.post<Restaurante>(this.baseUrl + 'api/Restaurante',restaurante).pipe(tap(_=> this.handleErrorService.log('Datos enviados')),
      catchError(this.handleErrorService.handleError<Restaurante>('Restaurante Registrado',null)));
  }

  buscarIdentificacion(codigo:string):Observable<Restaurante>
  {
    return this.http.get<Restaurante>(this.baseUrl + 'api/Restaurante/' + codigo).pipe(
      catchError(this.handleErrorService.handleError<Restaurante>('Consulta codigo', null))
    );
  }

  




}