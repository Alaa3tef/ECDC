import { Component } from '@angular/core';
import { DataService } from 'Services/data.service';
import { LoginService } from 'Services/login.service';
import { IRig } from 'SharedClasses/IRig';
import { Chart } from 'chart.js';

@Component({
  selector: 'app-get-medical-history-report-by-year-with-chart',
  templateUrl: './get-medical-history-report-by-year-with-chart.component.html',
  styleUrls: ['./get-medical-history-report-by-year-with-chart.component.scss']
})
export class GetMedicalHistoryReportByYearWithChartComponent {
  ErrorMessage: any;
  clearChart(ID_Name: string) {
    const myElement = document.querySelector('#' + ID_Name) as HTMLElement;
    myElement.remove();
    this.pushingListCounthing = []
    this.PotentialList = [];
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

  temp: boolean = false;
  ColorsBackground: any[] = []
  Rigs: any[] = [];
  PotentialList: any[] = [];
  pushingList: any[][] = []//any[]=[];
  pushingListCounthing: any[] = [];
  User: any;
  RigNames: string[] = [];
  Colors: string[] = [];
  test: string[] = ['vvvv', 'fff', 'dddd']
  Year: any[] = [];
  YearsList: any[] = [];
  RigList: IRig[] = [];
  Rig1: number = 0;
  Socia_HaveYouSufferedAnswer:any[]=[]
  Socia_HaveYouSufferedAnswerCount: number = 0;
  Socia_DoYouSmokeAnswer:any[]=[]
  Socia_DoYouSmokeAnswerCount: number = 0;
  family_AllergyAnswer:any[]=[]
  family_AllergyAnswerCount: number = 0;
  family_SurgeryAnswer:any[]=[]
  family_SurgeryAnswerCount: number = 0;
  family_HospitalizationAnswer:any[]=[]
  family_HospitalizationAnswerCount: number = 0;
  family_DiscProlapseAnswer:any[]=[]
  family_DiscProlapseAnswerCount: number = 0;
  family_DizzinessAnswer:any[]=[]
  family_DizzinessAnswerCount: number = 0;
  family_InfectiousAnswer:any[]=[]
  family_InfectiousAnswerCount: number = 0;
  family_KidneyAnswer:any[]=[]
  family_KidneyAnswerCount: number = 0;
  family_DepressionAnswer:any[]=[]
  family_DepressionAnswerCount: number = 0;
  family_NeurologicalAnswer:any[]=[]
  family_NeurologicalAnswerCount: number = 0;
  family_GITAnswer:any[]=[]
  family_GITAnswerCount: number = 0;
  family_DiabetesAnswer:any[]=[]
  family_DiabetesAnswerCount: number = 0;
  family_COPDAnswer:any[]=[]
  family_COPDAnswerCount: number = 0;
  family_HeartDiseaseAnswer:any[]=[]
  family_HeartDiseaseAnswerCount: number = 0;
  family_HighBloodPressureAnswer:any[]=[]
  family_HighBloodPressureAnswerCount: number = 0;
  constructor(private dataService: DataService, private loginService: LoginService) { }

  ngOnInit(): void {
    //Called after the constructor, initializing input properties, and the first call to ngOnChanges.
    //Add 'implements OnInit' to the class.
    this.User = this.loginService.currentUser.getValue();

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
    this.dataService.GetRig().subscribe({
      next: data => {
        this.RigList = data.data
      },
      error: err => {
        this.ErrorMessage = err
      }
    })
    // this.dataService.GetMedicalHistorys(this.User.ID, this.User.Role).subscribe({
    //   next: data => {
    //     data.data.forEach((ele: any) => {
    //       this.Year.push(ele)
    //     });
    //     // console.log('this.Year')
    //     // console.log(this.Year)
    //     // this.Year.forEach((ele: any) => {
    //     //   const dateObject = new Date(ele);
    //     //   const year = dateObject.getFullYear();
    //     //   this.YearsList.push(year)
    //     //   this.YearsList = Array.from(new Set(this.YearsList))

    //     // });
    //     // console.log('year formmaaaaaaaaate')
    //     // console.log(this.YearsList)
    //   }
    // })

  }
  // onRig1Change(event: any) {
  //   this.Rig1 = event.target.value
  //   console.log("this.Rig1", this.Rig1)
  // }
  onChange(event: any) {
    console.log("event")
    console.log(event)
    const myComboBox = document.getElementById('Rig1') as HTMLSelectElement;
    const selectedOption = myComboBox.options[myComboBox.selectedIndex];
    const selectedText = selectedOption.text;
    this.temp = true;
    console.log('selectedOption')
    console.log(selectedOption)
    console.log('selectedText')
    console.log(selectedText)
    console.log('event.target.value')
    console.log(event.target.value)
    console.log("Rig1:", this.Rig1);

    this.dataService.GetMedicalHistoryReportAnalysisWithCompareByYear(event.target.value,this.User.Role).subscribe({
      next: data => {
        console.log('data', data);
        this.clearChart("myChart")
        data.data.forEach((element: { socia_DoYouSmokeAnswer: string, socia_HaveYouSufferedAnswer:string,
          family_AllergyAnswer:string,family_SurgeryAnswer:string,family_HospitalizationAnswer:string,family_DiscProlapseAnswer:string,
          family_DizzinessAnswer:string,family_InfectiousAnswer:string,family_KidneyAnswer:string,
          family_DepressionAnswer:string,family_NeurologicalAnswer:string,family_GITAnswer:string,family_DiabetesAnswer:string,
          family_COPDAnswer:string,family_HeartDiseaseAnswer:string,family_HighBloodPressureAnswer:string
         }) => {
          console.log('element.socia_DoYouSmokeAnswer', element.socia_DoYouSmokeAnswer);

          if (element.socia_DoYouSmokeAnswer == 'Yes') {
            this.Socia_DoYouSmokeAnswer.push(element)
          }
         if (element.socia_HaveYouSufferedAnswer == 'Yes') {
          console.log("element.socia_HaveYouSufferedAnswer",element.socia_HaveYouSufferedAnswer)
            this.Socia_HaveYouSufferedAnswer.push(element)
          }
          if (element.family_AllergyAnswer == 'Yes') {
            this.family_AllergyAnswer.push(element)
          }
         if (element.family_HospitalizationAnswer == 'Yes') {
          console.log("element.family_HospitalizationAnswer",element.family_HospitalizationAnswer)
            this.family_HospitalizationAnswer.push(element)
          }
          if (element.family_DiscProlapseAnswer == 'Yes') {
            this.family_DiscProlapseAnswer.push(element)
          }
         if (element.family_DizzinessAnswer == 'Yes') {
          console.log("element.family_DizzinessAnswer",element.family_DizzinessAnswer)
            this.family_DizzinessAnswer.push(element)
          }
          if (element.family_InfectiousAnswer == 'Yes') {
            this.family_InfectiousAnswer.push(element)
          }
         if (element.family_KidneyAnswer == 'Yes') {
          console.log("element.family_KidneyAnswer",element.family_KidneyAnswer)
            this.family_KidneyAnswer.push(element)
          }
          if (element.family_DepressionAnswer == 'Yes') {
            this.family_DepressionAnswer.push(element)
          }
         if (element.family_NeurologicalAnswer == 'Yes') {
            this.family_NeurologicalAnswer.push(element)
          }
          if (element.family_GITAnswer == 'Yes') {
            this.family_GITAnswer.push(element)
          }
         if (element.family_COPDAnswer == 'Yes') {
            this.family_COPDAnswer.push(element)
          }
          if (element.family_DiabetesAnswer == 'Yes') {
            this.family_DiabetesAnswer.push(element)
          }
         if (element.family_HeartDiseaseAnswer == 'Yes') {
            this.family_HeartDiseaseAnswer.push(element)
          }
          if (element.family_HighBloodPressureAnswer == 'Yes') {
            this.family_HighBloodPressureAnswer.push(element)
          }

        });

        this.Socia_DoYouSmokeAnswerCount = this.Socia_DoYouSmokeAnswer.length
        this.Socia_HaveYouSufferedAnswerCount=this.Socia_HaveYouSufferedAnswer.length
        this.family_AllergyAnswerCount = this.family_AllergyAnswer.length
        this.family_SurgeryAnswerCount=this.family_SurgeryAnswer.length
        this.family_HospitalizationAnswerCount = this.family_HospitalizationAnswer.length
        this.family_DiscProlapseAnswerCount=this.family_DiscProlapseAnswer.length
        this.family_DizzinessAnswerCount = this.family_DizzinessAnswer.length
        this.family_InfectiousAnswerCount=this.family_InfectiousAnswer.length
        this.family_KidneyAnswerCount = this.family_KidneyAnswer.length
        this.family_DepressionAnswerCount=this.family_DepressionAnswer.length
        this.family_NeurologicalAnswerCount = this.family_NeurologicalAnswer.length
        this.family_GITAnswerCount=this.family_GITAnswer.length
        this.family_DiabetesAnswerCount = this.family_DiabetesAnswer.length
        this.family_COPDAnswerCount=this.family_COPDAnswer.length
        this.family_HeartDiseaseAnswerCount = this.family_HeartDiseaseAnswer.length
        this.family_HighBloodPressureAnswerCount=this.family_HighBloodPressureAnswer.length

        this.AddCanvas("myChart", "chart1")

        var myChart2 = new Chart("myChart", {
          type: 'bar',
          data: {
            labels: ["Smoker","industrial injury","Allergy",
              "Surgery","Hospitalization","Disc prolapse",
              "Dizziness","Infectious disease","Kidney",
              "Neurological","GIT","Diabetes","COPD",
              "Heart","High/ Low blood pressure"
            ],
            datasets: [{
              label: selectedText,
              data: [this.Socia_DoYouSmokeAnswerCount,this.Socia_HaveYouSufferedAnswerCount
                ,this.family_AllergyAnswerCount,this.family_SurgeryAnswerCount,
                this.family_HospitalizationAnswerCount,this.family_DiscProlapseAnswerCount,
                this.family_DizzinessAnswerCount,this.family_InfectiousAnswerCount,
                this.family_KidneyAnswerCount,this.family_DepressionAnswerCount,
                this.family_NeurologicalAnswerCount,
                this.family_GITAnswerCount,this.family_DiabetesAnswerCount,
                this.family_COPDAnswerCount,this.family_HeartDiseaseAnswerCount,
                this.family_HighBloodPressureAnswerCount],

              backgroundColor: [
                'rgba(255, 99, 132, 0.2)',
                'rgba(54, 162, 235, 0.2)'
              ],
              borderColor: [
                'rgba(255, 99, 132, 1)',
                'rgba(54, 162, 235, 1)'
              ],
              borderWidth: 1,
              datalabels: {
                color: [
                  'rgba(255, 99, 132, 1)',
                  'rgba(54, 162, 235, 1)'
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
      },
      error: err => {
        this.ErrorMessage = err
      }
    })





  }
}
