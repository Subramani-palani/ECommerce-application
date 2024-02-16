import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { RouterOutlet } from '@angular/router';

import { MyProfileComponent } from './my-profile/my-profile.component';
import { EditProfileComponent } from './edit-profile/edit-profile.component';
import { UserprofileComponent } from './userprofile.component';
import { UserProfileService } from '../services/user-profile.service';


@NgModule({
  declarations: [
    MyProfileComponent,
    EditProfileComponent,
    UserprofileComponent
    
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
