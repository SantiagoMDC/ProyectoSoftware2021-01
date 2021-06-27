import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { AlertModalComponent } from 'src/app/@base/alert-modal/alert-modal.component';
import { Persona } from 'src/app/models/persona';
import { Restaurante } from 'src/app/models/restaurante';
import { Vinculacion } from 'src/app/models/vinculacion';
import { PersonaService } from 'src/app/services/persona.service';
import { RestauranteService } from 'src/app/services/restaurante.service';
import { VinculacionService } from 'src/app/services/vinculacion.service';

@Component({
  selector: 'app-vinculacion',
  templateUrl: './vinculacion.component.html',
  styleUrls: ['./vinculacion.component.css']
})
export class VinculacionComponent implements OnInit {

  formRegister: FormGroup;
  vinculacion: Vinculacion;
  restaurante:Restaurante;
  persona:Persona;
  submitted = false;
  constructor(
    private servicep:PersonaService,
    private service:RestauranteService,
    private vinculacionService: VinculacionService,
    private formBuilder: FormBuilder,
    private modalService: NgbModal) { }
    

  ngOnInit() {
    this.restaurante = new Restaurante;
    this.persona = new Persona;
    this.builForm();
  }

  private builForm() {
    this.vinculacion = new Vinculacion();
    this.vinculacion.codigoRestaurante = '';
    this.vinculacion.nombreRestaurante = '';
    this.vinculacion.codigoPersona = '';
    this.vinculacion.nombrePersona = '';

    this.formRegister = this.formBuilder.group({
      codigoRestaurante: [this.vinculacion.codigoRestaurante, Validators.required],
      nombreRestaurante: [this.vinculacion.nombreRestaurante, Validators.required],
      codigoPersona: [this.vinculacion.codigoPersona, Validators.required],
      nombrePersona: [this.vinculacion.nombrePersona, Validators.required],
    });
  }

  get f() {
    return this.formRegister.controls;
  }

  add() {
    this.vinculacionService.registrar(this.vinculacion).subscribe(p => {
      if (p != null) {
        this.onReset();
        const messageBox = this.modalService.open(AlertModalComponent)
        messageBox.componentInstance.title = "Resultado Operación";
        messageBox.componentInstance.message = 'Vinculo Registrado Con exito!! :-)';

        
      }
    })
  }
  getR(){
    this.service.buscarIdentificacion(this.restaurante.codigo).subscribe(result => {
      this.restaurante = result;
      this.vinculacion.codigoRestaurante = this.restaurante.codigo;
      this.vinculacion.nombreRestaurante = this.restaurante.nombre;
      if(result != null){
        const messageBox = this.modalService.open(AlertModalComponent)
        messageBox.componentInstance.title = "Resultado Operación";
        messageBox.componentInstance.message = 'Restautante Encontrado !! :-)';
      }else{
        const messageBox1 = this.modalService.open(AlertModalComponent)
        messageBox1.componentInstance.title = "Resultado Operación";
        messageBox1.componentInstance.message = 'Restautante No Encontrado !! :-)';

      }
    });
  }
  getP(){
    this.servicep.buscarIdentificacion(this.persona.identificacion).subscribe(result => {
      this.persona = result;
      this.vinculacion.codigoPersona = this.persona.identificacion;
      this.vinculacion.nombrePersona = this.persona.nombre;
      if(result != null){
        const messageBox = this.modalService.open(AlertModalComponent)
        messageBox.componentInstance.title = "Resultado Operación";
        messageBox.componentInstance.message = 'Persona Encontrada !! :-)';
      }else{
        const messageBox1 = this.modalService.open(AlertModalComponent)
        messageBox1.componentInstance.title = "Resultado Operación";
        messageBox1.componentInstance.message = 'Persona No Encontrada !! :-(';

      }


    });
  }

  onSubmit() {
    this.submitted = true;
    if (this.formRegister.invalid) {
      return;
    }
    this.add();
  }

  onReset() {
    this.submitted = false;
    this.formRegister.reset();
  }
}