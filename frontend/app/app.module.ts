import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { HttpClientModule } from '@angular/common/http'
import { UserInternService } from './Services/user-intern.service';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AdminComponent } from './admin/admin.component';
import { HomeComponent } from './home/home.component';
import { StaffComponent } from './staff/staff.component';
import { StafflistComponent } from './stafflist/stafflist.component';
import { UpdateComponent } from './update/update.component';
import { ServicesComponent } from './Services/services.component';
import { HealthComponent } from './health/health.component';
import { BenifitsComponent } from './benifits/benifits.component';
import { HospitalComponent } from './hospital/hospital.component';
import { CardioComponent } from './cardio/cardio.component';
import { OrthoComponent } from './ortho/ortho.component';
import { SpineComponent } from './spine/spine.component';
// import { AuthService } from './authservice';


@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    RegisterComponent,
    AdminComponent,
    HomeComponent,
    StaffComponent,
    StafflistComponent,
    UpdateComponent,
    ServicesComponent,
    HealthComponent,
    BenifitsComponent,
    HospitalComponent,
    CardioComponent,
    OrthoComponent,
    SpineComponent,

  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule
    
  ],
  providers: [
    UserInternService
  ],
  bootstrap: [AppComponent]

})
export class AppModule { }
