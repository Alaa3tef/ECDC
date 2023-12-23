import { Component } from '@angular/core';
import { DataService } from 'Services/data.service';
import { LoginService } from 'Services/login.service';
import { IRig } from 'SharedClasses/IRig';
import { IRigData } from 'SharedClasses/IRigDataForCompareTwoRigCustomer';
import { Chart } from 'chart.js';

@Component({
  selector: 'app-customer-compare-by-month-user',
  templateUrl: './customer-compare-by-month-user.component.html',
  styleUrls: ['./customer-compare-by-month-user.component.scss']
})
export class CustomerCompareByMonthUserComponent {
  clearChart(ID_Name: string) {
    const myElement = document.querySelector('#' + ID_Name) as HTMLElement;
    myElement.remove()
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
  RigList: IRig[] = [];
  YearList: number[] = [];
  Year: number = 0;
  ErrorMessage: string = '';
  User: any;
  Colors: string[] = [];
  rigData: any[] = [];
  ColorsBackground: any[] = []

  constructor(private dataService: DataService, private loginService: LoginService) { }

  ngOnInit(): void {
    //Called after the constructor, initializing input properties, and the first call to ngOnChanges.
    //Add 'implements OnInit' to the class.
    this.User = this.loginService.currentUser.getValue();
  
    this.dataService.GetCustomersReport(this.User.ID, this.User.Role).subscribe({
      next: data => {
        data.data.forEach((element: any) => {
          this.YearList.push(element.year)
          console.log('year formmaaaaaaaaate')
          console.log(this.YearList)
        });
        this.YearList = Array.from(new Set(this.YearList))
        console.log('year formmaaaaaaaaate')
        console.log(this.YearList)
      },
      error: err => {
        this.ErrorMessage = err
      }
    })
  }

 

  onChange(event: any) {
    this.Year = event.target.value
    console.log("this.Month", this.Year)
    this.temp = true;

    this.dataService.GetCustomerAnalysisByYearForUser(event.target.value, this.User.Role,this.User.ID).subscribe({
      next: data => {
        console.log('Data from server:', data);

        // Clear existing chart
        this.clearChart("myChart");

        // Arrays to store data for each rig
        const rigData: IRigData[] = data.data.map((element: IRigData) => ({
          evaluationResult: element.evaluationResult,
          month:element.month
        }));

        console.log("rigData:", rigData);

        // Assuming rigData is an array of objects with rigId and evaluationResult properties
        const flattenedData = rigData.map(rig => ({
          rigNumber: `Rig-${rig.rigNumber}`,
          evaluationResult: rig.evaluationResult,
          month:rig.month
        }));
        this.rigData = flattenedData;

        // Use the flattenedData array to create the chart

       
        const evaluationResults = flattenedData.map(data => data.evaluationResult);

        // Add the canvas and create the chart
        this.AddCanvas("myChart", "chart1");
        for (let i = 0; i < flattenedData.length; i++) {
          const red = Math.floor(Math.random() * 256);
          const green = Math.floor(Math.random() * 200);
          const blue = Math.floor(Math.random() * 256);
          const colorString = `rgba(${red}, ${green}, ${blue}, 1)`;
          const colorStringbackground = `rgba(${red}, ${green}, ${blue}, 0.2)`;
          this.ColorsBackground.push(colorStringbackground);
          this.Colors.push(colorString);
        }

        const myChart = new Chart("myChart", {
          type: 'bar',
          data: {
            labels: this.YearList,
            datasets: [{
              label: 'Evaluation Results',
              data: evaluationResults,
              backgroundColor: this.ColorsBackground,
              borderColor: this.Colors[0],
              borderWidth: 1,
              datalabels: {
                color: this.Colors[0],
                font: {
                  size: 15,
                }
              }
            }],
          },
          options: {
            responsive: true,
            plugins: {
              legend: {
                position: 'top',
              }
            },
            scales: {
              x: {
                type: 'category',
                position: 'bottom',
                offset: true,
              },
              y: {
                type: 'linear',
                position: 'left',
              }
            }
          }
        });
      },
      error: err => {
        this.ErrorMessage = err;
      }
    });
  }

}
