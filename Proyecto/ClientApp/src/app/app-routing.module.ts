import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { PersonaRegisterComponent } from './Gestion/persona-register/persona-register.component';
import { PersonaConsultaComponent } from './Gestion/persona-consulta/persona-consulta.component';
import { RestauranteRegisterComponent } from './Gestion/restaurante-register/restaurante-register.component';
import { RestauranteConsultaComponent } from './Gestion/restaurante-consulta/restaurante-consulta.component';
import { ListaChequeoRegisterComponent } from './Gestion/lista-chequeo-register/lista-chequeo-register.component';
import { ListaChequeoConsultaComponent } from './Gestion/lista-chequeo-consulta/lista-chequeo-consulta.component';
import { HomeComponent } from './home/home.component';
import { ExamenRegisterComponent } from './Gestion/examen-register/examen-register.component'
import { ExamenConsultaComponent } from './Gestion/examen-consulta/examen-consulta.component'
import { AmbientalRegisterComponent } from './Gestion/ambiental-register/ambiental-register.component'
import { AmbientalConsultaComponent } from './Gestion/ambiental-consulta/ambiental-consulta.component'
import { VeterinariaRegisterComponent } from './Gestion/veterinaria-register/veterinaria-register.component'
import { VeterinariaConsultaComponent } from './Gestion/veterinaria-consulta/veterinaria-consulta.component'

import { VinculacionComponent} from './Gestion/vinculacion/vinculacion.component';
import { VinculacionConsultaComponent} from './Gestion/vinculacion-consulta/vinculacion-consulta.component';
import { LoginComponent } from './login/login.component' 
import { AuthGuard } from './services/auth.guard';


import { from } from 'rxjs';
import { RestauranteModificarComponent } from './Gestion/restaurante-modificar/restaurante-modificar.component';
import { PersonaViewComponent } from './Gestion/persona-view/persona-view.component';
const routes:Routes = [
  {path: '', redirectTo:'/loginComponent', pathMatch:'full'},
  {
    path:'loginComponent',
    component:LoginComponent
  },
  
  {
    path:'personaRegister',
    component:PersonaRegisterComponent,canActivate: [AuthGuard]

  },
  {
    path:'personaConsulta',
    component:PersonaConsultaComponent,canActivate: [AuthGuard]

  },
  {
    path:'restauranteRegister',
    component:RestauranteRegisterComponent,canActivate: [AuthGuard]

  },
  {
    path:'restauranteConsulta',
    component:RestauranteConsultaComponent,canActivate: [AuthGuard]

  },
  {
    path:'listaChequeoRegister',
    component:ListaChequeoRegisterComponent,canActivate: [AuthGuard]

  },
  {
    path:'listaChequeoConsulta',
    component:ListaChequeoConsultaComponent,canActivate: [AuthGuard]

  },
  {
    path:'homeComponent',
    component:HomeComponent,

  },
  {
    path:'vinculacionComponent',
    component:VinculacionComponent,canActivate: [AuthGuard]

  },
  {
    path:'vinculacionConsultaComponent',
    component:VinculacionConsultaComponent,canActivate: [AuthGuard]

  },
  {
    path:'examenRegisterComponent',
    component:ExamenRegisterComponent,canActivate: [AuthGuard]

  },
  {
    path:'examenConsulta',
    component:ExamenConsultaComponent,canActivate: [AuthGuard]

  },
  {
    path:'ambientalRegister',
    component:AmbientalRegisterComponent,canActivate: [AuthGuard]

  },
  {
    path:'ambientalConsulta',
    component:AmbientalConsultaComponent,canActivate: [AuthGuard]

  },
  {
    path:'veterinariaRegister',
    component:VeterinariaRegisterComponent,canActivate: [AuthGuard]

  },
  {
    path:'veterinariaConsulta',
    component:VeterinariaConsultaComponent,canActivate: [AuthGuard]

  },
  {
    path:'restauranteUpdate/:codigo',
    component:RestauranteModificarComponent,canActivate: [AuthGuard]

  },
  {
    path:'personaView/:identificacion',
    component:PersonaViewComponent,canActivate: [AuthGuard]

  }
];

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forRoot(routes)
  ]
})
export class AppRoutingModule { }
