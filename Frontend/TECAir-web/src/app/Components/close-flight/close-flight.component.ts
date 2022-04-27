import { LocationStrategy } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { Flight } from 'src/app/Models/flight';
import { Route } from 'src/app/Models/route';
import { FlightService } from 'src/app/Services/flight.service';
import { RouteService } from 'src/app/Services/route.service';

@Component({
  selector: 'app-close-flight',
  templateUrl: './close-flight.component.html',
  styleUrls: ['./close-flight.component.css']
})
export class CloseFlightComponent implements OnInit {
  flightsList:Flight[] = []
  flight:Flight = new Flight
  routesList:Route[] = []
  route:Route = new Route

  constructor(private service:FlightService, private routeService:RouteService) { }

  ngOnInit(): void {
    this.service.getFlight().subscribe((data:any)=>{
      this.flightsList = data
      this.flightsList.map((re: any) => {
        re.checked = false
      })
      console.log(this.flightsList)
    })
    this.routeService.getRoutes().subscribe((data:any)=>{this.routesList = data})
  }

  delFlight(delFlt:Flight){
    this.service.deleteFlight(delFlt.id).subscribe(()=>{},()=>alert("No se pudo eliminar el vuelo, porfavor intente de nuevo!"))
  }

  checkAll(event:any){
    
  }
}
