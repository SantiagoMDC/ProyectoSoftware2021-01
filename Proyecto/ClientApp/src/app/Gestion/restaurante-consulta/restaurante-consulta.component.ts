import { Component, OnInit } from '@angular/core';
import { Restaurante } from 'src/app/models/restaurante';
import { RestauranteService } from 'src/app/services/restaurante.service';
import { SignalRService } from 'src/app/services/signal-r.service';

@Component({
  selector: 'app-restaurante-consulta',
  templateUrl: './restaurante-consulta.component.html',
  styleUrls: ['./restaurante-consulta.component.css']
})
export class RestauranteConsultaComponent implements OnInit {

  restaurantes:Restaurante[];
  Total :Number = 0;
  searchText = "";
  searchText1 = "";
  constructor(private service:RestauranteService,  private signalRService: SignalRService) { }

  ngOnInit(): void {
    this.get();
    this.getAllRestaurantes();
    
    this.signalRService.restauranteReceived.subscribe((restaurante: Restaurante) => {
      this.restaurantes.push(restaurante);
    });
  }
  get(){
    this.service.Consultar().subscribe(result => {
      this.restaurantes = result;
    });
  }

  getAllRestaurantes() {
    this.service.Consultar().subscribe(result => {
      this.restaurantes = result;
    })
  }
}
