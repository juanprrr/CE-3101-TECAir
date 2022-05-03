import { Flight } from './../../Models/flight';
import { AirplaneService } from './../../Services/airplane.service';
import { Airplane } from './../../Models/airplane';
import { AirportService } from './../../Services/airport.service';
import { Airport } from './../../Models/airport';
import { TravelService } from './../../Services/travel.service';
import { Travel } from './../../Models/travel';
import { RouteService } from './../../Services/route.service';
import { Route } from './../../Models/route';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { plainToInstance } from "class-transformer";
import { FlightService } from 'src/app/Services/flight.service';

@Component({
  selector: 'app-flight-mngmt',
  templateUrl: './flight-mngmt.component.html',
  styleUrls: ['./flight-mngmt.component.css']
})
export class FlightMngmtComponent implements OnInit {

  newRoute: Route = new Route
  newTravel: Travel = new Travel
  newFlight: Flight = new Flight
  routeList: Route[]=[];
  airportList: Airport[]=[]
  airplaneList: Airplane[]=[]
  flightList: Flight[] = []
  updateFlight: Flight = new Flight

  constructor(private service:RouteService, 
    private travelService: TravelService,
    private router:Router, 
    private airport:AirportService,
    private airplane: AirplaneService,
    private flight: FlightService) { }

  ngOnInit(): void {
    this.getRoutes();
    this.getAirport();
    this.getAirplane();
    this.getFlights();
  }
  getAirplane() {
    this.airplane.getAirplanes().subscribe( (airplanes:Airplane[]) => {
      console.log("REQUEST" + JSON.stringify(airplanes));
      this.airplaneList =  plainToInstance(Airplane, airplanes);
    })
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
      window.location.reload()
    }, ()=>alert("No se pudo registrar ruta"))
  }
  addTravel(newTravel:Travel){
    this.travelService.insertTravel(newTravel).subscribe(()=>
    {
      window.location.reload()
    }, ()=>alert("No se pudo registrar viaje"))
  }

  addFlight(newFlight:Flight){
    this.flight.insertFlight(newFlight).subscribe(()=>
    {
      window.location.reload()
    }, ()=>alert("No se pudo registrar vuelo"))
  }

  getFlights(){
    this.flight.getFlight().subscribe((flights: Flight[]) => {
      this.flightList = plainToInstance(Flight, flights)
    })
  }

  deleteFlight(flight: Flight){
    this.flight.deleteFlight(flight.id).subscribe(()=>
    {
      window.location.reload();

    },()=> alert("No se pudo eliminar  vuelo, por favor intente de nuevo!"))
  }


}
