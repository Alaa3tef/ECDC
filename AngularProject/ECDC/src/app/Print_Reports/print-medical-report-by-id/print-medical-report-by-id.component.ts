import { Component } from '@angular/core';
import { ActivatedRoute, ParamMap } from '@angular/router';
import { AddNewMedicalReportService } from 'Services/add-new-medical-report.service';
import { DataService } from 'Services/data.service';
import { LoginService } from 'Services/login.service';

@Component({
  selector: 'app-print-medical-report-by-id',
  templateUrl: './print-medical-report-by-id.component.html',
  styleUrls: ['./print-medical-report-by-id.component.scss']
})
export class PrintMedicalReportByIdComponent {
  MedicalReportObj!: any;
  ErrorMessage: string = '';
  MedicalReportId!: any;
  Data: boolean = false;
  User:any;

  constructor(private loginService:LoginService,private activatedRoute: ActivatedRoute,private AddNewMedicalReport: AddNewMedicalReportService, private dataService: DataService,) { }
  ngOnInit() {
    this.User=this.loginService.currentUser.getValue();
    this.activatedRoute.paramMap.subscribe((params: ParamMap) => {
      this.MedicalReportId = params.get("id");
      console.log(this.MedicalReportId)
    }),
      this.AddNewMedicalReport.GetMedicalReportByID(this.MedicalReportId,this.User.ID,this.User.Role).subscribe({
        next: data => {
          this.MedicalReportObj = data.data;
          this.Data = true;
          console.log("this.MedicalReportObj");
  
          console.log(this.MedicalReportObj)
        },
        error: error => {
          this.ErrorMessage = error;
          console.log("Error");
        }
      })
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
