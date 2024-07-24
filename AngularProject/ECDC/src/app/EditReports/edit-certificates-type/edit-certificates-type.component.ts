import { Component } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router, ParamMap } from '@angular/router';
import { EditDataService } from 'Services/edit-data.service';
import { LoginService } from 'Services/login.service';
import { ICertificatesType } from 'SharedClasses/ICertificatesType';

@Component({
  selector: 'app-edit-certificates-type',
  templateUrl: './edit-certificates-type.component.html',
  styleUrls: ['./edit-certificates-type.component.scss']
})
export class EditCertificatesTypeComponent {
  certificatesTypeId: any;
  certificatesType!: ICertificatesType;
  certificatesTypeForm!: FormGroup;
  ErrorMessage = '';
  // json_data: any[] = [];
  UserJsonString: any
  UserJsonObj: any

  constructor(
    private activatedRoute: ActivatedRoute,
    private loginService: LoginService,
    private editDataService: EditDataService,
    private fb: FormBuilder,
    private router: Router) {
  }

  ngOnInit() {
    this.activatedRoute.paramMap.subscribe((params: ParamMap) => {
      this.certificatesTypeId = params.get("id");
      console.log(this.certificatesTypeId)
    }),
      this.editDataService.GetCertificatesTypeById(this.certificatesTypeId).subscribe({
        next: data => {
          this.certificatesType = data.data,
            console.log('*************************************************************')
          console.log(this.certificatesType)
          console.log('###################################################')
        },
        error: (erorr: string) => this.ErrorMessage = erorr
      }),
      this.UserJsonString = JSON.stringify(this.loginService.currentUser.getValue())
    this.UserJsonObj = JSON.parse(this.UserJsonString);
    this.certificatesTypeForm = this.fb.group(
      {
        id: this.fb.control(
          this.certificatesTypeId,
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
    )
  }

  get id() {
    return this.certificatesTypeForm.get('id');
  }
  get type() {
    return this.certificatesTypeForm.get('type');
  }

  submitData() {
    if (this.certificatesTypeForm.valid) {
      this.editDataService.EditCertificatesType(this.certificatesTypeForm.value).subscribe({
        next: data => {
          console.log('from service')
          console.log(data)
          this.router.navigate(['Dashboard/CertificatesType']);
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
