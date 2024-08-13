import { ChangeDetectorRef, Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, ParamMap, Router } from '@angular/router';
import { AddNewMedicalReportService } from 'Services/add-new-medical-report.service';
import { DataService } from 'Services/data.service';
import { LoginService } from 'Services/login.service';
import { IMedicalReport } from 'SharedClasses/IMedicalReport';
import { IQHSEPosition } from 'SharedClasses/IQHSEPosition';
import { IQHSEPositionName } from 'SharedClasses/IQHSEPositionName';
import { IRig } from 'SharedClasses/IRig';
import { ITypeOfIncident } from 'SharedClasses/ITypeOfIncident';

@Component({
  selector: 'app-edit-medical-report',
  templateUrl: './edit-medical-report.component.html',
  styleUrls: ['./edit-medical-report.component.scss']
})
export class EditMedicalReportComponent {
  MedicalReportId: any;
  MedicalReport!: IMedicalReport;
  ErrorMessage: string = "";
  MedicalReportForm!: FormGroup;
  Date: Date = new Date();
  rigList: IRig[] = []
  TypeOfIncidentList: ITypeOfIncident[] = []
  TypeOfIncident:number=0;
  qhsePositionNameList: IQHSEPositionName[] = []
  qhsePositionList: IQHSEPosition[] = []
  QHSEPositionID: number = 0;

  UserJsonString: any
  UserJsonObj: any

  QHSECodeRecord: any;

  QHSEPositionCodeID: number = 0;
  QHSENameCodeID: number = 0;
  QHSEposition: string = '';
  QHSEName: string = '';

  QHSECodeList: any[]=[];
  QHSE_NameID: number = 0;
  QHSE_Code: number = 0;
  QHSE_Name: string = '';
  QHSE_Position: string = '';

  isOtherSelected = false;
  isEcdcSelected = false;
  Code:any=[]
  User: any;


  constructor(private loginService: LoginService,
    private activatedRoute: ActivatedRoute,
    private dataService: DataService,
    private MedicalReportService: AddNewMedicalReportService,
    private fb: FormBuilder,
    private router: Router,
    private cdr: ChangeDetectorRef) { 
      
    }


  ngOnInit(): void {
    this.User = this.loginService.currentUser.getValue();
    this.activatedRoute.paramMap.subscribe((params: ParamMap) => {
      this.MedicalReportId = params.get("id");
      console.log(this.MedicalReportId)
    }),
      this.MedicalReportService.GetMedicalReportByID(this.MedicalReportId, this.User.ID, this.User.Role).subscribe({
        next: data => {
          this.MedicalReport = data.data,
            console.log('*************************************************************')
          console.log(this.MedicalReport);
          this.QHSE_Code = data.data.code
          this.QHSE_Position = data.data.job;
          this.QHSE_Name = data.data.name;
          this.TypeOfIncident=data.data.typeOfIncidentId;
          console.log('*********** TypeOfIncident ******************')
          console.log(this.TypeOfIncident)
          console.log("dataaaaaaaaaa")
          console.log(data.data)
          this.Date = this.MedicalReport.date
          console.log('###################################################')

          console.log(this.QHSE_Code)
          console.log("this.QHSE_Code")

          this.dataService.GetEmpCodeByCode(this.QHSE_Code).subscribe({
            next: data => {
              this.QHSE_NameID = data.data.id;
              this.QHSE_Name = data.data.name;
              this.QHSEPositionID = data.data.positionId;
              console.log("this.QHSE_Name+++++++++++++++++");
              console.log(data.data);
              console.log("this.QHSE_nameeeeeeeeeeeeeeeeeeeeeeeeee");
              console.log(this.QHSE_Name);
              console.log("this.QHSE_PositionID");
              console.log(this.QHSEPositionID);
              
              this.dataService.GetPositionByID(this.QHSEPositionID).subscribe({
                next: data => {
                  this.QHSE_Position = data.data.name;
                  console.log("this.QHSE_Position");
                  console.log(this.QHSE_Position);
                },
                error: err => {
                  this.ErrorMessage = err;
                  console.log(this.ErrorMessage);
                }
              });
            },
            error: err => {
              this.ErrorMessage = err;
              console.log(err);
            }
          });   
        },
        error: (erorr: string) => this.ErrorMessage = erorr
      }),
      this.dataService.GetEmpCode().subscribe({
        next: data => {
          this.QHSECodeList = data.data
          console.log("this.QHSECodeListtttt")
          console.log(this.QHSECodeList)
          this.Code = data.data.code
          console.log(data.data.code)
          this.cdr.detectChanges();
        },
        error: err => {
          this.ErrorMessage = err,
            console.log("this.ErrorMessage")
          console.log(this.ErrorMessage)
        }
      }),
      this.UserJsonString = JSON.stringify(this.loginService.currentUser.getValue()),
      this.UserJsonObj = JSON.parse(this.UserJsonString),
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
              Validators.required,
              Validators.minLength(14),
              Validators.maxLength(14)
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
      this.dataService.GetTypeOfIncidentIdList().subscribe({
        next: data => {
          this.TypeOfIncidentList = data.data,

            console.log(this.TypeOfIncidentList)
        },
        error: err => {
          this.ErrorMessage = err,
            console.log(this.ErrorMessage)
        }
      }),
      this.dataService.GetRig().subscribe({
        next: data => {
          this.rigList = data.data,
            console.log(this.rigList)
        },
        error: err => {
          this.ErrorMessage = err,
            console.log(this.ErrorMessage)
        }
      })
  }

  selectedMenace(event: any) {
    console.log("event.target.value")
    console.log(event.target.value)
    this.dataService.GetEmpCodeByCode(event.target.value).subscribe({
      next:data=>{
        this.QHSE_NameID=data.data.id
        this.QHSE_Name=data.data.name,
        this.QHSEPositionID=data.data.positionId
        console.log(data.data)
        console.log("this.QHSE_Name")
        console.log(this.QHSE_Name)
        console.log("this kkkkkkkkk")
        console.log(data.data)
        console.log("this.QHSE_PositionID")
        console.log(this.QHSEPositionID)
        this.dataService.GetPositionByID(this.QHSEPositionID).subscribe({
          next:data=>{
            this.QHSE_Position=data.data.name,
            console.log("this.QHSE_Position")
            console.log(this.QHSE_Position)
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
      this.MedicalReportService.EditMedicalReport(Formdata, this.MedicalReportId).subscribe({
        next: data => {
          console.log(data)
          this.router.navigate(['/Dashboard/MedicalReport']);
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

      console.log("E+++++====error in : ");
    }
  }

}
