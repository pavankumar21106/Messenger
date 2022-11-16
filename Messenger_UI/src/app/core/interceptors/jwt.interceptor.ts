import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { finalize, Observable, tap } from 'rxjs';
import { Router } from '@angular/router';
import { LoaderService } from 'src/app/shared/loader/loader.service';

@Injectable()
export class jwt implements HttpInterceptor {

  constructor(private _router: Router,private ngxService: LoaderService,) { }


  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    this.ngxService.start();

    const token = sessionStorage.getItem('token');

    if (request.url.includes('sign-in') || !token) {
      this.ngxService.stop();
      return next.handle(request);
    }

    const modifiedRequest = request.clone({
      headers: request.headers.set('auth', `${token}`),
    })

    return next.handle(modifiedRequest).pipe(finalize(()=>{
      this.ngxService.stop();
    }))
  }
}
