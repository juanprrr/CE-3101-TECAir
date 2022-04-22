import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { University } from '../Models/university';

@Injectable({
  providedIn: 'root'
})
export class UniversityService {

  url = '/api/User';
  constructor(private httpclient:HttpClient) { }
  
  //GetUsers
  getUsers():Observable<any>{
    return this.httpclient.get(this.url)
  }
  //GetUserbyId
  getUserbyId(Id:number):Observable<University>{
    let params = new HttpParams().set('Id', Id)
    return this.httpclient.get<University>(this.url, {params:params})
  }
  //PostUser
  insertUser(university:University):Observable<any>{
    return this.httpclient.post(this.url, university, this.generateHeaders())
  }
  //UpdateUser
  updateUser(university:University):Observable<any>{
    return this.httpclient.put(this.url, university)
  }
  //DeleteUser
  deleteUser(Id:number):Observable<any>{
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
