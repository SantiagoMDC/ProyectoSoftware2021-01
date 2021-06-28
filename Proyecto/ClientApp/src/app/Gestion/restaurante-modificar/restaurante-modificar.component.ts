import { Location } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { Restaurante } from 'src/app/models/restaurante';
import { RestauranteService } from 'src/app/services/restaurante.service';

@Component({
  selector: 'app-restaurante-modificar',
  templateUrl: './restaurante-modificar.component.html',
  styleUrls: ['./restaurante-modificar.component.css']
})
export class RestauranteModificarComponent implements OnInit {

  constructor(private location:Location,private route:ActivatedRoute,private formBuilder:FormBuilder,private restauranteService:RestauranteService) { }

  registerForm : FormGroup;
  restaurante:Restaurante;
  ngOnInit() {
    this.get();
    this.restaurante = new Restaurante();
    this.registerForm = this.formBuilder.group({
      codigo: [this.restaurante.codigo, Validators.required],
      nombre: [this.restaurante.nombre, Validators.required],
      telefono: [this.restaurante.telefono, Validators.required],
      direccion: [this.restaurante.direccion, Validators.required],
    });
  }

  get():void{
    const codigo = +this.route.snapshot.paramMap.get('codigo');
    this.restauranteService.buscarIdentificacion(codigo.toString()).subscribe(restaurante => {
      this.registerForm.controls['codigo'].setValue(restaurante.codigo);
      this.registerForm.controls['nombre'].setValue(restaurante.nombre);
      this.registerForm.controls['telefono'].setValue(restaurante.telefono);
      this.registerForm.controls['direccion'].setValue(restaurante.direccion);
    });
  }

  get f(){
    return this.registerForm.controls;
  }

  update(){
    this.restaurante = this.registerForm.value;
    this.restauranteService.updateRestaurante(this.restaurante).subscribe(() =>
      this.goBack()
    );

  }
  goBack(): void {
    this.location.back();
  }

  onSubmit(){
    if (this.registerForm.invalid) {
      return;
    }
    this.update();
  }
}
