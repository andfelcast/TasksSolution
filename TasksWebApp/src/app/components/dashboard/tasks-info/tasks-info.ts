import { ChangeDetectorRef, Component, inject } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { TaskService } from '../../../services/task-service';
import { Task } from '../../../classes/Task';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-tasks-info',
  imports: [],
  templateUrl: './tasks-info.html',
  styleUrl: './tasks-info.css',
})
export class TasksInfo {
  private router = inject(Router);
  private route =  inject(ActivatedRoute);
  private service = inject(TaskService);
  private cdr =  inject(ChangeDetectorRef); 
  lstTasks:Task[] = [];
  ngOnInit(): void {
    this.LoadTasks();
  }
  LoadTasks(){
    this.service.List().subscribe({
      next:(data) =>{        
        if(data.isValid){                           
          this.lstTasks = data.resultData;   
          this.cdr.detectChanges();       
        }        
      }
    });
  }
  Create(){
    this.router.navigate(['../createTask'], { relativeTo: this.route })
  }
  Details(id:number){
    let Task = this.lstTasks.find(x => x.id== id)!;  
    let htmlTable=`<table class="table">
                  <tbody>                  
                  `;  
    htmlTable +=`<tr><td>Name</td><td>` + Task.name + `</td></tr>`;
    htmlTable +=`<tr><td>Duration(hours)</td><td>` + Task.duration + `</td></tr>`;
    htmlTable +=`<tr><td>User</td><td>` + Task.userName + `</td></tr>`;
    htmlTable +=`<tr><td>Status</td><td>` + Task.statusName + `</td></tr>`;    
    htmlTable += `</tbody></table>`;
    Swal.fire({
      titleText: 'Task Info', // Use titleText for simple text title
      html: htmlTable, // Insert the HTML string here
      icon: 'info', // Optional: adds an icon (e.g., 'info', 'success', 'warning', 'error')
      confirmButtonText: 'Close'
    });
  }
  ChangeStatus(id:number){
    this.service.ChangeStatus(id).subscribe({
      next: (data) =>{
        if(data.isValid){
          Swal.fire({
            title: "Update successful",
            text: "The task was updated successfully.",
            icon: "success",
            timer:3000
          });         
          this.LoadTasks(); 
        }else{
              Swal.fire({
                  title: "Failed update",
                  text: "Could not update the task status. Please try again",
                  icon: "error",
                  timer:3000
              });
        }
      }, error:(error) =>{
          console.log(error.message);
    }
    });
    
  }
}
