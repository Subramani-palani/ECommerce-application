import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { UserService } from 'src/app/services/User/user.service';
import { UserapiService } from 'src/app/services/UserApi/userapi.service';
import { AppServiceService } from 'src/app/services/app-service.service';

@Component({
  selector: 'app-sign-up',
  templateUrl: './sign-up.component.html',
  styleUrls: ['./sign-up.component.css']
})
export class SignUpComponent implements OnInit {
signupForm !: FormGroup;
constructor(private form:FormBuilder,private auth:UserapiService,private router: Router) {
}
ngOnInit(): void
{
  this.signupForm=this.form.group({
  personName:['',Validators.required],
  email:['',Validators.required],
  phoneNumber:['',Validators.required],
  password:['',Validators.required],
  confirmPassword:['',Validators.required]
  });
}
onRegister(){
  if(this.signupForm.value){
    this.auth.register(this.signupForm.value).subscribe({
      next: (res=>{
        console.log(res.message);
        this.signupForm.reset();
        alert("User is Registered successfully !!!")
        this.router.navigateByUrl("/Account/login");
      }),
      error:(err=>{
        alert(err?.error.message)
      })
    })
    console.log(this.signupForm.value)
   }
   else{
    alert("Ivalid Fields");
   }
  }



}
