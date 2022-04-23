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
  constructor(private service:RouteService, private router:Router) { }

  ngOnInit(): void {
  }

  addRoute(newRoute:Route){
    this.service.insertRoute(newRoute).subscribe(()=>
    {
      //this.router.navigate(['/'])
    }, ()=>alert("No se pudo registrar ruta"))
  }
}
