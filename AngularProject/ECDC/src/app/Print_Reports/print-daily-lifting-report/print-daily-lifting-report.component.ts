import { Component } from '@angular/core';
import { ActivatedRoute, ParamMap } from '@angular/router';
import { AddNewDailyLiftingReportService } from 'Services/add-new-daily-lifting-report.service';
import { DataService } from 'Services/data.service';
import { LoginService } from 'Services/login.service';

@Component({
  selector: 'app-print-daily-lifting-report',
  templateUrl: './print-daily-lifting-report.component.html',
  styleUrls: ['./print-daily-lifting-report.component.scss']
})
export class PrintDailyLiftingReportComponent {
  DailyLiftingReport: any[] = [];
  ErrorMessage: string = '';
  DailyLiftingReportRecord: any[] = [];
  Data: boolean = false;
  User:any;
  date!: Date;
  extractedNumber: number = 0;
  extractedDate!: Date;
  constructor(private loginService:LoginService,private AddNewDailyLiftingReport: AddNewDailyLiftingReportService, private dataService: DataService) { }
  ngOnInit() {
    this.User=this.loginService.currentUser.getValue();
    console.log()
    this.AddNewDailyLiftingReport.GetDailyLiftingReport(this.User.ID,this.User.Role).subscribe({
      next: data => {
        data.data.forEach((ele: any) => {
          this.DailyLiftingReport.push(ele)
          console.log("$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$44")
          console.log(data.data)
          console.log(this.DailyLiftingReport)
        });
        // this.Accident = data.data;
       this.DailyLiftingReport = Array.from(new Set(this.DailyLiftingReport))
        console.log(this.DailyLiftingReport)
      },
      error: error => this.ErrorMessage = error
    })
  }



  DailyLiftingReportByRigAndNameSelected(event: any) {
    console.log("Input String:", event.target.value);

    // const regex = /(\d+)\s*\/\s*(\d{2}-\d{2}-\d{4})\s*\/\s*([\w\s-]*)/;
    const regex = /(\d+)\s*\/\s*(\d{2}-\d{2}-\d{4})\s*\/\s*([\w\s.-]*)/;
    const match = event.target.value.match(regex);

    if (match) {
      const rigNumber = match[1];
      const date = match[2];  // Extracted date
      const name = match[3];  // Extracted name

      console.log("Number: " + rigNumber);
      console.log("Date: " + date);
      console.log("Name: " + name);

      // Format the date as "MM-DD-YYYY"
      const formattedDate = date.split('-').reverse().join('-');

      console.log("Formatted Date: " + formattedDate);


      this.AddNewDailyLiftingReport.GetDataByRigAndDateAndName(rigNumber,formattedDate,name,this.User.ID,this.User.Role
      ).subscribe({
          next: response => {
            console.log("Full API Response:", response);

            this.DailyLiftingReportRecord = response.data;
            this.Data = true;
            console.log("dtoooooooo", this.DailyLiftingReportRecord);
            console.log("this.DailyLiftingReportRecord[0]", this.DailyLiftingReportRecord[0]);
            console.log("done");
          },
          error: error => {
            this.ErrorMessage = error;
            console.log("Error:", error);
          }
        });
    } else {
      console.log("No match found");
    }
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
