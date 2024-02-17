import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterOutlet } from '@angular/router';
import { MyProfileComponent } from './my-profile/my-profile.component';
import { EditProfileComponent } from './edit-profile/edit-profile.component';
import { UserProfileService } from '../services/Profile/user-profile.service';
import { UserProfileComponent } from './UserProfile.component';






@NgModule({
  declarations: [
   MyProfileComponent,
   EditProfileComponent,
   UserProfileComponent


  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    RouterOutlet,


  ],
    providers: [UserProfileService],
    exports:[
    MyProfileComponent,
    EditProfileComponent
  ]
})
export class UserProfileModule { }
