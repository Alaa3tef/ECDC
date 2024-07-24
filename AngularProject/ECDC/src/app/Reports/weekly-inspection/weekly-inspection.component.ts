import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AddWeeklyInspectionServiceService } from 'Services/add-weekly-inspection-service.service';
import { DataService } from 'Services/data.service';
import { LoginService } from 'Services/login.service';
import { IRig } from 'SharedClasses/IRig';
import { Workbook } from 'exceljs';
import * as saveAs from 'file-saver';
@Component({
  selector: 'app-weekly-inspection',
  templateUrl: './weekly-inspection.component.html',
  styleUrls: ['./weekly-inspection.component.scss']
})
export class WeeklyInspectionComponent {
   weeklyInspectionForm !: FormGroup;
  ErrorMessage = '';
  json_data: any[] = [];
  rigList: IRig[] = []
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

  UserJsonString: any
  UserJsonObj: any

  CodeList: any;
  Code_NameID:number=0;
  Code_Name:string='';
  CodePositionID: number = 0;
  Code_Position:string='';

  User:any;

  constructor(private loginService: LoginService, private dataService: DataService, private AddNewWeeklyInspection: AddWeeklyInspectionServiceService, private fb: FormBuilder, private router: Router) {
    // this.calculateDuration();


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

    this. weeklyInspectionForm  = this.fb.group(
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

          weldingWeeklyFindings: this.fb.control(
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
      this.dataService.GetWeeklyInspections(this.User.ID,this.User.Role).subscribe({
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
    return this. weeklyInspectionForm .get('id');
  }
  get rigId() {
    return this. weeklyInspectionForm .get('rigId');
  }
  get date() {
    return this. weeklyInspectionForm .get('date');
  }
  get wellName() {
    return this. weeklyInspectionForm .get('wellName');
  }

  get client() {
    return this. weeklyInspectionForm .get('client');
  }
  get eyeStatus() {
    return this. weeklyInspectionForm .get('eyeStatus');
  }
  get eyeWeeklyFindings() {
    return this. weeklyInspectionForm .get('eyeWeeklyFindings');
  }
  get firstAidStatus() {
    return this. weeklyInspectionForm .get('firstAidStatus');
  }
  get firstAidWeeklyFindings() {
    return this. weeklyInspectionForm .get('firstAidWeeklyFindings');
  }
  get scbaStatus() {
    return this. weeklyInspectionForm .get('scbaStatus');
  }
  get scbaWeeklyFindings() {
    return this. weeklyInspectionForm .get('scbaWeeklyFindings');
  }

  get scba30min() {
    return this. weeklyInspectionForm .get('scba30min');
  }
  get scba15min() {
    return this. weeklyInspectionForm .get('scba15min');
  }
  get scba10min() {
    return this. weeklyInspectionForm .get('scba10min');
  }

  get portableGasStatus() {
    return this. weeklyInspectionForm .get('portableGasStatus');
  }
  get portableGasWeeklyFindings() {
    return this. weeklyInspectionForm .get('portableGasWeeklyFindings');
  }
  get portableGasMuti() {
    return this. weeklyInspectionForm .get('portableGasMuti');
  }

  get portableGasSingle() {
    return this. weeklyInspectionForm .get('portableGasSingle');
  }
  get expeiryDate() {
    return this. weeklyInspectionForm .get('expeiryDate');
  }
  get firePumpStatus() {
    return this. weeklyInspectionForm .get('firePumpStatus');
  }

  get firePumpWeeklyFindings() {
    return this. weeklyInspectionForm .get('firePumpWeeklyFindings');
  }
  get weldingStatus() {
    return this. weeklyInspectionForm .get('weldingStatus');
  }
  get weldingWeeklyFindings() {
    return this. weeklyInspectionForm .get('weldingWeeklyFindings');
  }

  get windStatus() {
    return this. weeklyInspectionForm .get('windStatus');
  }
  get windWeeklyFindings() {
    return this. weeklyInspectionForm .get('windWeeklyFindings');
  }
  get smokeStatus() {
    return this. weeklyInspectionForm .get('smokeStatus');
  }

  get smokeWeeklyFindings() {
    return this. weeklyInspectionForm .get('smokeWeeklyFindings');
  }
  get fireExtinguishersStatus() {
    return this. weeklyInspectionForm .get('fireExtinguishersStatus');
  }
  get fireExtinguishersWeeklyFindings() {
    return this. weeklyInspectionForm .get('fireExtinguishersWeeklyFindings');
  }

  get derrickmanStatus() {
    return this. weeklyInspectionForm .get('derrickmanStatus');
  }
  get derrickmanWeeklyFindings() {
    return this. weeklyInspectionForm .get('derrickmanWeeklyFindings');
  }
  get workingStatus() {
    return this. weeklyInspectionForm .get('workingStatus');
  }

  get workingWeeklyFindings() {
    return this. weeklyInspectionForm .get('workingWeeklyFindings');
  }
  get portableLadderStatus() {
    return this. weeklyInspectionForm .get('portableLadderStatus');
  }
  get portableLadderWeeklyFindings() {
    return this. weeklyInspectionForm .get('portableLadderWeeklyFindings');
  }
  get safetyStatus() {
    return this. weeklyInspectionForm .get('safetyStatus');
  }
  get safetyWeeklyFindings() {
    return this. weeklyInspectionForm .get('safetyWeeklyFindings');
  }
  get fallStatus() {
    return this. weeklyInspectionForm .get('fallStatus');
  }
  get fallWeeklyFindings() {
    return this. weeklyInspectionForm .get('fallWeeklyFindings');
  }
  get craneStatus() {
    return this. weeklyInspectionForm .get('craneStatus');
  }

   get craneWeeklyFindings() {
    return this. weeklyInspectionForm .get('craneWeeklyFindings');
  }

  get forkStatus() {
    return this. weeklyInspectionForm .get('forkStatus');
  }
  get forkWeeklyFindings() {
    return this. weeklyInspectionForm .get('forkWeeklyFindings');
  }
  get droppedInspectionStatus() {
    return this. weeklyInspectionForm .get('droppedInspectionStatus');
  }
  get droppedInspectionWeeklyFindings() {
    return this. weeklyInspectionForm .get('droppedInspectionWeeklyFindings');
  }
  get electricalStatus() {
    return this. weeklyInspectionForm .get('electricalStatus');
  }
  get electricalWeeklyFindings() {
    return this. weeklyInspectionForm .get('electricalWeeklyFindings');
  }
  get circuitStatus() {
    return this. weeklyInspectionForm .get('circuitStatus');
  }
  get circuitWeeklyFindings() {
    return this. weeklyInspectionForm .get('circuitWeeklyFindings');
  }
  get earthingStatus() {
    return this. weeklyInspectionForm .get('earthingStatus');
  }
  get earthingWeeklyFindings() {
    return this. weeklyInspectionForm .get('earthingWeeklyFindings');
  }
   get earthingMaximum() {
    return this. weeklyInspectionForm .get('earthingMaximum');
  }
  get earthingMin() {
    return this. weeklyInspectionForm .get('earthingMin');
  }
  get code() {
    return this. weeklyInspectionForm .get('code');
  }
  get positionName() {
    return this. weeklyInspectionForm .get('positionName');
  }
  get name() {
    return this. weeklyInspectionForm .get('name');
  }

  submitData() {

     if (this. weeklyInspectionForm .valid) {

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
      Formdata.append('weldingWeeklyFindings', this.weldingWeeklyFindings?.value);

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
      console.log(Formdata);


      console.log('after formData')
      this.AddNewWeeklyInspection.AddWeeklyInspection(Formdata).subscribe({
        next: data => {
          // console.log(this. weeklyInspectionForm );

          console.log('from service')
          console.log(data.data)
          location.reload();
        },
        error: error => {
          // console.log(this. weeklyInspectionForm );

          console.log("from Error")
          console.log(error)
        }
      });
     console.log(Formdata);
    }
    else {
      this.weeklyInspectionForm.markAllAsTouched()
       console.log('weeklyyy', this.weeklyInspectionForm.value)

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

  Download() {
    let workbook = new Workbook();

    let worksheet = workbook.addWorksheet("Weekly Inspection Data");


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

    let fname = "Weekly Inspection Report"

    //add data and file name and download
    workbook.xlsx.writeBuffer().then((data) => {
      let blob = new Blob([data], { type: 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet' });
      saveAs.saveAs(blob, fname + '-' + new Date().toUTCString() + '.xlsx');
    });
  }



}
