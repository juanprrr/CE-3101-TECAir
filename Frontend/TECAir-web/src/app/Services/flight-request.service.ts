import { FlightRequest } from './../Models/flight-request';
import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class FlightRequestService {
  newFlightRequest: FlightRequest = new FlightRequest
  private source = new BehaviorSubject(this.newFlightRequest);
  currentSource = this.source.asObservable();


  constructor() { }
  
  updateSource(newFlightRequest: FlightRequest){
      this.source.next(newFlightRequest);
  }
  getRequest(){
    return this.currentSource
  }
}
