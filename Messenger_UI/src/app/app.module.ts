import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './modules/login/login.component';
import { HeaderComponent } from './layouts/header/header.component';
import { InboxComponent } from './modules/inbox/inbox.component';
import { ComposeComponent } from './modules/compose/compose.component';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import {
  NgxUiLoaderModule,
  NgxUiLoaderConfig,
  SPINNER,
  POSITION,
  PB_DIRECTION,
} from "ngx-ui-loader";
import { NgxDatatableModule } from '@swimlane/ngx-datatable';
import { NotFoundComponent } from './utility/not-found/not-found.component';
import { jwt } from './core/interceptors/jwt.interceptor';
import { ToHtmlPipe } from './utility/pipes/to-html.pipe';
import { MainComponent } from './layouts/main/main.component';
import { TextHidePipe } from './utility/pipes/text-hide.pipe';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';

//TODO:move this
const ngxUiLoaderConfig: NgxUiLoaderConfig = {
  "bgsColor": "#00dce9",
  "bgsOpacity": 0.5,
  "bgsPosition": "bottom-right",
  "bgsSize": 60,
  "bgsType": "ball-spin-clockwise",
  "blur": 5,
  "delay": 0,
  "fastFadeOut": true,
  "fgsColor": "#0c80e3",
  "fgsPosition": "center-center",
  "fgsSize": 60,
  "fgsType": "cube-grid",
  "gap": 24,
  "logoPosition": "center-center",
  "logoSize": 120,
  "logoUrl": "",
  "masterLoaderId": "master",
  "overlayBorderRadius": "0",
  "overlayColor": "rgba(40, 40, 40, 0.8)",
  "pbColor": "#02eb25",
  "pbDirection": "ltr",
  "pbThickness": 3,
  "hasProgressBar": false,
  "text": "Loading",
  "textColor": "#FFFFFF",
  "textPosition": "center-center",
  // "maxTime": -1,
  // "minTime": 300
};

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    HeaderComponent,
    InboxComponent,
    ComposeComponent,
    NotFoundComponent,
    ToHtmlPipe,
    MainComponent,
    TextHidePipe,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    CommonModule,
   BrowserAnimationsModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    NgxDatatableModule,
    NgxUiLoaderModule.forRoot(ngxUiLoaderConfig),
    ToastrModule.forRoot({
      timeOut: 3000,
      closeButton:true,
      maxOpened:3,
      progressBar:true,
    }),
  ],
  providers: [{ provide: HTTP_INTERCEPTORS, useClass:jwt, multi: true }],
  bootstrap: [AppComponent]
})
export class AppModule { }
