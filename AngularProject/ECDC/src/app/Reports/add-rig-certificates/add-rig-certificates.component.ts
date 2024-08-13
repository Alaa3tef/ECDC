import { DatePipe } from '@angular/common';
import { Component } from '@angular/core';
import { FormArray, FormBuilder, FormGroup, ValidationErrors, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AddDataService } from 'Services/add-data.service';
import { DataService } from 'Services/data.service';
import { LoginService } from 'Services/login.service';
import { RigCertificatesService } from 'Services/rig-certificates.service';
import { ICertificatesType } from 'SharedClasses/ICertificatesType';
import { IEquipmentList } from 'SharedClasses/IEquipmentList';
import { IRig } from 'SharedClasses/IRig';
import { Workbook } from 'exceljs';
import * as saveAs from 'file-saver';

@Component({
  selector: 'app-add-rig-certificates',
  templateUrl: './add-rig-certificates.component.html',
  styleUrls: ['./add-rig-certificates.component.scss']
})
export class AddRigCertificatesComponent {
  RigCertificatesForm!: FormGroup;
  ErrorMessage = '';
  json_data: any[] = [];
  time = new Date();
  rigList: IRig[] = [];
  cetificatesTypeList: ICertificatesType[] = [];
  equipmentList: IEquipmentList[] = [];
  SelectFiles: File[] = []
  UserJsonString: any;
  Record: any = {};
  UserJsonObj: any
  User: any;
  submitted: boolean = false;
  textVisible1: boolean = false;
  textVisible2: boolean = false;
  testUser: any;
  EmpCodeList: any;

  EmpCode_NameID: number = 0;
  // EmpCode_Name:string='';
  // EmpCode_Position:string='';
  EmpCode_Name: any[] = [];
  EmpCode_Position: any[] = [];

  // leavingEmpCode_Name:string='';
  // leavingEmpCode_NameId:number=0;

  today = new Date();

  presssureReliefValveClicked: boolean = false;
  hseEquipmentTableClicked: boolean = false;
  personnelCerificatesClicked: boolean = false;
  hydraulicWinchClicked: boolean = false;
  airHoistClicked: boolean = false;
  manRidingWinchClicked: boolean = false;
  forkliftClicked: boolean = false;
  mobileCraneClicked: boolean = false;

  constructor(private datePipe: DatePipe,
    private loginService: LoginService,
    private dataService: DataService,
    private fb: FormBuilder,
    private router: Router,
    private addDataService: AddDataService,
    private AddService: RigCertificatesService) { }

  ngOnInit() {
    // this.today.setHours(0, 0, 0, 0);
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
    this.dataService.GetCertificatesType().subscribe({
      next: data => {
        this.cetificatesTypeList = data.data;
        console.log(this.cetificatesTypeList)
      },
      error: err => this.ErrorMessage = err
    });
    this.dataService.GetHSEEquipmentList().subscribe({
      next: data => {
        this.equipmentList = data.data;
        console.log(this.equipmentList)
      },
      error: err => this.ErrorMessage = err
    });
    this.dataService.GetEmpCode().subscribe({
      next: data => {
        this.EmpCodeList = data.data,
          console.log("this.EmpCodeList")
        console.log(this.EmpCodeList)
      },
      error: err => {
        this.ErrorMessage = err,
          console.log("this.ErrorMessage")
        console.log(this.ErrorMessage)
      }
    }),

      this.User = JSON.stringify(this.loginService.currentUser.getValue())//this.loginService.currentUser.getValue();
    console.log("uuuuuuussssssseeeeerrrrbbbbbvvvcc")



    this.AddService.GetRigCertificatesForExcel(this.testUser.ID, this.testUser.Role).subscribe({
      next: data => this.json_data = data.data,
      error: err => this.ErrorMessage = err
    });

    this.UserJsonString = JSON.stringify(this.loginService.currentUser.getValue())
    this.UserJsonObj = JSON.parse(this.UserJsonString);

    this.RigCertificatesForm = this.fb.group(
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
        certificationLiftingGear: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        certificationCATIII: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        certificationCATIV: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        certificationGaugeCalibraion: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        certificationWallThickness: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        dueLiftingGear: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        dueCATIII: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        dueCATIV: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        dueGaugeCalibraion: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        dueWallThickness: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        mobileCrane: this.fb.array(
          []
        ),
        forklift: this.fb.array(
          []
        ),
        manRidingWinch: this.fb.array(
          []
        ),
        airHoist: this.fb.array(
          []
        ),
        hydraulicWinch: this.fb.array(
          []
        ),
        personnelCerificates: this.fb.array(
          []
        ),
        presssureReliefValve: this.fb.array(
          []
        ),
        hseEquipmentTable: this.fb.array(
          []
        ),
        hoistingSystem: this.fb.array(
          [
            this.createhoistingSystemFormGroup('Mast'),
            this.createhoistingSystemFormGroup('Substructure'),
            this.createhoistingSystemFormGroup('Post of substructure'),
            this.createhoistingSystemFormGroup('Crown Block'),
            this.createhoistingSystemFormGroup('Travelling Block'),
            this.createhoistingSystemFormGroup('Travelling Block Hook'),
            this.createhoistingSystemFormGroup('Stabbing Board'),
            this.createhoistingSystemFormGroup('Monkey Board'),
            this.createhoistingSystemFormGroup('Dead Line Anchor'),
            this.createhoistingSystemFormGroup('Block Hang off Line'),
            this.createhoistingSystemFormGroup('Drawwork'),
            this.createhoistingSystemFormGroup('Drum reel'),
            this.createhoistingSystemFormGroup('Break band'),
            this.createhoistingSystemFormGroup('Welding for break hand'),
            this.createhoistingSystemFormGroup('Monkey board connections and fingers'),
            this.createhoistingSystemFormGroup('Man Riding'),
            this.createhoistingSystemFormGroup('Air Tugger 1'),
            this.createhoistingSystemFormGroup('Air Tugger 2'),
            this.createhoistingSystemFormGroup('Hydraulic Tugger 1'),
            this.createhoistingSystemFormGroup('Hydraulic Tugger 2'),
          ]
        ),
        rotarySystem: this.fb.array(
          [
            this.createrotarySystemFormGroup('Rotary Table'),
            this.createrotarySystemFormGroup('TDS'),
            this.createrotarySystemFormGroup('Swivel'),
            this.createrotarySystemFormGroup('Master bushing'),
            this.createrotarySystemFormGroup('Kelly'),
            this.createrotarySystemFormGroup('kelly bushing'),
          ]
        ),
        mudCirculationSystem: this.fb.array(
          [
            this.createmudCirculationSystemFormGroup('Mud Pump 1'),
            this.createmudCirculationSystemFormGroup('Mud Pump 2'),
            this.createmudCirculationSystemFormGroup('Relief Valves of Mud Pumps'),
            this.createmudCirculationSystemFormGroup('Mud pump gauges'),
            this.createmudCirculationSystemFormGroup('Stand pipe'),
            this.createmudCirculationSystemFormGroup('Pulsation Dampeners'),
            this.createmudCirculationSystemFormGroup('water tanks'),
            this.createmudCirculationSystemFormGroup('mud system tanks'),
            this.createmudCirculationSystemFormGroup('Shale Shaker'),
            this.createmudCirculationSystemFormGroup('Flow Line'),
            this.createmudCirculationSystemFormGroup('Stand Pipe manifold'),
          ]
        ),
        wellControlSystem: this.fb.array(
          [
            this.createwellControlSystemFormGroup('Kommey Unit & BOTTLES'),
            this.createwellControlSystemFormGroup('Annular BOP'),
            this.createwellControlSystemFormGroup('Double BOP'),
            this.createwellControlSystemFormGroup('Bottom Ram BOP'),
            this.createwellControlSystemFormGroup('Test Stump'),
            this.createwellControlSystemFormGroup('Coflex Hoses'),
            this.createwellControlSystemFormGroup('Swaco Unit'),
            this.createwellControlSystemFormGroup('Test Pump'),
            this.createwellControlSystemFormGroup('Choke Manifold'),
            this.createwellControlSystemFormGroup('BOP pad eyes ( Lifting frame )'),
            this.createwellControlSystemFormGroup('BOP Crane'),
            this.createwellControlSystemFormGroup('BOP TROLLY and skid'),
          ]
        ),
        powerSystem: this.fb.array(
          [
            this.createpowerSystemFormGroup('Generators'),
            this.createpowerSystemFormGroup('Air Compressors'),
            this.createpowerSystemFormGroup('Main air receiver tank'),
            this.createpowerSystemFormGroup('SCR or VFD'),
            this.createpowerSystemFormGroup('MCC'),
            this.createpowerSystemFormGroup('Air receiver tanks ( carrier)'),
          ]
        ),
        otherSystem: this.fb.array(
          [
            this.createotherSystemFormGroup('Slips, Elev. All Sizes'),
            this.createotherSystemFormGroup('Elev. Links All Sizes'),
            this.createotherSystemFormGroup('Catwalk'),
            this.createotherSystemFormGroup('Pipe racks'),
            this.createotherSystemFormGroup('Barrel racks'),
            this.createotherSystemFormGroup('Fly camp caravans'),
            this.createotherSystemFormGroup('Main camp caravans'),
            this.createotherSystemFormGroup('Stores'),
            this.createotherSystemFormGroup('Bottles racks'),
            this.createotherSystemFormGroup('Personal basket'),
            this.createotherSystemFormGroup('Stair guard for mast'),
            this.createotherSystemFormGroup('Stairs'),
            this.createotherSystemFormGroup('Welding of rack above carrier'),
            this.createotherSystemFormGroup('Connection pad eyes between carrier and mast'),
            this.createotherSystemFormGroup('carrier Ramp'),
            this.createotherSystemFormGroup('Base for dog house and pad eyes to rig floor'),
            this.createotherSystemFormGroup('Welding area for carrier base '),
            this.createotherSystemFormGroup('Posts'),
            this.createotherSystemFormGroup('Scaffold'),
            this.createotherSystemFormGroup('Connection pad eyes for mast raising piston'),
            this.createotherSystemFormGroup('Baskets'),
            this.createotherSystemFormGroup('Flanges'),
            this.createotherSystemFormGroup('Links'),
            this.createotherSystemFormGroup('Pipes Handling Tools'),
            this.createotherSystemFormGroup('Lifting caps'),
            this.createotherSystemFormGroup('Safety clamps'),
            this.createotherSystemFormGroup('Rig tong'),
            this.createotherSystemFormGroup('Power tong'),
            this.createotherSystemFormGroup('Pipe Spinner'),
            this.createotherSystemFormGroup('Bit Breaker'),
            this.createotherSystemFormGroup('Cooling tank'),
            this.createotherSystemFormGroup('Fire Tank'),
            this.createotherSystemFormGroup('Diesel Tanks'),
            this.createotherSystemFormGroup('Fire Pump'),
            this.createotherSystemFormGroup('Carrier chassis'),
          ]
        ),
        userID: this.fb.control(
          this.UserJsonObj.ID,
          [
            Validators.required
          ]
        )
      }
    );
  }

  get id() {
    return this.RigCertificatesForm.get('id');
  }
  get rigId() {
    return this.RigCertificatesForm.get('rigId');
  }
  get date() {
    return this.RigCertificatesForm.get('date');
  }
  get certificationLiftingGear() {
    return this.RigCertificatesForm.get('certificationLiftingGear');
  }
  get certificationCATIII() {
    return this.RigCertificatesForm.get('certificationCATIII');
  }
  get certificationCATIV() {
    return this.RigCertificatesForm.get('certificationCATIV');
  }
  get certificationGaugeCalibraion() {
    return this.RigCertificatesForm.get('certificationGaugeCalibraion');
  }
  get certificationWallThickness() {
    return this.RigCertificatesForm.get('certificationWallThickness');
  }
  get dueLiftingGear() {
    return this.RigCertificatesForm.get('dueLiftingGear');
  }
  get dueCATIII() {
    return this.RigCertificatesForm.get('dueCATIII');
  }
  get dueCATIV() {
    return this.RigCertificatesForm.get('dueCATIV');
  }
  get dueGaugeCalibraion() {
    return this.RigCertificatesForm.get('dueGaugeCalibraion');
  }
  get dueWallThickness() {
    return this.RigCertificatesForm.get('dueWallThickness');
  }
  get hseEquipmentTable() {
    return this.RigCertificatesForm.get('hseEquipmentTable') as FormArray;
  }
  get mudCirculationSystem() {
    return this.RigCertificatesForm.get('mudCirculationSystem') as FormArray;
  }
  get wellControlSystem() {
    return this.RigCertificatesForm.get('wellControlSystem') as FormArray;
  }
  get powerSystem() {
    return this.RigCertificatesForm.get('powerSystem') as FormArray;
  }
  get otherSystem() {
    return this.RigCertificatesForm.get('otherSystem') as FormArray;
  }
  get presssureReliefValve() {
    return this.RigCertificatesForm.get('presssureReliefValve') as FormArray;
  }
  get personnelCerificates() {
    return this.RigCertificatesForm.get('personnelCerificates') as FormArray;
  }
  get mobileCrane() {
    return this.RigCertificatesForm.get('mobileCrane') as FormArray;
  }
  get forklift() {
    return this.RigCertificatesForm.get('forklift') as FormArray;
  }
  get airHoist() {
    return this.RigCertificatesForm.get('airHoist') as FormArray;
  }
  get hydraulicWinch() {
    return this.RigCertificatesForm.get('hydraulicWinch') as FormArray;
  }
  get manRidingWinch() {
    return this.RigCertificatesForm.get('manRidingWinch') as FormArray;
  }
  get hoistingSystem() {
    return this.RigCertificatesForm.get('hoistingSystem') as FormArray;
  }
  get rotarySystem() {
    return this.RigCertificatesForm.get('rotarySystem') as FormArray;
  }


  createhoistingSystemFormGroup(itemValue: string, isNewRow: boolean = false) {
    return this.fb.group({
      equipment: [itemValue],
      serialNumber: [''],
      cocAvailabilty: [''],
      catiiiCertificationDate: [''],
      catiiiExpiryDate: [''],
      cativCertificationDate: [''],
      cativExpiryDate: [''],
      isNewRow: [isNewRow] // Track if the row is new or existing
    });
  }

  createwellControlSystemFormGroup(itemValue: string, isNewRow: boolean = false) {
    return this.fb.group({
      equipment: [itemValue],
      serialNumber: [''],
      cocAvailabilty: [''],
      catiiiCertificationDate: [''],
      catiiiExpiryDate: [''],
      cativCertificationDate: [''],
      cativExpiryDate: [''],
      isNewRow: [isNewRow] // Track if the row is new or existing
    });
  }

  createpowerSystemFormGroup(itemValue: string, isNewRow: boolean = false) {
    return this.fb.group({
      equipment: [itemValue],
      serialNumber: [''],
      cocAvailabilty: [''],
      catiiiCertificationDate: [''],
      catiiiExpiryDate: [''],
      cativCertificationDate: [''],
      cativExpiryDate: [''],
      isNewRow: [isNewRow] // Track if the row is new or existing
    });
  }

  createotherSystemFormGroup(itemValue: string, isNewRow: boolean = false) {
    return this.fb.group({
      item: [itemValue],
      catiiiCertificationDate: [''],
      catiiiExpiryDate: [''],
      cativCertificationDate: [''],
      cativExpiryDate: [''],
      isNewRow: [isNewRow] // Track if the row is new or existing
    });
  }

  createrotarySystemFormGroup(itemValue: string, isNewRow: boolean = false) {
    return this.fb.group({
      equipment: [itemValue],
      serialNumber: [''],
      cocAvailabilty: [''],
      catiiiCertificationDate: [''],
      catiiiExpiryDate: [''],
      cativCertificationDate: [''],
      cativExpiryDate: [''],
      isNewRow: [isNewRow] // Track if the row is new or existing
    });
  }

  createmudCirculationSystemFormGroup(itemValue: string, isNewRow: boolean = false) {
    return this.fb.group({
      equipment: [itemValue],
      serialNumber: [''],
      cocAvailabilty: [''],
      catiiiCertificationDate: [''],
      catiiiExpiryDate: [''],
      cativCertificationDate: [''],
      cativExpiryDate: [''],
      isNewRow: [isNewRow] // Track if the row is new or existing
    });
  }
  createhseEquipmentTableFormGroup() {
    return this.fb.group({
      equipmentId: ['', Validators.required],
      model: ['', Validators.required],
      serialNumber: ['', Validators.required],
      expiryDate: ['', Validators.required],
    });
  }
  createpresssureReliefValveFormGroup() {
    return this.fb.group({
      valves: ['', Validators.required],
      location: ['', Validators.required],
      certificationDate: ['', Validators.required],
      expiryDate: ['', Validators.required],
    });
  }
  createpersonnelCerificatesFormGroup() {
    return this.fb.group({
      code: ['', Validators.required],
      position: ['', Validators.required],
      name: ['', Validators.required],
      certificateType: ['', Validators.required],
      certificateDate: ['', Validators.required],
      expiryDate: ['', Validators.required],
    });
  }
  createmobileCraneFormGroup() {
    return this.fb.group({
      model: ['', Validators.required],
      type: ['', Validators.required],
      chassisNo: ['', Validators.required],
      hookSerialNo: ['', Validators.required],
      capacity: ['', Validators.required],
      manufactureDate: ['', Validators.required],
      lastExaminationDate: ['', Validators.required],
      nextExaminationDate: ['', Validators.required],
    })
  }
  createforkliftFormGroup() {
    return this.fb.group({
      model: ['', Validators.required],
      type: ['', Validators.required],
      serialNo: ['', Validators.required],
      capacity: ['', Validators.required],
      // manufactureDate: ['', Validators.required],
      lastExaminationDate: ['', Validators.required],
      nextExaminationDate: ['', Validators.required],
    })
  }
  createmanRidingWinchFormGroup() {
    return this.fb.group({
      serialNo: ['', Validators.required],
      wireSize: ['', Validators.required],
      capacity: ['', Validators.required],
      wireInspectionDueDate: ['', Validators.required],
      lastMPIInspectionDate: ['', Validators.required],
      nextMPIInspectionDate: ['', Validators.required],
      nextLoadTestDate: ['', Validators.required],
    });
  }
  createairHoistFormGroup() {
    return this.fb.group({
      serialNo: ['', Validators.required],
      wireSize: ['', Validators.required],
      capacity: ['', Validators.required],
      wireInspectionDueDate: ['', Validators.required],
      lastMPIInspectionDate: ['', Validators.required],
      nextMPIInspectionDate: ['', Validators.required],
      nextLoadTestDate: ['', Validators.required],
    });
  }
  createhydraulicWinchFormGroup() {
    return this.fb.group({
      serialNo: ['', Validators.required],
      wireSize: ['', Validators.required],
      capacity: ['', Validators.required],
      wireInspectionDueDate: ['', Validators.required],
      lastMPIInspectionDate: ['', Validators.required],
      nextMPIInspectionDate: ['', Validators.required],
      nextLoadTestDate: ['', Validators.required],
    });
  }

  addrotarySystem() {
    this.rotarySystem.push(this.createrotarySystemFormGroup('', true));
  }
  deleteRotarySystem(index: any) {
    if (confirm("Are you sure you want to delete this record?")) {
      this.rotarySystem.removeAt(index);
    }
  }

  addhoistingSystem() {
    this.hoistingSystem.push(this.createhoistingSystemFormGroup('', true));
  }
  deletehoistingSystem(index: any) {
    if (confirm("Are you sure you want to delete this record?")) {
      this.hoistingSystem.removeAt(index);
    }
  }
  addmudCirculationSystem() {
    this.mudCirculationSystem.push(this.createmudCirculationSystemFormGroup('', true));
  }
  deletemudCirculationSystem(index: any) {
    if (confirm("Are you sure you want to delete this record?")) {
      this.mudCirculationSystem.removeAt(index);
    }
  }
  addwellControlSystem() {
    this.wellControlSystem.push(this.createwellControlSystemFormGroup('', true));
  }
  deletewellControlSystem(index: any) {
    if (confirm("Are you sure you want to delete this record?")) {
      this.wellControlSystem.removeAt(index);
    }
  }
  addpowerSystem() {
    this.powerSystem.push(this.createpowerSystemFormGroup('', true));
  }
  deletepowerSystem(index: any) {
    if (confirm("Are you sure you want to delete this record?")) {
      this.powerSystem.removeAt(index);
    }
  }
  addotherSystem() {
    this.otherSystem.push(this.createotherSystemFormGroup('', true));
  }
  deleteotherSystem(index: any) {
    if (confirm("Are you sure you want to delete this record?")) {
      this.otherSystem.removeAt(index);
    }
  }
  addpersonnelCerificates() {
    this.personnelCerificates.push(this.createpersonnelCerificatesFormGroup());
    this.personnelCerificatesClicked = true;
    this.EmpCode_Name.push('');
    this.EmpCode_Position.push('');
  }
  deletepersonnelCerificates(index: any) {
    if (confirm("Are you sure you want to delete this record?")) {
      this.personnelCerificates.removeAt(index);
    }
  }
  addmobileCrane() {
    this.mobileCrane.push(this.createmobileCraneFormGroup());
    this.mobileCraneClicked = true;
  }
  deletemobileCrane(index: any) {
    if (confirm("Are you sure you want to delete this record?")) {
      this.mobileCrane.removeAt(index);
    }
  }
  addforklift() {
    this.forklift.push(this.createforkliftFormGroup());
    this.forkliftClicked = true;
  }
  deleteforklift(index: any) {
    if (confirm("Are you sure you want to delete this record?")) {
      this.forklift.removeAt(index);
    }
  }
  addmanRidingWinch() {
    this.manRidingWinch.push(this.createmanRidingWinchFormGroup());
    this.manRidingWinchClicked = true;
  }
  deletemanRidingWinch(index: any) {
    if (confirm("Are you sure you want to delete this record?")) {
      this.manRidingWinch.removeAt(index);
    }
  }
  addairHoist() {
    this.airHoist.push(this.createairHoistFormGroup());
    this.airHoistClicked = true;
  }
  deleteairHoist(index: any) {
    if (confirm("Are you sure you want to delete this record?")) {
      this.airHoist.removeAt(index);
    }
  }
  addhydraulicWinch() {
    this.hydraulicWinch.push(this.createhydraulicWinchFormGroup());
    this.hydraulicWinchClicked = true;
  }
  deletehydraulicWinch(index: any) {
    if (confirm("Are you sure you want to delete this record?")) {
      this.hydraulicWinch.removeAt(index);
    }
  }
  addpresssureReliefValve() {
    this.presssureReliefValve.push(this.createpresssureReliefValveFormGroup());
    this.presssureReliefValveClicked = true;
  }
  deletepresssureReliefValve(index: any) {
    if (confirm("Are you sure you want to delete this record?")) {
      this.presssureReliefValve.removeAt(index);
    }
  }
  addhseEquipmentTable() {
    this.hseEquipmentTable.push(this.createhseEquipmentTableFormGroup());
    this.hseEquipmentTableClicked = true;
  }
  deletehseEquipmentTable(index: any) {
    if (confirm("Are you sure you want to delete this record?")) {
      this.hseEquipmentTable.removeAt(index);
    }
  }
  submitData() {
    console.log("this.RigCertificatesForm.value")
    console.log(this.RigCertificatesForm.value)
    if (this.RigCertificatesForm.valid) {
      this.submitted = false
      this.AddService.AddRigCertificates(this.RigCertificatesForm.value).subscribe({
        next: data => {
          console.log('from service')
          console.log(data)
          location.reload();
        },
        error: error => {
          console.log("from Error")
          console.log(error)
          console.log(this.RigCertificatesForm)
          console.log(this.RigCertificatesForm.errors)
        }
      });
      // console.log(Formdata);
    }
    else {
      this.RigCertificatesForm.markAllAsTouched()
      this.submitted = true;
      console.log("E+++++====error in : ");
      console.log(this.RigCertificatesForm)
    }
  }

  selectedMenace(event: any, i: any) {
    console.log("event.target.value")
    console.log(event.target.value)
    this.dataService.GetEmpCodeByCodeAndPosition(event.target.value).subscribe({
      next: data => {
        this.EmpCode_NameID = data.data.id
        this.EmpCode_Name[i] = data.data.name,
          this.EmpCode_Position[i] = data.data.position,
          console.log(data.data)
        console.log("this.EmpCode_Name")
        console.log(this.EmpCode_Name)
        console.log(this.EmpCode_Position)
      },
      error: err => {
        this.ErrorMessage = err,
          console.log(err)
      }
    })
  }


  Download() {
    let workbook = new Workbook();

    let worksheet = workbook.addWorksheet("RigCertificates Data");


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

    let fname = "RigCertificates Report"

    //add data and file name and download
    workbook.xlsx.writeBuffer().then((data) => {
      let blob = new Blob([data], { type: 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet' });
      saveAs.saveAs(blob, fname + '-' + new Date().toUTCString() + '.xlsx');
    });
  }
}
