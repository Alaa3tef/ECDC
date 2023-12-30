import { Component } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router, ParamMap } from '@angular/router';
import { EditDataService } from 'Services/edit-data.service';
import { LoginService } from 'Services/login.service';
import { IStandard } from 'SharedClasses/IStandard';

@Component({
  selector: 'app-edit-standard',
  templateUrl: './edit-standard.component.html',
  styleUrls: ['./edit-standard.component.scss']
})
export class EditStandardComponent {
  StandardId:any;
  Standard!:IStandard;
  StandardForm!: FormGroup;
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
      this.StandardId = params.get("id");
      console.log(this.StandardId)
    }),
    this.editDataService.GetStandardById(this.StandardId).subscribe({
      next: data => {
        this.Standard = data.data,
        console.log('*************************************************************')
        console.log(this.Standard)
        console.log('###################################################')
      },
      error: (erorr: string) => this.ErrorMessage = erorr
    }),
    this.UserJsonString=JSON.stringify(this.loginService.currentUser.getValue())
    this.UserJsonObj=JSON.parse(this.UserJsonString);
    this.StandardForm = this.fb.group(
      {
        id: this.fb.control(
          this.StandardId,
          [
            Validators.required
          ]
        ),
        standardName: this.fb.control(
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
    return this.StandardForm.get('id');
  }
  get standardName() {
    return this.StandardForm.get('standardName');
  }

  submitData() {
    if (this.StandardForm.valid) {
      this.editDataService.EditStandard(this.StandardForm.value).subscribe({
        next: data => {
          console.log(this.StandardForm.value)
          console.log('from service')
          console.log(data)
          this.router.navigate(['Dashboard/Standard']);
        },
        error: error => {
          console.log("from Error")
          console.log(error)
        }
      });
    }
    else {
      console.log("E+++++====error in : ");
      console.log(this.StandardForm);
    }
  }


}
