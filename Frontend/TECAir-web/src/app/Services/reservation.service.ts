import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Reservation } from '../Models/reservation';

@Injectable({
  providedIn: 'root'
})
export class ReservationService {

  url = "/api/Reservation/";
  constructor(private httpclient:HttpClient) { }
  
  //Getreservations
  getReservation():Observable<any>{
    return this.httpclient.get(this.url)
  }
  //GetreservationbyId
  getReservationbyId(Id:number):Observable<Reservation>{
    let params = new HttpParams().set('id', Id)
    return this.httpclient.get<Reservation>(this.url, {params:params})
  }
  //Postreservation
  insertReservation(reservation:Reservation):Observable<any>{
    return this.httpclient.post(this.url, reservation, this.generateHeaders())
  }
  //Updatereservation
  updateReservation(reservation:Reservation):Observable<any>{
    
    return this.httpclient.put(this.url + reservation.id, reservation, this.generateHeaders())
  }
  //Deletereservation
  deleteReservation(Id:number):Observable<any>{
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