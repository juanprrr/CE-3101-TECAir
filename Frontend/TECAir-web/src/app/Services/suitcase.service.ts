import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Suitcase } from '../Models/suitcase';

@Injectable({
  providedIn: 'root'
})
export class SuitcaseService {

  url = "/api/Suitcase/";
  constructor(private httpclient:HttpClient) { console.log('Flight Service') }
  
  //GetSuitcases
  getSuitcase():Observable<any>{
    return this.httpclient.get(this.url)
  }
  //GetSuitcasebyId
  getSuitcasebyId(Id:number):Observable<Suitcase>{
    let params = new HttpParams().set('id', Id)
    return this.httpclient.get<Suitcase>(this.url, {params:params})
  }
  //PostFlight
  insertSuitcase(suitcase:Suitcase):Observable<any>{
    return this.httpclient.post(this.url, suitcase, this.generateHeaders())
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
