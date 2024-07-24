import { DatePipe } from '@angular/common';
import { Component } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormArray, ValidationErrors } from '@angular/forms';
import { ActivatedRoute, ParamMap, Router } from '@angular/router';
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
  selector: 'app-edit-rig-certificates',
  templateUrl: './edit-rig-certificates.component.html',
  styleUrls: ['./edit-rig-certificates.component.scss']
})
export class EditRigCertificatesComponent {
  RigCertificatesId: any;
  RigCertificates!: any;
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

  EmpCode_Name: any[] = [];
  EmpCode_Position: any[] = [];

  numHSEEquipmentTable: number = 0;
  numHoistingSystem: number = 0;
  numRotarySystem: number = 0;
  numMudCirculationSystem: number = 0;
  numPowerSystem: number = 0;
  numOtherSystem: number = 0;
  numWellControlSystem: number = 0;
  numPresssureReliefValve: number = 0;
  numPersonnelCerificates: number = 0;
  numHydraulicWinch: number = 0;
  numAirHoist: number = 0;
  numManRidingWinch: number = 0;
  numForklift: number = 0;
  numMobileCrane: number = 0;

  presssureReliefValveClicked: boolean = false;
  hseEquipmentTableClicked: boolean = false;
  personnelCerificatesClicked: boolean = false;
  HoistingSystemClicked: boolean = false;
  RotarySystemClicked: boolean = false;
  MudCirculationSystemClicked: boolean = false;
  PowerSystemClicked: boolean = false;
  OtherSystemClicked: boolean = false;
  WellControlSystemClicked: boolean = false;
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
    private activatedRoute: ActivatedRoute,
    private AddService: RigCertificatesService) { }

  ngOnInit() {
    this.testUser = this.loginService.currentUser.getValue();
    console.log("////*********/////////")
    console.log(this.testUser)
    this.activatedRoute.paramMap.subscribe((params: ParamMap) => {
      this.RigCertificatesId = params.get("id");
      console.log(this.RigCertificatesId)
    }),
      this.AddService.GetRigCertificatesById(this.RigCertificatesId, this.testUser.ID, this.testUser.Role).subscribe({
        next: data => {
          this.RigCertificates = data.data

          this.numHSEEquipmentTable = this.RigCertificates.hseEquipmentTable.length;
          this.numHoistingSystem = this.RigCertificates.hoistingSystem.length;
          this.numRotarySystem = this.RigCertificates.rotarySystem.length;
          this.numMudCirculationSystem = this.RigCertificates.mudCirculationSystem.length;
          this.numWellControlSystem = this.RigCertificates.wellControlSystem.length;
          this.numPowerSystem = this.RigCertificates.powerSystem.length;
          this.numOtherSystem = this.RigCertificates.otherSystem.length;
          this.numPresssureReliefValve = this.RigCertificates.presssureReliefValve.length;
          this.numPersonnelCerificates = this.RigCertificates.personnelCerificates.length;
          this.numManRidingWinch = this.RigCertificates.manRidingWinch.length;
          this.numAirHoist = this.RigCertificates.airHoist.length;
          this.numForklift = this.RigCertificates.forklift.length;
          this.numMobileCrane = this.RigCertificates.mobileCrane.length;
          this.numHydraulicWinch = this.RigCertificates.hydraulicWinch.length;

          if (this.numPersonnelCerificates > 0) {
            this.RigCertificates.personnelCerificates.forEach((certificate: { name: any; position: any; }) => {
              this.EmpCode_Name.push(certificate.name);
              this.EmpCode_Position.push(certificate.position);
            });
          }

          this.initializehseEquipmentTable()
          this.initializehoistingSystem()
          this.initializerotarySystem()
          this.initializemudCirculationSystem()
          this.initializewellControlSystem()
          this.initializepowerSystem()
          this.initializeotherSystem()
          this.initializepresssureReliefValve()
          this.initializepersonnelCerificates()
          this.initializeforklift()
          this.initializemobileCrane()
          this.initializehydraulicWinch()
          this.initializeairHoist()
          this.initializemanRidingWinch()

          this.RigCertificatesForm.patchValue({
            id: data.data.id,
            rigId: data.data.rigId,
            date: this.datePipe.transform(data.data.date, 'yyyy-MM-dd'),
            certificationLiftingGear: this.datePipe.transform(data.data.certificationLiftingGear, 'yyyy-MM-dd'),
            certificationCATIII: this.datePipe.transform(data.data.certificationCATIII, 'yyyy-MM-dd'),
            certificationCATIV: this.datePipe.transform(data.data.certificationCATIV, 'yyyy-MM-dd'),
            certificationGaugeCalibraion: this.datePipe.transform(data.data.certificationGaugeCalibraion, 'yyyy-MM-dd'),
            certificationWallThickness: this.datePipe.transform(data.data.certificationWallThickness, 'yyyy-MM-dd'),
            dueLiftingGear: this.datePipe.transform(data.data.dueLiftingGear, 'yyyy-MM-dd'),
            dueCATIII: this.datePipe.transform(data.data.dueCATIII, 'yyyy-MM-dd'),
            dueCATIV: this.datePipe.transform(data.data.dueCATIV, 'yyyy-MM-dd'),
            dueGaugeCalibraion: this.datePipe.transform(data.data.dueGaugeCalibraion, 'yyyy-MM-dd'),
            dueWallThickness: this.datePipe.transform(data.data.dueWallThickness, 'yyyy-MM-dd'),
            personnelCerificates: data.data.personnelCerificates.map((certificate: { code: any; name: any; position: any; certificateType: any; certificateDate: string | number | Date; expiryDate: string | number | Date; }) => ({
              code: certificate.code,
              name: certificate.name,
              position: certificate.position,
              certificateType: certificate.certificateType,
              certificateDate: this.datePipe.transform(certificate.certificateDate, 'yyyy-MM-dd'),
              expiryDate: this.datePipe.transform(certificate.expiryDate, 'yyyy-MM-dd'),
            })),
            hseEquipmentTable: data.data.hseEquipmentTable.map((hseEquipment: { equipmentId: any; model: any; serialNumber: any; expiryDate: string | number | Date; }) => ({
              equipmentId: hseEquipment.equipmentId,
              model: hseEquipment.model,
              serialNumber: hseEquipment.serialNumber,
              expiryDate: this.datePipe.transform(hseEquipment.expiryDate, 'yyyy-MM-dd'),
            })),
            hoistingSystem: data.data.hoistingSystem.map((hoistingSystem: { equipment: any; serialNumber: any; cocAvailabilty: boolean; catiiiCertificationDate: string | number | Date; catiiiExpiryDate: string | number | Date; cativCertificationDate: string | number | Date; cativExpiryDate: string | number | Date; }) => ({
              equipment: hoistingSystem.equipment,
              serialNumber: hoistingSystem.serialNumber,
              cocAvailabilty: hoistingSystem.cocAvailabilty,
              catiiiCertificationDate: this.datePipe.transform(hoistingSystem.catiiiCertificationDate, 'yyyy-MM-dd'),
              catiiiExpiryDate: this.datePipe.transform(hoistingSystem.catiiiExpiryDate, 'yyyy-MM-dd'),
              cativCertificationDate: this.datePipe.transform(hoistingSystem.cativCertificationDate, 'yyyy-MM-dd'),
              cativExpiryDate: this.datePipe.transform(hoistingSystem.cativExpiryDate, 'yyyy-MM-dd'),
              isNewRow: false  // Mark existing rows as not new
            })),
            rotarySystem: data.data.rotarySystem.map((rotarySystem: { equipment: any; serialNumber: any; cocAvailabilty: boolean; catiiiCertificationDate: string | number | Date; catiiiExpiryDate: string | number | Date; cativCertificationDate: string | number | Date; cativExpiryDate: string | number | Date; }) => ({
              equipment: rotarySystem.equipment,
              serialNumber: rotarySystem.serialNumber,
              cocAvailabilty: rotarySystem.cocAvailabilty,
              catiiiCertificationDate: this.datePipe.transform(rotarySystem.catiiiCertificationDate, 'yyyy-MM-dd'),
              catiiiExpiryDate: this.datePipe.transform(rotarySystem.catiiiExpiryDate, 'yyyy-MM-dd'),
              cativCertificationDate: this.datePipe.transform(rotarySystem.cativCertificationDate, 'yyyy-MM-dd'),
              cativExpiryDate: this.datePipe.transform(rotarySystem.cativExpiryDate, 'yyyy-MM-dd'),
              isNewRow: false  // Mark existing rows as not new
            })),
            mudCirculationSystem: data.data.mudCirculationSystem.map((mudCirculationSystem: { equipment: any; serialNumber: any; cocAvailabilty: boolean; catiiiCertificationDate: string | number | Date; catiiiExpiryDate: string | number | Date; cativCertificationDate: string | number | Date; cativExpiryDate: string | number | Date; }) => ({
              equipment: mudCirculationSystem.equipment,
              serialNumber: mudCirculationSystem.serialNumber,
              cocAvailabilty: mudCirculationSystem.cocAvailabilty,
              catiiiCertificationDate: this.datePipe.transform(mudCirculationSystem.catiiiCertificationDate, 'yyyy-MM-dd'),
              catiiiExpiryDate: this.datePipe.transform(mudCirculationSystem.catiiiExpiryDate, 'yyyy-MM-dd'),
              cativCertificationDate: this.datePipe.transform(mudCirculationSystem.cativCertificationDate, 'yyyy-MM-dd'),
              cativExpiryDate: this.datePipe.transform(mudCirculationSystem.cativExpiryDate, 'yyyy-MM-dd'),
              isNewRow: false  // Mark existing rows as not new
            })),
            wellControlSystem: data.data.wellControlSystem.map((wellControlSystem: { equipment: any; serialNumber: any; cocAvailabilty: boolean; catiiiCertificationDate: string | number | Date; catiiiExpiryDate: string | number | Date; cativCertificationDate: string | number | Date; cativExpiryDate: string | number | Date; }) => ({
              equipment: wellControlSystem.equipment,
              serialNumber: wellControlSystem.serialNumber,
              cocAvailabilty: wellControlSystem.cocAvailabilty,
              catiiiCertificationDate: this.datePipe.transform(wellControlSystem.catiiiCertificationDate, 'yyyy-MM-dd'),
              catiiiExpiryDate: this.datePipe.transform(wellControlSystem.catiiiExpiryDate, 'yyyy-MM-dd'),
              cativCertificationDate: this.datePipe.transform(wellControlSystem.cativCertificationDate, 'yyyy-MM-dd'),
              cativExpiryDate: this.datePipe.transform(wellControlSystem.cativExpiryDate, 'yyyy-MM-dd'),
              isNewRow: false  // Mark existing rows as not new
            })),
            powerSystem: data.data.powerSystem.map((powerSystem: { equipment: any; serialNumber: any; cocAvailabilty: boolean; catiiiCertificationDate: string | number | Date; catiiiExpiryDate: string | number | Date; cativCertificationDate: string | number | Date; cativExpiryDate: string | number | Date; }) => ({
              equipment: powerSystem.equipment,
              serialNumber: powerSystem.serialNumber,
              cocAvailabilty: powerSystem.cocAvailabilty,
              catiiiCertificationDate: this.datePipe.transform(powerSystem.catiiiCertificationDate, 'yyyy-MM-dd'),
              catiiiExpiryDate: this.datePipe.transform(powerSystem.catiiiExpiryDate, 'yyyy-MM-dd'),
              cativCertificationDate: this.datePipe.transform(powerSystem.cativCertificationDate, 'yyyy-MM-dd'),
              cativExpiryDate: this.datePipe.transform(powerSystem.cativExpiryDate, 'yyyy-MM-dd'),
              isNewRow: false  // Mark existing rows as not new
            })),
            otherSystem: data.data.otherSystem.map((otherSystem: { item: any; catiiiCertificationDate: string | number | Date; catiiiExpiryDate: string | number | Date; cativCertificationDate: string | number | Date; cativExpiryDate: string | number | Date; }) => ({
              item: otherSystem.item,
              catiiiCertificationDate: this.datePipe.transform(otherSystem.catiiiCertificationDate, 'yyyy-MM-dd'),
              catiiiExpiryDate: this.datePipe.transform(otherSystem.catiiiExpiryDate, 'yyyy-MM-dd'),
              cativCertificationDate: this.datePipe.transform(otherSystem.cativCertificationDate, 'yyyy-MM-dd'),
              cativExpiryDate: this.datePipe.transform(otherSystem.cativExpiryDate, 'yyyy-MM-dd'),
              isNewRow: false  // Mark existing rows as not new
            })),
            presssureReliefValve: data.data.presssureReliefValve.map((presssureReliefValve: { valves: any; location: any; certificationDate: string | number | Date; expiryDate: string | number | Date; }) => ({
              valves: presssureReliefValve.valves,
              location: presssureReliefValve.location,
              certificationDate: this.datePipe.transform(presssureReliefValve.certificationDate, 'yyyy-MM-dd'),
              expiryDate: this.datePipe.transform(presssureReliefValve.expiryDate, 'yyyy-MM-dd'),
            })),
            mobileCrane: data.data.mobileCrane.map((mobileCrane: { model: any; type: any; chassisNo: any; hookSerialNo: any; capacity: any; manufactureDate: string | number | Date; lastExaminationDate: string | number | Date; nextExaminationDate: string | number | Date; }) => ({
              model: mobileCrane.model,
              type: mobileCrane.type,
              chassisNo: mobileCrane.chassisNo,
              hookSerialNo: mobileCrane.hookSerialNo,
              capacity: mobileCrane.capacity,
              manufactureDate: this.datePipe.transform(mobileCrane.manufactureDate, 'yyyy-MM-dd'),
              lastExaminationDate: this.datePipe.transform(mobileCrane.lastExaminationDate, 'yyyy-MM-dd'),
              nextExaminationDate: this.datePipe.transform(mobileCrane.nextExaminationDate, 'yyyy-MM-dd'),
            })),
            forklift: data.data.forklift.map((forklift: { model: any; type: any; serialNo: any; capacity: any; lastExaminationDate: string | number | Date; nextExaminationDate: string | number | Date; }) => ({
              model: forklift.model,
              type: forklift.type,
              serialNo: forklift.serialNo,
              capacity: forklift.capacity,
              lastExaminationDate: this.datePipe.transform(forklift.lastExaminationDate, 'yyyy-MM-dd'),
              nextExaminationDate: this.datePipe.transform(forklift.nextExaminationDate, 'yyyy-MM-dd'),
            })),
            manRidingWinch: data.data.manRidingWinch.map((manRidingWinch: { serialNo: any; wireSize: any; capacity: any; wireInspectionDueDate: string | number | Date; lastMPIInspectionDate: string | number | Date; nextMPIInspectionDate: string | number | Date; nextLoadTestDate: string | number | Date; }) => ({
              serialNo: manRidingWinch.serialNo,
              wireSize: manRidingWinch.wireSize,
              capacity: manRidingWinch.capacity,
              wireInspectionDueDate: this.datePipe.transform(manRidingWinch.wireInspectionDueDate, 'yyyy-MM-dd'),
              lastMPIInspectionDate: this.datePipe.transform(manRidingWinch.lastMPIInspectionDate, 'yyyy-MM-dd'),
              nextMPIInspectionDate: this.datePipe.transform(manRidingWinch.nextMPIInspectionDate, 'yyyy-MM-dd'),
              nextLoadTestDate: this.datePipe.transform(manRidingWinch.nextLoadTestDate, 'yyyy-MM-dd'),
            })),
            airHoist: data.data.airHoist.map((airHoist: { serialNo: any; wireSize: any; capacity: any; wireInspectionDueDate: string | number | Date; lastMPIInspectionDate: string | number | Date; nextMPIInspectionDate: string | number | Date; nextLoadTestDate: string | number | Date; }) => ({
              serialNo: airHoist.serialNo,
              wireSize: airHoist.wireSize,
              capacity: airHoist.capacity,
              wireInspectionDueDate: this.datePipe.transform(airHoist.wireInspectionDueDate, 'yyyy-MM-dd'),
              lastMPIInspectionDate: this.datePipe.transform(airHoist.lastMPIInspectionDate, 'yyyy-MM-dd'),
              nextMPIInspectionDate: this.datePipe.transform(airHoist.nextMPIInspectionDate, 'yyyy-MM-dd'),
              nextLoadTestDate: this.datePipe.transform(airHoist.nextLoadTestDate, 'yyyy-MM-dd'),
            })),
            hydraulicWinch: data.data.hydraulicWinch.map((hydraulicWinch: { serialNo: any; wireSize: any; capacity: any; wireInspectionDueDate: string | number | Date; lastMPIInspectionDate: string | number | Date; nextMPIInspectionDate: string | number | Date; nextLoadTestDate: string | number | Date; }) => ({
              serialNo: hydraulicWinch.serialNo,
              wireSize: hydraulicWinch.wireSize,
              capacity: hydraulicWinch.capacity,
              wireInspectionDueDate: this.datePipe.transform(hydraulicWinch.wireInspectionDueDate, 'yyyy-MM-dd'),
              lastMPIInspectionDate: this.datePipe.transform(hydraulicWinch.lastMPIInspectionDate, 'yyyy-MM-dd'),
              nextMPIInspectionDate: this.datePipe.transform(hydraulicWinch.nextMPIInspectionDate, 'yyyy-MM-dd'),
              nextLoadTestDate: this.datePipe.transform(hydraulicWinch.nextLoadTestDate, 'yyyy-MM-dd'),
            })),
          });
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
          [],
          [
            // Validators.required
          ]
        ),
        presssureReliefValve: this.fb.array(
          [],
          [
            // Validators.required
          ]
        ),
        hseEquipmentTable: this.fb.array(
          [],
          [
            // Validators.required
          ]
        ),
        hoistingSystem: this.fb.array(
          [],
          [
            // Validators.required
          ]
        ),
        rotarySystem: this.fb.array(
          [],
          [
            // Validators.required
          ]
        ),
        mudCirculationSystem: this.fb.array(
          [],
          [
            // Validators.required
          ]
        ),
        wellControlSystem: this.fb.array(
          [],
          [
            // Validators.required
          ]
        ),
        powerSystem: this.fb.array(
          [],
          [
            // Validators.required
          ]
        ),
        otherSystem: this.fb.array(
          [],
          [
            // Validators.required
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



  initializehseEquipmentTable() {
    console.log("numhseEquipmentTable")
    console.log(this.numHSEEquipmentTable)
    for (let i = 0; i < this.numHSEEquipmentTable; i++) {
      this.addhseEquipmentTable();
    }
  }

  initializehoistingSystem() {
    console.log("numhoistingSystem")
    console.log(this.numHoistingSystem)
    for (let i = 0; i < this.numHoistingSystem; i++) {
      this.addhoistingSystem();
    }
  }

  initializerotarySystem() {
    console.log("numrotarySystem")
    console.log(this.numRotarySystem)
    for (let i = 0; i < this.numRotarySystem; i++) {
      this.addrotarySystem();
    }
  }

  initializemudCirculationSystem() {
    console.log("nummudCirculationSystem")
    console.log(this.numMudCirculationSystem)
    for (let i = 0; i < this.numMudCirculationSystem; i++) {
      this.addmudCirculationSystem();
    }
  }

  initializewellControlSystem() {
    console.log("numWellControlSystem")
    console.log(this.numWellControlSystem)
    for (let i = 0; i < this.numWellControlSystem; i++) {
      this.addwellControlSystem();
    }
  }

  initializepowerSystem() {
    console.log("numpowerSystem")
    console.log(this.numPowerSystem)
    for (let i = 0; i < this.numPowerSystem; i++) {
      this.addpowerSystem();
    }
  }

  initializeotherSystem() {
    console.log("numotherSystem")
    console.log(this.numOtherSystem)
    for (let i = 0; i < this.numOtherSystem; i++) {
      this.addotherSystem();
    }
  }

  initializepresssureReliefValve() {
    console.log("numpresssureReliefValve")
    console.log(this.numPresssureReliefValve)
    for (let i = 0; i < this.numPresssureReliefValve; i++) {
      this.addpresssureReliefValve();
    }
  }

  initializepersonnelCerificates() {
    console.log("numpersonnelCerificates")
    console.log(this.numPersonnelCerificates)
    for (let i = 0; i < this.numPersonnelCerificates; i++) {
      this.addpersonnelCerificates();
    }
  }

  initializehydraulicWinch() {
    console.log("numHydraulicWinch")
    console.log(this.numHydraulicWinch)
    for (let i = 0; i < this.numHydraulicWinch; i++) {
      this.addhydraulicWinch();
    }
  }

  initializeairHoist() {
    console.log("numAirHoist")
    console.log(this.numAirHoist)
    for (let i = 0; i < this.numAirHoist; i++) {
      this.addairHoist();
    }
  }

  initializemanRidingWinch() {
    console.log("numManRidingWinch")
    console.log(this.numManRidingWinch)
    for (let i = 0; i < this.numManRidingWinch; i++) {
      this.addmanRidingWinch();
    }
  }

  initializeforklift() {
    console.log("numForklift")
    console.log(this.numForklift)
    for (let i = 0; i < this.numForklift; i++) {
      this.addforklift();
    }
  }

  initializemobileCrane() {
    console.log("numMobileCrane")
    console.log(this.numMobileCrane)
    for (let i = 0; i < this.numMobileCrane; i++) {
      this.addmobileCrane();
    }
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

  addmobileCrane() {
    this.mobileCrane.push(this.createmobileCraneFormGroup());
    this.mobileCraneClicked = true;
  }

  addforklift() {
    this.forklift.push(this.createforkliftFormGroup());
    this.forkliftClicked = true;
  }

  addmanRidingWinch() {
    this.manRidingWinch.push(this.createmanRidingWinchFormGroup());
    this.manRidingWinchClicked = true;
  }

  addairHoist() {
    this.airHoist.push(this.createairHoistFormGroup());
    this.airHoistClicked = true;
  }

  addhydraulicWinch() {
    this.hydraulicWinch.push(this.createhydraulicWinchFormGroup());
    this.hydraulicWinchClicked = true;
  }

  addrotarySystem() {
    this.rotarySystem.push(this.createrotarySystemFormGroup('', true));
    this.RotarySystemClicked = true;
  }
  addhoistingSystem() {
    this.hoistingSystem.push(this.createhoistingSystemFormGroup('', true));
    this.HoistingSystemClicked = true;
  }

  addmudCirculationSystem() {
    this.mudCirculationSystem.push(this.createmudCirculationSystemFormGroup('', true));
    this.MudCirculationSystemClicked = true;
  }
  addwellControlSystem() {
    this.wellControlSystem.push(this.createwellControlSystemFormGroup('', true));
    this.WellControlSystemClicked = true;
  }

  addpowerSystem() {
    this.powerSystem.push(this.createpowerSystemFormGroup('', true));
    this.PowerSystemClicked = true;
  }
  addotherSystem() {
    this.otherSystem.push(this.createotherSystemFormGroup('', true));
    this.OtherSystemClicked = true;
  }

  addpersonnelCerificates() {
    this.personnelCerificates.push(this.createpersonnelCerificatesFormGroup());
    this.personnelCerificatesClicked = true;
    this.EmpCode_Name.push('');
    this.EmpCode_Position.push('');
  }
  addpresssureReliefValve() {
    this.presssureReliefValve.push(this.createpresssureReliefValveFormGroup());
    this.presssureReliefValveClicked = true;
  }

  addhseEquipmentTable() {
    this.hseEquipmentTable.push(this.createhseEquipmentTableFormGroup());
    this.hseEquipmentTableClicked = true;
  }


  submitData() {
    console.log("this.RigCertificatesForm.value")
    console.log(this.RigCertificatesForm.value)
    if (this.RigCertificatesForm.valid) {
      this.submitted = false
      this.AddService.EditRigCertificates(this.RigCertificatesId, this.RigCertificatesForm.value).subscribe({
        next: data => {
          console.log('from service')
          console.log(data)
          this.router.navigate(['Dashboard/RigCertificates']);
        },
        error: error => {
          console.log("from Error")
          console.log(error)
          console.log(this.RigCertificatesForm)
          console.log(this.RigCertificatesForm.errors)
        }
      });
      console.log(this.RigCertificatesForm);
    }
    else {
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
