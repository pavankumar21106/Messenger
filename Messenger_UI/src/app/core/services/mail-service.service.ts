import { Injectable } from '@angular/core';
import { BehaviorSubject, map } from 'rxjs';
import { Mails } from 'src/app/modules/inbox/inbox.component';
import { slugs } from '../constants/api-slug';
import { HttpService } from './http.service';

@Injectable({
  providedIn: 'root'
})
export class MailServiceService {

  constructor(private readonly _httpClient: HttpService) { }
  // public mails: Mails[] = [];

  private _mailsSub = new BehaviorSubject<Mails[]>([]);
  public mails = this._mailsSub.asObservable();
  getMails() {
    return new Promise((resolve) => {
      let temp = this._httpClient.get<any>(slugs.GetMessages).subscribe(res => {
        if (res) {
          this._mailsSub.next(res);
          resolve(true);
        }
      }
      )
    })
  }

  SearchMails(searchText:string="") {
    return new Promise((resolve) => {
      let temp = this._httpClient.get<any>(slugs.SearchMessages+searchText).subscribe(res => {
        if (res) {
          this._mailsSub.next(res);
          resolve(true);
        }
      }
      )
    })
  }
}
