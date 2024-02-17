import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { UserProfile } from 'src/app/models/Profile/userprofile';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class UserProfileService {

  apiBaseAddress = environment.apiBaseAddress;

  constructor(private http: HttpClient) {}

  getUserProfile(): Observable<UserProfile> {
    return this.http.get<UserProfile>(this.apiBaseAddress);
  }

  updateUserProfile(userProfileData: UserProfile): Observable<UserProfile> {
    return this.http.put<UserProfile>(this.apiBaseAddress, userProfileData);
  }

}
