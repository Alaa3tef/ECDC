using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using TempProject.Models;

namespace TempProject.DTO.ResponseDTO
{
    public class WeeklyCampInspectionsResponseDTO
    {
        public int Id { get; set; }

        public int RigId { get; set; }

        [Column(TypeName = "date")]
        public DateTime Date { get; set; }
        public string General_AreParking { get; set; }
        public string General_IsCampSite { get; set; }
        public string General_IsAllRubbish { get; set; }
        public string General_AreWater { get; set; }
        public string General_IsGenerator { get; set; }
        public string General_WhatIsGeneralOpinion { get; set; }

        public string? General_AreParkingComment { get; set; }
        public string? General_IsCampSiteComment { get; set; }
        public string? General_IsAllRubbishComment { get; set; }
        public string? General_AreWaterComment { get; set; }
        public string? General_IsGeneratorComment { get; set; }
        public string? General_WhatIsGeneralOpinionComment { get; set; }

        public string Safety_DateOfLastCampfireDrill { get; set; }
        public string Safety_DateOfLastMedicalDrill { get; set; }
        public string Safety_AreStaffAwareOfFoodHazards { get; set; }
        public string Safety_FirePumpInGoodCondition { get; set; }
        public string Safety_AreThereAnyPotentialHazards { get; set; }
        public string Safety_IsTheDiesel { get; set; }
        public string Safety_AreThereAnyUnsafe { get; set; }
        public string Safety_IsCampEarthing { get; set; }
        public string Safety_AreFireEmergency { get; set; }

        public string? Safety_DateOfLastCampfireDrillComment { get; set; }
        public string? Safety_DateOfLastMedicalDrillComment { get; set; }
        public string? Safety_AreStaffAwareOfFoodHazardsComment { get; set; }
        public string? Safety_FirePumpInGoodConditionComment { get; set; }
        public string? Safety_AreThereAnyPotentialHazardsComment { get; set; }
        public string? Safety_IsTheDieselComment { get; set; }
        public string? Safety_AreThereAnyUnsafeComment { get; set; }
        public string? Safety_IsCampEarthingComment { get; set; }
        public string? Safety_AreFireEmergencyComment { get; set; }

        public string FoodStorage_WhatIsTheGeneralAppearance { get; set; }
        public string FoodStorage_IsFoodProperlyProtectedFromRisk { get; set; }
        public string FoodStorage_IsThereEnoughDryFood { get; set; }
        public string FoodStorage_FrozenStoredFood { get; set; }
        public string FoodStorage_AreFrozenFoods { get; set; }
        public string FoodStorage_IsFoodProperlyStored { get; set; }
        public string FoodStorage_AreChillerAndFreezerClean { get; set; }
        public string FoodStorage_AreDryFoodsProperlyStored { get; set; }

        public string? FoodStorage_WhatIsTheGeneralAppearanceComment { get; set; }
        public string? FoodStorage_IsFoodProperlyProtectedFromRiskComment { get; set; }
        public string? FoodStorage_IsThereEnoughDryFoodComment { get; set; }
        public string? FoodStorage_FrozenStoredFoodComment { get; set; }
        public string? FoodStorage_AreFrozenFoodsComment { get; set; }
        public string? FoodStorage_IsFoodProperlyStoredComment { get; set; }
        public string? FoodStorage_AreChillerAndFreezerCleanComment { get; set; }
        public string? FoodStorage_AreDryFoodsProperlyStoredComment { get; set; }


        public string Galley_IsThereWnyWaterLeaks { get; set; }
        public string Galley_AreAllAppliancesWorking { get; set; }
        public string Galley_WhenWasExhaustFans { get; set; }
        public string Galley_AreDishesAndUtensilsClean { get; set; }
        public string Galley_WhatTheConditionOfTheChipPanAndfoodOil { get; set; }
        public string Galley_IsTheGalleyAreaClean { get; set; }

        public string? Galley_IsThereWnyWaterLeaksComment { get; set; }
        public string? Galley_AreAllAppliancesWorkingComment { get; set; }
        public string? Galley_WhenWasExhaustFansComment { get; set; }
        public string? Galley_AreDishesAndUtensilsCleanComment { get; set; }
        public string? Galley_WhatTheConditionOfTheChipPanAndfoodOilComment { get; set; }
        public string? Galley_IsTheGalleyAreaCleanComment { get; set; }

        public string MessHall_AreWashHandBasins { get; set; }
        public string MessHall_RegistersForChangingFoodOil { get; set; }
        public string MessHall_AreAllAppliancesWorking { get; set; }
        public string MessHall_AreTablesInGoodWorkingCondition { get; set; }
        public string MessHall_AreFlyKillersWorking { get; set; }
        public string MessHall_IsMessHallClean { get; set; }
        public string MessHall_AllElectricalCables { get; set; }

        public string? MessHall_AreWashHandBasinsComment { get; set; }
        public string? MessHall_RegistersForChangingFoodOilComment { get; set; }
        public string? MessHall_AreAllAppliancesWorkingComment { get; set; }
        public string? MessHall_AreTablesInGoodWorkingConditionComment { get; set; }
        public string? MessHall_AreFlyKillersWorkingComment { get; set; }
        public string? MessHall_IsMessHallCleanComment { get; set; }
        public string? MessHall_AllElectricalCablesComment { get; set; }

        public string Accomodations_LockersOfBathroomsAreInstalledWell { get; set; }
        public string Accomodations_TypesOfCleaningMaterialsUsed { get; set; }
        public string Accomodations_AnyLackInCleaning { get; set; }
        public string Accomodations_AreDoorHingesAndClosures { get; set; }

        public string? Accomodations_LockersOfBathroomsAreInstalledWellComment { get; set; }
        public string? Accomodations_TypesOfCleaningMaterialsUsedComment { get; set; }
        public string? Accomodations_AnyLackInCleaningComment { get; set; }
        public string? Accomodations_AreDoorHingesAndClosuresComment { get; set; }

        public string Clinic_IsTheClinicCleanAndTidy { get; set; }
        public string Clinic_RelevantSdsPresent { get; set; }
        public string Clinic_IsMedicalApparatus { get; set; }
        public string Clinic_IsMedicalStockMaintained { get; set; }
        public string Clinic_IsMedicalTreatment { get; set; }


        public string? Clinic_IsTheClinicCleanAndTidyComment { get; set; }
        public string? Clinic_RelevantSdsPresentComment { get; set; }
        public string? Clinic_IsMedicalApparatusComment { get; set; }
        public string? Clinic_IsMedicalStockMaintainedComment { get; set; }
        public string? Clinic_IsMedicalTreatmentComment { get; set; }

        public string Laundry_IsLaundryAleanAndTidy { get; set; }
        public string Laundry_TypesOfChemicalsUsedAreRelevant { get; set; }
        public string Laundry_AreAllAppliancesSafety { get; set; }
        public string Laundry_AreAllAppliancesWorking { get; set; }

        public string? Laundry_IsLaundryAleanAndTidyComment { get; set; }
        public string? Laundry_TypesOfChemicalsUsedAreRelevantComment { get; set; }
        public string? Laundry_AreAllAppliancesSafetyComment { get; set; }
        public string? Laundry_AreAllAppliancesWorkingComment { get; set; }


        public string GeneralBathRooms_AreAllElectricalFixtures { get; set; }
        public string GeneralBathRooms_AreAllDoorsInGoodWorkingOrder { get; set; }
        public string GeneralBathRooms_AnyLeaksInPiping { get; set; }
        public string GeneralBathRooms_IsTheAreaCleanAndTidy { get; set; }

        public string? GeneralBathRooms_AreAllElectricalFixturesComment { get; set; }
        public string? GeneralBathRooms_AreAllDoorsInGoodWorkingOrderComment { get; set; }
        public string? GeneralBathRooms_AnyLeaksInPipingComment { get; set; }
        public string? GeneralBathRooms_IsTheAreaCleanAndTidyComment { get; set; }

        public string WaterTanks_AreWaterTanksHatchesClean { get; set; }
        public string WaterTanks_AnyWaterLeaks { get; set; }
        public string WaterTanks_WhatIsTheDateOfLastWaterSample { get; set; }
        public string WaterTanks_IsAreaCleanAndTidy { get; set; }

        public string? WaterTanks_AreWaterTanksHatchesCleanComment { get; set; }
        public string? WaterTanks_AnyWaterLeaksComment { get; set; }
        public string? WaterTanks_WhatIsTheDateOfLastWaterSampleComment { get; set; }
        public string? WaterTanks_IsAreaCleanAndTidyComment { get; set; }



        [DefaultValue(false)]
		public bool IsDeleted { get; set; }
		public string userID { get; set; }
		public string userName { get; set; }


	}
}
