import { DatePipe } from '@angular/common';
import { Component } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormArray } from '@angular/forms';
import { Router } from '@angular/router';
import { AddDataService } from 'Services/add-data.service';
import { DataService } from 'Services/data.service';
import { HandoverService } from 'Services/handover.service';
import { LoginService } from 'Services/login.service';
import { IRig } from 'SharedClasses/IRig';
import { Workbook } from 'exceljs';
import * as saveAs from 'file-saver';

@Component({
  selector: 'app-add-handover',
  templateUrl: './add-handover.component.html',
  styleUrls: ['./add-handover.component.scss']
})
export class AddHandoverComponent {
  HandoverForm!: FormGroup;
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
  ValidDate: boolean = true;
  selectedShiftDateTo!: Date;
  selectedShiftDateFrom!: Date;

  EmpCodeList: any;

  comingEmpCode_NameID:number=0;
  comingEmpCode_Name:string='';

  leavingEmpCode_Name:string='';
  leavingEmpCode_NameId:number=0;

  shiftDrillTypesClicked:boolean=false;
  visitsClicked:boolean=false;
  materialRequestedClicked:boolean=false;

  constructor(private datePipe: DatePipe,
    private loginService: LoginService,
    private dataService: DataService,
    private fb: FormBuilder,
    private router: Router,
    private addDataService: AddDataService,
    private AddService: HandoverService) { }

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
    this.dataService.GetEmpCode().subscribe({
      next: data => {
        this.EmpCodeList = data.data,
          console.log("this.EmpCodeList")
        console.log(this.EmpCodeList)
      },
      error: err => {
        this.ErrorMessage = err,
          console.log("this.ErrorMessage")
        console.log(this.ErrorMessage)
      }
    }),

    this.User = JSON.stringify(this.loginService.currentUser.getValue())//this.loginService.currentUser.getValue();
    console.log("uuuuuuussssssseeeeerrrrbbbbbvvvcc")



    this.AddService.GetHandoverForExcel(this.testUser.ID, this.testUser.Role).subscribe({
      next: data => this.json_data = data.data,
      error: err => this.ErrorMessage = err
    });

    this.UserJsonString = JSON.stringify(this.loginService.currentUser.getValue())
    this.UserJsonObj = JSON.parse(this.UserJsonString);

    this.HandoverForm = this.fb.group(
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
        shiftDateTo: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        shiftDateFrom: this.fb.control(
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
        leavingEmpCode: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        leavingEmpName: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        comingEmpCode: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        comingEmpName: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        stopCards: this.fb.control(
          0,
          [
            Validators.required
          ]
        ),
        monthlyStopCards: this.fb.control(
          0,
          [
            Validators.required
          ]
        ),
        openStopCards: this.fb.control(
          0,
          [
            Validators.required
          ]
        ),
        drills: this.fb.control(
          0,
          [
            Validators.required
          ]
        ),
        monthlyDrills: this.fb.control(
          0,
          [
            Validators.required
          ]
        ),
        safetyAlerts: this.fb.control(
          0,
          [
            Validators.required
          ]
        ),
        monthlySafetyAlerts: this.fb.control(
          0,
          [
            Validators.required
          ]
        ),
        weeklyInspection: this.fb.control(
          0,
          [
            Validators.required
          ]
        ),
        internalAudit: this.fb.control(
          0,
          [
            Validators.required
          ]
        ),
        externalAudit: this.fb.control(
          0,
          [
            Validators.required
          ]
        ),
        medicalReport: this.fb.control(
          0,
          [
            Validators.required
          ]
        ),
        trainingMatrix: this.fb.control(
          0,
          [
            Validators.required
          ]
        ),
        rigMove: this.fb.control(
          0,
          [
            Validators.required
          ]
        ),
        incidentReport: this.fb.control(
          0,
          [
            Validators.required
          ]
        ),
        trackingSheetClosedPoints: this.fb.control(
          0,
          [
            Validators.required
          ]
        ),
        potentialHazardReport: this.fb.control(
          0,
          [
            Validators.required
          ]
        ),
        shiftBrief: this.fb.control(
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
        shiftDrillTypes: this.fb.array(
          [],
          [
            // Validators.required
          ]
        ),
        visits: this.fb.array(
          [],
          [
            // Validators.required
          ]
        ),
        hseInventory: this.fb.array(
          [
            this.createhseInventoryFormGroup('White Helmet'),
            this.createhseInventoryFormGroup('Blue Helmet'),
            this.createhseInventoryFormGroup('Green Helmet'),
            this.createhseInventoryFormGroup('Safety Boot'),
            this.createhseInventoryFormGroup('Safety Shoes'),
            this.createhseInventoryFormGroup('Rubber Safety Boot'),
            this.createhseInventoryFormGroup('Normal Coverall'),
            this.createhseInventoryFormGroup('Winter Coverall'),
            this.createhseInventoryFormGroup('Impact Gloves'),
            this.createhseInventoryFormGroup('Rubber Gloves'),
            this.createhseInventoryFormGroup('Mechanic Gloves'),
            this.createhseInventoryFormGroup('Electrician Gloves'),
            this.createhseInventoryFormGroup('Thermal Gloves'),
            this.createhseInventoryFormGroup('Clear Safety Glassess'),
            this.createhseInventoryFormGroup('Dark Safety Glassess'),
            this.createhseInventoryFormGroup('Safety Goggles'),
            this.createhseInventoryFormGroup('Welding Shield'),
            this.createhseInventoryFormGroup('Face Shield'),
            this.createhseInventoryFormGroup('Ear Muff'),
            this.createhseInventoryFormGroup('Ear Plug'),
            this.createhseInventoryFormGroup('Rain Suit'),
            this.createhseInventoryFormGroup('Apron'),
            this.createhseInventoryFormGroup('Disposable Coveralls'),
            this.createhseInventoryFormGroup('Norm Suits'),
            this.createhseInventoryFormGroup('Safety Harness'),
            this.createhseInventoryFormGroup('Double Lanyard'),
            this.createhseInventoryFormGroup('Single Lanyard'),
            this.createhseInventoryFormGroup('Man Riding Harness'),
            this.createhseInventoryFormGroup('Fall Arrestor'),
            this.createhseInventoryFormGroup('Dust Mask'),
            this.createhseInventoryFormGroup('Fire Hose'),
            this.createhseInventoryFormGroup('Fire Nozzle'),
            this.createhseInventoryFormGroup('Foam Mixer'),
            this.createhseInventoryFormGroup('Foam Nozzle'),
            this.createhseInventoryFormGroup('Fire Blanket'),
            this.createhseInventoryFormGroup('Foam For Firefighting'),
            this.createhseInventoryFormGroup('Fire Tab'),
            this.createhseInventoryFormGroup('Push-Pull Stick'),
            this.createhseInventoryFormGroup('Finger Saver'),
            this.createhseInventoryFormGroup('Rescue At Height Kit'),
            this.createhseInventoryFormGroup('Working At Height Tools Kit'),
            this.createhseInventoryFormGroup('Spill Kit'),
            this.createhseInventoryFormGroup('High Visibility Vest'),
            this.createhseInventoryFormGroup('Caution Tabe'),
            this.createhseInventoryFormGroup('First Aid Kit'),
            this.createhseInventoryFormGroup('Stretcher'),
            this.createhseInventoryFormGroup('Smoke Detector'),
            this.createhseInventoryFormGroup('Eye wash'),
            this.createhseInventoryFormGroup('Wind Sock'),
            this.createhseInventoryFormGroup('Helmet suspension'),
            this.createhseInventoryFormGroup('Helmet Strap'),
            this.createhseInventoryFormGroup('Eye Wash'),
            this.createhseInventoryFormGroup('Stretcher'),
            this.createhseInventoryFormGroup('Fire Blanket'),
            this.createhseInventoryFormGroup('First Aid Box'),
          ],
          [
            Validators.required
          ]
        ),
        hseEquipment: this.fb.array(
          [
            this.createhseEquipmentFormGroup('Single H2S Detector'),
            this.createhseEquipmentFormGroup('Multi Gas Detector'),
            this.createhseEquipmentFormGroup('Fixed H2S Detector'),
            this.createhseEquipmentFormGroup('ELSA'),
            this.createhseEquipmentFormGroup('SCBA'),
            this.createhseEquipmentFormGroup('Aneomometer'),
            this.createhseEquipmentFormGroup('Norm Device'),
            this.createhseEquipmentFormGroup('DCP Fire Extinguisher (6 kg )'),
            this.createhseEquipmentFormGroup('DCP Fire Extinguisher (12 kg )'),
            this.createhseEquipmentFormGroup('DCP Fire Extinguisher (25 kg )'),
            this.createhseEquipmentFormGroup('Co2 Fire Extinguisher (6 kg )'),
            this.createhseEquipmentFormGroup('Co2 Fire Extinguisher (10 kg )'),
            this.createhseEquipmentFormGroup('Foam Fire Extinguisher (45 L)'),
            this.createhseEquipmentFormGroup('Fire Extinguisher Class K'),
            this.createhseEquipmentFormGroup('O2 Medical Cylinder'),
          ],
          [
            Validators.required
          ]
        ),
        materialRequested: this.fb.array(
          [],
          [
            // Validators.required
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

  onChange(event:any){
    console.log("before")
    console.log(this.shiftBrief?.value)
    const textareaContent = this.shiftBrief?.value;
    const formattedContent = textareaContent.replace(/\n/g, '\n');

    this.shiftBrief?.setValue(formattedContent)
    console.log("after")
    console.log(this.shiftBrief?.value)
  }


  get id() {
    return this.HandoverForm.get('id');
  }
  get rigId() {
    return this.HandoverForm.get('rigId');
  }
  get shiftDateFrom() {
    return this.HandoverForm.get('shiftDateFrom');
  }
  get shiftDateTo() {
    return this.HandoverForm.get('shiftDateTo');
  }
  get wellName() {
    return this.HandoverForm.get('wellName');
  }
  get client() {
    return this.HandoverForm.get('client');
  }
  get leavingEmpCode() {
    return this.HandoverForm.get('leavingEmpCode');
  }
  get leavingEmpName() {
    return this.HandoverForm.get('leavingEmpName');
  }
  get comingEmpCode() {
    return this.HandoverForm.get('comingEmpCode');
  }
  get comingEmpName() {
    return this.HandoverForm.get('comingEmpName');
  }
  get stopCards() {
    return this.HandoverForm.get('stopCards');
  }
  get monthlyStopCards() {
    return this.HandoverForm.get('monthlyStopCards');
  }
  get openStopCards() {
    return this.HandoverForm.get('openStopCards');
  }
  get drills() {
    return this.HandoverForm.get('drills');
  }
  get monthlyDrills() {
    return this.HandoverForm.get('monthlyDrills');
  }
  get safetyAlerts() {
    return this.HandoverForm.get('safetyAlerts');
  }
  get monthlySafetyAlerts() {
    return this.HandoverForm.get('monthlySafetyAlerts');
  }
  get weeklyInspection() {
    return this.HandoverForm.get('weeklyInspection');
  }
  get internalAudit() {
    return this.HandoverForm.get('internalAudit');
  }
  get externalAudit() {
    return this.HandoverForm.get('externalAudit');
  }
  get medicalReport() {
    return this.HandoverForm.get('medicalReport');
  }
  get trainingMatrix() {
    return this.HandoverForm.get('trainingMatrix');
  }
  get rigMove() {
    return this.HandoverForm.get('rigMove');
  }
  get incidentReport() {
    return this.HandoverForm.get('incidentReport');
  }
  get trackingSheetClosedPoints() {
    return this.HandoverForm.get('trackingSheetClosedPoints');
  }
  get potentialHazardReport() {
    return this.HandoverForm.get('potentialHazardReport');
  }
  get shiftBrief() {
    return this.HandoverForm.get('shiftBrief');
  }

  get qhseEngineer() {
    return this.HandoverForm.get('qhseEngineer');
  }
  get shiftDrillTypes() {
    return this.HandoverForm.get('shiftDrillTypes') as FormArray;
  }
  get visits() {
    return this.HandoverForm.get('visits') as FormArray;
  }
  get hseInventory() {
    return this.HandoverForm.get('hseInventory') as FormArray;
  }
  get hseEquipment() {
    return this.HandoverForm.get('hseEquipment') as FormArray;
  }
  get materialRequested() {
    return this.HandoverForm.get('materialRequested') as FormArray;
  }

  createhseInventoryFormGroup(itemValue: string, isNewRow: boolean = false) {
    return this.fb.group({
      item : [itemValue, Validators.required],
      stockAtStorage : [0, Validators.required],
      releasedFromStorage: [0, Validators.required],
      newlyRecieved: [0, Validators.required],
      isNewRow: [isNewRow] // Track if the row is new or existing
    });
  }

  createhseEquipmentFormGroup(itemValue: string, isNewRow: boolean = false) {
    return this.fb.group({
      item : [itemValue, Validators.required],
      onSite : [0, Validators.required],
      sentForMaintenance: [0, Validators.required],
      isNewRow: [isNewRow] // Track if the row is new or existing
    });
  }
  creatematerialRequestedFormGroup() {
    return this.fb.group({
      pr : ['', Validators.required],
      requiredItem : ['', Validators.required],
    });
  }
  createvisitsFormGroup() {
    return this.fb.group({
      date : ['', Validators.required],
      visitName : ['', Validators.required],
    });
  }
  createshiftDrillTypesFormGroup() {
    return this.fb.group({
      date : ['', Validators.required],
      drillType : ['', Validators.required],
    });
  }

  addhseEquipment() {
    this.hseEquipment.push(this.createhseEquipmentFormGroup('',true));
  }
  addhseInventory() {
    this.hseInventory.push(this.createhseInventoryFormGroup('',true));
  }

  addvisits() {
    this.visits.push(this.createvisitsFormGroup());
    this.visitsClicked=true;
  }
  addshiftDrillTypes() {
    this.shiftDrillTypes.push(this.createshiftDrillTypesFormGroup());
    this.shiftDrillTypesClicked=true;
  }

  addmaterialRequested() {
    this.materialRequested.push(this.creatematerialRequestedFormGroup());
    this.materialRequestedClicked=true;
  }

  submitData() {
    console.log("this.HandoverForm.value")
    console.log(this.HandoverForm.value)
    if (this.HandoverForm.valid) {
      this.submitted = false
      this.AddService.AddHandover(this.HandoverForm.value).subscribe({
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
      this.HandoverForm.markAllAsTouched()
      this.submitted = true;
      console.log("E+++++====error in : ");
      console.log(this.HandoverForm.errors);
    }
  }

  ChangeShiftDateTo(event: any) {
    console.log(event.target.value)
    this.selectedShiftDateTo = new Date(event.target.value)
    if ((this.selectedShiftDateTo.getDate()) >= (this.selectedShiftDateFrom.getDate())) {
      this.ValidDate = true;
    } else if((this.selectedShiftDateTo.getDate()) < (this.selectedShiftDateFrom.getDate())) {
      this.ValidDate = false;
    }
    console.log(this.ValidDate)
  }

  selectedMenace(event: any) {
    console.log("event.target.value")
    console.log(event.target.value)
    this.dataService.GetEmpCodeByCode(event.target.value).subscribe({
      next:data=>{
        this.comingEmpCode_NameID=data.data.id
        this.comingEmpCode_Name=data.data.name,
        console.log(data.data)
        console.log("this.comingEmpCode_Name")
        console.log(this.comingEmpCode_Name)
      },
      error:err=>{
        this.ErrorMessage=err,
        console.log(err)
      }
    })
  }

  selectedMenace2(event: any) {
    console.log("event.target.value")
    console.log(event.target.value)
    this.dataService.GetEmpCodeByCode(event.target.value).subscribe({
      next:data=>{
        this.leavingEmpCode_NameId=data.data.id
        this.leavingEmpCode_Name=data.data.name,
        console.log(data.data)
        console.log("this.leavingEmpName_Name")
        console.log(this.leavingEmpCode_Name)
      },
      error:err=>{
        this.ErrorMessage=err,
        console.log(err)
      }
    })
  }

  ChangeShiftDateFrom(event: any) {
    console.log(event.target.value)
    this.selectedShiftDateFrom = new Date(event.target.value)
    if ((this.selectedShiftDateTo.getDate()) >= (this.selectedShiftDateFrom.getDate())) {
      this.ValidDate = true;
    } else if((this.selectedShiftDateTo.getDate()) < (this.selectedShiftDateFrom.getDate())) {
      this.ValidDate = false;
    }
    console.log(this.ValidDate)
  }

  Download() {
    let workbook = new Workbook();

    let worksheet = workbook.addWorksheet("Handover Data");


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

    let fname = "Handover Report"

    //add data and file name and download
    workbook.xlsx.writeBuffer().then((data) => {
      let blob = new Blob([data], { type: 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet' });
      saveAs.saveAs(blob, fname + '-' + new Date().toUTCString() + '.xlsx');
    });
  }

}
