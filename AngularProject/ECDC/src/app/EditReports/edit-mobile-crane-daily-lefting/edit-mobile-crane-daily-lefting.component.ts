import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router, ParamMap } from '@angular/router';
import { DataService } from 'Services/data.service';
import { EditDataService } from 'Services/edit-data.service';
import { LoginService } from 'Services/login.service';
import { ICraneDailyLifting } from 'SharedClasses/ICraneDailyLifting';
import { IRig } from 'SharedClasses/IRig';

@Component({
  selector: 'app-edit-mobile-crane-daily-lefting',
  templateUrl: './edit-mobile-crane-daily-lefting.component.html',
  styleUrls: ['./edit-mobile-crane-daily-lefting.component.scss']
})
export class EditMobileCraneDailyLeftingComponent {
  CraneDailyLiftingId:any;
  CraneDailyLifting!:ICraneDailyLifting;
  CraneDailyLiftingForm!: FormGroup;
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
      this.CraneDailyLiftingId = params.get("id");
      console.log(this.CraneDailyLiftingId)
    }),
    this.dataService.GetCraneDailyLiftingByID(this.CraneDailyLiftingId).subscribe({
      next: data => {
        this.CraneDailyLifting = data.data,
        console.log('*************************************************************')
        console.log(this.CraneDailyLifting)
        console.log('###################################################')
      },
      error: (erorr: string) => this.ErrorMessage = erorr
    }),
    this.UserJsonString=JSON.stringify(this.loginService.currentUser.getValue())
    this.UserJsonObj=JSON.parse(this.UserJsonString);
 
 
    this.CraneDailyLiftingForm = this.fb.group(
      {
        id: this.fb.control(
          this.CraneDailyLiftingId,
          [
            Validators.required
          ]
        ),
        dateofNextInspection: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        dateofLastInspection: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        capacity: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        chasisNo: this.fb.control(
          '',
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
        mobileCraneName: this.fb.control(
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
    return this.CraneDailyLiftingForm.get('id');
  }
  get mobileCraneName() {
    return this.CraneDailyLiftingForm.get('mobileCraneName');
  }
  get dateofNextInspection() {
    return this.CraneDailyLiftingForm.get('dateofNextInspection');
  }
  get dateofLastInspection() {
    return this.CraneDailyLiftingForm.get('dateofLastInspection');
  }
  get capacity() {
    return this.CraneDailyLiftingForm.get('capacity');
  }
  get chasisNo() {
    return this.CraneDailyLiftingForm.get('chasisNo');
  }
  get type() {
    return this.CraneDailyLiftingForm.get('type');
  }

  submitData() {
    if (this.CraneDailyLiftingForm.valid) {
      this.editDataService.EditCraneDailyLifting( this.CraneDailyLiftingId,this.CraneDailyLiftingForm.value).subscribe({
        next: data => {
          console.log('from service')
          console.log(data)
          this.router.navigate(['Dashboard/CraneDailyReports']);
        },
        error: error => {
          console.log("from Error")
          console.log(error)
        }
      });
    }
    else {
      console.log("E+++++====error in : ");
      console.log(this.CraneDailyLiftingForm);
    }
  }
}
