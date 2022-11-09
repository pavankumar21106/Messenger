import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
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

  constructor(private readonly _httpClient: httpService.HttpService, private ngxService: LoaderService,
    private _router: Router) { }

  ngOnInit() {
  }
  
  onSubmit() {
    this.ngxService.start();
    console.log(this.composeForm);
    console.log(this.composeForm.value);
    let temp = this._httpClient.post<any>(slugs.Compose, this.composeForm.value).pipe(map(res => res)).subscribe(r => {
      console.log(r);
      this._router.navigate(['inbox']);
      return r;
    });
      this.ngxService.stop();
  }

  composeForm = new FormGroup({
    toName: new FormControl('pavan'),
    to: new FormControl(''),
    subject: new FormControl(''),
    body: new FormControl(''),
    attachment:new FormControl([]),
  });
}
