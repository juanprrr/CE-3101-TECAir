import { Airport } from './../Models/airport';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class AirportService {
  url = "/api/Airport"
  constructor(private httpclient:HttpClient) { console.log('Routes Service') }

  getAirport():Observable<Airport[]>{
    return this.httpclient.get<Airport[]>(this.url)
}
}
