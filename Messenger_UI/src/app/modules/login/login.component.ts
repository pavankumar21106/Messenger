import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { slugs } from 'src/app/core/constants/api-slug';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  constructor(private readonly _httpClient: HttpClient) { }

  ngOnInit(): void {
  }

  d = {
    "email": "test@gmail.com",
    "userName": "test",
    "password": "Tst@123"
  };

  logIn() {
    console.log('hii');

    //let t = this._httpClient.post(`${environment.BaseUrl}${slugs.Login}`,this.d);

    this._httpClient.post<any>(slugs.Login, this.d);
  }
}
