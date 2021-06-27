import { Component, OnInit } from '@angular/core';
import {FormGroup,FormBuilder,Validators,AbstractControl} from '@angular/forms'
import { Persona } from 'src/app/models/persona';
import { PersonaService} from 'src/app/services/persona.service';
import { AlertModalComponent } from 'src/app/@base/alert-modal/alert-modal.component';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-persona-register',
  templateUrl: './persona-register.component.html',
  styleUrls: ['./persona-register.component.css']
})
export class PersonaRegisterComponent implements OnInit {

  registerForm:FormGroup;
  submitted = false;
  persona:Persona;
  constructor(private formBuilder:FormBuilder,private personaService:PersonaService,private modalService: NgbModal) { }

  ngOnInit() {
    this.buildForm();
  }

  private buildForm()
  {
    this.persona = new Persona();
    this.persona.identificacion = '';  
    this.persona.nombre = '';
    this.persona.apellido = '';
    this.persona.sexo = '';
    this.persona.edad = 0;
    this.persona.estadoCivil = '';
    this.persona.paisDeProcedencia = '';
    this.persona.nivelEducativo = '';
    this.persona.conocimiento1 = '';
    this.persona.conocimiento2 = '';
    this.persona.conocimiento3 = '';
    this.persona.conocimiento4 = '';
    this.persona.conocimiento5 = '';
    this.persona.conocimientoExplicacion = '';
    this.persona.actitud1 = '';
    this.persona.actitud2 = '';
    this.persona.actitud3 = '';
    this.persona.actitudExplicacion = '';
    this.persona.actitud5 = '';
    this.persona.actitud6 = '';
    this.persona.practica1 = '';
    this.persona.practica2 = '';
    this.persona.practica3 = '';
    this.persona.practica4 = '';
    this.registerForm = this.formBuilder.group({
      identificacion: [this.persona.identificacion, Validators.required],
      nombre: [this.persona.nombre, Validators.required],
      apellido: [this.persona.apellido, Validators.required],
      sexo: [this.persona.sexo, Validators.required],
      edad: [this.persona.edad, Validators.required],
      estadoCivil: [this.persona.estadoCivil, Validators.required],
      paisDeProcedencia: [this.persona.paisDeProcedencia, Validators.required],
      nivelEducativo: [this.persona.nivelEducativo, Validators.required],
      conocimiento1: [this.persona.conocimiento1, Validators.required],
      conocimiento2: [this.persona.conocimiento2, Validators.required],
      conocimiento3: [this.persona.conocimiento3, Validators.required],
      conocimiento4: [this.persona.conocimiento4, Validators.required],
      conocimiento5: [this.persona.conocimiento5, Validators.required],
      conocimientoExplicacion: [this.persona.conocimientoExplicacion, Validators.required],
      actitud1: [this.persona.actitud1, Validators.required],
      actitud2: [this.persona.actitud2, Validators.required],
      actitud3: [this.persona.actitud3, Validators.required],
      actitudExplicacion: [this.persona.actitudExplicacion, Validators.required],
      actitud5: [this.persona.actitud5, Validators.required],
      actitud6: [this.persona.actitud6, Validators.required],
      practica1: [this.persona.practica1, Validators.required],
      practica2: [this.persona.practica2, Validators.required],
      practica3: [this.persona.practica3, Validators.required],
      practica4: [this.persona.practica4, Validators.required]
    });
  }

  get f() { 
    return this.registerForm.controls;
  }
    

  onSubmit(){
    this.submitted = true;
    if (this.registerForm.invalid) {
      return;
    }
    this.add();
  }

  add(){
    this.persona = this.registerForm.value;
    this.personaService.registrar(this.persona).subscribe(p => {
      if (p != null) {
        const messageBox = this.modalService.open(AlertModalComponent)
        messageBox.componentInstance.title = "Resultado Operación";
        messageBox.componentInstance.message = 'Restaurante Registrado Con exito!! :-)';
        this.onReset();
      }
    })
  }

  onReset() {
    this.submitted = false;
    this.registerForm.reset();
  }
}


