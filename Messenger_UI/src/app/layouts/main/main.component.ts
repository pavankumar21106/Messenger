import { Component, OnInit, ViewChild } from '@angular/core';
import { ColumnMode } from '@swimlane/ngx-datatable';
import { Mails } from 'src/app/modules/inbox/inbox.component';
import * as httpService from 'src/app/core/services/http.service';
import { slugs } from 'src/app/core/constants/api-slug';
import { map } from 'rxjs';

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.scss']
})
export class MainComponent implements OnInit {

  @ViewChild('myTable') table: any;

  rows: any[] = [];
  expanded: any = {};
  timeout: any;
  public mails: Mails[] = [];

  ColumnMode = ColumnMode;

  constructor(private readonly _httpClient: httpService.HttpService) {
    this.fetch((data: any[]) => {
      this.rows = data;
    });
  }


  ngOnInit(): void {
    let temp = this._httpClient.get<any>(slugs.GetMessages).pipe(map(res => res)).subscribe(r => {
      console.log(r);
      this.mails = r;
      console.log(this.mails);

      return r;
    });
  }


  fetch(cb: { (data: any[]): void; (arg0: any): void; }) {
    const req = new XMLHttpRequest();
    req.open('GET', `http://swimlane.github.io/ngx-datatable/assets/data/100k.json`);

    req.onload = () => {
      cb(JSON.parse(req.response));
    };

    req.send();
  }

  toggleExpandRow(row: any) {
    console.log('Toggled Expand Row!', row);
    this.table.rowDetail.toggleExpandRow(row);
  }

  onDetailToggle(event: any) {
    console.log('Detail Toggled', event);
  }

}
