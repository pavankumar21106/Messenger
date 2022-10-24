import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { environment } from 'src/environments/environment';
import { slugs } from './core/constants/api-slug';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {

  constructor() {
  }

  title = 'Messenger_UI';

  test(){
    console.log('test');
    
    //this.http.get(environment.BaseUrl+"Message/GetMessages")
  }
}
