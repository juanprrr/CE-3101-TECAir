import { Travel } from './../../Models/travel';
import { Flight } from './../../Models/flight';
import { RouteService } from './../../Services/route.service';
import { Route } from './../../Models/route';

import { TravelService } from './../../Services/travel.service';
import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute} from '@angular/router';
import { FlightRequest } from 'src/app/Models/flight-request';
import { FlightService } from 'src/app/Services/flight.service';
import { plainToInstance } from 'class-transformer';

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
  flightList: Flight[] = []
  travelList: Travel[] = []
  optionsList: Travel[] = []
  datetimeAr: any;
  datetimeDep: any;
  

  constructor(private router: Router,
              private flight: FlightService, 
              private travelService: TravelService, 
              private routeService: RouteService,
              private activatedRoute : ActivatedRoute ) { 
  this.newFlightRequest = JSON.parse(activatedRoute.snapshot.params["newFlightRequest"]);

              }

  ngOnInit(): void {
    console.log("REQUEST" + JSON.stringify(this.newFlightRequest));
    this.getTravels()
    

  }

  getTravels(){
    this.travelService.getTravels().subscribe((travels: Travel[]) =>{
    console.log("TRAVELS AVAILABLE: ", JSON.stringify(travels));
    this.travelList = plainToInstance(Travel, travels);
    this.searchFlights();
    console.log("Options found", JSON.stringify(this.optionsList))

  })
  }
  searchFlights(){
    var i: number;
    var top = this.travelList.length-1;
    for(i = 0; i <= top; i++){
      if(this.travelList[i].id_origin == this.newFlightRequest.origin || 
        this.travelList[i].id_destination == this.newFlightRequest.destination){
          this.datetimeAr = this.travelList[i].arrival_time?.toString().split("T");
          this.datetimeDep = this.travelList[i].departure_time?.toString().split("T");
          
          if(this.datetimeDep[0] == this.newFlightRequest.departure || 
            this.datetimeAr[0] == this.newFlightRequest.arrival){
            this.optionsList.push(this.travelList[i])

          }
        }
    }

  }
  
  goToPage(pageName:string){
    this.router.navigate([`${pageName}`]);
  }
}
