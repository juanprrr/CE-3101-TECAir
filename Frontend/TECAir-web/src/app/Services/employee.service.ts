import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Employee } from '../Models/employee';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {
  url = '/api/Employee';
  constructor(private httpclient:HttpClient) { }

   //GetEmployees
   getEmployees():Observable<any>{
    return this.httpclient.get(this.url)
  }
  //GetEmployeebyId
  getEmployeebyId(Id:number):Observable<Employee>{
    let params = new HttpParams().set('Id', Id)
    return this.httpclient.get<Employee>(this.url, {params:params})
  }
  //PostEmployee
  insertUser(employee:Employee):Observable<any>{
    return this.httpclient.post(this.url, employee, this.generateHeaders())
  }
  //UpdateEmployee
  updateUser(employee:Employee):Observable<any>{
    return this.httpclient.put(this.url, employee)
  }
  //DeleteEmployee
  deleteEmployee(Id:number):Observable<any>{
    return this.httpclient.delete(this.url + Id)
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
