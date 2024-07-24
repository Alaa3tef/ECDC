import { Component } from '@angular/core';
import { AddNewMedicalHistoryService } from 'Services/add-new-medical-history.service';
import { DataService } from 'Services/data.service';
import { LoginService } from 'Services/login.service';

@Component({
  selector: 'app-print-medical-history',
  templateUrl: './print-medical-history.component.html',
  styleUrls: ['./print-medical-history.component.scss']
})
export class PrintMedicalHistoryComponent {
  MedicalHistory: any[] = [];
  ErrorMessage: string = '';
  MedicalHistoryRecord: any[] = [];
  Data: boolean = false;
  User:any;
  date!: Date;
  extractedNumber: number = 0;
  extractedDate!: Date;
  constructor(private loginService:LoginService,private AddNewMedicalHistory: AddNewMedicalHistoryService, private dataService: DataService) { }
  ngOnInit() {
    this.User=this.loginService.currentUser.getValue();
    console.log()
    this.dataService.GetMedicalHistorys(this.User.ID,this.User.Role).subscribe({
      next: data => {
        data.data.forEach((ele: any) => {
          this.MedicalHistory.push(ele)
          console.log("$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$44")
          console.log(data.data)
          console.log(this.MedicalHistory)
        });
        // this.Accident = data.data;
       this.MedicalHistory = Array.from(new Set(this.MedicalHistory))
        console.log(this.MedicalHistory)
      },
      error: error => this.ErrorMessage = error
    })
  }



  MedicalHistoryByRigAndJopAndNameSelected(event: any) {
    console.log("Input String:", event.target.value);

    const regex = /(\d+)\/([\w\s]+)\/([\w\s]*)/;
    const match = event.target.value.match(regex);

    if (match) {
      const rigNumber = match[1];
      const jop = match[2];
      const name = match[3]; // Use match[0] for the entire match


      console.log("Number: " + rigNumber);
      console.log("Jop: " + jop);
      console.log("name: " + name);



      this.AddNewMedicalHistory.GetMedicalHistoryByRigNumerAndJopAndName(rigNumber,name,jop,this.User.ID, this.User.Role)
        .subscribe({
          next: response => {
            console.log("Full API Response:", response);

            const apiUrl = this.AddNewMedicalHistory.GetMedicalHistoryByRigNumerAndJopAndName(rigNumber,name,jop,this.User.ID, this.User.Role)
            console.log("API Request URL:", apiUrl);

            this.MedicalHistoryRecord = response.data;
            this.Data = true;
            console.log("dtoooooooo", this.MedicalHistoryRecord);
            console.log("this.MedicalHistoryRecord[0]", this.MedicalHistoryRecord[0]);
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
