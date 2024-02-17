import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { User } from 'src/app/models/user';
import { UserService } from 'src/app/services/User/user.service';
import { UserapiService } from 'src/app/services/UserApi/userapi.service';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  user!: any;
  loginForm!: FormGroup;
  role!: any;
  constructor(public authservice:AuthService,
    public router:Router,private form:FormBuilder,private auth:UserapiService,private userauth:UserService){}
    ngOnInit(): void
    {
     this.loginForm=this.form.group({
      email:['',Validators.required],
      password:['',Validators.required]
     })
    }
  Getlogin(): void {

    if(this.loginForm.valid){
      this.auth.login(this.loginForm.value).subscribe({
        next:(res)=>{
          console.log(res.message);
          this.loginForm.reset();
          this.userauth.storeToken(res.token);
          console.warn(this.auth.getUsers());
          const tokenPayload = this.userauth.decodedToken();
          this.userauth.setRoleForStore(tokenPayload.role);
          this.userauth.setIdForStore(tokenPayload.Id);
          alert(" Login successfully !! ");
          
          this.userauth.getRoleFromStore().subscribe(val=>{
            const roleFromToken = this.userauth.getRoleFromToken();
            this.role = val|| roleFromToken;
          });
          if(this.role=='Admin'){
            this.router.navigate(['home']);
          }
          else{
            this.router.navigate(['/']);
          }
        },
        error:(err)=>{
          alert("Login Failed!!!")
         console.log(err);
        }
      })
      console.log(this.loginForm.value)
    }
    else{
      console.log("Form is not valid");
      alert("Your form is invalid")
    }
  }

  }

