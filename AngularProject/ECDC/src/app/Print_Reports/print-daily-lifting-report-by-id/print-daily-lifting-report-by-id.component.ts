import { Component } from '@angular/core';
import { ActivatedRoute, ParamMap } from '@angular/router';
import { AddNewDailyLiftingReportService } from 'Services/add-new-daily-lifting-report.service';
import { LoginService } from 'Services/login.service';

@Component({
  selector: 'app-print-daily-lifting-report-by-id',
  templateUrl: './print-daily-lifting-report-by-id.component.html',
  styleUrls: ['./print-daily-lifting-report-by-id.component.scss']
})
export class PrintDailyLiftingReportByIdComponent {
  DailyLiftingReportObj!: any;
  ErrorMessage: string = '';
  DailyLiftingReportId!: any;
  Data: boolean = false;
  User: any;

  constructor(
    private loginService: LoginService,
    private activatedRoute: ActivatedRoute,
    private dataService: AddNewDailyLiftingReportService
  ) { }
  ngOnInit() {
    this.User = this.loginService.currentUser.getValue();
    this.activatedRoute.paramMap.subscribe((params: ParamMap) => {
      this.DailyLiftingReportId = params.get("id");
      console.log(this.DailyLiftingReportId)
    }),
      this.dataService.GetDailyLiftingReportDataById(this.DailyLiftingReportId, this.User.ID, this.User.Role).subscribe({
        next: data => {
          this.DailyLiftingReportObj = data.data;
          this.Data = true;
          console.log("this.DailyLiftingReportObj");

          console.log(this.DailyLiftingReportObj)
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

      // Add a CSS media query for A4 paper size
      style.textContent += `@media print {
        @page {
          size: A4;
        }
        .print-section {
          page-break-before: always;
          min-height: 27.7cm;
        }
        body {
          background-color: white;
        }
      }`;

      window.setTimeout(() => {
        iframe.contentWindow?.print();
        document.body.removeChild(iframe);
      }, 1000);
    }
  }

}
