import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule} from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { HeadersComponent } from './Components/headers/headers.component';
import { MenuComponent } from './Components/menu/menu.component';
import { ContentComponent } from './Components/content/content.component';
import { FooterComponent } from './Components/footer/footer.component';
import { AppRoutingModule } from './app-routing.module';

import { PersonaRegisterComponent } from './Gestion/persona-register/persona-register.component';
import { PersonaConsultaComponent } from './Gestion/persona-consulta/persona-consulta.component';
import { RestauranteRegisterComponent } from './Gestion/restaurante-register/restaurante-register.component';
import { RestauranteConsultaComponent } from './Gestion/restaurante-consulta/restaurante-consulta.component';
import { ListaChequeoRegisterComponent } from './Gestion/lista-chequeo-register/lista-chequeo-register.component';
import { ListaChequeoConsultaComponent } from './Gestion/lista-chequeo-consulta/lista-chequeo-consulta.component';
import { NgbModule} from '@ng-bootstrap/ng-bootstrap';
import { AlertModalComponent } from './@base/alert-modal/alert-modal.component';
import { FiltroPersonaPipe } from './pipe/filtro-persona.pipe';
import { FiltroRestaurantePipe } from './pipe/filtro-restaurante.pipe';
import { VinculacionComponent } from './Gestion/vinculacion/vinculacion.component';
import { VinculacionConsultaComponent } from './Gestion/vinculacion-consulta/vinculacion-consulta.component';
import { FiltroVinculacionPipe } from './pipe/filtro-vinculacion.pipe';
import { LoginComponent } from './login/login.component';
import {JwtInterceptor} from './services/jwt.interceptor';
import { ExamenRegisterComponent } from './Gestion/examen-register/examen-register.component';
import { VeterinariaRegisterComponent } from './Gestion/veterinaria-register/veterinaria-register.component';
import { AmbientalRegisterComponent } from './Gestion/ambiental-register/ambiental-register.component';
import { AmbientalConsultaComponent } from './Gestion/ambiental-consulta/ambiental-consulta.component';
import { VeterinariaConsultaComponent } from './Gestion/veterinaria-consulta/veterinaria-consulta.component';
import { ExamenConsultaComponent } from './Gestion/examen-consulta/examen-consulta.component';
import { RestauranteModificarComponent } from './Gestion/restaurante-modificar/restaurante-modificar.component';


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    HeadersComponent,
    MenuComponent,
    ContentComponent,
    FooterComponent,
    PersonaRegisterComponent,
    PersonaConsultaComponent,
    RestauranteRegisterComponent,
    RestauranteConsultaComponent,
    ListaChequeoRegisterComponent,
    ListaChequeoConsultaComponent,
    AlertModalComponent,
    FiltroPersonaPipe,
    FiltroRestaurantePipe,
    VinculacionComponent,
    VinculacionConsultaComponent,
    FiltroVinculacionPipe,
    LoginComponent,
    ExamenRegisterComponent,
    VeterinariaRegisterComponent,
    AmbientalRegisterComponent,
    AmbientalConsultaComponent,
    VeterinariaConsultaComponent,
    ExamenConsultaComponent,
    RestauranteModificarComponent
  ],
  imports: [
    ReactiveFormsModule,
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
    ]),
    AppRoutingModule,
    NgbModule
  ],
  entryComponents:[AlertModalComponent],
  providers: [{ provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },],
  bootstrap: [AppComponent]
})
export class AppModule { }
