import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
@Injectable({
  providedIn: 'root'
})
export class UserapiService {
  apiBaseAddress = environment.apiBaseAddress;
constructor(private http:HttpClient,private router:Router) { }
//register & login  and get all user

getUsers()
{
 return this.http.get<any>(this.apiBaseAddress);
}

register(userObj:any){
  return this.http.post<any>(`${this.apiBaseAddress}api/Accounts/Register`,userObj);
}

login(loginObj:any){

  return this.http.post<any>(`${this.apiBaseAddress}api/Accounts/Login`,loginObj);
}

authenticate(login:any){
  this.http.post<any>(`${this.apiBaseAddress}api/Accounts/Login`,JSON.stringify(login));
  this.http.get<any>(this.apiBaseAddress).subscribe(res=>
      {
        const user=res.find((a:any)=>
        {
          return a.email === login.email && a.password === login.password;
        });
        if(user)
        {
          localStorage.setItem('user', JSON.stringify(user))

        }
        console.warn(user);
      });
    }

}
