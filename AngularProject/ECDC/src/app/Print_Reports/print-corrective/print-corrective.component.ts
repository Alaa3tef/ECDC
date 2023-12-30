import { Component } from '@angular/core';
import { DataService } from 'Services/data.service';
import { LoginService } from 'Services/login.service';
import { CorrectiveObservation } from 'SharedClasses/CorrectiveObservation';
import { CorrectiveRootCause } from 'SharedClasses/CorrectiveRootCause';
import { IRig } from 'SharedClasses/IRig';

@Component({
  selector: 'app-print-corrective',
  templateUrl: './print-corrective.component.html',
  styleUrls: ['./print-corrective.component.scss']
})
export class PrintCorrectiveComponent {
  observationList: CorrectiveObservation[] = [];
  rootCausesList: CorrectiveRootCause[] = [];
  rigList: IRig[] = [];

  corrective: any[] = [];
  ErrorMessage: string = '';
  Classification!: string;
  correctiveRecord: any[] = [];
  Data: boolean = false;
  User: any;
  date!: Date;
  rigId!: any;


  constructor(
    private loginService: LoginService,
    private dataService: DataService
  ) { }
  ngOnInit() {
    this.User = this.loginService.currentUser.getValue();
    console.log("this.User")
    console.log(this.User)
    this.dataService.GetCorrective(this.User.ID, this.User.Role).subscribe({
      next: data => {
        data.data.forEach((ele: any) => {
          if (ele.formStatus == "open") {
            this.corrective.push(ele.dateRaisedBy)
          }
        });
        console.log("this.corrective")
        console.log(this.corrective)
        this.corrective = Array.from(new Set(this.corrective))
      },
      error: error => this.ErrorMessage = error
    })
    this.dataService.GetRig().subscribe({
      next: data => {
        this.rigList = data.data
      }
    })
  }

  ClassificationSelected(event: any) {
    if (this.User.Role == "Admin") {
      this.dataService.GetCorrectiveForAnalysis(event.target.value, this.User.ID, this.User.Role).subscribe({
        next: data => {
          console.log("data.data")
          console.log(data.data)
          data.data.forEach((ele: any) => {
            if (ele.formStatus == "open") {
              this.correctiveRecord.push(ele)
            }
            console.log("************//////////////************")
            console.log(this.correctiveRecord)
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
    else if (this.User.Role == "User") {
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
