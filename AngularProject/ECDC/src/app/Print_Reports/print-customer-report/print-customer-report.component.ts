import { Component } from '@angular/core';
import { AddNewCustomerReportServiceService } from 'Services/add-new-customer-report-service.service';
import { DataService } from 'Services/data.service';
import { LoginService } from 'Services/login.service';

@Component({
  selector: 'app-print-customer-report',
  templateUrl: './print-customer-report.component.html',
  styleUrls: ['./print-customer-report.component.scss']
})
export class PrintCustomerReportComponent {
  CustomerReport: any[] = [];
  ErrorMessage: string = '';



  Rating!: string;
  CustomerReportRecord: any[] = [];
  Data: boolean = false;
  User:any;
  date!: Date;
  extractedNumber: number = 0;
  extractedDate!: Date;
  month!:number;
  json_data: any[] = [];

  constructor(private loginService:LoginService,private AddNewCustomer: AddNewCustomerReportServiceService, private dataService: DataService) { }
  ngOnInit() {
    this.User=this.loginService.currentUser.getValue();
    console.log()
    this.dataService.GetCustomersReport(this.User.ID,this.User.Role).subscribe({
      next: data => {
        this.json_data=data.data
        console.log("JSON Data:", this.json_data);

        data.data.forEach((ele: any) => {
          this.CustomerReport.push(ele)
          console.log("ele" , ele)
          console.log("$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$44")
          console.log(data.data)
          console.log(this.CustomerReport)
        });
        // this.Accident = data.data;
       this.CustomerReport = Array.from(new Set(this.CustomerReport))
        console.log(this.CustomerReport)
      },
      
      error: error => this.ErrorMessage = error
      
    })
  }
  
  CustomerReportByMonthAndYearSelected(event: any) {
    const selectedReport: string = event.target.value;
    console.log("selectedReport", selectedReport);
  
    // Split the combined value into month and year
    const [month, year] = selectedReport.split('/').map((value: string) => value.trim());
  
    console.log("Month:", month);
    console.log("Year:", year);

    // Remove any spaces between month and year
    const sanitizedMonth: string = month.trim();
    const sanitizedYear: string = year.trim();
  
    // Call the service function with the sanitized values
    this.AddNewCustomer.GetDataByMonthAndYear(Number(sanitizedMonth), Number(sanitizedYear), this.User.ID, this.User.Role)
      .subscribe({
        next: data => {
          this.CustomerReportRecord = data.data;
          console.log("Data retrieval successful", data.data);
          this.Data = true;
          console.log("Data retrieval successful");
        },
        error: error => {
          this.ErrorMessage = error;
          console.log("Error occurred while retrieving data");
        }
      });
  }
  
  print(): void {
    const elements = Array.from(document.getElementsByClassName("print-section"));

    const iframe = document.body.appendChild(document.createElement("iframe"));
    iframe.style.display = "none";
    const idoc = iframe.contentDocument;

    if (idoc != null) {
      idoc.head.innerHTML = document.head.innerHTML;
      elements.forEach(element => {
        idoc.body.appendChild(element.cloneNode(true));
      });

      const pageStyles = window.getComputedStyle(document.body);

      const style = document.createElement('style');
      style.textContent = pageStyles.cssText;
      idoc.head.appendChild(style);

      const breakRule = `@media print {
    .print-section {
      page-break-before: always;
    }
  }`;

      style.textContent += breakRule;

      window.setTimeout(() => {
        iframe.contentWindow?.print();
        document.body.removeChild(iframe);
      }, 1000);
    }
  }
}
