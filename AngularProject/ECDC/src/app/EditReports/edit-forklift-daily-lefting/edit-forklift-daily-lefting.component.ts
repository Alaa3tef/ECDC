import { Component } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router, ParamMap } from '@angular/router';
import { DataService } from 'Services/data.service';
import { EditDataService } from 'Services/edit-data.service';
import { LoginService } from 'Services/login.service';
import { IForkliftDailyLifting } from 'SharedClasses/IForkliftDailyLifting';
import { IRig } from 'SharedClasses/IRig';

@Component({
  selector: 'app-edit-forklift-daily-lefting',
  templateUrl: './edit-forklift-daily-lefting.component.html',
  styleUrls: ['./edit-forklift-daily-lefting.component.scss']
})
export class EditForkliftDailyLeftingComponent {
  ForkliftDailyLiftingId:any;
  ForkliftDailyLifting!:IForkliftDailyLifting;
  ForkliftDailyLiftingForm!: FormGroup;
  ErrorMessage = '';
  // json_data: any[] = [];
  UserJsonString:any
  UserJsonObj:any
  positonIdList:any;
  rigList:IRig[]=[];
  constructor(private dataService:DataService,private activatedRoute:ActivatedRoute,private loginService:LoginService,private editDataService:EditDataService,private fb: FormBuilder, private router: Router) {

  }

  ngOnInit() {
    this.activatedRoute.paramMap.subscribe((params: ParamMap) => {
      this.ForkliftDailyLiftingId = params.get("id");
      console.log(this.ForkliftDailyLiftingId)
    }),
    this.dataService.GetForkliftDailyLiftingByID(this.ForkliftDailyLiftingId).subscribe({
      next: data => {
        this.ForkliftDailyLifting = data.data,
        console.log('*************************************************************')
        console.log(this.ForkliftDailyLifting)
        console.log('###################################################')
      },
      error: (erorr: string) => this.ErrorMessage = erorr
    }),
    this.UserJsonString=JSON.stringify(this.loginService.currentUser.getValue())
    this.UserJsonObj=JSON.parse(this.UserJsonString);
 
 
    this.ForkliftDailyLiftingForm = this.fb.group(
      {
        id: this.fb.control(
          this.ForkliftDailyLiftingId,
          [
            Validators.required
          ]
        ),
        forkDateofNextInspection: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        forkDateofLastInspection: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        forkCapacity: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        forkChasisNo: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        forkType: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        forkName: this.fb.control(
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
    return this.ForkliftDailyLiftingForm.get('id');
  }
  get forkName() {
    return this.ForkliftDailyLiftingForm.get('forkName');
  }
  get forkDateofNextInspection() {
    return this.ForkliftDailyLiftingForm.get('forkDateofNextInspection');
  }
  get forkDateofLastInspection() {
    return this.ForkliftDailyLiftingForm.get('forkDateofLastInspection');
  }
  get forkCapacity() {
    return this.ForkliftDailyLiftingForm.get('forkCapacity');
  }
  get forkChasisNo() {
    return this.ForkliftDailyLiftingForm.get('forkChasisNo');
  }
  get forkType() {
    return this.ForkliftDailyLiftingForm.get('forkType');
  }

  submitData() {
    if (this.ForkliftDailyLiftingForm.valid) {
      this.editDataService.EditForkliftDailyLifting( this.ForkliftDailyLiftingId,this.ForkliftDailyLiftingForm.value).subscribe({
        next: data => {
          console.log('from service')
          console.log(data)
          this.router.navigate(['Dashboard/ForkliftDailyReports']);
        },
        error: error => {
          console.log("from Error")
          console.log(error)
        }
      });
    }
    else {
      console.log("E+++++====error in : ");
      console.log(this.ForkliftDailyLiftingForm);
    }
  }
}
