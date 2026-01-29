import { Component, inject } from '@angular/core';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { UserService } from '../../../services/user-service';
import { ActivatedRoute, Router } from '@angular/router';
import Swal from 'sweetalert2';
import { User } from '../../../classes/User';

@Component({
  selector: 'app-create-user',
  imports: [ReactiveFormsModule],
  templateUrl: './create-user.html',
  styleUrl: './create-user.css',
})
export class CreateUser {
  private service = inject(UserService);
  private router = inject(Router);
  private route = inject(ActivatedRoute);
  public formBuild = inject(FormBuilder);

  createForm=this.formBuild.group({
    firstName: ['', [Validators.required]],
    lastName: ['', [Validators.required]],
    documentNumber: ['', [Validators.required], Validators.minLength(6), Validators.maxLength(12)],
    email: ['', [Validators.required, Validators.email]],
    phoneNumber: ['', [Validators.required, Validators.minLength(10)]]    
  });

  constructor() {}

  Save(){
    if(this.createForm.invalid){ 
          Swal.fire({
              title: "Important",
              text: "Please fill the required fields",
              icon: "error",
              timer:3000
          });     
          return;
    }
    const objUser:User = {
          id:0,
          firstName: this.createForm.value.firstName!,
          lastName: this.createForm.value.lastName!,
          documentNumber: this.createForm.value.documentNumber!.toString(),
          phoneNumber: this.createForm.value.phoneNumber!.toString(),
          email: this.createForm.value.email!,                            
    };
    this.service.Create(objUser).subscribe({
          next: (data) =>{
              if(data.isValid){
                Swal.fire({
                  title: "Registry successful",
                  text: "The user was created successfully.",
                  icon: "success",
                  timer:3000
                });
                    this.router.navigate(['../users'], { relativeTo: this.route })
              }else{
                    Swal.fire({
                        title: "Failed insertion",
                        text: "Could not insert the user. Please try again",
                        icon: "error",
                        timer:3000
                    });
              }
          }, error:(error) =>{
              console.log(error.message);
          }
    })
  }
  GoBack(){
    this.router.navigate(['../users'], { relativeTo: this.route })
  }
}
