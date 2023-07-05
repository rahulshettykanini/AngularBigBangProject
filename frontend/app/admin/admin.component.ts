import { Component } from '@angular/core';
import { InternModel } from '../Models/intern.model';
import { UserDTOModel } from '../Models/userDTO.model';
import { Router } from '@angular/router';
import { UserInternService } from '../Services/user-intern.service';
import { DoctorModel } from '../Models/Doctor.model';

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.css']
})
export class AdminComponent {
  intern:InternModel;
  userdto:UserDTOModel;
  public staff:any;
  public newstaff:any;
  public deleteStaff:any;
  public remove:any;
  public touser:InternModel;
  public todoctor:DoctorModel


  constructor(private userInternService:UserInternService,//Injections
              private router:Router
              )
  {
    this.intern = new InternModel();
    this.userdto=new UserDTOModel();
    this.touser=new InternModel();
    this.todoctor=new DoctorModel();
  }

  sendRequest()
  {
    this.userInternService.getStaffs().subscribe(data=>
      {
        this.staff=data;

        // this.userInternService.userRegister(this.intern).subscribe(data=>//Entered details inserted into database
        // {
        //   this.userdto = data as UserDTOModel;//copying the returned data into userdto object
        //   localStorage.setItem("token",this.userdto.token);//set token into localStorage
        //   localStorage.setItem("this.internID",(this.userdto.userName).toString());//set ID into localStorage
  
  
          
          
   
          // if(this.userdto.role=="staff")//If user is intern navigate to intern restricted page
          // {
          //   this.router.navigate(['logIN']);
          // }
          
          console.log(this.userdto);
        // },
      
        // err=>{
        //   console.log(err)
        // });
      });
  }

  addRow(obj:any)
  {
    this.touser.name=obj.name;
    this.touser.email=obj.email;
    this.touser.userName=obj.userName;
    this.touser.gender=obj.gender;
    this.touser.role=obj.role;
    this.touser.userPassword=obj.password;

    this.todoctor.name=obj.name;
    this.todoctor.email=obj.email;
    this.todoctor.userName=obj.userName;
    this.todoctor.gender=obj.gender;
    this.todoctor.role=obj.role;
    this.todoctor.specialization=obj.specialization ;
    this.todoctor.experiance=obj.experiance;

    this.userInternService.userRegister(this.touser).subscribe(data=>
    {
      this.userdto = data as UserDTOModel;//copying the returned data into userdto object
      localStorage.setItem("token",this.userdto.token);//set token into localStorage
      localStorage.setItem("this.internID",(this.userdto.userName).toString());//set ID into localStorage
      alert('Registration Successful');
      this.sendRequest();
    });
    this.userInternService.doctorRegister(this.todoctor).subscribe(data=>
      {
        this.userdto = data as UserDTOModel;//copying the returned data into userdto object
      localStorage.setItem("token",this.userdto.token);//set token into localStorage
      localStorage.setItem("this.internID",(this.userdto.userName).toString());//set ID into localStorage
      alert('Registration Successful');
      this.sendRequest();
      })

  }
  deleteRow(obj:any)
  {
    this.deleteStaff=obj;
    this.userInternService.deleteStaffInList(this.deleteStaff).subscribe(data=>
      {
              this.remove=data;
              this.sendRequest();

      });
  }
}
