import { DatePipe } from '@angular/common';
import { Component } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormArray } from '@angular/forms';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';
import { AddDataService } from 'Services/add-data.service';
import { AddNewDailyLiftingReportService } from 'Services/add-new-daily-lifting-report.service';
import { DataService } from 'Services/data.service';
import { LoginService } from 'Services/login.service';
import { IRig } from 'SharedClasses/IRig';
import { Workbook } from 'exceljs';
import * as saveAs from 'file-saver';

@Component({
  selector: 'app-edit-daily-lifting-report',
  templateUrl: './edit-daily-lifting-report.component.html',
  styleUrls: ['./edit-daily-lifting-report.component.scss']
})
export class EditDailyLiftingReportComponent {
  DailyLiftingReportId: any;
  DailyLiftingReport!: any;
  DailyLiftingReportForm!: FormGroup;
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

  numSummaryDailyList: number = 0;
  numPermitsToWorkList: number = 0;
  numDailyRecordStacticsList: number = 0;

  PermitsToWorkListClicked: boolean = false;
  SummaryDailyListClicked: boolean = false;

  EmpCodeList: any;

  liftingEngieerName_NameID: number = 0;
  liftingEngieerCode_Name: string = '';

  MobileCraneList: any;

  MobileCraneName_NameID: number = 0;
  MobileCrane_Name: string = '';

  MobileCrane_TypeID: number = 0;
  MobileCrane_Type: string = '';

  MobileCrane_CapacityID: number = 0;
  MobileCrane_Capacity: string = '';

  MobileCrane_ChasisNoId: number = 0;
  MobileCrane_ChasisNo: string = '';

  MobileCrane_DateofNextInspectionID: number = 0;
  MobileCrane_DateofNextInspection: string = '';

  MobileCrane_DateofLastInspectionId: number = 0;
  MobileCrane_DateofLastInspection: string = '';

  ForkDailyLiftingList: any;

  ForkDailyLiftingName_NameID: number = 0;
  ForkDailyLifting_Name: string = '';

  ForkDailyLifting_TypeID: number = 0;
  ForkDailyLifting_Type: string = '';

  ForkDailyLifting_CapacityID: number = 0;
  ForkDailyLifting_Capacity: string = '';

  ForkDailyLifting_ChasisNoId: number = 0;
  ForkDailyLifting_ChasisNo: string = '';

  ForkDailyLifting_DateofNextInspectionID: number = 0;
  ForkDailyLifting_DateofNextInspection: string = '';

  ForkDailyLifting_DateofLastInspectionId: number = 0;
  ForkDailyLifting_DateofLastInspection: string = '';

  constructor(private datePipe: DatePipe,
    private loginService: LoginService,
    private dataService: DataService,
    private fb: FormBuilder,
    private router: Router,
    private activatedRoute: ActivatedRoute,
    private addDataService: AddDataService,
    private AddService: AddNewDailyLiftingReportService) { }

  ngOnInit() {
    this.testUser = this.loginService.currentUser.getValue();
    this.activatedRoute.paramMap.subscribe((params: ParamMap) => {
      this.DailyLiftingReportId = params.get("id");
      console.log(this.DailyLiftingReportId)
      console.log("this.DailyLiftingReportIddddddddddddddddddddddddddddddddddddddddd")
    }),
      this.AddService.GetDailyLiftingReportById(this.DailyLiftingReportId, this.testUser.ID, this.testUser.Role).subscribe({
        next: data => {
          this.DailyLiftingReport = data.data
          console.log("this.DailyLiftingReportttttttttttttttttttttttttttttttttttttt")
          console.log(this.DailyLiftingReport)
          this.ForkDailyLifting_Name = data.data.forkName,
            this.ForkDailyLifting_Type = data.data.forkType,
            this.ForkDailyLifting_Capacity = data.data.forkCapacity,
            this.ForkDailyLifting_ChasisNo = data.data.forkChasisNo,
            this.ForkDailyLifting_DateofLastInspection = data.data.forkDateofLastInspection,
            this.ForkDailyLifting_DateofNextInspection = data.data.forkDateofNextInspection,
            this.MobileCrane_Name = data.data.mobileCraneName,
            this.MobileCrane_Type = data.data.type,
            this.MobileCrane_Capacity = data.data.capacity,
            this.MobileCrane_ChasisNo = data.data.chasisNo,
            this.MobileCrane_DateofLastInspection = data.data.dateofLastInspection,
            this.MobileCrane_DateofNextInspection = data.data.dateofNextInspection,
            this.liftingEngieerCode_Name = data.data.liftingEngieerName
          console.log("this.liftingEngieerCode_Name", this.liftingEngieerName)

          console.log("data.data.summaryDailyListDTOs", data.data.summaryDailyListDTOs.summaryDailyListName)
          console.log("data.data.permitsToWorkListDTOs", data.data.permitsToWorkListDTOs)
          console.log("data.data.dailyRecordStacticsListDTOs", data.data.dailyRecordStacticsListDTOs)

          this.numDailyRecordStacticsList = this.DailyLiftingReport.dailyRecordStacticsListDTOs.length;
          this.numPermitsToWorkList = this.DailyLiftingReport.permitsToWorkListDTOs.length;
          this.numSummaryDailyList = this.DailyLiftingReport.summaryDailyListDTOs.length;
          console.log("this.numPermitsToWorkList", this.numPermitsToWorkList)
          console.log("this.numSummaryDailyList", this.numSummaryDailyList)
          this.initializeDailyRecordStacticsList();
          this.initializePermitsToWorkList();
          this.initializeSummaryDailyList();

          this.DailyLiftingReportForm.patchValue({
            id: data.data.id,
            rigId: data.data.rigId,
            date: this.datePipe.transform(data.data.date, 'yyyy-MM-dd'),
            mobileCraneName: data.data.mobileCraneName,
            type: data.data.type,
            chasisNo: data.data.chasisNo,
            capacity: data.data.capacity,
            dateofLastInspection: data.data.dateofLastInspection,
            dateofNextInspection: data.data.dateofNextInspection,
            forkName: data.data.forkName,
            forkType: data.data.forkType,
            forkChasisNo: data.data.forkChasisNo,
            forkCapacity: data.data.forkCapacity,
            forkDateofLastInspection: data.data.forkDateofLastInspection,
            forkDateofNextInspection: data.data.forkDateofNextInspection,
            liftingEngieerCode: data.data.liftingEngieerCode,
            liftingEngieerName: data.data.liftingEngieerName,

            // userID: data.data.userID,
            summaryDailyListDTOs: data.data.summaryDailyListDTOs.map((summaryDaily: { item: any; summaryDailyListName: any; }) => ({
              item: summaryDaily.item,
              summaryDailyListName: summaryDaily.summaryDailyListName,
            })),
            dailyRecordStacticsListDTOs: data.data.dailyRecordStacticsListDTOs.map((dailyRecord: { item: any; dailyRecordStacticsListName: any; }) => ({
              item: dailyRecord.item,
              dailyRecordStacticsListName: dailyRecord.dailyRecordStacticsListName,
              isNewRow: false  // Mark existing rows as not new
            })),
            permitsToWorkListDTOs: data.data.permitsToWorkListDTOs.map((permitsToWork: { permitsToWorkListName: any; item: any; }) => ({
              permitsToWorkListName: permitsToWork.permitsToWorkListName,
              item: permitsToWork.item,
              isNewRow: false  // Mark existing rows as not new
            }))
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
    this.AddService.GetMobileCrane().subscribe({
      next: data => {
        this.MobileCraneList = data.data,
          console.log("this.MobileCraneList")
        console.log(this.MobileCraneList)
      },
      error: err => {
        this.ErrorMessage = err,
          console.log("this.ErrorMessage")
        console.log(this.ErrorMessage)
      }
    }),
      this.AddService.GetForkDailyLifting().subscribe({
        next: data => {
          this.ForkDailyLiftingList = data.data,
            console.log("this.ForkDailyLifting")
          console.log(this.ForkDailyLiftingList)
        },
        error: err => {
          this.ErrorMessage = err,
            console.log("this.ErrorMessage")
          console.log(this.ErrorMessage)
        }
      }),
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



    this.AddService.GetDailyLiftingReport(this.testUser.ID, this.testUser.Role).subscribe({
      next: data => {
        this.json_data = data.data;
        console.log("GetDailyLiftingReport", this.json_data);

      },
      error: err => this.ErrorMessage = err
    });

    this.UserJsonString = JSON.stringify(this.loginService.currentUser.getValue())
    this.UserJsonObj = JSON.parse(this.UserJsonString);
    this.DailyLiftingReportForm = this.fb.group(
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
        liftingEngieerCode: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        liftingEngieerName: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        type: this.fb.control(
          0,
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
        chasisNo: this.fb.control(
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
        dateofLastInspection: this.fb.control(
          '',
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
        forkType: this.fb.control(
          0,
          [
            Validators.required
          ]
        ),
        forkName: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        forkChasisNo: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        forkCapacity: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        forkDateofLastInspection: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        forkDateofNextInspection: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        permitsToWorkListDTOs: this.fb.array(
          [],
          [
            //  Validators.required
          ]
        ),
        summaryDailyListDTOs: this.fb.array(
          [],
          [
            //  Validators.required
          ]
        ),
        dailyRecordStacticsListDTOs: this.fb.array(
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

  get id() {
    return this.DailyLiftingReportForm.get('id');
  }
  get rigId() {
    return this.DailyLiftingReportForm.get('rigId');
  }
  get date() {
    return this.DailyLiftingReportForm.get('date');
  }
  get liftingEngieerCode() {
    return this.DailyLiftingReportForm.get('liftingEngieerCode');
  }
  get liftingEngieerName() {
    return this.DailyLiftingReportForm.get('liftingEngieerName');
  }

  get dateofNextInspection() {
    return this.DailyLiftingReportForm.get('dateofNextInspection');
  }
  get mobileCraneName() {
    return this.DailyLiftingReportForm.get('mobileCraneName');
  }
  get type() {
    return this.DailyLiftingReportForm.get('type');
  }
  get capacity() {
    return this.DailyLiftingReportForm.get('capacity');
  }
  get chasisNo() {
    return this.DailyLiftingReportForm.get('chasisNo');
  }
  get dateofLastInspection() {
    return this.DailyLiftingReportForm.get('dateofLastInspection');
  }
  get forkDateofNextInspection() {
    return this.DailyLiftingReportForm.get('forkDateofNextInspection');
  }
  get forkName() {
    return this.DailyLiftingReportForm.get('forkName');
  }
  get forkType() {
    return this.DailyLiftingReportForm.get('forkType');
  }
  get forkCapacity() {
    return this.DailyLiftingReportForm.get('forkCapacity');
  }
  get forkChasisNo() {
    return this.DailyLiftingReportForm.get('forkChasisNo');
  }
  get forkDateofLastInspection() {
    return this.DailyLiftingReportForm.get('forkDateofLastInspection');
  }
  get permitsToWorkListDTOs() {
    return this.DailyLiftingReportForm.get('permitsToWorkListDTOs') as FormArray;
  }
  get summaryDailyListDTOs() {
    return this.DailyLiftingReportForm.get('summaryDailyListDTOs') as FormArray;
  }
  get dailyRecordStacticsListDTOs() {
    return this.DailyLiftingReportForm.get('dailyRecordStacticsListDTOs') as FormArray;
  }


  createDailyRecordStacticsListFormGroup(itemValue: string) {
    return this.fb.group({
      item: [itemValue, Validators.required],
      dailyRecordStacticsListName: [''],
    });
  }


  createPermitsToWorkListFormGroup(itemValue: string, isNewRow: boolean = false) {
    return this.fb.group({
      item: [itemValue, Validators.required],
      permitsToWorkListName: [''],
      isNewRow: [isNewRow] // Track if the row is new or existing
    });
  }
  createSummaryDailyListFormGroup(itemValue: string, isNewRow: boolean = false) {
    return this.fb.group({
      item: [itemValue, Validators.required],
      summaryDailyListName: [''],
      isNewRow: [isNewRow] // Track if the row is new or existing
    });
  }




  initializeDailyRecordStacticsList() {
    console.log("numDailyRecordStacticsList")
    console.log(this.numDailyRecordStacticsList)
    for (let i = 0; i < this.numDailyRecordStacticsList; i++) {
      this.addDailyRecordStacticsList();
    }
  }
  initializeSummaryDailyList() {
    console.log("numSummaryDailyList")
    console.log(this.numSummaryDailyList)
    for (let i = 0; i < this.numSummaryDailyList; i++) {
      this.addSummaryDailyList();
    }
  }
  initializePermitsToWorkList() {
    console.log("numPermitsToWorkList")
    console.log(this.numPermitsToWorkList)
    for (let i = 0; i < this.numPermitsToWorkList; i++) {
      this.addPermitsToWorkList();
    }
  }
  addDailyRecordStacticsList() {
    this.dailyRecordStacticsListDTOs.push(this.createDailyRecordStacticsListFormGroup(''));
    // this.drugButtonClicked = true
  }
  addSummaryDailyList() {
    const newItemValue = this.summaryDailyListDTOs.length + 1;
    this.summaryDailyListDTOs.push(this.createSummaryDailyListFormGroup(newItemValue.toString(), true));
    this.SummaryDailyListClicked = true;
  }

  addPermitsToWorkList() {
    const newItemValue = this.permitsToWorkListDTOs.length + 1;
    this.permitsToWorkListDTOs.push(this.createPermitsToWorkListFormGroup(newItemValue.toString(), true));
    this.PermitsToWorkListClicked = true;
  }


  submitData() {
    console.log("this.DailyLiftingReportForm.value")
    console.log(this.DailyLiftingReportForm.value)
    if (this.DailyLiftingReportForm.valid) {
      this.submitted = false
      this.AddService.EditDailyLiftingReport(this.DailyLiftingReportId, this.DailyLiftingReportForm.value).subscribe({
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
      this.submitted = true;
      console.log("E+++++====error in : ");
      console.log(this.DailyLiftingReportForm);
    }
  }

  selectedMenace(event: any) {
    console.log("event.target.value")
    console.log(event.target.value)
    this.dataService.GetEmpCodeByCode(event.target.value).subscribe({
      next: data => {
        this.liftingEngieerName_NameID = data.data.id
        this.liftingEngieerCode_Name = data.data.name,
          console.log(data.data)
        console.log("this.liftingEngieerCode_Name")
        console.log(this.liftingEngieerCode_Name)
      },
      error: err => {
        this.ErrorMessage = err,
          console.log(err)
      }
    })
  }

  selectedMenaceMobileCrane(event: any) {
    console.log("event.target.value")
    console.log(event.target.value)
    this.AddService.GetByMobileCrane(event.target.value).subscribe({
      next: data => {
        this.MobileCraneName_NameID = data.data.id
        this.MobileCrane_Name = data.data.mobileCraneName,
          this.MobileCrane_TypeID = data.data.id,
          this.MobileCrane_Type = data.data.type,
          this.MobileCrane_CapacityID = data.data.id,
          this.MobileCrane_Capacity = data.data.capacity,
          this.MobileCrane_ChasisNoId = data.data.id,
          this.MobileCrane_ChasisNo = data.data.chasisNo,
          this.MobileCrane_DateofLastInspectionId = data.data.id,
          this.MobileCrane_DateofLastInspection = data.data.dateofLastInspection,
          this.MobileCrane_DateofNextInspectionID = data.data.id,
          this.MobileCrane_DateofNextInspection = data.data.dateofNextInspection,
          console.log(data.data)
        console.log("this.MobileCrane_Name")
        console.log(this.MobileCrane_Name)
      },
      error: err => {
        this.ErrorMessage = err,
          console.log(err)
      }
    })
  }
  selectedMenaceForkDailyLifting(event: any) {
    console.log("event.target.value")
    console.log(event.target.value)
    this.AddService.GetByForkDailyLifting(event.target.value).subscribe({
      next: data => {
        this.ForkDailyLiftingName_NameID = data.data.id
        this.ForkDailyLifting_Name = data.data.forkName,
          this.ForkDailyLifting_TypeID = data.data.id,
          this.ForkDailyLifting_Type = data.data.forkType,
          this.ForkDailyLifting_CapacityID = data.data.id,
          this.ForkDailyLifting_Capacity = data.data.forkCapacity,
          this.ForkDailyLifting_ChasisNoId = data.data.id,
          this.ForkDailyLifting_ChasisNo = data.data.forkChasisNo,
          this.ForkDailyLifting_DateofLastInspectionId = data.data.id,
          this.ForkDailyLifting_DateofLastInspection = data.data.forkDateofLastInspection,
          this.ForkDailyLifting_DateofNextInspectionID = data.data.id,
          this.ForkDailyLifting_DateofNextInspection = data.data.forkDateofNextInspection,
          console.log(data.data)
        console.log("this.DateofNextInspection")
        console.log(data.data.forkDateofNextInspection)
      },
      error: err => {
        this.ErrorMessage = err,
          console.log(err)
      }
    })
  }



  Download() {
    let workbook = new Workbook();

    let worksheet = workbook.addWorksheet("DailyLiftingReport Data");


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

    let fname = "DailyLiftingReport Report"

    //add data and file name and download
    workbook.xlsx.writeBuffer().then((data) => {
      let blob = new Blob([data], { type: 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet' });
      saveAs.saveAs(blob, fname + '-' + new Date().toUTCString() + '.xlsx');
    });
  }
}
