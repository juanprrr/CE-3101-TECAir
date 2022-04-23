import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { University } from 'src/app/Models/university';
import { User } from 'src/app/Models/user';
import { UniversityService } from 'src/app/Services/university.service';
import { UserService } from 'src/app/Services/user.service';

@Component({
  selector: 'app-user-register',
  templateUrl: './user-register.component.html',
  styleUrls: ['./user-register.component.css']
})
export class UserRegisterComponent implements OnInit {
  newUser:User = new User
  universitiesList:University[] = []
  university = new University

  constructor(private service:UserService, private router:Router, private universityService:UniversityService) { }

  ngOnInit(): void {
    this.universityService.getUniversities().subscribe((data:any)=>{this.universitiesList = data})
  }

  addUser(newUse:User){
    this.service.insertUser(newUse).subscribe(()=>{
      this.goToPage('/')
    },()=>alert("No se pudo registrar su usuario, porfavor intente de nuevo!"))
  }
  
  goToPage(pageName:string){
    this.router.navigate([`${pageName}`]);
  }
}
