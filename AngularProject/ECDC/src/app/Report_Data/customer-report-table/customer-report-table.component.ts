import { Component } from '@angular/core';
import { AddNewCustomerReportServiceService } from 'Services/add-new-customer-report-service.service';
import { DataService } from 'Services/data.service';
import { DeleteDataService } from 'Services/delete-data.service';
import { GetdataByPageService } from 'Services/getdata-by-page.service';
import { LoginService } from 'Services/login.service';
import { IcustomerReport } from 'SharedClasses/ICustomerReport';
import { Workbook } from 'exceljs';
import * as saveAs from 'file-saver';
import { BehaviorSubject } from 'rxjs';

@Component({
  selector: 'app-customer-report-table',
  templateUrl: './customer-report-table.component.html',
  styleUrls: ['./customer-report-table.component.scss']
})
export class CustomerReportTableComponent {
  private ListOfCustomerReport = new BehaviorSubject<any[]>([]);
  readonly CustomerReportList = this.ListOfCustomerReport.asObservable();
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
  ErrorMessage: any;


  constructor(private AddnewCustomerReport: AddNewCustomerReportServiceService,private getDataByPage:GetdataByPageService,private dataService: DataService, private deleteService: DeleteDataService,private loginService:LoginService) { }

  ngOnInit() {
    this.User=this.loginService.currentUser.getValue();
    this.getpages(1)

    this.loginService.isAdmin.subscribe({
      next: data => {
        this.IsAdmin=data
      }
     })
    this.loginService.isUser.subscribe({
      next: data => {
        this.IsUser=data
      }
     })

     this.dataService.GetCustomersReport(this.User.ID,this.User.Role).subscribe({
      next: data =>{this.json_data = data.data
        console.log("JSON Data:", this.json_data);
      },
      error: err => this.ErrorMessage = err
    })
  }

  DeleteCustomerReport(CustomerReport: IcustomerReport) {
    if (confirm("Are you sure you want to delete this Record?")) {
      // user clicked "Yes"
      // do something, such as call an API to delete the item
      this.deleteService.DeleteCustomerReport(CustomerReport).subscribe({
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
  getpages(num:number)
  {
    this.getDataByPage.GetCustomerReportByPage(num,this.User.ID,this.User.Role).subscribe({
      next: data => {
        console.log(' this.ListOfCustomer', this.ListOfCustomerReport)
        this.ListOfCustomerReport.next(data.items)
        this.countOfPage=data.count;
        this.TempArray= new Array(this.countOfPage);
      },
      error: err => {
        console.log(' this.ListOfDrill', this.ListOfCustomerReport.value)

        console.log(err)
      }
    })
    this.indexofPages=num;
    console.log("getpages"+this.indexofPages);
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

  // Ensure that the workbook is created successfully
  console.log("Workbook:", workbook);

  let worksheet = workbook.addWorksheet("Customer Satisfaction Evaluation Report Data");

  // Ensure that the worksheet is created successfully
  console.log("Worksheet:", worksheet);

  if (!this.json_data || this.json_data.length === 0) {
    console.error("No data available for export.");
    console.log("JSON Data:", this.json_data);

    return;
  }
    let header = Object.keys(this.json_data[0]);
     console.log("headerrrrrrrrrrr",header)

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

    let fname = "Customer Satisfaction Evaluation Report "

    //add data and file name and download
    workbook.xlsx.writeBuffer().then((data) => {
      let blob = new Blob([data], { type: 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet' });
      saveAs.saveAs(blob, fname + '-' + new Date().toUTCString() + '.xlsx');
    });
  }
}
