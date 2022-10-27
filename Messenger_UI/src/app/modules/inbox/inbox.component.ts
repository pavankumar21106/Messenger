import { Component, OnInit } from '@angular/core';
import { map } from 'rxjs';
import { slugs } from 'src/app/core/constants/api-slug';
import * as httpService from 'src/app/core/services/http.service';

@Component({
  selector: 'app-inbox',
  templateUrl: './inbox.component.html',
  styleUrls: ['./inbox.component.scss']
})
export class InboxComponent implements OnInit {

  constructor(private readonly _httpClient: httpService.HttpService,) { }

  ngOnInit(): void {
    let temp = this._httpClient.get<any>(slugs.GetMessages).pipe(map(res => res)).subscribe(r => {
      console.log(r);
      return r;
    });
  }

}
