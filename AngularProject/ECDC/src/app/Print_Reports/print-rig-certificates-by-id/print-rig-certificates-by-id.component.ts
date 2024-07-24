import { Component } from '@angular/core';
import { ActivatedRoute, ParamMap } from '@angular/router';
import { LoginService } from 'Services/login.service';
import { RigCertificatesService } from 'Services/rig-certificates.service';

@Component({
  selector: 'app-print-rig-certificates-by-id',
  templateUrl: './print-rig-certificates-by-id.component.html',
  styleUrls: ['./print-rig-certificates-by-id.component.scss']
})
export class PrintRigCertificatesByIdComponent {
  RigCertificatesObj!: any;
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
    this.activatedRoute.paramMap.subscribe((params: ParamMap) => {
      this.RigCertificatesId = params.get("id");
      console.log(this.RigCertificatesId)
    }),
      this.dataService.GetRigCertificatesDataById(this.RigCertificatesId, this.User.ID, this.User.Role).subscribe({
        next: data => {
          this.RigCertificatesObj = data.data;
          this.Data = true;
          console.log("this.RigCertificatesObj");

          console.log(this.RigCertificatesObj)
        },
        error: error => {
          this.ErrorMessage = error;
          console.log("Error");
        }
      })
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
