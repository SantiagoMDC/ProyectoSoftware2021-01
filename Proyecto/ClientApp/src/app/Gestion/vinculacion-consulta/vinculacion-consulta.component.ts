import { Component, OnInit } from '@angular/core';
import { Vinculacion } from 'src/app/models/vinculacion';
import { VinculacionService } from 'src/app/services/vinculacion.service';

@Component({
  selector: 'app-vinculacion-consulta',
  templateUrl: './vinculacion-consulta.component.html',
  styleUrls: ['./vinculacion-consulta.component.css']
})
export class VinculacionConsultaComponent implements OnInit {

  vinculaciones:Vinculacion[];
  Total :Number = 0;
  searchText = "";
  searchText1 = "";
  constructor(private service:VinculacionService) { }

  ngOnInit(): void {
    this.get();
  }
  get(){
    this.service.Consultar().subscribe(result => {
      this.vinculaciones = result;
    });
  }

}
