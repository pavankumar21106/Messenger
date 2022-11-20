import { Injectable } from '@angular/core';
import { ToastrService } from 'ngx-toastr';

@Injectable({
  providedIn: 'root'
})
export class ToasterService {

  constructor(private toastr: ToastrService) { }

  successToaster(message:string) {
    this.toastr.success(message);
  }
  errorToaster(message:string) {
    this.toastr.error(message);
  }
}
