import { Component } from '@angular/core';
import { ActivatedRoute, ParamMap } from '@angular/router';
import { AddNewVehicleWeeklyChecklistReportService } from 'Services/add-new-vehicle-weekly-checklist-report.service';
import { LoginService } from 'Services/login.service';

@Component({
  selector: 'app-print-vehicle-weekly-checklist-report-by-id',
  templateUrl: './print-vehicle-weekly-checklist-report-by-id.component.html',
  styleUrls: ['./print-vehicle-weekly-checklist-report-by-id.component.scss']
})
export class PrintVehicleWeeklyChecklistReportByIdComponent {
  VehicleWeeklyChecklistObj!: any;
  ErrorMessage: string = '';
  VehicleWeeklyChecklistId!: any;
  Data: boolean = false;
  User: any;

  constructor(
    private loginService: LoginService,
    private activatedRoute: ActivatedRoute,
    private dataService: AddNewVehicleWeeklyChecklistReportService
  ) { }
  ngOnInit() {
    this.User = this.loginService.currentUser.getValue();
    this.activatedRoute.paramMap.subscribe((params: ParamMap) => {
      this.VehicleWeeklyChecklistId = params.get("id");
      console.log(this.VehicleWeeklyChecklistId)
    }),
      this.dataService.GetVehicleWeeklyChecklistDataById(this.VehicleWeeklyChecklistId, this.User.ID, this.User.Role).subscribe({
        next: data => {
          this.VehicleWeeklyChecklistObj = data.data;
          this.Data = true;
          console.log("this.VehicleWeeklyChecklistObj");

          console.log(this.VehicleWeeklyChecklistObj)
        },
        error: error => {
          this.ErrorMessage = error;
          console.log("Error");
        }
      })
  }


  // print(): void {
  //   const elements = Array.from(document.getElementsByClassName("print-section"));
  //   const iframe = document.body.appendChild(document.createElement("iframe"));
  //   iframe.style.display = "none";
  //   const idoc = iframe.contentDocument;

  //   if (idoc != null) {
  //     idoc.head.innerHTML = document.head.innerHTML;
  //     elements.forEach(element => {
  //       idoc.body.appendChild(element.cloneNode(true));
  //     });

  //     const pageStyles = window.getComputedStyle(document.body);

  //     const style = document.createElement('style');
  //     style.textContent = pageStyles.cssText;
  //     idoc.head.appendChild(style);

  //     // Add a CSS media query for A4 paper size
  //     style.textContent += `@media print {
  //       @page {
  //         size: A4;
  //       }
  //       .print-section {
  //         page-break-before: always;
  //         min-height: 27.7cm;
  //       }
  //     }`;

  //     window.setTimeout(() => {
  //       iframe.contentWindow?.print();
  //       document.body.removeChild(iframe);
  //     }, 1000);
  //   }
  // }
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
