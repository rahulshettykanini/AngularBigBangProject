import { Component, OnInit } from '@angular/core';
import { UserInternService } from '../Services/user-intern.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-update',
  templateUrl: './update.component.html',
  styleUrls: ['./update.component.css']
})
export class UpdateComponent implements OnInit {

  
  name = localStorage.getItem("this.internID");
  public applications :any;
  public appointmentId :any;
  public doctors : any;
  public cancelId :any;
  appointmentlist:any={pusername :this.name, dusername :'',  age: '', date :''}
  newappointment :any ={pusername :this.name, dusername :'',  age: '', date :''}

  constructor(private userInternService:UserInternService,private router:Router ) { 

  }

  ngOnInit() {

    
    this.GetAppointments();
  }

  private GetAppointments(): void {
    this.userInternService.getAppointments(this.name).subscribe(data=>
      {
        this.applications=data;
      });
    }


    public UpdateAppointmentById(){
      console.log(56458)
      return this.userInternService.updateappointments(this.appointmentId ,this.appointmentlist) .subscribe( result =>
        {
          // result=this.prdtlist
          alert("updated")
        }
        );                                                                     

    }


    public CancelAppointmentById(){
      console.log(56458)
      return this.userInternService.cancelappointments(this.cancelId) .subscribe( result =>
        {
          // result=this.prdtlist
          alert("Appointment Cancelled")
        }
        );                                                                     

    }

}
