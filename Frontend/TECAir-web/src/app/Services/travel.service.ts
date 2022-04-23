import { Travel } from './../Models/travel';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TravelService {
  url = '/api/Travel';
  constructor(private httpclient:HttpClient) { console.log('Travel Service') }

  
  //GetUsers
  getTravels():Observable<any>{
    return this.httpclient.get(this.url)
  }
  //GetTravelbyId
  getTravelbyNumber(Number:number):Observable<Travel>{
    let params = new HttpParams().set('Number', Number)
    return this.httpclient.get<Travel>(this.url, {params:params})
  }
  //PostTravel
  insertTravel(travel:Travel):Observable<any>{
    return this.httpclient.post(this.url, travel, this.generateHeaders())
  }
  //UpdateTravel
  updateTravel(travel:Travel):Observable<any>{
    return this.httpclient.put(this.url, travel, this.generateHeaders())
  }
  //DeleteTravel
  deleteUser(Number:number):Observable<any>{
    return this.httpclient.delete(this.url + Number, this.generateHeaders())
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
