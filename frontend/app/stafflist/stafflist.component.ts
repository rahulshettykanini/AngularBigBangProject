import { Component } from '@angular/core';

import { UserInternService } from '../Services/user-intern.service';

@Component({
  selector: 'app-stafflist',
  templateUrl: './stafflist.component.html',
  styleUrls: ['./stafflist.component.css']
})
export class StafflistComponent {

  public stafflist :any;

  
  
  constructor(private userInternService:UserInternService)
  {

  }

  ngOnInit(): void {
    this.GetAllStaffs();
  }
  

    
  private GetAllStaffs(): void {
    this.userInternService.getStaffs().subscribe(data=>
      {
        this.stafflist=data;
      });
}




}
