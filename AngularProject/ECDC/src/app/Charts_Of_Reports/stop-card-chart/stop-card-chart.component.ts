import { Component } from '@angular/core';
import { DataService } from 'Services/data.service';
import { LoginService } from 'Services/login.service';
import { Chart, registerables } from 'chart.js';
import ChartDataLabels from 'chartjs-plugin-datalabels';
Chart.register(ChartDataLabels);
Chart.register(...registerables);

@Component({
  selector: 'app-stop-card-chart',
  templateUrl: './stop-card-chart.component.html',
  styleUrls: ['./stop-card-chart.component.scss'],
})

export class StopCardChartComponent {
  clearChart(ID_Name:string) {
    const myElement = document.querySelector('#'+ ID_Name) as HTMLElement;
    myElement.remove()
    this.UnsafeAct=[]
    this.UnsafeCondition=[]
    this.PositiveRemark=[]
    this.Other=[]
    this.BypassingSafetyControls = []
    this.Driving = []
    this.EnergyIsolation = []
    this.HotWork = []
    this.LineofFire = []
    this.SafeMechanicalLifting = []
    this.WorkAuthorization = []
    this.WorkingatHeight = []
    this.PPE = []
    this.Housekeeping = []
    this.Environmental = []
    this.HealthCare = [];
    this.SafetyProtectionSystem = []
    this.HSEIMS= []
    this.Equipment = []
    this.OtherCategory= []
    this.SWA_yes = []
    this.SWA_no = []
    this.pushingListCounthing = []
    this.PotentialList = [];
    this.pushingList = [];
    this.Colors = [];
    this.ColorsBackground = [];
  }

  AddCanvas(ID_Name:string,DIV_Name:string) {
    // Create a new element
    var newElement = document.createElement('canvas');
    newElement.id=ID_Name

    // Get the parent element where you want to append the new element
    const myElement = document.querySelector('#'+DIV_Name) as HTMLElement;

    // Append the new element to the parent element
    myElement.appendChild(newElement);
  }

  temp: boolean = false;
  classifications: string[] = [];
  categories: string[] = [];
  UnsafeAct: any[] = [];
  UnsafeActCount: number = 0;
  UnsafeCondition: any[] = [];
  UnsafeConditionCount: number = 0;
  PositiveRemark: any[] = [];
  PositiveRemarkCount: number = 0;
  Other: any[] = [];
  OtherCount: number = 0;
  BypassingSafetyControls: any[] = [];
  BypassingSafetyControlsCount: number = 0;
  Driving: any[] = [];
  DrivingCount: number = 0;
  EnergyIsolation: any[] = [];
  EnergyIsolationCount: number = 0;
  HotWork: any[] = [];
  HotWorkCount: number = 0;
  LineofFire: any[] = [];
  LineofFireCount: number = 0;
  SafeMechanicalLifting: any[] = [];
  SafeMechanicalLiftingCount: number = 0;
  WorkAuthorization: any[] = [];
  WorkAuthorizationCount: number = 0;
  WorkingatHeight: any[] = [];
  WorkingatHeightCount: number = 0;
  PPE: any[] = [];
  PPECount: number = 0;
  Housekeeping: any[] = [];
  HousekeepingCount: number = 0;
  Environmental: any[] = [];
  EnvironmentalCount: number = 0;
  HealthCare: any[] = [];
  HealthCareCount: number = 0;
  SafetyProtectionSystem: any[] = [];
  SafetyProtectionSystemCount: number = 0;
  HSEIMS: any[] = [];
  HSEIMSCount: number = 0;
  Equipment: any[] = [];
  EquipmentCount: number = 0;
  OtherCategory: any[] = [];
  OtherCategoryCount: number = 0;
  SWA_yes: any[] = [];
  SWA_yesCount: number = 0;
  SWA_no: any[] = [];
  SWA_noCount: number = 0;
  ErrorMessage: string = '';
  Year:number[]=[];
  YearsList:number[]=[];
  SelectedYear:number=0;
  ColorsBackground: any[] = []
  Rigs: any[] = [];
  PotentialList: any[] = [];
  pushingList: any[][] = []//any[]=[];
  pushingListCounthing: any[] = [];
  User: any;
  RigNames: string[] = [];
  Colors: string[] = [];

  constructor(private loginService:LoginService,private dataService: DataService) {}

  ngOnInit(): void {
    //Called after the constructor, initializing input properties, and the first call to ngOnChanges.
    //Add 'implements OnInit' to the class.
    this.User=this.loginService.currentUser.getValue();
    // this.dataService.GetRig().subscribe({
    //   next: data => {
    //     this.Rigs = data.data;
    //     this.Rigs.forEach(element => {
    //       // var name= 'Rig-'+element.number
    //       this.RigNames.push('Rig-' + element.number)

    //     });
    //     console.log('this.RigNames')
    //     console.log(this.RigNames)
    //   }
    // })
    this.dataService.GetClassification().subscribe({
      next: data => {
        data.data.forEach((element: { name: string; }) => {
          this.classifications.push(element.name)
        });
      }
    })
    this.dataService.GetTypeOfObservationCategory().subscribe({
      next: data => {
        data.data.forEach((element: { name: string; }) => {
          this.categories.push(element.name)
        });
      }
    })
    this.dataService.GetStopCards(this.User.ID, this.User.Role).subscribe({
      next:data=>{
        data.data.forEach((ele: any) => {
          this.Year.push(ele.date)
        });

        this.Year.forEach((ele: any) => {
          const dateObject = new Date(ele);
          const year = dateObject.getFullYear();
          this.YearsList.push(year)
          this.YearsList= Array.from(new Set(this.YearsList))

        });
      }
    })
    this.dataService.GetStopCards(this.User.ID, this.User.Role).subscribe({
      next: data => {
        this.Rigs = data.data;
        this.Rigs.forEach(element => {
          // var name= 'Rig-'+element.number
          this.RigNames.push(element.userName)

        });
        console.log('this.RigNamessssssssssssssssssssssssssssss')
        console.log(this.RigNames)
      }
    })
  }
  onYearChange(event: any) {
    this.SelectedYear = event.target.value
    console.log("this.yearrr", this.Year)

  }
onMonth(event:any){

}
  onChange(event: any) {
    console.log("event")
    console.log(event)
    const myComboBox = document.getElementById('month') as HTMLSelectElement;
    const selectedOption = myComboBox.options[myComboBox.selectedIndex];
    const selectedText = selectedOption.text;
    console.log("Year:", this.Year);

    this.temp = true;

    this.dataService.GetStopCardsByMonth(event.target.value,this.SelectedYear,this.User.ID,this.User.Role).subscribe({
      next: data => {
        console.log(data.data)
        this.clearChart("myChart")
        data.data.forEach((element: { classification: string; }) => {
          if (element.classification == 'Unsafe Act') {
            this.UnsafeAct.push(element)
          }
          else if (element.classification == 'Positive Remark') {
            this.PositiveRemark.push(element)
          }
          else if (element.classification == 'Unsafe Condition') {
            this.UnsafeCondition.push(element)
          }
          else {
            this.Other.push(element)
          }
        });
        this.UnsafeActCount = this.UnsafeAct.length
        this.UnsafeConditionCount = this.UnsafeCondition.length
        this.PositiveRemarkCount = this.PositiveRemark.length
        this.OtherCount = this.Other.length


        this.AddCanvas("myChart","chart1")

        var myChart = new Chart("myChart", {
          type: 'bar',
          data: {
            labels: this.classifications,
            datasets: [{
              label: selectedText,
              data: [this.UnsafeActCount, this.UnsafeConditionCount, this.PositiveRemarkCount, this.OtherCount],
              backgroundColor: [
                'rgba(255, 99, 132, 0.2)',
                'rgba(54, 162, 235, 0.2)',
                'rgba(255, 206, 86, 0.2)',
                'rgba(75, 192, 192, 0.2)'
              ],
              borderColor: [
                'rgba(255, 99, 132, 1)',
                'rgba(54, 162, 235, 1)',
                'rgba(255, 206, 86, 1)',
                'rgba(75, 192, 192, 1)'
              ],
              borderWidth: 1,
              datalabels: {
                color: [
                  'rgba(255, 99, 132, 1)',
                  'rgba(54, 162, 235, 1)',
                  'rgba(255, 206, 86, 1)',
                  'rgba(75, 192, 192, 1)'
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
      }
    });

    this.dataService.GetStopCardsByMonth(event.target.value,this.SelectedYear,this.User.ID,this.User.Role).subscribe({
      next: data => {
        console.log(data.data)
        this.clearChart("myChart2")

        data.data.forEach((element: { typeOfObservationCategory: string; }) => {
          if (element.typeOfObservationCategory == 'Bypassing Safety Controls') {
            this.BypassingSafetyControls.push(element)
          }
          else if (element.typeOfObservationCategory == 'Driving') {
            this.Driving.push(element)
          }
          else if (element.typeOfObservationCategory == 'Energy Isolation') {
            this.EnergyIsolation.push(element)
          }
          else if (element.typeOfObservationCategory == 'Hot Work') {
            this.HotWork.push(element)
          }
          else if (element.typeOfObservationCategory == 'Line of Fire') {
            this.LineofFire.push(element)
          }
          else if (element.typeOfObservationCategory == 'Safe Mechanical Lifting') {
            this.SafeMechanicalLifting.push(element)
          }
          else if (element.typeOfObservationCategory == 'Work Authorization') {
            this.WorkAuthorization.push(element)
          }
          else if (element.typeOfObservationCategory == 'Working at Height') {
            this.WorkingatHeight.push(element)
          }
          else if (element.typeOfObservationCategory == 'PPE') {
            this.PPE.push(element)
          }
          else if (element.typeOfObservationCategory == 'Housekeeping') {
            this.Housekeeping.push(element)
          }
          else if (element.typeOfObservationCategory == 'Environmental') {
            this.Environmental.push(element)
          }
          else if (element.typeOfObservationCategory == 'Health Care') {
            this.HealthCare.push(element)
          }
          else if (element.typeOfObservationCategory == 'Safety Protection System') {
            this.SafetyProtectionSystem.push(element)
          }
          else if (element.typeOfObservationCategory == 'HSE IMS') {
            this.HSEIMS.push(element)
          }
          else if (element.typeOfObservationCategory == 'Equipment') {
            this.Equipment.push(element)
          }
          else {
            this.OtherCategory.push(element)
          }
        });

        this.BypassingSafetyControlsCount = this.BypassingSafetyControls.length
        this.DrivingCount = this.Driving.length
        this.EnergyIsolationCount = this.EnergyIsolation.length
        this.HotWorkCount = this.HotWork.length
        this.LineofFireCount = this.LineofFire.length
        this.SafeMechanicalLiftingCount = this.SafeMechanicalLifting.length
        this.WorkAuthorizationCount = this.WorkAuthorization.length
        this.WorkingatHeightCount = this.WorkingatHeight.length
        this.PPECount = this.PPE.length
        this.HousekeepingCount = this.Housekeeping.length
        this.EnvironmentalCount = this.Environmental.length
        this.HealthCareCount = this.HealthCare.length
        this.SafetyProtectionSystemCount = this.SafetyProtectionSystem.length
        this.HSEIMSCount = this.HSEIMS.length
        this.EquipmentCount = this.Equipment.length
        this.OtherCategoryCount = this.OtherCategory.length

        this.AddCanvas("myChart2","chart2")

        var myChart2 = new Chart("myChart2", {
          type: 'bar',
          data: {
            labels: this.categories,
            datasets: [{
              label: selectedText,
              data: [
                this.BypassingSafetyControlsCount,
                this.DrivingCount,
                this.EnergyIsolationCount,
                this.HotWorkCount,
                this.LineofFireCount,
                this.SafeMechanicalLiftingCount,
                this.WorkAuthorizationCount,
                this.WorkingatHeightCount,
                this.PPECount,
                this.HousekeepingCount,
                this.EnvironmentalCount,
                this.HealthCareCount,
                this.SafetyProtectionSystemCount,
                this.HSEIMSCount,
                this.EquipmentCount,
                this.OtherCategoryCount
              ],
              backgroundColor: [
                'rgba(255, 99, 132, 0.2)',
                'rgba(54, 162, 235, 0.2)',
                'rgba(255, 206, 86, 0.2)',
                'rgba(75, 192, 192, 0.2)',
                'rgba(255, 99, 237, 0.2)',
                'rgba(166, 99, 255, 0.2)',
                'rgba(99, 240, 255, 0.2)',
                'rgba(255, 202, 99, 0.2)',
                'rgba(166, 255, 99, 0.2)',
                'rgba(57, 9, 140, 0.2)',
                'rgba(10, 140, 9, 0.2)',
                'rgba(140, 84, 9, 0.2)',
                'rgba(158, 10, 147, 0.2)',
                'rgba(47, 4, 43, 0.2)',
                'rgba(12, 16, 151, 0.2)',
                'rgba(12, 151, 132, 0.2)'
              ],
              borderColor: [
                'rgba(255, 99, 132, 1)',
                'rgba(54, 162, 235, 1)',
                'rgba(255, 206, 86, 1)',
                'rgba(75, 192, 192, 1)',
                'rgba(255, 99, 237, 1)',
                'rgba(166, 99, 255, 1)',
                'rgba(99, 240, 255, 1)',
                'rgba(255, 202, 99, 1)',
                'rgba(166, 255, 99, 1)',
                'rgba(57, 9, 140, 1)',
                'rgba(10, 140, 9, 1)',
                'rgba(140, 84, 9, 1)',
                'rgba(158, 10, 147, 1)',
                'rgba(47, 4, 43, 1)',
                'rgba(12, 16, 151, 1)',
                'rgba(12, 151, 132, 1)'
              ],
              borderWidth: 1,
              datalabels: {
                color: [
                  'rgba(255, 99, 132, 1)',
                  'rgba(54, 162, 235, 1)',
                  'rgba(255, 206, 86, 1)',
                  'rgba(75, 192, 192, 1)',
                  'rgba(255, 99, 237, 1)',
                  'rgba(166, 99, 255, 1)',
                  'rgba(99, 240, 255, 1)',
                  'rgba(255, 202, 99, 1)',
                  'rgba(166, 255, 99, 1)',
                  'rgba(57, 9, 140, 1)',
                  'rgba(10, 140, 9, 1)',
                  'rgba(140, 84, 9, 1)',
                  'rgba(158, 10, 147, 1)',
                  'rgba(47, 4, 43, 1)',
                  'rgba(12, 16, 151, 1)',
                  'rgba(12, 151, 132, 1)'
                ],
                font: {
                  size: 14,
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
    this.dataService.GetStopCardsByMonth(event.target.value,this.SelectedYear,this.User.ID,this.User.Role).subscribe({
      next: data => {
        console.log(data.data)
        this.clearChart("myChart3")

        data.data.forEach((element: { stopWorkAuthorityApplied: string; }) => {
          if (element.stopWorkAuthorityApplied == 'Yes') {
            this.SWA_yes.push(element)
          }
          else if (element.stopWorkAuthorityApplied == 'No') {
            this.SWA_no.push(element)
          }
        });
        this.SWA_yesCount = this.SWA_yes.length
        this.SWA_noCount = this.SWA_no.length

        console.log("this.SWA_yesCount")
        console.log(this.SWA_yesCount)
        console.log("this.SWA_noCount")
        console.log(this.SWA_noCount)

        this.AddCanvas("myChart3","chart3")

        var myChart3 = new Chart("myChart3", {
          type: 'bar',
          data: {
            labels: ["Yes", "No"],
            datasets: [{
              label: selectedText,
              data: [this.SWA_yesCount, this.SWA_noCount],
              backgroundColor: [
                'rgba(255, 99, 132, 0.2)',
                'rgba(54, 162, 235, 0.2)',
              ],
              borderColor: [
                'rgba(255, 99, 132, 1)',
                'rgba(54, 162, 235, 1)',
              ],
              borderWidth: 1,
              datalabels: {
                color: [
                  'rgba(255, 99, 132, 1)',
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
    this.dataService.GetStopCardsByMonth(event.target.value, this.SelectedYear, this.User.ID, this.User.Role).subscribe({
      next: data => {
        this.clearChart("myChart4");
        this.PotentialList = data.data;
        this.pushingList = [];

        // Organize the data by username
        const reportCounts = this.PotentialList.reduce((acc, item) => {
          if (!acc[item.userName]) {
            acc[item.userName] = 0;
          }
          acc[item.userName] += 1;
          return acc;
        }, {});

        // Extract usernames and their corresponding counts
        this.RigNames = Object.keys(reportCounts); // Usernames
        this.pushingListCounthing = Object.values(reportCounts); // Number of reports per user
        console.log("ggggggggggggggggggggg",this.pushingListCounthing);
        // Generate random colors
        this.ColorsBackground = [];
        this.Colors = [];
        for (let i = 0; i < this.pushingListCounthing.length; i++) {
          const red = Math.floor(Math.random() * 256);
          const green = Math.floor(Math.random() * 200);
          const blue = Math.floor(Math.random() * 256);
          this.ColorsBackground.push(`rgba(${red}, ${green}, ${blue}, 0.2)`);
          this.Colors.push(`rgba(${red}, ${green}, ${blue}, 1)`);
        }

        // Create or update the chart
        this.AddCanvas("myChart4", "chart4");

        const myChart4 = new Chart("myChart4", {
          type: 'bar',
          data: {
            labels: this.RigNames, // Unique Usernames
            datasets: [{
              label: `Reports made by users (${event.target.value})`,
              data: this.pushingListCounthing, // Total number of reports per user
              backgroundColor: this.ColorsBackground,
              borderColor: this.Colors,
              borderWidth: 1,
              datalabels: {
                display: true, // Show labels
                color: this.Colors, // Color of the text labels
                anchor: 'center', // Center the labels on the bars
                align: 'center',
                font: {
                  size: 14, // Adjust the font size for readability
                },
                formatter: function(value, context) {
                  return value; // Display the count directly on the chart
                }
              }
            }]
          },
          options: {
            responsive: true,
            scales: {
              x: {
                ticks: {
                  autoSkip: false, // Don't skip ticks (since users should be unique)
                  maxRotation: 60, // Increase label rotation angle if needed
                  minRotation: 60,
                  maxTicksLimit: 20, // Adjust the limit based on number of users
                },
                title: {
                  display: true,
                  text: 'Usernames',
                },
              },
              y: {
                beginAtZero: true,
                title: {
                  display: true,
                  text: 'Number of Reports',
                }
              }
            },
            plugins: {
              legend: {
                display: true,
                position: 'top',
              },
              tooltip: {
                enabled: true, // Enable tooltips to show data on hover
              },
              datalabels: {
                display: true, // Ensure datalabels are displayed
                align: 'end',
                anchor: 'end',
                font: {
                  weight: 'bold',
                  size: 14,
                },
                formatter: (value) => {
                  return value; // Show the value directly
                }
              }
            },
          }
        });


      }
    });


  }

}
