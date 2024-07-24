import { Component } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router, ParamMap } from '@angular/router';
import { EditDataService } from 'Services/edit-data.service';
import { LoginService } from 'Services/login.service';
import { ICorrectiveObservation } from 'SharedClasses/ICorrectiveObservation';

@Component({
  selector: 'app-edit-corrective-observation',
  templateUrl: './edit-corrective-observation.component.html',
  styleUrls: ['./edit-corrective-observation.component.scss']
})
export class EditCorrectiveObservationComponent {
  CorrectiveObservationId:any;
  CorrectiveObservation!:ICorrectiveObservation;
  CorrectiveObservationForm!: FormGroup;
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
      this.CorrectiveObservationId = params.get("id");
      console.log(this.CorrectiveObservationId)
    }),
    this.editDataService.GetCorrectiveObservationById(this.CorrectiveObservationId).subscribe({
      next: data => {
        this.CorrectiveObservation = data.data,
        console.log('*************************************************************')
        console.log(this.CorrectiveObservation)
        console.log('###################################################')
      },
      error: (erorr: string) => this.ErrorMessage = erorr
    }),
    this.UserJsonString=JSON.stringify(this.loginService.currentUser.getValue())
    this.UserJsonObj=JSON.parse(this.UserJsonString);
    this.CorrectiveObservationForm = this.fb.group(
      {
        id: this.fb.control(
          this.CorrectiveObservationId,
          [
            Validators.required
          ]
        ),
        observation: this.fb.control(
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
    return this.CorrectiveObservationForm.get('id');
  }
  get observation() {
    return this.CorrectiveObservationForm.get('observation');
  }

  submitData() {
    if (this.CorrectiveObservationForm.valid) {
      this.editDataService.EditCorrectiveObservation(this.CorrectiveObservationForm.value).subscribe({
        next: data => {
          console.log(this.CorrectiveObservationForm.value)
          console.log('from service')
          console.log(data)
          this.router.navigate(['Dashboard/CorrectiveObservation']);
        },
        error: error => {
          console.log("from Error")
          console.log(error)
        }
      });
    }
    else {
      console.log("E+++++====error in : ");
      console.log(this.CorrectiveObservationForm);
    }
  }


}
