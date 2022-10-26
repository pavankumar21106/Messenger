import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { map } from 'rxjs';
import { slugs } from 'src/app/core/constants/api-slug';
import * as httpService from 'src/app/core/services/http.service';
import { LoaderService } from 'src/app/shared/loader/loader.service';

@Component({
  selector: 'app-compose',
  templateUrl: './compose.component.html',
  styleUrls: ['./compose.component.scss']
})
export class ComposeComponent implements OnInit {

  constructor(private readonly _httpClient: httpService.HttpService, private ngxService: LoaderService) { }

  ngOnInit() {
  }
  
  onSubmit() {
    this.ngxService.start();
    console.log(this.expensesForm);
    console.log(this.expensesForm.value);
    let temp = this._httpClient.post<any>(slugs.Compose, this.expensesForm.value).pipe(map(res => res)).subscribe(r => {
      console.log(r);
      return r;
    });
      this.ngxService.stop();
  }

  expensesForm = new FormGroup({
    toName: new FormControl('pavan'),
    to: new FormControl(''),
    subject: new FormControl(''),
    body: new FormControl('')
  });
}
