import { Component } from '@angular/core';
import { ActivatedRoute, ParamMap } from '@angular/router';
import { LoginService } from 'Services/login.service';
import { WeeklyClinicService } from 'Services/weekly-clinic.service';

@Component({
  selector: 'app-print-weekly-clinic',
  templateUrl: './print-weekly-clinic.component.html',
  styleUrls: ['./print-weekly-clinic.component.scss']
})
export class PrintWeeklyClinicComponent {
  WeeklyClinic: any[] = [];
  WeeklyClinicRecord: any[] = [];

  ErrorMessage: string = '';
  WeeklyClinicId!: any;
  Data: boolean = false;
  User: any;

  constructor(
    private loginService: LoginService,
    private activatedRoute: ActivatedRoute,
    private dataService: WeeklyClinicService
  ) { }

  ngOnInit() {
    this.User = this.loginService.currentUser.getValue();
    this.activatedRoute.paramMap.subscribe((params: ParamMap) => {
      this.WeeklyClinicId = params.get("id");
      console.log(this.WeeklyClinicId)
    }),
      this.dataService.GetWeeklyClinic(this.User.ID, this.User.Role).subscribe({
        next: data => {
          data.data.forEach((ele: any) => {
            // Check if the element already exists in WeeklyClinic based on date and rig number
            const existingElement = this.WeeklyClinic.find(item => item.date === ele.date && item.rigNo === ele.rigNo);
            if (!existingElement) {
              this.WeeklyClinic.push(ele);
            }
          });
          this.WeeklyClinic = this.WeeklyClinic.filter((WeeklyClinic, index, self) =>
            index === self.findIndex((t) => (
              t.rigNo === WeeklyClinic.rigNo && t.date === WeeklyClinic.date
            ))
          );
          this.WeeklyClinic.sort((a, b) => a.rigNo - b.rigNo);
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

      this.dataService.GetWeeklyClinicByDate(rigNumber, formattedDate, this.User.ID, this.User.Role).subscribe({
        next: data => {
          this.WeeklyClinicRecord = data.data
          console.log("***************************************************")
          console.log(this.WeeklyClinicRecord)
          if (this.WeeklyClinicRecord.length > 0) {
            this.Data = true;
            this.WeeklyClinicRecord.forEach(element => {
              const textareaContent = element.otherComments; // assuming shiftBrief is the correct field, not shiftBrief.value
              const formattedContent = textareaContent.replace(/\n/g, '<br>');
              element.otherComments = formattedContent;
            })
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
    this.WeeklyClinicRecord = [];
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
