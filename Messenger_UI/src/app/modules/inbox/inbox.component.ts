import { Component, OnInit, ViewChild } from '@angular/core';
import { map } from 'rxjs';
import { slugs } from 'src/app/core/constants/api-slug';
import {
  ColumnMode, DatatableComponent,
} from '@swimlane/ngx-datatable';
import { HttpService } from 'src/app/core/services/http.service';
import { MailServiceService } from 'src/app/core/services/mail-service.service';
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

  constructor(private readonly _httpClient: HttpService, private readonly _mailServiceService: MailServiceService) { }

  deleteMail(row: Mails) {
    let temp = this._httpClient.Delete<any>(slugs.Delete + row.id).pipe(map(res => res)).subscribe(r => {
      console.log('click', row);
      for (var i = 0; i < this.mails.length; i++) {
        if (this.mails[i].id === row.id) {
          this.mails.splice(i, 1);
          this.mails = [...this.mails]
        }
      }
      this.table.offset = 0;
    });
  }


  async ngOnInit(): Promise<void> {
    let res = await this._mailServiceService.getMails();
    if (res) {
      this._mailServiceService.mails.subscribe(res=>{
        this.mails = [...res];
      })
    }
  }

  toggleExpandRow(row: any) {
    console.log('Toggled Expand Row!', row);
    this.table.rowDetail.toggleExpandRow(row);
  }

}

export interface Mails {
  from: string
  fromName: string
  subject: string
  body: string
  id: number
  createdDate: string
}

