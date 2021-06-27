import { Pipe, PipeTransform } from '@angular/core';
import { Vinculacion } from '../models/vinculacion';
import { VinculacionService } from '../services/vinculacion.service';

@Pipe({
  name: 'filtroVinculacion'
})
export class FiltroVinculacionPipe implements PipeTransform {

  transform(vinculacion: Vinculacion[],  searchText: string): any {
    if (searchText === undefined || searchText === '') return vinculacion;
      return vinculacion.filter(p =>
      p.codigo.toLowerCase()
    .indexOf(searchText.toLowerCase()) !== -1||p.nombreRestaurante.toLowerCase().indexOf(searchText.toLowerCase()) !== -1);
    }
    
}
