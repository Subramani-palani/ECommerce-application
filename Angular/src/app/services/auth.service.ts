import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { User } from '../models/user';
import { Observable } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class AuthService {
 // public selectedApp: User = {} as User;
 //Url to acess api
  apiBaseAddress = environment.apiBaseAddress;

  constructor(private http: HttpClient) { }
  LoginUser(user: User): Observable<any> {
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
        Authorization: 'auth-token',
        'Access-Control-Allow-Origin': '*',
      }),
    };

    return this.http.post<User>(`${this.apiBaseAddress}`, user);
  }
}
