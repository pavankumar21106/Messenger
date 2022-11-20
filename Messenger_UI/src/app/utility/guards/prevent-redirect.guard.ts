import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, CanDeactivate, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PreventRedirectGuard implements CanDeactivate<any> {
  canDeactivate(
    component: PreventRedirect,
    currentRoute: ActivatedRouteSnapshot,
    currentState: RouterStateSnapshot,
    nextState?: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
    if (component.allowRedirect) {
      return true;
    }
    if (
      (component.canDeactivate && !component.canDeactivate())
    ) {
      if (
        window.confirm("Sure man?")
      ) {
        return true;
      } else {
        return false;
      }
    } else {
      return true;
    }
  }

}

export interface PreventRedirect {
  allowRedirect: boolean;
  canDeactivate(): boolean;
}
