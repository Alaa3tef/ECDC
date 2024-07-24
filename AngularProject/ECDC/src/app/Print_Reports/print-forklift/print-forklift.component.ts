import { Component } from '@angular/core';
import { DataService } from 'Services/data.service';
import { LoginService } from 'Services/login.service';
import { IRig } from 'SharedClasses/IRig';

@Component({
  selector: 'app-print-forklift',
  templateUrl: './print-forklift.component.html',
  styleUrls: ['./print-forklift.component.scss']
})
export class PrintForkliftComponent {
  rigList: IRig[] = [];

  forklift: any[] = [];
  ErrorMessage: string = '';
  Classification!: string;
  forkliftRecord: any[] = [];
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
    this.dataService.GetForklift(this.User.ID, this.User.Role).subscribe({
      next: data => {
        data.data.forEach((ele: any) => {
          this.forklift.push(ele)
        });
        console.log("this.forklift")
        console.log(this.forklift)
        // this.forklift = Array.from(new Set(this.forklift))
        this.forklift = this.forklift.filter((forkliftObj, index, self) =>
          index === self.findIndex((t) => (
            t.rigNo === forkliftObj.rigNo && t.date === forkliftObj.date
          ))
        );

      },
      error: error => this.ErrorMessage = error
    })
  }

  ClassificationSelected(event: any) {
    const regex = /(\d+) \/ (\d{4}-\d{2}-\d{2})/;
    const match = event.target.value.match(regex);

    if (match) {
      const rigNumber = match[1];
      const date = match[2];

      console.log("Number: " + rigNumber);
      console.log("Date: " + date);

      this.dataService.GetForkliftDataByDateAndRig(date, rigNumber, this.User.ID, this.User.Role).subscribe({
        next: data => {
          console.log("data.data")
          console.log(data.data)
          data.data.forEach((ele: any) => {
            this.forkliftRecord.push(ele)
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

      this.forkliftRecord = []
    }
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
