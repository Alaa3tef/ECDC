import { Component } from '@angular/core';
import { DataService } from 'Services/data.service';
import { LoginService } from 'Services/login.service';
import { WeeklyClinicService } from 'Services/weekly-clinic.service';
import { IRig } from 'SharedClasses/IRig';
import { Chart } from 'chart.js';

@Component({
  selector: 'app-weekly-clinic-chart',
  templateUrl: './weekly-clinic-chart.component.html',
  styleUrls: ['./weekly-clinic-chart.component.scss']
})
export class WeeklyClinicChartComponent {
  clearChart(ID_Name: string) {
    const myElement = document.querySelector('#' + ID_Name) as HTMLElement;
    myElement.remove()
    this.HealthMeetingCount = 0
    this.WeeklyCasesCount = 0
    this.MedicalReportsNoCount = 0
    this.SnakeVaccineCount = 0
    this.ScorpionVaccineCount = 0
    this.TetanusVaccineCount = 0
    this.RabiesVaccineCount = 0

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
  HealthMeeting: any[] = [];
  HealthMeetingCount: number = 0;
  WeeklyCases: any[] = [];
  WeeklyCasesCount: number = 0;
  MedicalReportsNo: any[] = [];
  MedicalReportsNoCount: number = 0;
  SnakeVaccine: any[] = [];
  SnakeVaccineCount: number = 0;
  ScorpionVaccine: any[] = [];
  ScorpionVaccineCount: number = 0;
  TetanusVaccine: any[] = [];
  TetanusVaccineCount: number = 0;
  RabiesVaccine: any[] = [];
  RabiesVaccineCount: number = 0;

  rigList: IRig[] = [];
  User: any;

  constructor(private loginService: LoginService, private dataService: DataService, private WeeklydataService: WeeklyClinicService) { }

  ngOnInit(): void {
    //Called after the constructor, initializing input properties, and the first call to ngOnChanges.
    //Add 'implements OnInit' to the class.
    this.User = this.loginService.currentUser.getValue();
    this.dataService.GetRig().subscribe({
      next: data => {
        this.rigList = data.data
        console.log(this.rigList)
      }
    })
  }


  onChange(event: any) {
    console.log("event")
    console.log(event.target.value)
    const myComboBox = document.getElementById('date') as HTMLSelectElement;
    const selectedOption = myComboBox.options[myComboBox.selectedIndex];
    const selectedText = selectedOption.text;
    this.temp = true;
    this.WeeklydataService.GetWeeklyClinicByRig(event.target.value, this.User.ID, this.User.Role).subscribe({
      next: data => {
        console.log(data.data)
        this.clearChart("myChart3")

        if (data.data != null) {
          this.HealthMeetingCount = data.data.healthMeetingNo
          this.WeeklyCasesCount = data.data.weeklyClinicNo
          this.MedicalReportsNoCount = data.data.medicalReportNo
          if (data.data.fridgeComponents[0].item == "Snake Vaccine") {
            this.SnakeVaccineCount = data.data.fridgeComponents[0].quantity
          }
          if (data.data.fridgeComponents[1].item == "Scorpion Vaccine") {
            this.ScorpionVaccineCount = data.data.fridgeComponents[1].quantity
          }
          if (data.data.fridgeComponents[2].item == "Tetanus Vaccine") {
            this.TetanusVaccineCount = data.data.fridgeComponents[2].quantity
          }
          if (data.data.fridgeComponents[3].item == "Rabies Vaccine") {
            this.RabiesVaccineCount = data.data.fridgeComponents[3].quantity
          }
        }
        console.log("this.HealthMeetingCount")
        console.log(this.HealthMeetingCount)
        console.log("this.WeeklyCasesCount")
        console.log(this.WeeklyCasesCount)
        console.log("this.MedicalReportsNoCount")
        console.log(this.MedicalReportsNoCount)
        console.log("this.SnakeVaccineCount")
        console.log(this.SnakeVaccineCount)
        console.log("this.ScorpionVaccineCount")
        console.log(this.ScorpionVaccineCount)
        console.log("this.TetanusVaccineCount")
        console.log(this.TetanusVaccineCount)
        console.log("this.RabiesVaccineCount")
        console.log(this.RabiesVaccineCount)

        this.AddCanvas("myChart3", "chart3")

        var myChart3 = new Chart("myChart3", {
          type: 'bar',
          data: {
            labels: ["No. of Health Meeting with Crew", "Weekly Cases", "Medical Reports", "Snake Vaccine", "Scorpion Vaccine", "Tetanus Vaccine", "Rabies Vaccine"],
            datasets: [{
              label: selectedText,
              data: [this.HealthMeetingCount, this.WeeklyCasesCount, this.MedicalReportsNoCount, this.SnakeVaccineCount, this.ScorpionVaccineCount, this.TetanusVaccineCount, this.RabiesVaccineCount],
              backgroundColor: [
                'rgba(255, 99, 132, 0.2)',
                'rgba(255, 159, 64, 0.2)',
                'rgba(255, 205, 86, 0.2)',
                'rgba(75, 192, 192, 0.2)',
                'rgba(54, 162, 235, 0.2)',
                'rgba(153, 102, 255, 0.2)',
                'rgba(0, 255, 0, 0.2)',
              ],
              borderColor: [
                'rgba(255, 99, 132, 1)',
                'rgba(255, 159, 64, 1)',
                'rgba(255, 205, 86, 1)',
                'rgba(75, 192, 192, 1)',
                'rgba(54, 162, 235, 1)',
                'rgba(153, 102, 255, 1)',
                'rgba(0, 255, 0, 1)',
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
                  'rgba(0, 255, 0, 1)',
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
    this.HealthMeetingCount = 0;
    this.WeeklyCasesCount = 0;
    this.MedicalReportsNoCount = 0;
    this.SnakeVaccineCount = 0;
    this.ScorpionVaccineCount = 0;
    this.TetanusVaccineCount = 0;
    this.RabiesVaccineCount = 0;
  }
}
