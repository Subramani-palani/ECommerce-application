import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AccountModule } from './Account/account.module';
import { SharedModule } from './shared/shared.module';
import { CommonModule } from '@angular/common';
import { ApplicationModule } from './application/application.module';





const firebaseConfig = {
  // Your Firebase config object
};




@NgModule({
  declarations: [
    AppComponent,
  
    
  ],
  imports: [
    CommonModule,
    BrowserModule,
    AppRoutingModule,
    ApplicationModule,
    SharedModule,
    AccountModule
   
    
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
