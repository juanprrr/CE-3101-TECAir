import { Router } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import { Airport } from 'src/app/Models/airport';
import { AirportService } from 'src/app/Services/airport.service';
import { FlightSearch } from 'src/app/Models/flight-search';
import { FlightSearchService } from 'src/app/Services/flight-search.service';

@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html',
  styleUrls: ['./home-page.component.css']
})
export class HomePageComponent implements OnInit {
  airportsList:Airport[] = []
  airport:Airport = new Airport
  flightSearch:FlightSearch = new FlightSearch

  constructor(private service:AirportService, private serviceFlightSearch:FlightSearchService, private router: Router) { }

  ngOnInit(): void {
    this.service.getAirport().subscribe((data:any)=>{this.airportsList = data})
  }
  
  goToPage(pageName:string){
    this.router.navigate([`${pageName}`]);
    this.serviceFlightSearch.flightSearchTrigger.emit({
      data:this.flightSearch
    })
  }
}
