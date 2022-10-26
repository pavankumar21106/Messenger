import { Component, OnInit } from '@angular/core';
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

  constructor(private readonly _httpClient: httpService.HttpService,private ngxService: LoaderService) { }


  ngOnInit() {
    this.ngxService.start(); 
    this.ngxService.stop(); 
    setTimeout(() => {
    }, 1000);
  }

  data = {
    "toName": "TestTo",
    "fromName": "TestFrom",
    "from": "Test@gmail.com",
    "to": "pavankumar21106@gmail.com",
    "title": "string",
    "message": "This is test",
  "attachment": [
  ]
}


  compose(){
    let temp = this._httpClient.post<any>(slugs.Compose, this.data).pipe(map(res=>res)).subscribe(r=>{
      console.log(r);
    });
  }

}
