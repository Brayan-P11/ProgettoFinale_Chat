import { Component } from '@angular/core';
import { ProfiloService } from '../../services/profilo.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-profilo',
  templateUrl: './profilo.component.html',
  styleUrl: './profilo.component.css'
})
export class ProfiloComponent {

  datiUtente: string | undefined;

  constructor(private router: Router, private service: ProfiloService){
    if(!localStorage.getItem("ilToken"))
      router.navigateByUrl("/login")

  }

  ngOnInit(): void {
    //Called after the constructor, initializing input properties, and the first call to ngOnChanges.
    //Add 'implements OnInit' to the class.
    this.service.recuperaProfilo().subscribe(risultato => {
      this.datiUtente = risultato.data
    })
  }
  
}
