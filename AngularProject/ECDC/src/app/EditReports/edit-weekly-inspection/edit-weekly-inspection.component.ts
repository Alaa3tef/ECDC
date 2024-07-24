import { ChangeDetectorRef, Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, ParamMap, Router } from '@angular/router';
import { AddWeeklyInspectionServiceService } from 'Services/add-weekly-inspection-service.service';
import { DataService } from 'Services/data.service';
import { LoginService } from 'Services/login.service';
import { IQHSEPosition } from 'SharedClasses/IQHSEPosition';
import { IQHSEPositionName } from 'SharedClasses/IQHSEPositionName';
import { IRig } from 'SharedClasses/IRig';
import { IWeeklyInspection } from 'SharedClasses/IWeeklyInspection';

@Component({
  selector: 'app-edit-weekly-inspection',
  templateUrl: './edit-weekly-inspection.component.html',
  styleUrls: ['./edit-weekly-inspection.component.scss']
})
export class EditWeeklyInspectionComponent {
  WeeklyInspectionId: any;
  WeeklyInspection!: IWeeklyInspection;
  ErrorMessage: string = "";
  WeeklyInspectionForm!: FormGroup;
  Date: Date = new Date();
  rigList: IRig[] = []

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

  Code:any=[]
  User: any;

  showInstructions = false;
  arrowDown = false;

  showInstructions1 = false;
  arrowDown1 = false;

  showInstructions2 = false;
  arrowDown2 = false;

  showInstructions3 = false;
  arrowDown3 = false;

  showInstructions4 = false;
  arrowDown4 = false;

  showInstructions5 = false;
  arrowDown5 = false;

  showInstructions6 = false;
  arrowDown6 = false;

  showInstructions7 = false;
  arrowDown7 = false;

  showInstructions8 = false;
  arrowDown8 = false;

  showInstructions9 = false;
  arrowDown9 = false;

  showInstructions10 = false;
  arrowDown10 = false;

  showInstructions11 = false;
  arrowDown11 = false;

  showInstructions12 = false;
  arrowDown12 = false;

  showInstructions13 = false;
  arrowDown13 = false;

  showInstructions14 = false;
  arrowDown14 = false;

  showInstructions15 = false;
  arrowDown15 = false;

  showInstructions16 = false;
  arrowDown16 = false;

  showInstructions17 = false;
  arrowDown17 = false;

  showInstructions18 = false;
  arrowDown18 = false;
  constructor(private loginService: LoginService,
    private activatedRoute: ActivatedRoute,
    private dataService: DataService,
    private WeeklyInspectionService: AddWeeklyInspectionServiceService,
    private fb: FormBuilder,
    private router: Router,
    private cdr: ChangeDetectorRef) { 
      
    }


  ngOnInit(): void {
    this.User = this.loginService.currentUser.getValue();
    this.activatedRoute.paramMap.subscribe((params: ParamMap) => {
      this.WeeklyInspectionId = params.get("id");
      console.log(this.WeeklyInspectionId)
    }),
   
   

      this.WeeklyInspectionService.GetWeeklyInspectionByID(this.WeeklyInspectionId, this.User.ID, this.User.Role).subscribe({
        next: data => {
          this.WeeklyInspection = data.data,
            console.log('*************************************************************')
          console.log(this.WeeklyInspection);
          this.QHSE_Code = data.data.code
          this.QHSE_Position = data.data.positionName;
          this.QHSE_Name = data.data.name;
        //this.WeldingWeeklyFindings=data.data.weldingWeeklyFindings;

            console.log('***********this.QHSE_Code here ******************')
          console.log(this.QHSE_Code)
          console.log("dataaaaaaaaaa")
          console.log(data.data)
          this.Date = this.WeeklyInspection.date
          console.log('###################################################')

          console.log(this.QHSE_Code)

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
      this.WeeklyInspectionForm  = this.fb.group(
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
          wellName: this.fb.control(
            '',
            [
              Validators.required
            ]
          ),
          client: this.fb.control(
            '',
            [
               Validators.required
            ]
          ),
          eyeStatus: this.fb.control(
            '',
            [
               Validators.required
            ]
          ),
          eyeWeeklyFindings: this.fb.control(
            '',
            [
               
            ]
          ),
          firstAidStatus: this.fb.control(
            '',
            [
               Validators.required
            ]
          ),
          firstAidWeeklyFindings: this.fb.control(
            '',
            [
               
            ]
          ),
          scbaStatus: this.fb.control(
            '',
            [
               Validators.required
            ]
          ),
          scbaWeeklyFindings: this.fb.control(
            '',
            [
              
            ]
          ),
          scba30min: this.fb.control(
            '',
            [
               Validators.required
            ]
          ),
          scba15min: this.fb.control(
            '',
            [
              Validators.required
            ]
          ),

          scba10min: this.fb.control(
            '',
            [
              Validators.required
            ]
          ),
          portableGasStatus: this.fb.control(
            '',
            [
              Validators.required
            ]
          ),
          portableGasWeeklyFindings : this.fb.control(
            '',
            [
              
            ]
          ),

          portableGasMuti: this.fb.control(
            '',
            [
              Validators.required
            ]
          ),
          portableGasSingle: this.fb.control(
            '',
            [
              Validators.required
            ]
          ),
          expeiryDate: this.fb.control(
            '',
            [
              Validators.required
            ]
          ),

          firePumpStatus: this.fb.control(
            '',
            [
              Validators.required
            ]
          ),
          firePumpWeeklyFindings: this.fb.control(
            '',
            [
             
            ]
          ),
          weldingStatus: this.fb.control(
            '',
            [
              Validators.required
            ]
          ),
          weldingWeeklyFindings:this.fb.control(
            '',
            [
              
            ]
          ),
          windStatus: this.fb.control(
            '',
            [
              Validators.required
            ]
          ),
          windWeeklyFindings: this.fb.control(
            '',
            [
              
            ]
          ),

          smokeStatus: this.fb.control(
            '',
            [
              Validators.required
            ]
          ),
          smokeWeeklyFindings: this.fb.control(
            '',
            [
              
            ]
          ),
          fireExtinguishersStatus: this.fb.control(
            '',
            [
              Validators.required
            ]
          ),

          fireExtinguishersWeeklyFindings: this.fb.control(
            '',
            [
             
            ]
          ),
          derrickmanStatus: this.fb.control(
            '',
            [
              Validators.required
            ]
          ),
          derrickmanWeeklyFindings: this.fb.control(
            '',
            [
             
            ]
          ),

          workingStatus: this.fb.control(
            '',
            [
              Validators.required
            ]
          ),
          workingWeeklyFindings: this.fb.control(
            '',
            [
             
            ]
          ),
          portableLadderStatus: this.fb.control(
            '',
            [
              Validators.required
            ]
            
          ),
          portableLadderWeeklyFindings: this.fb.control(
            '',
            [
             
            ]
          ),
          safetyStatus: this.fb.control(
            '',
            [
              Validators.required,
            ]
          ),
          safetyWeeklyFindings: this.fb.control(
            '',
            [
              
            ]
          ),
          fallStatus: this.fb.control(
            '',
             [
              Validators.required
             ]           
          ),
          fallWeeklyFindings: this.fb.control(
            '',
            [
              
            ]
          ),
          craneStatus: this.fb.control(
            '',
            [
              Validators.required
            ]
          ),
          craneWeeklyFindings: this.fb.control(
            '',
            [
              
            ]
          ),
          forkStatus: this.fb.control(
            '',
            [
              Validators.required
            ]
          ),
          forkWeeklyFindings: this.fb.control(
            '',
            [
              
            ]
          ),
          droppedInspectionStatus: this.fb.control(
            '',
            [
              Validators.required
            ]
          ),
          droppedInspectionWeeklyFindings: this.fb.control(
            '',
            [
             
            ]
          ),
          electricalStatus: this.fb.control(
            '',
            [
              Validators.required
            ]
          ),
          electricalWeeklyFindings: this.fb.control(
            '',
            [
              
            ]
          ),
          circuitStatus: this.fb.control(
            '',
            [
              Validators.required
            ]
          ),
          circuitWeeklyFindings: this.fb.control(
            '',
            [
              
            ]
          ),
          earthingStatus: this.fb.control(
            '',
            [
              Validators.required
            ]
          ),
          earthingWeeklyFindings: this.fb.control(
            '',
            [
              
            ]
          ),
          earthingMaximum: this.fb.control(
            '',
            [
              Validators.required
            ]
          ),
          earthingMin: this.fb.control(
            '',
            [
              Validators.required
            ]
          ),
          code: this.fb.control(
            '',
            [
              Validators.required
            ]
          ),
          positionName: this.fb.control(
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

 
    
get id() {
  return this.WeeklyInspectionForm .get('id');
}
get rigId() {
  return this.WeeklyInspectionForm .get('rigId');
}
get date() {
  return this.WeeklyInspectionForm .get('date');
}
get wellName() {
  return this.WeeklyInspectionForm .get('wellName');
}

get client() {
  return this.WeeklyInspectionForm .get('client');
}
get eyeStatus() {
  return this.WeeklyInspectionForm .get('eyeStatus');
}
get eyeWeeklyFindings() {
  return this.WeeklyInspectionForm .get('eyeWeeklyFindings');
}
get firstAidStatus() {
  return this.WeeklyInspectionForm .get('firstAidStatus');
}
get firstAidWeeklyFindings() {
  return this.WeeklyInspectionForm .get('firstAidWeeklyFindings');
}
get scbaStatus() {
  return this.WeeklyInspectionForm .get('scbaStatus');
}
get scbaWeeklyFindings() {
  return this.WeeklyInspectionForm .get('scbaWeeklyFindings');
}

get scba30min() {
  return this.WeeklyInspectionForm .get('scba30min');
}
get scba15min() {
  return this.WeeklyInspectionForm .get('scba15min');
}
get scba10min() {
  return this.WeeklyInspectionForm .get('scba10min');
}

get portableGasStatus() {
  return this.WeeklyInspectionForm .get('portableGasStatus');
}
get portableGasWeeklyFindings() {
  return this.WeeklyInspectionForm .get('portableGasWeeklyFindings');
}
get portableGasMuti() {
  return this.WeeklyInspectionForm .get('portableGasMuti');
}

get portableGasSingle() {
  return this.WeeklyInspectionForm .get('portableGasSingle');
}
get expeiryDate() {
  return this.WeeklyInspectionForm .get('expeiryDate');
}
get firePumpStatus() {
  return this.WeeklyInspectionForm .get('firePumpStatus');
}

get firePumpWeeklyFindings() {
  return this.WeeklyInspectionForm .get('firePumpWeeklyFindings');
}
get weldingStatus() {
  return this.WeeklyInspectionForm .get('weldingStatus');
}
get weldingWeeklyFindings() {
  return this.WeeklyInspectionForm.get('weldingWeeklyFindings');
}
get windStatus() {
  return this.WeeklyInspectionForm .get('windStatus');
}
get windWeeklyFindings() {
  return this.WeeklyInspectionForm .get('windWeeklyFindings');
}
get smokeStatus() {
  return this.WeeklyInspectionForm .get('smokeStatus');
}

get smokeWeeklyFindings() {
  return this.WeeklyInspectionForm .get('smokeWeeklyFindings');
}
get fireExtinguishersStatus() {
  return this.WeeklyInspectionForm .get('fireExtinguishersStatus');
}
get fireExtinguishersWeeklyFindings() {
  return this.WeeklyInspectionForm .get('fireExtinguishersWeeklyFindings');
}

get derrickmanStatus() {
  return this.WeeklyInspectionForm .get('derrickmanStatus');
}
get derrickmanWeeklyFindings() {
  return this.WeeklyInspectionForm .get('derrickmanWeeklyFindings');
}
get workingStatus() {
  return this.WeeklyInspectionForm .get('workingStatus');
}

get workingWeeklyFindings() {
  return this.WeeklyInspectionForm .get('workingWeeklyFindings');
}
get portableLadderStatus() {
  return this.WeeklyInspectionForm .get('portableLadderStatus');
}
get portableLadderWeeklyFindings() {
  return this.WeeklyInspectionForm .get('portableLadderWeeklyFindings');
}
get safetyStatus() {
  return this.WeeklyInspectionForm .get('safetyStatus');
}
get safetyWeeklyFindings() {
  return this.WeeklyInspectionForm .get('safetyWeeklyFindings');
}
get fallStatus() {
  return this.WeeklyInspectionForm .get('fallStatus');
}
get fallWeeklyFindings() {
  return this.WeeklyInspectionForm .get('fallWeeklyFindings');
}
get craneStatus() {
  return this.WeeklyInspectionForm .get('craneStatus');
}

 get craneWeeklyFindings() {
  return this.WeeklyInspectionForm .get('craneWeeklyFindings');
}

get forkStatus() {
  return this.WeeklyInspectionForm .get('forkStatus');
}
get forkWeeklyFindings() {
  return this.WeeklyInspectionForm .get('forkWeeklyFindings');
}
get droppedInspectionStatus() {
  return this.WeeklyInspectionForm .get('droppedInspectionStatus');
}
get droppedInspectionWeeklyFindings() {
  return this.WeeklyInspectionForm .get('droppedInspectionWeeklyFindings');
}
get electricalStatus() {
  return this.WeeklyInspectionForm .get('electricalStatus');
}
get electricalWeeklyFindings() {
  return this.WeeklyInspectionForm .get('electricalWeeklyFindings');
}
get circuitStatus() {
  return this.WeeklyInspectionForm .get('circuitStatus');
}
get circuitWeeklyFindings() {
  return this.WeeklyInspectionForm .get('circuitWeeklyFindings');
}
get earthingStatus() {
  return this.WeeklyInspectionForm .get('earthingStatus');
}
get earthingWeeklyFindings() {
  return this.WeeklyInspectionForm .get('earthingWeeklyFindings');
}
 get earthingMaximum() {
  return this.WeeklyInspectionForm .get('earthingMaximum');
}
get earthingMin() {
  return this.WeeklyInspectionForm .get('earthingMin');
}
get code() {
  return this.WeeklyInspectionForm .get('code');
}
get positionName() {
  return this.WeeklyInspectionForm .get('positionName');
}
get name() {
  return this.WeeklyInspectionForm .get('name');
}

submitData() {

  if (this.WeeklyInspectionForm .valid) {

   const Formdata=new FormData()
  console.log("fforrrrrrrmmmmmmmmm",Formdata)

   Formdata.append('rigId', this.rigId?.value);
   Formdata.append('date', this.date?.value);
   Formdata.append('wellName', this.wellName?.value);
   Formdata.append('client', this.client?.value);

   Formdata.append('eyeStatus', this.eyeStatus?.value);
   Formdata.append('eyeWeeklyFindings', this.eyeWeeklyFindings?.value);
   Formdata.append('firstAidStatus', this.firstAidStatus?.value);

   Formdata.append('firstAidWeeklyFindings', this.firstAidWeeklyFindings?.value);
   Formdata.append('scbaStatus', this.scbaStatus?.value);
   Formdata.append('scbaWeeklyFindings', this.scbaWeeklyFindings?.value);

   Formdata.append('scba30min', this.scba30min?.value);
   Formdata.append('scba15min', this.scba15min?.value);
   Formdata.append('scba10min', this.scba10min?.value);

   Formdata.append('portableGasStatus', this.portableGasStatus?.value);
   Formdata.append('portableGasWeeklyFindings', this.portableGasWeeklyFindings?.value);
   Formdata.append('portableGasMuti', this.portableGasMuti?.value);

   Formdata.append('portableGasSingle', this.portableGasSingle?.value);
   Formdata.append('expeiryDate', this.expeiryDate?.value);
   Formdata.append('firePumpStatus', this.firePumpStatus?.value);

   Formdata.append('firePumpWeeklyFindings', this.firePumpWeeklyFindings?.value);
   Formdata.append('weldingStatus', this.weldingStatus?.value);
   Formdata.append('weldingWeeklyFindings',this.weldingWeeklyFindings?.value);

   Formdata.append('windStatus', this.windStatus?.value);
   Formdata.append('windWeeklyFindings', this.windWeeklyFindings?.value);
   Formdata.append('smokeStatus', this.smokeStatus?.value);

   Formdata.append('smokeWeeklyFindings', this.smokeWeeklyFindings?.value);
   Formdata.append('fireExtinguishersStatus', this.fireExtinguishersStatus?.value);
   Formdata.append('fireExtinguishersWeeklyFindings', this.fireExtinguishersWeeklyFindings?.value);

   Formdata.append('derrickmanStatus', this.derrickmanStatus?.value);
   Formdata.append('derrickmanWeeklyFindings', this.derrickmanWeeklyFindings?.value);
   Formdata.append('workingStatus', this.workingStatus?.value);

   Formdata.append('workingWeeklyFindings', this.workingWeeklyFindings?.value);
   Formdata.append('portableLadderStatus', this.portableLadderStatus?.value);
   Formdata.append('portableLadderWeeklyFindings', this.portableLadderWeeklyFindings?.value);

   Formdata.append('safetyStatus', this.safetyStatus?.value);
   Formdata.append('safetyWeeklyFindings', this.safetyWeeklyFindings?.value);
   Formdata.append('fallStatus', this.fallStatus?.value);

   Formdata.append('fallWeeklyFindings', this.fallWeeklyFindings?.value);
   Formdata.append('craneStatus', this.craneStatus?.value);
   Formdata.append('craneWeeklyFindings', this.craneWeeklyFindings?.value);

   Formdata.append('forkStatus', this.forkStatus?.value);
   Formdata.append('forkWeeklyFindings', this.forkWeeklyFindings?.value);
   Formdata.append('droppedInspectionStatus', this.droppedInspectionStatus?.value);
   Formdata.append('droppedInspectionWeeklyFindings', this.droppedInspectionWeeklyFindings?.value);

   Formdata.append('electricalStatus', this.electricalStatus?.value);
   Formdata.append('electricalWeeklyFindings', this.electricalWeeklyFindings?.value);
   Formdata.append('circuitStatus', this.circuitStatus?.value);
   Formdata.append('circuitWeeklyFindings', this.circuitWeeklyFindings?.value);
   Formdata.append('earthingStatus', this.earthingStatus?.value);
   Formdata.append('earthingWeeklyFindings', this.earthingWeeklyFindings?.value);
   Formdata.append('earthingMaximum', this.earthingMaximum?.value);
   Formdata.append('earthingMin', this.earthingMin?.value);
   Formdata.append('code', this.code?.value);
   Formdata.append('positionName', this.positionName?.value);
   Formdata.append('name', this.name?.value);

   Formdata.append('userID', this.UserJsonObj.ID);
   Formdata.append('userName', this.UserJsonObj.name);

   console.log(Formdata);


   console.log('after formData')
   this.WeeklyInspectionService.EditWeeklyInspection(Formdata,this.WeeklyInspectionId).subscribe({
     next: data => {
      console.log('from service')
       console.log(data.data)
       this.router.navigate(['/Dashboard/WeeklyInspection']);
      },
     error: error => {
       console.log("from Error")
       console.log(error)
     }
   });
  
  
  console.log("ffffffffffffffffffffffffffffffff",Formdata);
 }
 else {
    console.log('weeklyyy', this.WeeklyInspectionForm.value)

   console.log("E+++++====error in : ");
 }
}

toggleInstructions() {
  this.showInstructions = !this.showInstructions;
  this.arrowDown = !this.arrowDown;
}
toggleInstructions1() {
  this.showInstructions1 = !this.showInstructions1;
  this.arrowDown1 = !this.arrowDown1;
}
toggleInstructions2() {
  this.showInstructions2 = !this.showInstructions2;
  this.arrowDown2 = !this.arrowDown2;
}
toggleInstructions3() {
  this.showInstructions3 = !this.showInstructions3;
  this.arrowDown3 = !this.arrowDown3;
}
toggleInstructions4() {
  this.showInstructions4 = !this.showInstructions4;
  this.arrowDown4 = !this.arrowDown4;
}
toggleInstructions5() {
  this.showInstructions5 = !this.showInstructions5;
  this.arrowDown5 = !this.arrowDown5;
}
toggleInstructions6() {
  this.showInstructions6 = !this.showInstructions6;
  this.arrowDown6 = !this.arrowDown6;
}
toggleInstructions7() {
  this.showInstructions7 = !this.showInstructions7;
  this.arrowDown7 = !this.arrowDown7;
}
toggleInstructions8() {
  this.showInstructions8 = !this.showInstructions8;
  this.arrowDown8 = !this.arrowDown8;
}
toggleInstructions9() {
  this.showInstructions9 = !this.showInstructions9;
  this.arrowDown9 = !this.arrowDown9;
}
toggleInstructions10() {
  this.showInstructions10 = !this.showInstructions10;
  this.arrowDown10 = !this.arrowDown;
}
toggleInstructions11() {
  this.showInstructions11 = !this.showInstructions11;
  this.arrowDown11 = !this.arrowDown11;
}
toggleInstructions12() {
  this.showInstructions12 = !this.showInstructions12;
  this.arrowDown12 = !this.arrowDown12;
}
toggleInstructions13() {
  this.showInstructions13 = !this.showInstructions13;
  this.arrowDown13 = !this.arrowDown13;
}
toggleInstructions14() {
  this.showInstructions14 = !this.showInstructions14;
  this.arrowDown14 = !this.arrowDown14;
}
toggleInstructions15() {
  this.showInstructions15 = !this.showInstructions15;
  this.arrowDown15 = !this.arrowDown15;
}
toggleInstructions16() {
  this.showInstructions16 = !this.showInstructions16;
  this.arrowDown16 = !this.arrowDown16;
}
toggleInstructions17() {
  this.showInstructions17 = !this.showInstructions17;
  this.arrowDown17 = !this.arrowDown17;
}
toggleInstructions18() {
  this.showInstructions18 = !this.showInstructions18;
  this.arrowDown18 = !this.arrowDown18;
}

}
