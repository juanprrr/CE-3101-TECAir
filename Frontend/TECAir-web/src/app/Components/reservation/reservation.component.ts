import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Flight } from 'src/app/Models/flight';
import { Route } from 'src/app/Models/route';
import { FlightService } from 'src/app/Services/flight.service';
import { RouteService } from 'src/app/Services/route.service';

@Component({
  selector: 'app-reservation',
  templateUrl: './reservation.component.html',
  styleUrls: ['./reservation.component.css']
})
export class ReservationComponent implements OnInit {
  flightsList:Flight[] = []
  flight:Flight = new Flight
  routesList:Route[] = []
  route:Route = new Route

  constructor(private service:FlightService, private routeService:RouteService, private router: Router) { }

  ngOnInit(): void {
    this.service.getFlight().subscribe((data:any)=>{this.flightsList = data})
    this.routeService.getRoutes().subscribe((data:any)=>{this.routesList = data})
  }
  goToPage(pageName:string){
    this.router.navigate([`${pageName}`]);
  }
}
