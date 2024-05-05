import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Risposta } from '../models/risposta';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ProfiloService {

  constructor(private http: HttpClient) { }

  recuperaProfilo(): Observable<Risposta>{
    let contenutoToken = localStorage.getItem("ilToken");

    let headerCustom = new HttpHeaders(
      {
        Authorization: `Bearer ${contenutoToken}`
      }
    );
    // DA aggiungere l'endpoint giusto
    return this.http.get<Risposta>("https://localhost:7123/profiloutente", {headers: headerCustom});
  }
}
