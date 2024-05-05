import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'task_chat';

  isLoggato: boolean = false;

  constructor(){
    if(localStorage.getItem("ilToken"))
      this.isLoggato = true;
  }
}
