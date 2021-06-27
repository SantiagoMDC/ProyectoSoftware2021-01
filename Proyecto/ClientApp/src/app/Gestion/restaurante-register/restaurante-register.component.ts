import { Component, OnInit } from '@angular/core';
import { RestauranteService } from '../../services/restaurante.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Restaurante } from '../../models/restaurante';
import { AlertModalComponent } from 'src/app/@base/alert-modal/alert-modal.component';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { SignalRService } from 'src/app/services/signal-r.service';


@Component({
  selector: 'app-restaurante-register',
  templateUrl: './restaurante-register.component.html',
  styleUrls: ['./restaurante-register.component.css']
})
export class RestauranteRegisterComponent implements OnInit {

  formRegister: FormGroup;
  restaurante: Restaurante;
  submitted = false;
  constructor(
    private restauranteService: RestauranteService,
    private formBuilder: FormBuilder,
    private modalService: NgbModal,
    private signalRService: SignalRService
    ) { }
    

  ngOnInit() {
    this.builForm();
  }

  private builForm() {
    this.restaurante = new Restaurante();
    this.restaurante.codigo = '';
    this.restaurante.nombre = '';
    this.restaurante.direccion = '';
    this.restaurante.telefono = '';

    this.formRegister = this.formBuilder.group({
      codigo: [this.restaurante.codigo, Validators.required],
      nombre: [this.restaurante.nombre, Validators.required],
      direccion: [this.restaurante.direccion, Validators.required],
      telefono: [this.restaurante.telefono, Validators.required],
    });
  }

  get f() {
    return this.formRegister.controls;
  }

  add() {
    this.restaurante = this.formRegister.value;
    this.restauranteService.registrar(this.restaurante).subscribe(p => {
      if (p != null) {
        this.onReset();
        const messageBox = this.modalService.open(AlertModalComponent)
        messageBox.componentInstance.title = "Resultado Operación";
        messageBox.componentInstance.message = 'Restaurante Registrado Con exito!! :-)';

        
      }
    })
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
