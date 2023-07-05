import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
// import { AuthService } from './authservice';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  constructor(private router: Router) { }

  private isAllowed(): boolean {
    const token = localStorage.getItem('token');
    const role = localStorage.getItem('role');
    return !!(token && (role === 'admin' || role === 'doctor' || role === 'user'));
  }

  

  canActivateDoctor(): boolean {
    if (this.isAllowed() && localStorage.getItem('role') === 'doctor') {
      return true;
    } else {
      if(confirm('Authenticated users only allowed!!!'))
      {
       this.router.navigate(['/logIN']);
      }      return false;
    }
  }

  canActivateAdmin(): boolean {
    if (this.isAllowed() && localStorage.getItem('role') === 'admin') {
      return true;
    } else {
      if(confirm('Authenticated users only allowed!!!'))
     {
      this.router.navigate(['/logIN']);
     }
      return false;
    }
  }

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean | UrlTree {
    const allowedRoles = route.data['roles'] as string[];
    const userRole = localStorage.getItem('role');

    if (this.isAllowed() && userRole !== null && allowedRoles.includes(userRole)) {
      return true;
    } else {
      alert('Restricted Access');
      return this.router.createUrlTree(['/']);
    }
  }
  
}