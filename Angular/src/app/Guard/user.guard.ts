import { CanActivate, CanActivateFn, Router } from '@angular/router';
import { UserService } from '../services/User/user.service';

export class AuthGuard implements CanActivate {
  constructor(private router:Router,private auth:UserService){}
  canActivate() : boolean {

//checking if the user is authenticated
//If the user is unauthorized and  ..redirected to login page

    if(this.auth.isLoggedIn()){
       const userRole=this.auth.getRoleFromToken();
       if(userRole=='Admin')
       {
        return true;
       }
       else
       {
        alert("UnAuthorized Access!!!");
        this.router.navigate(['/']);
        return false;
       }
    }
    else{
      alert("Please Login First!");
      this.router.navigate(['/login']);
      return false;
    }
    }
}

