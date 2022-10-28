import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { LoginService } from 'src/app/core/services/login.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  constructor(private readonly _logInService: LoginService) { }

  ngOnInit(): void {
  }

  loginForm = new FormGroup({
    email: new FormControl(''),
    userName: new FormControl(''),
    password: new FormControl('')
  });

  isLoggedIn: boolean = false;

  onSubmit() {
    console.log(this.loginForm.value);
    let res = this._logInService.logIn(this.loginForm.value);
    res.subscribe(res => {
      console.log(res);
      if (res.isSuccess) {
        this.isLoggedIn = true;
      }
    });
    console.log(this.isLoggedIn);
  }
}
