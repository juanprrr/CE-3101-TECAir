import { Route } from './../Models/route';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class RouteService {

  url = "/api/Route"
  constructor(private httpclient:HttpClient) { console.log('Routes Service') }

    //GetRoutes
  getRoutes():Observable<Route[]>{
      return this.httpclient.get<Route[]>(this.url)
  }
  //GetRoutesbyId
  getRoutebyId(Id:number):Observable<Route>{
    let params = new HttpParams().set('id', Id)
    return this.httpclient.get<Route>(this.url, {params:params})
  }
 //PostRoute
 insertRoute(route:Route):Observable<Route>{
  return this.httpclient.post<Route>(this.url, route, this.generateHeaders())
}
private generateHeaders = () => {
  return {
    headers: new HttpHeaders({
      "Access-Control-Allow-Origin": "*",
      'Content-Type': 'application/json'
    })
  }
}
}
