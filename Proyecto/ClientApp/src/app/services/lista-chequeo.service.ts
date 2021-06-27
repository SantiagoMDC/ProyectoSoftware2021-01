import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';
import { HandleHttpErrorService } from '../@base/handle-http-error.service';
import { ListaChequeo } from '../models/lista-chequeo';

@Injectable({
  providedIn: 'root'
})
export class ListaChequeoService {
  baseUrl: string;
 
  constructor(private http:HttpClient,@Inject('BASE_URL') baseUrl: string,private handleErrorService:HandleHttpErrorService) { this.baseUrl = baseUrl}

  Consultar(): Observable<ListaChequeo[]>{
    return this.http.get<ListaChequeo[]>(this.baseUrl + 'api/ListaChequeo')
    .pipe(
        tap(_ => this.handleErrorService.log('Datos enviados')),
        catchError(this.handleErrorService.handleError<ListaChequeo[]>('Consulta ListaChequeo', null))
      );
    
  }
  
  registrar(listaChequeo:ListaChequeo):Observable<ListaChequeo>{
    return this.http.post<ListaChequeo>(this.baseUrl + 'api/ListaChequeo',listaChequeo).pipe(tap(_=> this.handleErrorService.log('Datos enviados')),
      catchError(this.handleErrorService.handleError<ListaChequeo>('ListaChequeo Registrada',null)));
  }

  buscarIdentificacion(codigo:string):Observable<ListaChequeo>
  {
    return this.http.get<ListaChequeo>(this.baseUrl + 'api/ListaChequeo/' + codigo).pipe(
      catchError(this.handleErrorService.handleError<ListaChequeo>('Consulta codigo', null))
    );
  }
}