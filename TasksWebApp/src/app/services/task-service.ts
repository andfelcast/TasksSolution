import { inject, Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { GeneralResponse } from '../classes/General';
import { Observable } from 'rxjs';
import { Task, TaskCreate } from '../classes/Task';

@Injectable({
  providedIn: 'root',
})
export class TaskService {
  private http = inject(HttpClient);
  private apiUrl = environment.API_URL;
  controller:string = 'Tasks';

  
  constructor(){}
  List(): Observable<GeneralResponse>{
    return this.http.get<GeneralResponse>(this.apiUrl + this.controller);
  }

  GetById(id:number): Observable<GeneralResponse>{
    return this.http.get<GeneralResponse>(this.apiUrl + this.controller + '/' + id.toString());
  }
  
  Create(request:TaskCreate):Observable<GeneralResponse>{
    return this.http.post<GeneralResponse>(this.apiUrl + this.controller,request);
  }

  ChangeStatus(taskId: number):Observable<GeneralResponse>{
    return this.http.put<GeneralResponse>(this.apiUrl + this.controller +'/' + taskId.toString() + '/status',null);
  }
}
