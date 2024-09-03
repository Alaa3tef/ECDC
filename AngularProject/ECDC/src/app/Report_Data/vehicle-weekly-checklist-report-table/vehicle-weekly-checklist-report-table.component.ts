import { Component } from '@angular/core';
import { AddNewVehicleWeeklyChecklistReportService } from 'Services/add-new-vehicle-weekly-checklist-report.service';
import { DataService } from 'Services/data.service';
import { LoginService } from 'Services/login.service';
import { IVehicleWeeklyChecklist } from 'SharedClasses/IVehicleWeeklyChecklist';
import { Workbook } from 'exceljs';
import * as saveAs from 'file-saver';
import { BehaviorSubject } from 'rxjs';

@Component({
  selector: 'app-vehicle-weekly-checklist-report-table',
  templateUrl: './vehicle-weekly-checklist-report-table.component.html',
  styleUrls: ['./vehicle-weekly-checklist-report-table.component.scss']
})
export class VehicleWeeklyChecklistReportTableComponent {
  ErrorMessage = '';
  private ListOfVehicleWeeklyChecklist = new BehaviorSubject<any[]>([]);
  readonly VehicleWeeklyChecklistList = this.ListOfVehicleWeeklyChecklist.asObservable();
  page:number=1;
  count:number=0;
  productSize:number=5;
  indexofPages: number=1;
  countOfPage:number=0;
  TempArray:any[]=[];
  IsUser:boolean=false;
  IsRadio:boolean=false;
  IsAdmin:boolean=false;

  json_data: any[] = [];

  User:any;

  isLoading = false;
  progress: number = 0;
  message!: string;
  constructor(
    private getDataByPage:AddNewVehicleWeeklyChecklistReportService,
    private loginService:LoginService,
    private dataService:DataService) { }

  ngOnInit() {
    this.User=this.loginService.currentUser.getValue();
    this.getpages(1)

    this.loginService.isAdmin.subscribe({
      next: data => {
        this.IsAdmin=data
      }
     })

     this.getDataByPage.GetVehicleWeeklyChecklist(this.User.ID, this.User.Role).subscribe({
      next: data => this.json_data = data.data,
      error: err => this.ErrorMessage = err
    });
  }

  DeleteVehicleWeeklyChecklist(VehicleWeeklyChecklist: IVehicleWeeklyChecklist) {
    if (confirm("Are you sure you want to delete this Record?")) {
      // user clicked "Yes"
      // do something, such as call an API to delete the item
      this.getDataByPage.DeleteVehicleWeeklyChecklist(VehicleWeeklyChecklist).subscribe({
        next: data => {
          console.log(data)
          this.getpages(this.indexofPages)
        },
        error: err => {
          console.log(err);
        }
      })
    } else {
      // user clicked "No"
      // do nothing
    }
  }
  recordContainsPoor(record: any): boolean {
    return Object.values(record).some(value => value === 'No');
  }
  getpages(num:number)
  {
    this.isLoading = true;  // Start the loader
    this.progress = 0;  // Reset progress
    this.getDataByPage.GetVehicleWeeklyChecklistByPage(num,this.User.ID,this.User.Role).subscribe({
      next: data => {
        this.progress = 100;  // Set progress to 100% when backend responds
          this.isLoading = false;  // Stop loader
        this.ListOfVehicleWeeklyChecklist.next(data.items)
        this.countOfPage=data.count;
        this.TempArray= new Array(this.countOfPage);
      },
      error: err => {
        this.isLoading = false;  // Stop loader
        this.progress = 0;  // Reset progress on error
        this.message = 'Error occurred during Generation.';

        console.log(err)
      }
    })
    this.simulateProgressUntilCompletion();
    this.indexofPages=num;
    console.log("getpages"+this.indexofPages);
  }
   // Simulate incremental progress for user feedback until backend completes
   simulateProgressUntilCompletion() {
    const interval = setInterval(() => {
      if (this.progress < 90) {  // Limit to 90% to leave room for backend completion
        this.progress += 10;
      } else {
        clearInterval(interval);  // Stop simulation when close to 100%
      }
    }, 500);  // Adjust as needed
  }
  gotleft()
  {
    (this.indexofPages>1)?this.indexofPages-=1:this.indexofPages=1;
    this.getpages(this.indexofPages);
    console.log("gotleft"+this.indexofPages);
  }
  gotoright()
  {

    (this.indexofPages<this.countOfPage)?this.indexofPages+=1:this.indexofPages=this.countOfPage;
    this.getpages(this.indexofPages);
    console.log("gotoright"+this.indexofPages);
  }

  Download() {
    let workbook = new Workbook();

    let worksheet = workbook.addWorksheet("Vehicle Weekly Checklist Data");


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

    let fname = "Vehicle Weekly Checklist Report"

    //add data and file name and download
    workbook.xlsx.writeBuffer().then((data) => {
      let blob = new Blob([data], { type: 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet' });
      saveAs.saveAs(blob, fname + '-' + new Date().toUTCString() + '.xlsx');
    });
  }
}
