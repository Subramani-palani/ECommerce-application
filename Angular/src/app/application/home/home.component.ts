import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { AppServiceService } from 'src/app/services/app-service.service';
// TW Elements is free under AGPL, with commercial license required for specific uses. See more details: https://tw-elements.com/license/ and contact us for queries at tailwind@mdbootstrap.com 
// Initialization for ES Users
// import {
//   Dropdown,
//   Ripple,
//   initTE,
// } from "tw-elements";

// initTE({ Dropdown, Ripple });

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {

  isOpen!: boolean;
  /**
   *
   */
  constructor(private app:AppServiceService) {
    
    
  }
  toggleDropdown() {
   this.isOpen = this.app.toggleDropdown();  
  }

  
}
