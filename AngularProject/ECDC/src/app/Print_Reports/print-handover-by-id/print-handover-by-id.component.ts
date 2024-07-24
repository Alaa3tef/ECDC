import { Component } from '@angular/core';
import { ActivatedRoute, ParamMap } from '@angular/router';
import { HandoverService } from 'Services/handover.service';
import { LoginService } from 'Services/login.service';

@Component({
  selector: 'app-print-handover-by-id',
  templateUrl: './print-handover-by-id.component.html',
  styleUrls: ['./print-handover-by-id.component.scss']
})
export class PrintHandoverByIdComponent {
  HandoverObj!: any;
  ErrorMessage: string = '';
  HandoverId!: any;
  Data: boolean = false;
  User: any;

  constructor(
    private loginService: LoginService,
    private activatedRoute: ActivatedRoute,
    private dataService: HandoverService
  ) { }
  ngOnInit() {
    this.User = this.loginService.currentUser.getValue();
    this.activatedRoute.paramMap.subscribe((params: ParamMap) => {
      this.HandoverId = params.get("id");
      console.log(this.HandoverId)
    }),
      this.dataService.GetHandoverDataById(this.HandoverId, this.User.ID, this.User.Role).subscribe({
        next: data => {
          this.HandoverObj = data.data;
          this.Data = true;
          const textareaContent = this.HandoverObj.shiftBrief; // assuming shiftBrief is the correct field, not shiftBrief.value
          const formattedContent = textareaContent.replace(/\n/g, '<br>');
          console.log(formattedContent); // check the formatted value
          this.HandoverObj.shiftBrief = formattedContent;
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
