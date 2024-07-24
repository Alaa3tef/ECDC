import { Component } from '@angular/core';
import { AddweeklyCampInspectionServiceService } from 'Services/addweekly-camp-inspection-service.service';
import { DataService } from 'Services/data.service';
import { LoginService } from 'Services/login.service';

@Component({
  selector: 'app-printweekly-camp-inspection',
  templateUrl: './printweekly-camp-inspection.component.html',
  styleUrls: ['./printweekly-camp-inspection.component.scss']
})
export class PrintweeklyCampInspectionComponent {
  WeeklyCampInspection: any[] = [];
  ErrorMessage: string = '';
  WeeklyCampInspectionRecord: any[] = [];
  Data: boolean = false;
  User:any;
  date!: Date;
  extractedNumber: number = 0;
  extractedDate!: Date;
  constructor(private loginService:LoginService,private AddNewWeeklyCampInspection: AddweeklyCampInspectionServiceService, private dataService: DataService) { }
  ngOnInit() {
    this.User=this.loginService.currentUser.getValue();
    console.log()
    this.dataService.GetWeeklyCampInspections(this.User.ID,this.User.Role).subscribe({
      next: data => {
        data.data.forEach((ele: any) => {
          this.WeeklyCampInspection.push(ele)
          console.log("$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$44")
          console.log(data.data)
          console.log(this.WeeklyCampInspection)
        });
        // this.Accident = data.data;
       this.WeeklyCampInspection = Array.from(new Set(this.WeeklyCampInspection))
        console.log(this.WeeklyCampInspection)
      },
      error: error => this.ErrorMessage = error
    })
  }

  

  WeeklyCampInspectionByRigAndDateSelected(event: any) {
    console.log("Input String:", event.target.value);
  
    const regex = /(\d+) \/ (\d{2}-\d{2}-\d{4})/;
    const match = event.target.value.match(regex);
  
    if (match) {
      const rigNumber = match[1];
      const date = match[2];
  
      console.log("Number: " + rigNumber);
      console.log("Date: " + date);
  
      const formattedDate = date.split('-').reverse().join('-');
  
      console.log("Formatted Date: " + formattedDate);
  
      this.AddNewWeeklyCampInspection.GetWeeklyCampInspectionByRigAndDate(formattedDate, this.User.ID, this.User.Role, rigNumber)
        .subscribe({
          next: response => {
            console.log("Full API Response:", response);
  
            const apiUrl = this.AddNewWeeklyCampInspection.GetWeeklyCampInspectionByRigAndDate(formattedDate, this.User.ID, this.User.Role, rigNumber); // Adjust the method name based on your service
            console.log("API Request URL:", apiUrl);
  
            this.WeeklyCampInspectionRecord = response.data;
            this.Data = true;
            console.log("dtoooooooo", this.WeeklyCampInspectionRecord);
            console.log("this.WeeklyCampInspectionRecord[0]", this.WeeklyCampInspectionRecord[0]);
            console.log("done");
          },
          error: error => {
            this.ErrorMessage = error;
            console.log("Error:", error);
          }
        });
    } else {
      console.log("No match found");
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
