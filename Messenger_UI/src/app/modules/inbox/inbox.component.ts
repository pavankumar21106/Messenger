import { Component, OnInit, ViewChild } from '@angular/core';
import { map } from 'rxjs';
import { slugs } from 'src/app/core/constants/api-slug';
import * as httpService from 'src/app/core/services/http.service';
import {
  ColumnMode, DatatableComponent,
} from '@swimlane/ngx-datatable';
import { ToastrService } from 'ngx-toastr';
@Component({
  selector: 'app-inbox',
  templateUrl: './inbox.component.html',
  styleUrls: ['./inbox.component.scss']
})
export class InboxComponent implements OnInit {

  @ViewChild(DatatableComponent)
  table!: DatatableComponent;
  rows: any[] = [];
  expanded: any = {};
  timeout: any;
  public mails: Mails[] = [];
  ColumnMode = ColumnMode;

  constructor(private readonly _httpClient: httpService.HttpService) { }

  deleteMail(row: Mails) {
    let temp = this._httpClient.Delete<any>(slugs.Delete + row.id).pipe(map(res => res)).subscribe(r => {
      console.log('click', row);
      for (var i = 0; i < this.mails.length; i++) {
        if (this.mails[i].id === row.id) {
          this.mails.splice(i, 1);
          this.mails=[...this.mails]
        }
      }
      this.table.offset = 0;
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

  toggleExpandRow(row: any) {
    console.log('Toggled Expand Row!', row);
    this.table.rowDetail.toggleExpandRow(row);
  }

  // onDetailToggle(event: any) {
  //   console.log('Detail Toggled', event);
  // }

}

export interface Mails {
  from: string
  fromName: string
  subject: string
  body: string
  id: number
  createdDate: string
}

