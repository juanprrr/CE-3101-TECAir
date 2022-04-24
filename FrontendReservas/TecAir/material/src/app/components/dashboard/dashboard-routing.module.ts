import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DashboardComponent } from './dashboard.component';
import { InicioComponent } from './inicio/inicio.component';
import { VuelosComponent } from './vuelos/vuelos.component';
import { PromocionesComponent } from './promociones/promociones.component';
import { IngresarComponent } from './ingresar/ingresar.component';
import { RegistarseComponent } from './registarse/registarse.component';
//import { ReservasComponent } from './reservas/reservas.component';

const routes: Routes = [
  { path: '', component: DashboardComponent, children: [
    { path: 'inicio', component: InicioComponent },
    { path: 'vuelos', component: VuelosComponent },
    { path: 'promociones', component: PromocionesComponent },
    //{ path: 'reservas', component: ReservasComponent },
    { path: 'registarse', component: RegistarseComponent },
    { path: 'ingresar', component: IngresarComponent },
    //{ path: 'craer-reserva', component: ReservasComponent },
  ]  
},
  
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class DashboardRoutingModule { }





