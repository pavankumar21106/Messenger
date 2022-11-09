import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { LoginService } from 'src/app/core/services/login.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  constructor(private readonly _logInService: LoginService,
    private _router: Router) { }

  ngOnInit(): void {
  }

  loginForm = new FormGroup({
    email: new FormControl(''),
    userName: new FormControl(''),
    password: new FormControl('')
  });

  isLoggedIn: boolean = false;

  async onSubmit() {
    console.log(this.loginForm.value);
    console.log(Date.now,'s');
    let res = this._logInService.logIn(this.loginForm.value);
    res.subscribe(res => {
      console.log(Date.now,'i');
      console.log(res);
      if (res) {
        sessionStorage.setItem('token',res.token);
        this.isLoggedIn = true;
        console.log(this.isLoggedIn,'ii');
        this._router.navigate(['inbox']);
      }
    });
    console.log(Date.now,'e');
    console.log(this.isLoggedIn);
  }
}
