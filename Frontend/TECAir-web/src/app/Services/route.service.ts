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
  getRoutes():Observable<any>{
      return this.httpclient.get(this.url)
  }
  //GetRoutesbyId
  getRoutebyId(Id:number):Observable<Route>{
    let params = new HttpParams().set('Id', Id)
    return this.httpclient.get<Route>(this.url, {params:params})
  }
 //PostRoute
 insertRoute(route:Route):Observable<any>{
  return this.httpclient.post(this.url, route, this.generateHeaders())
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
