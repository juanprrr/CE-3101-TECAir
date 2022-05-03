import { ReservationService } from './../../Services/reservation.service';
import { Reservation } from './../../Models/reservation';
import { SelectFlight } from './../../Models/select-flight';
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
  newReservation: Reservation = new Reservation
  flightList: Flight[] = []
  travelList: Travel[] = []
  optionsList: Travel[] = []
  datetimeAr: any;
  datetimeDep: any;
  selectionsList: SelectFlight[] =[] 
  
  constructor(private router: Router,
              private flightS: FlightService, 
              private travelService: TravelService, 
              private routeService: RouteService,
              private activatedRoute : ActivatedRoute,
              private reservationS: ReservationService ) { 
  this.newFlightRequest = JSON.parse(activatedRoute.snapshot.params["newFlightRequest"]);

              }

  ngOnInit(): void {
    console.log("NEW FLIGHT REQUEST" + JSON.stringify(this.newFlightRequest));
    this.getTravels()
    this.getFlights()

  }
  //Se obtienen todos los viajes disponibles
  getTravels(){
    this.travelService.getTravels().subscribe((travels: Travel[]) =>{
    console.log("TRAVELS AVAILABLE: ", JSON.stringify(travels));
    this.travelList = plainToInstance(Travel, travels);
    this.searchFlights();
    console.log("Options found", JSON.stringify(this.optionsList))

  })
  }
  //se obtienen todos los vuelos disponibles
  getFlights(){
    this.flightS.getFlight().subscribe((flights: Flight[]) =>{
    console.log("Flights available: ", JSON.stringify(flights));
    this.flightList = plainToInstance(Flight, flights);
    this.selectFlightOptions();
    console.log("selections found: ", JSON.stringify(this.selectionsList));
 
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

  addReservation(newReservation: Reservation){
    
      this.reservationS.insertReservation(newReservation).subscribe(()=>{
        window.location.reload()
      },()=>alert("No se pudo registrar su usuario, por favor intente de nuevo!"))
    }
  

  selectFlightOptions(){
    var i: number = 0;
    var k: number = 0;
    var top2 = this.flightList.length-1
    var top = this.optionsList.length-1
    
    for(i; i <= top; i++){
      

      for(k; k<=top2;k++){
        if(this.optionsList[i].id_route == this.flightList[k].id_ruta){
          var currentResult: SelectFlight = new SelectFlight
          this.datetimeAr = this.optionsList[i].arrival_time?.toString().split("T");
          this.datetimeDep = this.optionsList[i].departure_time?.toString().split("T");

          currentResult.nVuelo = this.flightList[k].id
          currentResult.pasajeros = this.flightList[k].number_of_passengers
          currentResult.llegada = this.datetimeAr[1]
          currentResult.salida = this.datetimeDep[1]
          currentResult.precio = this.flightList[k].cost
          this.selectionsList.push(currentResult)
        }
      }
    }
    console.log("Results from search: ", JSON.stringify(this.selectionsList))
  }

  goToPage(pageName:string){
    this.router.navigate([`${pageName}`]);
  }
}
