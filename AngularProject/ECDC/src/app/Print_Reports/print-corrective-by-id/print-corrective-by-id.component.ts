import { Component } from '@angular/core';
import { ActivatedRoute, ParamMap } from '@angular/router';
import { DataService } from 'Services/data.service';
import { LoginService } from 'Services/login.service';
import { CorrectiveObservation } from 'SharedClasses/CorrectiveObservation';
import { CorrectiveRootCause } from 'SharedClasses/CorrectiveRootCause';

@Component({
  selector: 'app-print-corrective-by-id',
  templateUrl: './print-corrective-by-id.component.html',
  styleUrls: ['./print-corrective-by-id.component.scss']
})
export class PrintCorrectiveByIdComponent {
  CorrectiveObj!: any;
  ErrorMessage: string = '';
  CorrectiveId!: any;
  Data: boolean = false;
  User:any;
  observationList: CorrectiveObservation[] = [];
  rootCausesList: CorrectiveRootCause[] = [];

  constructor(
    private loginService:LoginService,
    private activatedRoute: ActivatedRoute,
    private dataService: DataService
    ) { }
  ngOnInit() {
    this.User=this.loginService.currentUser.getValue();
    this.activatedRoute.paramMap.subscribe((params: ParamMap) => {
      this.CorrectiveId = params.get("id");
      console.log(this.CorrectiveId)
    }),
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
      this.dataService.GetCorrectiveDataById(this.CorrectiveId,this.User.ID,this.User.Role).subscribe({
        next: data => {
          this.CorrectiveObj = data.data;
          this.Data = true;
          console.log("this.CorrectiveObj");

          console.log(this.CorrectiveObj)
        },
        error: error => {
          this.ErrorMessage = error;
          console.log("Error");
        }
      })
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
