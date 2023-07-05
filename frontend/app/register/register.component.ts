import { Component } from '@angular/core';
import { InternModel } from '../Models/intern.model';
import { UserInternService } from '../Services/user-intern.service';
import { UserDTOModel } from '../Models/userDTO.model';
import { Router } from '@angular/router';
import { DoctorModel } from '../Models/Doctor.model';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent 
{
  intern:InternModel;
  userdto:UserDTOModel;
  response:DoctorModel;
  result:any;
  doctor:DoctorModel;
  show:string;


  constructor(private userInternService:UserInternService,//Injections
              private router:Router
              )
  {
    this.intern = new InternModel();
    this.userdto=new UserDTOModel();
    this.response=new DoctorModel();
    this.doctor=new DoctorModel();
    this.show="";
  }

  

  onRoleChange() {
    if (this.intern.role === 'doctor') {
      this.show="doctor";
      this.doctorReg();
    }
  }
  doctorReg(){
    
    this.doctor.name=this.intern.name;
    this.doctor.email=this.intern.email;
    this.doctor.userName=this.intern.userName;
    this.doctor.gender=this.intern.gender;
    this.doctor.role=this.intern.role;
    this.doctor.password=this.intern.userPassword;
  
  }

  isValidForm(): boolean {
    return (
      !!this.intern.name &&
      !!this.intern.userName &&
      !!this.intern.userPassword &&
      !!this.intern.gender &&
      !!this.intern.role &&
      (this.show !== 'doctor' || (this.show === 'doctor' && !!this.doctor.specialization && !!this.doctor.experiance))
    );
  }
  

  addIntern()
  {
    if (this.intern.role === "doctor") {
      this.userInternService.staffRegister(this.doctor).subscribe(
        (data) => {
          // Success response
          this.response = data;
          this.response = data;
      if (data && data.name !== "") {
        this.result = "wait for admin approval";
        alert('Resuest Sent Successful');
      } else {
        this.result = "change the user name";
        alert('Error in Resuest Sent');
      }
        },
        (error) => {
          // Error response
          console.log(error); // Log the error for debugging purposes
          // Handle the error or display an error message to the user
        }
      );
    }
       if(this.intern.role==="user")   
       {
        this.userInternService.userRegister(this.intern).subscribe(data=>//Entered details inserted into database
        {
          this.userdto = data as UserDTOModel;//copying the returned data into userdto object
          localStorage.setItem("token",this.userdto.token);//set token into localStorage
          localStorage.setItem("this.internID",(this.userdto.userName).toString());//set ID into localStorage
  
  
          
          
   
          if(this.userdto.role=="user")//If user is intern navigate to intern restricted page
          {
            this.router.navigate(['logIN']);
          }
          else if(this.userdto.role=="Admin")//If user is Admin navigate to intern restricted page
          {
            this.router.navigate(['admin']);
          }
          
          console.log(this.userdto);
        },
      
        err=>{
          console.log(err)
        });
  
       }
      
      
  }
  
  
  login()
  {
    this.router.navigate(['logIN']);
  }


}