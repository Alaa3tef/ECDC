import { Component } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AddDataService } from 'Services/add-data.service';
import { DataService } from 'Services/data.service';
import { LoginService } from 'Services/login.service';
import { IRig } from 'SharedClasses/IRig';
import { Workbook } from 'exceljs';
import * as saveAs from 'file-saver';

@Component({
  selector: 'app-add-forklift',
  templateUrl: './add-forklift.component.html',
  styleUrls: ['./add-forklift.component.scss']
})
export class AddForkliftComponent {
  forkliftForm!: FormGroup;
  ErrorMessage = '';
  json_data: any[] = [];
  time = new Date();
  rigList: IRig[] = []

  UserJsonString: any
  UserJsonObj: any

  User: any;

  constructor(private loginService: LoginService,
    private dataService: DataService,
    private AddNew: AddDataService,
    private fb: FormBuilder,
    private router: Router) { }

  ngOnInit() {
    this.User = this.loginService.currentUser.getValue();
    this.dataService.GetRig().subscribe({
      next: data => this.rigList = data.data,
      error: err => this.ErrorMessage = err
    }),
      this.UserJsonString = JSON.stringify(this.loginService.currentUser.getValue())
    this.UserJsonObj = JSON.parse(this.UserJsonString);
    this.forkliftForm = this.fb.group(
      {
        id: this.fb.control(
          0,
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
        date: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        wellName: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        unitNo: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        qhseEngineer: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        // hrsSinceOilChange: this.fb.control(
        //   '',
        //   [
        //     Validators.required
        //   ]
        // ),
        cleanAndTidy: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        engineOilLevel: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        transmissionOilLevel: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        radiatorWaterLevel: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        hydraulicOilLevel: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        v_beltsTension: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        drainWater: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        leaks: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        batteryHolder: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        gaugesForCorrectReadings: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        tirePressure: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        tireCondition: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        fuelTanksFull: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        lights: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        alarms: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        hoistingSystem: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        abnormalNoise: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        brakes: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        liquidLevel: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        instruments: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        engineDriveBelts: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        carriageRollers: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        steeringSystem: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        seatBelt: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        hoseofCoilCooling: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        firstAidBox: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        crankShaft: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        driverSeat: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        engineV_belts: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        wipers: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        existingCorrosion: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        driverName: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        cleanAndTidyRemarks: this.fb.control(
          '',
          [
          ]
        ),
        engineOilLevelRemarks: this.fb.control(
          '',
          [
          ]
        ),
        transmissionOilLevelRemarks: this.fb.control(
          '',
          [
          ]
        ),
        radiatorWaterLevelRemarks: this.fb.control(
          '',
          [
          ]
        ),
        hydraulicOilLevelRemarks: this.fb.control(
          '',
          [
          ]
        ),
        v_beltsTensionRemarks: this.fb.control(
          '',
          [
          ]
        ),
        drainWaterRemarks: this.fb.control(
          '',
          [
          ]
        ),
        leaksRemarks: this.fb.control(
          '',
          [
          ]
        ),
        batteryHolderRemarks: this.fb.control(
          '',
          [
          ]
        ),
        gaugesForCorrectReadingsRemarks: this.fb.control(
          '',
          [
          ]
        ),
        tyrePressureRemarks: this.fb.control(
          '',
          [
          ]
        ),
        tyreConditionRemarks: this.fb.control(
          '',
          [
          ]
        ),
        fuelTanksFullRemarks: this.fb.control(
          '',
          [
          ]
        ),
        lightsRemarks: this.fb.control(
          '',
          [
          ]
        ),
        alarmsRemarks: this.fb.control(
          '',
          [
          ]
        ),
        hoistingSystemRemarks: this.fb.control(
          '',
          [
          ]
        ),
        abnormalNoiseRemarks: this.fb.control(
          '',
          [
          ]
        ),
        brakesRemarks: this.fb.control(
          '',
          [
          ]
        ),
        liquidLevelRemarks: this.fb.control(
          '',
          [
          ]
        ),
        instrumentsRemarks: this.fb.control(
          '',
          [
          ]
        ),
        engineDriveBeltsRemarks: this.fb.control(
          '',
          [
          ]
        ),
        carriageRollersRemarks: this.fb.control(
          '',
          [
          ]
        ),
        steeringSystemRemarks: this.fb.control(
          '',
          [
          ]
        ),
        seatBeltRemarks: this.fb.control(
          '',
          [
          ]
        ),
        hoseofCoilCoolingRemarks: this.fb.control(
          '',
          [
          ]
        ),
        firstAidBoxRemarks: this.fb.control(
          '',
          [
          ]
        ),
        crankShaftRemarks: this.fb.control(
          '',
          [
          ]
        ),
        driverSeatRemarks: this.fb.control(
          '',
          [
          ]
        ),
        engineV_beltsRemarks: this.fb.control(
          '',
          [
          ]
        ),
        wipersRemarks: this.fb.control(
          '',
          [
          ]
        ),
        existingCorrosionRemarks: this.fb.control(
          '',
          [
          ]
        ),
        userID: this.fb.control(
          this.UserJsonObj.ID,
          [
            Validators.required
          ]
        )
      }
    )
    this.dataService.GetForkliftForExcel(this.User.ID, this.User.Role).subscribe({
      next: data => this.json_data = data.data,
      error: err => this.ErrorMessage = err
    });
  }



  get id() {
    return this.forkliftForm.get('id');
  }
  get rigId() {
    return this.forkliftForm.get('rigId');
  }
  get date() {
    return this.forkliftForm.get('date');
  }
  get wellName() {
    return this.forkliftForm.get('wellName');
  }
  get unitNo() {
    return this.forkliftForm.get('unitNo');
  }
  get qhseEngineer() {
    return this.forkliftForm.get('qhseEngineer');
  }
  // get hrsSinceOilChange() {
  //   return this.forkliftForm.get('hrsSinceOilChange');
  // }
  get cleanAndTidy() {
    return this.forkliftForm.get('cleanAndTidy');
  }
  get engineOilLevel() {
    return this.forkliftForm.get('engineOilLevel');
  }
  get transmissionOilLevel() {
    return this.forkliftForm.get('transmissionOilLevel');
  }
  get radiatorWaterLevel() {
    return this.forkliftForm.get('radiatorWaterLevel');
  }
  get hydraulicOilLevel() {
    return this.forkliftForm.get('hydraulicOilLevel');
  }
  get v_beltsTension() {
    return this.forkliftForm.get('v_beltsTension');
  }
  get drainWater() {
    return this.forkliftForm.get('drainWater');
  }
  get leaks() {
    return this.forkliftForm.get('leaks');
  }
  get batteryHolder() {
    return this.forkliftForm.get('batteryHolder');
  }
  get gaugesForCorrectReadings() {
    return this.forkliftForm.get('gaugesForCorrectReadings');
  }
  get tirePressure() {
    return this.forkliftForm.get('tirePressure');
  }
  get tireCondition() {
    return this.forkliftForm.get('tireCondition');
  }
  get fuelTanksFull() {
    return this.forkliftForm.get('fuelTanksFull');
  }
  get lights() {
    return this.forkliftForm.get('lights');
  }
  get alarms() {
    return this.forkliftForm.get('alarms');
  }
  get hoistingSystem() {
    return this.forkliftForm.get('hoistingSystem');
  }
  get abnormalNoise() {
    return this.forkliftForm.get('abnormalNoise');
  }
  get brakes() {
    return this.forkliftForm.get('brakes');
  }
  get liquidLevel() {
    return this.forkliftForm.get('liquidLevel');
  }
  get instruments() {
    return this.forkliftForm.get('instruments');
  }
  get engineDriveBelts() {
    return this.forkliftForm.get('engineDriveBelts');
  }
  get carriageRollers() {
    return this.forkliftForm.get('carriageRollers');
  }
  get steeringSystem() {
    return this.forkliftForm.get('steeringSystem');
  }
  get seatBelt() {
    return this.forkliftForm.get('seatBelt');
  }
  get hoseofCoilCooling() {
    return this.forkliftForm.get('hoseofCoilCooling');
  }
  get firstAidBox() {
    return this.forkliftForm.get('firstAidBox');
  }
  get crankShaft() {
    return this.forkliftForm.get('crankShaft');
  }
  get driverSeat() {
    return this.forkliftForm.get('driverSeat');
  }
  get engineV_belts() {
    return this.forkliftForm.get('engineV_belts');
  }
  get wipers() {
    return this.forkliftForm.get('wipers');
  }
  get existingCorrosion() {
    return this.forkliftForm.get('existingCorrosion');
  }
  get driverName() {
    return this.forkliftForm.get('driverName');
  }
  get cleanAndTidyRemarks() {
    return this.forkliftForm.get('cleanAndTidyRemarks');
  }
  get engineOilLevelRemarks() {
    return this.forkliftForm.get('engineOilLevelRemarks');
  }
  get transmissionOilLevelRemarks() {
    return this.forkliftForm.get('transmissionOilLevelRemarks');
  }
  get radiatorWaterLevelRemarks() {
    return this.forkliftForm.get('radiatorWaterLevelRemarks');
  }
  get hydraulicOilLevelRemarks() {
    return this.forkliftForm.get('hydraulicOilLevelRemarks');
  }
  get v_beltsTensionRemarks() {
    return this.forkliftForm.get('v_beltsTensionRemarks');
  }
  get drainWaterRemarks() {
    return this.forkliftForm.get('drainWaterRemarks');
  }
  get leaksRemarks() {
    return this.forkliftForm.get('leaksRemarks');
  }
  get batteryHolderRemarks() {
    return this.forkliftForm.get('batteryHolderRemarks');
  }
  get gaugesForCorrectReadingsRemarks() {
    return this.forkliftForm.get('gaugesForCorrectReadingsRemarks');
  }
  get tyrePressureRemarks() {
    return this.forkliftForm.get('tyrePressureRemarks');
  }
  get tyreConditionRemarks() {
    return this.forkliftForm.get('tyreConditionRemarks');
  }
  get fuelTanksFullRemarks() {
    return this.forkliftForm.get('fuelTanksFullRemarks');
  }
  get lightsRemarks() {
    return this.forkliftForm.get('lightsRemarks');
  }
  get alarmsRemarks() {
    return this.forkliftForm.get('alarmsRemarks');
  }
  get hoistingSystemRemarks() {
    return this.forkliftForm.get('hoistingSystemRemarks');
  }
  get abnormalNoiseRemarks() {
    return this.forkliftForm.get('abnormalNoiseRemarks');
  }
  get brakesRemarks() {
    return this.forkliftForm.get('brakesRemarks');
  }
  get liquidLevelRemarks() {
    return this.forkliftForm.get('liquidLevelRemarks');
  }
  get instrumentsRemarks() {
    return this.forkliftForm.get('instrumentsRemarks');
  }
  get engineDriveBeltsRemarks() {
    return this.forkliftForm.get('engineDriveBeltsRemarks');
  }
  get carriageRollersRemarks() {
    return this.forkliftForm.get('carriageRollersRemarks');
  }
  get steeringSystemRemarks() {
    return this.forkliftForm.get('steeringSystemRemarks');
  }
  get seatBeltRemarks() {
    return this.forkliftForm.get('seatBeltRemarks');
  }
  get hoseofCoilCoolingRemarks() {
    return this.forkliftForm.get('hoseofCoilCoolingRemarks');
  }
  get firstAidBoxRemarks() {
    return this.forkliftForm.get('firstAidBoxRemarks');
  }
  get crankShaftRemarks() {
    return this.forkliftForm.get('crankShaftRemarks');
  }
  get driverSeatRemarks() {
    return this.forkliftForm.get('driverSeatRemarks');
  }
  get engineV_beltsRemarks() {
    return this.forkliftForm.get('engineV_beltsRemarks');
  }
  get wipersRemarks() {
    return this.forkliftForm.get('wipersRemarks');
  }
  get existingCorrosionRemarks() {
    return this.forkliftForm.get('existingCorrosionRemarks');
  }

  submitData() {
    if (this.forkliftForm.valid) {
      this.AddNew.AddForklift(this.forkliftForm.value).subscribe({
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
      console.log(this.forkliftForm.value);
    }
    else {
      this.forkliftForm.markAllAsTouched()
      console.log("E+++++====error in : ");
      console.log(this.forkliftForm);
    }
  }


  Download() {
    let workbook = new Workbook();

    let worksheet = workbook.addWorksheet("Weekly Forklift Inspection Data");


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

    let fname = "Weekly Forklift Inspection Report"

    //add data and file name and download
    workbook.xlsx.writeBuffer().then((data) => {
      let blob = new Blob([data], { type: 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet' });
      saveAs.saveAs(blob, fname + '-' + new Date().toUTCString() + '.xlsx');
    });
  }
}
