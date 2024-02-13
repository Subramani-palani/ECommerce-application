import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AppServiceService {

  constructor() { }
  isMobileMenuOpen: boolean = false ;
  toggleMobileMenu(): boolean {
    this.isMobileMenuOpen = !this.isMobileMenuOpen;
    return this.isMobileMenuOpen
  }
}
