import { Component } from '@angular/core';
import { AppServiceService } from 'src/app/services/app-service.service';

@Component({
  selector: 'app-navigation-bar',
  templateUrl: './navigation-bar.component.html',
  styleUrls: ['./navigation-bar.component.css']
})
export class NavigationBarComponent {
  isMobileMenuOpen!: boolean;
  isLoggedIn: boolean = false; // Add this property

  constructor(private app: AppServiceService) {}

  toggleMobileMenus() {
    this.isMobileMenuOpen = this.app.toggleMobileMenu();
  }

  // a method to check if the user is logged in
  checkLoginStatus() {
    // For example, you can check if there is a token in local storage
    this.isLoggedIn = localStorage.getItem('token') !== null;
  }

  ngOnInit() {
    this.checkLoginStatus();
  }
}
