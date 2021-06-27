import { Component, OnInit } from '@angular/core';
import { ListaChequeo } from 'src/app/models/lista-chequeo';
import { ListaChequeoService } from 'src/app/services/lista-chequeo.service';

@Component({
  selector: 'app-lista-chequeo-consulta',
  templateUrl: './lista-chequeo-consulta.component.html',
  styleUrls: ['./lista-chequeo-consulta.component.css']
})
export class ListaChequeoConsultaComponent implements OnInit {

  listaChequeos:ListaChequeo[];
  Total :Number = 0;
  searchText = "";
  searchText1 = "";
  constructor(private service:ListaChequeoService) { }

  ngOnInit(): void {
    this.get();
  }
  get(){
    this.service.Consultar().subscribe(result => {
      this.listaChequeos = result;
    });
  }

}
