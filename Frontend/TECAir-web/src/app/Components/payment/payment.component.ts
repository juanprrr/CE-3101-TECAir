import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Flight } from 'src/app/Models/flight';
import { Reservation } from 'src/app/Models/reservation';
import { FlightService } from 'src/app/Services/flight.service';
import { ReservationService } from 'src/app/Services/reservation.service';

@Component({
  selector: 'app-payment',
  templateUrl: './payment.component.html',
  styleUrls: ['./payment.component.css']
})
export class PaymentComponent implements OnInit {
  flight:Flight = new Flight
  reservation:Reservation = new Reservation
  reservationsList:Reservation[] = []

  constructor(private service:ReservationService, private flightService:FlightService, private router: Router) { }

  ngOnInit(): void {
    this.flightService.flightTrigger.subscribe((data:any) => {this.flight = data
    console.log(this.flight)})
    this.service.getReservation().subscribe((data:any)=>{this.reservationsList = data})
  }
  buyFlight(rsv:Reservation, flt:number, id:number){
    rsv.id_flight=1
    rsv.id = id+1
    this.service.insertReservation(rsv).subscribe(()=>{
      this.goToPage('home_page')
    },()=>alert("No se pudo efectuar su reservación, porfavor intente de nuevo!"))
  }
  goToPage(pageName:string){
    this.router.navigate([`${pageName}`]);
  }
}
