import { Component } from '@angular/core';
import { DataService } from 'Services/data.service';
import { LoginService } from 'Services/login.service';
import { IStandard } from 'SharedClasses/IStandard';
import { Chart } from 'chart.js';

@Component({
  selector: 'app-corrective-by-standard',
  templateUrl: './corrective-by-standard.component.html',
  styleUrls: ['./corrective-by-standard.component.scss']
})
export class CorrectiveByStandardComponent {
  clearChart(ID_Name:string) {
    const myElement = document.querySelector('#'+ ID_Name) as HTMLElement;
    myElement.remove()
    this.Open = []
    this.Close = []
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
  Open: any[] = [];
  OpenCount: number = 0;
  Close: any[] = [];
  CloseCount: number = 0;
  standardList:IStandard[]=[];
  User:any;

  constructor(private loginService:LoginService,private dataService: DataService) {}

  ngOnInit(): void {
    //Called after the constructor, initializing input properties, and the first call to ngOnChanges.
    //Add 'implements OnInit' to the class.
    this.User=this.loginService.currentUser.getValue();
    this.dataService.GetStandard().subscribe({
      next:data=>{
        this.standardList=data.data
        console.log(this.standardList)
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
    this.dataService.GetCorrectiveByStandard(event.target.value,this.User.ID,this.User.Role).subscribe({
      next: data => {
        console.log(data.data)
        this.clearChart("myChart3")

        data.data.forEach((element: { formStatus: string; }) => {
          if (element.formStatus == 'open') {
            this.Open.push(element)
          }
          else if (element.formStatus == 'closed') {
            this.Close.push(element)
          }
        });
        this.OpenCount = this.Open.length
        this.CloseCount = this.Close.length

        console.log("this.OpenCount")
        console.log(this.OpenCount)
        console.log("this.CloseCount")
        console.log(this.CloseCount)

        this.AddCanvas("myChart3","chart3")

        var myChart3 = new Chart("myChart3", {
          type: 'bar',
          data: {
            labels: ["Open", "Closed"],
            datasets: [{
              label: selectedText,
              data: [this.OpenCount, this.CloseCount],
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

  }
}
