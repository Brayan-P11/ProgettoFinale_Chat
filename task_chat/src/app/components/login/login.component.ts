import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../../services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {

  user: string = "";
  pass: string = "";

  constructor(private service:AuthService, private router: Router){}

  verifica(): void{
    console.log("ciao");
    this.service.login(this.user, this.pass).subscribe(risultato => {
      
      if(risultato.token){
        localStorage.setItem("ilToken", risultato.token)
        this.router.navigateByUrl("/profilo");
      }
    })
  }

}
