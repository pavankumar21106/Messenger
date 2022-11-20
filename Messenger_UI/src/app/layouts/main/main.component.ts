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
  ngOnInit(): void {
    throw new Error('Method not implemented.');
  }

}
