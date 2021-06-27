import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { AlertModalComponent } from 'src/app/@base/alert-modal/alert-modal.component';
import { ListaChequeo } from 'src/app/models/lista-chequeo';
import { Restaurante } from 'src/app/models/restaurante';
import { ListaChequeoService } from 'src/app/services/lista-chequeo.service';
import { RestauranteService } from 'src/app/services/restaurante.service';

@Component({
  selector: 'app-lista-chequeo-register',
  templateUrl: './lista-chequeo-register.component.html',
  styleUrls: ['./lista-chequeo-register.component.css']
})
export class ListaChequeoRegisterComponent implements OnInit {

  listaChequeo:ListaChequeo;
  submitted = false;
  restaurante: Restaurante;
  formRegister: FormGroup;

  constructor(private service:RestauranteService,
    private listaChequeoService: ListaChequeoService,
    private formBuilder: FormBuilder,
    private modalService: NgbModal) { }

  ngOnInit() {
    this.restaurante = new Restaurante;
    this.builForm();
  }
  private builForm() {
    this.listaChequeo = new ListaChequeo();
    this.listaChequeo.codigoRestaurante = '';
    this.listaChequeo.nombreRestaurante = '';
    this.listaChequeo.item1 = '';
    this.listaChequeo.item2 = '';

    this.formRegister = this.formBuilder.group({
      codigoRestaurante: [this.listaChequeo.codigoRestaurante, Validators.required],
      nombreRestaurante: [this.listaChequeo.nombreRestaurante, Validators.required],
      item1: [this.listaChequeo.item1, Validators.required],
      item2: [this.listaChequeo.item2, Validators.required],
    });
  }

  add() {
    this.listaChequeoService.registrar(this.listaChequeo).subscribe(p => {
      if (p != null) {
        this.onReset();
        const messageBox = this.modalService.open(AlertModalComponent)
        messageBox.componentInstance.title = "Resultado Operación";
        messageBox.componentInstance.message = 'ListaChequeo Registrada Con exito!! :-)';

        
      }
    })
  }
  getR(){
    this.service.buscarIdentificacion(this.restaurante.codigo).subscribe(result => {
      this.restaurante = result;
      this.listaChequeo.codigoRestaurante = this.restaurante.codigo;
      this.listaChequeo.nombreRestaurante = this.restaurante.nombre;
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
  onReset() {
    this.submitted = false;
    this.formRegister.reset();
  }

}
