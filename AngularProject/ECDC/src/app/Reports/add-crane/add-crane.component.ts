import { COMPILER_OPTIONS, Component } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AddDataService } from 'Services/add-data.service';
import { DataService } from 'Services/data.service';
import { LoginService } from 'Services/login.service';
import { IRig } from 'SharedClasses/IRig';
import { Workbook } from 'exceljs';
import * as saveAs from 'file-saver';

@Component({
  selector: 'app-add-crane',
  templateUrl: './add-crane.component.html',
  styleUrls: ['./add-crane.component.scss']
})
export class AddCraneComponent {
  craneForm!: FormGroup;
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
    this.craneForm = this.fb.group(
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
        loadComputer: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        gaugesForCcorrectReadings: this.fb.control(
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
        fuelTanksFull: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        wireRopes: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        swingBrake: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        testLimitSwitches: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        testOutriggers: this.fb.control(
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
        serviceBrakes: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        sheaves: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        spoolingOfWire: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        hookcondition: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        boomSections: this.fb.control(
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
        wiringVisually: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        loadIndicator: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        audibleAlarm: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        loadLimiting: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        boomAngle: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        limitSwitch: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        emergencyShutDown: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        operatingReturn: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        operatingControls: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        headLight: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        reverseAlarm: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        parkingBrake: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        safetyBelt: this.fb.control(
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
        tireBolts: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        safeLoadIndicator: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        screenCurtains: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        outrigger: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        strangeSound: this.fb.control(
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
        loadComputerRemarks: this.fb.control(
          '',
          [
          ]
        ),
        gaugesForCcorrectReadingsRemarks: this.fb.control(
          '',
          [
          ]
        ),
        tirePressureRemarks: this.fb.control(
          '',
          [
          ]
        ),
        fuelTanksFullRemarks: this.fb.control(
          '',
          [
          ]
        ),
        wireRopesRemarks: this.fb.control(
          '',
          [
          ]
        ),
        swingBrakeRemarks: this.fb.control(
          '',
          [
          ]
        ),
        testLimitSwitchesRemarks: this.fb.control(
          '',
          [
          ]
        ),
        testOutriggersRemarks: this.fb.control(
          '',
          [
          ]
        ),
        abnormalNoiseRemarks: this.fb.control(
          '',
          [
          ]
        ),
        serviceBrakesRemarks: this.fb.control(
          '',
          [
          ]
        ),
        sheavesRemarks: this.fb.control(
          '',
          [
          ]
        ),
        spoolingOfWireRemarks: this.fb.control(
          '',
          [
          ]
        ),
        hookconditionRemarks: this.fb.control(
          '',
          [
          ]
        ),
        boomSectionsRemarks: this.fb.control(
          '',
          [
          ]
        ),
        engineV_beltsRemarks: this.fb.control(
          '',
          [
          ]
        ),
        wiringVisuallyRemarks: this.fb.control(
          '',
          [
          ]
        ),
        loadIndicatorRemarks: this.fb.control(
          '',
          [
          ]
        ),
        audibleAlarmRemarks: this.fb.control(
          '',
          [
          ]
        ),
        loadLimitingRemarks: this.fb.control(
          '',
          [
          ]
        ),
        boomAngleRemarks: this.fb.control(
          '',
          [
          ]
        ),
        limitSwitchRemarks: this.fb.control(
          '',
          [
          ]
        ),
        emergencyShutDownRemarks: this.fb.control(
          '',
          [
          ]
        ),
        operatingReturnRemarks: this.fb.control(
          '',
          [
          ]
        ),
        operatingControlsRemarks: this.fb.control(
          '',
          [
          ]
        ),
        headLightRemarks: this.fb.control(
          '',
          [
          ]
        ),
        reverseAlarmRemarks: this.fb.control(
          '',
          [
          ]
        ),
        parkingBrakeRemarks: this.fb.control(
          '',
          [
          ]
        ),
        safetyBeltRemarks: this.fb.control(
          '',
          [
          ]
        ),
        driverSeatRemarks: this.fb.control(
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
        tireBoltsRemarks: this.fb.control(
          '',
          [
          ]
        ),
        safeLoadIndicatorRemarks: this.fb.control(
          '',
          [
          ]
        ),
        screenCurtainsRemarks: this.fb.control(
          '',
          [
          ]
        ),
        outriggerRemarks: this.fb.control(
          '',
          [
          ]
        ),
        strangeSoundRemarks: this.fb.control(
          '',
          [
          ]
        ),
        driverName: this.fb.control(
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
        )
      }
    )
    this.dataService.GetCraneForExcel(this.User.ID, this.User.Role).subscribe({
      next: data => this.json_data = data.data,
      error: err => this.ErrorMessage = err
    })
  }



  get id() {
    return this.craneForm.get('id');
  }
  get rigId() {
    return this.craneForm.get('rigId');
  }
  get date() {
    return this.craneForm.get('date');
  }
  get wellName() {
    return this.craneForm.get('wellName');
  }
  get unitNo() {
    return this.craneForm.get('unitNo');
  }
  get qhseEngineer() {
    return this.craneForm.get('qhseEngineer');
  }
  // get hrsSinceOilChange() {
  //   return this.craneForm.get('hrsSinceOilChange');
  // }
  get cleanAndTidy() {
    return this.craneForm.get('cleanAndTidy');
  }
  get engineOilLevel() {
    return this.craneForm.get('engineOilLevel');
  }
  get transmissionOilLevel() {
    return this.craneForm.get('transmissionOilLevel');
  }
  get radiatorWaterLevel() {
    return this.craneForm.get('radiatorWaterLevel');
  }
  get hydraulicOilLevel() {
    return this.craneForm.get('hydraulicOilLevel');
  }
  get v_beltsTension() {
    return this.craneForm.get('v_beltsTension');
  }
  get drainWater() {
    return this.craneForm.get('drainWater');
  }
  get leaks() {
    return this.craneForm.get('leaks');
  }
  get batteryHolder() {
    return this.craneForm.get('batteryHolder');
  }
  get loadComputer() {
    return this.craneForm.get('loadComputer');
  }
  get gaugesForCcorrectReadings() {
    return this.craneForm.get('gaugesForCcorrectReadings');
  }
  get tirePressure() {
    return this.craneForm.get('tirePressure');
  }
  get fuelTanksFull() {
    return this.craneForm.get('fuelTanksFull');
  }
  get wireRopes() {
    return this.craneForm.get('wireRopes');
  }
  get swingBrake() {
    return this.craneForm.get('swingBrake');
  }
  get testLimitSwitches() {
    return this.craneForm.get('testLimitSwitches');
  }
  get testOutriggers() {
    return this.craneForm.get('testOutriggers');
  }
  get abnormalNoise() {
    return this.craneForm.get('abnormalNoise');
  }
  get serviceBrakes() {
    return this.craneForm.get('serviceBrakes');
  }
  get sheaves() {
    return this.craneForm.get('sheaves');
  }
  get spoolingOfWire() {
    return this.craneForm.get('spoolingOfWire');
  }
  get hookcondition() {
    return this.craneForm.get('hookcondition');
  }
  get boomSections() {
    return this.craneForm.get('boomSections');
  }
  get engineV_belts() {
    return this.craneForm.get('engineV_belts');
  }
  get wiringVisually() {
    return this.craneForm.get('wiringVisually');
  }
  get loadIndicator() {
    return this.craneForm.get('loadIndicator');
  }
  get audibleAlarm() {
    return this.craneForm.get('audibleAlarm');
  }
  get loadLimiting() {
    return this.craneForm.get('loadLimiting');
  }
  get boomAngle() {
    return this.craneForm.get('boomAngle');
  }
  get limitSwitch() {
    return this.craneForm.get('limitSwitch');
  }
  get emergencyShutDown() {
    return this.craneForm.get('emergencyShutDown');
  }
  get operatingReturn() {
    return this.craneForm.get('operatingReturn');
  }
  get operatingControls() {
    return this.craneForm.get('operatingControls');
  }
  get headLight() {
    return this.craneForm.get('headLight');
  }
  get reverseAlarm() {
    return this.craneForm.get('reverseAlarm');
  }
  get parkingBrake() {
    return this.craneForm.get('parkingBrake');
  }
  get safetyBelt() {
    return this.craneForm.get('safetyBelt');
  }
  get driverSeat() {
    return this.craneForm.get('driverSeat');
  }
  get wipers() {
    return this.craneForm.get('wipers');
  }
  get existingCorrosion() {
    return this.craneForm.get('existingCorrosion');
  }
  get tireBolts() {
    return this.craneForm.get('tireBolts');
  }
  get safeLoadIndicator() {
    return this.craneForm.get('safeLoadIndicator');
  }
  get screenCurtains() {
    return this.craneForm.get('screenCurtains');
  }
  get outrigger() {
    return this.craneForm.get('outrigger');
  }
  get strangeSound() {
    return this.craneForm.get('strangeSound');
  }
  get cleanAndTidyRemarks() {
    return this.craneForm.get('cleanAndTidyRemarks');
  }
  get engineOilLevelRemarks() {
    return this.craneForm.get('engineOilLevelRemarks');
  }
  get transmissionOilLevelRemarks() {
    return this.craneForm.get('transmissionOilLevelRemarks');
  }
  get radiatorWaterLevelRemarks() {
    return this.craneForm.get('radiatorWaterLevelRemarks');
  }
  get hydraulicOilLevelRemarks() {
    return this.craneForm.get('hydraulicOilLevelRemarks');
  }
  get v_beltsTensionRemarks() {
    return this.craneForm.get('v_beltsTensionRemarks');
  }
  get drainWaterRemarks() {
    return this.craneForm.get('drainWaterRemarks');
  }
  get leaksRemarks() {
    return this.craneForm.get('leaksRemarks');
  }
  get batteryHolderRemarks() {
    return this.craneForm.get('batteryHolderRemarks');
  }
  get loadComputerRemarks() {
    return this.craneForm.get('loadComputerRemarks');
  }
  get gaugesForCcorrectReadingsRemarks() {
    return this.craneForm.get('gaugesForCcorrectReadingsRemarks');
  }
  get tirePressureRemarks() {
    return this.craneForm.get('tirePressureRemarks');
  }
  get fuelTanksFullRemarks() {
    return this.craneForm.get('fuelTanksFullRemarks');
  }
  get wireRopesRemarks() {
    return this.craneForm.get('wireRopesRemarks');
  }
  get swingBrakeRemarks() {
    return this.craneForm.get('swingBrakeRemarks');
  }
  get testLimitSwitchesRemarks() {
    return this.craneForm.get('testLimitSwitchesRemarks');
  }
  get testOutriggersRemarks() {
    return this.craneForm.get('testOutriggersRemarks');
  }
  get abnormalNoiseRemarks() {
    return this.craneForm.get('abnormalNoiseRemarks');
  }
  get serviceBrakesRemarks() {
    return this.craneForm.get('serviceBrakesRemarks');
  }
  get sheavesRemarks() {
    return this.craneForm.get('sheavesRemarks');
  }
  get spoolingOfWireRemarks() {
    return this.craneForm.get('spoolingOfWireRemarks');
  }
  get hookconditionRemarks() {
    return this.craneForm.get('hookconditionRemarks');
  }
  get boomSectionsRemarks() {
    return this.craneForm.get('boomSectionsRemarks');
  }
  get engineV_beltsRemarks() {
    return this.craneForm.get('engineV_beltsRemarks');
  }
  get wiringVisuallyRemarks() {
    return this.craneForm.get('wiringVisuallyRemarks');
  }
  get loadIndicatorRemarks() {
    return this.craneForm.get('loadIndicatorRemarks');
  }
  get audibleAlarmRemarks() {
    return this.craneForm.get('audibleAlarmRemarks');
  }
  get loadLimitingRemarks() {
    return this.craneForm.get('loadLimitingRemarks');
  }
  get boomAngleRemarks() {
    return this.craneForm.get('boomAngleRemarks');
  }
  get limitSwitchRemarks() {
    return this.craneForm.get('limitSwitchRemarks');
  }
  get emergencyShutDownRemarks() {
    return this.craneForm.get('emergencyShutDownRemarks');
  }
  get operatingReturnRemarks() {
    return this.craneForm.get('operatingReturnRemarks');
  }
  get operatingControlsRemarks() {
    return this.craneForm.get('operatingControlsRemarks');
  }
  get headLightRemarks() {
    return this.craneForm.get('headLightRemarks');
  }
  get reverseAlarmRemarks() {
    return this.craneForm.get('reverseAlarmRemarks');
  }
  get parkingBrakeRemarks() {
    return this.craneForm.get('parkingBrakeRemarks');
  }
  get safetyBeltRemarks() {
    return this.craneForm.get('safetyBeltRemarks');
  }
  get driverSeatRemarks() {
    return this.craneForm.get('driverSeatRemarks');
  }
  get wipersRemarks() {
    return this.craneForm.get('wipersRemarks');
  }
  get existingCorrosionRemarks() {
    return this.craneForm.get('existingCorrosionRemarks');
  }
  get tireBoltsRemarks() {
    return this.craneForm.get('tireBoltsRemarks');
  }
  get safeLoadIndicatorRemarks() {
    return this.craneForm.get('safeLoadIndicatorRemarks');
  }
  get screenCurtainsRemarks() {
    return this.craneForm.get('screenCurtainsRemarks');
  }
  get outriggerRemarks() {
    return this.craneForm.get('outriggerRemarks');
  }
  get strangeSoundRemarks() {
    return this.craneForm.get('strangeSoundRemarks');
  }
  get driverName() {
    return this.craneForm.get('driverName');
  }

  submitData() {
    if (this.craneForm.valid) {
      this.AddNew.AddCrane(this.craneForm.value).subscribe({
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
      console.log(this.craneForm.value);
    }
    else {
      this.craneForm.markAllAsTouched()
      console.log("E+++++====error in : ");
      console.log(this.craneForm);
    }
  }


  Download() {
    let workbook = new Workbook();

    let worksheet = workbook.addWorksheet("Weekly Crane Inspection Data");


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

    let fname = "Weekly Crane Inspection Report"

    //add data and file name and download
    workbook.xlsx.writeBuffer().then((data) => {
      let blob = new Blob([data], { type: 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet' });
      saveAs.saveAs(blob, fname + '-' + new Date().toUTCString() + '.xlsx');
    });
  }


}
