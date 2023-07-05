import { Component } from '@angular/core';
import { UserDTOModel } from '../Models/userDTO.model';
import { UserInternService } from '../Services/user-intern.service';
import { Router } from '@angular/router';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent 
{
  user:UserDTOModel;
  toggle:boolean;

  constructor(private userInterService:UserInternService,
              private router:Router)
  {
    this.user=new UserDTOModel();
    
    this.toggle=false;
  }

  addUser()
  {
    this.userInterService.userlogin(this.user).subscribe(data=>
    {
      this.user=data as UserDTOModel;//copy the returned user from the api if the user is present and id and password is match

      //Setting the object properties into the localStorage for the further operation
      localStorage.setItem("token",this.user.token);
      localStorage.setItem("this.internID",(this.user.userName).toString());
      localStorage.setItem("role",this.user.role);
      console.log(this.user);

  
      if(this.user.role=="user")
      {
        this.router.navigate(['/']).then(() => {
          // Optional: Scroll to the top of the page
          window.scrollTo(0, 0);
          location.reload();
    
        });
    
      }
      else if(this.user.role=="admin")
      {
        this.router.navigate(['/admin']).then(() => {
          // Optional: Scroll to the top of the page
          window.scrollTo(0, 0);
          location.reload();
    
        });
      }
      else if(this.user.role=="doctor")
      {
        
        //this.router.navigate(['staff']);
        this.router.navigate(['/staff']).then(() => {
          // Optional: Scroll to the top of the page
          window.scrollTo(0, 0);
          location.reload();
    
        });
      }
      else{
        this.toggle=!this.toggle;
      }
    },
    err=>{
      console.log(err);
    });
    
  }

  register()
  {
    this.router.navigate(['register']);
  }

  
  
}