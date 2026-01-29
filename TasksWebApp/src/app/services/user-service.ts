import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { GeneralResponse } from '../classes/General';
import { Observable } from 'rxjs';
import { User } from '../classes/User';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  private http = inject(HttpClient);
  private apiUrl = environment.API_URL;
  
  constructor(){}

  List(): Observable<GeneralResponse>{
    return this.http.get<GeneralResponse>(this.apiUrl + 'Users');
  }

  GetById(id:number): Observable<GeneralResponse>{
    return this.http.get<GeneralResponse>(this.apiUrl + 'Users/' + id.toString());
  }
  
  Create(request:User):Observable<GeneralResponse>{
    return this.http.post<GeneralResponse>(this.apiUrl + 'Users',request);
  }
}
