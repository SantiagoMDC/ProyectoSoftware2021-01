import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';
import { HandleHttpErrorService } from '../@base/handle-http-error.service';
import { Vinculacion } from '../models/vinculacion';

@Injectable({
  providedIn: 'root'
})
export class VinculacionService {
  baseUrl: string;
 
  constructor(private http:HttpClient,@Inject('BASE_URL') baseUrl: string,private handleErrorService:HandleHttpErrorService) { this.baseUrl = baseUrl}

  Consultar(): Observable<Vinculacion[]>{
    return this.http.get<Vinculacion[]>(this.baseUrl + 'api/Vinculacion')
    .pipe(
        tap(_ => this.handleErrorService.log('Datos enviados')),
        catchError(this.handleErrorService.handleError<Vinculacion[]>('Consulta Vinculo', null))
      );
    
  }
  
  registrar(vinculacion:Vinculacion):Observable<Vinculacion>{
    return this.http.post<Vinculacion>(this.baseUrl + 'api/Vinculacion',vinculacion).pipe(tap(_=> this.handleErrorService.log('Datos enviados')),
      catchError(this.handleErrorService.handleError<Vinculacion>('Vinculo Registrado',null)));
  }

  buscarIdentificacion(codigo:string):Observable<Vinculacion>
  {
    return this.http.get<Vinculacion>(this.baseUrl + 'api/Vinculacion/' + codigo).pipe(
      catchError(this.handleErrorService.handleError<Vinculacion>('Consulta codigo', null))
    );
  }

}
