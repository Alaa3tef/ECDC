import { Component } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router, ParamMap } from '@angular/router';
import { EditDataService } from 'Services/edit-data.service';
import { LoginService } from 'Services/login.service';
import { ICorrectiveResponsability } from 'SharedClasses/ICorrectiveResponsability';

@Component({
  selector: 'app-edit-corrective-responsability',
  templateUrl: './edit-corrective-responsability.component.html',
  styleUrls: ['./edit-corrective-responsability.component.scss']
})
export class EditCorrectiveResponsabilityComponent {
  CorrectiveResponsabilityId:any;
  CorrectiveResponsability!:ICorrectiveResponsability;
  CorrectiveResponsabilityForm!: FormGroup;
  ErrorMessage = '';
  // json_data: any[] = [];
  UserJsonString:any
  UserJsonObj:any

  constructor(private activatedRoute:ActivatedRoute,
    private loginService:LoginService,
    private editDataService:EditDataService,
    private fb: FormBuilder,
    private router: Router) { }

  ngOnInit() {
    this.activatedRoute.paramMap.subscribe((params: ParamMap) => {
      this.CorrectiveResponsabilityId = params.get("id");
      console.log(this.CorrectiveResponsabilityId)
    }),
    this.editDataService.GetCorrectiveResponsabilityById(this.CorrectiveResponsabilityId).subscribe({
      next: data => {
        this.CorrectiveResponsability = data.data,
        console.log('*************************************************************')
        console.log(this.CorrectiveResponsability)
        console.log('###################################################')
      },
      error: (erorr: string) => this.ErrorMessage = erorr
    }),
    this.UserJsonString=JSON.stringify(this.loginService.currentUser.getValue())
    this.UserJsonObj=JSON.parse(this.UserJsonString);
    this.CorrectiveResponsabilityForm = this.fb.group(
      {
        id: this.fb.control(
          this.CorrectiveResponsabilityId,
          [
            Validators.required
          ]
        ),
        responsibilityName: this.fb.control(
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
    return this.CorrectiveResponsabilityForm.get('id');
  }
  get responsibilityName() {
    return this.CorrectiveResponsabilityForm.get('responsibilityName');
  }

  submitData() {
    if (this.CorrectiveResponsabilityForm.valid) {
      this.editDataService.EditCorrectiveResponsability(this.CorrectiveResponsabilityForm.value).subscribe({
        next: data => {
          console.log(this.CorrectiveResponsabilityForm.value)
          console.log('from service')
          console.log(data)
          this.router.navigate(['Dashboard/CorrectiveResponsability']);
        },
        error: error => {
          console.log("from Error")
          console.log(error)
        }
      });
    }
    else {
      console.log("E+++++====error in : ");
      console.log(this.CorrectiveResponsabilityForm);
    }
  }
}
