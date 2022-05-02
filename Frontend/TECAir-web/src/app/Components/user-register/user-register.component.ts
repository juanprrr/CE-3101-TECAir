import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { plainToInstance } from 'class-transformer';
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
  updateUser: User = new User
  universitiesList:University[] = []
  university = new University
  usersList: User[] = []

  constructor(private service:UserService, private router:Router, private universityService:UniversityService) { }

  ngOnInit(): void {
    this.universityService.getUniversities().subscribe((data:any)=>{this.universitiesList = data})
    this.getUsers()
  }

  addUser(newUse:User){
    this.service.insertUser(newUse).subscribe(()=>{
      window.location.reload()
    },()=>alert("No se pudo registrar su usuario, por favor intente de nuevo!"))
  }
  getUsers(){
    this.service.getUsers().subscribe((users: User[]) =>{
      console.log("Users in database: ", JSON.stringify(users));
      this.usersList = plainToInstance(User, users);
    })    
  }
  deleteUser(userD: User){
    this.service.deleteUser(userD.id).subscribe(()=>{
      window.location.reload()
    }, ()=>alert("No se pudo eliminar  usuario, por favor intente de nuevo!"))
  }
  
  goToPage(pageName:string){
    this.router.navigate([`${pageName}`]);
  }

  updateUserName(upUser:User){
    var i = this.usersList.length-1;
    for (i; 0 <= i; i--){
      if (upUser.id == this.usersList[i].id){
        this.usersList[i].name = upUser.name
        this.service.updateUser(this.usersList[i]).subscribe(()=>
        { window.location.reload();
          alert("El nombre se actualizó exitosamente!")})
      }
    }
  }
}
