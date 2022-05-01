import { FlightRequestService } from './../../Services/flight-request.service';
import { TravelService } from './../../Services/travel.service';
import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute} from '@angular/router';
import { FlightRequest } from 'src/app/Models/flight-request';
import { FlightService } from 'src/app/Services/flight.service';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-reservation',
  template: `
    FlightRequest
  `,
  templateUrl: './reservation.component.html',
  styleUrls: ['./reservation.component.css']
})
export class ReservationComponent implements OnInit {
  newFlightRequest: FlightRequest = new FlightRequest
  subscription: Subscription = new Subscription;

  constructor(private router: Router,
              private flight: FlightService, 
              private travelService: TravelService, 
              private request: FlightRequestService,
              private activatedRoute : ActivatedRoute ) { 
  this.newFlightRequest = JSON.parse(activatedRoute.snapshot.params["newFlightRequest"]);
              }

  ngOnInit(): void {
    console.log("REQUEST" + JSON.stringify(this.newFlightRequest));

  }

  searchFlights(){

  }
  goToPage(pageName:string){
    this.router.navigate([`${pageName}`]);
  }
}
