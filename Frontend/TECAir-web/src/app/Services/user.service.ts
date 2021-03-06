import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { User } from '../Models/user';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  url = '/api/User';
  constructor(private httpclient:HttpClient) { console.log('User Service') }
  
  //GetUsers
  getUsers():Observable<any>{
    return this.httpclient.get(this.url)
  }
  //GetUserbyId
  getUserbyId(Id:number):Observable<User>{
    let params = new HttpParams().set('id', Id)
    return this.httpclient.get<User>(this.url, {params:params})
  }
  //PostUser
  insertUser(user:User):Observable<any>{
    return this.httpclient.post(this.url, user, this.generateHeaders())
  }
  //UpdateUser
  updateUser(user:User):Observable<any>{
    return this.httpclient.put(this.url + "/" + user.id, user,  this.generateHeaders())
  }
  //DeleteUser
  deleteUser(Id:number):Observable<any>{
    return this.httpclient.delete(this.url + "/" +  Id, this.generateHeaders())
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
