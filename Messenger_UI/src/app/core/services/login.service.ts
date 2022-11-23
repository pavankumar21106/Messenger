import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { slugs } from '../constants/api-slug';
import { HttpService } from './http.service';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  isLoggedIn:LoginClass;
  constructor(private readonly _httpClient: HttpService, private _router: Router) {
    this.isLoggedIn = new LoginClass(false);
    let token = localStorage.getItem('token') ?? "";
    this.isLoggedIn.isLoggedIn = token.length>0 ?  true : false;
   }


  logIn(userData: any, headers?: any) {
    return new Promise((resolve) => {
      this._httpClient.post<any>(slugs.Login, userData, headers).subscribe(res => {
        if (res.token) {
          localStorage.setItem('token', res.token);
          this.isLoggedIn.isLoggedIn = true;
          resolve(this.isLoggedIn)
        }
        resolve(false);
      }
      )
    })
  }

  logOut() {
    localStorage.removeItem('token');
    this._router.navigate(['login']);
    this.isLoggedIn.isLoggedIn = false;
  }
}
export class LoginClass {
  constructor(isLoggedIn: boolean) {
    this.isLoggedIn = isLoggedIn;
  }
  isLoggedIn: boolean;
}

