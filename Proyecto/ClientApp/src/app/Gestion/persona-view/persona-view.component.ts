import { Location } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { AlertModalComponent } from 'src/app/@base/alert-modal/alert-modal.component';
import { Persona } from 'src/app/models/persona';
import { PersonaService } from 'src/app/services/persona.service';

@Component({
  selector: 'app-persona-view',
  templateUrl: './persona-view.component.html',
  styleUrls: ['./persona-view.component.css']
})
export class PersonaViewComponent implements OnInit {

  constructor(private location: Location,private route:ActivatedRoute,private formBuilder:FormBuilder,private personaService:PersonaService,private modalService: NgbModal) { }

  registerForm : FormGroup;
  persona:Persona;
  personaresult:Persona;
  ngOnInit() {
    this.get();
    this.persona = new Persona();
    
  }

  get():void{
    const codigo = +this.route.snapshot.paramMap.get('identificacion');
    this.personaService.buscarIdentificacion(codigo.toString()).subscribe(result => {
      this.personaresult = result;
      this.persona.identificacion = this.personaresult.identificacion;
      this.persona.nombre = this.personaresult.nombre;
      this.persona.apellido = this.personaresult.apellido;
      this.persona.edad = this.personaresult.edad;
      this.persona.estadoCivil = this.personaresult.estadoCivil;
      this.persona.sexo = this.personaresult.sexo;
      this.persona.actitud1 = this.personaresult.actitud1;
      this.persona.actitud2 = this.personaresult.actitud2;
      this.persona.actitud3 = this.personaresult.actitud3;
      this.persona.actitudExplicacion = this.personaresult.actitudExplicacion;
      this.persona.actitud5 = this.personaresult.actitud5;
      this.persona.actitud6 = this.personaresult.actitud6;
      this.persona.practica1 = this.personaresult.practica1;
      this.persona.practica2 = this.personaresult.practica2;
      this.persona.practica3 = this.personaresult.practica3;
      this.persona.practica4 = this.personaresult.practica4;
      this.persona.conocimiento1 = this.personaresult.conocimiento1;
      this.persona.conocimiento2 = this.personaresult.conocimiento2;
      this.persona.conocimiento3 = this.personaresult.conocimiento3;
      this.persona.conocimiento4 = this.personaresult.conocimiento4;
      this.persona.conocimiento5 = this.personaresult.conocimiento5;
      this.persona.conocimientoExplicacion = this.personaresult.conocimientoExplicacion;
      this.persona.paisDeProcedencia = this.personaresult.paisDeProcedencia;
      this.persona.nivelEducativo = this.personaresult.nivelEducativo;


      
    });
  }

  get f(){
    return this.registerForm.controls;
  }

  
  goBack(): void {
    this.location.back();
  }

  atras(){
    this.goBack()
  }
}
