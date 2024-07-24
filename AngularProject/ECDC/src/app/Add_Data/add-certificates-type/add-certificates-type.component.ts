import { Component } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AddDataService } from 'Services/add-data.service';
import { LoginService } from 'Services/login.service';

@Component({
  selector: 'app-add-certificates-type',
  templateUrl: './add-certificates-type.component.html',
  styleUrls: ['./add-certificates-type.component.scss']
})
export class AddCertificatesTypeComponent {
  certificatesTypeForm!: FormGroup;
  ErrorMessage = '';
  // json_data: any[] = [];
  UserJsonString:any
  UserJsonObj:any

  constructor(
    private loginService:LoginService,
    private addDataService:AddDataService,
    private fb: FormBuilder,
    private router: Router) {

  }

  ngOnInit() {
    this.certificatesTypeForm = this.fb.group(
      {
        id: this.fb.control(
          0,
          [
            Validators.required
          ]
        ),
        type: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        isDeleted: this.fb.control(
          false,
          [
            Validators.required
          ]
        )
      }
    ),
    this.UserJsonString=JSON.stringify(this.loginService.currentUser.getValue())
    this.UserJsonObj=JSON.parse(this.UserJsonString);
  }

  get id() {
    return this.certificatesTypeForm.get('id');
  }
  get type() {
    return this.certificatesTypeForm.get('type');
  }

  submitData() {
    if (this.certificatesTypeForm.valid) {
      this.addDataService.AddCertificatesType(this.certificatesTypeForm.value).subscribe({
        next: data => {
          console.log('from service')
          console.log(data)
          location.reload();
        },
        error: error => {
          console.log("from Error")
          console.log(error)
        }
      });
    }
    else {
      console.log("E+++++====error in : ");
      console.log(this.certificatesTypeForm);
    }
  }
}
