import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { accountModule } from '../Account/account.module';




@NgModule({
  declarations: [
    
  ],
  exports:[
    accountModule
  ],
  imports: [
    CommonModule,

    FormsModule
  ]
})
export class ApplicationModule { }
