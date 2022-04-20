import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { HomePageComponent } from './Components/home-page/home-page.component';
import { HeaderComponent } from './Components/header/header.component';
import { LoginComponent } from './Components/login/login.component';
import { UserRegisterComponent } from './Components/user-register/user-register.component';
import { ReservationComponent } from './Components/reservation/reservation.component';
import { FlightMngmtComponent } from './Components/flight-mngmt/flight-mngmt.component';
import { CheckInComponent } from './Components/check-in/check-in.component';
import { BaggageAsgComponent } from './Components/baggage-asg/baggage-asg.component';
import { OpenFlightComponent } from './Components/open-flight/open-flight.component';
import { CloseFlightComponent } from './Components/close-flight/close-flight.component';

const routes: Routes = [
  {
    path: '', 
    component: LoginComponent
  },
  {
    path: 'home_page', 
    component: HomePageComponent
  },
  {
    path: 'reservation',
    component: ReservationComponent
  },
  {
    path: 'flight_mngmnt', 
    component: FlightMngmtComponent
  },
  {
    path: 'open_flight', 
    component: OpenFlightComponent
  },
  {
    path: 'checkin', 
    component: CheckInComponent
  },
  {
    path: 'baggage', 
    component: BaggageAsgComponent
  },
  {
    path: 'close_flight', 
    component: CloseFlightComponent
  },
  {
    path: 'user_register', 
    component: UserRegisterComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
