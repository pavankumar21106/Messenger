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

  async onSubmit() {
    console.log(this.loginForm.value);
    console.log(Date.now, 's');
    let res = await this._logInService.logIn(this.loginForm.value);
    if (res) {
      this._router.navigate(['inbox']);
    }
  }
}
