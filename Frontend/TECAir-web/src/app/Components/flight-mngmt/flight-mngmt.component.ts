import { AirportService } from './../../Services/airport.service';
import { Airport } from './../../Models/airport';
import { TravelService } from './../../Services/travel.service';
import { Travel } from './../../Models/travel';
import { RouteService } from './../../Services/route.service';
import { Route } from './../../Models/route';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { plainToInstance } from "class-transformer";

@Component({
  selector: 'app-flight-mngmt',
  templateUrl: './flight-mngmt.component.html',
  styleUrls: ['./flight-mngmt.component.css']
})
export class FlightMngmtComponent implements OnInit {

  newRoute: Route = new Route
  newTravel: Travel = new Travel
  routeList: Route[]=[];
  airportList: Airport[]=[]

  constructor(private service:RouteService, 
    private travelService: TravelService, private router:Router, private airport:AirportService) { }

  ngOnInit(): void {
    this.getRoutes();
    this.getAirport();
  }
  getAirport() {
    this.airport.getAirport().subscribe( (airports:Airport[]) => {
      console.log("REQUEST" + JSON.stringify(airports));
      this.airportList =  plainToInstance(Airport, airports);
    })
  }

  getRoutes(){
    this.service.getRoutes().subscribe( (routes:Route[]) => {
      console.log("REQUEST" + JSON.stringify(routes));
      this.routeList =  plainToInstance(Route, routes);
    })
  }

  addRoute(newRoute:Route){
    this.service.insertRoute(newRoute).subscribe(()=>
    {
      this.router.navigate(['flight_mngmnt/redirect'])
    }, ()=>alert("No se pudo registrar ruta"))
  }
  addTravel(newTravel:Travel){
    this.travelService.insertTravel(newTravel).subscribe(()=>
    {
      //this.router.navigate(['/'])
    }, ()=>alert("No se pudo registrar viaje"))
  }


}
