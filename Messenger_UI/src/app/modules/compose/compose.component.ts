import { Component, HostListener, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { map } from 'rxjs';
import { slugs } from 'src/app/core/constants/api-slug';
import * as httpService from 'src/app/core/services/http.service';
import { ToasterService } from 'src/app/utility/services/toster/toster.service';
import { PreventRedirect } from "../../utility/guards/prevent-redirect.guard";
@Component({
  selector: 'app-compose',
  templateUrl: './compose.component.html',
  styleUrls: ['./compose.component.scss']
})
export class ComposeComponent  implements OnInit,PreventRedirect {

  constructor(private readonly _httpClient: httpService.HttpService,
    private _router: Router,private _toster:ToasterService) { }
    toEmail = 'pavankumar21106@gmail.com';
    public isFormValid:boolean=true;

  ngOnInit() {
  }

  onSubmit() {
    this.isFormValid=this.composeForm.valid;
    if (!this.isFormValid) {
      return;
    }
    this.composeForm.patchValue({
      toName:this.toEmail.split('@')[0]
    })
    console.log(this.composeForm);
    console.log(this.composeForm.value);
    this._httpClient.post<any>(slugs.Compose, this.composeForm.value).pipe(map(res => res)).subscribe(r => {
      console.log(r);
      this.allowRedirect=true;
      this._toster.successToaster('Mail Sent');
      this._router.navigate(['inbox']);
    });
  }

  composeForm = new FormGroup({
    to: new FormControl('',[
      Validators.required,
      Validators.email
    ]),
    toName: new FormControl(''),
    subject: new FormControl(''),
    body: new FormControl(''),
    attachment:new FormControl([]),
  });
  allowRedirect: boolean =  false;
canDeactivate(): boolean {
  return !this.composeForm.dirty;
}

@HostListener('window:beforeunload', ['$event'])
beforeUnloadHander($event: any) {
  console.log('refresh');
  if (this.composeForm.dirty) {
    $event.returnValue =true;

  }
}
}
