import { Component } from '@angular/core';
import { UserInternService } from '../Services/user-intern.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {
   name = localStorage.getItem("this.internID");
  public applications :any;
  public appointmentId :any;
  public doctors : any;
  public cancelId :any;
  appointmentlist:any={pusername :this.name, dusername :'',  age: '', date :''}
  newappointment :any ={pusername :this.name, dusername :'',  age: '', date :''}
  
 
  
  constructor(private userInternService:UserInternService,private router:Router)
  {

  }

  
  ngOnInit(): void {
    this.GetDoctors();
  }

  
  
    private GetDoctors(): void {
      this.userInternService.getDoctors().subscribe(data=>
        {
          this.doctors=data;
        });
      }


  

    public BookAppointmentById(){
      console.log(56458)
      return this.userInternService.bookappointments(this.newappointment) .subscribe( result =>
        {
          // result=this.prdtlist
          alert("Appointment Booked")
        }
        );                                                                     

    }

   

    
    update()
    {
      this.router.navigate(['update']);
    }
  
  }


