import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AddNewMedicalReportService } from 'Services/add-new-medical-report.service';
import { DataService } from 'Services/data.service';
import { LoginService } from 'Services/login.service';
import { IRig } from 'SharedClasses/IRig';
import { ITypeOfIncident } from 'SharedClasses/ITypeOfIncident';
import { Workbook } from 'exceljs';
import * as saveAs from 'file-saver';

@Component({
  selector: 'app-add-medical-report',
  templateUrl: './add-medical-report.component.html',
  styleUrls: ['./add-medical-report.component.scss']
})
export class AddMedicalReportComponent {
  MedicalReportForm!: FormGroup;
  ErrorMessage = '';
  json_data: any[] = [];
  time = new Date();
  base64: any; rigList: IRig[] = []
  TypeOfIncidentList: ITypeOfIncident[] = []
  MedicalReportObj!: any
  TypeOfIncident:number=0;
  IsTheIllHealth:number=0;

  UserJsonString: any
  UserJsonObj: any
  CodeList: any;
  Code_NameID:number=0;
  Code_Name:string='';
  CodePositionID: number = 0;
  Code_Position:string='';
  isOtherSelected = false;
  isEcdcSelected = false;
  User: any;

  selectedOption: string = '';
  selectedIncidentId: number = 0;
  constructor(private loginService: LoginService, private dataService: DataService, private AddNewMedicalReport: AddNewMedicalReportService, private fb: FormBuilder, private router: Router) {

  }


  ngOnInit() {
    this.User = this.loginService.currentUser.getValue();
    this.UserJsonString = JSON.stringify(this.loginService.currentUser.getValue())
    this.UserJsonObj = JSON.parse(this.UserJsonString);
    console.log("useeeeeeeeeeeeeeeeeeeeeeeeeeeeee")
    console.log(this.UserJsonObj)

    this.dataService.GetEmpCode().subscribe({
      next: data => {
        this.CodeList = data.data
       console.log("this.CodeList")
        console.log(this.CodeList)


      },
      error: err => {
        this.ErrorMessage = err,
          console.log("this.ErrorMessage")
        console.log(this.ErrorMessage)
      }
    }),

      this.MedicalReportForm = this.fb.group(
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
          typeOfIncidentId: this.fb.control(
            '',
            [
              //Validators.required
            ]
          ),
          code: this.fb.control(
            '',
            [
              Validators.required
            ]
          ),
          name: this.fb.control(
            '',
            [
              Validators.required
            ]
          ),
          company: this.fb.control(
            '',
            [
              Validators.required
            ]
          ),
          job: this.fb.control(
            '',
            [
              Validators.required
            ]
          ),
          isTheIllHealth: this.fb.control(
            '',
            [
              Validators.required
            ]
          ),
          address: this.fb.control(
            '',
            [
              Validators.required
            ]
          ),
          telephoneNumber: this.fb.control(
            '',
            [
              Validators.required
            ]
          ),
          age: this.fb.control(
            '',
            [
              Validators.required
            ]
          ),
          dateOfBirth: this.fb.control(
            '',
            [
              Validators.required
            ]
          ),
          rigManager: this.fb.control(
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
          rigDoctor: this.fb.control(
            '',
            [
              Validators.required
            ]
          ),
          doctorRecommendation: this.fb.control(
            '',
            [
              Validators.required
            ]
          ),

          doctorComment: this.fb.control(
            '',
            [
              Validators.required
            ]
          ),
          diagnosis: this.fb.control(
            '',
            [
              Validators.required
            ]
          ),
          userID: this.fb.control(this.User.ID, [Validators.required])
        }
      ),
      this.dataService.GetMedicalReports(this.User.ID, this.User.Role).subscribe({
        next: data =>{ this.json_data = data.data
        },
        error: err => this.ErrorMessage = err
      }),

      this.dataService.GetRig().subscribe({
        next: data => this.rigList = data.data,
        error: err => this.ErrorMessage = err
      }),
      this.dataService.GetTypeOfIncidentIdList().subscribe({
        next: data => {
          this.TypeOfIncidentList = data.data
        },
        error: err => this.ErrorMessage = err
      })

  }
  selectedMenace(event: any) {
    console.log("event.target.value")
    console.log(event.target.value)
    this.dataService.GetEmpCodeByCode(event.target.value).subscribe({
      next:data=>{
        this.Code_NameID=data.data.id
        this.Code_Name=data.data.name,
        this.CodePositionID=data.data.positionId
        console.log(data.data)
        console.log("this.QHSE_Name")
        console.log(this.Code_Name)
        console.log("this kkkkkkkkk")
        console.log(data.data)
        console.log("this.QHSE_PositionID")
        console.log(this.CodePositionID)
        this.dataService.GetPositionByID(this.CodePositionID).subscribe({
          next:data=>{
            this.Code_Position=data.data.name,
            console.log("this.QHSE_Positionnnnnnnnnnnnnnnn")
            console.log(this.Code_Position)
          },
          error:err=>{
            this.ErrorMessage=err,
            console.log(this.ErrorMessage)
          }
        })
      },
      error:err=>{
        this.ErrorMessage=err,
        console.log(err)
      }
    })
  }

  get id() {
    return this.MedicalReportForm.get('id');
  }
  get rigId() {
    return this.MedicalReportForm.get('rigId');
  }
  get date() {
    return this.MedicalReportForm.get('date');
  }
  get typeOfIncidentId() {
    return this.MedicalReportForm.get('typeOfIncidentId');
  }

  get isTheIllHealth() {
    return this.MedicalReportForm.get('isTheIllHealth');
  }
  get company() {
    return this. MedicalReportForm .get('company')!;
  }
  get job() {
    return this.MedicalReportForm.get('job');
  }
  get code() {
    return this.MedicalReportForm.get('code');
  }
  get name() {
    return this.MedicalReportForm.get('name');
  }
  get address() {
    return this.MedicalReportForm.get('address');
  }
  get telephoneNumber() {
    return this.MedicalReportForm.get('telephoneNumber');
  }

  get age() {
    return this.MedicalReportForm.get('age');
  }
  get dateOfBirth() {
    return this.MedicalReportForm.get('dateOfBirth');
  }
  get rigManager() {
    return this.MedicalReportForm.get('rigManager');
  }

  get qhseEngineer() {
    return this.MedicalReportForm.get('qhseEngineer');
  }
  get rigDoctor() {
    return this.MedicalReportForm.get('rigDoctor');
  }
  get doctorRecommendation() {
    return this.MedicalReportForm.get('doctorRecommendation');
  }

  get doctorComment() {
    return this.MedicalReportForm.get('doctorComment');
  }
  get diagnosis() {
    return this.MedicalReportForm.get('diagnosis');
  }

  onCompanyChange() {
    const selectedCompany = this.company.value;
    // Update flags based on the selected company
    this.isOtherSelected = selectedCompany === 'Other';
    this.isEcdcSelected = selectedCompany === 'ECDC';
  }

  validateKeyPress(event: KeyboardEvent): void {
    const input = event.target as HTMLInputElement;
    const allowedKeys = ['Backspace', 'ArrowLeft', 'ArrowRight', 'Delete'];
    const isNumber = /^\d$/.test(event.key);

    if (!isNumber && !allowedKeys.includes(event.key)) {
      event.preventDefault();
    }

    if (input.value.length >= 14 && !allowedKeys.includes(event.key)) {
      event.preventDefault();
    }
  }
  submitData() {

    if (this.MedicalReportForm.valid) {

      const Formdata = new FormData()
      console.log("fforrrrrrrmmmmmmmmm", Formdata)

      Formdata.append('rigId', this.rigId?.value);
      Formdata.append('date', this.date?.value);
      Formdata.append('typeOfIncidentId', this.typeOfIncidentId?.value);
      Formdata.append('isTheIllHealth', this.isTheIllHealth?.value);

      Formdata.append('company', this.company?.value);
      Formdata.append('job', this.job?.value);
      Formdata.append('code', this.code?.value);

      Formdata.append('name', this.name?.value);
      Formdata.append('address', this.address?.value);
      Formdata.append('telephoneNumber', this.telephoneNumber?.value);

      Formdata.append('age', this.age?.value);
      Formdata.append('dateOfBirth', this.dateOfBirth?.value);
      Formdata.append('rigManager', this.rigManager?.value);

      Formdata.append('qhseEngineer', this.qhseEngineer?.value);
      Formdata.append('rigDoctor', this.rigDoctor?.value);
      Formdata.append('doctorRecommendation', this.doctorRecommendation?.value);
      Formdata.append('doctorComment', this.doctorComment?.value);
     Formdata.append('diagnosis', this.diagnosis?.value);
      Formdata.append('userID', this.UserJsonObj.ID);
      console.log('after formData')
      console.log(Formdata);
      this.AddNewMedicalReport.AddMedicalReport(Formdata).subscribe({
        next: data => {
          console.log('from service')
          console.log(data.data)
          // location.reload();
        },
        error: error => {
          console.log("this.MedicalReportForm");
          console.log(this.MedicalReportForm);

          console.log("from Error")
          console.log(error)
        }
      });
      console.log(Formdata);
    }
    else {
      console.log('MedicalReportlllll', this.MedicalReportForm.value)
this.MedicalReportForm.markAllAsTouched()
      console.log("E+++++====error in : ");
    }
  }


  Download() {
    let workbook = new Workbook();

    let worksheet = workbook.addWorksheet("MedicalReports Data");


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
    let fname = "MedicalReport Report"
    workbook.xlsx.writeBuffer().then((data) => {
      let blob = new Blob([data], { type: 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet' });
      saveAs.saveAs(blob, fname + '-' + new Date().toUTCString() + '.xlsx');
    });
  }
}
