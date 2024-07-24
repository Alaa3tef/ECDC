import { Component } from '@angular/core';
import { DataService } from 'Services/data.service';
import { LoginService } from 'Services/login.service';
import { ICorrectiveResponsability } from 'SharedClasses/ICorrectiveResponsability';
import { Chart } from 'chart.js';

@Component({
  selector: 'app-corrective-by-suggested-date',
  templateUrl: './corrective-by-suggested-date.component.html',
  styleUrls: ['./corrective-by-suggested-date.component.scss']
})
export class CorrectiveBySuggestedDateComponent {
  clearChart(ID_Name: string) {
    const myElement = document.querySelector('#' + ID_Name) as HTMLElement;
    myElement.remove()
    this.Open = []
    // this.Close = []
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

  temp: boolean = false;
  Open: any[] = [];
  OpenCount: number = 0;
  Close: any[] = [];
  CloseCount: number = 0;
  Drilling: any[] = [];
  DrillingCount: number = 0;
  QHSE: any[] = [];
  QHSECount: number = 0;
  Services: any[] = [];
  ServicesCount: number = 0;
  Maintenance: any[] = [];
  MaintenanceCount: number = 0;
  Projects: any[] = [];
  ProjectsCount: number = 0;
  Transportation: any[] = [];
  TransportationCount: number = 0;
  Client: any[] = [];
  ClientCount: number = 0;
  HR: any[] = [];
  HRCount: number = 0;
  SupplyChain: any[] = [];
  SupplyChainCount: number = 0;
  Rig1: any[] = [];
  Rig1Count: number = 0;
  Rig2: any[] = [];
  Rig2Count: number = 0;
  Rig3: any[] = [];
  Rig3Count: number = 0;
  Rig5: any[] = [];
  Rig5Count: number = 0;
  Rig6: any[] = [];
  Rig6Count: number = 0;
  Rig9: any[] = [];
  Rig9Count: number = 0;
  Rig10: any[] = [];
  Rig10Count: number = 0;
  Rig810: any[] = [];
  Rig810Count: number = 0;
  Rig815: any[] = [];
  Rig815Count: number = 0;
  Chart2List: any[] = [];
  valuesList: any[] = [];
  respList: string[] = [];
  User: any;

  constructor(private loginService: LoginService, private dataService: DataService) { }

  ngOnInit(): void {
    //Called after the constructor, initializing input properties, and the first call to ngOnChanges.
    //Add 'implements OnInit' to the class.
    this.User = this.loginService.currentUser.getValue();
    this.dataService.GetCorrectiveResponsability().subscribe({
      next: data => {
        data.data.forEach((element: { responsibilityName: string; }) => {
          this.respList.push(element.responsibilityName)
        });
      },
      error: err => {
        console.log(err)
      }
    })
    this.draw()
  }


  draw() {
    // const myComboBox = document.getElementById('date') as HTMLSelectElement;
    // const selectedOption = myComboBox.options[myComboBox.selectedIndex];
    // const selectedText = selectedOption.text;
    this.temp = true;
    this.dataService.GetCorrectiveByDateForAnalysis(this.User.ID, this.User.Role).subscribe({
      next: data => {
        console.log(data.data)
        this.clearChart("myChart2")

        data.data.forEach((element: { formStatus: string; }) => {
          if (element.formStatus == 'open') {
            this.Chart2List.push(element)
          }
        });
        this.Chart2List.forEach((item) => {
          if (item.formResponsability == "Drilling") {
            this.Drilling.push(item)
          }
          else if (item.formResponsability == "QHSE") {
            this.QHSE.push(item)
          }
          else if (item.formResponsability == "Services") {
            this.Services.push(item)
          }
          else if (item.formResponsability == "Maintenance") {
            this.Maintenance.push(item)
          }
          else if (item.formResponsability == "Projects") {
            this.Projects.push(item)
          }
          else if (item.formResponsability == "Transportation") {
            this.Transportation.push(item)
          }
          else if (item.formResponsability == "Client") {
            this.Client.push(item)
          }
          else if (item.formResponsability == "HR") {
            this.HR.push(item)
          }
          else if (item.formResponsability == "Supply Chain") {
            this.SupplyChain.push(item)
          }
          else if (item.formResponsability == "Rig 1") {
            this.Rig1.push(item)
          }
          else if (item.formResponsability == "Rig 2") {
            this.Rig2.push(item)
          }
          else if (item.formResponsability == "Rig 3") {
            this.Rig3.push(item)
          }
          else if (item.formResponsability == "Rig 5") {
            this.Rig5.push(item)
          }
          else if (item.formResponsability == "Rig 6") {
            this.Rig6.push(item)
          }
          else if (item.formResponsability == "Rig 9") {
            this.Rig9.push(item)
          }
          else if (item.formResponsability == "Rig 10") {
            this.Rig10.push(item)
          }
          else if (item.formResponsability == "Rig 810") {
            this.Rig810.push(item)
          }
          else if (item.formResponsability == "Rig 815") {
            this.Rig815.push(item)
          }
        })
        this.DrillingCount = this.Drilling.length
        this.QHSECount = this.QHSE.length
        this.ServicesCount = this.Services.length
        this.MaintenanceCount = this.Maintenance.length
        this.ProjectsCount = this.Projects.length
        this.TransportationCount = this.Transportation.length
        this.ClientCount = this.Client.length
        this.HRCount = this.HR.length
        this.SupplyChainCount = this.SupplyChain.length
        this.Rig1Count = this.Rig1.length
        this.Rig2Count = this.Rig2.length
        this.Rig3Count = this.Rig3.length
        this.Rig5Count = this.Rig5.length
        this.Rig6Count = this.Rig6.length
        this.Rig9Count = this.Rig9.length
        this.Rig10Count = this.Rig10.length
        this.Rig810Count = this.Rig810.length
        this.Rig815Count = this.Rig815.length

        this.valuesList = [
          this.DrillingCount, this.QHSECount,
          this.ServicesCount, this.MaintenanceCount,
          this.ProjectsCount, this.TransportationCount,
          this.ClientCount, this.HRCount,
          this.SupplyChainCount, this.Rig1Count,
          this.Rig2Count, this.Rig3Count,
          this.Rig5Count, this.Rig6Count,
          this.Rig9Count, this.Rig10Count,
          this.Rig810Count, this.Rig815Count]

        this.AddCanvas("myChart2", "chart2")

        var myChart2 = new Chart("myChart2", {
          type: 'bar',
          data: {
            labels: this.respList,
            datasets: [{
              label: "Suggested Date",
              data: this.valuesList,
              backgroundColor: [
                'rgba(255, 99, 132, 0.2)',
                'rgba(255, 159, 64, 0.2)',
                'rgba(255, 205, 86, 0.2)',
                'rgba(75, 192, 192, 0.2)',
                'rgba(54, 162, 235, 0.2)',
                'rgba(153, 102, 255, 0.2)',
                'rgba(201, 203, 207, 0.2)',
                'rgba(255, 0, 0, 0.2)',
                'rgba(0, 255, 0, 0.2)',
                'rgba(0, 0, 255, 0.2)',
                'rgba(255, 255, 0, 0.2)',
                'rgba(0, 255, 255, 0.2)',
                'rgba(255, 0, 255, 0.2)',
                'rgba(192, 192, 192, 0.2)',
                'rgba(128, 128, 128, 0.2)',
                'rgba(128, 0, 0, 0.2)',
                'rgba(128, 128, 0, 0.2)',
                'rgba(0, 128, 0, 0.2)'
              ],
              borderColor: [
                'rgba(255, 99, 132, 1)',
                'rgba(255, 159, 64, 1)',
                'rgba(255, 205, 86, 1)',
                'rgba(75, 192, 192, 1)',
                'rgba(54, 162, 235, 1)',
                'rgba(153, 102, 255, 1)',
                'rgba(201, 203, 207, 1)',
                'rgba(255, 0, 0, 1)',
                'rgba(0, 255, 0, 1)',
                'rgba(0, 0, 255, 1)',
                'rgba(255, 255, 0, 1)',
                'rgba(0, 255, 255, 1)',
                'rgba(255, 0, 255, 1)',
                'rgba(192, 192, 192, 1)',
                'rgba(128, 128, 128, 1)',
                'rgba(128, 0, 0, 1)',
                'rgba(128, 128, 0, 1)',
                'rgba(0, 128, 0, 1)'
              ],
              borderWidth: 1,
              datalabels: {
                color: [
                  'rgba(255, 99, 132, 1)',
                  'rgba(255, 159, 64, 1)',
                  'rgba(255, 205, 86, 1)',
                  'rgba(75, 192, 192, 1)',
                  'rgba(54, 162, 235, 1)',
                  'rgba(153, 102, 255, 1)',
                  'rgba(201, 203, 207, 1)',
                  'rgba(255, 0, 0, 1)',
                  'rgba(0, 255, 0, 1)',
                  'rgba(0, 0, 255, 1)',
                  'rgba(255, 255, 0, 1)',
                  'rgba(0, 255, 255, 1)',
                  'rgba(255, 0, 255, 1)',
                  'rgba(192, 192, 192, 1)',
                  'rgba(128, 128, 128, 1)',
                  'rgba(128, 0, 0, 1)',
                  'rgba(128, 128, 0, 1)',
                  'rgba(0, 128, 0, 1)'
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

        myChart2.update();

      }
    });
  }

}
