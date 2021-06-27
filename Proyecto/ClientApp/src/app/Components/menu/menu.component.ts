import { Component, OnInit } from '@angular/core';

import { Router } from '@angular/router';
import { AlertModalComponent } from 'src/app/@base/alert-modal/alert-modal.component';
import { Usuario } from 'src/app/models/usuario';
import { User } from 'src/app/seguridad/user';
import { AuthenticationService } from 'src/app/services/authentication.service';



@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.css']
})
export class MenuComponent implements OnInit {

  currentUser:User;
  modalService: any;
  constructor(private authenticationService:AuthenticationService,private router:Router)
  {
    this.authenticationService.currentUser.subscribe(x=> this.currentUser = x);
  }

  user:User;
  nombre:string;
  ngOnInit() {
    this.user = new User();
    this.user =  this.authenticationService.currentUserValue;
  }

  logout(){
    this.authenticationService.logout();
    
    this.router.navigate(['/loginComponent']);
  }

}
