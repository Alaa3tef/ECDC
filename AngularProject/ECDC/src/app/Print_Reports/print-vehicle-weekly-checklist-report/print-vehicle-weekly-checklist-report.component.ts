import { Component } from '@angular/core';
import { ActivatedRoute, ParamMap } from '@angular/router';
import { AddNewVehicleWeeklyChecklistReportService } from 'Services/add-new-vehicle-weekly-checklist-report.service';
import { LoginService } from 'Services/login.service';

@Component({
  selector: 'app-print-vehicle-weekly-checklist-report',
  templateUrl: './print-vehicle-weekly-checklist-report.component.html',
  styleUrls: ['./print-vehicle-weekly-checklist-report.component.scss']
})
export class PrintVehicleWeeklyChecklistReportComponent {
  VehicleWeeklyChecklist: any[] = [];
  VehicleWeeklyChecklistRecord: any[] = [];

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
      this.dataService.GetVehicleWeeklyChecklist(this.User.ID, this.User.Role).subscribe({
       
        next: data => {
          data.data.forEach((ele: any) => {
            // Check if the element already exists in VehicleWeeklyChecklist based on date and rig number
            const existingElement = this.VehicleWeeklyChecklist.find(item => item.date === ele.date && item.rigNo === ele.rigNo);
            if (!existingElement) {
              this.VehicleWeeklyChecklist.push(ele);
            }
          });
        },
        error: error => this.ErrorMessage = error
      })
  }

  onChange(event: any) {
    console.log(event.target.value)
    const regex = /(\d+) \/ (\d{2}-\d{2}-\d{4})/;
    const match = event.target.value.match(regex);

    if (match) {
      const rigNumber = match[1];
      const date = match[2];

      console.log("Number: " + rigNumber);
      console.log("Date: " + date);

      const formattedDate = date.split('-').reverse().join('-');

      console.log("Formatted Date: " + formattedDate);

      this.dataService.GetVehicleWeeklyChecklistByDate(rigNumber, formattedDate, this.User.ID, this.User.Role).subscribe({
        next: data => {
          this.VehicleWeeklyChecklistRecord = data.data
          console.log("***************************************************")
          console.log(this.VehicleWeeklyChecklistRecord)
          if (this.VehicleWeeklyChecklistRecord.length > 0) {
            this.Data = true;
          } else {
            this.Data = false;
          }
        },
        error: error => {
          this.ErrorMessage = error;
          console.log("Error");
        }
      })
    }
    this.VehicleWeeklyChecklistRecord = [];
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
