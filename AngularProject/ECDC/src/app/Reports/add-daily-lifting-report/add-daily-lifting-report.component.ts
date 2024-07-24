import { formatDate } from '@angular/common';
import { Component } from '@angular/core';
import { FormArray, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AddNewDailyLiftingReportService } from 'Services/add-new-daily-lifting-report.service';
import { DataService } from 'Services/data.service';
import { LoginService } from 'Services/login.service';
import { IDailyLiftingReport } from 'SharedClasses/IDailyLiftingReport';
import { IRig } from 'SharedClasses/IRig';
import { Workbook } from 'exceljs';
import * as saveAs from 'file-saver';

@Component({
  selector: 'app-add-daily-lifting-report',
  templateUrl: './add-daily-lifting-report.component.html',
  styleUrls: ['./add-daily-lifting-report.component.scss']
})
export class AddDailyLiftingReportComponent {
  DailyLiftingForm!: FormGroup;
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

  liftingEngieerName_NameID:number=0;
  liftingEngieerCode_Name:string='';

  MobileCraneList: any;

  MobileCraneName_NameID:number=0;
  MobileCrane_Name:string='';

  MobileCrane_TypeID: number = 0;
  MobileCrane_Type: string = '';

  MobileCrane_CapacityID:number=0;
  MobileCrane_Capacity:string='';

  MobileCrane_ChasisNoId: number = 0;
  MobileCrane_ChasisNo: string = '';

  MobileCrane_DateofNextInspectionID:number=0;
  MobileCrane_DateofNextInspection:string='';

  MobileCrane_DateofLastInspectionId: number = 0;
  MobileCrane_DateofLastInspection: string = '';


  ForkDailyLiftingList: any;

  ForkDailyLiftingName_NameID:number=0;
  ForkDailyLifting_Name:string='';

  ForkDailyLifting_TypeID: number = 0;
  ForkDailyLifting_Type: string = '';

  ForkDailyLifting_CapacityID:number=0;
  ForkDailyLifting_Capacity:string='';

  ForkDailyLifting_ChasisNoId: number = 0;
  ForkDailyLifting_ChasisNo: string = '';

  ForkDailyLifting_DateofNextInspectionID:number=0;
  ForkDailyLifting_DateofNextInspection:string='';

  ForkDailyLifting_DateofLastInspectionId: number = 0;
  ForkDailyLifting_DateofLastInspection: string = '';

  SummaryDailyListClicked: boolean = false;
  PermitsToWorkListClicked: boolean = false;


  constructor(
    private loginService: LoginService,
    private dataService: DataService,
    private fb: FormBuilder,
    private router: Router,
    private AddService: AddNewDailyLiftingReportService) { }

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
      next: data => this.json_data = data.data,
      error: err => this.ErrorMessage = err
    });

    this.UserJsonString = JSON.stringify(this.loginService.currentUser.getValue())
    this.UserJsonObj = JSON.parse(this.UserJsonString);

    this.DailyLiftingForm = this.fb.group(
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
          [
            // this.createPermitsToWorkListFormGroup('1'),
            // this.createPermitsToWorkListFormGroup('2'),
            // this.createPermitsToWorkListFormGroup('3'),
            // this.createPermitsToWorkListFormGroup('4'),
            // this.createPermitsToWorkListFormGroup('5'),
            // this.createPermitsToWorkListFormGroup('6'),
            // this.createPermitsToWorkListFormGroup('7'),
            // this.createPermitsToWorkListFormGroup('8'),
            // this.createPermitsToWorkListFormGroup('9'),
            // this.createPermitsToWorkListFormGroup('10'),
            // this.createPermitsToWorkListFormGroup('11'),
            // this.createPermitsToWorkListFormGroup('12'),
            // this.createPermitsToWorkListFormGroup('13'),
            // this.createPermitsToWorkListFormGroup('14'),
            // this.createPermitsToWorkListFormGroup('15'),
          ],
          [
            //  Validators.required
          ]
        ),
        summaryDailyListDTOs: this.fb.array(
          [
            // this.createSummaryDailyListFormGroup('1'),
            // this.createSummaryDailyListFormGroup('2'),
            // this.createSummaryDailyListFormGroup('3'),
            // this.createSummaryDailyListFormGroup('4'),
            // this.createSummaryDailyListFormGroup('5'),
            // this.createSummaryDailyListFormGroup('6'),
            // this.createSummaryDailyListFormGroup('7'),
            // this.createSummaryDailyListFormGroup('8'),
            // this.createSummaryDailyListFormGroup('9'),
            // this.createSummaryDailyListFormGroup('10'),
            // this.createSummaryDailyListFormGroup('11'),
            // this.createSummaryDailyListFormGroup('12'),
            // this.createSummaryDailyListFormGroup('13'),
            // this.createSummaryDailyListFormGroup('14'),
            // this.createSummaryDailyListFormGroup('15'),
          ],
          [
            //  Validators.required
          ]
        ),
        dailyRecordStacticsListDTOs : this.fb.array(
          [
            this.createDailyRecordStacticsListFormGroup('Number of lifting permits to work'),
            this.createDailyRecordStacticsListFormGroup('Permit of total permit to work'),
            this.createDailyRecordStacticsListFormGroup('Number of open lifting observation'),
            this.createDailyRecordStacticsListFormGroup('Number of closed audit lifting observations'),
            this.createDailyRecordStacticsListFormGroup('Date of next CAT III Inspection'),

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
    return this.DailyLiftingForm.get('id');
  }
  get rigId() {
    return this.DailyLiftingForm.get('rigId');
  }
  get date() {
    return this.DailyLiftingForm.get('date');
  }
  get liftingEngieerCode() {
    return this.DailyLiftingForm.get('liftingEngieerCode');
  }
  get liftingEngieerName() {
    return this.DailyLiftingForm.get('liftingEngieerName');
  }

  get dateofNextInspection() {
    return this.DailyLiftingForm.get('dateofNextInspection');
  }
  get mobileCraneName() {
    return this.DailyLiftingForm.get('mobileCraneName');
  }
  get type() {
    return this.DailyLiftingForm.get('type');
  }
  get capacity() {
    return this.DailyLiftingForm.get('capacity');
  }
  get chasisNo() {
    return this.DailyLiftingForm.get('chasisNo');
  }
  get dateofLastInspection() {
    return this.DailyLiftingForm.get('dateofLastInspection');
  }
  get forkDateofNextInspection() {
    return this.DailyLiftingForm.get('forkDateofNextInspection');
  }
  get forkName() {
    return this.DailyLiftingForm.get('forkName');
  }
  get forkType() {
    return this.DailyLiftingForm.get('forkType');
  }
  get forkCapacity() {
    return this.DailyLiftingForm.get('forkCapacity');
  }
  get forkChasisNo() {
    return this.DailyLiftingForm.get('forkChasisNo');
  }
  get forkDateofLastInspection() {
    return this.DailyLiftingForm.get('forkDateofLastInspection');
  }
  get permitsToWorkListDTOs() {
    return this.DailyLiftingForm.get('permitsToWorkListDTOs') as FormArray;
  }
  get summaryDailyListDTOs() {
    return this.DailyLiftingForm.get('summaryDailyListDTOs') as FormArray;
  }
  get dailyRecordStacticsListDTOs() {
    return this.DailyLiftingForm.get('dailyRecordStacticsListDTOs') as FormArray;
  }
  createDailyRecordStacticsListFormGroup(itemValue: string) {
    return this.fb.group({
      item : [itemValue, Validators.required],
      dailyRecordStacticsListName:['',Validators.required]
    });
  }
  createPermitsToWorkListFormGroup(itemValue: string, isNewRow: boolean = false) {
    return this.fb.group({
      item : [itemValue, Validators.required],
      permitsToWorkListName : ['', Validators.required],
      isNewRow: [isNewRow] // Track if the row is new or existing

    });
  }
  createSummaryDailyListFormGroup(itemValue: string, isNewRow: boolean = false) {
    return this.fb.group({
      item : [itemValue, Validators.required],
      summaryDailyListName : ['', Validators.required],
      isNewRow: [isNewRow] // Track if the row is new or existing

    });
  }

  // addSummaryDailyList() {
  //   this.summaryDailyListDTOs.push(this.createSummaryDailyListFormGroup(''));
  //   this.SummaryDailyListClicked = true;
  // }

  addSummaryDailyList() {
    const newItemValue = this.summaryDailyListDTOs.length + 1;
    this.summaryDailyListDTOs.push(this.createSummaryDailyListFormGroup(newItemValue.toString(),true));
    this.SummaryDailyListClicked = true;
  }


  addPermitsToWorkList() {
    const newItemValue = this.permitsToWorkListDTOs.length + 1;
    this.permitsToWorkListDTOs.push(this.createPermitsToWorkListFormGroup(newItemValue.toString(),true));
    this.PermitsToWorkListClicked = true;
  }

  // submitData() {
  //   console.log("this.DailyLiftingForm.value")
  //   console.log(this.DailyLiftingForm.value)
  //   console.log("this.DailyLiftingForm.valid",this.DailyLiftingForm.valid)
  //   if (this.DailyLiftingForm.valid) {
  //     this.submitted = false
  //     const formData = this.DailyLiftingForm.value;

  //     console.log("this.DailyLiftingForm.valid",this.DailyLiftingForm.valid)
  //     this.AddService.AddDailyLiftingReport(formData).subscribe({
  //       next: data => {
  //         console.log('from service')
  //         console.log("sumary",data.summaryDailyList.length);
  //         console.log("permist",data.permitsToWorkList.length);
  //         console.log("daily",data.dailyRecordStacticsList.length);

  //         location.reload();
  //       },
  //       error: error => {
  //         console.log("from Error")
  //         console.log(error)
  //       }
  //     });
  //     // console.log(Formdata);
  //   }
  //   else {
  //     this.submitted = true;
  //     console.log("E+++++====error in : ");
  //     console.log(this.DailyLiftingForm.errors);
  //   }
  // }


  submitData() {
    console.log("Form data before submission:", this.DailyLiftingForm.value);

    if (this.DailyLiftingForm.valid) {
      this.submitted = false;
      const formData = this.DailyLiftingForm.value;

      this.AddService.AddDailyLiftingReport(formData).subscribe({
        next: data => {
          console.log('Response from service:', data);

          // Check if summaryDailyList exists and has elements
          if (data && data.summaryDailyList && data.summaryDailyList.length > 0) {
            console.log("Summary Daily List length:", data.summaryDailyList.length);
          } else {
            console.log("Summary Daily List is undefined or empty in the response.");
          }

          // Optionally, perform further actions based on the server response
          location.reload();
        },
        error: error => {
          console.log("Error from service:", error);
          // Optionally, handle error
        }
      });
    } else {
      this.DailyLiftingForm.markAllAsTouched()
      this.submitted = true;
      console.log("Form is invalid. Validation errors:", this.DailyLiftingForm);
    }
  }



  // submitData(dailyLiftingReport: IDailyLiftingReport) {
  //   // Check if summaryDailyListDTOs is empty
  //   if (dailyLiftingReport.summaryDailyList.length === 0) {
  //     console.warn('Summary Daily List is empty');
  //   }

  //   // Check if permitsToWorkListDTOs is empty
  //   if (dailyLiftingReport.permitsToWorkList.length === 0) {
  //     console.warn('Permits To Work List is empty');
  //   }

  //   // Check if dailyRecordStacticsListDTOs is empty
  //   if (dailyLiftingReport.dailyRecordStacticsList.length === 0) {
  //     console.warn('Daily Record Stactics List is empty');
  //   }

  //   // Call the service to send data to the server
  //   this.AddService.AddDailyLiftingReport(this.DailyLiftingForm.value)
  //     .subscribe(
  //       (response) => {
  //         // Handle successful response
  //         console.log('Server response:', response);
  //         // Check if any additional processing is required based on the server response
  //         if (response.statescode === 200) {
  //           // Data was successfully saved, perform any additional actions if needed
  //           console.log('Data saved successfully');
  //         } else {
  //           // Handle other scenarios based on the server response
  //           console.warn('Unexpected server response:', response);
  //         }
  //       },
  //       (error) => {
  //         // Handle error response
  //         console.error('Error:', error);
  //         // Perform error handling if needed
  //       }
  //     );
  // }



  selectedMenace(event: any) {
    console.log("event.target.value")
    console.log(event.target.value)
    this.dataService.GetEmpCodeByCode(event.target.value).subscribe({
      next:data=>{
        this.liftingEngieerName_NameID=data.data.id
        this.liftingEngieerCode_Name=data.data.name,
        console.log(data.data)
        console.log("this.liftingEngieerCode_Name")
        console.log(this.liftingEngieerCode_Name)
      },
      error:err=>{
        this.ErrorMessage=err,
        console.log(err)
      }
    })
  }

  selectedMenaceMobileCrane(event: any) {
    console.log("event.target.value")
    console.log(event.target.value)
    this.AddService.GetByMobileCrane(event.target.value).subscribe({
      next:data=>{
        this.MobileCraneName_NameID=data.data.id
        this.MobileCrane_Name=data.data.mobileCraneName,
        this.MobileCrane_TypeID=data.data.id,
        this.MobileCrane_Type=data.data.type,
        this.MobileCrane_CapacityID=data.data.id,
        this.MobileCrane_Capacity=data.data.capacity,
        this.MobileCrane_ChasisNoId=data.data.id,
        this.MobileCrane_ChasisNo=data.data.chasisNo,
        this.MobileCrane_DateofLastInspectionId=data.data.id,
        this.MobileCrane_DateofLastInspection=data.data.dateofLastInspection,
        this.MobileCrane_DateofNextInspectionID=data.data.id,
        this.MobileCrane_DateofNextInspection=data.data.dateofNextInspection,
        console.log(data.data)
        console.log("this.MobileCrane_Name")
        console.log(this.MobileCrane_Name)
      },
      error:err=>{
        this.ErrorMessage=err,
        console.log(err)
      }
    })
  }
  selectedMenaceForkDailyLifting(event: any) {
    console.log("event.target.value")
    console.log(event.target.value)
    this.AddService.GetByForkDailyLifting(event.target.value).subscribe({
      next:data=>{
        this.ForkDailyLiftingName_NameID=data.data.id
        this.ForkDailyLifting_Name=data.data.forkName,
        this.ForkDailyLifting_TypeID=data.data.id,
        this.ForkDailyLifting_Type=data.data.forkType,
        this.ForkDailyLifting_CapacityID=data.data.id,
        this.ForkDailyLifting_Capacity=data.data.forkCapacity,
        this.ForkDailyLifting_ChasisNoId=data.data.id,
        this.ForkDailyLifting_ChasisNo=data.data.forkChasisNo,
        this.ForkDailyLifting_DateofLastInspectionId=data.data.id,
        this.ForkDailyLifting_DateofLastInspection=data.data.forkDateofLastInspection,
        this.ForkDailyLifting_DateofNextInspectionID=data.data.id,
        this.ForkDailyLifting_DateofNextInspection=data.data.forkDateofNextInspection,
        console.log(data.data)
        console.log("this.DateofNextInspection")
        console.log(data.data.forkDateofNextInspection)
      },
      error:err=>{
        this.ErrorMessage=err,
        console.log(err)
      }
    })
  }
  Download() {
    let workbook = new Workbook();

    let worksheet = workbook.addWorksheet("Daily Lifting Data");


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

    let fname = "Daily Lifting Report"

    //add data and file name and download
    workbook.xlsx.writeBuffer().then((data) => {
      let blob = new Blob([data], { type: 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet' });
      saveAs.saveAs(blob, fname + '-' + new Date().toUTCString() + '.xlsx');
    });
  }
}
