import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { GeneralResponse } from '../classes/General';

@Injectable({
  providedIn: 'root',
})
export class GeneralService {
  private http = inject(HttpClient);
  private apiUrl = environment.API_URL;    
  constructor(){}
  ListStatus(): Observable<GeneralResponse>{
    return this.http.get<GeneralResponse>(this.apiUrl +'Status');
  }
}
