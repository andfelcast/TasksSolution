import { ChangeDetectorRef, Component, inject, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { User } from '../../../classes/User';
import { UserService } from '../../../services/user-service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-users-info',
  imports: [],
  templateUrl: './users-info.html',
  styleUrl: './users-info.css',
})
export class UsersInfo implements OnInit{
  private router = inject(Router);
  private route =  inject(ActivatedRoute);
  private service = inject(UserService);
  private cdr =  inject(ChangeDetectorRef); 
  lstUsers:User[] = [];
  ngOnInit(): void {
    this.LoadUsers();
  }
  LoadUsers(){
    this.service.List().subscribe({
      next:(data) =>{        
        if(data.isValid){                           
          this.lstUsers = data.resultData;   
          this.cdr.detectChanges();       
        }        
      }
    });
  }
  Create(){
    this.router.navigate(['../createUser'], { relativeTo: this.route })
  }
  Details(id:number){
    let user = this.lstUsers.find(x => x.id== id)!;  
    let htmlTable=`<table class="table">
                  <tbody>                  
                  `;  
    htmlTable +=`<tr><td>Name</td><td>` + user.firstName + ' ' + user.lastName + `</td></tr>`;
    htmlTable +=`<tr><td>Document Number</td><td>` + user.documentNumber + `</td></tr>`;
    htmlTable +=`<tr><td>Email</td><td>` + user.email + `</td></tr>`;
    htmlTable +=`<tr><td>Phone</td><td>` + user.phoneNumber + `</td></tr>`;    
    htmlTable += `</tbody></table>`;
    Swal.fire({
      titleText: 'User Info', // Use titleText for simple text title
      html: htmlTable, // Insert the HTML string here
      icon: 'info', // Optional: adds an icon (e.g., 'info', 'success', 'warning', 'error')
      confirmButtonText: 'Close'
    });
  }
}
