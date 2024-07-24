import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AddweeklyCampInspectionServiceService } from 'Services/addweekly-camp-inspection-service.service';
import { DataService } from 'Services/data.service';
import { LoginService } from 'Services/login.service';
import { IRig } from 'SharedClasses/IRig';
import { Workbook } from 'exceljs';
import * as saveAs from 'file-saver';

@Component({
  selector: 'app-weekly-camp-inspection',
  templateUrl: './weekly-camp-inspection.component.html',
  styleUrls: ['./weekly-camp-inspection.component.scss']
})
export class WeeklyCampInspectionComponent {
  weeklyCampInspectionForm !: FormGroup;
  ErrorMessage = '';
  json_data: any[] = [];
  rigList: IRig[] = []

  UserJsonString: any
  UserJsonObj: any

  User:any;

  constructor(private loginService: LoginService, private dataService: DataService, private AddNewweeklyCampInspection: AddweeklyCampInspectionServiceService, private fb: FormBuilder, private router: Router) {
    // this.calculateDuration();


  }


  ngOnInit() {
    this.User=this.loginService.currentUser.getValue();
    this.UserJsonString = JSON.stringify(this.loginService.currentUser.getValue())
    this.UserJsonObj = JSON.parse(this.UserJsonString);
    console.log("useeeeeeeeeeeeeeeeeeeeeeeeeeeeee")
    console.log(this.UserJsonObj)

    this. weeklyCampInspectionForm  = this.fb.group(
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
          general_AreParking: this.fb.control(
            '',
            [
              Validators.required
            ]
          ),
          general_IsCampSite: this.fb.control(
            '',
            [
               Validators.required
            ]
          ),
          general_IsAllRubbish: this.fb.control(
            '',
            [
               Validators.required
            ]
          ),
          general_AreWater: this.fb.control(
            '',
            [
               Validators.required
            ]
          ),
          general_IsGenerator: this.fb.control(
            '',
            [
               Validators.required
            ]
          ),
          general_WhatIsGeneralOpinion: this.fb.control(
            '',
            [
               Validators.required
            ]
          ),
          general_AreParkingComment: this.fb.control(
            '',
            [

            ]
          ),
          general_IsCampSiteComment: this.fb.control(
            '',
            [
            ]
          ),
          general_IsAllRubbishComment: this.fb.control(
            '',
            [
            ]
          ),
          general_AreWaterComment: this.fb.control(
            '',
            [
            ]
          ),
          general_IsGeneratorComment: this.fb.control(
            '',
            [
            ]
          ),
          general_WhatIsGeneralOpinionComment: this.fb.control(
            '',
            [
            ]
          ),
          safety_DateOfLastCampfireDrill: this.fb.control(
            '',
            [
              Validators.required
            ]
          ),
          safety_DateOfLastMedicalDrill: this.fb.control(
            '',
            [
              Validators.required
            ]
          ),
          safety_AreStaffAwareOfFoodHazards: this.fb.control(
            '',
            [
              Validators.required
            ]
          ),
          safety_FirePumpInGoodCondition: this.fb.control(
            '',
            [
              Validators.required
            ]
          ),

          safety_AreThereAnyPotentialHazards: this.fb.control(
            '',
            [
              Validators.required
            ]
          ),
          safety_IsTheDiesel: this.fb.control(
            '',
            [
              Validators.required
            ]
          ),
          safety_AreThereAnyUnsafe: this.fb.control(
            '',
            [
              Validators.required
            ]
          ),
          safety_IsCampEarthing: this.fb.control(
            '',
            [
              Validators.required
            ]
          ),
          safety_AreFireEmergency: this.fb.control(
            '',
            [
              Validators.required
            ]
          ),
          safety_DateOfLastCampfireDrillComment: this.fb.control(
            '',
            [
            ]
          ),

          safety_DateOfLastMedicalDrillComment: this.fb.control(
            '',
            [
            ]
          ),
          safety_AreStaffAwareOfFoodHazardsComment: this.fb.control(
            '',
            [
            ]
          ),
          safety_FirePumpInGoodConditionComment: this.fb.control(
            '',
            [
            ]
          ),

          safety_AreThereAnyPotentialHazardsComment: this.fb.control(
            '',
            [
            ]
          ),
          safety_IsTheDieselComment: this.fb.control(
            '',
            [
            ]
          ),
          safety_AreThereAnyUnsafeComment: this.fb.control(
            '',
            [
            ]
          ),

          safety_IsCampEarthingComment: this.fb.control(
            '',
            [
            ]
          ),
          safety_AreFireEmergencyComment: this.fb.control(
            '',
            [
            ]
          ),
          foodStorage_WhatIsTheGeneralAppearance: this.fb.control(
            '',
            [
              Validators.required
            ]

          ),
          foodStorage_IsFoodProperlyProtectedFromRisk: this.fb.control(
            '',
            [
              Validators.required
            ]
          ),
          foodStorage_IsThereEnoughDryFood: this.fb.control(
            '',
            [
              Validators.required,
            ]
          ),
          foodStorage_FrozenStoredFood: this.fb.control(
            '',
            [
              Validators.required,
            ]
          ),
          foodStorage_AreDryFoodsProperlyStored: this.fb.control(
            '',
            [
              Validators.required,
            ]
          ),
          foodStorage_AreFrozenFoods: this.fb.control(
            '',
             [
              Validators.required
             ]
          ),
          foodStorage_IsFoodProperlyStored: this.fb.control(
            '',
            [
              Validators.required
            ]
          ),
          foodStorage_AreChillerAndFreezerClean: this.fb.control(
            '',
            [
              Validators.required
            ]
          ),
          foodStorage_WhatIsTheGeneralAppearanceComment: this.fb.control(
            '',
            [
            ]
          ),
          foodStorage_IsFoodProperlyProtectedFromRiskComment: this.fb.control(
            '',
            [
            ]
          ),
          foodStorage_AreDryFoodsProperlyStoredComment: this.fb.control(
            '',
            [
            ]
          ),
          foodStorage_IsThereEnoughDryFoodComment: this.fb.control(
            '',
            [
            ]
          ),
          foodStorage_FrozenStoredFoodComment: this.fb.control(
            '',
            [
            ]
          ),
          foodStorage_AreFrozenFoodsComment: this.fb.control(
            '',
            [
            ]
          ),
          foodStorage_IsFoodProperlyStoredComment: this.fb.control(
            '',
            [
            ]
          ),
          foodStorage_AreChillerAndFreezerCleanComment: this.fb.control(
            '',
            [
            ]
          ),
          galley_IsThereWnyWaterLeaks: this.fb.control(
            '',
            [
              Validators.required
            ]
          ),
          galley_AreAllAppliancesWorking: this.fb.control(
            '',
            [
              Validators.required
            ]
          ),
          galley_WhenWasExhaustFans: this.fb.control(
            '',
            [
              Validators.required
            ]
          ),
          galley_AreDishesAndUtensilsClean: this.fb.control(
            '',
            [
              Validators.required
            ]
          ),
          galley_WhatTheConditionOfTheChipPanAndfoodOil: this.fb.control(
            '',
            [
              Validators.required
            ]
          ),
          galley_IsTheGalleyAreaClean: this.fb.control(
            '',
            [
              Validators.required
            ]
          ),
          galley_IsThereWnyWaterLeaksComment: this.fb.control(
            '',
            [
            ]
          ),
          galley_AreAllAppliancesWorkingComment: this.fb.control(
            '',
            [
            ]
          ),
          galley_WhenWasExhaustFansComment: this.fb.control(
            '',
            [
            ]
          ),
          galley_AreDishesAndUtensilsCleanComment: this.fb.control(
            '',
            [
            ]
          ),
          galley_WhatTheConditionOfTheChipPanAndfoodOilComment: this.fb.control(
            '',
            [
            ]
          ),
          galley_IsTheGalleyAreaCleanComment: this.fb.control(
            '',
            [
            ]
          ),
          messHall_AreWashHandBasins: this.fb.control(
            '',
            [
              Validators.required
            ]
          ),
          messHall_RegistersForChangingFoodOil: this.fb.control(
            '',
            [
              Validators.required
            ]
          ),
          messHall_AreAllAppliancesWorking: this.fb.control(
            '',
            [
              Validators.required
            ]
          ),
          messHall_AreTablesInGoodWorkingCondition: this.fb.control(
            '',
            [
               Validators.required
            ]
          ),
          messHall_AreFlyKillersWorking: this.fb.control(
            '',
            [
               Validators.required
            ]
          ),
          messHall_AllElectricalCables: this.fb.control(
            '',
            [
               Validators.required
            ]
          ),
          messHall_IsMessHallClean: this.fb.control(
            '',
            [
               Validators.required
            ]
          ),
          messHall_AreWashHandBasinsComment: this.fb.control(
            '',
            [
            ]
          ),
          messHall_RegistersForChangingFoodOilComment: this.fb.control(
            '',
            [
            ]
          ),
          messHall_AreAllAppliancesWorkingComment: this.fb.control(
            '',
            [

            ]
          ),
          messHall_AllElectricalCablesComment: this.fb.control(
            '',
            [
            ]
          ),
          messHall_AreTablesInGoodWorkingConditionComment: this.fb.control(
            '',
            [
            ]
          ),
          messHall_AreFlyKillersWorkingComment: this.fb.control(
            '',
            [
            ]
          ),
          messHall_IsMessHallCleanComment: this.fb.control(
            '',
            [
            ]
          ),
          accomodations_LockersOfBathroomsAreInstalledWell: this.fb.control(
            '',
            [
              Validators.required
            ]
          ),
          accomodations_TypesOfCleaningMaterialsUsed: this.fb.control(
            '',
            [
              Validators.required
            ]
          ),
          accomodations_AnyLackInCleaning: this.fb.control(
            '',
            [
              Validators.required
            ]
          ),
          accomodations_AreDoorHingesAndClosures: this.fb.control(
            '',
            [
              Validators.required
            ]
          ),
          accomodations_LockersOfBathroomsAreInstalledWellComment: this.fb.control(
            '',
            [
            ]
          ),
          accomodations_TypesOfCleaningMaterialsUsedComment: this.fb.control(
            '',
            [
            ]
          ),

          accomodations_AnyLackInCleaningComment: this.fb.control(
            '',
            [
            ]
          ),
          accomodations_AreDoorHingesAndClosuresComment: this.fb.control(
            '',
            [
            ]
          ),
          clinic_IsTheClinicCleanAndTidy: this.fb.control(
            '',
            [
              Validators.required
            ]
          ),
          clinic_RelevantSdsPresent: this.fb.control(
            '',
            [
              Validators.required
            ]
          ),
          clinic_IsMedicalApparatus: this.fb.control(
            '',
            [
              Validators.required
            ]
          ),
          clinic_IsMedicalStockMaintained: this.fb.control(
            '',
            [
              Validators.required,
            ]
          ),

          clinic_IsMedicalTreatment: this.fb.control(
            '',
            [
              Validators.required,
            ]
          ),
          clinic_IsTheClinicCleanAndTidyComment: this.fb.control(
            '',
            [
            ]
          ),
          clinic_RelevantSdsPresentComment: this.fb.control(
            '',
            [
            ]
          ),

          clinic_IsMedicalApparatusComment: this.fb.control(
            '',
            [
            ]
          ),
          clinic_IsMedicalStockMaintainedComment: this.fb.control(
            '',
            [
            ]
          ),
          clinic_IsMedicalTreatmentComment: this.fb.control(
            '',
            [
            ]
          ),

          laundry_IsLaundryAleanAndTidy: this.fb.control(
            '',
            [
              Validators.required,
            ]
          ),
          laundry_TypesOfChemicalsUsedAreRelevant: this.fb.control(
            '',
            [
              Validators.required,
            ]
          ),
          laundry_AreAllAppliancesSafety: this.fb.control(
            '',
            [
              Validators.required
            ]

          ),
          laundry_AreAllAppliancesWorking: this.fb.control(
            '',
            [
              Validators.required
            ]
          ),
          laundry_IsLaundryAleanAndTidyComment: this.fb.control(
            '',
            [
            ]
          ),
          laundry_TypesOfChemicalsUsedAreRelevantComment: this.fb.control(
            '',
            [
            ]
          ),
          laundry_AreAllAppliancesSafetyComment: this.fb.control(
            '',
             [
             ]
          ),
          laundry_AreAllAppliancesWorkingComment: this.fb.control(
            '',
            [
            ]
          ),
          generalBathRooms_AreAllElectricalFixtures: this.fb.control(
            '',
            [
              Validators.required
            ]
          ),
          generalBathRooms_AreAllDoorsInGoodWorkingOrder: this.fb.control(
            '',
            [
              Validators.required,
            ]
          ),
          generalBathRooms_AnyLeaksInPiping: this.fb.control(
            '',
            [
              Validators.required,

            ]
          ),
          generalBathRooms_IsTheAreaCleanAndTidy: this.fb.control(
            '',
            [
              Validators.required,
            ]
          ),
          generalBathRooms_AreAllElectricalFixturesComment: this.fb.control(
            '',
            [
            ]
          ),
          generalBathRooms_AreAllDoorsInGoodWorkingOrderComment: this.fb.control(
            '',
            [
            ]
          ),
          generalBathRooms_AnyLeaksInPipingComment: this.fb.control(
            '',
            [
            ]
          ),
          generalBathRooms_IsTheAreaCleanAndTidyComment: this.fb.control(
            '',
            [
            ]
          ),
          waterTanks_AreWaterTanksHatchesClean: this.fb.control(
            '',
            [
              Validators.required
            ]
          ),
          waterTanks_AnyWaterLeaks: this.fb.control(
            '',
            [
              Validators.required
            ]
          ),
          waterTanks_WhatIsTheDateOfLastWaterSample: this.fb.control(
            '',
            [
              Validators.required
            ]
          ),
          waterTanks_IsAreaCleanAndTidy: this.fb.control(
            '',
            [
              Validators.required
            ]
          ),
          waterTanks_AreWaterTanksHatchesCleanComment: this.fb.control(
            '',
            [
            ]
          ),
          waterTanks_AnyWaterLeaksComment: this.fb.control(
            '',
            [
            ]
          ),
          waterTanks_WhatIsTheDateOfLastWaterSampleComment: this.fb.control(
            '',
            [
            ]
          ),
          waterTanks_IsAreaCleanAndTidyComment: this.fb.control(
            '',
            [
            ]
          ),

          userID: this.fb.control(this.User.ID, [Validators.required]),
        }
      ),
      this.dataService.GetWeeklyCampInspections(this.User.ID,this.User.Role).subscribe({
        next: data => this.json_data = data.data,
        error: err => this.ErrorMessage = err
      }),

      this.dataService.GetRig().subscribe({
        next: data => this.rigList = data.data,
        error: err => this.ErrorMessage = err
      })
  }


get id() {
    return this. weeklyCampInspectionForm .get('id');
  }
  get rigId() {
    return this. weeklyCampInspectionForm .get('rigId');
  }
  get date() {
    return this. weeklyCampInspectionForm .get('date');
  }
  get general_AreParking() {
    return this. weeklyCampInspectionForm .get('general_AreParking');
  }

  get general_IsCampSite() {
    return this. weeklyCampInspectionForm .get('general_IsCampSite');
  }
  get general_IsAllRubbish() {
    return this. weeklyCampInspectionForm .get('general_IsAllRubbish');
  }
  get general_AreWater() {
    return this. weeklyCampInspectionForm .get('general_AreWater');
  }
  get general_IsGenerator() {
    return this. weeklyCampInspectionForm .get('general_IsGenerator');
  }
  get general_WhatIsGeneralOpinion() {
    return this. weeklyCampInspectionForm .get('general_WhatIsGeneralOpinion');
  }
  get general_AreParkingComment() {
    return this. weeklyCampInspectionForm .get('general_AreParkingComment');
  }
  get general_IsCampSiteComment() {
    return this. weeklyCampInspectionForm .get('general_IsCampSiteComment');
  }

  get general_IsAllRubbishComment() {
    return this. weeklyCampInspectionForm .get('general_IsAllRubbishComment');
  }
  get general_AreWaterComment() {
    return this. weeklyCampInspectionForm .get('general_AreWaterComment');
  }
  get general_IsGeneratorComment() {
    return this. weeklyCampInspectionForm .get('general_IsGeneratorComment');
  }

  get general_WhatIsGeneralOpinionComment() {
    return this. weeklyCampInspectionForm .get('general_WhatIsGeneralOpinionComment');
  }
  get safety_DateOfLastCampfireDrill() {
    return this. weeklyCampInspectionForm .get('safety_DateOfLastCampfireDrill');
  }
  get safety_DateOfLastMedicalDrill() {
    return this. weeklyCampInspectionForm .get('safety_DateOfLastMedicalDrill');
  }

  get safety_AreStaffAwareOfFoodHazards() {
    return this. weeklyCampInspectionForm .get('safety_AreStaffAwareOfFoodHazards');
  }
  get safety_FirePumpInGoodCondition() {
    return this. weeklyCampInspectionForm .get('safety_FirePumpInGoodCondition');
  }
  get safety_AreThereAnyPotentialHazards() {
    return this. weeklyCampInspectionForm .get('safety_AreThereAnyPotentialHazards');
  }

  get safety_IsTheDiesel() {
    return this. weeklyCampInspectionForm .get('safety_IsTheDiesel');
  }
  get safety_AreThereAnyUnsafe() {
    return this. weeklyCampInspectionForm .get('safety_AreThereAnyUnsafe');
  }
  get safety_IsCampEarthing() {
    return this. weeklyCampInspectionForm .get('safety_IsCampEarthing');
  }

  get safety_AreFireEmergency() {
    return this. weeklyCampInspectionForm .get('safety_AreFireEmergency');
  }
  get safety_DateOfLastCampfireDrillComment() {
    return this. weeklyCampInspectionForm .get('safety_DateOfLastCampfireDrillComment');
  }
  get safety_DateOfLastMedicalDrillComment() {
    return this. weeklyCampInspectionForm .get('safety_DateOfLastMedicalDrillComment');
  }

  get safety_AreStaffAwareOfFoodHazardsComment() {
    return this. weeklyCampInspectionForm .get('safety_AreStaffAwareOfFoodHazardsComment');
  }
  get safety_FirePumpInGoodConditionComment() {
    return this. weeklyCampInspectionForm .get('safety_FirePumpInGoodConditionComment');
  }
  get safety_AreThereAnyPotentialHazardsComment() {
    return this. weeklyCampInspectionForm .get('safety_AreThereAnyPotentialHazardsComment');
  }

  get safety_IsTheDieselComment() {
    return this. weeklyCampInspectionForm .get('safety_IsTheDieselComment');
  }
  get safety_AreThereAnyUnsafeComment() {
    return this. weeklyCampInspectionForm .get('safety_AreThereAnyUnsafeComment');
  }
  get safety_IsCampEarthingComment() {
    return this. weeklyCampInspectionForm .get('safety_IsCampEarthingComment');
  }

  get safety_AreFireEmergencyComment() {
    return this. weeklyCampInspectionForm .get('safety_AreFireEmergencyComment');
  }
  get foodStorage_WhatIsTheGeneralAppearance() {
    return this. weeklyCampInspectionForm .get('foodStorage_WhatIsTheGeneralAppearance');
  }
  get foodStorage_IsFoodProperlyProtectedFromRisk() {
    return this. weeklyCampInspectionForm .get('foodStorage_IsFoodProperlyProtectedFromRisk');
  }
  get foodStorage_IsThereEnoughDryFood() {
    return this. weeklyCampInspectionForm .get('foodStorage_IsThereEnoughDryFood');
  }
  get foodStorage_FrozenStoredFood() {
    return this. weeklyCampInspectionForm .get('foodStorage_FrozenStoredFood');
  }
  get foodStorage_AreDryFoodsProperlyStoredComment() {
    return this. weeklyCampInspectionForm .get('foodStorage_AreDryFoodsProperlyStoredComment');
  }
  get foodStorage_AreDryFoodsProperlyStored() {
    return this. weeklyCampInspectionForm .get('foodStorage_AreDryFoodsProperlyStored');
  }
  get foodStorage_AreFrozenFoods() {
    return this. weeklyCampInspectionForm .get('foodStorage_AreFrozenFoods');
  }
  get foodStorage_IsFoodProperlyStored() {
    return this. weeklyCampInspectionForm .get('foodStorage_IsFoodProperlyStored');
  }
  get foodStorage_AreChillerAndFreezerClean() {
    return this. weeklyCampInspectionForm .get('foodStorage_AreChillerAndFreezerClean');
  }

   get foodStorage_WhatIsTheGeneralAppearanceComment() {
    return this. weeklyCampInspectionForm .get('foodStorage_WhatIsTheGeneralAppearanceComment');
  }

  get foodStorage_IsFoodProperlyProtectedFromRiskComment() {
    return this. weeklyCampInspectionForm .get('foodStorage_IsFoodProperlyProtectedFromRiskComment');
  }
  get foodStorage_IsThereEnoughDryFoodComment() {
    return this. weeklyCampInspectionForm .get('foodStorage_IsThereEnoughDryFoodComment');
  }
  get foodStorage_FrozenStoredFoodComment() {
    return this. weeklyCampInspectionForm .get('foodStorage_FrozenStoredFoodComment');
  }
  get foodStorage_AreFrozenFoodsComment() {
    return this. weeklyCampInspectionForm .get('foodStorage_AreFrozenFoodsComment');
  }
  get foodStorage_IsFoodProperlyStoredComment() {
    return this. weeklyCampInspectionForm .get('foodStorage_IsFoodProperlyStoredComment');
  }
  get foodStorage_AreChillerAndFreezerCleanComment() {
    return this. weeklyCampInspectionForm .get('foodStorage_AreChillerAndFreezerCleanComment');
  }
  get galley_IsThereWnyWaterLeaks() {
    return this. weeklyCampInspectionForm .get('galley_IsThereWnyWaterLeaks');
  }
  get galley_AreAllAppliancesWorking() {
    return this. weeklyCampInspectionForm .get('galley_AreAllAppliancesWorking');
  }
  get galley_WhenWasExhaustFans() {
    return this. weeklyCampInspectionForm .get('galley_WhenWasExhaustFans');
  }
  get galley_AreDishesAndUtensilsClean() {
    return this. weeklyCampInspectionForm .get('galley_AreDishesAndUtensilsClean');
  }
   get galley_WhatTheConditionOfTheChipPanAndfoodOil() {
    return this. weeklyCampInspectionForm .get('galley_WhatTheConditionOfTheChipPanAndfoodOil');
  }
  get galley_IsTheGalleyAreaClean() {
    return this. weeklyCampInspectionForm .get('galley_IsTheGalleyAreaClean');
  }
  get galley_IsThereWnyWaterLeaksComment() {
    return this. weeklyCampInspectionForm .get('galley_IsThereWnyWaterLeaksComment');
  }
  get galley_AreAllAppliancesWorkingComment() {
    return this. weeklyCampInspectionForm .get('galley_AreAllAppliancesWorkingComment');
  }
  get galley_WhenWasExhaustFansComment() {
    return this. weeklyCampInspectionForm .get('galley_WhenWasExhaustFansComment');
  }

  get galley_AreDishesAndUtensilsCleanComment() {
    return this. weeklyCampInspectionForm .get('galley_AreDishesAndUtensilsCleanComment');
  }
  get galley_WhatTheConditionOfTheChipPanAndfoodOilComment() {
    return this. weeklyCampInspectionForm .get('galley_WhatTheConditionOfTheChipPanAndfoodOilComment');
  }
  get galley_IsTheGalleyAreaCleanComment() {
    return this. weeklyCampInspectionForm .get('galley_IsTheGalleyAreaCleanComment');
  }
  get messHall_AreWashHandBasins() {
    return this. weeklyCampInspectionForm .get('messHall_AreWashHandBasins');
  }
  get messHall_RegistersForChangingFoodOil() {
    return this. weeklyCampInspectionForm .get('messHall_RegistersForChangingFoodOil');
  }
  get messHall_AreAllAppliancesWorking() {
    return this. weeklyCampInspectionForm .get('messHall_AreAllAppliancesWorking');
  }
  get messHall_AreTablesInGoodWorkingCondition() {
    return this. weeklyCampInspectionForm .get('messHall_AreTablesInGoodWorkingCondition');
  }
  get messHall_AreFlyKillersWorking() {
    return this. weeklyCampInspectionForm .get('messHall_AreFlyKillersWorking');
  }
  get messHall_IsMessHallClean() {
    return this. weeklyCampInspectionForm .get('messHall_IsMessHallClean');
  }
  get messHall_AllElectricalCables() {
    return this. weeklyCampInspectionForm .get('messHall_AllElectricalCables');
  }
  get messHall_AllElectricalCablesComment() {
    return this. weeklyCampInspectionForm .get('messHall_AllElectricalCablesComment');
  }
  get messHall_AreWashHandBasinsComment() {
    return this. weeklyCampInspectionForm .get('messHall_AreWashHandBasinsComment');
  }
  get messHall_RegistersForChangingFoodOilComment() {
    return this. weeklyCampInspectionForm .get('messHall_RegistersForChangingFoodOilComment');
  }
  get messHall_AreAllAppliancesWorkingComment() {
    return this. weeklyCampInspectionForm .get('messHall_AreAllAppliancesWorkingComment');
  }
  get messHall_AreTablesInGoodWorkingConditionComment() {
    return this. weeklyCampInspectionForm .get('messHall_AreTablesInGoodWorkingConditionComment');
  }
  get messHall_AreFlyKillersWorkingComment() {
    return this. weeklyCampInspectionForm .get('messHall_AreFlyKillersWorkingComment');
  }
  get messHall_IsMessHallCleanComment() {
    return this. weeklyCampInspectionForm .get('messHall_IsMessHallCleanComment');
  }
   get accomodations_LockersOfBathroomsAreInstalledWell() {
    return this. weeklyCampInspectionForm .get('accomodations_LockersOfBathroomsAreInstalledWell');
  }
  get accomodations_TypesOfCleaningMaterialsUsed() {
    return this. weeklyCampInspectionForm .get('accomodations_TypesOfCleaningMaterialsUsed');
  }
  get accomodations_AnyLackInCleaning() {
    return this. weeklyCampInspectionForm .get('accomodations_AnyLackInCleaning');
  }
  get accomodations_AreDoorHingesAndClosures() {
    return this. weeklyCampInspectionForm .get('accomodations_AreDoorHingesAndClosures');
  }
  get accomodations_LockersOfBathroomsAreInstalledWellComment() {
    return this. weeklyCampInspectionForm .get('accomodations_LockersOfBathroomsAreInstalledWellComment');
  }
  get accomodations_TypesOfCleaningMaterialsUsedComment() {
    return this. weeklyCampInspectionForm .get('accomodations_TypesOfCleaningMaterialsUsedComment');
  }
  get accomodations_AnyLackInCleaningComment() {
    return this. weeklyCampInspectionForm .get('accomodations_AnyLackInCleaningComment');
  }
  get accomodations_AreDoorHingesAndClosuresComment() {
    return this. weeklyCampInspectionForm .get('accomodations_AreDoorHingesAndClosuresComment');
  }
  get clinic_IsTheClinicCleanAndTidy() {
    return this. weeklyCampInspectionForm .get('clinic_IsTheClinicCleanAndTidy');
  }
  get clinic_RelevantSdsPresent() {
    return this. weeklyCampInspectionForm .get('clinic_RelevantSdsPresent');
  }
  get clinic_IsMedicalApparatus() {
    return this. weeklyCampInspectionForm .get('clinic_IsMedicalApparatus');
  }
   get clinic_IsMedicalStockMaintained() {
    return this. weeklyCampInspectionForm .get('clinic_IsMedicalStockMaintained');
  }
  get clinic_IsMedicalTreatment() {
    return this. weeklyCampInspectionForm .get('clinic_IsMedicalTreatment');
  }
  get clinic_IsTheClinicCleanAndTidyComment() {
    return this. weeklyCampInspectionForm .get('clinic_IsTheClinicCleanAndTidyComment');
  }
  get clinic_RelevantSdsPresentComment() {
    return this. weeklyCampInspectionForm .get('clinic_RelevantSdsPresentComment');
  }
  get clinic_IsMedicalApparatusComment() {
    return this. weeklyCampInspectionForm .get('clinic_IsMedicalApparatusComment');
  }
  get clinic_IsMedicalStockMaintainedComment() {
    return this. weeklyCampInspectionForm .get('clinic_IsMedicalStockMaintainedComment');
  }
  get clinic_IsMedicalTreatmentComment() {
    return this. weeklyCampInspectionForm .get('clinic_IsMedicalTreatmentComment');
  }
  get laundry_IsLaundryAleanAndTidy() {
    return this. weeklyCampInspectionForm .get('laundry_IsLaundryAleanAndTidy');
  }
  get laundry_TypesOfChemicalsUsedAreRelevant() {
    return this. weeklyCampInspectionForm .get('laundry_TypesOfChemicalsUsedAreRelevant');
  }
  get laundry_AreAllAppliancesSafety() {
    return this. weeklyCampInspectionForm .get('laundry_AreAllAppliancesSafety');
  }
   get laundry_AreAllAppliancesWorking() {
    return this. weeklyCampInspectionForm .get('laundry_AreAllAppliancesWorking');
  }
  get laundry_IsLaundryAleanAndTidyComment() {
    return this. weeklyCampInspectionForm .get('laundry_IsLaundryAleanAndTidyComment');
  }
  get laundry_TypesOfChemicalsUsedAreRelevantComment() {
    return this. weeklyCampInspectionForm .get('laundry_TypesOfChemicalsUsedAreRelevantComment');
  }
  get laundry_AreAllAppliancesSafetyComment() {
    return this. weeklyCampInspectionForm .get('laundry_AreAllAppliancesSafetyComment');
  }
  get laundry_AreAllAppliancesWorkingComment() {
    return this. weeklyCampInspectionForm .get('laundry_AreAllAppliancesWorkingComment');
  }
  get generalBathRooms_AreAllElectricalFixtures() {
    return this. weeklyCampInspectionForm .get('generalBathRooms_AreAllElectricalFixtures');
  }
  get generalBathRooms_AreAllDoorsInGoodWorkingOrder() {
    return this. weeklyCampInspectionForm .get('generalBathRooms_AreAllDoorsInGoodWorkingOrder');
  }
  get generalBathRooms_AnyLeaksInPiping() {
    return this. weeklyCampInspectionForm .get('generalBathRooms_AnyLeaksInPiping');
  }
  get generalBathRooms_IsTheAreaCleanAndTidy() {
    return this. weeklyCampInspectionForm .get('generalBathRooms_IsTheAreaCleanAndTidy');
  }
  get generalBathRooms_AreAllElectricalFixturesComment() {
    return this. weeklyCampInspectionForm .get('generalBathRooms_AreAllElectricalFixturesComment');
  }
   get generalBathRooms_AreAllDoorsInGoodWorkingOrderComment() {
    return this. weeklyCampInspectionForm .get('generalBathRooms_AreAllDoorsInGoodWorkingOrderComment');
  }
  get generalBathRooms_AnyLeaksInPipingComment() {
    return this. weeklyCampInspectionForm .get('generalBathRooms_AnyLeaksInPipingComment');
  }
  get generalBathRooms_IsTheAreaCleanAndTidyComment() {
    return this. weeklyCampInspectionForm .get('generalBathRooms_IsTheAreaCleanAndTidyComment');
  }
  get waterTanks_AreWaterTanksHatchesClean() {
    return this. weeklyCampInspectionForm .get('waterTanks_AreWaterTanksHatchesClean');
  }
  get waterTanks_AnyWaterLeaks() {
    return this. weeklyCampInspectionForm .get('waterTanks_AnyWaterLeaks');
  }
  get waterTanks_WhatIsTheDateOfLastWaterSample() {
    return this. weeklyCampInspectionForm .get('waterTanks_WhatIsTheDateOfLastWaterSample');
  }
  get waterTanks_IsAreaCleanAndTidy() {
    return this. weeklyCampInspectionForm .get('waterTanks_IsAreaCleanAndTidy');
  }
  get waterTanks_AreWaterTanksHatchesCleanComment() {
    return this. weeklyCampInspectionForm .get('waterTanks_AreWaterTanksHatchesCleanComment');
  }
  get waterTanks_AnyWaterLeaksComment() {
    return this. weeklyCampInspectionForm .get('waterTanks_AnyWaterLeaksComment');
  }
  get waterTanks_WhatIsTheDateOfLastWaterSampleComment() {
    return this. weeklyCampInspectionForm .get('waterTanks_WhatIsTheDateOfLastWaterSampleComment');
  }
   get waterTanks_IsAreaCleanAndTidyComment() {
    return this. weeklyCampInspectionForm .get('waterTanks_IsAreaCleanAndTidyComment');
  }



  submitData() {

     if (this. weeklyCampInspectionForm .valid) {

      const Formdata=new FormData()
     console.log("fforrrrrrrmmmmmmmmm",Formdata)

      Formdata.append('rigId', this.rigId?.value);
      Formdata.append('date', this.date?.value);
                   // GENERAL
      Formdata.append('general_AreParking', this.general_AreParking?.value);
      Formdata.append('general_IsCampSite', this.general_IsCampSite?.value);

      Formdata.append('general_IsAllRubbish', this.general_IsAllRubbish?.value);
      Formdata.append('general_AreWater', this.general_AreWater?.value);
      Formdata.append('general_IsGenerator', this.general_IsGenerator?.value);

      Formdata.append('general_WhatIsGeneralOpinion', this.general_WhatIsGeneralOpinion?.value);
      Formdata.append('general_AreParkingComment', this.general_AreParkingComment?.value);
      Formdata.append('general_IsCampSiteComment', this.general_IsCampSiteComment?.value);

      Formdata.append('general_IsAllRubbishComment', this.general_IsAllRubbishComment?.value);
      Formdata.append('general_AreWaterComment', this.general_AreWaterComment?.value);
      Formdata.append('general_IsGeneratorComment', this.general_IsGeneratorComment?.value);
      Formdata.append('general_WhatIsGeneralOpinionComment', this.general_WhatIsGeneralOpinionComment?.value);

         // *************SAFETY**************************
      Formdata.append('safety_DateOfLastCampfireDrill', this.safety_DateOfLastCampfireDrill?.value);
      Formdata.append('safety_DateOfLastMedicalDrill', this.safety_DateOfLastMedicalDrill?.value);

      Formdata.append('safety_AreStaffAwareOfFoodHazards', this.safety_AreStaffAwareOfFoodHazards?.value);
      Formdata.append('safety_FirePumpInGoodCondition', this.safety_FirePumpInGoodCondition?.value);
      Formdata.append('safety_AreThereAnyPotentialHazards', this.safety_AreThereAnyPotentialHazards?.value);

      Formdata.append('safety_IsTheDiesel', this.safety_IsTheDiesel?.value);
      Formdata.append('safety_AreThereAnyUnsafe', this.safety_AreThereAnyUnsafe?.value);
      Formdata.append('safety_IsCampEarthing', this.safety_IsCampEarthing?.value);

      Formdata.append('safety_AreFireEmergency', this.safety_AreFireEmergency?.value);
      Formdata.append('safety_DateOfLastCampfireDrillComment', this.safety_DateOfLastCampfireDrillComment?.value);
      Formdata.append('safety_DateOfLastMedicalDrillComment', this.safety_DateOfLastMedicalDrillComment?.value);

      Formdata.append('safety_AreStaffAwareOfFoodHazardsComment', this.safety_AreStaffAwareOfFoodHazardsComment?.value);
      Formdata.append('safety_FirePumpInGoodConditionComment', this.safety_FirePumpInGoodConditionComment?.value);
      Formdata.append('safety_AreThereAnyPotentialHazardsComment', this.safety_AreThereAnyPotentialHazardsComment?.value);

      Formdata.append('safety_IsTheDieselComment', this.safety_IsTheDieselComment?.value);
      Formdata.append('safety_AreThereAnyUnsafeComment', this.safety_AreThereAnyUnsafeComment?.value);
      Formdata.append('safety_IsCampEarthingComment', this.safety_IsCampEarthingComment?.value);

      // ***************************** FOODSTORAGE ***************************
      Formdata.append('foodStorage_WhatIsTheGeneralAppearance', this.foodStorage_WhatIsTheGeneralAppearance?.value);
      Formdata.append('foodStorage_IsFoodProperlyProtectedFromRisk', this.foodStorage_IsFoodProperlyProtectedFromRisk?.value);

      Formdata.append('foodStorage_IsThereEnoughDryFood', this.foodStorage_IsThereEnoughDryFood?.value);
      Formdata.append('foodStorage_FrozenStoredFood', this.foodStorage_FrozenStoredFood?.value);
      Formdata.append('foodStorage_AreFrozenFoods', this.foodStorage_AreFrozenFoods?.value);

      Formdata.append('foodStorage_IsFoodProperlyStored', this.foodStorage_IsFoodProperlyStored?.value);
      Formdata.append('foodStorage_AreChillerAndFreezerClean', this.foodStorage_AreChillerAndFreezerClean?.value);
      Formdata.append('foodStorage_WhatIsTheGeneralAppearanceComment', this.foodStorage_WhatIsTheGeneralAppearanceComment?.value);

      Formdata.append('foodStorage_IsFoodProperlyProtectedFromRiskComment', this.foodStorage_IsFoodProperlyProtectedFromRiskComment?.value);
      Formdata.append('foodStorage_IsThereEnoughDryFoodComment', this.foodStorage_IsThereEnoughDryFoodComment?.value);
      Formdata.append('foodStorage_FrozenStoredFoodComment', this.foodStorage_FrozenStoredFoodComment?.value);
      Formdata.append('foodStorage_AreFrozenFoodsComment', this.foodStorage_AreFrozenFoodsComment?.value);

      Formdata.append('foodStorage_IsFoodProperlyStoredComment', this.foodStorage_IsFoodProperlyStoredComment?.value);
      Formdata.append('foodStorage_AreChillerAndFreezerCleanComment', this.foodStorage_AreChillerAndFreezerCleanComment?.value);

    //  ****************************** GALLEY ************************************
    Formdata.append('galley_IsThereWnyWaterLeaks', this.galley_IsThereWnyWaterLeaks?.value);
    Formdata.append('galley_AreAllAppliancesWorking', this.galley_AreAllAppliancesWorking?.value);
    Formdata.append('galley_WhenWasExhaustFans', this.galley_WhenWasExhaustFans?.value);
    Formdata.append('galley_AreDishesAndUtensilsClean', this.galley_AreDishesAndUtensilsClean?.value);
    Formdata.append('galley_WhatTheConditionOfTheChipPanAndfoodOil', this.galley_WhatTheConditionOfTheChipPanAndfoodOil?.value);
    Formdata.append('galley_IsTheGalleyAreaClean', this.galley_IsTheGalleyAreaClean?.value);
    Formdata.append('galley_IsThereWnyWaterLeaksComment', this.galley_IsThereWnyWaterLeaksComment?.value);
    Formdata.append('galley_AreAllAppliancesWorkingComment', this.galley_AreAllAppliancesWorkingComment?.value);
    Formdata.append('galley_WhenWasExhaustFansComment', this.galley_WhenWasExhaustFansComment?.value);
    Formdata.append('galley_AreDishesAndUtensilsCleanComment', this.galley_AreDishesAndUtensilsCleanComment?.value);
    Formdata.append('galley_WhatTheConditionOfTheChipPanAndfoodOilComment', this.galley_WhatTheConditionOfTheChipPanAndfoodOilComment?.value);
    Formdata.append('galley_IsTheGalleyAreaCleanComment', this.galley_IsTheGalleyAreaCleanComment?.value);


      Formdata.append('foodStorage_WhatIsTheGeneralAppearance', this.foodStorage_WhatIsTheGeneralAppearance?.value);
      Formdata.append('foodStorage_IsFoodProperlyProtectedFromRisk', this.foodStorage_IsFoodProperlyProtectedFromRisk?.value);

      Formdata.append('foodStorage_IsThereEnoughDryFood', this.foodStorage_IsThereEnoughDryFood?.value);
      Formdata.append('foodStorage_FrozenStoredFood', this.foodStorage_FrozenStoredFood?.value);
      Formdata.append('foodStorage_AreFrozenFoods', this.foodStorage_AreFrozenFoods?.value);

      Formdata.append('foodStorage_IsFoodProperlyStored', this.foodStorage_IsFoodProperlyStored?.value);
      Formdata.append('foodStorage_AreChillerAndFreezerClean', this.foodStorage_AreChillerAndFreezerClean?.value);
      Formdata.append('foodStorage_WhatIsTheGeneralAppearanceComment', this.foodStorage_WhatIsTheGeneralAppearanceComment?.value);

      Formdata.append('foodStorage_IsFoodProperlyProtectedFromRiskComment', this.foodStorage_IsFoodProperlyProtectedFromRiskComment?.value);
      Formdata.append('foodStorage_IsThereEnoughDryFoodComment', this.foodStorage_IsThereEnoughDryFoodComment?.value);
      Formdata.append('foodStorage_FrozenStoredFoodComment', this.foodStorage_FrozenStoredFoodComment?.value);
      Formdata.append('foodStorage_AreFrozenFoodsComment', this.foodStorage_AreFrozenFoodsComment?.value);
      Formdata.append('foodStorage_AreDryFoodsProperlyStoredComment', this.foodStorage_AreDryFoodsProperlyStoredComment?.value);
      Formdata.append('foodStorage_AreDryFoodsProperlyStored', this.foodStorage_AreDryFoodsProperlyStored?.value);

      Formdata.append('foodStorage_IsFoodProperlyStoredComment', this.foodStorage_IsFoodProperlyStoredComment?.value);
      Formdata.append('foodStorage_AreChillerAndFreezerCleanComment', this.foodStorage_AreChillerAndFreezerCleanComment?.value);

      Formdata.append('messHall_AreWashHandBasins', this.messHall_AreWashHandBasins?.value);
      Formdata.append('messHall_RegistersForChangingFoodOil', this.messHall_RegistersForChangingFoodOil?.value);

      Formdata.append('messHall_AreAllAppliancesWorking', this.messHall_AreAllAppliancesWorking?.value);
      Formdata.append('messHall_AreTablesInGoodWorkingCondition', this.messHall_AreTablesInGoodWorkingCondition?.value);
      Formdata.append('messHall_AreFlyKillersWorking', this.messHall_AreFlyKillersWorking?.value);

      Formdata.append('messHall_IsMessHallClean', this.messHall_IsMessHallClean?.value);
      Formdata.append('messHall_AreWashHandBasinsComment', this.messHall_AreWashHandBasinsComment?.value);
      Formdata.append('messHall_RegistersForChangingFoodOilComment', this.messHall_RegistersForChangingFoodOilComment?.value);

      Formdata.append('messHall_AreAllAppliancesWorkingComment', this.messHall_AreAllAppliancesWorkingComment?.value);
      Formdata.append('messHall_AreTablesInGoodWorkingConditionComment', this.messHall_AreTablesInGoodWorkingConditionComment?.value);
      Formdata.append('messHall_AreFlyKillersWorkingComment', this.messHall_AreFlyKillersWorkingComment?.value);
      Formdata.append('messHall_AllElectricalCables', this.messHall_AllElectricalCables?.value);
      Formdata.append('messHall_AllElectricalCablesComment', this.messHall_AllElectricalCablesComment?.value);

      Formdata.append('messHall_IsMessHallCleanComment', this.messHall_IsMessHallCleanComment?.value);
      Formdata.append('accomodations_LockersOfBathroomsAreInstalledWell', this.accomodations_LockersOfBathroomsAreInstalledWell?.value);
      Formdata.append('accomodations_TypesOfCleaningMaterialsUsed', this.accomodations_TypesOfCleaningMaterialsUsed?.value);

      Formdata.append('accomodations_AnyLackInCleaning', this.accomodations_AnyLackInCleaning?.value);
      Formdata.append('accomodations_AreDoorHingesAndClosures', this.accomodations_AreDoorHingesAndClosures?.value);
      Formdata.append('accomodations_LockersOfBathroomsAreInstalledWellComment', this.accomodations_LockersOfBathroomsAreInstalledWellComment?.value);

      Formdata.append('accomodations_TypesOfCleaningMaterialsUsedComment', this.accomodations_TypesOfCleaningMaterialsUsedComment?.value);
      Formdata.append('accomodations_AnyLackInCleaningComment', this.accomodations_AnyLackInCleaningComment?.value);
      Formdata.append('accomodations_AreDoorHingesAndClosuresComment', this.accomodations_AreDoorHingesAndClosuresComment?.value);

      Formdata.append('clinic_IsTheClinicCleanAndTidy', this.clinic_IsTheClinicCleanAndTidy?.value);
      Formdata.append('clinic_RelevantSdsPresent', this.clinic_RelevantSdsPresent?.value);
      Formdata.append('clinic_IsMedicalApparatus', this.clinic_IsMedicalApparatus?.value);

      Formdata.append('clinic_IsMedicalStockMaintained', this.clinic_IsMedicalStockMaintained?.value);
      Formdata.append('clinic_IsMedicalTreatment', this.clinic_IsMedicalTreatment?.value);
      Formdata.append('clinic_IsTheClinicCleanAndTidyComment', this.clinic_IsTheClinicCleanAndTidyComment?.value);

      Formdata.append('clinic_RelevantSdsPresentComment', this.clinic_RelevantSdsPresentComment?.value);
      Formdata.append('clinic_IsMedicalApparatusComment', this.clinic_IsMedicalApparatusComment?.value);
      Formdata.append('clinic_IsMedicalStockMaintainedComment', this.clinic_IsMedicalStockMaintainedComment?.value);

      Formdata.append('clinic_IsMedicalTreatmentComment', this.clinic_IsMedicalTreatmentComment?.value);
      Formdata.append('laundry_IsLaundryAleanAndTidy', this.laundry_IsLaundryAleanAndTidy?.value);
      Formdata.append('laundry_TypesOfChemicalsUsedAreRelevant', this.laundry_TypesOfChemicalsUsedAreRelevant?.value);

      Formdata.append('laundry_AreAllAppliancesSafety', this.laundry_AreAllAppliancesSafety?.value);
      Formdata.append('laundry_AreAllAppliancesWorking', this.laundry_AreAllAppliancesWorking?.value);
      Formdata.append('laundry_IsLaundryAleanAndTidyComment', this.laundry_IsLaundryAleanAndTidyComment?.value);

      Formdata.append('laundry_TypesOfChemicalsUsedAreRelevantComment', this.laundry_TypesOfChemicalsUsedAreRelevantComment?.value);
      Formdata.append('laundry_AreAllAppliancesSafetyComment', this.laundry_AreAllAppliancesSafetyComment?.value);
      Formdata.append('laundry_AreAllAppliancesWorkingComment', this.laundry_AreAllAppliancesWorkingComment?.value);
      Formdata.append('generalBathRooms_AreAllElectricalFixtures', this.generalBathRooms_AreAllElectricalFixtures?.value);

      Formdata.append('generalBathRooms_AreAllDoorsInGoodWorkingOrder', this.generalBathRooms_AreAllDoorsInGoodWorkingOrder?.value);
      Formdata.append('generalBathRooms_AnyLeaksInPiping', this.generalBathRooms_AnyLeaksInPiping?.value);
      Formdata.append('generalBathRooms_IsTheAreaCleanAndTidy', this.generalBathRooms_IsTheAreaCleanAndTidy?.value);
      Formdata.append('generalBathRooms_AreAllElectricalFixturesComment', this.generalBathRooms_AreAllElectricalFixturesComment?.value);
      Formdata.append('generalBathRooms_AreAllDoorsInGoodWorkingOrderComment', this.generalBathRooms_AreAllDoorsInGoodWorkingOrderComment?.value);
      Formdata.append('generalBathRooms_AnyLeaksInPipingComment', this.generalBathRooms_AnyLeaksInPipingComment?.value);
      Formdata.append('generalBathRooms_IsTheAreaCleanAndTidyComment', this.generalBathRooms_IsTheAreaCleanAndTidyComment?.value);
      Formdata.append('waterTanks_AreWaterTanksHatchesClean', this.waterTanks_AreWaterTanksHatchesClean?.value);
      Formdata.append('waterTanks_AnyWaterLeaks', this.waterTanks_AnyWaterLeaks?.value);
      Formdata.append('waterTanks_WhatIsTheDateOfLastWaterSample', this.waterTanks_WhatIsTheDateOfLastWaterSample?.value);
      Formdata.append('waterTanks_IsAreaCleanAndTidy', this.waterTanks_IsAreaCleanAndTidy?.value);
      Formdata.append('waterTanks_AreWaterTanksHatchesCleanComment', this.waterTanks_AreWaterTanksHatchesCleanComment?.value);
      Formdata.append('waterTanks_AnyWaterLeaksComment', this.waterTanks_AnyWaterLeaksComment?.value);
      Formdata.append('waterTanks_WhatIsTheDateOfLastWaterSampleComment', this.waterTanks_WhatIsTheDateOfLastWaterSampleComment?.value);
      Formdata.append('waterTanks_IsAreaCleanAndTidyComment', this.waterTanks_IsAreaCleanAndTidyComment?.value);

      Formdata.append('userID', this.UserJsonObj.ID);
      console.log(Formdata);


      console.log('after formData')
      this.AddNewweeklyCampInspection.AddWeeklyCampInspection(Formdata).subscribe({
        next: data => {
          // console.log(this. weeklyCampInspectionForm );

          console.log('from service')
          console.log(data.data)
          location.reload();
        },
        error: error => {
          // console.log(this. weeklyCampInspectionForm );

          console.log("from Error")
          console.log(error)
        }
      });
     console.log(Formdata);
    }
    else {
      this.weeklyCampInspectionForm.markAllAsTouched()
       console.log('weeklyyy', this.weeklyCampInspectionForm.value)

      console.log("E+++++====error in : ");
    }
  }

  Download() {
    let workbook = new Workbook();

    let worksheet = workbook.addWorksheet("Weekly Camp Inspection Data");


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

    let fname = "Weekly Camp Inspection Report"

    //add data and file name and download
    workbook.xlsx.writeBuffer().then((data) => {
      let blob = new Blob([data], { type: 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet' });
      saveAs.saveAs(blob, fname + '-' + new Date().toUTCString() + '.xlsx');
    });
  }

}
