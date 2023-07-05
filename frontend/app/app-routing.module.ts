import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RegisterComponent } from './register/register.component';
import { LoginComponent } from './login/login.component';
import { AdminComponent } from './admin/admin.component';
import { HomeComponent } from './home/home.component';
import { StaffComponent } from './staff/staff.component';
import { UpdateComponent } from './update/update.component';
import { HealthComponent } from './health/health.component';
import { BenifitsComponent } from './benifits/benifits.component';
import { HospitalComponent } from './hospital/hospital.component';
import { CardioComponent } from './cardio/cardio.component';
import { OrthoComponent } from './ortho/ortho.component';
import { SpineComponent } from './spine/spine.component';
import { AuthGuard } from './authguard';

const routes: Routes = [
  {path:'',component:HospitalComponent},
  {path:'register',component:RegisterComponent},
  {path:'logIN',component:LoginComponent},
  {path:'admin',component:AdminComponent, canActivate: [AuthGuard], data:{roles:['admin']}},
  {path:'home',component:HomeComponent,  canActivate: [AuthGuard], data:{roles:['user']}},
  {path:'staff',component:StaffComponent,  canActivate: [AuthGuard], data:{roles:['doctor']}},
  {path:'update',component:UpdateComponent,  canActivate: [AuthGuard], data:{roles:['user']}},
  {path:'health',component:HealthComponent},
  {path:'benifits',component:BenifitsComponent},
  {path:'cardio',component:CardioComponent},
  {path:'ortho',component:OrthoComponent},
  {path:'spine',component:SpineComponent}
  
  

 // redirectTo:'logIN',pathMatch:'full'


];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
