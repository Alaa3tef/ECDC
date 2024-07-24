import { Component } from '@angular/core';
import { ActivatedRoute, ParamMap } from '@angular/router';
import { AddweeklyCampInspectionServiceService } from 'Services/addweekly-camp-inspection-service.service';
import { DataService } from 'Services/data.service';
import { LoginService } from 'Services/login.service';

@Component({
  selector: 'app-printweekly-camp-inspection-by-id',
  templateUrl: './printweekly-camp-inspection-by-id.component.html',
  styleUrls: ['./printweekly-camp-inspection-by-id.component.scss']
})
export class PrintweeklyCampInspectionByIDComponent {
  WeeklyCampInspectionObj!: any;
  ErrorMessage: string = '';
  WeeklyCampInspectionId!: any;
  Data: boolean = false;
  User:any;
  constructor(private loginService:LoginService,private activatedRoute: ActivatedRoute,private AddNewWeeklyCampInspection: AddweeklyCampInspectionServiceService, private dataService: DataService,) { }
  ngOnInit() {
    this.User=this.loginService.currentUser.getValue();
    this.activatedRoute.paramMap.subscribe((params: ParamMap) => {
      this.WeeklyCampInspectionId = params.get("id");
      console.log(this.WeeklyCampInspectionId)
    }),
      this.AddNewWeeklyCampInspection.GetWeeklyCampInspectionByIDForPrint(this.WeeklyCampInspectionId,this.User.ID,this.User.Role).subscribe({
        next: data => {
          this.WeeklyCampInspectionObj = data.data;
          this.Data = true;
          console.log("this.WeeklyCampInspectionObj");
          console.log(this.WeeklyCampInspectionObj)
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
