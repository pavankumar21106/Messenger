import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { LoginClass, LoginService } from 'src/app/core/services/login.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {

  constructor(private readonly _loginService: LoginService,
    private _router: Router) { }
  public isLoggedIn!: LoginClass;
  ngOnInit(): void {
    this.isLoggedIn = this._loginService.isLoggedIn;
  }

  navigateToCompose() {
    this._router.navigate(['compose']);
  }

  navigateToInbox() {
    this._router.navigate(['inbox']);
  }

  logOut() {
    this._loginService.logOut();

  }
}
