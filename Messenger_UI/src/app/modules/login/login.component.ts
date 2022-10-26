import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { slugs } from 'src/app/core/constants/api-slug';
import { HttpService } from 'src/app/core/services/http.service';
import { LoginService } from 'src/app/core/services/login.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {


  constructor(private readonly _httpClient: HttpService, private readonly _logInService: LoginService) { }

  ngOnInit(): void {
  }

  d = {
    "email": "test@gmail.com",
    "userName": "test",
    "password": "Test@123"
  };
  isLoggedIn: boolean = false;

  logIn() {
    let res = this._logInService.logIn(this.d);
    res.subscribe(res => {
      if (res.isSuccess) {
        this.isLoggedIn = true;
      }
    });
    console.log(this.isLoggedIn);
  }

}
