import { Component } from '@angular/core';
import { DataService } from 'Services/data.service';
import { LoginService } from 'Services/login.service';
import { CorrectiveObservation } from 'SharedClasses/CorrectiveObservation';
import { CorrectiveRootCause } from 'SharedClasses/CorrectiveRootCause';
import { ICorrectiveResponsability } from 'SharedClasses/ICorrectiveResponsability';

@Component({
  selector: 'app-print-corrective',
  templateUrl: './print-corrective.component.html',
  styleUrls: ['./print-corrective.component.scss']
})
export class PrintCorrectiveComponent {
  observationList: CorrectiveObservation[] = [];
  rootCausesList: CorrectiveRootCause[] = [];
  // rigList: IRig[] = [];
  respList: ICorrectiveResponsability[] = [];

  corrective: any[] = [];
  ErrorMessage: string = '';
  Classification!: string;
  correctiveRecord: any[] = [];
  Data: boolean = false;
  User: any;
  date!: Date;
  dateSelected: string = "";
  titleList: any[] = [];
  Title: string = "";
  Status: string = "";
  // rigId: any=0;
  responsability: string = "";


  constructor(
    private loginService: LoginService,
    private dataService: DataService
  ) { }
  ngOnInit() {
    this.User = this.loginService.currentUser.getValue();
    console.log("this.User")
    console.log(this.User)
    this.dataService.GetCorrectiveResponsability().subscribe({
      next: data => {
        this.respList = data.data
      }
    })
    this.dataService.GetCorrective(this.User.ID, this.User.Role).subscribe({
      next: data => {
        data.data.forEach((ele: any) => {
          this.corrective.push(ele.dateRaisedBy)
          this.titleList.push(ele.title)
        });
        console.log("this.corrective")
        console.log(this.corrective)
        this.corrective = Array.from(new Set(this.corrective))
        this.titleList = Array.from(new Set(this.titleList))
      },
      error: error => this.ErrorMessage = error
    })
  }

  onClick(event: any) {
    this.Title = "";
    this.Status = "";
    this.responsability = "";
    this.dateSelected = "";
  }

  onChange(event: any) {
    console.log(event.target.value)
    if (this.User.Role == "Admin") {
      if (this.responsability != "" || this.Title != "" || this.dateSelected != "" || this.Status != "") {
        this.dataService.GetCorrectiveByFilter(this.responsability, this.Title, this.dateSelected, this.Status).subscribe({
          next: data => {
            this.correctiveRecord = data.data
            console.log("***************************************************")
            console.log(this.correctiveRecord)
            this.correctiveRecord.forEach(element => {
              const textareaContent1 = element.objectiveEvidence; // assuming shiftBrief is the correct field, not shiftBrief.value
              const formattedContent1 = textareaContent1.replace(/\n/g, '<br>');
              element.objectiveEvidence = formattedContent1;
              const textareaContent2 = element.comment; // assuming shiftBrief is the correct field, not shiftBrief.value
              const formattedContent2 = textareaContent2.replace(/\n/g, '<br>');
              element.comment = formattedContent2;
            })
            this.dataService.GetCorrectiveObservation().subscribe({
              next: data => {
                this.observationList = data.data;
              },
              error: err => this.ErrorMessage = err
            });
            this.dataService.GetRootCause().subscribe({
              next: data => {
                this.rootCausesList = data.data;
              },
              error: err => this.ErrorMessage = err
            });
            if (this.correctiveRecord.length > 0) {
              this.Data = true;
            }
          },
          error: error => {
            this.ErrorMessage = error;
            console.log("Error");
          }
        })
        this.correctiveRecord = [];
      }
    }
  }

  ClassificationSelected(event: any) {
    if (this.User.Role == "User") {
      this.dataService.GetCorrectiveDataByDate(event.target.value, this.User.ID, this.User.Role).subscribe({
        next: data => {
          console.log("data.data")
          console.log(data.data)
          data.data.forEach((ele: any) => {
            if (ele.formStatus == "open") {
              this.correctiveRecord.push(ele)
            }
          });
          this.dataService.GetCorrectiveObservation().subscribe({
            next: data => {
              this.observationList = data.data;
            },
            error: err => this.ErrorMessage = err
          });
          this.dataService.GetRootCause().subscribe({
            next: data => {
              this.rootCausesList = data.data;
            },
            error: err => this.ErrorMessage = err
          });
          this.Data = true;
          console.log("done");
          console.log("data.data");
          console.log(data.data);
        },
        error: error => {
          this.ErrorMessage = error;
          console.log("Error");
        }
      })
    }

    this.correctiveRecord = []
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

  //     const breakRule = `@media print {
  //   .print-section {
  //     page-break-before: always;
  //     min-height:27.7cm
  //   }
  // }`;

  //     style.textContent += breakRule;

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
      }`;

      window.setTimeout(() => {
        iframe.contentWindow?.print();
        document.body.removeChild(iframe);
      }, 1000);
    }
  }

}
