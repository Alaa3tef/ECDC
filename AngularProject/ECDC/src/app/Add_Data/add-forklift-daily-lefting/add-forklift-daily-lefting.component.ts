import { Component } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AddDataService } from 'Services/add-data.service';
import { DataService } from 'Services/data.service';
import { LoginService } from 'Services/login.service';

@Component({
  selector: 'app-add-forklift-daily-lefting',
  templateUrl: './add-forklift-daily-lefting.component.html',
  styleUrls: ['./add-forklift-daily-lefting.component.scss']
})
export class AddForkliftDailyLeftingComponent {
  ForkliftDailyReport!: FormGroup;
  ErrorMessage = '';
  // json_data: any[] = [];
  UserJsonString:any
  UserJsonObj:any
  constructor(private dataService:DataService,private loginService:LoginService,
    private addDataService:AddDataService,private fb: FormBuilder, private router: Router) {

  }

  ngOnInit() {
    this.ForkliftDailyReport = this.fb.group(
      {
        id: this.fb.control(
          0,
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
    ),
    this.UserJsonString=JSON.stringify(this.loginService.currentUser.getValue())
    this.UserJsonObj=JSON.parse(this.UserJsonString);
  }

  get id() {
    return this.ForkliftDailyReport.get('id');
  }
  get forkName() {
    return this.ForkliftDailyReport.get('forkName');
  }
  get forkDateofNextInspection() {
    return this.ForkliftDailyReport.get('forkDateofNextInspection');
  }
  get forkDateofLastInspection() {
    return this.ForkliftDailyReport.get('forkDateofLastInspection');
  }
  get forkCapacity() {
    return this.ForkliftDailyReport.get('forkCapacity');
  }
  get forkChasisNo() {
    return this.ForkliftDailyReport.get('forkChasisNo');
  }
  get forkType() {
    return this.ForkliftDailyReport.get('forkType');
  }

  submitData() {
    console.log("here>>>>>>>>>")
    console.log(this.ForkliftDailyReport.value)
    if (this.ForkliftDailyReport.valid) {
      this.addDataService.AddForkliftDailyReport(this.ForkliftDailyReport.value).subscribe({
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
      console.log(this.ForkliftDailyReport);
    }
  }
}
