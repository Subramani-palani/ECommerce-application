import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
  HttpErrorResponse
} from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { Router } from '@angular/router';
import { UserService } from '../services/User/user.service';
import {catchError} from'rxjs/operators';


@Injectable()
export class TokenInterceptor implements HttpInterceptor {

  constructor(private auth:UserService,private router:Router) {}

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {

    const myToken = this.auth.getToken();
    if(myToken){
      request=request.clone({
        setHeaders: {Authorization:`Bearer ${myToken}`}
      })
    }
    return next.handle(request).pipe(
      catchError((err:any)=>{
        if(err instanceof HttpErrorResponse){
          if(err.status == 401){
            alert("Warning ! Token is expired, Please Login Again");
            this .router.navigate(['/login']);
          }
        }
        return throwError(()=> new Error("Some other error occured"))
      })
    );
  }
}
