import { Flight } from './../Models/flight';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class FlightService {

  url = '/api/Flight';
  constructor(private httpclient:HttpClient) { console.log('Flight Service') }
  
  //GetUsers
  getFlight():Observable<any>{
    return this.httpclient.get(this.url)
  }
  //GetUserbyId
  getFlightbyId(Id:number):Observable<Flight>{
    let params = new HttpParams().set('id', Id)
    return this.httpclient.get<Flight>(this.url, {params:params})
  }
  //PostUser
  insertFlight(flight:Flight):Observable<any>{
    return this.httpclient.post(this.url, flight, this.generateHeaders())
  }
  //UpdateUser
  updateFlight(flight:Flight):Observable<any>{
    return this.httpclient.put(this.url, flight, this.generateHeaders())
  }
  //DeleteUser
  deleteFlight(Id:number):Observable<any>{
    return this.httpclient.delete(this.url + Id, this.generateHeaders())
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
