import { Pipe, PipeTransform } from '@angular/core';
import { from } from 'rxjs';
import { Persona } from '../models/persona';

@Pipe({
  name: 'filtroPersona'
})
export class FiltroPersonaPipe implements PipeTransform {

  transform(persona: Persona[],  searchText: string): any {
    if (searchText === undefined || searchText === '') return persona;
      return persona.filter(p =>
      p.identificacion.toLowerCase()
    .indexOf(searchText.toLowerCase()) !== -1||p.nombre.toLowerCase().indexOf(searchText.toLowerCase()) !== -1);
    }

}
