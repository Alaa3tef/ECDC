import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AddNewMedicalHistoryService } from 'Services/add-new-medical-history.service';
import { DataService } from 'Services/data.service';
import { LoginService } from 'Services/login.service';
import { IRig } from 'SharedClasses/IRig';
import { Workbook } from 'exceljs';
import * as saveAs from 'file-saver';

@Component({
  selector: 'app-add-medical-history-report',
  templateUrl: './add-medical-history-report.component.html',
  styleUrls: ['./add-medical-history-report.component.scss']
})
export class AddMedicalHistoryReportComponent {
  MedicalHistoryForm !: FormGroup;
  ErrorMessage = '';
  json_data: any[] = [];
  rigList: IRig[] = []


  UserJsonString: any
  UserJsonObj: any

  CodeList: any;
  Code_NameID:number=0;
  Code_Name:string='';
  CodePositionID: number = 0;
  Code_Position:string='';

  isOtherSelected = false;
  isEcdcSelected = false;
  User:any;

  constructor(private loginService: LoginService, private dataService: DataService, private AddNewMedicalHistory: AddNewMedicalHistoryService, private fb: FormBuilder, private router: Router) {
  }


  ngOnInit() {
    this.User=this.loginService.currentUser.getValue();
    this.UserJsonString = JSON.stringify(this.loginService.currentUser.getValue())
    this.UserJsonObj = JSON.parse(this.UserJsonString);
    console.log("useeeeeeeeeeeeeeeeeeeeeeeeeeeeee")
    console.log(this.UserJsonObj)
    this.dataService.GetEmpCode().subscribe({
      next: data => {
        this.CodeList = data.data,
          console.log("this.CodeList")
        console.log(this.CodeList)
      },
      error: err => {
        this.ErrorMessage = err,
          console.log("this.ErrorMessage")
        console.log(this.ErrorMessage)
      }
    }),

    this. MedicalHistoryForm  = this.fb.group(
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
          company: this.fb.control(
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
          dateOfBirth: this.fb.control(
            '',
            [
               Validators.required
            ]
          ),
          contact: this.fb.control(
            '',
            [

            ]
          ),
          telephoneNumber: this.fb.control(
            '',
            [
               Validators.required
            ]
          ),
          socia_DoYouSmokeAnswer: this.fb.control(
            '',
            [
              Validators.required
            ]
          ),
          socia_DoYouSmokeComment: this.fb.control(
            '',
            [
            ]
          ),
          socia_DoYouExerciseRegularlyAnswer: this.fb.control(
            '',
            [
              Validators.required
            ]
          ),
          socia_DoYouExerciseRegularlyComment: this.fb.control(
            '',
            [
            ]
          ),
          socia_HaveYouBeenExposedAnswer: this.fb.control(
            '',
            [
              Validators.required
            ]
          ),

          socia_HaveYouBeenExposedComment: this.fb.control(
            '',
            [
            ]
          ),
          socia_HaveYouEverDevelopedAnswer: this.fb.control(
            '',
            [
              Validators.required
            ]
          ),
          socia_HaveYouEverDevelopedComment : this.fb.control(
            '',
            [

            ]
          ),

          socia_HaveYouSufferedAnswer: this.fb.control(
            '',
            [
              Validators.required
            ]
          ),
          socia_HaveYouSufferedComment: this.fb.control(
            '',
            [
            ]
          ),
          family_AreYouCurrentlyBeingTreatedAnswer: this.fb.control(
            '',
            [
              Validators.required
            ]
          ),

          family_AreYouCurrentlyBeingTreatedComment: this.fb.control(
            '',
            [
            ]
          ),
          family_AreYouCurrentlyReceivingAnyMedicalAnswer: this.fb.control(
            '',
            [
              Validators.required
            ]
          ),
          family_AreYouCurrentlyReceivingAnyMedicalComment: this.fb.control(
            '',
            [
            ]
          ),

          family_HighBloodPressureAnswer: this.fb.control(
            '',
            [
              Validators.required
            ]
          ),
          family_HighBloodPressureComment: this.fb.control(
            '',
            [
            ]
          ),
          family_HeartDiseaseAnswer: this.fb.control(
            '',
            [
              Validators.required
            ]
          ),

          family_HeartDiseaseComment: this.fb.control(
            '',
            [
            ]
          ),
          family_COPDAnswer: this.fb.control(
            '',
            [
              Validators.required
            ]
          ),
          family_COPDComment: this.fb.control(
            '',
            [
            ]
          ),

          family_DiabetesAnswer: this.fb.control(
            '',
            [
              Validators.required
            ]
          ),
          family_DiabetesComment: this.fb.control(
            '',
            [
            ]
          ),
          family_GITAnswer: this.fb.control(
            '',
            [
              Validators.required
            ]
          ),

          family_GITComment: this.fb.control(
            '',
            [
            ]
          ),
          family_KidneyAnswer: this.fb.control(
            '',
            [
              Validators.required
            ]
          ),
          family_KidneyComment: this.fb.control(
            '',
            [
            ]

          ),
          family_NeurologicalAnswer: this.fb.control(
            '',
            [
              Validators.required
            ]
          ),
          family_NeurologicalComment: this.fb.control(
            '',
            [
            ]
          ),
          family_InfectiousAnswer: this.fb.control(
            '',
            [
              Validators.required
            ]
          ),
          family_InfectiousComment: this.fb.control(
            '',
             [
             ]
          ),
          family_DizzinessAnswer: this.fb.control(
            '',
            [
              Validators.required
            ]
          ),
          family_DizzinessComment: this.fb.control(
            '',
            [
            ]
          ),
          family_DiscProlapseAnswer: this.fb.control(
            '',
            [
              Validators.required
            ]
          ),
          family_DiscProlapseComment: this.fb.control(
            '',
            [
            ]
          ),
          family_AllergyAnswer: this.fb.control(
            '',
            [
              Validators.required
            ]
          ),
          family_AllergyComment: this.fb.control(
            '',
            [
            ]
          ),
          family_HospitalizationAnswer: this.fb.control(
            '',
            [
              Validators.required
            ]
          ),
          family_HospitalizationComment: this.fb.control(
            '',
            [
            ]
          ),
          family_SurgeryAnswer: this.fb.control(
            '',
            [
              Validators.required
            ]
          ),
          family_SurgeryComment: this.fb.control(
            '',
            [
            ]
          ),
          family_DepressionAnswer: this.fb.control(
            '',
            [
              Validators.required
            ]
          ),
          family_DepressionComment: this.fb.control(
            '',
            [
            ]
          ),
          family_DoAnyOfYour1stDegreeFamilyAnswer: this.fb.control(
            '',
            [
              Validators.required
            ]
          ),
          family_DoAnyOfYour1stDegreeFamilyComment: this.fb.control(
            '',
            [
            ]
          ),
          generalExamination_Weight: this.fb.control(
            '',
            [
            ]
          ),
          generalExamination_Height: this.fb.control(
            '',
            [
            ]
          ),
          generalExamination_BloodPressure: this.fb.control(
            '',
            [
            ]
          ),
          generalExamination_HeartRate: this.fb.control(
            '',
            [
            ]
          ),
          doctorComments: this.fb.control(
            '',
            [
            ]
          ),
          doctorName: this.fb.control(
            '',
            [
            ]
          ),
          code: this.fb.control(
            '',
            [
              Validators.required,
              Validators.minLength(14),
              Validators.maxLength(14)
            ]
          ),
          jop: this.fb.control(
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
          userID: this.fb.control(this.User.ID, [Validators.required]),
        }
      ),
      this.dataService.GetMedicalHistorys(this.User.ID,this.User.Role).subscribe({
        next: data => this.json_data = data.data,
        error: err => this.ErrorMessage = err
      }),

      this.dataService.GetRig().subscribe({
        next: data => this.rigList = data.data,
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
            console.log("this.QHSE_Position")
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
    return this. MedicalHistoryForm .get('id');
  }
  get rigId() {
    return this. MedicalHistoryForm .get('rigId');
  }
  get date() {
    return this. MedicalHistoryForm .get('date');
  }
  get company() {
    return this. MedicalHistoryForm .get('company')!;
  }

  get address() {
    return this. MedicalHistoryForm .get('address');
  }
  get dateOfBirth() {
    return this. MedicalHistoryForm .get('dateOfBirth');
  }
  get contact() {
    return this. MedicalHistoryForm .get('contact');
  }
  get telephoneNumber() {
    return this. MedicalHistoryForm .get('telephoneNumber');
  }
  get socia_DoYouSmokeAnswer() {
    return this. MedicalHistoryForm .get('socia_DoYouSmokeAnswer');
  }
  get socia_DoYouSmokeComment() {
    return this. MedicalHistoryForm .get('socia_DoYouSmokeComment');
  }
  get socia_DoYouExerciseRegularlyAnswer() {
    return this. MedicalHistoryForm .get('socia_DoYouExerciseRegularlyAnswer');
  }

  get socia_DoYouExerciseRegularlyComment() {
    return this. MedicalHistoryForm .get('socia_DoYouExerciseRegularlyComment');
  }
  get socia_HaveYouBeenExposedAnswer() {
    return this. MedicalHistoryForm .get('socia_HaveYouBeenExposedAnswer');
  }
  get socia_HaveYouBeenExposedComment() {
    return this. MedicalHistoryForm .get('socia_HaveYouBeenExposedComment');
  }

  get socia_HaveYouEverDevelopedAnswer() {
    return this. MedicalHistoryForm .get('socia_HaveYouEverDevelopedAnswer');
  }
  get socia_HaveYouEverDevelopedComment() {
    return this. MedicalHistoryForm .get('socia_HaveYouEverDevelopedComment');
  }
  get socia_HaveYouSufferedAnswer() {
    return this. MedicalHistoryForm .get('socia_HaveYouSufferedAnswer');
  }

  get socia_HaveYouSufferedComment() {
    return this. MedicalHistoryForm .get('socia_HaveYouSufferedComment');
  }
  get family_AreYouCurrentlyBeingTreatedAnswer() {
    return this. MedicalHistoryForm .get('family_AreYouCurrentlyBeingTreatedAnswer');
  }
  get family_AreYouCurrentlyBeingTreatedComment() {
    return this. MedicalHistoryForm .get('family_AreYouCurrentlyBeingTreatedComment');
  }

  get family_AreYouCurrentlyReceivingAnyMedicalAnswer() {
    return this. MedicalHistoryForm .get('family_AreYouCurrentlyReceivingAnyMedicalAnswer');
  }
  get family_AreYouCurrentlyReceivingAnyMedicalComment() {
    return this. MedicalHistoryForm .get('family_AreYouCurrentlyReceivingAnyMedicalComment');
  }
  get family_HighBloodPressureAnswer() {
    return this. MedicalHistoryForm .get('family_HighBloodPressureAnswer');
  }

  get family_HighBloodPressureComment() {
    return this. MedicalHistoryForm .get('family_HighBloodPressureComment');
  }
  get family_HeartDiseaseAnswer() {
    return this. MedicalHistoryForm .get('family_HeartDiseaseAnswer');
  }
  get family_HeartDiseaseComment() {
    return this. MedicalHistoryForm .get('family_HeartDiseaseComment');
  }

  get family_COPDAnswer() {
    return this. MedicalHistoryForm .get('family_COPDAnswer');
  }
  get family_COPDComment() {
    return this. MedicalHistoryForm .get('family_COPDComment');
  }
  get family_DiabetesAnswer() {
    return this. MedicalHistoryForm .get('family_DiabetesAnswer');
  }

  get family_DiabetesComment() {
    return this. MedicalHistoryForm .get('family_DiabetesComment');
  }
  get family_GITAnswer() {
    return this. MedicalHistoryForm .get('family_GITAnswer');
  }
  get family_GITComment() {
    return this. MedicalHistoryForm .get('family_GITComment');
  }

  get family_KidneyAnswer() {
    return this. MedicalHistoryForm .get('family_KidneyAnswer');
  }
  get family_KidneyComment() {
    return this. MedicalHistoryForm .get('family_KidneyComment');
  }
  get family_NeurologicalAnswer() {
    return this. MedicalHistoryForm .get('family_NeurologicalAnswer');
  }
  get family_NeurologicalComment() {
    return this. MedicalHistoryForm .get('family_NeurologicalComment');
  }
  get family_InfectiousAnswer() {
    return this. MedicalHistoryForm .get('family_InfectiousAnswer');
  }
  get family_InfectiousComment() {
    return this. MedicalHistoryForm .get('family_InfectiousComment');
  }
  get family_DizzinessAnswer() {
    return this. MedicalHistoryForm .get('family_DizzinessAnswer');
  }
  get family_DizzinessComment() {
    return this. MedicalHistoryForm .get('family_DizzinessComment');
  }

   get family_DiscProlapseAnswer() {
    return this. MedicalHistoryForm .get('family_DiscProlapseAnswer');
  }

  get family_DiscProlapseComment() {
    return this. MedicalHistoryForm .get('family_DiscProlapseComment');
  }
  get family_AllergyAnswer() {
    return this. MedicalHistoryForm .get('family_AllergyAnswer');
  }
  get family_AllergyComment() {
    return this. MedicalHistoryForm .get('family_AllergyComment');
  }
  get family_HospitalizationAnswer() {
    return this. MedicalHistoryForm .get('family_HospitalizationAnswer');
  }
  get family_HospitalizationComment() {
    return this. MedicalHistoryForm .get('family_HospitalizationComment');
  }
  get family_SurgeryAnswer() {
    return this. MedicalHistoryForm .get('family_SurgeryAnswer');
  }
  get family_SurgeryComment() {
    return this. MedicalHistoryForm .get('family_SurgeryComment');
  }
  get family_DepressionAnswer() {
    return this. MedicalHistoryForm .get('family_DepressionAnswer');
  }
  get family_DepressionComment() {
    return this. MedicalHistoryForm .get('family_DepressionComment');
  }
  get family_DoAnyOfYour1stDegreeFamilyAnswer() {
    return this. MedicalHistoryForm .get('family_DoAnyOfYour1stDegreeFamilyAnswer');
  }
   get family_DoAnyOfYour1stDegreeFamilyComment() {
    return this. MedicalHistoryForm .get('family_DoAnyOfYour1stDegreeFamilyComment');
  }
  get generalExamination_Weight() {
    return this. MedicalHistoryForm .get('generalExamination_Weight');
  }
  get generalExamination_Height() {
    return this. MedicalHistoryForm .get('generalExamination_Height');
  }
  get generalExamination_BloodPressure() {
    return this. MedicalHistoryForm .get('generalExamination_BloodPressure');
  }
  get generalExamination_HeartRate() {
    return this. MedicalHistoryForm .get('generalExamination_HeartRate');
  }
  get doctorComments() {
    return this. MedicalHistoryForm .get('doctorComments');
  }
  get doctorName() {
    return this. MedicalHistoryForm .get('doctorName');
  }
  get code() {
    return this. MedicalHistoryForm .get('code');
  }
  get jop() {
    return this. MedicalHistoryForm .get('jop');
  }
  get name() {
    return this. MedicalHistoryForm .get('name');
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

     if (this. MedicalHistoryForm .valid) {

      const Formdata=new FormData()
     console.log("fforrrrrrrmmmmmmmmm",Formdata)

      Formdata.append('rigId', this.rigId?.value);
      Formdata.append('date', this.date?.value);
      Formdata.append('company', this.company?.value);
      Formdata.append('address', this.address?.value);

      Formdata.append('dateOfBirth', this.dateOfBirth?.value);
      Formdata.append('contact', this.contact?.value);
      Formdata.append('telephoneNumber', this.telephoneNumber?.value);

      Formdata.append('socia_DoYouSmokeAnswer', this.socia_DoYouSmokeAnswer?.value);
      Formdata.append('socia_DoYouSmokeComment', this.socia_DoYouSmokeComment?.value);
      Formdata.append('socia_DoYouExerciseRegularlyAnswer', this.socia_DoYouExerciseRegularlyAnswer?.value);

      Formdata.append('socia_DoYouExerciseRegularlyComment', this.socia_DoYouExerciseRegularlyComment?.value);
      Formdata.append('socia_HaveYouBeenExposedAnswer', this.socia_HaveYouBeenExposedAnswer?.value);
      Formdata.append('socia_HaveYouBeenExposedComment', this.socia_HaveYouBeenExposedComment?.value);

      Formdata.append('socia_HaveYouEverDevelopedAnswer', this.socia_HaveYouEverDevelopedAnswer?.value);
      Formdata.append('socia_HaveYouEverDevelopedComment', this.socia_HaveYouEverDevelopedComment?.value);
      Formdata.append('socia_HaveYouSufferedAnswer', this.socia_HaveYouSufferedAnswer?.value);

      Formdata.append('socia_HaveYouSufferedComment', this.socia_HaveYouSufferedComment?.value);
      Formdata.append('family_AreYouCurrentlyBeingTreatedAnswer', this.family_AreYouCurrentlyBeingTreatedAnswer?.value);
      Formdata.append('family_AreYouCurrentlyBeingTreatedComment', this.family_AreYouCurrentlyBeingTreatedComment?.value);

      Formdata.append('family_AreYouCurrentlyReceivingAnyMedicalAnswer', this.family_AreYouCurrentlyReceivingAnyMedicalAnswer?.value);
      Formdata.append('family_AreYouCurrentlyReceivingAnyMedicalComment', this.family_AreYouCurrentlyReceivingAnyMedicalComment?.value);
      Formdata.append('family_HighBloodPressureAnswer', this.family_HighBloodPressureAnswer?.value);

      Formdata.append('family_HighBloodPressureComment', this.family_HighBloodPressureComment?.value);
      Formdata.append('family_HeartDiseaseAnswer', this.family_HeartDiseaseAnswer?.value);
      Formdata.append('family_HeartDiseaseComment', this.family_HeartDiseaseComment?.value);

      Formdata.append('family_COPDAnswer', this.family_COPDAnswer?.value);
      Formdata.append('family_COPDComment', this.family_COPDComment?.value);
      Formdata.append('family_DiabetesAnswer', this.family_DiabetesAnswer?.value);

      Formdata.append('family_DiabetesComment', this.family_DiabetesComment?.value);
      Formdata.append('family_GITAnswer', this.family_GITAnswer?.value);
      Formdata.append('family_GITComment', this.family_GITComment?.value);

      Formdata.append('family_KidneyAnswer', this.family_KidneyAnswer?.value);
      Formdata.append('family_KidneyComment', this.family_KidneyComment?.value);
      Formdata.append('family_NeurologicalAnswer', this.family_NeurologicalAnswer?.value);

      Formdata.append('family_NeurologicalComment', this.family_NeurologicalComment?.value);
      Formdata.append('family_InfectiousAnswer', this.family_InfectiousAnswer?.value);
      Formdata.append('family_InfectiousComment', this.family_InfectiousComment?.value);

      Formdata.append('family_DizzinessAnswer', this.family_DizzinessAnswer?.value);
      Formdata.append('family_DizzinessComment', this.family_DizzinessComment?.value);
      Formdata.append('family_DiscProlapseAnswer', this.family_DiscProlapseAnswer?.value);

      Formdata.append('family_DiscProlapseComment', this.family_DiscProlapseComment?.value);
      Formdata.append('family_AllergyAnswer', this.family_AllergyAnswer?.value);
      Formdata.append('family_AllergyComment', this.family_AllergyComment?.value);
      Formdata.append('family_HospitalizationAnswer', this.family_HospitalizationAnswer?.value);

      Formdata.append('family_HospitalizationComment', this.family_HospitalizationComment?.value);
      Formdata.append('family_SurgeryAnswer', this.family_SurgeryAnswer?.value);
      Formdata.append('family_SurgeryComment', this.family_SurgeryComment?.value);
      Formdata.append('family_DepressionAnswer', this.family_DepressionAnswer?.value);
      Formdata.append('family_DepressionComment', this.family_DepressionComment?.value);
      Formdata.append('family_DoAnyOfYour1stDegreeFamilyAnswer', this.family_DoAnyOfYour1stDegreeFamilyAnswer?.value);
      Formdata.append('family_DoAnyOfYour1stDegreeFamilyComment', this.family_DoAnyOfYour1stDegreeFamilyComment?.value);
      Formdata.append('generalExamination_Weight', this.generalExamination_Weight?.value);
      Formdata.append('generalExamination_Height', this.generalExamination_Height?.value);
      Formdata.append('generalExamination_BloodPressure', this.generalExamination_BloodPressure?.value);
      Formdata.append('generalExamination_HeartRate', this.generalExamination_HeartRate?.value);
      Formdata.append('doctorComments', this.doctorComments?.value);
      Formdata.append('doctorName', this.doctorName?.value);

      Formdata.append('code', this.code?.value);
      Formdata.append('jop', this.jop?.value);
      Formdata.append('name', this.name?.value);

      Formdata.append('userID', this.UserJsonObj.ID);
      console.log(Formdata);


      console.log('after formData')
      this.AddNewMedicalHistory.AddMedicalHistory(Formdata).subscribe({
        next: data => {
          // console.log(this. MedicalHistoryForm );

          console.log('from service')
          console.log(data.data)
          location.reload();
        },
        error: error => {
          // console.log(this. MedicalHistoryForm );

          console.log("from Error")
          console.log(error)
        }
      });
     console.log(Formdata);
    }
    else {
      this.MedicalHistoryForm.markAllAsTouched()
       console.log('weeklyyy', this.MedicalHistoryForm.value)

      console.log("E+++++====error in : ");
    }
  }
  Download() {
    let workbook = new Workbook();

    let worksheet = workbook.addWorksheet("Medical History Report Data");


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

    let fname = "Medical History Report"

    //add data and file name and download
    workbook.xlsx.writeBuffer().then((data) => {
      let blob = new Blob([data], { type: 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet' });
      saveAs.saveAs(blob, fname + '-' + new Date().toUTCString() + '.xlsx');
    });
  }

}
