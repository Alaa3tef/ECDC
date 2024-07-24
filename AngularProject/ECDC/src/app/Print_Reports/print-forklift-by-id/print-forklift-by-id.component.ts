import { Component } from '@angular/core';
import { ActivatedRoute, ParamMap } from '@angular/router';
import { DataService } from 'Services/data.service';
import { LoginService } from 'Services/login.service';

@Component({
  selector: 'app-print-forklift-by-id',
  templateUrl: './print-forklift-by-id.component.html',
  styleUrls: ['./print-forklift-by-id.component.scss']
})
export class PrintForkliftByIdComponent {
  ForkliftObj!: any;
  ErrorMessage: string = '';
  ForkliftId!: any;
  Data: boolean = false;
  User:any;

  constructor(
    private loginService:LoginService,
    private activatedRoute: ActivatedRoute,
    private dataService: DataService
    ) { }
  ngOnInit() {
    this.User=this.loginService.currentUser.getValue();
    this.activatedRoute.paramMap.subscribe((params: ParamMap) => {
      this.ForkliftId = params.get("id");
      console.log(this.ForkliftId)
    }),
      this.dataService.GetForkliftDataById(this.ForkliftId,this.User.ID,this.User.Role).subscribe({
        next: data => {
          this.ForkliftObj = data.data;
          this.Data = true;
          console.log("this.forkliftobj");

          console.log(this.ForkliftObj)
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
