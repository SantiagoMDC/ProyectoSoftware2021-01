import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { first } from 'rxjs/operators';
import { AlertModalComponent } from '../@base/alert-modal/alert-modal.component';
import { MenuComponent } from '../Components/menu/menu.component';
import { AuthenticationService } from '../services/authentication.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  currentItem : string;
  loginForm:FormGroup;
  loading=false;
  submitted=false;
  returnUrl:string;
  content:MenuComponent;
  constructor(private formBuilder:FormBuilder,
              private route:ActivatedRoute,
              private router:Router,
              private authenticationService:AuthenticationService,
              private modalService:NgbModal) {
                if(this.authenticationService.currentUserValue){
                  this.router.navigate(['/']);
                }
               }

  ngOnInit() {
    this.loginForm = this.formBuilder.group({
      userName:['',Validators.required],
      password:['',Validators.required]
      
    });

    this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
  }

  get f(){
    return this.loginForm.controls;
  }

  onSubmit(){
    this.submitted = true;
    if (this.loginForm.invalid) {
      return ;
    }
    this.loading = true;
    this.authenticationService.login(this.f.userName.value,this.f.password.value).pipe(first()).subscribe(
      data => {
        
        const modalRef = this.modalService.open(AlertModalComponent);
        modalRef.componentInstance.title = 'Acceso Concedido';
        modalRef.componentInstance.message = 'Welcome...';

          this.router.navigate(['/homeComponent']);
        
      },
      error => {
        const modalRef = this.modalService.open(AlertModalComponent);
        modalRef.componentInstance.title = 'Acceso Denegado';
        modalRef.componentInstance.message = error.error;
        this.loading = false;       
      }
    )
  }
}
