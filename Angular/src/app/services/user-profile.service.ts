import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { UserProfile } from '../model/userprofile';

@Injectable({
  providedIn: 'root'
})
export class UserProfileService {
  private apiUrl = '/api/user-profile';

  constructor(private http: HttpClient) {}

  getUserProfile(): Observable<UserProfile> {
    return this.http.get<UserProfile>(this.apiUrl);
  }

  updateUserProfile(userProfileData: UserProfile): Observable<UserProfile> {
    return this.http.put<UserProfile>(this.apiUrl, userProfileData);
  }
}
