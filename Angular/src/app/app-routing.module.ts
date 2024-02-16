import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SignUpComponent } from './Account/sign-up/sign-up.component';
import { AccountComponent } from './Account/account.component';
import { AccountModule } from './Account/account.module';
import { HomeComponent } from './application/home/home.component';
import { ContactComponent } from './Account/contact/contact.component';
import { UserprofileComponent } from './UserProfile/userprofile.component';
import { MyProfileComponent } from './UserProfile/my-profile/my-profile.component';
import { EditProfileComponent } from './UserProfile/edit-profile/edit-profile.component';


const routes: Routes = [
  
  {
    path:'',
    component:HomeComponent
  },
  {
    path:'Account',component:AccountComponent,
    children:[
      {
        path:'signup',
        component:SignUpComponent
      },
      {
        path:'contact',
        component:ContactComponent
      }
    ]
  },
  {
    path: 'profile',
    component: UserprofileComponent,
    children: [
      {
        path: 'myprofile',
        component: MyProfileComponent,
      },
      {
        path: 'edit',
        component: EditProfileComponent
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes),AccountModule],
  exports: [RouterModule]
})
export class AppRoutingModule { }
