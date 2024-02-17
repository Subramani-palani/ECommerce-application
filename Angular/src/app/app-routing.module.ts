import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SignUpComponent } from './Account/sign-up/sign-up.component';
import { AccountComponent } from './Account/account.component';
import { AccountModule } from './Account/account.module';
import { LoginComponent } from './Account/login/login.component';
import { ContactComponent } from './Account/contact/contact.component';
import { HomeComponent } from './application/home/home.component';
import { UserProfileComponent } from './UserProfile/UserProfile.component';
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
        path:'login',
        component:LoginComponent
      },
      {
        path:'contact',
        component:ContactComponent
      }
    ]
  },
  {
    path:'profile',
    component:UserProfileComponent,
    children:[
      {
        path:'myprofile',
        component:MyProfileComponent
      },
      {
        path:'edit',
        component:EditProfileComponent
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes),AccountModule],
  exports: [RouterModule]
})
export class AppRoutingModule { }
