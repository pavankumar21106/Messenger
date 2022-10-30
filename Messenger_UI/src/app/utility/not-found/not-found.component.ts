import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-not-found',
  //remember:this is for svg as a template
  // templateUrl: '../../../assets/icons/undraw_page_not_found_re_e9o6 (1).svg',
  templateUrl: './not-found.component.html',
  styleUrls: ['./not-found.component.scss']
})
export class NotFoundComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

}
