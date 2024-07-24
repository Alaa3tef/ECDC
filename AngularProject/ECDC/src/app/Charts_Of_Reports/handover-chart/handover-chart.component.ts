import { Component } from '@angular/core';
import { DataService } from 'Services/data.service';
import { HandoverService } from 'Services/handover.service';
import { LoginService } from 'Services/login.service';
import { IRig } from 'SharedClasses/IRig';
import { Chart } from 'chart.js';

@Component({
  selector: 'app-handover-chart',
  templateUrl: './handover-chart.component.html',
  styleUrls: ['./handover-chart.component.scss']
})
export class HandoverChartComponent {
  clearChart(ID_Name: string) {
    const myElement = document.querySelector('#' + ID_Name) as HTMLElement;
    myElement.remove()
    this.StopCardsCount = 0
    this.DrillsCount = 0
    this.SafetyAlertsCount = 0
    this.InternalAuditCount = 0
    this.TrainingMatrixCount = 0

  }

  AddCanvas(ID_Name: string, DIV_Name: string) {
    // Create a new element
    var newElement = document.createElement('canvas');
    newElement.id = ID_Name

    // Get the parent element where you want to append the new element
    const myElement = document.querySelector('#' + DIV_Name) as HTMLElement;

    // Append the new element to the parent element
    myElement.appendChild(newElement);
  }

  Handover: any[] = [];
  HandoverRecord: any[] = [];
  ErrorMessage: string = '';
  temp: boolean = false;
  TrainingMatrix: any[] = [];
  TrainingMatrixCount: number = 0;
  InternalAudit: any[] = [];
  InternalAuditCount: number = 0;
  SafetyAlerts: any[] = [];
  SafetyAlertsCount: number = 0;
  Drills: any[] = [];
  DrillsCount: number = 0;
  StopCards: any[] = [];
  StopCardsCount: number = 0;

  rigList: IRig[] = [] ;
  User: any;

  constructor(private loginService: LoginService, private dataService: DataService, private HandoverdataService: HandoverService) { }

  ngOnInit(): void {
    //Called after the constructor, initializing input properties, and the first call to ngOnChanges.
    //Add 'implements OnInit' to the class.
    this.User = this.loginService.currentUser.getValue();
    // this.HandoverdataService.GetHandover(this.User.ID, this.User.Role).subscribe({
    //   next: data => {
    //     data.data.forEach((ele: any) => {
    //       // Check if the element already exists in Handover based on date and rig number
    //       const existingElement = this.Handover.find(item => item.leavingEmpName === ele.leavingEmpName && item.rigNo === ele.rigNo);
    //       if (!existingElement) {
    //         this.Handover.push(ele);
    //       }
    //     });
    //   },
    //   error: error => this.ErrorMessage = error
    // })
    this.dataService.GetRig().subscribe({
      next: data => {
        this.rigList = data.data
        console.log(this.rigList)
      }
    })
  }


  onChange(event: any) {
    // console.log("event")
    // console.log(event.target.value)
    // let match = event.target.value.split(/\s\/\s/);
    // console.log(match);


    // if (match) {
    //   const rigId = match[0];
    //   const leavingName = match[1];

    //   console.log("Number: " + rigId);
    //   console.log("leavingName: " + leavingName);

      const myComboBox = document.getElementById('date') as HTMLSelectElement;
      const selectedOption = myComboBox.options[myComboBox.selectedIndex];
      const selectedText = selectedOption.text;
      this.temp = true;
      this.HandoverdataService.GetHandoverByRig(event.target.value, this.User.ID, this.User.Role).subscribe({
        next: data => {
          console.log(data.data)
          this.clearChart("myChart3")

          data.data.forEach((element: { stopCards: number; drills: number; safetyAlerts: number; internalAudit: number; trainingMatrix: number; }) => {
            this.StopCardsCount += element.stopCards
            this.DrillsCount += element.drills
            this.SafetyAlertsCount += element.safetyAlerts
            this.InternalAuditCount += element.internalAudit
            this.TrainingMatrixCount += element.trainingMatrix
          });

          console.log("data.data")
          console.log(data.data)
          console.log("this.StopCardsCount")
          console.log(this.StopCardsCount)
          console.log("this.DrillsCount")
          console.log(this.DrillsCount)
          console.log("this.SafetyAlertsCount")
          console.log(this.SafetyAlertsCount)
          console.log("this.InternalAuditCount")
          console.log(this.InternalAuditCount)
          console.log("this.TrainingMatrixCount")
          console.log(this.TrainingMatrixCount)

          this.AddCanvas("myChart3", "chart3")

          var myChart3 = new Chart("myChart3", {
            type: 'bar',
            data: {
              labels: ["Stop Cards", "Drills", "Safety Alerts", "Internal Audit", "Training Matrix"],
              datasets: [{
                label: selectedText,
                data: [this.StopCardsCount, this.DrillsCount, this.SafetyAlertsCount, this.InternalAuditCount, this.TrainingMatrixCount],
                backgroundColor: [
                  'rgba(255, 99, 132, 0.2)',
                  'rgba(255, 159, 64, 0.2)',
                  'rgba(255, 205, 86, 0.2)',
                  'rgba(75, 192, 192, 0.2)',
                  'rgba(54, 162, 235, 0.2)',
                ],
                borderColor: [
                  'rgba(255, 99, 132, 1)',
                  'rgba(255, 159, 64, 1)',
                  'rgba(255, 205, 86, 1)',
                  'rgba(75, 192, 192, 1)',
                  'rgba(54, 162, 235, 1)',
                ],
                borderWidth: 1,
                datalabels: {
                  color: [
                    'rgba(255, 99, 132, 1)',
                    'rgba(255, 159, 64, 1)',
                    'rgba(255, 205, 86, 1)',
                    'rgba(75, 192, 192, 1)',
                    'rgba(54, 162, 235, 1)',
                  ],
                  font: {
                    size: 18,
                  }
                }
              }]
            },
            options: {
              scales: {
                y: {
                  beginAtZero: true
                }
              }
            }
          });

          myChart3.update();

        }
      });

    // }
  }
}
