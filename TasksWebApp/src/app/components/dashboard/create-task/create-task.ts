import { ChangeDetectorRef, Component, inject, OnInit } from '@angular/core';
import { FormBuilder, ReactiveFormsModule, Validators, ɵInternalFormsSharedModule } from "@angular/forms";
import { TaskService } from '../../../services/task-service';
import { ActivatedRoute, Router } from '@angular/router';
import { UserService } from '../../../services/user-service';
import { User } from '../../../classes/User';
import Swal from 'sweetalert2';
import { Task, TaskCreate } from '../../../classes/Task';

@Component({
  selector: 'app-create-task',
  imports: [ReactiveFormsModule],
  templateUrl: './create-task.html',
  styleUrl: './create-task.css',
})
export class CreateTask implements OnInit {
  private service = inject(TaskService);
  private userService = inject(UserService);
  private router = inject(Router);
  private route = inject(ActivatedRoute);
  private cdr =  inject(ChangeDetectorRef); 
  public formBuild = inject(FormBuilder);
  
  lstUsers:User[] = [];

  createForm=this.formBuild.group({
    title: ['', [Validators.required]],
    duration: ['', [Validators.required], Validators.min(1)],
    userId: ['', [Validators.required]],    
  });

  ngOnInit(): void {
    this.LoadUsers();
  }

  LoadUsers(){
    this.userService.List().subscribe({
      next:(data) =>{        
        if(data.isValid){                           
          this.lstUsers = data.resultData;               
        }        
      }
    });
  }

  Save(){
    debugger;
    if(this.createForm.invalid){ 
          Swal.fire({
              title: "Important",
              text: "Please fill the required fields",
              icon: "error",
              timer:3000
          });     
          return;
    }
    const objTask:TaskCreate = {
          id:0,
          name: this.createForm.value.title!,
          duration: Number(this.createForm.value.duration!),
          userId: Number(this.createForm.value.userId!),
          statusId:1          
    };
    this.service.Create(objTask).subscribe({
          next: (data) =>{
              if(data.isValid){
                Swal.fire({
                  title: "Registry successful",
                  text: "The task was created successfully.",
                  icon: "success",
                  timer:3000
                });
                this.router.navigate(['../Tasks'], { relativeTo: this.route })
              }else{
                    Swal.fire({
                        title: "Failed insertion",
                        text: "Could not insert the Task. Please try again",
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
    this.router.navigate(['../tasks'], { relativeTo: this.route })
  }

}
