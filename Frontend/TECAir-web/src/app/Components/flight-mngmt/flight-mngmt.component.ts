import { TravelService } from './../../Services/travel.service';
import { Travel } from './../../Models/travel';
import { RouteService } from './../../Services/route.service';
import { Route } from './../../Models/route';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
@Component({
  selector: 'app-flight-mngmt',
  templateUrl: './flight-mngmt.component.html',
  styleUrls: ['./flight-mngmt.component.css']
})
export class FlightMngmtComponent implements OnInit {

  newRoute: Route = new Route
  newTravel: Travel = new Travel
  routeList: Route[] =[] 
  constructor(private service:RouteService, 
    private travelService: TravelService, private router:Router) { }

  ngOnInit(): void {
    this.getRoutes();
  }

  getRoutes(){
    this.service.getRoutes().subscribe( data=> {
      console.log("REQUEST:  " + JSON.stringify(data));
      this.routeList =  data as Route[]})
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
