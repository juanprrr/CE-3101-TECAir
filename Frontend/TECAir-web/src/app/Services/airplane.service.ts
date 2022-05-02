import { Airplane } from './../Models/airplane';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AirplaneService {
  url = "/api/Airplane"
  constructor(private httpclient:HttpClient) { console.log('Airplane Service') }

  getAirplanes():Observable<Airplane[]>{
    return this.httpclient.get<Airplane[]>(this.url)
}
}
