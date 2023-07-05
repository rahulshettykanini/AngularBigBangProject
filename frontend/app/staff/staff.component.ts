import { Component } from '@angular/core';
import { UserInternService } from '../Services/user-intern.service';

@Component({
  selector: 'app-staff',
  templateUrl: './staff.component.html',
  styleUrls: ['./staff.component.css']
})
export class StaffComponent {
  
name = localStorage.getItem("this.internID");
public appoints : any;


constructor(private userInternService:UserInternService)
  {

  }

  ngOnInit(): void {

    this.GetMyAppointments();
  }

  private GetMyAppointments(): void {
    this.userInternService.getMyAppointments(this.name).subscribe(data=>
      {
        this.appoints=data;
      });
    }













}
