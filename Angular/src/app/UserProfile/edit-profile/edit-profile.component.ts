import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { UserProfile } from 'src/app/models/Profile/userprofile';
import { UserProfileService } from 'src/app/services/Profile/user-profile.service';

@Component({
  selector: 'app-edit-profile',
  templateUrl: './edit-profile.component.html',
  styleUrls: ['./edit-profile.component.css']
})
export class EditProfileComponent implements OnInit {

  profileForm: FormGroup;

  constructor(private formBuilder: FormBuilder, private userProfileService: UserProfileService, private router: Router) {
    this.profileForm = this.formBuilder.group({
      Name: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      phoneNumber: ['', Validators.required],
      address: ['', Validators.required]
    });
  }
  ngOnInit(): void {

  }

  save(): void {
    if (this.profileForm.valid) {
      const userProfileData: UserProfile = {
        // Create a new instance of UserProfile using form data
        PersonName: this.profileForm.value.firstName,
        Email: this.profileForm.value.email,
        PhoneNumber: this.profileForm.value.phoneNumber,
      };

      // Send userProfileData to your backend
      this.userProfileService.updateUserProfile(userProfileData).subscribe(
        (response) => {
          console.log('User profile data updated successfully:', response);

          // Navigate back to the MyProfileComponent
          this.router.navigate(['profile']);
        },
        (error) => {
          console.error('Error updating user profile data:', error);
        }
      );
    } else {
      // Form is invalid, display error message or handle accordingly
      console.log('Form is invalid. Please check the fields.');
    }
  }

}
