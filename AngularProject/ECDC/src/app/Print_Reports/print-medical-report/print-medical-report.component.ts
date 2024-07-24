import { Component } from '@angular/core';
import { AddNewMedicalReportService } from 'Services/add-new-medical-report.service';
import { DataService } from 'Services/data.service';
import { LoginService } from 'Services/login.service';

@Component({
  selector: 'app-print-medical-report',
  templateUrl: './print-medical-report.component.html',
  styleUrls: ['./print-medical-report.component.scss']
})
export class PrintMedicalReportComponent {
 MedicalReport: any[] = [];
  ErrorMessage: string = '';



 MedicalReportType!: string;
 MedicalReportRecord: any[] = [];
  Data: boolean = false;
  User:any;
  date!: Date;
  extractedNumber: number = 0;
  extractedDate!: Date;
  constructor(private loginService:LoginService,private AddNewMedicalReport: AddNewMedicalReportService, private dataService: DataService) { }
  ngOnInit() {
    this.User=this.loginService.currentUser.getValue();
    console.log()
    this.dataService.GetMedicalReports(this.User.ID,this.User.Role).subscribe({
      next: data => {
        data.data.forEach((ele: any) => {
          this.MedicalReport.push(ele)
          console.log("jobbbbbbbbbbbbbbbbbbbbbbbbbb44")
          console.log(ele.job)

          console.log(data.data)
          console.log(this.MedicalReport)
        });
        // this.Accident = data.data;
       this.MedicalReport = Array.from(new Set(this.MedicalReport))
        console.log(this.MedicalReport)
      },
      error: error => this.ErrorMessage = error
    })
  }

  GetDataByRigAndDateAndName(event: any) {
    console.log("event.target.value")

    console.log(event.target.value)
    const regex = /(\d+)\/([\w\s]+)\/(\d{2}-\d{2}-\d{4})\/([\w\s]*)/;
    const match = event.target.value.match(regex);

    if (match) {
      const rigNumber = match[1].trim();  // Extracted number
      const name = match[2]  // Extracted string with leading/trailing spaces trimmed
      const date = match[3];    // Extracted date
      const jop = match[4].trim();  // Extracted date

      console.log("Number: " + rigNumber);
      console.log("Name: " +name);
      console.log("Date: " + date);
      console.log("jop: " + jop);

      const formattedDate = date.split('-').reverse().join('-');

      console.log("Formatted Date: " + formattedDate);
      this.AddNewMedicalReport.GetDataByRigAndDateAndName(name, this.User.ID, this.User.Role, formattedDate, rigNumber, jop).subscribe({
        next: response => {
          console.log("Full API Response:", response);
          this.MedicalReportRecord = response.data; // Assuming data is the array you want
          this.Data = true;
          console.log("dtoooooooo", this.MedicalReportRecord);
          console.log("this.MedicalReportRecord[0]", this.MedicalReportRecord[0]);
          console.log("done");
        },
        error: error => {
          this.ErrorMessage = error;
          console.log("Error");
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
