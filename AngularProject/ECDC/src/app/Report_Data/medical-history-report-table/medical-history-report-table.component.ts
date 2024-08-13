import { Component } from '@angular/core';
import { AddNewMedicalHistoryService } from 'Services/add-new-medical-history.service';
import { DataService } from 'Services/data.service';
import { DeleteDataService } from 'Services/delete-data.service';
import { GetdataByPageService } from 'Services/getdata-by-page.service';
import { LoginService } from 'Services/login.service';
import { IMedicalHistory } from 'SharedClasses/IMedicalHistory';
import { elements } from 'chart.js';
import { Workbook } from 'exceljs';
import * as saveAs from 'file-saver';
import { BehaviorSubject } from 'rxjs';

@Component({
  selector: 'app-medical-history-report-table',
  templateUrl: './medical-history-report-table.component.html',
  styleUrls: ['./medical-history-report-table.component.scss']
})
export class MedicalHistoryReportTableComponent {
  json_data: any[] = [];
  ErrorMessage = '';
  SearchList: string[] = ['Smokers ', 'industrial injury', 'Depression or Anxiety disorder', 'Surgery'
    , 'Hospitalization', 'Allergy', 'Disc prolapse', 'Dizziness, vertigo, problems with balance',
    'Infectious disease', 'Neurological disorder (e.g. Stroke or epilepsy)',
    'Kidney disease (e.g. stone)', 'GIT disease (e.g. Liver disease)', 'Diabetes', 'Bronchial Asthma / COPD',
    'Heart Disease/ Chest pain', 'High/ Low blood pressure'];
  private ListOfMedicalHistory = new BehaviorSubject<any[]>([]);
  readonly MedicalHistoryList = this.ListOfMedicalHistory.asObservable();
  page: number = 1;
  count: number = 0;
  productSize: number = 5;
  indexofPages: number = 1; countOfPage: number = 0;
  TempArray: any[] = [];
  IsUser: boolean = false;
  IsRadio: boolean = false;
  IsAdmin: boolean = false;
  User: any;


  constructor(private MedicalHistoryService: AddNewMedicalHistoryService, private getByPage: GetdataByPageService, private dataSevice: DataService, private deleteService: DeleteDataService, private loginService: LoginService) { }
  ngOnInit() {
    this.User = this.loginService.currentUser.getValue();
    this.getpages(1)
    this.dataSevice.GetMedicalHistorys(this.User.ID, this.User.Role).subscribe({
      next: data => {
        data.data.forEach((element: { name: string; }) => {
          this.SearchList.push(element.name)
        });
        console.log("searchListtttt", this.SearchList)
      }
    }),
      this.loginService.isAdmin
        .subscribe({
          next: data => { this.IsAdmin = data }
        }),
      this.loginService.isUser
        .subscribe({
          next: data => { this.IsUser = data }
        }),
      this.dataSevice.GetMedicalHistorys(this.User.ID, this.User.Role).subscribe({
        next: data => this.json_data = data.data,
        error: err => this.ErrorMessage = err
      })
  }
  DeleteMedicalHistory(MedicalHistory: IMedicalHistory) {
    if (confirm("Are you sure you want to delete this Record?")) {
      // user clicked "Yes"
      // do something, such as call an API to delete the item
      this.deleteService.DeleteMedicalHistory(MedicalHistory).subscribe({
        next: data => {
          console.log(data)
          this.getpages(this.indexofPages)
        },
        error: err => {
          console.log(err);
        }
      })
    }
  }

  SelectMenace(event: any) {
    console.log(event.target.value, +"this.User.Role", this.User.Role);

    this.MedicalHistoryService.GetSearchByDieases(event.target.value, this.User.Role).subscribe({
      next: (data: { data: IMedicalHistory[] }) => {
        if (data && data.data) {
          console.log("Initial Data:", data.data);

          let filteredData: IMedicalHistory[] = data.data;

          switch (event.target.value) {
            case 'Smokers':
              console.log("Before Filter:", filteredData);
              // Filter the data based on Socia_DoYouSmokeAnswer
              filteredData = filteredData.filter((item: IMedicalHistory) => item.socia_DoYouSmokeAnswer === 'Yes');
              console.log("After Filter:", filteredData);

              break;
            case 'industrial injury':
              filteredData = filteredData.filter((item: IMedicalHistory) => item.socia_HaveYouSufferedAnswer === 'Yes');
              break;
            case 'Allergy':
              filteredData = filteredData.filter((item: IMedicalHistory) => item.family_AllergyAnswer === 'Yes');
              break;
            case 'Surgery':
              filteredData = filteredData.filter((item: IMedicalHistory) => item.family_SurgeryAnswer === 'Yes');
              break;
            case 'Hospitalization':
              filteredData = filteredData.filter((item: IMedicalHistory) => item.family_HospitalizationAnswer === 'Yes');
              break;
            case 'Disc prolapse':
              filteredData = filteredData.filter((item: IMedicalHistory) => item.family_DiscProlapseAnswer === 'Yes');
              break;
            case 'Dizziness, vertigo, problems with balance':
              filteredData = filteredData.filter((item: IMedicalHistory) => item.family_DizzinessAnswer === 'Yes');
              break;
            case 'Infectious disease':
              filteredData = filteredData.filter((item: IMedicalHistory) => item.family_InfectiousAnswer === 'Yes');
              break;
            case 'Kidney disease (e.g. stone)':
              filteredData = filteredData.filter((item: IMedicalHistory) => item.family_KidneyAnswer === 'Yes');
              break;
            case 'Depression or Anxiety disorder':
              filteredData = filteredData.filter((item: IMedicalHistory) => item.family_DepressionAnswer === 'Yes');
              break;
            case 'Neurological disorder (e.g. Stroke or epilepsy)':
              filteredData = filteredData.filter((item: IMedicalHistory) => item.family_NeurologicalAnswer === 'Yes');
              break;
            case 'GIT disease (e.g. Liver disease)':
              filteredData = filteredData.filter((item: IMedicalHistory) => item.family_GITAnswer === 'Yes');
              break;
            case 'Diabetes':
              filteredData = filteredData.filter((item: IMedicalHistory) => item.family_DiabetesAnswer === 'Yes');
              break;
            case 'Bronchial Asthma / COPD':
              filteredData = filteredData.filter((item: IMedicalHistory) => item.family_COPDAnswer === 'Yes');
              break;
            case 'Heart Disease/ Chest pain':
              filteredData = filteredData.filter((item: IMedicalHistory) => item.family_HeartDiseaseAnswer === 'Yes');
              break;
            case 'High/ Low blood pressure':
              filteredData = filteredData.filter((item: IMedicalHistory) => item.family_HighBloodPressureAnswer === 'Yes');
              break;

            default:
              break;
          }

          this.ListOfMedicalHistory.next(filteredData);
        } else {
          console.log("API response is null or does not contain data.");
        }
      },
      error: err => {
        this.getpages(1);
        console.log(err);
      }
    });




  }

  DeleteMedicalHistoryReport(MedicalHistory: IMedicalHistory) {
    if (confirm("Are you sure you want to delete this Record?")) {
      // user clicked "Yes"
      // do something, such as call an API to delete the item
      this.deleteService.DeleteMedicalHistory(MedicalHistory).subscribe({
        next: data => {
          console.log(data)
          this.getpages(this.indexofPages)
        },
        error: err => {
          console.log(err);
        }
      })
    } else {
      // user clicked "No"
      // do nothing
    }
  }

  recordContainsPoor(record: any): boolean {
    return Object.values(record).some(value => value === 'Surgery' || 'Hospitalization' || 'Allergy' || 'High/ Low blood pressure'
      || 'Heart Disease/ Chest pain' || 'Bronchial Asthma / COPD' || 'Diabetes' || 'GIT disease (e.g. Liver disease)'
      || 'Kidney disease (e.g. stone)' || 'Neurological disorder (e.g. Stroke or epilepsy)' || 'Infectious disease' || 'Dizziness, vertigo, problems with balance'
      || 'Dizziness, vertigo, problems with balance' || 'Disc prolapse' || 'Depression or Anxiety disorder' || 'industrial injury' || 'Smokers');
  }
  getpages(num: number) {
    this.getByPage.GetMedicalHistoryReportByPage(num, this.User.ID, this.User.Role).subscribe({
      next: (data) => {
        this.ListOfMedicalHistory.next(data.items);
        this.countOfPage = data.count;
        this.TempArray = new Array(this.countOfPage);
        console.log(data)
      }
      ,
      error: (error) => { console.log(error); }

    });
    this.indexofPages = num;
    console.log("getpages" + this.indexofPages);
  }
  gotleft() {
    (this.indexofPages > 1) ? this.indexofPages -= 1 : this.indexofPages = 1;
    this.getpages(this.indexofPages);
    console.log("gotleft" + this.indexofPages);
  }
  gotoright() {

    (this.indexofPages < this.countOfPage) ? this.indexofPages += 1 : this.indexofPages = this.countOfPage;
    this.getpages(this.indexofPages);
    console.log("gotoright" + this.indexofPages);
  }

  Download() {
    let workbook = new Workbook();

    let worksheet = workbook.addWorksheet("Stop Card Data");

    let header = Object.keys(this.json_data[0]);

    let headerRow = worksheet.addRow(header);

    headerRow.fill = {
      type: 'pattern',
      pattern: 'solid',
      fgColor: {
        argb: 'ff0e0a27'
      }
    }

    headerRow.font = {
      name: 'Calibri',
      size: 12,
      bold: true,
      color: {
        argb: 'ffffffff'
      }
    }

    headerRow.alignment = {
      horizontal: 'center',
      vertical: 'middle',
      wrapText: true
    }

    headerRow.eachCell((cell, colNumber) => {
      worksheet.getColumn(colNumber).width = Math.max((header[colNumber - 1].length) + 10, 15);
      worksheet.getRow(1).height = 35;
    });



    for (let x1 of this.json_data) {
      let x2 = Object.keys(x1);
      let temp: any[] = []
      for (let y of x2) {
        temp.push(x1[y])
      }
      worksheet.addRow(temp)
    }

    let fname = "Stop Card Report"

    //add data and file name and download
    workbook.xlsx.writeBuffer().then((data) => {
      let blob = new Blob([data], { type: 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet' });
      saveAs.saveAs(blob, fname + '-' + new Date().toUTCString() + '.xlsx');
    });
  }




}

