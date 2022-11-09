import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { Observable } from 'rxjs';
import { Router } from '@angular/router';

@Injectable()
export class AuthHeaderInterceptor implements HttpInterceptor {

  constructor(private _router: Router) { }


  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {

    if (request.url.includes('sign-in')) {
      return next.handle(request);
    }

    const token = sessionStorage.getItem('token');
    if (!token) {
      this._router.navigate(['login']);
    }
    const modifiedRequest = request.clone({
      headers: request.headers.set('auth', `${token}`),
    })

    return next.handle(modifiedRequest);
  }
}
