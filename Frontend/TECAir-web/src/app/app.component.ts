import { Component } from '@angular/core';
import { UserService } from './Services/user.service';
import { Router }  from "@angular/router";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'TECAir-web';
  public users: Array<any> = []

  constructor(private userService:UserService, public router: Router){}
  ngOnInit(){
    this.userService.getUsers().subscribe((res: any)=>{
      console.log('Res: ', res)
      this.users = res
    })
  }
}
