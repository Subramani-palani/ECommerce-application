import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { UserProfile } from 'src/app/models/Profile/userprofile';
import { UserProfileService } from 'src/app/services/Profile/user-profile.service';

@Component({
  selector: 'app-my-profile',
  templateUrl: './my-profile.component.html',
  styleUrls: ['./my-profile.component.css']
})
export class MyProfileComponent implements OnInit {

  profileForm!: FormGroup;
  userProfileData!: UserProfile;

  constructor(
    private formBuilder: FormBuilder,
    private router: Router,
    private userProfileService: UserProfileService
  ) {}

  ngOnInit(): void {
    // Fetch user profile data from the backend
    this.userProfileService.getUserProfile().subscribe(
      (data: UserProfile) => {
        this.userProfileData = data;

        // Initialize the form with user profile data
        this.profileForm = this.formBuilder.group({
          Name: [this.userProfileData.PersonName, Validators.required],
          email: [this.userProfileData.Email, [Validators.required, Validators.email]],
          phoneNumber: [this.userProfileData.PhoneNumber, Validators.required],
        });
      },
      (error) => {
        console.error('Error fetching user profile data:', error);
      }
    );
  }

  save(): void {
    if (this.profileForm.valid) {
      const updatedUserProfileData: UserProfile = {
        // Create a new instance of UserProfile using form data
        PersonName: this.profileForm.value.firstName,
        Email: this.profileForm.value.email,
        PhoneNumber: this.profileForm.value.phoneNumber,
      };

      // Send updatedUserProfileData to your backend
      this.userProfileService.updateUserProfile(updatedUserProfileData).subscribe(
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

  navigateToEditProfile() {
    this.router.navigate(['profile/edit']);
  }

}
