import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { LoginService } from 'Services/login.service';
import { ToastrService } from 'ngx-toastr';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AllEditGuard implements CanActivate {
  User: any = this._LoginService.currentUser.getValue();
  constructor(private _LoginService: LoginService, private router: Router, private toastr: ToastrService) { }

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
    // Allow the admin to edit the report at any time
    if ((this.User != null) && ((this.User.Role == "Admin")||(this.User.Role == "Radio"))) {
      return true;
    }
    // Allow the user to edit the report only within two days from its date
    else if ((this.User != null) && ((this.User.Role == "User"))) {
      // Get the date of the report to be edited from the route parameters
      const reportDate = new Date(route.params['reportDate']); // Adjust this based on how you pass report date in the route

      // Calculate the difference in days between the report date and the current date
      const today = new Date();
      const differenceInDays = Math.floor((today.getTime() - reportDate.getTime()) / (1000 * 60 * 60 * 24));

      // Check if the user is trying to edit the report within two days from its date
      if (differenceInDays <= 2) {
        console.log("User is allowed to edit the report within two days from its date.");
        return true;
      } else {
        console.log("User is not allowed to edit the report as it's more than two days old.");
        // Redirect user to some page indicating they can't edit the report
        this.toastr.error(`User is not allowed to edit the report as it's more than two days old.`);
        return false;
      }
    } else {
      // User is not logged in or doesn't have permissions
      this.router.navigate(['/Login']);
      return false;
    }
  }

}
