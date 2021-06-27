import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { AlertModalComponent } from 'src/app/@base/alert-modal/alert-modal.component';
import { Ambiental } from 'src/app/models/ambiental';
import { Persona } from 'src/app/models/persona';
import { AmbientalService } from 'src/app/services/ambiental.service';
import { PersonaService } from 'src/app/services/persona.service';

@Component({
  selector: 'app-ambiental-register',
  templateUrl: './ambiental-register.component.html',
  styleUrls: ['./ambiental-register.component.css']
})
export class AmbientalRegisterComponent implements OnInit {

  
  ambiental:Ambiental;
  submitted = false;
  persona: Persona;
  formRegister: FormGroup;

  constructor(private service:PersonaService,
    private ambientalService: AmbientalService,
    private formBuilder: FormBuilder,
    private modalService: NgbModal) { }

  ngOnInit() {
    this.persona = new Persona;
    this.builForm();
  }
  private builForm() {
    this.ambiental = new Ambiental();
    this.ambiental.codigoManipulador = '';
    this.ambiental.nombreManipulador = '';
    this.ambiental.barrio = '';

    this.formRegister = this.formBuilder.group({
      codigoManipulador: [this.ambiental.codigoManipulador, Validators.required],
      nombreManipulador: [this.ambiental.nombreManipulador, Validators.required],
      barrio: [this.ambiental.barrio, Validators.required],
    });
  }

  add() {
    this.ambientalService.registrar(this.ambiental).subscribe(p => {
      if (p != null) {
        this.onReset();
        const messageBox = this.modalService.open(AlertModalComponent)
        messageBox.componentInstance.title = "Resultado Operación";
        messageBox.componentInstance.message = 'Componente Ambiental Registrado Con exito!! :-)';

        
      }
    })
  }
  getR(){
    this.service.buscarIdentificacion(this.persona.identificacion).subscribe(result => {
      this.persona = result;
      this.ambiental.codigoManipulador = this.persona.identificacion;
      this.ambiental.nombreManipulador = this.persona.nombre;
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
