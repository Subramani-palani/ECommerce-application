import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NavigationBarComponent } from './components/navigation-bar/navigation-bar.component';
import { FooterComponent } from './components/footer/footer.component';
import { Router, RouterModule } from '@angular/router';

import { AccountModule } from '../Account/account.module';






@NgModule({
  declarations: [  
    NavigationBarComponent,
    FooterComponent
  ],
  exports:[
    NavigationBarComponent,
    FooterComponent
  ],
  imports: [
   
    CommonModule,
    RouterModule,
    AccountModule
   
  ]
})
export class SharedModule { }
