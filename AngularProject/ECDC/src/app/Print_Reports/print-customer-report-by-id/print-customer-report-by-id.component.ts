import { Component } from '@angular/core';
import { ActivatedRoute, ParamMap } from '@angular/router';
import { AddNewCustomerReportServiceService } from 'Services/add-new-customer-report-service.service';
import { DataService } from 'Services/data.service';
import { LoginService } from 'Services/login.service';

@Component({
  selector: 'app-print-customer-report-by-id',
  templateUrl: './print-customer-report-by-id.component.html',
  styleUrls: ['./print-customer-report-by-id.component.scss']
})
export class PrintCustomerReportByIdComponent {
  CustomerReportObj!: any;
  ErrorMessage: string = '';
  CustomerReportId!: any;
  Data: boolean = false;
  User:any;

  constructor(private loginService:LoginService,private activatedRoute: ActivatedRoute,private AddNewCustomer: AddNewCustomerReportServiceService, private dataService: DataService,) { }
  ngOnInit() {
    this.User=this.loginService.currentUser.getValue();
    this.activatedRoute.paramMap.subscribe((params: ParamMap) => {
      this.CustomerReportId = params.get("id");
      console.log(this.CustomerReportId)
    }),

  

 

      this.AddNewCustomer.GetCustomerReportByID(this.CustomerReportId,this.User.ID,this.User.Role).subscribe({
        next: data => {
          this.CustomerReportObj = data.data;
          this.Data = true;
          console.log("this.cutomerObj");
  
          console.log(this.CustomerReportObj)

          
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
