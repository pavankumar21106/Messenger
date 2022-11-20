import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
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
    public isFormValid:boolean=true;
  ngOnInit(): void {
  }

  loginForm = new FormGroup({
    email: new FormControl(''),
    userName: new FormControl('',[
      Validators.required,
      Validators.email
    ]),
    password: new FormControl('')
  });

  async onSubmit() {
    this.isFormValid=this.loginForm.valid
    console.log(this.loginForm);
    if (!this.isFormValid) {
      return;
    }
    console.log(Date.now, 's');
    let res = await this._logInService.logIn(this.loginForm.value);
    if (res) {
      this._router.navigate(['inbox']);
    }
    else{
    this.isFormValid=false
    }
  }
}
