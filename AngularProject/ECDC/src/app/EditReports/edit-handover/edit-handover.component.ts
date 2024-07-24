import { DatePipe } from '@angular/common';
import { Component } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormArray } from '@angular/forms';
import { ActivatedRoute, ParamMap, Router } from '@angular/router';
import { AddDataService } from 'Services/add-data.service';
import { DataService } from 'Services/data.service';
import { HandoverService } from 'Services/handover.service';
import { LoginService } from 'Services/login.service';
import { IRig } from 'SharedClasses/IRig';
import { Workbook } from 'exceljs';
import * as saveAs from 'file-saver';

@Component({
  selector: 'app-edit-handover',
  templateUrl: './edit-handover.component.html',
  styleUrls: ['./edit-handover.component.scss']
})
export class EditHandoverComponent {
  HandoverId: any;
  Handover!: any;
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

  numshiftDrillTypes: number = 0;
  numvisits: number = 0;
  nummaterialRequested: number = 0;
  numhseInventory: number = 0;
  numhseEquipment: number = 0;

  EmpCodeList: any;

  comingEmpCode_NameID: number = 0;
  comingEmpCode_Name: string = '';

  leavingEmpCode_Name: string = '';
  leavingEmpCode_NameId: number = 0;

  shiftDrillTypesClicked: boolean = false;
  visitsClicked: boolean = false;
  materialRequestedClicked: boolean = false;
  hseInventoryClicked: boolean = false;
  hseEquipmentClicked: boolean = false;

  constructor(private datePipe: DatePipe,
    private loginService: LoginService,
    private dataService: DataService,
    private fb: FormBuilder,
    private router: Router,
    private activatedRoute: ActivatedRoute,
    private addDataService: AddDataService,
    private AddService: HandoverService) { }

  ngOnInit() {
    this.testUser = this.loginService.currentUser.getValue();
    this.activatedRoute.paramMap.subscribe((params: ParamMap) => {
      this.HandoverId = params.get("id");
      console.log(this.HandoverId)
    }),
      this.AddService.GetHandoverById(this.HandoverId, this.testUser.ID, this.testUser.Role).subscribe({
        next: data => {
          this.Handover = data.data
          console.log("this.Handover")
          console.log(this.Handover)
          this.numhseEquipment = this.Handover.hseEquipment.length;
          this.numhseInventory = this.Handover.hseInventory.length;
          this.nummaterialRequested = this.Handover.materialRequested.length;
          this.numshiftDrillTypes = this.Handover.shiftDrillTypes.length;
          this.numvisits = this.Handover.visits.length;
          this.comingEmpCode_Name = this.Handover.comingEmpName;
          this.leavingEmpCode_Name = this.Handover.leavingEmpName;

          // this.WeeklyClinic.fridgeComponents = this.fb.array(
          //   this.WeeklyClinic.map((item: { FridgeComponent: FridgeComponent; }) => this.fb.group(item.FridgeComponent))
          // );
          this.initializehseEquipment()
          this.initializehseInventory()
          this.initializematerialRequested()
          this.initializeshiftDrillTypes()
          this.initializevisits()

          this.HandoverForm.patchValue({
            id: data.data.id,
            rigId: data.data.rigId,
            wellName: data.data.wellName,
            client: data.data.client,
            leavingEmpCode: data.data.leavingEmpCode,
            leavingEmpName: data.data.leavingEmpName,
            comingEmpCode: data.data.comingEmpCode,
            comingEmpName: data.data.comingEmpName,
            stopCards: data.data.stopCards,
            monthlyStopCards: data.data.monthlyStopCards,
            openStopCards: data.data.openStopCards,
            drills: data.data.drills,
            monthlyDrills: data.data.monthlyDrills,
            safetyAlerts: data.data.safetyAlerts,
            monthlySafetyAlerts: data.data.monthlySafetyAlerts,
            weeklyInspection: data.data.weeklyInspection,
            internalAudit: data.data.internalAudit,
            externalAudit: data.data.externalAudit,
            medicalReport: data.data.medicalReport,
            trainingMatrix: data.data.trainingMatrix,
            rigMove: data.data.rigMove,
            incidentReport: data.data.incidentReport,
            trackingSheetClosedPoints: data.data.trackingSheetClosedPoints,
            potentialHazardReport: data.data.potentialHazardReport,
            shiftBrief: data.data.shiftBrief,
            qhseEngineer: data.data.qhseEngineer,
            shiftDateFrom: this.datePipe.transform(data.data.shiftDateFrom, 'yyyy-MM-dd'),
            shiftDateTo: this.datePipe.transform(data.data.shiftDateTo, 'yyyy-MM-dd'),
            shiftDrillTypes: data.data.shiftDrillTypes.map((shiftDrillType: { drillType: any; date: string | number | Date; }) => ({
              drillType: shiftDrillType.drillType,
              date: this.datePipe.transform(shiftDrillType.date, 'yyyy-MM-dd'),
            })),
            visits: data.data.visits.map((visit: { visitName: any; date: string | number | Date; }) => ({
              visitName: visit.visitName,
              date: this.datePipe.transform(visit.date, 'yyyy-MM-dd'),
            })),
            hseInventory: data.data.hseInventory.map((hseInventory: { item: any; stockAtStorage: any; releasedFromStorage: any; newlyRecieved: any; }) => ({
              item: hseInventory.item,
              stockAtStorage: hseInventory.stockAtStorage,
              releasedFromStorage: hseInventory.releasedFromStorage,
              newlyRecieved: hseInventory.newlyRecieved,
              isNewRow: false  // Mark existing rows as not new
            })),
            hseEquipment: data.data.hseEquipment.map((hseEquipment: { item: any; onSite: any; sentForMaintenance: any; }) => ({
              item: hseEquipment.item,
              onSite: hseEquipment.onSite,
              sentForMaintenance: hseEquipment.sentForMaintenance,
              isNewRow: false  // Mark existing rows as not new
            })),
            materialRequested: data.data.materialRequested.map((materialRequested: { pr: any; requiredItem: any; }) => ({
              pr: materialRequested.pr,
              requiredItem: materialRequested.requiredItem,
            })),
          });
        },
        error: err => {
          console.log(err)
        }
      })
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
          [],
          [
            Validators.required
          ]
        ),
        hseEquipment: this.fb.array(
          [],
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
        // othershiftDrillTypes: this.fb.array(
        //   [],
        //   [
        //     // Validators.required
        //   ]
        // ),
        // othervisits: this.fb.array(
        //   [],
        //   [
        //     // Validators.required
        //   ]
        // ),
        // otherhseInventory: this.fb.array(
        //   [],
        //   [
        //     // Validators.required
        //   ]
        // ),
        // otherhseEquipment: this.fb.array(
        //   [],
        //   [
        //     // Validators.required
        //   ]
        // ),
        // othermaterialRequested: this.fb.array(
        //   [],
        //   [
        //     // Validators.required
        //   ]
        // ),
        userID: this.fb.control(
          this.UserJsonObj.ID,
          [
            Validators.required
          ]
        )
      }
    );
  }

  onChange(event: any) {
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
  // get othershiftDrillTypes() {
  //   return this.HandoverForm.get('othershiftDrillTypes') as FormArray;
  // }
  // get othervisits() {
  //   return this.HandoverForm.get('othervisits') as FormArray;
  // }
  // get otherhseInventory() {
  //   return this.HandoverForm.get('otherhseInventory') as FormArray;
  // }
  // get otherhseEquipment() {
  //   return this.HandoverForm.get('otherhseEquipment') as FormArray;
  // }
  // get othermaterialRequested() {
  //   return this.HandoverForm.get('othermaterialRequested') as FormArray;
  // }

  initializevisits() {
    console.log("numvisits")
    console.log(this.numvisits)
    for (let i = 0; i < this.numvisits; i++) {
      this.addvisits();
    }
  }

  initializeshiftDrillTypes() {
    console.log("numshiftDrillTypes")
    console.log(this.numshiftDrillTypes)
    for (let i = 0; i < this.numshiftDrillTypes; i++) {
      this.addshiftDrillTypes();
    }
  }

  initializematerialRequested() {
    console.log("nummaterialRequested")
    console.log(this.nummaterialRequested)
    for (let i = 0; i < this.nummaterialRequested; i++) {
      this.addmaterialRequested();
    }
  }

  initializehseInventory() {
    console.log("numhseInventory")
    console.log(this.numhseInventory)
    for (let i = 0; i < this.numhseInventory; i++) {
      this.addhseInventory();
    }
  }

  initializehseEquipment() {
    console.log("numhseEquipment")
    console.log(this.numhseEquipment)
    for (let i = 0; i < this.numhseEquipment; i++) {
      this.addhseEquipment();
    }
  }

  createhseInventoryFormGroup(itemValue: string, isNewRow: boolean = false) {
    return this.fb.group({
      item: [itemValue, Validators.required],
      stockAtStorage: [0, Validators.required],
      releasedFromStorage: [0, Validators.required],
      newlyRecieved: [0, Validators.required],
      isNewRow: [isNewRow] // Track if the row is new or existing
    });
  }

  createhseEquipmentFormGroup(itemValue: string, isNewRow: boolean = false) {
    return this.fb.group({
      item: [itemValue, Validators.required],
      onSite: [0, Validators.required],
      sentForMaintenance: [0, Validators.required],
      isNewRow: [isNewRow] // Track if the row is new or existing
    });
  }
  creatematerialRequestedFormGroup() {
    return this.fb.group({
      pr: ['', Validators.required],
      requiredItem: ['', Validators.required],
    });
  }
  createvisitsFormGroup() {
    return this.fb.group({
      date: ['', Validators.required],
      visitName: ['', Validators.required],
    });
  }
  createshiftDrillTypesFormGroup() {
    return this.fb.group({
      date: ['', Validators.required],
      drillType: ['', Validators.required],
    });
  }

  // createotherhseInventoryFormGroup() {
  //   return this.fb.group({
  //     item: ['', Validators.required],
  //     stockAtStorage: ['', Validators.required],
  //     releasedFromStorage: ['', Validators.required],
  //     newlyRecieved: ['', Validators.required],
  //   });
  // }

  // createotherhseEquipmentFormGroup() {
  //   return this.fb.group({
  //     item: ['', Validators.required],
  //     onSite: ['', Validators.required],
  //     sentForMaintenance: ['', Validators.required],
  //   });
  // }
  // createothermaterialRequestedFormGroup() {
  //   return this.fb.group({
  //     pr: ['', Validators.required],
  //     requiredItem: ['', Validators.required],
  //   });
  // }
  // createothervisitsFormGroup() {
  //   return this.fb.group({
  //     date: ['', Validators.required],
  //     visitName: ['', Validators.required],
  //   });
  // }
  // createothershiftDrillTypesFormGroup() {
  //   return this.fb.group({
  //     date: ['', Validators.required],
  //     drillType: ['', Validators.required],
  //   });
  // }

  addhseEquipment() {
    this.hseEquipment.push(this.createhseEquipmentFormGroup('',true));
    this.hseEquipmentClicked = true;
  }
  addhseInventory() {
    this.hseInventory.push(this.createhseInventoryFormGroup('',true));
    this.hseInventoryClicked = true;
  }

  addvisits() {
    this.visits.push(this.createvisitsFormGroup());
    this.visitsClicked = true;
  }
  addshiftDrillTypes() {
    this.shiftDrillTypes.push(this.createshiftDrillTypesFormGroup());
    this.shiftDrillTypesClicked = true;
  }

  addmaterialRequested() {
    this.materialRequested.push(this.creatematerialRequestedFormGroup());
    this.materialRequestedClicked = true;
  }

  // addotherhseEquipment() {
  //   this.otherhseEquipment.push(this.createotherhseEquipmentFormGroup());
  //   this.hseEquipmentClicked = true;
  // }
  // addotherhseInventory() {
  //   this.otherhseInventory.push(this.createotherhseInventoryFormGroup());
  //   this.hseInventoryClicked = true;
  // }

  // addothervisits() {
  //   this.othervisits.push(this.createothervisitsFormGroup());
  //   this.visitsClicked = true;
  // }
  // addothershiftDrillTypes() {
  //   this.othershiftDrillTypes.push(this.createothershiftDrillTypesFormGroup());
  //   this.shiftDrillTypesClicked = true;
  // }

  // addothermaterialRequested() {
  //   this.othermaterialRequested.push(this.createothermaterialRequestedFormGroup());
  //   this.materialRequestedClicked = true;
  // }

  submitData() {
    console.log("this.HandoverForm.value")
    console.log(this.HandoverForm.value)
    if (this.HandoverForm.valid) {
      this.submitted = false
      this.AddService.EditHandover(this.HandoverId, this.HandoverForm.value).subscribe({
        next: data => {
          console.log('from service')
          console.log(data)
          this.router.navigate(['Dashboard/Handover']);
        },
        error: error => {
          console.log("from Error")
          console.log(error)
        }
      });
      // console.log(Formdata);
    }
    else {
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
    } else if ((this.selectedShiftDateTo.getDate()) < (this.selectedShiftDateFrom.getDate())) {
      this.ValidDate = false;
    }
    console.log(this.ValidDate)
  }

  selectedMenace(event: any) {
    console.log("event.target.value")
    console.log(event.target.value)
    this.dataService.GetEmpCodeByCode(event.target.value).subscribe({
      next: data => {
        this.comingEmpCode_NameID = data.data.id
        this.comingEmpCode_Name = data.data.name,
          console.log(data.data)
        console.log("this.comingEmpCode_Name")
        console.log(this.comingEmpCode_Name)
      },
      error: err => {
        this.ErrorMessage = err,
          console.log(err)
      }
    })
  }

  selectedMenace2(event: any) {
    console.log("event.target.value")
    console.log(event.target.value)
    this.dataService.GetEmpCodeByCode(event.target.value).subscribe({
      next: data => {
        this.leavingEmpCode_NameId = data.data.id
        this.leavingEmpCode_Name = data.data.name,
          console.log(data.data)
        console.log("this.leavingEmpName_Name")
        console.log(this.leavingEmpCode_Name)
      },
      error: err => {
        this.ErrorMessage = err,
          console.log(err)
      }
    })
  }

  ChangeShiftDateFrom(event: any) {
    console.log(event.target.value)
    this.selectedShiftDateFrom = new Date(event.target.value)
    if ((this.selectedShiftDateTo.getDate()) >= (this.selectedShiftDateFrom.getDate())) {
      this.ValidDate = true;
    } else if ((this.selectedShiftDateTo.getDate()) < (this.selectedShiftDateFrom.getDate())) {
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
