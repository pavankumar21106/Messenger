import { Component, OnInit, ViewChild } from '@angular/core';
import { map } from 'rxjs';
import { slugs } from 'src/app/core/constants/api-slug';
import * as httpService from 'src/app/core/services/http.service';
import {
  ColumnMode,
} from '@swimlane/ngx-datatable';
import { ToastrService } from 'ngx-toastr';
@Component({
  selector: 'app-inbox',
  templateUrl: './inbox.component.html',
  styleUrls: ['./inbox.component.scss']
})
export class InboxComponent implements OnInit {

  @ViewChild('myTable') table: any;
  rows: any[] = [];
  expanded: any = {};
  timeout: any;
  public mails: Mails[] = [];
  ColumnMode = ColumnMode;

  constructor(private readonly _httpClient: httpService.HttpService,private toastr: ToastrService) {}


  openSnackBar() {
    this.toastr.success('Hello world!');
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
    this.openSnackBar();
    console.log('Toggled Expand Row!', row);
    this.table.rowDetail.toggleExpandRow(row);
  }

  onDetailToggle(event: any) {
    console.log('Detail Toggled', event);
  }

}

export interface Mails {
  to: string
  toName: string
  subject: string
  body: string
  attachment: any[]
}
