import { Component, ElementRef, ViewChild } from '@angular/core';
import { DataService } from 'Services/data.service';
import { LoginService } from 'Services/login.service';
import { Chart } from 'chart.js';

@Component({
  selector: 'app-customer-compare-all-rigs-by-month',
  templateUrl: './customer-compare-all-rigs-by-month.component.html',
  styleUrls: ['./customer-compare-all-rigs-by-month.component.scss']
})
export class CustomerCompareAllRigsByMonthComponent {
  @ViewChild('myChartCanvas') myChartCanvas!: ElementRef;

  clearChart(ID_Name: string) {
    const myElement = document.querySelector('#' + ID_Name) as HTMLElement;
    myElement.remove();
    this.pushingListCounthing = []
    this.CustomerList = [];
    this.pushingList = [];
    this.Colors = [];
    this.ColorsBackground = [];
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
  myChart1: Chart | null = null; // Variable to store the Chart instance

  temp: boolean = false;
  ColorsBackground: any[] = []
  Rigs: any[] = [];
  CustomerList: any[] = [];
  pushingList: any[][] = []//any[]=[];
  pushingListCounthing: any[] = [];
  User: any;
  RigNames: string[] = [];
  Colors: string[] = [];
  test: string[] = ['vvvv', 'fff', 'dddd']
  Month: any[] = [];
  MonthsList: any[] = [];


  constructor(private dataService: DataService, private loginService: LoginService) { }

  ngOnInit(): void {
    //Called after the constructor, initializing input properties, and the first call to ngOnChanges.
    //Add 'implements OnInit' to the class.
    this.User = this.loginService.currentUser.getValue();

    this.dataService.GetRig().subscribe({
      next: data => {
        this.Rigs = data.data;
        this.Rigs.forEach(element => {
          // var name= 'Rig-'+element.number
          this.RigNames.push('Rig-' + element.number)

        });
        console.log('this.RigNames')
        console.log(this.RigNames)
      }
    })
    this.dataService.GetCustomersReport(this.User.ID, this.User.Role).subscribe({
      next: data => {
        data.data.forEach((ele: any) => {
          this.Month.push(ele.month)
        });
        console.log('this.Monthhhhhhhhh')
        console.log(this.Month)
        this.Month.forEach((ele: any) => {
          if (typeof ele === 'number') {
            const Month = ele;
            this.MonthsList.push(Month);
          } else if (typeof ele === 'string') {
            const Month = parseInt(ele, 10);
            if (!isNaN(Month)) {
              this.MonthsList.push(Month);
            }
          }
        });
        
        this.MonthsList = Array.from(new Set(this.MonthsList));
        console.log('Month formmaaaaaaaaate')
        console.log(this.MonthsList)
      }
    })

  }

  onChange(event: any) {
    console.log("event")
    console.log(event)
    const myComboBox = document.getElementById('month') as HTMLSelectElement;
    const selectedOption = myComboBox.options[myComboBox.selectedIndex];
    const selectedText = selectedOption.text;
    this.temp = true;
    console.log('selectedOption')
    console.log(selectedOption)
    console.log('selectedText')
    console.log(selectedText)
    console.log('event.target.value')
    console.log(event.target.value)

    this.dataService.GetCustomerAnalysisWithCompareByMonth(event.target.value, this.User.Role).subscribe({
      next: data => {
        this.clearChart("myChart")
        this.CustomerList = data.data
        console.log(data.data)

        // Initialize pushingList as an empty 2D array
        for (var i = 0; i < this.CustomerList.length; i++) {
          // Check if this item has been added to any row
          let added = false;

          for (var j = 0; j < this.pushingList.length; j++) {
            const row = this.pushingList[j];

            // Check if the item's rigId matches any item in the current row
            if (row.some(item => item.rigId === this.CustomerList[i].rigId)) {
              row.push(this.CustomerList[i]);
              added = true;
              break;
            }
          }

          // If the item wasn't added to any existing row, create a new row
          if (!added) {
            this.pushingList.push([this.CustomerList[i]]);
          }
        }
        console.log('this.pushingList')
        console.log(this.CustomerList)
        console.log(this.pushingList)
        console.log(this.Rigs)
        this.pushingListCounthing = new Array(this.Rigs.length).fill(0);
        for (var i = 0; i < this.Rigs.length; i++) {
          for (var j = 0; j < this.pushingList.length; j++) {
            let foundMatchInRow = false; // Flag to check if a match is found in the row

            for (var k = 0; k < this.pushingList[j].length; k++) {

              if (this.Rigs[i].id === this.pushingList[j][k].rigId) {
                foundMatchInRow = true;
                break; // Exit the inner loop once a match is found
              }

            }

            // If a match is found in the row, update the count in the result array
            if (foundMatchInRow) {
              this.pushingListCounthing[i] = this.pushingList[j].length;
            }
          }
        }
        console.log('this.pushingListCounthing')
        console.log(this.pushingListCounthing)

        for (let i = 0; i < this.pushingListCounthing.length; i++) {
          const red = Math.floor(Math.random() * 256);
          const green = Math.floor(Math.random() * 200);
          const blue = Math.floor(Math.random() * 256);
          const colorString = `rgba(${red}, ${green}, ${blue}, 1)`;
          const colorStringbackground = `rgba(${red}, ${green}, ${blue}, 0.2)`;
          this.ColorsBackground.push(colorStringbackground);
          this.Colors.push(colorString);
        }
        this.AddCanvas("myChart", "chart1")
        var myChart = new Chart("myChart", {
          type: 'bar',
          data: {
            labels: this.RigNames,
            datasets: [{
              label: selectedText,
              data: this.pushingListCounthing,
              backgroundColor: this.ColorsBackground
              // [
              //   'rgba(255, 99, 132, 0.2)',
              //   'rgba(54, 162, 235, 0.2)',
              //   'rgba(255, 206, 86, 0.2)',
              //   'rgba(75, 192, 192, 0.2)'
              // ]
              ,
              borderColor: this.Colors
              // [
              //   'rgba(255, 99, 132, 1)',
              //   'rgba(54, 162, 235, 1)',
              //   'rgba(255, 206, 86, 1)',
              //   'rgba(75, 192, 192, 1)'
              // ]
              ,
              borderWidth: 1,
              datalabels: {
                color: this.Colors
                //  [
                //   'rgba(255, 99, 132, 1)',
                //   'rgba(54, 162, 235, 1)',
                //   'rgba(255, 206, 86, 1)',
                //   'rgba(75, 192, 192, 1)'
                // ]
                ,
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

        this.createChart()
      }
    });
  }

  createChart() {
    if (this.myChartCanvas && this.myChartCanvas.nativeElement) {
      const ctx = this.myChartCanvas.nativeElement.getContext('2d');

      if (!ctx) {
        console.error('Canvas context is not available.');
        return;
      }

      // Destroy existing chart if it exists
      if (this.myChart1) {
        this.myChart1.destroy();
      }
// Assuming this.pushingList is an array of rigs with evaluation results
const rigData = this.pushingList.map(row => ({
  rigNumber: `Rig-${row[0].rigNumber}`,
  evaluationResults: row.map(result => result.evaluationResult),
}));

console.log('rigData:', rigData);

const flattenedData = rigData.flatMap(rig => rig.evaluationResults.map(result => ({
  rigNumber: rig.rigNumber,
  evaluationResult: result,
})));


const rigNumber = flattenedData.map(data => data.rigNumber);
const evaluationResults = flattenedData.map(data => data.evaluationResult);



this.myChart1 = new Chart(ctx, {
        type: 'bar',
        data: {
          labels: rigNumber,
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
          scales: {
            y: {
              beginAtZero: true,
            },
          },
        },
      });
    } else {
      console.error('Canvas element is not available.');
    }
  }
}
