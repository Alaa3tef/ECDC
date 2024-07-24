import { DatePipe } from '@angular/common';
import { Component } from '@angular/core';
import { FormArray, FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AddDataService } from 'Services/add-data.service';
import { DataService } from 'Services/data.service';
import { LoginService } from 'Services/login.service';
import { WeeklyClinicService } from 'Services/weekly-clinic.service';
import { IRig } from 'SharedClasses/IRig';
import { Workbook } from 'exceljs';
import * as saveAs from 'file-saver';

@Component({
  selector: 'app-add-weekly-clinic',
  templateUrl: './add-weekly-clinic.component.html',
  styleUrls: ['./add-weekly-clinic.component.scss']
})
export class AddWeeklyClinicComponent {
  WeeklyClinicForm!: FormGroup;
  ErrorMessage = '';
  json_data: any[] = [];
  time = new Date();
  rigList: IRig[] = [];
  SelectFiles: File[] = []
  UserJsonString: any;
  Record: any = {};
  UserJsonObj: any
  User: any;
  submitted: boolean = false;
  textVisible1: boolean = false;
  textVisible2: boolean = false;
  testUser: any;

  constructor(private datePipe: DatePipe,
    private loginService: LoginService,
    private dataService: DataService,
    private fb: FormBuilder,
    private router: Router,
    private addDataService: AddDataService,
    private AddService: WeeklyClinicService) { }

  ngOnInit() {
    this.testUser = this.loginService.currentUser.getValue();
    console.log("////*********/////////")
    console.log(this.testUser)
    this.dataService.GetRig().subscribe({
      next: data => {
        this.rigList = data.data;
        console.log('rrrrrrrrrrrriiiiiiiiiiiiiiiiiiggggggggggg')
        console.log(this.rigList)
      },
      error: err => this.ErrorMessage = err
    });

    this.User = JSON.stringify(this.loginService.currentUser.getValue())//this.loginService.currentUser.getValue();
    console.log("uuuuuuussssssseeeeerrrrbbbbbvvvcc")



    this.AddService.GetWeeklyClinicForExcel(this.testUser.ID, this.testUser.Role).subscribe({
      next: data => this.json_data = data.data,
      error: err => this.ErrorMessage = err
    });

    this.UserJsonString = JSON.stringify(this.loginService.currentUser.getValue())
    this.UserJsonObj = JSON.parse(this.UserJsonString);

    this.WeeklyClinicForm = this.fb.group(
      {
        id: this.fb.control(
          0,
          [
            Validators.required
          ]
        ),
        rigId: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        date: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        weeklyClinicNo: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        medicalReportNo: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        lastFirstAidDrillNo: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        healthMeetingNo: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        topics: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        healthStatus: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        healthStatusComment: this.fb.control(
          null,
          [
            // Validators.required
          ]
        ),
        lifeSavingApparatuses: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        lifeSavingApparatusesComment: this.fb.control(
          null,
          [
            // Validators.required
          ]
        ),
        vaccinesAvailable: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        vaccinesAvailableComment: this.fb.control(
          null,
          [
            // Validators.required
          ]
        ),
        erp: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        erpComment: this.fb.control(
          null,
          [
            // Validators.required
          ]
        ),
        medicalStretcher: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        medicalStretcherComment: this.fb.control(
          null,
          [
            // Validators.required
          ]
        ),
        waterTest: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        waterTestComment: this.fb.control(
          null,
          [
            // Validators.required
          ]
        ),
        bloodSugar: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        bloodSugarComment: this.fb.control(
          null,
          [
            // Validators.required
          ]
        ),
        firstAidBox: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        firstAidBoxComment: this.fb.control(
          null,
          [
            // Validators.required
          ]
        ),
        fullO2Cylinder: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        fullO2CylinderComment: this.fb.control(
          null,
          [
            // Validators.required
          ]
        ),
        medicalWaste: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        medicalWasteComment: this.fb.control(
          null,
          [
            // Validators.required
          ]
        ),
        medicinesExpiryDate: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        medicinesExpiryDateComment: this.fb.control(
          null,
          [
            // Validators.required
          ]
        ),
        otherComments: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        doctorName: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        qhseEngineer: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        fridgeComponents: this.fb.array(
          [
            this.createFridgeComponentsFormGroup('Snake Vaccine'),
            this.createFridgeComponentsFormGroup('Scorpion Vaccine'),
            this.createFridgeComponentsFormGroup('Tetanus Vaccine'),
            this.createFridgeComponentsFormGroup('Rabies Vaccine')
          ],
          [
            Validators.required
          ]
        ),
        drugInventory: this.fb.array(
          [
            this.createDrugInventoryFormGroup(),
            this.createDrugInventoryFormGroup(),
          ],
          [
            Validators.required
          ]
        ),
        userID: this.fb.control(
          this.UserJsonObj.ID,
          [
            Validators.required
          ]
        )
      }
    );
  }


  get id() {
    return this.WeeklyClinicForm.get('id');
  }
  get rigId() {
    return this.WeeklyClinicForm.get('rigId');
  }
  get date() {
    return this.WeeklyClinicForm.get('date');
  }
  get weeklyClinicNo() {
    return this.WeeklyClinicForm.get('weeklyClinicNo');
  }
  get medicalReportNo() {
    return this.WeeklyClinicForm.get('medicalReportNo');
  }
  get lastFirstAidDrillNo() {
    return this.WeeklyClinicForm.get('lastFirstAidDrillNo');
  }
  get healthMeetingNo() {
    return this.WeeklyClinicForm.get('healthMeetingNo');
  }
  get topics() {
    return this.WeeklyClinicForm.get('topics');
  }
  get healthStatus() {
    return this.WeeklyClinicForm.get('healthStatus');
  }
  get healthStatusComment() {
    return this.WeeklyClinicForm.get('healthStatusComment');
  }
  get lifeSavingApparatuses() {
    return this.WeeklyClinicForm.get('lifeSavingApparatuses');
  }
  get lifeSavingApparatusesComment() {
    return this.WeeklyClinicForm.get('lifeSavingApparatusesComment');
  }
  get vaccinesAvailable() {
    return this.WeeklyClinicForm.get('vaccinesAvailable');
  }
  get erp() {
    return this.WeeklyClinicForm.get('erp');
  }
  get erpComment() {
    return this.WeeklyClinicForm.get('erpComment');
  }
  get medicalStretcher() {
    return this.WeeklyClinicForm.get('medicalStretcher');
  }
  get medicalStretcherComment() {
    return this.WeeklyClinicForm.get('medicalStretcherComment');
  }
  get waterTest() {
    return this.WeeklyClinicForm.get('waterTest');
  }
  get waterTestComment() {
    return this.WeeklyClinicForm.get('waterTestComment');
  }
  get bloodSugar() {
    return this.WeeklyClinicForm.get('bloodSugar');
  }
  get bloodSugarComment() {
    return this.WeeklyClinicForm.get('bloodSugarComment');
  }
  get firstAidBox() {
    return this.WeeklyClinicForm.get('firstAidBox');
  }
  get firstAidBoxComment() {
    return this.WeeklyClinicForm.get('firstAidBoxComment');
  }
  get fullO2Cylinder() {
    return this.WeeklyClinicForm.get('fullO2Cylinder');
  }
  get fullO2CylinderComment() {
    return this.WeeklyClinicForm.get('fullO2CylinderComment');
  }
  get medicalWaste() {
    return this.WeeklyClinicForm.get('medicalWaste');
  }
  get medicalWasteComment() {
    return this.WeeklyClinicForm.get('medicalWasteComment');
  }
  get medicinesExpiryDate() {
    return this.WeeklyClinicForm.get('medicinesExpiryDate');
  }
  get medicinesExpiryDateComment() {
    return this.WeeklyClinicForm.get('medicinesExpiryDateComment');
  }
  get otherComments() {
    return this.WeeklyClinicForm.get('otherComments');
  }
  get doctorName() {
    return this.WeeklyClinicForm.get('doctorName');
  }
  get qhseEngineer() {
    return this.WeeklyClinicForm.get('qhseEngineer');
  }
  get drugInventory() {
    return this.WeeklyClinicForm.get('drugInventory') as FormArray;
  }
  get fridgeComponents() {
    return this.WeeklyClinicForm.get('fridgeComponents') as FormArray;
  }

  createFridgeComponentsFormGroup(itemValue: string) {
    return this.fb.group({
      item : [itemValue, Validators.required],
      quantity : ['', Validators.required],
      expireDate: ['', Validators.required],
    });
  }

  createDrugInventoryFormGroup() {
    return this.fb.group({
      item : ['', Validators.required],
      quantity : ['', Validators.required],
      expireDate: ['', Validators.required],
    });
  }

  addDrugInventory() {
    this.drugInventory.push(this.createDrugInventoryFormGroup());
  }
  addFridgeComponents() {
    this.fridgeComponents.push(this.createFridgeComponentsFormGroup(''));
  }

  submitData() {
    console.log("this.WeeklyClinicForm.value")
    console.log(this.WeeklyClinicForm.value)
    if (this.WeeklyClinicForm.valid) {
      this.submitted = false
      this.AddService.AddWeeklyClinic(this.WeeklyClinicForm.value).subscribe({
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
      // console.log(Formdata);
    }
    else {
      this.WeeklyClinicForm.markAllAsTouched()
      this.submitted = true;
      console.log("E+++++====error in : ");
      console.log(this.WeeklyClinicForm);
    }
  }

  Download() {
    let workbook = new Workbook();

    let worksheet = workbook.addWorksheet("Weekly Clinic Data");


    let header = Object.keys(this.json_data[0]);

    let headerRow = worksheet.addRow(header);

    headerRow.fill = {
      type: 'pattern',
      pattern: 'solid',
      fgColor: {
        argb: 'ff0e0a27'
      }
    }

    headerRow.font = {
      name: 'Calibri',
      size: 12,
      bold: true,
      color: {
        argb: 'ffffffff'
      }
    }

    headerRow.alignment = {
      horizontal: 'center',
      vertical: 'middle',
      wrapText: true
    }

    headerRow.eachCell((cell, colNumber) => {
      worksheet.getColumn(colNumber).width = Math.max((header[colNumber - 1].length) + 10, 15);
      worksheet.getRow(1).height = 35;
    });

    for (let x1 of this.json_data) {
      let x2 = Object.keys(x1);
      let temp: any[] = []
      for (let y of x2) {
        temp.push(x1[y])
      }
      worksheet.addRow(temp)
    }

    let fname = "Weekly Clinic Report"

    //add data and file name and download
    workbook.xlsx.writeBuffer().then((data) => {
      let blob = new Blob([data], { type: 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet' });
      saveAs.saveAs(blob, fname + '-' + new Date().toUTCString() + '.xlsx');
    });
  }

}
