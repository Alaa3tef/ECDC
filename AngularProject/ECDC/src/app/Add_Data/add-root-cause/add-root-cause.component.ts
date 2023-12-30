import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AddDataService } from 'Services/add-data.service';
import { LoginService } from 'Services/login.service';

@Component({
  selector: 'app-add-root-cause',
  templateUrl: './add-root-cause.component.html',
  styleUrls: ['./add-root-cause.component.scss']
})
export class AddRootCauseComponent {
  RootCauseForm!: FormGroup;
  ErrorMessage = '';
  // // json_data: any[] = [];
  UserJsonString:any
  UserJsonObj:any

  constructor(private loginService: LoginService,
    private addDataService: AddDataService,
    private fb: FormBuilder,
    private router: Router) { }

  ngOnInit() {
    this.RootCauseForm = this.fb.group(
      {
        id: this.fb.control(
          0,
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
    ),
    this.UserJsonString=JSON.stringify(this.loginService.currentUser.getValue())
    this.UserJsonObj=JSON.parse(this.UserJsonString);
  }

  get id() {
    return this.RootCauseForm.get('id');
  }
  get causeName() {
    return this.RootCauseForm.get('causeName');
  }

  submitData() {
      if (this.RootCauseForm.valid) {
        this.addDataService.AddRootCause(this.RootCauseForm.value).subscribe({
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
        console.log(this.RootCauseForm);
      }
  }


  // Download() {
  //   let workbook = new Workbook();

  //   let worksheet = workbook.addWorksheet("Employee Data");

  //   let header = [
  //     "Id",
  //     "Rig",
  //     "Time Of Event",
  //     "Date Of Event",
  //     "Type Of Injury",
  //     "Violation Category",
  //     "Accident Causes",
  //     "Prevention Category",
  //     "Classification Of Accident",
  //     "Accident Location",
  //     "QHSE Name",
  //     "Tool Pusher Name",
  //     "Tool Pusher Position",
  //     "QHSE Position",
  //     "Driller Name",
  //     "Description Of TheEvent",
  //     "Immediate Action Type",
  //     "Direct Causes",
  //     "Root Causes",
  //     "Recommendations",
  //     "User Name",
  //     "Pictures"
  //   ];

  //   // this.json_data.push(this.accidentForm.value)

  //   let headerRow = worksheet.addRow(header);

  //   for (let x1 of this.json_data) {
  //     let x2 = Object.keys(x1);
  //     let temp: any[] = []
  //     for (let y of x2) {
  //       temp.push(x1[y])
  //     }
  //     worksheet.addRow(temp)
  //   }

  //   let fname = "Accident Report"

  //   //add data and file name and download
  //   workbook.xlsx.writeBuffer().then((data) => {
  //     let blob = new Blob([data], { type: 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet' });
  //     saveAs.saveAs(blob, fname + '-' + new Date().toUTCString() + '.xlsx');
  //   });
  // }


}

