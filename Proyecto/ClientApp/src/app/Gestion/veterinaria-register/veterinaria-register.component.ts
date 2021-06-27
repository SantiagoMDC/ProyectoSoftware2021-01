import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { AlertModalComponent } from 'src/app/@base/alert-modal/alert-modal.component';
import { Persona } from 'src/app/models/persona';
import { Veterinaria } from 'src/app/models/veterinaria';
import { PersonaService } from 'src/app/services/persona.service';
import { VeterinariaService } from 'src/app/services/veterinaria.service';


@Component({
  selector: 'app-veterinaria-register',
  templateUrl: './veterinaria-register.component.html',
  styleUrls: ['./veterinaria-register.component.css']
})
export class VeterinariaRegisterComponent implements OnInit {

   
  veterinaria:Veterinaria;
  submitted = false;
  persona: Persona;
  formRegister: FormGroup;

  
  constructor(private service:PersonaService,
    private veterinariaService: VeterinariaService,
    private formBuilder: FormBuilder,
    private modalService: NgbModal) { }

  ngOnInit() {
    this.persona = new Persona;
    this.builForm();
  }
  private builForm() {
    this.veterinaria = new Veterinaria();
    this.veterinaria.codigoManipulador = '';
    this.veterinaria.nombreManipulador = '';

    this.formRegister = this.formBuilder.group({
      codigoManipulador: [this.veterinaria.codigoManipulador, Validators.required],
      nombreManipulador: [this.veterinaria.nombreManipulador, Validators.required],
      
    });
  }

  add() {
    this.veterinariaService.registrar(this.veterinaria).subscribe(p => {
      if (p != null) {
        this.onReset();
        const messageBox = this.modalService.open(AlertModalComponent)
        messageBox.componentInstance.title = "Resultado Operación";
        messageBox.componentInstance.message = 'Componente Veterinario Registrado Con exito!! :-)';

        
      }
    })
  }
  getR(){
    this.service.buscarIdentificacion(this.persona.identificacion).subscribe(result => {
      this.persona = result;
      this.veterinaria.codigoManipulador = this.persona.identificacion;
      this.veterinaria.nombreManipulador = this.persona.nombre;
      if(result != null){
        const messageBox = this.modalService.open(AlertModalComponent)
        messageBox.componentInstance.title = "Resultado Operación";
        messageBox.componentInstance.message = 'Persona Encontrado !! :-)';
      }else{
        const messageBox1 = this.modalService.open(AlertModalComponent)
        messageBox1.componentInstance.title = "Resultado Operación";
        messageBox1.componentInstance.message = 'Persona No Encontrado !! :-)';

      }
      
    });
  }
  onReset() {
    this.submitted = false;
    this.formRegister.reset();
  }


}
