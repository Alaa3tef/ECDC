import { Component } from '@angular/core';
import { FormArray, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AddNewVehicleWeeklyChecklistReportService } from 'Services/add-new-vehicle-weekly-checklist-report.service';
import { DataService } from 'Services/data.service';
import { LoginService } from 'Services/login.service';
import { IRig } from 'SharedClasses/IRig';
import { Workbook } from 'exceljs';
import * as saveAs from 'file-saver';

@Component({
  selector: 'app-add-vehicle-weekly-checklist-report',
  templateUrl: './add-vehicle-weekly-checklist-report.component.html',
  styleUrls: ['./add-vehicle-weekly-checklist-report.component.scss']
})
export class AddVehicleWeeklyChecklistReportComponent {
  VehicleWeeklyChecklistForm!: FormGroup;
  ErrorMessage = '';
  json_data: any[] = [];
  rigList: IRig[] = [];
  SelectFiles: File[] = []
  UserJsonString: any;
  Record: any = {};
  UserJsonObj: any
  User: any;
  submitted: boolean = false;
  textVisible1: boolean = false;
  textVisible2: boolean = false;
  testUser: any;

  constructor(
    private loginService: LoginService,
    private dataService: DataService,
    private fb: FormBuilder,
    private AddService: AddNewVehicleWeeklyChecklistReportService) { }

  ngOnInit() {
    this.testUser = this.loginService.currentUser.getValue();
    console.log("////*********/////////")
    console.log(this.testUser)
    this.dataService.GetRig().subscribe({
      next: data => {
        this.rigList = data.data;
        console.log('rrrrrrrrrrrriiiiiiiiiiiiiiiiiiggggggggggg')
        console.log(this.rigList)
      },
      error: err => this.ErrorMessage = err
    });

    this.User = JSON.stringify(this.loginService.currentUser.getValue())//this.loginService.currentUser.getValue();
    console.log("uuuuuuussssssseeeeerrrrbbbbbvvvcc")



    this.AddService.GetVehicleWeeklyChecklistForExcel(this.testUser.ID, this.testUser.Role).subscribe({
      next: data => this.json_data = data.data,
      error: err => this.ErrorMessage = err
    });

    this.UserJsonString = JSON.stringify(this.loginService.currentUser.getValue())
    this.UserJsonObj = JSON.parse(this.UserJsonString);

    this.VehicleWeeklyChecklistForm = this.fb.group(
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
        cient: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        location: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        manPickupVehiclePlateNo: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        manPickupDriverName: this.fb.control(
          '',
          [
            Validators.required,
           // Validators.pattern :[/^[\u0600-\u06FF\u0750-\u077F\u0621-\u064A-Za-z\s]+$/]
          ]
        ),
        rigPickupVehiclePlateNo: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        rigPickupDriverName: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        primeMoverPlateNo: this.fb.control(
          '',
          [
             Validators.required
          ]
        ),
        trailerPlateNo: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        heavyTruckDriverName: this.fb.control(
          '',
          [
             Validators.required
          ]
        ),
        lightBusVehiclePlateNo: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        lightBusDriverName: this.fb.control(
          '',
          [
             Validators.required
          ]
        ),
        heavyTrucks: this.fb.array(
          [
            this.createHeavyTrucksFormGroup('1- Vehicle and driver licenses 1nd degree are valid'),
            this.createHeavyTrucksFormGroup('2- Fitness to work FTW'),
            this.createHeavyTrucksFormGroup('3- Valid defensive drive training from approved center.'),
            this.createHeavyTrucksFormGroup('4- GPS Access.'),

            this.createHeavyTrucksFormGroup('5- Have tyres Type tubeless of the same size and profile (pattern) and in good condition.'),
            this.createHeavyTrucksFormGroup('6- 2 multipurpose dry powder fire extinguishers with a capacity of 6 kg , First aid kit ,  minimum of one hazard warning triangle'),
            this.createHeavyTrucksFormGroup('7- To have minimum of ABS fitted on prime mover & ALL brakes (prime mover and trailer) are fully functional.'),
            this.createHeavyTrucksFormGroup('8- A dual-circuit, dual-line service brake system with a secondary braking system. All braking systems to be fail-safe in the event of loss of air pressure.'),

            this.createHeavyTrucksFormGroup('9- All light shall be fully functional.'),
            this.createHeavyTrucksFormGroup('10- Electrical sockets between trailer and prime mover are compatible and are connected correctly'),
            this.createHeavyTrucksFormGroup('11- Both prime mover and trailer are fitted with a reverse alarm that is audible to the rear of both units.'),
            this.createHeavyTrucksFormGroup('12- Provision of secondary retention (e.g. chain) for the propeller shaft in case of universal joint failure.'),

            this.createHeavyTrucksFormGroup('13- Both driver and passenger seat belts to be of 3-point inertia reel type.'),
            this.createHeavyTrucksFormGroup('15- All lights are fully functional.'),
            this.createHeavyTrucksFormGroup('16- Check Engine, Steering and Brake Oil Level '),

            this.createHeavyTrucksFormGroup('17- Check V-belts Tension'),
            this.createHeavyTrucksFormGroup('18- Check Radiator Water Level '),
            this.createHeavyTrucksFormGroup('19- Check Windscreen Wipers and its Water'),
            this.createHeavyTrucksFormGroup('20- Check for Leaks, Fuel, Water, Oil'),

            this.createHeavyTrucksFormGroup('21- Check Battery and Battery Holder '),
            this.createHeavyTrucksFormGroup('22- Check all Gauges for correct reading'),
            this.createHeavyTrucksFormGroup('23- Check for abnormal noise or vibration.')
          ],
          [
           // Validators.required
          ]
        ),
        manPickups: this.fb.array(
          [

            this.createManPickupFormGroup('1- Vehicle and driver licenses are valid'),
            this.createManPickupFormGroup('2- Fitness to work FTW'),
            this.createManPickupFormGroup('3- Valid defensive drive training from approved center.'),
            this.createManPickupFormGroup('4- GPS device is accessible.'),

            this.createManPickupFormGroup('5- Roll Over bar.'),
            this.createManPickupFormGroup('6- Have tyres Type tubeless of the same size and profile (pattern) and in good condition.'),
            this.createManPickupFormGroup('7- Vehicle is fitted with a spare wheel and equipment to change a wheel safely.'),
            this.createManPickupFormGroup('8- Seat belts with a functional 3-point inertia reel seatbelt shall be used.'),

            this.createManPickupFormGroup('9- Anti-lock Braking System (ABS).'),
            this.createManPickupFormGroup('10- Check main and hand Brakes '),
            this.createManPickupFormGroup('11- Minimum of two airbags fitted for driver and front passenger.'),
            this.createManPickupFormGroup('12- Be fitted with a serviceable air conditioning system able to maintain an in-cab temperature of less than 25°C under all driving conditions.'),

            this.createManPickupFormGroup('13- Fire extinguisher of minimum 2 kg capacity, First aid kit and Hazard warning triangle.'),
            this.createManPickupFormGroup('14- Reverse alarm mounted in the rear, which shall be audible and automatically activated when reverse is selected.'),
            this.createManPickupFormGroup('15- All lights are fully functional.'),
            this.createManPickupFormGroup('16- Check Engine, Steering and Brake Oil Level '),

            this.createManPickupFormGroup('17- Check V-belts Tension'),
            this.createManPickupFormGroup('18- Check Radiator Water Level '),
            this.createManPickupFormGroup('19- Check Windscreen Wipers and its Water'),
            this.createManPickupFormGroup('20- Check for Leaks, Fuel, Water, Oil'),

            this.createManPickupFormGroup('21- Check Battery and Battery Holder '),
            this.createManPickupFormGroup('22- Check all Gauges for correct reading'),
            this.createManPickupFormGroup('23- Check for abnormal noise or vibration.')
          ],
          [
           // Validators.required
          ]
        ),
        lightBus: this.fb.array(
          [
            this.createLightBusFormGroup('1- Vehicle and driver licenses 2nd degree are valid'),
            this.createLightBusFormGroup('2- Fitness to work FTW'),
            this.createLightBusFormGroup('3- Valid defensive drive training from approved center.'),
            this.createLightBusFormGroup('4- GPS device is accessible.'),

            this.createLightBusFormGroup('5- Have tyres Type tubeless of the same size and profile (pattern) and in good condition.'),
            this.createLightBusFormGroup('6- Vehicle is fitted with a spare wheel and equipment to change a wheel safely.'),
            this.createLightBusFormGroup('7- Driver and Co-pilot seat (right of driver) seat is fitted with a functional 3-point inertia reel seatbelt.'),
            this.createLightBusFormGroup('8- All passenger seats are fitted with a minimum of 2 point inertia or adjustable lap belt and function correctly.'),

            this.createLightBusFormGroup('9- Anti-lock Braking System (ABS).'),
            this.createLightBusFormGroup('10- Check main and hand Brakes '),
            this.createLightBusFormGroup('11- Minimum of two airbags fitted for driver and front passenger.'),
            this.createLightBusFormGroup('12- Be fitted with a serviceable air conditioning system able to maintain an in-cab temperature of less than 25°C under all driving conditions.'),

            this.createLightBusFormGroup('13- Fire extinguisher of minimum 2 kg capacity, First aid kit and Hazard warning triangle.'),
            this.createLightBusFormGroup('14- Reverse alarm mounted in the rear, which shall be audible and automatically activated when reverse is selected.'),
            this.createLightBusFormGroup('15- All lights are fully functional.'),
            this.createLightBusFormGroup('16- Check Engine, Steering and Brake Oil Level '),

            this.createLightBusFormGroup('17- Check V-belts Tension'),
            this.createLightBusFormGroup('18- Check Radiator Water Level '),
            this.createLightBusFormGroup('19- Check Windscreen Wipers and its Water'),
            this.createLightBusFormGroup('20- Check for Leaks, Fuel, Water, Oil'),

            this.createLightBusFormGroup('21- Check Battery and Battery Holder '),
            this.createLightBusFormGroup('22- Check all Gauges for correct reading'),
            this.createLightBusFormGroup('23- Check for abnormal noise or vibration.')
          ],
          [
           // Validators.required
          ]
        ),
        rigPickups: this.fb.array(
          [
            this.createRigPickupFormGroup('1- Vehicle and driver licenses are valid'),
            this.createRigPickupFormGroup('2- Fitness to work FTW'),
            this.createRigPickupFormGroup('3- Valid defensive drive training from approved center.'),
            this.createRigPickupFormGroup('4- GPS device is accessible.'),

            this.createRigPickupFormGroup('5- Roll Over bar.'),
            this.createRigPickupFormGroup('6- Have tyres Type tubeless of the same size and profile (pattern) and in good condition.'),
            this.createRigPickupFormGroup('7- Vehicle is fitted with a spare wheel and equipment to change a wheel safely.'),
            this.createRigPickupFormGroup('8- Seat belts with a functional 3-point inertia reel seatbelt shall be used.'),

            this.createRigPickupFormGroup('9- Anti-lock Braking System (ABS).'),
            this.createRigPickupFormGroup('10- Check main and hand Brakes '),
            this.createRigPickupFormGroup('11- Minimum of two airbags fitted for driver and front passenger.'),
            this.createRigPickupFormGroup('12- Be fitted with a serviceable air conditioning system able to maintain an in-cab temperature of less than 25°C under all driving conditions.'),

            this.createRigPickupFormGroup('13- Fire extinguisher of minimum 2 kg capacity, First aid kit and Hazard warning triangle.'),
            this.createRigPickupFormGroup('14- Reverse alarm mounted in the rear, which shall be audible and automatically activated when reverse is selected.'),
            this.createRigPickupFormGroup('15- All lights are fully functional.'),
            this.createRigPickupFormGroup('16- Check Engine, Steering and Brake Oil Level '),

            this.createRigPickupFormGroup('17- Check V-belts Tension'),
            this.createRigPickupFormGroup('18- Check Radiator Water Level '),
            this.createRigPickupFormGroup('19- Check Windscreen Wipers and its Water'),
            this.createRigPickupFormGroup('20- Check for Leaks, Fuel, Water, Oil'),

            this.createRigPickupFormGroup('21- Check Battery and Battery Holder '),
            this.createRigPickupFormGroup('22- Check all Gauges for correct reading'),
            this.createRigPickupFormGroup('23- Check for abnormal noise or vibration.')
          ],
          [
            //Validators.required
          ]
        ),
        userID: this.fb.control(
          this.UserJsonObj.ID,
          [
            Validators.required
          ]
        ),
        hseEngineer: this.fb.control(
          '',
          [
            Validators.required
          ]
        )
      }
    );
  }


  get id() {
    return this.VehicleWeeklyChecklistForm.get('id');
  }
  get rigId() {
    return this.VehicleWeeklyChecklistForm.get('rigId');
  }
  get date() {
    return this.VehicleWeeklyChecklistForm.get('date');
  }
  get cient() {
    return this.VehicleWeeklyChecklistForm.get('cient');
  }
  get hseEngineer() {
    return this.VehicleWeeklyChecklistForm.get('hseEngineer');
  }
  get location() {
    return this.VehicleWeeklyChecklistForm.get('location');
  }
  get manPickupVehiclePlateNo() {
    return this.VehicleWeeklyChecklistForm.get('manPickupVehiclePlateNo');
  }
  get manPickupDriverName() {
    return this.VehicleWeeklyChecklistForm.get('manPickupDriverName');
  }
  get rigPickupDriverName() {
    return this.VehicleWeeklyChecklistForm.get('rigPickupDriverName');
  }
  get rigPickupVehiclePlateNo() {
    return this.VehicleWeeklyChecklistForm.get('rigPickupVehiclePlateNo');
  }
  get primeMoverPlateNo() {
    return this.VehicleWeeklyChecklistForm.get('primeMoverPlateNo');
  }
  get trailerPlateNo() {
    return this.VehicleWeeklyChecklistForm.get('trailerPlateNo');
  }
  get heavyTruckDriverName() {
    return this.VehicleWeeklyChecklistForm.get('heavyTruckDriverName');
  }
  get lightBusVehiclePlateNo() {
    return this.VehicleWeeklyChecklistForm.get('lightBusVehiclePlateNo');
  }
  get lightBusDriverName() {
    return this.VehicleWeeklyChecklistForm.get('lightBusDriverName');
  }
  get manPickups() {
    return this.VehicleWeeklyChecklistForm.get('manPickups')as FormArray;
  }
  get rigPickups() {
    return this.VehicleWeeklyChecklistForm.get('rigPickups')as FormArray;
  }
  get lightBus() {
    return this.VehicleWeeklyChecklistForm.get('lightBus')as FormArray;
  }

  get heavyTrucks() {
    return this.VehicleWeeklyChecklistForm.get('heavyTrucks') as FormArray;
  }

  createHeavyTrucksFormGroup(itemValue: string) {
    return this.fb.group({
      item : [itemValue, Validators.required],
      status : ['', Validators.required],
      remarks: ['',],
    });
  }
  createManPickupFormGroup(itemValue: string) {
    return this.fb.group({
      item : [itemValue, Validators.required],
      remarks : [''],
      status: ['', Validators.required],
    });
  }
  createLightBusFormGroup(itemValue:string) {
    return this.fb.group({
      item : [itemValue, Validators.required],
      status : ['', Validators.required],
      remarks: [''],
    });
  }
  createRigPickupFormGroup(itemValue:string) {
    return this.fb.group({
      item : [itemValue, Validators.required],
      remarks : [''],
      status: ['', Validators.required],
    });
  }
  submitData() {
    console.log("this.VehicleWeeklyChecklistForm.value")
    console.log(this.VehicleWeeklyChecklistForm.value)
    if (this.VehicleWeeklyChecklistForm.valid) {
      this.submitted = false
      this.AddService.AddVehicleWeeklyChecklist(this.VehicleWeeklyChecklistForm.value).subscribe({
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
      // console.log(Formdata);
    }
    else {
      this.VehicleWeeklyChecklistForm.markAllAsTouched()
      this.submitted = true;
      console.log("E+++++====error in : ");
      console.log(this.VehicleWeeklyChecklistForm);
    }
  }

  Download() {
    let workbook = new Workbook();

    let worksheet = workbook.addWorksheet("VehicleWeeklyChecklist Data");


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

    let fname = "Vehicle Weekly Checklist Report "

    //add data and file name and download
    workbook.xlsx.writeBuffer().then((data) => {
      let blob = new Blob([data], { type: 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet' });
      saveAs.saveAs(blob, fname + '-' + new Date().toUTCString() + '.xlsx');
    });
  }

}
