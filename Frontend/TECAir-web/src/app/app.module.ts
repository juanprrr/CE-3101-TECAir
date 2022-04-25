import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
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
import { PaymentComponent } from './Components/payment/payment.component';

@NgModule({
  declarations: [
    AppComponent,
    HomePageComponent,
    HeaderComponent,
    LoginComponent,
    UserRegisterComponent,
    ReservationComponent,
    FlightMngmtComponent,
    CheckInComponent,
    BaggageAsgComponent,
    OpenFlightComponent,
    CloseFlightComponent,
    PaymentComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
