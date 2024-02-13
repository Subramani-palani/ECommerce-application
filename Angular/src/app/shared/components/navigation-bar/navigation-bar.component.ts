import { Component } from '@angular/core';
import { AppServiceService } from 'src/app/services/app-service.service';

@Component({
  selector: 'app-navigation-bar',
  templateUrl: './navigation-bar.component.html',
  styleUrls: ['./navigation-bar.component.css']
})
export class NavigationBarComponent {
  /**
   *
   */ isMobileMenuOpen!:boolean;
  constructor(private app:AppServiceService) {
    
    
  }
 
  toggleMobileMenus(){
    this.isMobileMenuOpen=this.app.toggleMobileMenu()
  }
  
}
