import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { DataService } from 'Services/data.service';
import { LoginService } from 'Services/login.service';
import { RigCertificatesService } from 'Services/rig-certificates.service';
import { IRig } from 'SharedClasses/IRig';

@Component({
  selector: 'app-print-rig-certificates',
  templateUrl: './print-rig-certificates.component.html',
  styleUrls: ['./print-rig-certificates.component.scss']
})
export class PrintRigCertificatesComponent {
  RigCertificates: any[] = [];
  RigCertificatesRecord: any[] = [];

  ErrorMessage: string = '';
  RigCertificatesId!: any;
  Data: boolean = false;
  User: any;

  constructor(
    private loginService: LoginService,
    private activatedRoute: ActivatedRoute,
    private dataService: RigCertificatesService
  ) { }

  ngOnInit() {
    this.User = this.loginService.currentUser.getValue();
    this.dataService.GetRigCertificates(this.User.ID, this.User.Role).subscribe({
      next: data => {
        data.data.forEach((ele: any) => {
          const existingElement = this.RigCertificates.find(item => item.date === ele.date && item.rigNo === ele.rigNo);
          if (!existingElement) {
            this.RigCertificates.push(ele);
          }
        });
        this.RigCertificates = this.RigCertificates.filter((RigCertificate, index, self) =>
          index === self.findIndex((t) => (
            t.rigNo === RigCertificate.rigNo && t.date === RigCertificate.date
          ))
        );
        this.RigCertificates.sort((a, b) => a.rigNo - b.rigNo);
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

      this.dataService.GetRigCertificatesByDate(rigNumber, formattedDate, this.User.ID, this.User.Role).subscribe({
        next: data => {
          this.RigCertificatesRecord = data.data
          console.log("***************************************************")
          console.log(this.RigCertificatesRecord)
          if (this.RigCertificatesRecord.length > 0) {
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
    this.RigCertificatesRecord = [];
  }

  getDaysDifference(dateString: string): string {
    if (dateString != null) {
      // Parse the date string to a Date object
      const certificationDate = new Date(dateString);

      // Get the current date
      const currentDate = new Date();

      // Calculate the difference in milliseconds
      const diffInMs = currentDate.getTime() - certificationDate.getTime();

      // Convert the difference from milliseconds to days
      const diffInDays = diffInMs / (1000 * 60 * 60 * 24);

      // Return the color based on the difference in days
      if (diffInDays > 0) {
        return '#FF0000'; // Red if the certification date is in the past (expired)
      } else if (diffInDays <= 0 && diffInDays > -30) {
        return '#FFFF00'; // Yellow if the certification date is within the next 30 days
      } else {
        return 'none'; // No color if the certification date is more than 30 days in the future
      }

    } else {
      return 'none'; // No color if the certification date is more than 30 days in the future
    }
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
