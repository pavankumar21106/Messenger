import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { LoginClass, LoginService } from 'src/app/core/services/login.service';
import { MailServiceService } from 'src/app/core/services/mail-service.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {

  constructor(private readonly _loginService: LoginService,
    private readonly _mailServiceService: MailServiceService,
    private _router: Router) { }
  public isLoggedIn!: LoginClass;
  public searchText:string="";
  ngOnInit(): void {
    this.isLoggedIn = this._loginService.isLoggedIn;
  }

  navigateToCompose() {
    this._router.navigate(['compose']);
  }

  navigateToInbox() {
    this._router.navigate(['inbox']);
  }

  async searchMails(searchText:string){
    let res = await this._mailServiceService.SearchMails(searchText);
    if (res) {
      this._router.navigate(['inbox']);
    }
    this.searchText="";
  }

  logOut() {
    this._loginService.logOut();

  }
}
