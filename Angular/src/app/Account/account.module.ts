import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SignUpComponent } from './sign-up/sign-up.component';
import { RouterOutlet } from '@angular/router';
import { AccountComponent } from './account.component';



@NgModule({
  declarations: [
    SignUpComponent,
    AccountComponent
    
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    RouterOutlet
  
  ],exports:[
    SignUpComponent
  ]
})
export class AccountModule { }
