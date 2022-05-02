import { FlightRequestService } from './../../Services/flight-request.service';
import { FlightRequest } from './../../Models/flight-request';
import { AirportService } from './../../Services/airport.service';
import { Router } from '@angular/router';
import { Component, OnInit, Output } from '@angular/core';
import { Airport } from 'src/app/Models/airport';
import { plainToInstance } from 'class-transformer';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html',
  styleUrls: ['./home-page.component.css']
})
export class HomePageComponent implements OnInit {
  newFlightRequest: FlightRequest = new FlightRequest
  airportList: Airport[] = []
  airportsList: Airport[] = []
  originList: Airport[] = []
  destinationList: Airport[] = []
  flightRequests: FlightRequest[] = []
  flightRequest:FlightRequest = new FlightRequest
  //@Output() tableDataValues=new EventEmitter<string>();

  constructor(private router: Router, 
              private airport: AirportService) { }

  ngOnInit(): void {
    this.getAirport();
    this.airport.getAirport().subscribe((data:any)=>{this.airportsList = data})
      
  }
  goToPage(pageName:string, newFlightRequest: FlightRequest){
    
    this.router.navigate([`${pageName}`, JSON.stringify(newFlightRequest)]);
  }
  
  getAirport() {
    this.airport.getAirport().subscribe( (airports:Airport[]) => {
      console.log("REQUEST" + JSON.stringify(airports));
      this.airportList =  plainToInstance(Airport, airports);
      this.selectOriginDest();
    })
  }

  selectOriginDest(){
    console.log("Checking airports list");
    var i:number; 
    var top = this.airportList.length-1;
    for (i = top; i >= 0 ; i--){
      if(this.airportList[i].country == "Costa Rica") {
        this.originList.push(this.airportList[i]);
      }
      else{
        this.destinationList.push(this.airportList[i]);
      }
    }
  }

}


