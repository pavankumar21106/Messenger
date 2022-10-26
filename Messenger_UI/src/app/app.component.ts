import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { time } from 'console';
import { NgxUiLoaderService } from 'ngx-ui-loader';
import { environment } from 'src/environments/environment';
import { slugs } from './core/constants/api-slug';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {

  title = 'Messenger_UI';

}
