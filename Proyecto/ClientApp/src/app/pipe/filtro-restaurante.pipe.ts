import { Pipe, PipeTransform } from '@angular/core';
import { Restaurante } from '../models/restaurante';
@Pipe({
  name: 'filtroRestaurante'
})
export class FiltroRestaurantePipe implements PipeTransform {

  transform(restaurante: Restaurante[],  searchText: string): any {
    if (searchText === undefined || searchText === '') return restaurante;
      return restaurante.filter(p =>
      p.codigo.toLowerCase()
    .indexOf(searchText.toLowerCase()) !== -1||p.nombre.toLowerCase().indexOf(searchText.toLowerCase()) !== -1);
    }
    
    

}
