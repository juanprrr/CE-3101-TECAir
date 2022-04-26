import { Component, OnInit } from '@angular/core';
import {Router } from '@angular/router';
import { EMPTY } from 'rxjs';
import { Employee } from 'src/app/Models/employee';
import { EmployeeService } from 'src/app/Services/employee.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  employee:Employee = new Employee
  employeesList:Employee[] = []
  logged:Boolean = false

  constructor(private service:EmployeeService, private router: Router){
  }

  ngOnInit(): void {
    this.service.getEmployees().subscribe((data:any)=>{this.employeesList = data})
  }
 
  goToPage(pageName:string){
    this.router.navigate([`${pageName}`]);
  }

  checkLogin(emp: Employee){
    for (var i=0; i<this.employeesList.length; i++){
      if (emp.email == this.employeesList[i].email && emp.password == this.employeesList[i].password && this.employeesList[i].id_role == 1) {
        this.goToPage('home_page')
        this.logged = true
      }
    }
  }
  
}
