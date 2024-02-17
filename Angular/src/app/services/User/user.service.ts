import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject } from 'rxjs';
import { environment } from 'src/environments/environment';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Router } from '@angular/router';
@Injectable({
  providedIn: 'root'
})
export class UserService {

  private role$ = new BehaviorSubject<string>("");
  private Username$ = new BehaviorSubject<string>("");
  private Id$ = new BehaviorSubject<number>(0);
  private userPayload:any;

constructor(private http:HttpClient, private router:Router) { }

//getting and setting of Role as an abservable
public getRoleFromStore(){
  return this.role$.asObservable();
}
public setRoleForStore(role:string){
  this.role$.next(role);
}


//getting and setting of username as an abservable
public getUsernameFromStore(){
  return this.Username$.asObservable();
}
public setUsernameForStore(Email:string){
  this.Username$.next(Email);
}


//getting and setting of ID as an abservable
public getIdFromStore(){
  return this.Id$.asObservable();
}
public setIdForStore(Id:number){
  this.Id$.next(Id);
}


//get and store token
getToken(){
  return localStorage.getItem('token')
 }
storeToken(tokenValue:string){
  localStorage.setItem('token',tokenValue)
}


//Checking the signed in user by token
isLoggedIn():boolean{
  return !!localStorage.getItem('token')
}


// logout method
 signOut(){
  localStorage.clear();
  this.router.navigate(['/home']);
}


//decoding the token
 decodedToken(){
   const jwtHelper = new JwtHelperService();
   const token = this.getToken()!;
   console.log(jwtHelper.decodeToken(token))
   return jwtHelper.decodeToken(token)
 }

//getting the role from token
 getRoleFromToken(){
  if(this.userPayload){
    return this.userPayload.role;
  }
 }


}
