import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { AccountModule} from '../Account/account.module';





@NgModule({
  declarations: [

  ],
  exports:[
    AccountModule
  ],
  imports: [
    CommonModule,
    AccountModule,
    FormsModule
  ]
})
export class ApplicationModule { }
