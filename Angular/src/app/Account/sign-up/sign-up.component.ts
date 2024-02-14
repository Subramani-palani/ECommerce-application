import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AppServiceService } from 'src/app/services/app-service.service';

@Component({
  selector: 'app-sign-up',
  templateUrl: './sign-up.component.html',
  styleUrls: ['./sign-up.component.css']
})
export class SignUpComponent implements OnInit {

sigupForm!: FormGroup<any>;

/**
 *
 */
constructor(private fb:FormBuilder) {
  
  
}
  ngOnInit(): void {
    this.sigupForm = this.fb.group({
  
      username : ['',[Validators.required]],
      email : ['',[Validators.required]],
      password:['',[Validators.required]]
      
    });
  }
  onSubmit() {
    throw new Error('Method not implemented.');
  }



}
