import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { RisToken } from '../models/ris-token';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  
  constructor(private http:HttpClient) { }

  login(use: string, pas: string): Observable<RisToken>{
    let headerCustom = new HttpHeaders();
    headerCustom.set('Content-type', 'application/json')

    let invio = {
      use,
      pas
    }

    return this.http.post<any>("https://localhost:7123/login", invio, { headers: headerCustom });
  }
}
