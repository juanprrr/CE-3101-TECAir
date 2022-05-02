import { Component, OnInit, Input } from '@angular/core';
import { Router } from '@angular/router';
import { Airport } from 'src/app/Models/airport';
import { Flight } from 'src/app/Models/flight';
import { FlightSearch } from 'src/app/Models/flight-search';
import { Route } from 'src/app/Models/route';
import { Travel } from 'src/app/Models/travel';
import { AirportService } from 'src/app/Services/airport.service';
import { FlightSearchService } from 'src/app/Services/flight-search.service';
import { FlightService } from 'src/app/Services/flight.service';
import { RouteService } from 'src/app/Services/route.service';
import { TravelService } from 'src/app/Services/travel.service';

@Component({
  selector: 'app-reservation',
  templateUrl: './reservation.component.html',
  styleUrls: ['./reservation.component.css']
})
export class ReservationComponent implements OnInit {
  flightsList:Flight[] = []
  flight:Flight = new Flight
  routesList:Route[] = []
  travelsList:Travel[] = []
  airportsList:Airport[] = []
  flightSearch:FlightSearch = new FlightSearch
  travelsByRoutes:Travel[] = []

  constructor(private service:FlightService, private routeService:RouteService, private travelService:TravelService, private airportService:AirportService, private flightSearchService:FlightSearchService, private router: Router) { }

  ngOnInit(): void {
    this.service.getFlight().subscribe((data:any)=>{this.flightsList = data})
    this.routeService.getRoutes().subscribe((data:any)=>{this.routesList = data})
    this.travelService.getTravels().subscribe((data:any)=>{this.travelsList = data})
    this.airportService.getAirport().subscribe((data:any)=>{this.airportsList = data})
    this.flightSearchService.flightSearchTrigger.subscribe(data => {this.flightSearch = data})
  }

  buildFlightsList(){
  }

  buyFlight(flt:Flight){
    this.service.flightTrigger.emit({
      data:flt
    })
    this.goToPage('payment')
  }

  goToPage(pageName:string){
    this.router.navigate([`${pageName}`]);
  }
}
