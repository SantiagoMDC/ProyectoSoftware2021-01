import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';
import { HandleHttpErrorService } from '../@base/handle-http-error.service';
import { Veterinaria } from '../models/veterinaria';

@Injectable({
  providedIn: 'root'
})
export class VeterinariaService {
  baseUrl: string;
 
  constructor(private http:HttpClient,@Inject('BASE_URL') baseUrl: string,private handleErrorService:HandleHttpErrorService) { this.baseUrl = baseUrl}

  Consultar(): Observable<Veterinaria[]>{
    return this.http.get<Veterinaria[]>(this.baseUrl + 'api/Veterinaria')
    .pipe(
        tap(_ => this.handleErrorService.log('Datos enviados')),
        catchError(this.handleErrorService.handleError<Veterinaria[]>('Consulta Veterinaria', null))
      );
    
  }
  
  registrar(veterinaria:Veterinaria):Observable<Veterinaria>{
    return this.http.post<Veterinaria>(this.baseUrl + 'api/Veterinaria',veterinaria).pipe(tap(_=> this.handleErrorService.log('Datos enviados')),
      catchError(this.handleErrorService.handleError<Veterinaria>('Componente Veterinario Registrado',null)));
  }

  buscarIdentificacion(codigo:string):Observable<Veterinaria>
  {
    return this.http.get<Veterinaria>(this.baseUrl + 'api/Veterinaria/' + codigo).pipe(
      catchError(this.handleErrorService.handleError<Veterinaria>('Consulta codigo', null))
    );
  }

  




}