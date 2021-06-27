import { Component, OnInit } from '@angular/core';
import { Ambiental } from 'src/app/models/ambiental';
import { AmbientalService } from 'src/app/services/ambiental.service';

@Component({
  selector: 'app-ambiental-consulta',
  templateUrl: './ambiental-consulta.component.html',
  styleUrls: ['./ambiental-consulta.component.css']
})
export class AmbientalConsultaComponent implements OnInit {
  ambiental:Ambiental[];

  constructor(private service:AmbientalService) { }

  ngOnInit() {
    this.get();
  }
  get(){
    this.service.Consultar().subscribe(result => {
      this.ambiental = result;
    });
  }

}
