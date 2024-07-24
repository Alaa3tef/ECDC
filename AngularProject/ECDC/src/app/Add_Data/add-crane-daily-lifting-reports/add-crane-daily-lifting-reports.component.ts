import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AddDataService } from 'Services/add-data.service';
import { DataService } from 'Services/data.service';
import { LoginService } from 'Services/login.service';

@Component({
  selector: 'app-add-crane-daily-lifting-reports',
  templateUrl: './add-crane-daily-lifting-reports.component.html',
  styleUrls: ['./add-crane-daily-lifting-reports.component.scss']
})
export class AddCraneDailyLiftingReportsComponent {
  craneDailyReport!: FormGroup;
  ErrorMessage = '';
  // json_data: any[] = [];
  UserJsonString:any
  UserJsonObj:any
  constructor(private dataService:DataService,private loginService:LoginService,
    private addDataService:AddDataService,private fb: FormBuilder, private router: Router) {

  }

  ngOnInit() {
    this.craneDailyReport = this.fb.group(
      {
        id: this.fb.control(
          0,
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
    ),
    this.UserJsonString=JSON.stringify(this.loginService.currentUser.getValue())
    this.UserJsonObj=JSON.parse(this.UserJsonString);
  }

  get id() {
    return this.craneDailyReport.get('id');
  }
  get mobileCraneName() {
    return this.craneDailyReport.get('mobileCraneName');
  }
  get dateofNextInspection() {
    return this.craneDailyReport.get('dateofNextInspection');
  }
  get dateofLastInspection() {
    return this.craneDailyReport.get('dateofLastInspection');
  }
  get capacity() {
    return this.craneDailyReport.get('capacity');
  }
  get chasisNo() {
    return this.craneDailyReport.get('chasisNo');
  }
  get type() {
    return this.craneDailyReport.get('type');
  }

  submitData() {
    console.log("here>>>>>>>>>")
    console.log(this.craneDailyReport.value)
    if (this.craneDailyReport.valid) {
      this.addDataService.AddCraneDailyReport(this.craneDailyReport.value).subscribe({
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
      console.log(this.craneDailyReport);
    }
  }
}
