import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators} from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  form: FormGroup;

  constructor(private fb: FormBuilder, private router: Router) { 
    this.form = this.fb.group({
      usuario: ['', Validators.required],
      contraseña: ['', Validators.required]

    })
  }

  ngOnInit(): void {
  }

}
