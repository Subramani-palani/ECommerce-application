import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SignUpComponent } from './Account/sign-up/sign-up.component';
import { AccountComponent } from './Account/account.component';
import { AccountModule } from './Account/account.module';


const routes: Routes = [
  
  {
    path:'',
    component:AccountComponent
  },
  {
    path:'Account',component:AccountComponent,
    children:[
      {
        path:'signup',
        component:SignUpComponent
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes),AccountModule],
  exports: [RouterModule]
})
export class AppRoutingModule { }
