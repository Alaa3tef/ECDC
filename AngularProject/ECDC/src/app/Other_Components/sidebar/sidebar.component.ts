import { Component, EventEmitter, HostListener, Input, Output } from '@angular/core';
import { Router } from '@angular/router';
import { LoginService } from 'Services/login.service';

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.scss']
})
export class SidebarComponent {
  IsLoging: boolean = false;
  UserName: any;
  UserId: any;
  UserRole!: string;
  IsUser:boolean=false;
  IsRadio:boolean=false;
  IsAdmin:boolean=false;
  @Input() isOpen: boolean = true;
  @Output() itemSelected = new EventEmitter<void>();
  isCollapsed = false;
  constructor(private loginService: LoginService, private router: Router) {

  }

  ngOnInit(): void {
    //Called after the constructor, initializing input properties, and the first call to ngOnChanges.
    //Add 'implements OnInit' to the class.

    this.loginService.sharedIsLogin.subscribe({
      next:data =>this.IsLoging=data
    })
    this.loginService.isAdmin.subscribe({
      next:data =>this.IsAdmin=data
    })

    this.loginService.currentUser.subscribe({
      next: (data: any) => {
        console.log("-------------------------------------+");
        console.log(data);
        this.UserRole = data.Role;
        if (data.Role.length > 2) {
          this.IsLoging = true;
        }
        if( this.UserRole=="Admin")
        {
          this.IsAdmin=true;
        }
        else if(this.UserRole=="Radio")
        {
          this.IsRadio=true;
        }
        else if(this.UserRole=="User")
        {
          this.IsUser=true;
        }
        this.UserId = data.ID;
        this.UserName = data.Name;

        console.log("user 3333333333333333333" + this.UserId);
        console.log("user 33333333333333333" + this.UserName);
        console.log("user id3333333333333333e" + this.UserRole);
      }
    })
    this.checkScreenSize()
  }

  SignOut() {

    // this.loginService.currentUser.next(null);
    // localStorage.removeItem('UserToken');
    // this.router.navigate(['/Login'])
    // console.log("SignOut Done")
    // this.IsLoging = false;

    this.loginService.SignOut();
    this.IsAdmin=false;
    this.IsRadio=false;
    this.IsUser=false;
  }

  toggleSidebar() {
    if (window.innerWidth <= 768) {
      this.isOpen = !this.isOpen;
    } else {
      this.isCollapsed = !this.isCollapsed;
    }
  }

  @HostListener('window:resize', ['$event'])
  onResize(event: Event) {
    this.checkScreenSize();
  }

  checkScreenSize() {
    if (window.innerWidth <= 768) {
      this.isOpen = false;
      this.isCollapsed = false;
    } else {
      this.isOpen = true;
      this.isCollapsed = false;
    }
  }

  onItemSelect() {
    this.itemSelected.emit();
  }
}
