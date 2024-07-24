import { Component } from '@angular/core';
import { ActivatedRoute, ParamMap } from '@angular/router';
import { DataService } from 'Services/data.service';
import { HandoverService } from 'Services/handover.service';
import { LoginService } from 'Services/login.service';
import { IRig } from 'SharedClasses/IRig';
import { concatAll } from 'rxjs';

@Component({
  selector: 'app-print-handover',
  templateUrl: './print-handover.component.html',
  styleUrls: ['./print-handover.component.scss']
})
export class PrintHandoverComponent {
  Handover: any[] = [];
  HandoverRecord: any[] = [];
  rigList: IRig[] = [];
  ErrorMessage: string = '';
  HandoverId!: any;
  Data: boolean = false;
  User: any;

  constructor(
    private loginService: LoginService,
    private activatedRoute: ActivatedRoute,
    private dataService: HandoverService,
    private OtherDate: DataService
  ) { }

  ngOnInit() {
    this.User = this.loginService.currentUser.getValue();
    // this.activatedRoute.paramMap.subscribe((params: ParamMap) => {
    //   this.HandoverId = params.get("id");
    //   console.log(this.HandoverId)
    // }),
    this.OtherDate.GetRig().subscribe({
      next: data => {
        this.rigList = data.data
        console.log(this.rigList)
      }
    })
    this.dataService.GetHandover(this.User.ID, this.User.Role).subscribe({
      next: data => {
        data.data.forEach((ele: any) => {
          const existingElement = this.Handover.find(item => item.leavingEmpName === ele.leavingEmpName && item.rigNo === ele.rigNo);
          if (!existingElement) {
            this.Handover.push(ele);
          }
        });
        this.Handover = this.Handover.filter((Handover, index, self) =>
          index === self.findIndex((t) => (
            t.rigNo === Handover.rigNo && t.leavingEmpName === Handover.leavingEmpName
          ))
        );
        this.Handover.sort((a, b) => a.rigNo - b.rigNo);
      },
      error: error => this.ErrorMessage = error
    })
  }

  onChange(event: any) {
    console.log(event.target.value)
    let paramaters = event.target.value.split(" / ");
    this.dataService.GetHandoverByRigandEngineer(paramaters[0], paramaters[1], this.User.ID, this.User.Role).subscribe({
      next: data => {
        this.HandoverRecord = data.data
        if (this.HandoverRecord.length > 0) {
          this.Data = true;
          this.HandoverRecord.forEach(element => {
            const textareaContent = element.shiftBrief; // assuming shiftBrief is the correct field, not shiftBrief.value
            const formattedContent = textareaContent.replace(/\n/g, '<br>');
            element.shiftBrief = formattedContent;
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
    this.HandoverRecord = [];
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
