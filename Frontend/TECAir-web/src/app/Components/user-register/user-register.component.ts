import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { User } from 'src/app/Models/user';
import { UserService } from 'src/app/Services/user.service';

@Component({
  selector: 'app-user-register',
  templateUrl: './user-register.component.html',
  styleUrls: ['./user-register.component.css']
})
export class UserRegisterComponent implements OnInit {
  newUser:User = new User

  constructor(private service:UserService, private router:Router) { }

  ngOnInit(): void {
  }

  addUser(newUse:User){
    this.service.insertUser(newUse).subscribe(()=>{
      //this.router.navigate(['/'])
    },()=>alert("No se pudo registrar su usuario, porfavor intente de nuevo!"))
  }
  
  goToPage(pageName:string){
    this.router.navigate([`${pageName}`]);
  }
}
