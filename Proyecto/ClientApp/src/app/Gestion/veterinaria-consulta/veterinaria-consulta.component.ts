import { Component, OnInit } from '@angular/core';
import { Veterinaria } from 'src/app/models/veterinaria';
import { VeterinariaService } from 'src/app/services/veterinaria.service';

@Component({
  selector: 'app-veterinaria-consulta',
  templateUrl: './veterinaria-consulta.component.html',
  styleUrls: ['./veterinaria-consulta.component.css']
})
export class VeterinariaConsultaComponent implements OnInit {
  veterinaria:Veterinaria[];
  constructor(private service:VeterinariaService) { }

  ngOnInit() {
    this.get();
  }
  get(){
    this.service.Consultar().subscribe(result => {
      this.veterinaria = result;
    });
  }
}
