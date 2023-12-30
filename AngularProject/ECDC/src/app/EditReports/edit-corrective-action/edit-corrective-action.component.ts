import { DatePipe } from '@angular/common';
import { Component } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, ParamMap, Router } from '@angular/router';
import { AddDataService } from 'Services/add-data.service';
import { DataService } from 'Services/data.service';
import { EditDataService } from 'Services/edit-data.service';
import { LoginService } from 'Services/login.service';
import { CorrectiveObservation } from 'SharedClasses/CorrectiveObservation';
import { CorrectiveRootCause } from 'SharedClasses/CorrectiveRootCause';
import { IRig } from 'SharedClasses/IRig';
import { IStandard } from 'SharedClasses/IStandard';
import { UpdateMode } from '../../../assets/vendor/chart.js/types/index';

@Component({
  selector: 'app-edit-corrective-action',
  templateUrl: './edit-corrective-action.component.html',
  styleUrls: ['./edit-corrective-action.component.scss']
})
export class EditCorrectiveActionComponent {
  correctiveId: any;
  corrective!: any;
  CorrectiveActionForm!: FormGroup;
  ErrorMessage = '';
  json_data: any[] = [];
  time = new Date();
  rigList: IRig[] = [];
  standardList: IStandard[] = [];
  observationList: CorrectiveObservation[] = [];
  rootCausesList: CorrectiveRootCause[] = [];
  SelectFiles: File[] = []
  ObservationSelected: any
  RootCausesSelected: any
  // CorrectiveObservationList: CorrectiveObservation[] = [];
  // CorrectiveRootCauseList: CorrectiveRootCause[] = [];
  selectedObservation: number[] = [];
  selectedRoot: number[] = [];
  selectedImages: any[] = [];

  UserJsonString: any;
  Record: any = {};
  UserJsonObj: any
  User: any;

  constructor(
    private datePipe: DatePipe,
    private loginService: LoginService,
    private dataService: DataService,
    private activatedRoute: ActivatedRoute,
    private editDataService: EditDataService,
    private fb: FormBuilder,
    private router: Router
  ) { }

  ngOnInit() {
    this.User = this.loginService.currentUser.getValue();
    this.activatedRoute.paramMap.subscribe((params: ParamMap) => {
      this.correctiveId = params.get("id");
      console.log(this.correctiveId)
    }),
      this.editDataService.GetCorrectiveById(this.correctiveId, this.User.ID, this.User.Role).subscribe({
        next: data => {
          this.corrective = data.data
          console.log("this.corrective")
          console.log(this.corrective)
          this.corrective.correctiveObservation.forEach((element: any) => {
            this.selectedObservation.push(element.correctiveObservationId)
          });
          this.corrective.rootCauses.forEach((element: any) => {
            this.selectedRoot.push(element.rootCausesId)
          });
          this.corrective.images.forEach((element: any) => {
            this.selectedImages.push(element.fileName)
          });

          console.log("this.corrective")
          console.log(this.corrective)

        },
        error: err => {
          console.log(err)
        }
      })
    this.dataService.GetRig().subscribe({
      next: data => {
        this.rigList = data.data;
        console.log('rrrrrrrrrrrriiiiiiiiiiiiiiiiiiggggggggggg')
        console.log(this.rigList)
      },
      error: err => this.ErrorMessage = err
    });
    this.dataService.GetStandard().subscribe({
      next: data => {
        this.standardList = data.data;
      },
      error: err => this.ErrorMessage = err
    });
    this.dataService.GetCorrectiveObservation().subscribe({
      next: data => {
        this.observationList = data.data;
      },
      error: err => this.ErrorMessage = err
    });
    this.dataService.GetRootCause().subscribe({
      next: data => {
        this.rootCausesList = data.data;
      },
      error: err => this.ErrorMessage = err
    });
    this.User = JSON.stringify(this.loginService.currentUser.getValue())//this.loginService.currentUser.getValue();
    console.log("uuuuuuussssssseeeeerrrrbbbbbvvvcc")

    this.UserJsonString = JSON.stringify(this.loginService.currentUser.getValue())
    this.UserJsonObj = JSON.parse(this.UserJsonString);

    this.CorrectiveActionForm = this.fb.group(
      {
        id: this.fb.control(
          0,
          [
            Validators.required
          ]
        ),
        reportNo: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        rigId: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        descriptionOfNonConformity: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        sn1: this.fb.control(
          '',
          [
          ]
        ),
        action1: this.fb.control(
          '',
          [
          ]
        ),
        responsible1: this.fb.control(
          '',
          [
          ]
        ),
        suggestedDate1: this.fb.control(
          '',
          [
          ]
        ),
        achievementDate1: this.fb.control(
          '',
          [
          ]
        ),
        followUpAudit1: this.fb.control(
          '',
          [
          ]
        ),
        status1: this.fb.control(
          false,
          [
          ]
        ),
        status2: this.fb.control(
          false,
          [
          ]
        ),
        status3: this.fb.control(
          false,
          [
          ]
        ),
        status4: this.fb.control(
          false,
          []
        ),
        sn2: this.fb.control(
          '',
          [
          ]
        ),
        action2: this.fb.control(
          '',
          [
          ]
        ),
        responsible2: this.fb.control(
          '',
          [
          ]
        ),
        suggestedDate2: this.fb.control(
          '',
          [
          ]
        ),
        achievementDate2: this.fb.control(
          '',
          [
          ]
        ),
        followUpAudit2: this.fb.control(
          '',
          [
          ]
        ),
        sn3: this.fb.control(
          '',
          [
          ]
        ),
        action3: this.fb.control(
          '',
          [
          ]
        ),
        responsible3: this.fb.control(
          '',
          [
          ]
        ),
        suggestedDate3: this.fb.control(
          '',
          [
          ]
        ),
        achievementDate3: this.fb.control(
          '',
          [
          ]
        ),
        followUpAudit3: this.fb.control(
          '',
          [
          ]
        ),
        sn4: this.fb.control(
          '',
          [
          ]
        ),
        action4: this.fb.control(
          '',
          [
          ]
        ),
        responsible4: this.fb.control(
          '',
          [
          ]
        ),
        suggestedDate4: this.fb.control(
          '',
          [
          ]
        ),
        achievementDate4: this.fb.control(
          '',
          [
          ]
        ),
        followUpAudit4: this.fb.control(
          '',
          [
          ]
        ),
        correctiveObservation: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        rootCauses: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        standardId: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        clauseNo: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        objectiveEvidence: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        ifOtherObservation: this.fb.control(
          '',
          [
          ]
        ),
        updateRisk: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        ifUpdate: this.fb.control(
          '',
          [
          ]
        ),
        managementOfChange: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        ifManagementOfChange: this.fb.control(
          '',
          [
          ]
        ),
        nameRasiedBy: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        sigRasiedBy: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        dateRaisedBy: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        ifOtherRootCause: this.fb.control(
          '',
          [
          ]
        ),
        comment: this.fb.control(
          '',
          [
          ]
        ),
        q_ManagerSig: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        userID: this.fb.control(
          this.UserJsonObj.ID,
          [
            Validators.required
          ]
        ),
        formStatus: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        images: this.fb.control(
          [],
          [
          ]
        )
      }
    );
  }

  get id() {
    return this.CorrectiveActionForm.get('id');
  }
  get reportNo() {
    return this.CorrectiveActionForm.get('reportNo');
  }
  get rigId() {
    return this.CorrectiveActionForm.get('rigId');
  }
  get descriptionOfNonConformity() {
    return this.CorrectiveActionForm.get('descriptionOfNonConformity');
  }
  get sn1() {
    return this.CorrectiveActionForm.get('sn1');
  }
  get action1() {
    return this.CorrectiveActionForm.get('action1');
  }
  get responsible1() {
    return this.CorrectiveActionForm.get('responsible1');
  }
  get suggestedDate1() {
    return this.CorrectiveActionForm.get('suggestedDate1');
  }
  get achievementDate1() {
    return this.CorrectiveActionForm.get('achievementDate1');
  }
  get followUpAudit1() {
    return this.CorrectiveActionForm.get('followUpAudit1');
  }
  get status1() {
    return this.CorrectiveActionForm.get('status1');
  }
  get sn2() {
    return this.CorrectiveActionForm.get('sn2');
  }
  get action2() {
    return this.CorrectiveActionForm.get('action2');
  }
  get responsible2() {
    return this.CorrectiveActionForm.get('responsible2');
  }
  get suggestedDate2() {
    return this.CorrectiveActionForm.get('suggestedDate2');
  }
  get achievementDate2() {
    return this.CorrectiveActionForm.get('achievementDate2');
  }
  get followUpAudit2() {
    return this.CorrectiveActionForm.get('followUpAudit2');
  }
  get status2() {
    return this.CorrectiveActionForm.get('status1');
  }
  get sn3() {
    return this.CorrectiveActionForm.get('sn3');
  }
  get action3() {
    return this.CorrectiveActionForm.get('action3');
  }
  get responsible3() {
    return this.CorrectiveActionForm.get('responsible3');
  }
  get suggestedDate3() {
    return this.CorrectiveActionForm.get('suggestedDate3');
  }
  get achievementDate3() {
    return this.CorrectiveActionForm.get('achievementDate3');
  }
  get followUpAudit3() {
    return this.CorrectiveActionForm.get('followUpAudit3');
  }
  get status3() {
    return this.CorrectiveActionForm.get('status1');
  }
  get sn4() {
    return this.CorrectiveActionForm.get('sn4');
  }
  get action4() {
    return this.CorrectiveActionForm.get('action4');
  }
  get responsible4() {
    return this.CorrectiveActionForm.get('responsible4');
  }
  get suggestedDate4() {
    return this.CorrectiveActionForm.get('suggestedDate4');
  }
  get achievementDate4() {
    return this.CorrectiveActionForm.get('achievementDate4');
  }
  get followUpAudit4() {
    return this.CorrectiveActionForm.get('followUpAudit4');
  }
  get status4() {
    return this.CorrectiveActionForm.get('status1');
  }
  get correctiveObservation() {
    return this.CorrectiveActionForm.get('correctiveObservation');
  }
  get rootCauses() {
    return this.CorrectiveActionForm.get('rootCauses');
  }
  get standardId() {
    return this.CorrectiveActionForm.get('standardId');
  }
  get clauseNo() {
    return this.CorrectiveActionForm.get('clauseNo');
  }
  get objectiveEvidence() {
    return this.CorrectiveActionForm.get('objectiveEvidence');
  }
  get ifOtherObservation() {
    return this.CorrectiveActionForm.get('ifOtherObservation');
  }
  get updateRisk() {
    return this.CorrectiveActionForm.get('updateRisk');
  }
  get ifUpdate() {
    return this.CorrectiveActionForm.get('ifUpdate');
  }
  get managementOfChange() {
    return this.CorrectiveActionForm.get('managementOfChange');
  }
  get ifManagementOfChange() {
    return this.CorrectiveActionForm.get('ifManagementOfChange');
  }
  get nameRasiedBy() {
    return this.CorrectiveActionForm.get('nameRasiedBy');
  }
  get sigRasiedBy() {
    return this.CorrectiveActionForm.get('sigRasiedBy');
  }
  get dateRaisedBy() {
    return this.CorrectiveActionForm.get('dateRaisedBy');
  }
  get ifOtherRootCause() {
    return this.CorrectiveActionForm.get('ifOtherRootCause');
  }
  get comment() {
    return this.CorrectiveActionForm.get('comment');
  }
  get q_ManagerSig() {
    return this.CorrectiveActionForm.get('q_ManagerSig');
  }
  get userID() {
    return this.CorrectiveActionForm.get('userID');
  }
  get formStatus() {
    return this.CorrectiveActionForm.get('formStatus');
  }
  get images() {
    return this.CorrectiveActionForm.get('images');
  }

  submitData() {
    if (this.CorrectiveActionForm.valid) {
      console.log('before formData')
      console.log(this.CorrectiveActionForm.value)
      console.log('***********')
      console.log(this.ObservationSelected?.length)
      const Formdata = new FormData();
      Formdata.append('id', this.id?.value);
      Formdata.append('reportNo', this.reportNo?.value);
      Formdata.append('rigId', this.rigId?.value);
      Formdata.append('descriptionOfNonConformity', this.descriptionOfNonConformity?.value);
      Formdata.append('sn1', this.sn1?.value != null ? this.sn1?.value : 0);
      Formdata.append('action1', this.action1?.value);
      Formdata.append('responsible1', this.responsible1?.value);
      Formdata.append('suggestedDate1', this.suggestedDate1?.value != null ? this.suggestedDate1?.value : new Date('1970-01-01').toISOString());
      Formdata.append('achievementDate1', this.achievementDate1?.value != null ? this.achievementDate1?.value : new Date('1970-01-01').toISOString());
      Formdata.append('followUpAudit1', this.followUpAudit1?.value);
      Formdata.append('status1', this.status1?.value);
      Formdata.append('sn2', this.sn2?.value != null ? this.sn2?.value : 0);
      Formdata.append('action2', this.action2?.value);
      Formdata.append('responsible2', this.responsible2?.value);
      Formdata.append('suggestedDate2', this.suggestedDate2?.value != null ? this.suggestedDate2?.value : new Date('1970-01-01').toISOString());
      Formdata.append('achievementDate2', this.achievementDate2?.value != null ? this.achievementDate2?.value : new Date('1970-01-01').toISOString());
      Formdata.append('followUpAudit2', this.followUpAudit2?.value);
      Formdata.append('status2', this.status2?.value);
      Formdata.append('sn3', this.sn3?.value != null ? this.sn3?.value : 0);
      Formdata.append('action3', this.action3?.value);
      Formdata.append('responsible3', this.responsible3?.value);
      Formdata.append('suggestedDate3', this.suggestedDate3?.value != null ? this.suggestedDate3?.value : new Date('1970-01-01').toISOString());
      Formdata.append('achievementDate3', this.achievementDate3?.value != null ? this.achievementDate3?.value : new Date('1970-01-01').toISOString());
      Formdata.append('followUpAudit3', this.followUpAudit3?.value);
      Formdata.append('status3', this.status3?.value);
      Formdata.append('sn4', this.sn4?.value != null ? this.sn4?.value : 0);
      Formdata.append('action4', this.action4?.value);
      Formdata.append('responsible4', this.responsible4?.value);
      Formdata.append('suggestedDate4', this.suggestedDate4?.value != null ? this.suggestedDate4?.value : new Date('1970-01-01').toISOString());
      Formdata.append('achievementDate4', this.achievementDate4?.value != null ? this.achievementDate4?.value : new Date('1970-01-01').toISOString());
      Formdata.append('followUpAudit4', this.followUpAudit4?.value);
      Formdata.append('status4', this.status4?.value);
      Formdata.append('standardId', this.standardId?.value);
      Formdata.append('clauseNo', this.clauseNo?.value);
      Formdata.append('objectiveEvidence', this.objectiveEvidence?.value);
      Formdata.append('ifOtherObservation', this.ifOtherObservation?.value);
      Formdata.append('updateRisk', this.updateRisk?.value);
      Formdata.append('ifUpdate', this.ifUpdate?.value);
      Formdata.append('managementOfChange', this.managementOfChange?.value);
      Formdata.append('ifManagementOfChange', this.ifManagementOfChange?.value);
      Formdata.append('nameRasiedBy', this.nameRasiedBy?.value);
      Formdata.append('sigRasiedBy', this.sigRasiedBy?.value);
      Formdata.append('dateRaisedBy', this.dateRaisedBy?.value);
      Formdata.append('ifOtherRootCause', this.ifOtherRootCause?.value);
      Formdata.append('comment', this.comment?.value);
      Formdata.append('q_ManagerSig', this.q_ManagerSig?.value);
      Formdata.append('formStatus', this.formStatus?.value);

      if (this.correctiveObservation?.value) {
        for (let i = 0; i < this.correctiveObservation.value.length; i++) {
          Formdata.append('correctiveObservation', this.correctiveObservation.value[i].toString());
        }
      }
      if (this.rootCauses?.value) {
        for (let i = 0; i < this.rootCauses.value.length; i++) {
          Formdata.append('rootCauses', this.rootCauses.value[i].toString());
        }
      }

      Formdata.append('userID', this.UserJsonObj.ID);
      for (let i = 0; i < this.SelectFiles.length; i++) {
        Formdata.append('images', this.SelectFiles[i]);
      }
      console.log('after formData')
      console.log(Formdata)

      console.log(Formdata.get('userId'));
      this.editDataService.EditCorrective(this.correctiveId, Formdata).subscribe({
        next: data => {
          console.log('from service')
          console.log(data)
          location.reload();
        },
        error: error => {
          console.log("from Error")
          console.log(error)
        }
      });

      console.log(Formdata);
    }
    else {
      console.log("E+++++====error in : ");
      console.log(this.CorrectiveActionForm);
    }
  }

  SelectedObservationFun(event: any) {
    this.ObservationSelected = this.correctiveObservation?.value;
  }

  SelectedRootCauseFun(event: any) {
    this.RootCausesSelected = this.rootCauses?.value;
  }

  // mytemp: any[] = [];
  Download() {
    //   let workbook = new Workbook();

    //   let worksheet = workbook.addWorksheet("QHSE Daily Data");
    //   //pip date to excel sheet
    //   this.mytemp = []
    //   this.json_data.forEach((item) => {
    //     item.date = this.datePipe.transform(item.date, 'dd/MM/yyyy')
    //     this.mytemp.push(item)
    //   });
    //   console.log("frommm excel")
    //   console.log(this.mytemp);
    //   let header = Object.keys(this.mytemp[0]);

    //   let headerRow = worksheet.addRow(header);

    //   headerRow.fill = {
    //     type: 'pattern',
    //     pattern: 'solid',
    //     fgColor: {
    //       argb: 'ff0e0a27'
    //     }
    //   }

    //   headerRow.font = {
    //     name: 'Calibri',
    //     size: 12,
    //     bold: true,
    //     color: {
    //       argb: 'ffffffff'
    //     }
    //   }

    //   headerRow.alignment = {
    //     horizontal: 'center',
    //     vertical: 'middle',
    //     wrapText: true
    //   }

    //   headerRow.eachCell((cell, colNumber) => {
    //     worksheet.getColumn(colNumber).width = Math.max((header[colNumber - 1].length) + 10, 15);
    //     worksheet.getRow(1).height = 35;
    //   });



    //   for (let x1 of this.mytemp) {
    //     let x2 = Object.keys(x1);
    //     let temp: any[] = []
    //     for (let y of x2) {
    //       temp.push(x1[y])
    //     }
    //     worksheet.addRow(temp)
    //   }

    //   let fname = "QHSE Daily Report"

    //   //add data and file name and download
    //   workbook.xlsx.writeBuffer().then((data) => {
    //     let blob = new Blob([data], { type: 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet' });
    //     saveAs.saveAs(blob, fname + '-' + new Date().toUTCString() + '.xlsx');
    //   });
  }

  GetImagePath(event: any) {
    this.SelectFiles = event.target.files;
  }
}
