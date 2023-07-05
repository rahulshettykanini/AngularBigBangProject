import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { UserDTOModel } from '../Models/userDTO.model';
import { InternModel } from '../Models/intern.model';
import { Observable } from 'rxjs/internal/Observable';
import { DoctorModel } from '../Models/Doctor.model';
import { DoctorTableModel } from '../Models/DoctorTable.model';

@Injectable({
  providedIn: 'root'
})
export class UserInternService {

  constructor(private httpClient:HttpClient) {
   }

   userlogin(user:UserDTOModel){
    return this.httpClient.post("https://localhost:7232/api/Users/LogIN/login",user);
   }

   userRegister(intern:InternModel):Observable<any>
   {
    return this.httpClient.post("https://localhost:7232/api/Users/Register",intern);
   }

   doctorRegister(doctor:DoctorTableModel):Observable<any>
   {
    return this.httpClient.post("https://localhost:7232/api/Doctors",doctor);

   }

   staffRegister(doctor:DoctorModel):Observable<any>
   {
    return this.httpClient.post("https://localhost:7232/api/Doctors/staff",doctor);

   }
   getStaffs():Observable<any>
   {
    return this.httpClient.get("https://localhost:7232/api/Doctors");

   }

   deleteStaffInList(intern:InternModel):Observable<any>
   {
    return this.httpClient.post("https://localhost:7232/api/Doctors/deleteStaffinlist",intern);
   }

   getAppointments(name :any):Observable<any>
   {
    return this.httpClient.get("https://localhost:7232/api/Appointments/patientname"+name);

   }

   getDoctors():Observable<any>
   {
    return this.httpClient.get("https://localhost:7232/api/Appointments/all");

   }


   updateappointments(id:number,updatedCar:any):Observable<any>
   {
     let url=("https://localhost:7232/api/Appointments/" + id);
     return this.httpClient.put(url, updatedCar);
   }
  
   bookappointments(book:any):Observable<any>
   {
    
    return this.httpClient.post("https://localhost:7232/api/Appointments",book);
   }

   cancelappointments(intern :any):Observable<any>
   {
    return this.httpClient.delete("https://localhost:7232/api/Appointments/"+intern);
   }

   getMyAppointments(intern :any):Observable<any>
   {
    return this.httpClient.get("https://localhost:7232/api/Appointments/doctorname"+intern);

   }
}