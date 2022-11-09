import { Injectable } from '@angular/core';
import { map } from 'rxjs';
import { slugs } from '../constants/api-slug';
import { HttpService } from './http.service';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  constructor(private readonly _httpClient: HttpService) { }

  isLogedIn: boolean = false;

  logIn(userData: any,headers?:any) {
    return this._httpClient.post<any>(slugs.Login, userData,headers).pipe(map(res=>res));
  }
}