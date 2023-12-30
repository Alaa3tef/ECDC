import { Component } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router, ParamMap } from '@angular/router';
import { EditDataService } from 'Services/edit-data.service';
import { LoginService } from 'Services/login.service';
import { IRootCause } from 'SharedClasses/IRootCause';

@Component({
  selector: 'app-edit-root-cause',
  templateUrl: './edit-root-cause.component.html',
  styleUrls: ['./edit-root-cause.component.scss']
})
export class EditRootCauseComponent {
  RootCauseId:any;
  RootCause!:IRootCause;
  RootCauseForm!: FormGroup;
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
      this.RootCauseId = params.get("id");
      console.log(this.RootCauseId)
    }),
    this.editDataService.GetRootCauseById(this.RootCauseId).subscribe({
      next: data => {
        this.RootCause = data.data,
        console.log('*************************************************************')
        console.log(this.RootCause)
        console.log('###################################################')
      },
      error: (erorr: string) => this.ErrorMessage = erorr
    }),
    this.UserJsonString=JSON.stringify(this.loginService.currentUser.getValue())
    this.UserJsonObj=JSON.parse(this.UserJsonString);
    this.RootCauseForm = this.fb.group(
      {
        id: this.fb.control(
          this.RootCauseId,
          [
            Validators.required
          ]
        ),
        causeName: this.fb.control(
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
    return this.RootCauseForm.get('id');
  }
  get causeName() {
    return this.RootCauseForm.get('causeName');
  }

  submitData() {
    if (this.RootCauseForm.valid) {
      this.editDataService.EditRootCause(this.RootCauseForm.value).subscribe({
        next: data => {
          console.log(this.RootCauseForm.value)
          console.log('from service')
          console.log(data)
          this.router.navigate(['Dashboard/RootCause']);
        },
        error: error => {
          console.log("from Error")
          console.log(error)
        }
      });
    }
    else {
      console.log("E+++++====error in : ");
      console.log(this.RootCauseForm);
    }
  }

}
