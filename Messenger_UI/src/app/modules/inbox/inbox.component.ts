import { Component, OnInit } from '@angular/core';
import { map } from 'rxjs';
import { slugs } from 'src/app/core/constants/api-slug';
import * as httpService from 'src/app/core/services/http.service';
import {
  ColumnMode,
  SelectionType,
  TableColumn,
} from '@swimlane/ngx-datatable';
@Component({
  selector: 'app-inbox',
  templateUrl: './inbox.component.html',
  styleUrls: ['./inbox.component.scss']
})
export class InboxComponent implements OnInit {

  public tableHeaders: TableColumn[] = [];
  public ColumnMode = ColumnMode;
  public mails: Mails[] = [];
  public selectionType = SelectionType;


  constructor(private readonly _httpClient: httpService.HttpService,) { }

  ngOnInit(): void {

    let temp = this._httpClient.get<any>(slugs.GetMessages).pipe(map(res => res)).subscribe(r => {
      console.log(r);
      this.mails = r;
      console.log(this.mails);

      return r;
    });

    this.tableHeaders = [
      {
        name: 'toName',
        sortable: false,
        prop: 'toName',
        resizeable: false,
        draggable: false,
      },

      {
        name: 'subject',
        prop: 'subject',
        resizeable: false,
        sortable: false,
        draggable: false,
      },
      {
        name: 'body',
        prop: 'body',
        resizeable: false,
        sortable: false,
        draggable: false,
      },
    ];
  }

  rows = [];
}


export interface Mails {
  to: string
  toName: string
  subject: string
  body: string
  attachment: any[]
}
