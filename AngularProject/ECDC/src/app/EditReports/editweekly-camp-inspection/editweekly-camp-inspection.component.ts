import { ChangeDetectorRef, Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, ParamMap, Router } from '@angular/router';
import { AddweeklyCampInspectionServiceService } from 'Services/addweekly-camp-inspection-service.service';
import { DataService } from 'Services/data.service';
import { LoginService } from 'Services/login.service';
import { IRig } from 'SharedClasses/IRig';
import { IWeeklyCampInspection } from 'SharedClasses/IWeeklyCampInspection';

@Component({
  selector: 'app-editweekly-camp-inspection',
  templateUrl: './editweekly-camp-inspection.component.html',
  styleUrls: ['./editweekly-camp-inspection.component.scss']
})
export class EditweeklyCampInspectionComponent {

  WeeklyCampInspectionId: any;
  WeeklyCampInspection!: IWeeklyCampInspection;
  ErrorMessage: string = "";
  WeeklyCampInspectionForm!: FormGroup;
  Date: Date = new Date();
  rigList: IRig[] = []
  UserJsonString: any
  UserJsonObj: any


  User: any;

  constructor(private loginService: LoginService,
    private activatedRoute: ActivatedRoute,
    private dataService: DataService,
    private WeeklyCampInspectionService: AddweeklyCampInspectionServiceService,
    private fb: FormBuilder,
    private router: Router,
    private cdr: ChangeDetectorRef) {

  }


  ngOnInit(): void {
    this.User = this.loginService.currentUser.getValue();
    this.activatedRoute.paramMap.subscribe((params: ParamMap) => {
      this.WeeklyCampInspectionId = params.get("id");
      console.log(this.WeeklyCampInspectionId)
    }),



      this.WeeklyCampInspectionService.GetWeeklyCampInspectionByID(this.WeeklyCampInspectionId, this.User.ID, this.User.Role).subscribe({
        next: data => {
          this.WeeklyCampInspection = data.data,
            console.log('*************************************************************')
          console.log(this.WeeklyCampInspection);
        },
        error: (erorr: string) => this.ErrorMessage = erorr
      }),
      this.UserJsonString = JSON.stringify(this.loginService.currentUser.getValue()),
      this.UserJsonObj = JSON.parse(this.UserJsonString),
      this.WeeklyCampInspectionForm = this.fb.group(
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
      this.dataService.GetRig().subscribe({
        next: data => {
          this.rigList = data.data,
            console.log(this.rigList)
        },
        error: err => {
          this.ErrorMessage = err,
            console.log(this.ErrorMessage)
        }
      })
  }
  get id() {
    return this.WeeklyCampInspectionForm.get('id');
  }
  get rigId() {
    return this.WeeklyCampInspectionForm.get('rigId');
  }
  get date() {
    return this.WeeklyCampInspectionForm.get('date');
  }
  get general_AreParking() {
    return this.WeeklyCampInspectionForm.get('general_AreParking');
  }

  get general_IsCampSite() {
    return this.WeeklyCampInspectionForm.get('general_IsCampSite');
  }
  get general_IsAllRubbish() {
    return this.WeeklyCampInspectionForm.get('general_IsAllRubbish');
  }
  get general_AreWater() {
    return this.WeeklyCampInspectionForm.get('general_AreWater');
  }
  get general_IsGenerator() {
    return this.WeeklyCampInspectionForm.get('general_IsGenerator');
  }
  get general_WhatIsGeneralOpinion() {
    return this.WeeklyCampInspectionForm.get('general_WhatIsGeneralOpinion');
  }
  get general_AreParkingComment() {
    return this.WeeklyCampInspectionForm.get('general_AreParkingComment');
  }
  get general_IsCampSiteComment() {
    return this.WeeklyCampInspectionForm.get('general_IsCampSiteComment');
  }

  get general_IsAllRubbishComment() {
    return this.WeeklyCampInspectionForm.get('general_IsAllRubbishComment');
  }
  get general_AreWaterComment() {
    return this.WeeklyCampInspectionForm.get('general_AreWaterComment');
  }
  get general_IsGeneratorComment() {
    return this.WeeklyCampInspectionForm.get('general_IsGeneratorComment');
  }

  get general_WhatIsGeneralOpinionComment() {
    return this.WeeklyCampInspectionForm.get('general_WhatIsGeneralOpinionComment');
  }
  get safety_DateOfLastCampfireDrill() {
    return this.WeeklyCampInspectionForm.get('safety_DateOfLastCampfireDrill');
  }
  get safety_DateOfLastMedicalDrill() {
    return this.WeeklyCampInspectionForm.get('safety_DateOfLastMedicalDrill');
  }

  get safety_AreStaffAwareOfFoodHazards() {
    return this.WeeklyCampInspectionForm.get('safety_AreStaffAwareOfFoodHazards');
  }
  get safety_FirePumpInGoodCondition() {
    return this.WeeklyCampInspectionForm.get('safety_FirePumpInGoodCondition');
  }
  get safety_AreThereAnyPotentialHazards() {
    return this.WeeklyCampInspectionForm.get('safety_AreThereAnyPotentialHazards');
  }

  get safety_IsTheDiesel() {
    return this.WeeklyCampInspectionForm.get('safety_IsTheDiesel');
  }
  get safety_AreThereAnyUnsafe() {
    return this.WeeklyCampInspectionForm.get('safety_AreThereAnyUnsafe');
  }
  get safety_IsCampEarthing() {
    return this.WeeklyCampInspectionForm.get('safety_IsCampEarthing');
  }

  get safety_AreFireEmergency() {
    return this.WeeklyCampInspectionForm.get('safety_AreFireEmergency');
  }
  get safety_DateOfLastCampfireDrillComment() {
    return this.WeeklyCampInspectionForm.get('safety_DateOfLastCampfireDrillComment');
  }
  get safety_DateOfLastMedicalDrillComment() {
    return this.WeeklyCampInspectionForm.get('safety_DateOfLastMedicalDrillComment');
  }

  get safety_AreStaffAwareOfFoodHazardsComment() {
    return this.WeeklyCampInspectionForm.get('safety_AreStaffAwareOfFoodHazardsComment');
  }
  get safety_FirePumpInGoodConditionComment() {
    return this.WeeklyCampInspectionForm.get('safety_FirePumpInGoodConditionComment');
  }
  get safety_AreThereAnyPotentialHazardsComment() {
    return this.WeeklyCampInspectionForm.get('safety_AreThereAnyPotentialHazardsComment');
  }

  get safety_IsTheDieselComment() {
    return this.WeeklyCampInspectionForm.get('safety_IsTheDieselComment');
  }
  get safety_AreThereAnyUnsafeComment() {
    return this.WeeklyCampInspectionForm.get('safety_AreThereAnyUnsafeComment');
  }
  get safety_IsCampEarthingComment() {
    return this.WeeklyCampInspectionForm.get('safety_IsCampEarthingComment');
  }

  get safety_AreFireEmergencyComment() {
    return this.WeeklyCampInspectionForm.get('safety_AreFireEmergencyComment');
  }
  get foodStorage_WhatIsTheGeneralAppearance() {
    return this.WeeklyCampInspectionForm.get('foodStorage_WhatIsTheGeneralAppearance');
  }
  get foodStorage_IsFoodProperlyProtectedFromRisk() {
    return this.WeeklyCampInspectionForm.get('foodStorage_IsFoodProperlyProtectedFromRisk');
  }
  get foodStorage_IsThereEnoughDryFood() {
    return this.WeeklyCampInspectionForm.get('foodStorage_IsThereEnoughDryFood');
  }
  get foodStorage_FrozenStoredFood() {
    return this.WeeklyCampInspectionForm.get('foodStorage_FrozenStoredFood');
  }
  get foodStorage_AreDryFoodsProperlyStoredComment() {
    return this.WeeklyCampInspectionForm.get('foodStorage_AreDryFoodsProperlyStoredComment');
  }
  get foodStorage_AreDryFoodsProperlyStored() {
    return this.WeeklyCampInspectionForm.get('foodStorage_AreDryFoodsProperlyStored');
  }
  get foodStorage_AreFrozenFoods() {
    return this.WeeklyCampInspectionForm.get('foodStorage_AreFrozenFoods');
  }
  get foodStorage_IsFoodProperlyStored() {
    return this.WeeklyCampInspectionForm.get('foodStorage_IsFoodProperlyStored');
  }
  get foodStorage_AreChillerAndFreezerClean() {
    return this.WeeklyCampInspectionForm.get('foodStorage_AreChillerAndFreezerClean');
  }

  get foodStorage_WhatIsTheGeneralAppearanceComment() {
    return this.WeeklyCampInspectionForm.get('foodStorage_WhatIsTheGeneralAppearanceComment');
  }

  get foodStorage_IsFoodProperlyProtectedFromRiskComment() {
    return this.WeeklyCampInspectionForm.get('foodStorage_IsFoodProperlyProtectedFromRiskComment');
  }
  get foodStorage_IsThereEnoughDryFoodComment() {
    return this.WeeklyCampInspectionForm.get('foodStorage_IsThereEnoughDryFoodComment');
  }
  get foodStorage_FrozenStoredFoodComment() {
    return this.WeeklyCampInspectionForm.get('foodStorage_FrozenStoredFoodComment');
  }
  get foodStorage_AreFrozenFoodsComment() {
    return this.WeeklyCampInspectionForm.get('foodStorage_AreFrozenFoodsComment');
  }
  get foodStorage_IsFoodProperlyStoredComment() {
    return this.WeeklyCampInspectionForm.get('foodStorage_IsFoodProperlyStoredComment');
  }
  get foodStorage_AreChillerAndFreezerCleanComment() {
    return this.WeeklyCampInspectionForm.get('foodStorage_AreChillerAndFreezerCleanComment');
  }
  get galley_IsThereWnyWaterLeaks() {
    return this.WeeklyCampInspectionForm.get('galley_IsThereWnyWaterLeaks');
  }
  get galley_AreAllAppliancesWorking() {
    return this.WeeklyCampInspectionForm.get('galley_AreAllAppliancesWorking');
  }
  get galley_WhenWasExhaustFans() {
    return this.WeeklyCampInspectionForm.get('galley_WhenWasExhaustFans');
  }
  get galley_AreDishesAndUtensilsClean() {
    return this.WeeklyCampInspectionForm.get('galley_AreDishesAndUtensilsClean');
  }
  get galley_WhatTheConditionOfTheChipPanAndfoodOil() {
    return this.WeeklyCampInspectionForm.get('galley_WhatTheConditionOfTheChipPanAndfoodOil');
  }
  get galley_IsTheGalleyAreaClean() {
    return this.WeeklyCampInspectionForm.get('galley_IsTheGalleyAreaClean');
  }
  get galley_IsThereWnyWaterLeaksComment() {
    return this.WeeklyCampInspectionForm.get('galley_IsThereWnyWaterLeaksComment');
  }
  get galley_AreAllAppliancesWorkingComment() {
    return this.WeeklyCampInspectionForm.get('galley_AreAllAppliancesWorkingComment');
  }
  get galley_WhenWasExhaustFansComment() {
    return this.WeeklyCampInspectionForm.get('galley_WhenWasExhaustFansComment');
  }

  get galley_AreDishesAndUtensilsCleanComment() {
    return this.WeeklyCampInspectionForm.get('galley_AreDishesAndUtensilsCleanComment');
  }
  get galley_WhatTheConditionOfTheChipPanAndfoodOilComment() {
    return this.WeeklyCampInspectionForm.get('galley_WhatTheConditionOfTheChipPanAndfoodOilComment');
  }
  get galley_IsTheGalleyAreaCleanComment() {
    return this.WeeklyCampInspectionForm.get('galley_IsTheGalleyAreaCleanComment');
  }
  get messHall_AreWashHandBasins() {
    return this.WeeklyCampInspectionForm.get('messHall_AreWashHandBasins');
  }
  get messHall_RegistersForChangingFoodOil() {
    return this.WeeklyCampInspectionForm.get('messHall_RegistersForChangingFoodOil');
  }
  get messHall_AreAllAppliancesWorking() {
    return this.WeeklyCampInspectionForm.get('messHall_AreAllAppliancesWorking');
  }
  get messHall_AreTablesInGoodWorkingCondition() {
    return this.WeeklyCampInspectionForm.get('messHall_AreTablesInGoodWorkingCondition');
  }
  get messHall_AreFlyKillersWorking() {
    return this.WeeklyCampInspectionForm.get('messHall_AreFlyKillersWorking');
  }
  get messHall_IsMessHallClean() {
    return this.WeeklyCampInspectionForm.get('messHall_IsMessHallClean');
  }
  get messHall_AllElectricalCables() {
    return this.WeeklyCampInspectionForm.get('messHall_AllElectricalCables');
  }
  get messHall_AllElectricalCablesComment() {
    return this.WeeklyCampInspectionForm.get('messHall_AllElectricalCablesComment');
  }
  get messHall_AreWashHandBasinsComment() {
    return this.WeeklyCampInspectionForm.get('messHall_AreWashHandBasinsComment');
  }
  get messHall_RegistersForChangingFoodOilComment() {
    return this.WeeklyCampInspectionForm.get('messHall_RegistersForChangingFoodOilComment');
  }
  get messHall_AreAllAppliancesWorkingComment() {
    return this.WeeklyCampInspectionForm.get('messHall_AreAllAppliancesWorkingComment');
  }
  get messHall_AreTablesInGoodWorkingConditionComment() {
    return this.WeeklyCampInspectionForm.get('messHall_AreTablesInGoodWorkingConditionComment');
  }
  get messHall_AreFlyKillersWorkingComment() {
    return this.WeeklyCampInspectionForm.get('messHall_AreFlyKillersWorkingComment');
  }
  get messHall_IsMessHallCleanComment() {
    return this.WeeklyCampInspectionForm.get('messHall_IsMessHallCleanComment');
  }
  get accomodations_LockersOfBathroomsAreInstalledWell() {
    return this.WeeklyCampInspectionForm.get('accomodations_LockersOfBathroomsAreInstalledWell');
  }
  get accomodations_TypesOfCleaningMaterialsUsed() {
    return this.WeeklyCampInspectionForm.get('accomodations_TypesOfCleaningMaterialsUsed');
  }
  get accomodations_AnyLackInCleaning() {
    return this.WeeklyCampInspectionForm.get('accomodations_AnyLackInCleaning');
  }
  get accomodations_AreDoorHingesAndClosures() {
    return this.WeeklyCampInspectionForm.get('accomodations_AreDoorHingesAndClosures');
  }
  get accomodations_LockersOfBathroomsAreInstalledWellComment() {
    return this.WeeklyCampInspectionForm.get('accomodations_LockersOfBathroomsAreInstalledWellComment');
  }
  get accomodations_TypesOfCleaningMaterialsUsedComment() {
    return this.WeeklyCampInspectionForm.get('accomodations_TypesOfCleaningMaterialsUsedComment');
  }
  get accomodations_AnyLackInCleaningComment() {
    return this.WeeklyCampInspectionForm.get('accomodations_AnyLackInCleaningComment');
  }
  get accomodations_AreDoorHingesAndClosuresComment() {
    return this.WeeklyCampInspectionForm.get('accomodations_AreDoorHingesAndClosuresComment');
  }
  get clinic_IsTheClinicCleanAndTidy() {
    return this.WeeklyCampInspectionForm.get('clinic_IsTheClinicCleanAndTidy');
  }
  get clinic_RelevantSdsPresent() {
    return this.WeeklyCampInspectionForm.get('clinic_RelevantSdsPresent');
  }
  get clinic_IsMedicalApparatus() {
    return this.WeeklyCampInspectionForm.get('clinic_IsMedicalApparatus');
  }
  get clinic_IsMedicalStockMaintained() {
    return this.WeeklyCampInspectionForm.get('clinic_IsMedicalStockMaintained');
  }
  get clinic_IsMedicalTreatment() {
    return this.WeeklyCampInspectionForm.get('clinic_IsMedicalTreatment');
  }
  get clinic_IsTheClinicCleanAndTidyComment() {
    return this.WeeklyCampInspectionForm.get('clinic_IsTheClinicCleanAndTidyComment');
  }
  get clinic_RelevantSdsPresentComment() {
    return this.WeeklyCampInspectionForm.get('clinic_RelevantSdsPresentComment');
  }
  get clinic_IsMedicalApparatusComment() {
    return this.WeeklyCampInspectionForm.get('clinic_IsMedicalApparatusComment');
  }
  get clinic_IsMedicalStockMaintainedComment() {
    return this.WeeklyCampInspectionForm.get('clinic_IsMedicalStockMaintainedComment');
  }
  get clinic_IsMedicalTreatmentComment() {
    return this.WeeklyCampInspectionForm.get('clinic_IsMedicalTreatmentComment');
  }
  get laundry_IsLaundryAleanAndTidy() {
    return this.WeeklyCampInspectionForm.get('laundry_IsLaundryAleanAndTidy');
  }
  get laundry_TypesOfChemicalsUsedAreRelevant() {
    return this.WeeklyCampInspectionForm.get('laundry_TypesOfChemicalsUsedAreRelevant');
  }
  get laundry_AreAllAppliancesSafety() {
    return this.WeeklyCampInspectionForm.get('laundry_AreAllAppliancesSafety');
  }
  get laundry_AreAllAppliancesWorking() {
    return this.WeeklyCampInspectionForm.get('laundry_AreAllAppliancesWorking');
  }
  get laundry_IsLaundryAleanAndTidyComment() {
    return this.WeeklyCampInspectionForm.get('laundry_IsLaundryAleanAndTidyComment');
  }
  get laundry_TypesOfChemicalsUsedAreRelevantComment() {
    return this.WeeklyCampInspectionForm.get('laundry_TypesOfChemicalsUsedAreRelevantComment');
  }
  get laundry_AreAllAppliancesSafetyComment() {
    return this.WeeklyCampInspectionForm.get('laundry_AreAllAppliancesSafetyComment');
  }
  get laundry_AreAllAppliancesWorkingComment() {
    return this.WeeklyCampInspectionForm.get('laundry_AreAllAppliancesWorkingComment');
  }
  get generalBathRooms_AreAllElectricalFixtures() {
    return this.WeeklyCampInspectionForm.get('generalBathRooms_AreAllElectricalFixtures');
  }
  get generalBathRooms_AreAllDoorsInGoodWorkingOrder() {
    return this.WeeklyCampInspectionForm.get('generalBathRooms_AreAllDoorsInGoodWorkingOrder');
  }
  get generalBathRooms_AnyLeaksInPiping() {
    return this.WeeklyCampInspectionForm.get('generalBathRooms_AnyLeaksInPiping');
  }
  get generalBathRooms_IsTheAreaCleanAndTidy() {
    return this.WeeklyCampInspectionForm.get('generalBathRooms_IsTheAreaCleanAndTidy');
  }
  get generalBathRooms_AreAllElectricalFixturesComment() {
    return this.WeeklyCampInspectionForm.get('generalBathRooms_AreAllElectricalFixturesComment');
  }
  get generalBathRooms_AreAllDoorsInGoodWorkingOrderComment() {
    return this.WeeklyCampInspectionForm.get('generalBathRooms_AreAllDoorsInGoodWorkingOrderComment');
  }
  get generalBathRooms_AnyLeaksInPipingComment() {
    return this.WeeklyCampInspectionForm.get('generalBathRooms_AnyLeaksInPipingComment');
  }
  get generalBathRooms_IsTheAreaCleanAndTidyComment() {
    return this.WeeklyCampInspectionForm.get('generalBathRooms_IsTheAreaCleanAndTidyComment');
  }
  get waterTanks_AreWaterTanksHatchesClean() {
    return this.WeeklyCampInspectionForm.get('waterTanks_AreWaterTanksHatchesClean');
  }
  get waterTanks_AnyWaterLeaks() {
    return this.WeeklyCampInspectionForm.get('waterTanks_AnyWaterLeaks');
  }
  get waterTanks_WhatIsTheDateOfLastWaterSample() {
    return this.WeeklyCampInspectionForm.get('waterTanks_WhatIsTheDateOfLastWaterSample');
  }
  get waterTanks_IsAreaCleanAndTidy() {
    return this.WeeklyCampInspectionForm.get('waterTanks_IsAreaCleanAndTidy');
  }
  get waterTanks_AreWaterTanksHatchesCleanComment() {
    return this.WeeklyCampInspectionForm.get('waterTanks_AreWaterTanksHatchesCleanComment');
  }
  get waterTanks_AnyWaterLeaksComment() {
    return this.WeeklyCampInspectionForm.get('waterTanks_AnyWaterLeaksComment');
  }
  get waterTanks_WhatIsTheDateOfLastWaterSampleComment() {
    return this.WeeklyCampInspectionForm.get('waterTanks_WhatIsTheDateOfLastWaterSampleComment');
  }
  get waterTanks_IsAreaCleanAndTidyComment() {
    return this.WeeklyCampInspectionForm.get('waterTanks_IsAreaCleanAndTidyComment');
  }
  submitData() {

    if (this.WeeklyCampInspectionForm.valid) {

      const Formdata = new FormData()
      console.log("fforrrrrrrmmmmmmmmm", Formdata)

      Formdata.append('rigId', this.rigId?.value);
      Formdata.append('date', this.date?.value);
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

      Formdata.append('safety_AreFireEmergencyComment', this.safety_AreFireEmergencyComment?.value);
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
      Formdata.append('galley_IsThereWnyWaterLeaks', this.galley_IsThereWnyWaterLeaks?.value);
      Formdata.append('galley_AreAllAppliancesWorking', this.galley_AreAllAppliancesWorking?.value);
      Formdata.append('galley_WhenWasExhaustFans', this.galley_WhenWasExhaustFans?.value);
      Formdata.append('galley_AreDishesAndUtensilsClean', this.galley_AreDishesAndUtensilsClean?.value);
      Formdata.append('galley_WhatTheConditionOfTheChipPanAndfoodOil', this.galley_WhatTheConditionOfTheChipPanAndfoodOil?.value);
      Formdata.append('galley_IsTheGalleyAreaClean', this.galley_IsTheGalleyAreaClean?.value);
      Formdata.append('galley_IsThereWnyWaterLeaksComment', this.galley_IsThereWnyWaterLeaksComment?.value);
      Formdata.append('galley_AreAllAppliancesWorkingComment', this.galley_AreAllAppliancesWorkingComment?.value);
      Formdata.append('galley_WhenWasExhaustFansComment', this.galley_WhenWasExhaustFansComment?.value);


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

      Formdata.append('safety_AreFireEmergencyComment', this.safety_AreFireEmergencyComment?.value);
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
      Formdata.append('userName', this.UserJsonObj.name);

      console.log(Formdata);


      console.log('after formData')
      this.WeeklyCampInspectionService.EditWeeklyCampInspection(Formdata, this.WeeklyCampInspectionId).subscribe({
        next: data => {
          console.log('from service')
          console.log(data.data)
          this.router.navigate(['/Dashboard/WeeklyCampInspection']);
        },
        error: error => {
          console.log("from Error")
          console.log(error)
        }
      });
      console.log(Formdata);
    }
    else {
      console.log('weeklyyy', this.WeeklyCampInspectionForm)

      console.log("E+++++====error in : ");
    }
  }


}
