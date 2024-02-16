import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import {
  Carousel,
  initTE,
} from "tw-elements";

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  demo:any[] =[1,2,3,4,5]
days: any = 3;
hours: any = 10;
minutes: any = 35;
seconds: any = 19;
  ngOnInit(): void {
    initTE({ Carousel });
  }

}
