import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { University } from '../Models/university';

@Injectable({
  providedIn: 'root'
})
export class UniversityService {

  url = '/api/University';
  constructor(private httpclient:HttpClient) { }
  
  //GetUniversity
  getUniversities():Observable<any>{
    return this.httpclient.get(this.url)
  }
  //GetUniversitybyId
  getUniversitybyId(Id:number):Observable<University>{
    let params = new HttpParams().set('Id', Id)
    return this.httpclient.get<University>(this.url, {params:params})
  }
  //PostUniversity
  insertUniversity(university:University):Observable<any>{
    return this.httpclient.post(this.url, university, this.generateHeaders())
  }
  //UpdateUniversity
  updateUniversity(university:University):Observable<any>{
    return this.httpclient.put(this.url, university)
  }
  //DeleteUniversity
  deleteUniversity(Id:number):Observable<any>{
    return this.httpclient.delete(this.url + Id)
  }
  private generateHeaders = () => {
    return {
      headers: new HttpHeaders({
        "Access-Control-Allow-Origin": "*", // este header es para permitir todos los CORS necesarios de los requests
        'Content-Type': 'application/json'
      })
    }
  }
}
