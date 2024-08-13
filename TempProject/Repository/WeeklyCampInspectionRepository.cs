using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Policy;
using TempProject.Models;

namespace TempProject.Repository
{
    public class WeeklyCampInspectionRepository : IWeeklyCampInspectionRepository
	{
        Context c;
        public WeeklyCampInspectionRepository(Context c)
        {
            this.c = c;
        }

        public List<WeeklyCampInspection> getall()
        {
            return c.WeeklyCampInspections
                .Include(a => a.Rig)
                .Include(a => a.user)
                .Where(a => a.IsDeleted == false)
                .Select(a => new WeeklyCampInspection 
				{
                    Id = a.Id,
                    RigId=a.RigId,
                    Rig = new Rig { Number = a.Rig.Number, Id=a.Rig.Id },
                    Date = a.Date,

                    GeneralBathRooms_AnyLeaksInPiping = a.GeneralBathRooms_AnyLeaksInPiping,
                    GeneralBathRooms_AnyLeaksInPipingComment = a.GeneralBathRooms_AnyLeaksInPipingComment,

                    GeneralBathRooms_AreAllDoorsInGoodWorkingOrder = a.GeneralBathRooms_AreAllDoorsInGoodWorkingOrder ,
                    GeneralBathRooms_AreAllDoorsInGoodWorkingOrderComment =a.GeneralBathRooms_AreAllDoorsInGoodWorkingOrderComment ,
                   
                    GeneralBathRooms_AreAllElectricalFixtures = a.GeneralBathRooms_AreAllElectricalFixtures ,
                    GeneralBathRooms_AreAllElectricalFixturesComment =a.GeneralBathRooms_AreAllElectricalFixturesComment ,

                    GeneralBathRooms_IsTheAreaCleanAndTidy = a.GeneralBathRooms_IsTheAreaCleanAndTidy ,
                    GeneralBathRooms_IsTheAreaCleanAndTidyComment  = a.GeneralBathRooms_IsTheAreaCleanAndTidyComment ,

                    General_AreParking  =  a.General_AreParking ,
                    General_AreParkingComment  = a.General_AreParkingComment ,

                    General_AreWater  = a.General_AreWater ,
                    General_AreWaterComment  = a.General_AreWaterComment,

                    General_IsAllRubbish = a.General_IsAllRubbish,
                    General_IsAllRubbishComment = a.General_IsAllRubbishComment,

                    General_IsCampSite = a.General_IsCampSite ,
                    General_IsCampSiteComment=a.General_IsCampSiteComment,

                    General_IsGenerator = a.General_IsGenerator,
                    General_IsGeneratorComment = a.General_IsGeneratorComment,

                    General_WhatIsGeneralOpinion = a.General_WhatIsGeneralOpinion ,
                    General_WhatIsGeneralOpinionComment=a.General_IsGeneratorComment,

                    Safety_AreFireEmergency = a.Safety_AreFireEmergency,
                    Safety_AreFireEmergencyComment = a.Safety_AreFireEmergencyComment,

                    Safety_AreStaffAwareOfFoodHazards = a.Safety_AreStaffAwareOfFoodHazards,
                    Safety_AreStaffAwareOfFoodHazardsComment = a.Safety_AreStaffAwareOfFoodHazardsComment,

                    Safety_AreThereAnyUnsafe = a.Safety_AreThereAnyUnsafe,
                    Safety_AreThereAnyUnsafeComment = a.Safety_AreThereAnyUnsafeComment,

                    Safety_AreThereAnyPotentialHazards  = a.Safety_AreThereAnyPotentialHazards,
                    Safety_AreThereAnyPotentialHazardsComment = a.Safety_AreThereAnyPotentialHazardsComment,

                    Safety_DateOfLastCampfireDrill = a.Safety_DateOfLastCampfireDrill,
                    Safety_DateOfLastCampfireDrillComment = a.Safety_DateOfLastCampfireDrillComment,

                    Safety_DateOfLastMedicalDrill = a.Safety_DateOfLastMedicalDrill,
                    Safety_DateOfLastMedicalDrillComment = a.Safety_DateOfLastMedicalDrillComment,

                    Safety_FirePumpInGoodCondition  = a.Safety_FirePumpInGoodCondition,
                    Safety_FirePumpInGoodConditionComment=a.Safety_FirePumpInGoodConditionComment,

                    Safety_IsCampEarthing = a.Safety_IsCampEarthing,
                    Safety_IsCampEarthingComment = a.Safety_IsCampEarthingComment,

                    Safety_IsTheDiesel = a.Safety_IsTheDiesel,
                    Safety_IsTheDieselComment=a.Safety_IsTheDieselComment,

                    FoodStorage_AreChillerAndFreezerClean = a.FoodStorage_AreChillerAndFreezerClean ,
                    FoodStorage_AreChillerAndFreezerCleanComment  = a.FoodStorage_AreChillerAndFreezerCleanComment ,

                    FoodStorage_AreFrozenFoods = a.FoodStorage_AreFrozenFoods,
                    FoodStorage_AreFrozenFoodsComment = a.FoodStorage_AreFrozenFoodsComment,

                    FoodStorage_FrozenStoredFood = a.FoodStorage_FrozenStoredFood,
                    FoodStorage_FrozenStoredFoodComment = a.FoodStorage_FrozenStoredFoodComment,

                    FoodStorage_IsFoodProperlyProtectedFromRisk = a.FoodStorage_IsFoodProperlyProtectedFromRisk,
                    FoodStorage_IsFoodProperlyProtectedFromRiskComment = a.FoodStorage_IsFoodProperlyProtectedFromRiskComment,
                   
                    FoodStorage_IsFoodProperlyStored  = a.FoodStorage_IsFoodProperlyStored,
                    FoodStorage_IsFoodProperlyStoredComment = a.FoodStorage_IsFoodProperlyStoredComment,

                    FoodStorage_IsThereEnoughDryFood = a.FoodStorage_IsThereEnoughDryFood,
                    FoodStorage_IsThereEnoughDryFoodComment = a.FoodStorage_IsThereEnoughDryFoodComment,
                    FoodStorage_WhatIsTheGeneralAppearance = a.FoodStorage_WhatIsTheGeneralAppearance,
                    FoodStorage_WhatIsTheGeneralAppearanceComment = a.FoodStorage_WhatIsTheGeneralAppearanceComment,
                    FoodStorage_AreDryFoodsProperlyStoredComment=a.FoodStorage_AreDryFoodsProperlyStoredComment,
                    FoodStorage_AreDryFoodsProperlyStored = a.FoodStorage_AreDryFoodsProperlyStored,

                    Galley_WhenWasExhaustFans = a.Galley_WhenWasExhaustFans,
                    Galley_WhenWasExhaustFansComment=a.Galley_WhenWasExhaustFansComment,
                   
                    Galley_AreAllAppliancesWorking= a.Galley_AreAllAppliancesWorking,
                    Galley_AreAllAppliancesWorkingComment = a.Galley_AreAllAppliancesWorkingComment,

                    Galley_AreDishesAndUtensilsClean = a.Galley_AreDishesAndUtensilsClean,
                    Galley_AreDishesAndUtensilsCleanComment = a.Galley_AreDishesAndUtensilsCleanComment,

                    Galley_IsTheGalleyAreaClean=a.Galley_IsTheGalleyAreaClean,
                    Galley_IsTheGalleyAreaCleanComment=a.Galley_IsTheGalleyAreaCleanComment,
                
                    Galley_IsThereWnyWaterLeaks=a.Galley_IsThereWnyWaterLeaks,
                    Galley_IsThereWnyWaterLeaksComment=a.Galley_IsThereWnyWaterLeaksComment,

                    Galley_WhatTheConditionOfTheChipPanAndfoodOil=a.Galley_WhatTheConditionOfTheChipPanAndfoodOil,
                    Galley_WhatTheConditionOfTheChipPanAndfoodOilComment=a.Galley_WhatTheConditionOfTheChipPanAndfoodOilComment,

                    MessHall_AreAllAppliancesWorking=a.MessHall_AreAllAppliancesWorking,
                    MessHall_AreAllAppliancesWorkingComment=a.MessHall_AreAllAppliancesWorkingComment,

                    MessHall_AreFlyKillersWorking=a.MessHall_AreFlyKillersWorking,
                    MessHall_AreFlyKillersWorkingComment=a.MessHall_AreFlyKillersWorkingComment,

                    MessHall_AreTablesInGoodWorkingCondition=a.MessHall_AreTablesInGoodWorkingCondition,
                    MessHall_AreTablesInGoodWorkingConditionComment=a.MessHall_AreTablesInGoodWorkingConditionComment,

                    MessHall_AreWashHandBasins=a.MessHall_AreWashHandBasins,
                    MessHall_AreWashHandBasinsComment=a.MessHall_AreWashHandBasinsComment,

                    MessHall_IsMessHallClean=a.MessHall_IsMessHallClean,
                    MessHall_IsMessHallCleanComment=a.MessHall_IsMessHallCleanComment,
                    MessHall_AllElectricalCablesComment=a.MessHall_AllElectricalCablesComment,
                    MessHall_AllElectricalCables = a.MessHall_AllElectricalCables,

                    MessHall_RegistersForChangingFoodOil = a.MessHall_RegistersForChangingFoodOil,
                    MessHall_RegistersForChangingFoodOilComment=a.MessHall_RegistersForChangingFoodOilComment,
                    
                    Accomodations_AnyLackInCleaning=a.Accomodations_AnyLackInCleaning,
                    Accomodations_AnyLackInCleaningComment=a.Accomodations_AnyLackInCleaningComment,

                    Accomodations_AreDoorHingesAndClosures=a.Accomodations_AreDoorHingesAndClosures,
                    Accomodations_AreDoorHingesAndClosuresComment=a.Accomodations_AreDoorHingesAndClosuresComment,

                    Accomodations_LockersOfBathroomsAreInstalledWell=a.Accomodations_LockersOfBathroomsAreInstalledWell,
                    Accomodations_LockersOfBathroomsAreInstalledWellComment=a.Accomodations_LockersOfBathroomsAreInstalledWellComment,

                    Accomodations_TypesOfCleaningMaterialsUsed=a.Accomodations_TypesOfCleaningMaterialsUsed,
                    Accomodations_TypesOfCleaningMaterialsUsedComment=a.Accomodations_TypesOfCleaningMaterialsUsedComment,

                    Clinic_IsMedicalApparatus =a.Clinic_IsMedicalApparatus,
                    Clinic_IsMedicalApparatusComment=a.Clinic_IsMedicalApparatusComment,

                    Clinic_IsMedicalStockMaintained=a.Clinic_IsMedicalStockMaintained,
                    Clinic_IsMedicalStockMaintainedComment=a.Clinic_IsMedicalStockMaintainedComment,

                    Clinic_IsMedicalTreatment=a.Clinic_IsMedicalTreatment,
                    Clinic_IsMedicalTreatmentComment=a.Clinic_IsMedicalTreatmentComment,

                    Clinic_IsTheClinicCleanAndTidy=a.Clinic_IsTheClinicCleanAndTidy,
                    Clinic_IsTheClinicCleanAndTidyComment=a.Clinic_IsTheClinicCleanAndTidyComment,

                    Clinic_RelevantSdsPresent=a.Clinic_RelevantSdsPresent,
                    Clinic_RelevantSdsPresentComment=a.Clinic_RelevantSdsPresentComment,

                    WaterTanks_AnyWaterLeaks=a.WaterTanks_AnyWaterLeaks,
                    WaterTanks_AnyWaterLeaksComment=a.WaterTanks_AnyWaterLeaksComment,

                    WaterTanks_AreWaterTanksHatchesClean=a.WaterTanks_AreWaterTanksHatchesClean,
                    WaterTanks_AreWaterTanksHatchesCleanComment=a.WaterTanks_AreWaterTanksHatchesCleanComment,

                    WaterTanks_IsAreaCleanAndTidy=a.WaterTanks_IsAreaCleanAndTidy,
                    WaterTanks_IsAreaCleanAndTidyComment=a.WaterTanks_IsAreaCleanAndTidyComment,

                    WaterTanks_WhatIsTheDateOfLastWaterSample=a.WaterTanks_WhatIsTheDateOfLastWaterSample,
                    WaterTanks_WhatIsTheDateOfLastWaterSampleComment=a.WaterTanks_WhatIsTheDateOfLastWaterSampleComment,

                    Laundry_AreAllAppliancesWorking=a.Laundry_AreAllAppliancesWorking,
                    Laundry_AreAllAppliancesWorkingComment=a.Laundry_AreAllAppliancesWorkingComment,

                    Laundry_AreAllAppliancesSafety=a.Laundry_AreAllAppliancesSafety,
                    Laundry_AreAllAppliancesSafetyComment=a.Laundry_AreAllAppliancesSafetyComment,

                    Laundry_IsLaundryAleanAndTidy=a.Laundry_IsLaundryAleanAndTidy ,
                    Laundry_IsLaundryAleanAndTidyComment=a.Laundry_IsLaundryAleanAndTidyComment,

                    Laundry_TypesOfChemicalsUsedAreRelevant=a.Laundry_TypesOfChemicalsUsedAreRelevant,
                    Laundry_TypesOfChemicalsUsedAreRelevantComment=a.Laundry_TypesOfChemicalsUsedAreRelevantComment,


                    user = new IdentityUser { UserName = a.user.UserName, Id = a.user.Id }
                }).ToList();
        }
    }
}
