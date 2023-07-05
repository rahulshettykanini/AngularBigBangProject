import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'AngularBigBang';
  role: string = localStorage.getItem('role') || '';


  constructor(private route:Router){}


  logoutpage() {
    localStorage.removeItem("token");
    localStorage.removeItem("role");
    this.route.navigate(['/']).then(() => {
      // Optional: Scroll to the top of the page
      window.scrollTo(0, 0);
      location.reload();

    });
  }
}
