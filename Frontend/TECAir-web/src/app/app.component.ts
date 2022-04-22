import { Component } from '@angular/core';
import { UserService } from './Services/user.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'TECAir-web';
  public users: Array<any> = []

  constructor(private userService:UserService){}
  ngOnInit(){
    this.userService.getUsers().subscribe((res: any)=>{
      console.log('Res: ', res)
      this.users = res
    })
  }
}
