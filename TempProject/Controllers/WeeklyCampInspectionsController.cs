using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using TempProject.DTO;
using TempProject.DTO.ResponseDTO;
using TempProject.Helper;
using TempProject.Models;
using TempProject.Repository;

namespace TempProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeeklyCampInspectionsController : ControllerBase
    {
        public IRepository<WeeklyCampInspection> WeeklyCampInspectionRepo { get; set; }

        public IWeeklyCampInspectionRepository WeeklyCampInspectionRepository { get; set; }

        private readonly Microsoft.AspNetCore.Identity.UserManager<IdentityUser> userManager;


        public WeeklyCampInspectionsController(Microsoft.AspNetCore.Identity.UserManager<IdentityUser> _userManager,
            IRepository<WeeklyCampInspection> _WeeklyCampInspectionRepo,
            IWeeklyCampInspectionRepository _WeeklyCampInspectionRepository)
         
        {
            this.WeeklyCampInspectionRepo   = _WeeklyCampInspectionRepo  ;
            this.WeeklyCampInspectionRepository  = _WeeklyCampInspectionRepository;
            this.userManager = _userManager;
           
        }

        [HttpGet("GetData")]
        public async Task<ResultDTO> GetAllWithData(string UserID, string UserRole)
        {
            ResultDTO result = new ResultDTO();

            try
            {
                if (string.Equals(UserRole, "Admin", StringComparison.OrdinalIgnoreCase))
                {
                    List<WeeklyCampInspection> temp = WeeklyCampInspectionRepository.getall();
                    List<WeeklyCampInspectionsResponseDTO > newTemp = new List<WeeklyCampInspectionsResponseDTO >();
                    foreach (WeeklyCampInspection  weeklyCampInspection   in temp)
                    {
                        WeeklyCampInspectionsResponseDTO weeklyCompInspectionResponseDTO = new WeeklyCampInspectionsResponseDTO();
                        weeklyCompInspectionResponseDTO.Id = weeklyCampInspection.Id;
                        weeklyCompInspectionResponseDTO.RigId = weeklyCampInspection.Rig.Number;
                        weeklyCompInspectionResponseDTO.Date = weeklyCampInspection.Date;
                        weeklyCompInspectionResponseDTO.GeneralBathRooms_AnyLeaksInPiping = weeklyCampInspection.GeneralBathRooms_AnyLeaksInPiping;
                        weeklyCompInspectionResponseDTO.GeneralBathRooms_AnyLeaksInPipingComment = weeklyCampInspection.GeneralBathRooms_AnyLeaksInPipingComment;
                        weeklyCompInspectionResponseDTO.GeneralBathRooms_AreAllDoorsInGoodWorkingOrder = weeklyCampInspection.GeneralBathRooms_AreAllDoorsInGoodWorkingOrder;
                        weeklyCompInspectionResponseDTO.GeneralBathRooms_AreAllDoorsInGoodWorkingOrderComment = weeklyCampInspection.GeneralBathRooms_AreAllDoorsInGoodWorkingOrderComment;
                        weeklyCompInspectionResponseDTO.GeneralBathRooms_AreAllElectricalFixtures = weeklyCampInspection.GeneralBathRooms_AreAllElectricalFixtures;
                        weeklyCompInspectionResponseDTO.GeneralBathRooms_AreAllElectricalFixturesComment = weeklyCampInspection.GeneralBathRooms_AreAllElectricalFixturesComment;
                        weeklyCompInspectionResponseDTO.GeneralBathRooms_IsTheAreaCleanAndTidy = weeklyCampInspection.GeneralBathRooms_IsTheAreaCleanAndTidy;
                        weeklyCompInspectionResponseDTO.GeneralBathRooms_IsTheAreaCleanAndTidyComment = weeklyCampInspection.GeneralBathRooms_IsTheAreaCleanAndTidyComment;

                        weeklyCompInspectionResponseDTO.General_AreParking = weeklyCampInspection.General_AreParking;
                        weeklyCompInspectionResponseDTO.General_AreParkingComment = weeklyCampInspection.General_AreParkingComment;
                        weeklyCompInspectionResponseDTO.General_IsGenerator = weeklyCampInspection.General_IsGenerator;
                        weeklyCompInspectionResponseDTO.General_IsGeneratorComment = weeklyCampInspection.General_IsGeneratorComment;
                        weeklyCompInspectionResponseDTO.General_IsCampSite = weeklyCampInspection.General_IsCampSite;
                        weeklyCompInspectionResponseDTO.General_IsCampSiteComment = weeklyCampInspection.General_IsCampSiteComment;
                        weeklyCompInspectionResponseDTO.General_IsAllRubbish = weeklyCampInspection.General_IsAllRubbish;
                        weeklyCompInspectionResponseDTO.General_IsAllRubbishComment = weeklyCampInspection.General_IsAllRubbishComment;
                        weeklyCompInspectionResponseDTO.General_AreWater = weeklyCampInspection.General_AreWater;
                        weeklyCompInspectionResponseDTO.General_AreWaterComment = weeklyCampInspection.General_AreWaterComment;

                        weeklyCompInspectionResponseDTO.General_WhatIsGeneralOpinion = weeklyCampInspection.General_WhatIsGeneralOpinion;
                        weeklyCompInspectionResponseDTO.General_WhatIsGeneralOpinionComment = weeklyCampInspection.General_WhatIsGeneralOpinionComment;

                        weeklyCompInspectionResponseDTO.Galley_AreAllAppliancesWorking = weeklyCampInspection.Galley_AreAllAppliancesWorking;
                        weeklyCompInspectionResponseDTO.Galley_AreAllAppliancesWorkingComment = weeklyCampInspection.Galley_AreAllAppliancesWorkingComment;
                        weeklyCompInspectionResponseDTO.Galley_AreDishesAndUtensilsClean = weeklyCampInspection.Galley_AreDishesAndUtensilsClean;
                        weeklyCompInspectionResponseDTO.Galley_AreDishesAndUtensilsCleanComment = weeklyCampInspection.Galley_AreDishesAndUtensilsCleanComment;
                        weeklyCompInspectionResponseDTO.Galley_IsTheGalleyAreaClean = weeklyCampInspection.Galley_IsTheGalleyAreaClean;
                        weeklyCompInspectionResponseDTO.Galley_IsTheGalleyAreaCleanComment = weeklyCampInspection.Galley_IsTheGalleyAreaCleanComment;
                        weeklyCompInspectionResponseDTO.Galley_IsThereWnyWaterLeaks = weeklyCampInspection.Galley_IsThereWnyWaterLeaks;
                        weeklyCompInspectionResponseDTO.Galley_IsThereWnyWaterLeaksComment = weeklyCampInspection.Galley_IsThereWnyWaterLeaksComment;
                        weeklyCompInspectionResponseDTO.Galley_WhatTheConditionOfTheChipPanAndfoodOil = weeklyCampInspection.Galley_WhatTheConditionOfTheChipPanAndfoodOil;
                        weeklyCompInspectionResponseDTO.Galley_WhatTheConditionOfTheChipPanAndfoodOilComment = weeklyCampInspection.Galley_WhatTheConditionOfTheChipPanAndfoodOilComment;
                        weeklyCompInspectionResponseDTO.Galley_WhenWasExhaustFans = weeklyCampInspection.Galley_WhenWasExhaustFans;
                        weeklyCompInspectionResponseDTO.Galley_WhenWasExhaustFansComment = weeklyCampInspection.Galley_WhenWasExhaustFansComment;

                        weeklyCompInspectionResponseDTO.Safety_AreFireEmergency = weeklyCampInspection.Safety_AreFireEmergency;
                        weeklyCompInspectionResponseDTO.Safety_AreFireEmergencyComment = weeklyCampInspection.Safety_AreFireEmergencyComment;
                        weeklyCompInspectionResponseDTO.Safety_AreStaffAwareOfFoodHazards = weeklyCampInspection.Safety_AreStaffAwareOfFoodHazards;
                        weeklyCompInspectionResponseDTO.Safety_AreStaffAwareOfFoodHazardsComment = weeklyCampInspection.Safety_AreStaffAwareOfFoodHazardsComment;
                        weeklyCompInspectionResponseDTO.Safety_AreThereAnyPotentialHazards = weeklyCampInspection.Safety_AreThereAnyPotentialHazards;
                        weeklyCompInspectionResponseDTO.Safety_AreThereAnyPotentialHazardsComment = weeklyCampInspection.Safety_AreThereAnyPotentialHazardsComment;
                        weeklyCompInspectionResponseDTO.Safety_AreThereAnyUnsafe = weeklyCampInspection.Safety_AreThereAnyUnsafe;
                        weeklyCompInspectionResponseDTO.Safety_AreThereAnyUnsafeComment = weeklyCampInspection.Safety_AreThereAnyUnsafeComment;
                        weeklyCompInspectionResponseDTO.Safety_DateOfLastCampfireDrill = weeklyCampInspection.Safety_DateOfLastCampfireDrill;
                        weeklyCompInspectionResponseDTO.Safety_DateOfLastCampfireDrillComment = weeklyCampInspection.Safety_DateOfLastCampfireDrillComment;
                        weeklyCompInspectionResponseDTO.Safety_DateOfLastMedicalDrill = weeklyCampInspection.Safety_DateOfLastMedicalDrill;
                        weeklyCompInspectionResponseDTO.Safety_DateOfLastMedicalDrillComment = weeklyCampInspection.Safety_DateOfLastMedicalDrillComment;
                        weeklyCompInspectionResponseDTO.Safety_FirePumpInGoodCondition = weeklyCampInspection.Safety_FirePumpInGoodCondition;
                        weeklyCompInspectionResponseDTO.Safety_FirePumpInGoodConditionComment = weeklyCampInspection.Safety_FirePumpInGoodConditionComment;
                        weeklyCompInspectionResponseDTO.Safety_IsCampEarthing = weeklyCampInspection.Safety_IsCampEarthing;
                        weeklyCompInspectionResponseDTO.Safety_IsCampEarthingComment = weeklyCampInspection.Safety_IsCampEarthingComment;
                        weeklyCompInspectionResponseDTO.Safety_IsTheDiesel = weeklyCampInspection.Safety_IsTheDiesel;
                        weeklyCompInspectionResponseDTO.Safety_IsTheDieselComment = weeklyCampInspection.Safety_IsTheDieselComment;

                        weeklyCompInspectionResponseDTO.Clinic_IsMedicalStockMaintained = weeklyCampInspection.Clinic_IsMedicalStockMaintained;
                        weeklyCompInspectionResponseDTO.Clinic_IsMedicalStockMaintainedComment = weeklyCampInspection.Clinic_IsMedicalStockMaintainedComment;
                        weeklyCompInspectionResponseDTO.Clinic_IsMedicalApparatus = weeklyCampInspection.Clinic_IsMedicalApparatus;
                        weeklyCompInspectionResponseDTO.Clinic_IsMedicalApparatusComment = weeklyCampInspection.Clinic_IsMedicalApparatusComment;
                        weeklyCompInspectionResponseDTO.Clinic_IsMedicalTreatment = weeklyCampInspection.Clinic_IsMedicalTreatment;
                        weeklyCompInspectionResponseDTO.Clinic_IsMedicalTreatmentComment = weeklyCampInspection.Clinic_IsMedicalTreatmentComment;

                        weeklyCompInspectionResponseDTO.Clinic_IsTheClinicCleanAndTidy = weeklyCampInspection.Clinic_IsTheClinicCleanAndTidy;
                        weeklyCompInspectionResponseDTO.Clinic_IsTheClinicCleanAndTidyComment = weeklyCampInspection.Clinic_IsTheClinicCleanAndTidyComment;
                        weeklyCompInspectionResponseDTO.Clinic_RelevantSdsPresent = weeklyCampInspection.Clinic_RelevantSdsPresent;
                        weeklyCompInspectionResponseDTO.Clinic_RelevantSdsPresentComment = weeklyCampInspection.Clinic_RelevantSdsPresentComment;

                        weeklyCompInspectionResponseDTO.Accomodations_AnyLackInCleaning = weeklyCampInspection.Accomodations_AnyLackInCleaning;
                        weeklyCompInspectionResponseDTO.Accomodations_AnyLackInCleaningComment = weeklyCampInspection.Accomodations_AnyLackInCleaningComment;
                        weeklyCompInspectionResponseDTO.Accomodations_AreDoorHingesAndClosures = weeklyCampInspection.Accomodations_AreDoorHingesAndClosures;
                        weeklyCompInspectionResponseDTO.Accomodations_AreDoorHingesAndClosuresComment = weeklyCampInspection.Accomodations_AreDoorHingesAndClosuresComment;
                        weeklyCompInspectionResponseDTO.Accomodations_LockersOfBathroomsAreInstalledWell = weeklyCampInspection.Accomodations_LockersOfBathroomsAreInstalledWell;
                        weeklyCompInspectionResponseDTO.Accomodations_LockersOfBathroomsAreInstalledWellComment = weeklyCampInspection.Accomodations_LockersOfBathroomsAreInstalledWellComment;
                        weeklyCompInspectionResponseDTO.Accomodations_TypesOfCleaningMaterialsUsed = weeklyCampInspection.Accomodations_TypesOfCleaningMaterialsUsed;
                        weeklyCompInspectionResponseDTO.Accomodations_TypesOfCleaningMaterialsUsedComment = weeklyCampInspection.Accomodations_TypesOfCleaningMaterialsUsedComment;

                        weeklyCompInspectionResponseDTO.WaterTanks_AnyWaterLeaks = weeklyCampInspection.WaterTanks_AnyWaterLeaks;
                        weeklyCompInspectionResponseDTO.WaterTanks_AnyWaterLeaksComment = weeklyCampInspection.WaterTanks_AnyWaterLeaksComment;
                        weeklyCompInspectionResponseDTO.WaterTanks_AreWaterTanksHatchesClean = weeklyCampInspection.WaterTanks_AreWaterTanksHatchesClean;
                        weeklyCompInspectionResponseDTO.WaterTanks_AreWaterTanksHatchesCleanComment = weeklyCampInspection.WaterTanks_AreWaterTanksHatchesCleanComment;
                        weeklyCompInspectionResponseDTO.WaterTanks_IsAreaCleanAndTidy = weeklyCampInspection.WaterTanks_IsAreaCleanAndTidy;
                        weeklyCompInspectionResponseDTO.WaterTanks_IsAreaCleanAndTidyComment = weeklyCampInspection.WaterTanks_IsAreaCleanAndTidyComment;
                        weeklyCompInspectionResponseDTO.WaterTanks_WhatIsTheDateOfLastWaterSample = weeklyCampInspection.WaterTanks_WhatIsTheDateOfLastWaterSample;
                        weeklyCompInspectionResponseDTO.WaterTanks_WhatIsTheDateOfLastWaterSampleComment = weeklyCampInspection.WaterTanks_WhatIsTheDateOfLastWaterSampleComment;

                        weeklyCompInspectionResponseDTO.FoodStorage_WhatIsTheGeneralAppearance = weeklyCampInspection.FoodStorage_WhatIsTheGeneralAppearance;
                        weeklyCompInspectionResponseDTO.FoodStorage_WhatIsTheGeneralAppearanceComment = weeklyCampInspection.FoodStorage_WhatIsTheGeneralAppearanceComment;
                        weeklyCompInspectionResponseDTO.FoodStorage_IsThereEnoughDryFood = weeklyCampInspection.FoodStorage_IsThereEnoughDryFood;
                        weeklyCompInspectionResponseDTO.FoodStorage_IsThereEnoughDryFoodComment = weeklyCampInspection.FoodStorage_IsThereEnoughDryFoodComment;
                        weeklyCompInspectionResponseDTO.FoodStorage_IsFoodProperlyStored = weeklyCampInspection.FoodStorage_IsFoodProperlyStored;
                        weeklyCompInspectionResponseDTO.FoodStorage_IsFoodProperlyStoredComment = weeklyCampInspection.FoodStorage_IsFoodProperlyStoredComment;
                        weeklyCompInspectionResponseDTO.FoodStorage_IsFoodProperlyProtectedFromRisk = weeklyCampInspection.FoodStorage_IsFoodProperlyProtectedFromRisk;
                        weeklyCompInspectionResponseDTO.FoodStorage_IsFoodProperlyProtectedFromRiskComment = weeklyCampInspection.FoodStorage_IsFoodProperlyProtectedFromRiskComment;
                        weeklyCompInspectionResponseDTO.FoodStorage_FrozenStoredFood = weeklyCampInspection.FoodStorage_FrozenStoredFood;
                        weeklyCompInspectionResponseDTO.FoodStorage_FrozenStoredFoodComment = weeklyCampInspection.FoodStorage_FrozenStoredFoodComment;
                        weeklyCompInspectionResponseDTO.FoodStorage_AreFrozenFoods = weeklyCampInspection.FoodStorage_AreFrozenFoods;
                        weeklyCompInspectionResponseDTO.FoodStorage_AreFrozenFoodsComment = weeklyCampInspection.FoodStorage_AreFrozenFoodsComment;
                        weeklyCompInspectionResponseDTO.FoodStorage_AreChillerAndFreezerClean = weeklyCampInspection.FoodStorage_AreChillerAndFreezerClean;
                        weeklyCompInspectionResponseDTO.FoodStorage_AreChillerAndFreezerCleanComment = weeklyCampInspection.FoodStorage_AreChillerAndFreezerCleanComment;
                        weeklyCompInspectionResponseDTO.FoodStorage_AreDryFoodsProperlyStored = weeklyCampInspection.FoodStorage_AreDryFoodsProperlyStored;
                        weeklyCompInspectionResponseDTO.FoodStorage_AreDryFoodsProperlyStoredComment = weeklyCampInspection.FoodStorage_AreDryFoodsProperlyStoredComment;

                        weeklyCompInspectionResponseDTO.Laundry_AreAllAppliancesSafety = weeklyCampInspection.Laundry_AreAllAppliancesSafety;
                        weeklyCompInspectionResponseDTO.Laundry_AreAllAppliancesSafetyComment = weeklyCampInspection.Laundry_AreAllAppliancesSafetyComment;
                        weeklyCompInspectionResponseDTO.Laundry_AreAllAppliancesWorking = weeklyCampInspection.Laundry_AreAllAppliancesWorking;
                        weeklyCompInspectionResponseDTO.Laundry_AreAllAppliancesWorkingComment = weeklyCampInspection.Laundry_AreAllAppliancesWorkingComment;
                        weeklyCompInspectionResponseDTO.Laundry_IsLaundryAleanAndTidy = weeklyCampInspection.Laundry_IsLaundryAleanAndTidy;
                        weeklyCompInspectionResponseDTO.Laundry_IsLaundryAleanAndTidyComment = weeklyCampInspection.Laundry_IsLaundryAleanAndTidyComment;
                        weeklyCompInspectionResponseDTO.Laundry_TypesOfChemicalsUsedAreRelevant = weeklyCampInspection.Laundry_TypesOfChemicalsUsedAreRelevant;
                        weeklyCompInspectionResponseDTO.Laundry_TypesOfChemicalsUsedAreRelevantComment = weeklyCampInspection.Laundry_TypesOfChemicalsUsedAreRelevantComment;

                        weeklyCompInspectionResponseDTO.MessHall_AreAllAppliancesWorking = weeklyCampInspection.MessHall_AreAllAppliancesWorking;
                        weeklyCompInspectionResponseDTO.MessHall_AreAllAppliancesWorkingComment = weeklyCampInspection.MessHall_AreAllAppliancesWorkingComment;
                        weeklyCompInspectionResponseDTO.MessHall_AreFlyKillersWorking = weeklyCampInspection.MessHall_AreFlyKillersWorking;
                        weeklyCompInspectionResponseDTO.MessHall_AreFlyKillersWorkingComment = weeklyCampInspection.MessHall_AreFlyKillersWorkingComment;
                        weeklyCompInspectionResponseDTO.MessHall_AreTablesInGoodWorkingCondition = weeklyCampInspection.MessHall_AreTablesInGoodWorkingCondition;
                        weeklyCompInspectionResponseDTO.MessHall_AreTablesInGoodWorkingConditionComment = weeklyCampInspection.MessHall_AreTablesInGoodWorkingConditionComment;
                        weeklyCompInspectionResponseDTO.MessHall_AreWashHandBasins = weeklyCampInspection.MessHall_AreWashHandBasins;
                        weeklyCompInspectionResponseDTO.MessHall_AreWashHandBasinsComment = weeklyCampInspection.MessHall_AreWashHandBasinsComment;
                        weeklyCompInspectionResponseDTO.MessHall_IsMessHallClean = weeklyCampInspection.MessHall_IsMessHallClean;
                        weeklyCompInspectionResponseDTO.MessHall_IsMessHallCleanComment = weeklyCampInspection.MessHall_IsMessHallCleanComment;
                        weeklyCompInspectionResponseDTO.MessHall_RegistersForChangingFoodOil = weeklyCampInspection.MessHall_RegistersForChangingFoodOil;
                        weeklyCompInspectionResponseDTO.MessHall_RegistersForChangingFoodOilComment = weeklyCampInspection.MessHall_RegistersForChangingFoodOilComment;
                        weeklyCompInspectionResponseDTO.MessHall_AllElectricalCables = weeklyCampInspection.MessHall_AllElectricalCables;
                        weeklyCompInspectionResponseDTO.MessHall_AllElectricalCablesComment = weeklyCampInspection.MessHall_AllElectricalCablesComment;


                        weeklyCompInspectionResponseDTO.userName = weeklyCampInspection .user.UserName;
                        weeklyCompInspectionResponseDTO.userID = weeklyCampInspection .user.Id;

                      
                        
                        newTemp.Add(weeklyCompInspectionResponseDTO);
                    }
                   
                    if (newTemp != null)
                    {
                        result.Message = "Success";
                        result.Statescode = 200;
                        result.Data = newTemp;

                        return result;
                    }
                }
                else if (string.Equals(UserRole, "User", StringComparison.OrdinalIgnoreCase))
                {

                    List<WeeklyCampInspection> temp = WeeklyCampInspectionRepository.getall().Where(a => a.user.Id == UserID).ToList();
                    List<WeeklyCampInspectionsResponseDTO> newTemp = new List<WeeklyCampInspectionsResponseDTO>();
                    foreach (WeeklyCampInspection weeklyCampInspection in temp)
                    {
                        WeeklyCampInspectionsResponseDTO weeklyCompInspectionResponseDTO = new WeeklyCampInspectionsResponseDTO();
                        weeklyCompInspectionResponseDTO.Id = weeklyCampInspection.Id;
                        weeklyCompInspectionResponseDTO.RigId = weeklyCampInspection.Rig.Number;
                        weeklyCompInspectionResponseDTO.Date = weeklyCampInspection.Date;
                        weeklyCompInspectionResponseDTO.GeneralBathRooms_AnyLeaksInPiping = weeklyCampInspection.GeneralBathRooms_AnyLeaksInPiping;
                        weeklyCompInspectionResponseDTO.GeneralBathRooms_AnyLeaksInPipingComment = weeklyCampInspection.GeneralBathRooms_AnyLeaksInPipingComment;
                        weeklyCompInspectionResponseDTO.GeneralBathRooms_AreAllDoorsInGoodWorkingOrder = weeklyCampInspection.GeneralBathRooms_AreAllDoorsInGoodWorkingOrder;
                        weeklyCompInspectionResponseDTO.GeneralBathRooms_AreAllDoorsInGoodWorkingOrderComment = weeklyCampInspection.GeneralBathRooms_AreAllDoorsInGoodWorkingOrderComment;
                        weeklyCompInspectionResponseDTO.GeneralBathRooms_AreAllElectricalFixtures = weeklyCampInspection.GeneralBathRooms_AreAllElectricalFixtures;
                        weeklyCompInspectionResponseDTO.GeneralBathRooms_AreAllElectricalFixturesComment = weeklyCampInspection.GeneralBathRooms_AreAllElectricalFixturesComment;
                        weeklyCompInspectionResponseDTO.GeneralBathRooms_IsTheAreaCleanAndTidy = weeklyCampInspection.GeneralBathRooms_IsTheAreaCleanAndTidy;
                        weeklyCompInspectionResponseDTO.GeneralBathRooms_IsTheAreaCleanAndTidyComment = weeklyCampInspection.GeneralBathRooms_IsTheAreaCleanAndTidyComment;

                        weeklyCompInspectionResponseDTO.General_AreParking = weeklyCampInspection.General_AreParking;
                        weeklyCompInspectionResponseDTO.General_AreParkingComment = weeklyCampInspection.General_AreParkingComment;
                        weeklyCompInspectionResponseDTO.General_IsGenerator = weeklyCampInspection.General_IsGenerator;
                        weeklyCompInspectionResponseDTO.General_IsGeneratorComment = weeklyCampInspection.General_IsGeneratorComment;
                        weeklyCompInspectionResponseDTO.General_IsCampSite = weeklyCampInspection.General_IsCampSite;
                        weeklyCompInspectionResponseDTO.General_IsCampSiteComment = weeklyCampInspection.General_IsCampSiteComment;
                        weeklyCompInspectionResponseDTO.General_IsAllRubbish = weeklyCampInspection.General_IsAllRubbish;
                        weeklyCompInspectionResponseDTO.General_IsAllRubbishComment = weeklyCampInspection.General_IsAllRubbishComment;
                        weeklyCompInspectionResponseDTO.General_AreWater = weeklyCampInspection.General_AreWater;
                        weeklyCompInspectionResponseDTO.General_AreWaterComment = weeklyCampInspection.General_AreWaterComment;

                        weeklyCompInspectionResponseDTO.General_WhatIsGeneralOpinion = weeklyCampInspection.General_WhatIsGeneralOpinion;
                        weeklyCompInspectionResponseDTO.General_WhatIsGeneralOpinionComment = weeklyCampInspection.General_WhatIsGeneralOpinionComment;

                        weeklyCompInspectionResponseDTO.Galley_AreAllAppliancesWorking = weeklyCampInspection.Galley_AreAllAppliancesWorking;
                        weeklyCompInspectionResponseDTO.Galley_AreAllAppliancesWorkingComment = weeklyCampInspection.Galley_AreAllAppliancesWorkingComment;
                        weeklyCompInspectionResponseDTO.Galley_AreDishesAndUtensilsClean = weeklyCampInspection.Galley_AreDishesAndUtensilsClean;
                        weeklyCompInspectionResponseDTO.Galley_AreDishesAndUtensilsCleanComment = weeklyCampInspection.Galley_AreDishesAndUtensilsCleanComment;
                        weeklyCompInspectionResponseDTO.Galley_IsTheGalleyAreaClean = weeklyCampInspection.Galley_IsTheGalleyAreaClean;
                        weeklyCompInspectionResponseDTO.Galley_IsTheGalleyAreaCleanComment = weeklyCampInspection.Galley_IsTheGalleyAreaCleanComment;
                        weeklyCompInspectionResponseDTO.Galley_IsThereWnyWaterLeaks = weeklyCampInspection.Galley_IsThereWnyWaterLeaks;
                        weeklyCompInspectionResponseDTO.Galley_IsThereWnyWaterLeaksComment = weeklyCampInspection.Galley_IsThereWnyWaterLeaksComment;
                        weeklyCompInspectionResponseDTO.Galley_WhatTheConditionOfTheChipPanAndfoodOil = weeklyCampInspection.Galley_WhatTheConditionOfTheChipPanAndfoodOil;
                        weeklyCompInspectionResponseDTO.Galley_WhatTheConditionOfTheChipPanAndfoodOilComment = weeklyCampInspection.Galley_WhatTheConditionOfTheChipPanAndfoodOilComment;
                        weeklyCompInspectionResponseDTO.Galley_WhenWasExhaustFans = weeklyCampInspection.Galley_WhenWasExhaustFans;
                        weeklyCompInspectionResponseDTO.Galley_WhenWasExhaustFansComment = weeklyCampInspection.Galley_WhenWasExhaustFansComment;

                        weeklyCompInspectionResponseDTO.Safety_AreFireEmergency = weeklyCampInspection.Safety_AreFireEmergency;
                        weeklyCompInspectionResponseDTO.Safety_AreFireEmergencyComment = weeklyCampInspection.Safety_AreFireEmergencyComment;
                        weeklyCompInspectionResponseDTO.Safety_AreStaffAwareOfFoodHazards = weeklyCampInspection.Safety_AreStaffAwareOfFoodHazards;
                        weeklyCompInspectionResponseDTO.Safety_AreStaffAwareOfFoodHazardsComment = weeklyCampInspection.Safety_AreStaffAwareOfFoodHazardsComment;
                        weeklyCompInspectionResponseDTO.Safety_AreThereAnyPotentialHazards = weeklyCampInspection.Safety_AreThereAnyPotentialHazards;
                        weeklyCompInspectionResponseDTO.Safety_AreThereAnyPotentialHazardsComment = weeklyCampInspection.Safety_AreThereAnyPotentialHazardsComment;
                        weeklyCompInspectionResponseDTO.Safety_AreThereAnyUnsafe = weeklyCampInspection.Safety_AreThereAnyUnsafe;
                        weeklyCompInspectionResponseDTO.Safety_AreThereAnyUnsafeComment = weeklyCampInspection.Safety_AreThereAnyUnsafeComment;
                        weeklyCompInspectionResponseDTO.Safety_DateOfLastCampfireDrill = weeklyCampInspection.Safety_DateOfLastCampfireDrill;
                        weeklyCompInspectionResponseDTO.Safety_DateOfLastCampfireDrillComment = weeklyCampInspection.Safety_DateOfLastCampfireDrillComment;
                        weeklyCompInspectionResponseDTO.Safety_DateOfLastMedicalDrill = weeklyCampInspection.Safety_DateOfLastMedicalDrill;
                        weeklyCompInspectionResponseDTO.Safety_DateOfLastMedicalDrillComment = weeklyCampInspection.Safety_DateOfLastMedicalDrillComment;
                        weeklyCompInspectionResponseDTO.Safety_FirePumpInGoodCondition = weeklyCampInspection.Safety_FirePumpInGoodCondition;
                        weeklyCompInspectionResponseDTO.Safety_FirePumpInGoodConditionComment = weeklyCampInspection.Safety_FirePumpInGoodConditionComment;
                        weeklyCompInspectionResponseDTO.Safety_IsCampEarthing = weeklyCampInspection.Safety_IsCampEarthing;
                        weeklyCompInspectionResponseDTO.Safety_IsCampEarthingComment = weeklyCampInspection.Safety_IsCampEarthingComment;
                        weeklyCompInspectionResponseDTO.Safety_IsTheDiesel = weeklyCampInspection.Safety_IsTheDiesel;
                        weeklyCompInspectionResponseDTO.Safety_IsTheDieselComment = weeklyCampInspection.Safety_IsTheDieselComment;

                        weeklyCompInspectionResponseDTO.Clinic_IsMedicalStockMaintained = weeklyCampInspection.Clinic_IsMedicalStockMaintained;
                        weeklyCompInspectionResponseDTO.Clinic_IsMedicalStockMaintainedComment = weeklyCampInspection.Clinic_IsMedicalStockMaintainedComment;
                        weeklyCompInspectionResponseDTO.Clinic_IsMedicalApparatus = weeklyCampInspection.Clinic_IsMedicalApparatus;
                        weeklyCompInspectionResponseDTO.Clinic_IsMedicalApparatusComment = weeklyCampInspection.Clinic_IsMedicalApparatusComment;
                        weeklyCompInspectionResponseDTO.Clinic_IsMedicalTreatment = weeklyCampInspection.Clinic_IsMedicalTreatment;
                        weeklyCompInspectionResponseDTO.Clinic_IsMedicalTreatmentComment = weeklyCampInspection.Clinic_IsMedicalTreatmentComment;

                        weeklyCompInspectionResponseDTO.Clinic_IsTheClinicCleanAndTidy = weeklyCampInspection.Clinic_IsTheClinicCleanAndTidy;
                        weeklyCompInspectionResponseDTO.Clinic_IsTheClinicCleanAndTidyComment = weeklyCampInspection.Clinic_IsTheClinicCleanAndTidyComment;
                        weeklyCompInspectionResponseDTO.Clinic_RelevantSdsPresent = weeklyCampInspection.Clinic_RelevantSdsPresent;
                        weeklyCompInspectionResponseDTO.Clinic_RelevantSdsPresentComment = weeklyCampInspection.Clinic_RelevantSdsPresentComment;

                        weeklyCompInspectionResponseDTO.Accomodations_AnyLackInCleaning = weeklyCampInspection.Accomodations_AnyLackInCleaning;
                        weeklyCompInspectionResponseDTO.Accomodations_AnyLackInCleaningComment = weeklyCampInspection.Accomodations_AnyLackInCleaningComment;
                        weeklyCompInspectionResponseDTO.Accomodations_AreDoorHingesAndClosures = weeklyCampInspection.Accomodations_AreDoorHingesAndClosures;
                        weeklyCompInspectionResponseDTO.Accomodations_AreDoorHingesAndClosuresComment = weeklyCampInspection.Accomodations_AreDoorHingesAndClosuresComment;
                        weeklyCompInspectionResponseDTO.Accomodations_LockersOfBathroomsAreInstalledWell = weeklyCampInspection.Accomodations_LockersOfBathroomsAreInstalledWell;
                        weeklyCompInspectionResponseDTO.Accomodations_LockersOfBathroomsAreInstalledWellComment = weeklyCampInspection.Accomodations_LockersOfBathroomsAreInstalledWellComment;
                        weeklyCompInspectionResponseDTO.Accomodations_TypesOfCleaningMaterialsUsed = weeklyCampInspection.Accomodations_TypesOfCleaningMaterialsUsed;
                        weeklyCompInspectionResponseDTO.Accomodations_TypesOfCleaningMaterialsUsedComment = weeklyCampInspection.Accomodations_TypesOfCleaningMaterialsUsedComment;

                        weeklyCompInspectionResponseDTO.WaterTanks_AnyWaterLeaks = weeklyCampInspection.WaterTanks_AnyWaterLeaks;
                        weeklyCompInspectionResponseDTO.WaterTanks_AnyWaterLeaksComment = weeklyCampInspection.WaterTanks_AnyWaterLeaksComment;
                        weeklyCompInspectionResponseDTO.WaterTanks_AreWaterTanksHatchesClean = weeklyCampInspection.WaterTanks_AreWaterTanksHatchesClean;
                        weeklyCompInspectionResponseDTO.WaterTanks_AreWaterTanksHatchesCleanComment = weeklyCampInspection.WaterTanks_AreWaterTanksHatchesCleanComment;
                        weeklyCompInspectionResponseDTO.WaterTanks_IsAreaCleanAndTidy = weeklyCampInspection.WaterTanks_IsAreaCleanAndTidy;
                        weeklyCompInspectionResponseDTO.WaterTanks_IsAreaCleanAndTidyComment = weeklyCampInspection.WaterTanks_IsAreaCleanAndTidyComment;
                        weeklyCompInspectionResponseDTO.WaterTanks_WhatIsTheDateOfLastWaterSample = weeklyCampInspection.WaterTanks_WhatIsTheDateOfLastWaterSample;
                        weeklyCompInspectionResponseDTO.WaterTanks_WhatIsTheDateOfLastWaterSampleComment = weeklyCampInspection.WaterTanks_WhatIsTheDateOfLastWaterSampleComment;

                        weeklyCompInspectionResponseDTO.FoodStorage_WhatIsTheGeneralAppearance = weeklyCampInspection.FoodStorage_WhatIsTheGeneralAppearance;
                        weeklyCompInspectionResponseDTO.FoodStorage_WhatIsTheGeneralAppearanceComment = weeklyCampInspection.FoodStorage_WhatIsTheGeneralAppearanceComment;
                        weeklyCompInspectionResponseDTO.FoodStorage_IsThereEnoughDryFood = weeklyCampInspection.FoodStorage_IsThereEnoughDryFood;
                        weeklyCompInspectionResponseDTO.FoodStorage_IsThereEnoughDryFoodComment = weeklyCampInspection.FoodStorage_IsThereEnoughDryFoodComment;
                        weeklyCompInspectionResponseDTO.FoodStorage_IsFoodProperlyStored = weeklyCampInspection.FoodStorage_IsFoodProperlyStored;
                        weeklyCompInspectionResponseDTO.FoodStorage_IsFoodProperlyStoredComment = weeklyCampInspection.FoodStorage_IsFoodProperlyStoredComment;
                        weeklyCompInspectionResponseDTO.FoodStorage_IsFoodProperlyProtectedFromRisk = weeklyCampInspection.FoodStorage_IsFoodProperlyProtectedFromRisk;
                        weeklyCompInspectionResponseDTO.FoodStorage_IsFoodProperlyProtectedFromRiskComment = weeklyCampInspection.FoodStorage_IsFoodProperlyProtectedFromRiskComment;
                        weeklyCompInspectionResponseDTO.FoodStorage_FrozenStoredFood = weeklyCampInspection.FoodStorage_FrozenStoredFood;
                        weeklyCompInspectionResponseDTO.FoodStorage_FrozenStoredFoodComment = weeklyCampInspection.FoodStorage_FrozenStoredFoodComment;
                        weeklyCompInspectionResponseDTO.FoodStorage_AreFrozenFoods = weeklyCampInspection.FoodStorage_AreFrozenFoods;
                        weeklyCompInspectionResponseDTO.FoodStorage_AreFrozenFoodsComment = weeklyCampInspection.FoodStorage_AreFrozenFoodsComment;
                        weeklyCompInspectionResponseDTO.FoodStorage_AreChillerAndFreezerClean = weeklyCampInspection.FoodStorage_AreChillerAndFreezerClean;
                        weeklyCompInspectionResponseDTO.FoodStorage_AreChillerAndFreezerCleanComment = weeklyCampInspection.FoodStorage_AreChillerAndFreezerCleanComment;
                        weeklyCompInspectionResponseDTO.FoodStorage_AreDryFoodsProperlyStored = weeklyCampInspection.FoodStorage_AreDryFoodsProperlyStored;
                        weeklyCompInspectionResponseDTO.FoodStorage_AreDryFoodsProperlyStoredComment = weeklyCampInspection.FoodStorage_AreDryFoodsProperlyStoredComment;

                        weeklyCompInspectionResponseDTO.Laundry_AreAllAppliancesSafety = weeklyCampInspection.Laundry_AreAllAppliancesSafety;
                        weeklyCompInspectionResponseDTO.Laundry_AreAllAppliancesSafetyComment = weeklyCampInspection.Laundry_AreAllAppliancesSafetyComment;
                        weeklyCompInspectionResponseDTO.Laundry_AreAllAppliancesWorking = weeklyCampInspection.Laundry_AreAllAppliancesWorking;
                        weeklyCompInspectionResponseDTO.Laundry_AreAllAppliancesWorkingComment = weeklyCampInspection.Laundry_AreAllAppliancesWorkingComment;
                        weeklyCompInspectionResponseDTO.Laundry_IsLaundryAleanAndTidy = weeklyCampInspection.Laundry_IsLaundryAleanAndTidy;
                        weeklyCompInspectionResponseDTO.Laundry_IsLaundryAleanAndTidyComment = weeklyCampInspection.Laundry_IsLaundryAleanAndTidyComment;
                        weeklyCompInspectionResponseDTO.Laundry_TypesOfChemicalsUsedAreRelevant = weeklyCampInspection.Laundry_TypesOfChemicalsUsedAreRelevant;
                        weeklyCompInspectionResponseDTO.Laundry_TypesOfChemicalsUsedAreRelevantComment = weeklyCampInspection.Laundry_TypesOfChemicalsUsedAreRelevantComment;

                        weeklyCompInspectionResponseDTO.MessHall_AreAllAppliancesWorking = weeklyCampInspection.MessHall_AreAllAppliancesWorking;
                        weeklyCompInspectionResponseDTO.MessHall_AreAllAppliancesWorkingComment = weeklyCampInspection.MessHall_AreAllAppliancesWorkingComment;
                        weeklyCompInspectionResponseDTO.MessHall_AreFlyKillersWorking = weeklyCampInspection.MessHall_AreFlyKillersWorking;
                        weeklyCompInspectionResponseDTO.MessHall_AreFlyKillersWorkingComment = weeklyCampInspection.MessHall_AreFlyKillersWorkingComment;
                        weeklyCompInspectionResponseDTO.MessHall_AreTablesInGoodWorkingCondition = weeklyCampInspection.MessHall_AreTablesInGoodWorkingCondition;
                        weeklyCompInspectionResponseDTO.MessHall_AreTablesInGoodWorkingConditionComment = weeklyCampInspection.MessHall_AreTablesInGoodWorkingConditionComment;
                        weeklyCompInspectionResponseDTO.MessHall_AreWashHandBasins = weeklyCampInspection.MessHall_AreWashHandBasins;
                        weeklyCompInspectionResponseDTO.MessHall_AreWashHandBasinsComment = weeklyCampInspection.MessHall_AreWashHandBasinsComment;
                        weeklyCompInspectionResponseDTO.MessHall_IsMessHallClean = weeklyCampInspection.MessHall_IsMessHallClean;
                        weeklyCompInspectionResponseDTO.MessHall_IsMessHallCleanComment = weeklyCampInspection.MessHall_IsMessHallCleanComment;
                        weeklyCompInspectionResponseDTO.MessHall_RegistersForChangingFoodOil = weeklyCampInspection.MessHall_RegistersForChangingFoodOil;
                        weeklyCompInspectionResponseDTO.MessHall_RegistersForChangingFoodOilComment = weeklyCampInspection.MessHall_RegistersForChangingFoodOilComment;
                        weeklyCompInspectionResponseDTO.MessHall_AllElectricalCables = weeklyCampInspection.MessHall_AllElectricalCables;
                        weeklyCompInspectionResponseDTO.MessHall_AllElectricalCablesComment = weeklyCampInspection.MessHall_AllElectricalCablesComment;


                        weeklyCompInspectionResponseDTO.userName = weeklyCampInspection.user.UserName;
                        weeklyCompInspectionResponseDTO.userID = weeklyCampInspection.user.Id;



                        newTemp.Add(weeklyCompInspectionResponseDTO);
                    }

                    if (newTemp != null)
                    {
                        result.Message = "Success";
                        result.Statescode = 200;
                        result.Data = newTemp;

                        return result;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Statescode = 404;
                result.Message = "data not found";
            }
            return result;
        }

        [HttpGet("GetDataForExcel")]
        public ActionResult<ResultDTO> GetDataForExcel(string UserID, string UserRole)
        {
            ResultDTO result = new ResultDTO();
            try
            {
                if (string.Equals(UserRole, "Admin", StringComparison.OrdinalIgnoreCase))
                {
                    List<WeeklyCampInspection> temp = WeeklyCampInspectionRepository.getall();
                    List<WeeklyCampInspectionsExcelDTO > newTemp = new List<WeeklyCampInspectionsExcelDTO>();
                    foreach (WeeklyCampInspection weeklyCampInspection in temp)
                    {
                        WeeklyCampInspectionsExcelDTO  weeklyCompInspectionResponseDTO = new WeeklyCampInspectionsExcelDTO();
                        weeklyCompInspectionResponseDTO.Id = weeklyCampInspection.Id;
                        weeklyCompInspectionResponseDTO.RigId = weeklyCampInspection.Rig.Number;
                        weeklyCompInspectionResponseDTO.Date = weeklyCampInspection.Date;
                        weeklyCompInspectionResponseDTO.GeneralBathRooms_AnyLeaksInPiping = weeklyCampInspection.GeneralBathRooms_AnyLeaksInPiping;
                        weeklyCompInspectionResponseDTO.GeneralBathRooms_AnyLeaksInPipingComment = weeklyCampInspection.GeneralBathRooms_AnyLeaksInPipingComment;
                        weeklyCompInspectionResponseDTO.GeneralBathRooms_AreAllDoorsInGoodWorkingOrder = weeklyCampInspection.GeneralBathRooms_AreAllDoorsInGoodWorkingOrder;
                        weeklyCompInspectionResponseDTO.GeneralBathRooms_AreAllDoorsInGoodWorkingOrderComment = weeklyCampInspection.GeneralBathRooms_AreAllDoorsInGoodWorkingOrderComment;
                        weeklyCompInspectionResponseDTO.GeneralBathRooms_AreAllElectricalFixtures = weeklyCampInspection.GeneralBathRooms_AreAllElectricalFixtures;
                        weeklyCompInspectionResponseDTO.GeneralBathRooms_AreAllElectricalFixturesComment = weeklyCampInspection.GeneralBathRooms_AreAllElectricalFixturesComment;
                        weeklyCompInspectionResponseDTO.GeneralBathRooms_IsTheAreaCleanAndTidy = weeklyCampInspection.GeneralBathRooms_IsTheAreaCleanAndTidy;
                        weeklyCompInspectionResponseDTO.GeneralBathRooms_IsTheAreaCleanAndTidyComment = weeklyCampInspection.GeneralBathRooms_IsTheAreaCleanAndTidyComment;

                        weeklyCompInspectionResponseDTO.General_AreParking = weeklyCampInspection.General_AreParking;
                        weeklyCompInspectionResponseDTO.General_AreParkingComment = weeklyCampInspection.General_AreParkingComment;
                        weeklyCompInspectionResponseDTO.General_IsGenerator = weeklyCampInspection.General_IsGenerator;
                        weeklyCompInspectionResponseDTO.General_IsGeneratorComment = weeklyCampInspection.General_IsGeneratorComment;
                        weeklyCompInspectionResponseDTO.General_IsCampSite = weeklyCampInspection.General_IsCampSite;
                        weeklyCompInspectionResponseDTO.General_IsCampSiteComment = weeklyCampInspection.General_IsCampSiteComment;
                        weeklyCompInspectionResponseDTO.General_IsAllRubbish = weeklyCampInspection.General_IsAllRubbish;
                        weeklyCompInspectionResponseDTO.General_IsAllRubbishComment = weeklyCampInspection.General_IsAllRubbishComment;
                        weeklyCompInspectionResponseDTO.General_AreWater = weeklyCampInspection.General_AreWater;
                        weeklyCompInspectionResponseDTO.General_AreWaterComment = weeklyCampInspection.General_AreWaterComment;
                        weeklyCompInspectionResponseDTO.General_WhatIsGeneralOpinion = weeklyCampInspection.General_WhatIsGeneralOpinion;
                        weeklyCompInspectionResponseDTO.General_WhatIsGeneralOpinionComment = weeklyCampInspection.General_WhatIsGeneralOpinionComment;

                        weeklyCompInspectionResponseDTO.Galley_AreAllAppliancesWorking = weeklyCampInspection.Galley_AreAllAppliancesWorking;
                        weeklyCompInspectionResponseDTO.Galley_AreAllAppliancesWorkingComment = weeklyCampInspection.Galley_AreAllAppliancesWorkingComment;
                        weeklyCompInspectionResponseDTO.Galley_AreDishesAndUtensilsClean = weeklyCampInspection.Galley_AreDishesAndUtensilsClean;
                        weeklyCompInspectionResponseDTO.Galley_AreDishesAndUtensilsCleanComment = weeklyCampInspection.Galley_AreDishesAndUtensilsCleanComment;
                        weeklyCompInspectionResponseDTO.Galley_IsTheGalleyAreaClean = weeklyCampInspection.Galley_IsTheGalleyAreaClean;
                        weeklyCompInspectionResponseDTO.Galley_IsTheGalleyAreaCleanComment = weeklyCampInspection.Galley_IsTheGalleyAreaCleanComment;
                        weeklyCompInspectionResponseDTO.Galley_IsThereWnyWaterLeaks = weeklyCampInspection.Galley_IsThereWnyWaterLeaks;
                        weeklyCompInspectionResponseDTO.Galley_IsThereWnyWaterLeaksComment = weeklyCampInspection.Galley_IsThereWnyWaterLeaksComment;
                        weeklyCompInspectionResponseDTO.Galley_WhatTheConditionOfTheChipPanAndfoodOil = weeklyCampInspection.Galley_WhatTheConditionOfTheChipPanAndfoodOil;
                        weeklyCompInspectionResponseDTO.Galley_WhatTheConditionOfTheChipPanAndfoodOilComment = weeklyCampInspection.Galley_WhatTheConditionOfTheChipPanAndfoodOilComment;
                        weeklyCompInspectionResponseDTO.Galley_WhenWasExhaustFans = weeklyCampInspection.Galley_WhenWasExhaustFans;
                        weeklyCompInspectionResponseDTO.Galley_WhenWasExhaustFansComment = weeklyCampInspection.Galley_WhenWasExhaustFansComment;

                        weeklyCompInspectionResponseDTO.Safety_AreFireEmergency = weeklyCampInspection.Safety_AreFireEmergency;
                        weeklyCompInspectionResponseDTO.Safety_AreFireEmergencyComment = weeklyCampInspection.Safety_AreFireEmergencyComment;
                        weeklyCompInspectionResponseDTO.Safety_AreStaffAwareOfFoodHazards = weeklyCampInspection.Safety_AreStaffAwareOfFoodHazards;
                        weeklyCompInspectionResponseDTO.Safety_AreStaffAwareOfFoodHazardsComment = weeklyCampInspection.Safety_AreStaffAwareOfFoodHazardsComment;
                        weeklyCompInspectionResponseDTO.Safety_AreThereAnyPotentialHazards = weeklyCampInspection.Safety_AreThereAnyPotentialHazards;
                        weeklyCompInspectionResponseDTO.Safety_AreThereAnyPotentialHazardsComment = weeklyCampInspection.Safety_AreThereAnyPotentialHazardsComment;
                        weeklyCompInspectionResponseDTO.Safety_AreThereAnyUnsafe = weeklyCampInspection.Safety_AreThereAnyUnsafe;
                        weeklyCompInspectionResponseDTO.Safety_AreThereAnyUnsafeComment = weeklyCampInspection.Safety_AreThereAnyUnsafeComment;
                        weeklyCompInspectionResponseDTO.Safety_DateOfLastCampfireDrill = weeklyCampInspection.Safety_DateOfLastCampfireDrill;
                        weeklyCompInspectionResponseDTO.Safety_DateOfLastCampfireDrillComment = weeklyCampInspection.Safety_DateOfLastCampfireDrillComment;
                        weeklyCompInspectionResponseDTO.Safety_DateOfLastMedicalDrill = weeklyCampInspection.Safety_DateOfLastMedicalDrill;
                        weeklyCompInspectionResponseDTO.Safety_DateOfLastMedicalDrillComment = weeklyCampInspection.Safety_DateOfLastMedicalDrillComment;
                        weeklyCompInspectionResponseDTO.Safety_FirePumpInGoodCondition = weeklyCampInspection.Safety_FirePumpInGoodCondition;
                        weeklyCompInspectionResponseDTO.Safety_FirePumpInGoodConditionComment = weeklyCampInspection.Safety_FirePumpInGoodConditionComment;
                        weeklyCompInspectionResponseDTO.Safety_IsCampEarthing = weeklyCampInspection.Safety_IsCampEarthing;
                        weeklyCompInspectionResponseDTO.Safety_IsCampEarthingComment = weeklyCampInspection.Safety_IsCampEarthingComment;
                        weeklyCompInspectionResponseDTO.Safety_IsTheDiesel = weeklyCampInspection.Safety_IsTheDiesel;
                        weeklyCompInspectionResponseDTO.Safety_IsTheDieselComment = weeklyCampInspection.Safety_IsTheDieselComment;

                        weeklyCompInspectionResponseDTO.Clinic_IsMedicalStockMaintained = weeklyCampInspection.Clinic_IsMedicalStockMaintained;
                        weeklyCompInspectionResponseDTO.Clinic_IsMedicalStockMaintainedComment = weeklyCampInspection.Clinic_IsMedicalStockMaintainedComment;
                        weeklyCompInspectionResponseDTO.Clinic_IsMedicalApparatus = weeklyCampInspection.Clinic_IsMedicalApparatus;
                        weeklyCompInspectionResponseDTO.Clinic_IsMedicalApparatusComment = weeklyCampInspection.Clinic_IsMedicalApparatusComment;
                        weeklyCompInspectionResponseDTO.Clinic_IsMedicalTreatment = weeklyCampInspection.Clinic_IsMedicalTreatment;
                        weeklyCompInspectionResponseDTO.Clinic_IsMedicalTreatmentComment = weeklyCampInspection.Clinic_IsMedicalTreatmentComment;
                        weeklyCompInspectionResponseDTO.Clinic_IsTheClinicCleanAndTidy = weeklyCampInspection.Clinic_IsTheClinicCleanAndTidy;
                        weeklyCompInspectionResponseDTO.Clinic_IsTheClinicCleanAndTidyComment = weeklyCampInspection.Clinic_IsTheClinicCleanAndTidyComment;
                        weeklyCompInspectionResponseDTO.Clinic_RelevantSdsPresent = weeklyCampInspection.Clinic_RelevantSdsPresent;
                        weeklyCompInspectionResponseDTO.Clinic_RelevantSdsPresentComment = weeklyCampInspection.Clinic_RelevantSdsPresentComment;

                        weeklyCompInspectionResponseDTO.Accomodations_AnyLackInCleaning = weeklyCampInspection.Accomodations_AnyLackInCleaning;
                        weeklyCompInspectionResponseDTO.Accomodations_AnyLackInCleaningComment = weeklyCampInspection.Accomodations_AnyLackInCleaningComment;
                        weeklyCompInspectionResponseDTO.Accomodations_AreDoorHingesAndClosures = weeklyCampInspection.Accomodations_AreDoorHingesAndClosures;
                        weeklyCompInspectionResponseDTO.Accomodations_AreDoorHingesAndClosuresComment = weeklyCampInspection.Accomodations_AreDoorHingesAndClosuresComment;
                        weeklyCompInspectionResponseDTO.Accomodations_LockersOfBathroomsAreInstalledWell = weeklyCampInspection.Accomodations_LockersOfBathroomsAreInstalledWell;
                        weeklyCompInspectionResponseDTO.Accomodations_LockersOfBathroomsAreInstalledWellComment = weeklyCampInspection.Accomodations_LockersOfBathroomsAreInstalledWellComment;
                        weeklyCompInspectionResponseDTO.Accomodations_TypesOfCleaningMaterialsUsed = weeklyCampInspection.Accomodations_TypesOfCleaningMaterialsUsed;
                        weeklyCompInspectionResponseDTO.Accomodations_TypesOfCleaningMaterialsUsedComment = weeklyCampInspection.Accomodations_TypesOfCleaningMaterialsUsedComment;

                        weeklyCompInspectionResponseDTO.WaterTanks_AnyWaterLeaks = weeklyCampInspection.WaterTanks_AnyWaterLeaks;
                        weeklyCompInspectionResponseDTO.WaterTanks_AnyWaterLeaksComment = weeklyCampInspection.WaterTanks_AnyWaterLeaksComment;
                        weeklyCompInspectionResponseDTO.WaterTanks_AreWaterTanksHatchesClean = weeklyCampInspection.WaterTanks_AreWaterTanksHatchesClean;
                        weeklyCompInspectionResponseDTO.WaterTanks_AreWaterTanksHatchesCleanComment = weeklyCampInspection.WaterTanks_AreWaterTanksHatchesCleanComment;
                        weeklyCompInspectionResponseDTO.WaterTanks_IsAreaCleanAndTidy = weeklyCampInspection.WaterTanks_IsAreaCleanAndTidy;
                        weeklyCompInspectionResponseDTO.WaterTanks_IsAreaCleanAndTidyComment = weeklyCampInspection.WaterTanks_IsAreaCleanAndTidyComment;
                        weeklyCompInspectionResponseDTO.WaterTanks_WhatIsTheDateOfLastWaterSample = weeklyCampInspection.WaterTanks_WhatIsTheDateOfLastWaterSample;
                        weeklyCompInspectionResponseDTO.WaterTanks_WhatIsTheDateOfLastWaterSampleComment = weeklyCampInspection.WaterTanks_WhatIsTheDateOfLastWaterSampleComment;

                        weeklyCompInspectionResponseDTO.FoodStorage_WhatIsTheGeneralAppearance = weeklyCampInspection.FoodStorage_WhatIsTheGeneralAppearance;
                        weeklyCompInspectionResponseDTO.FoodStorage_WhatIsTheGeneralAppearanceComment = weeklyCampInspection.FoodStorage_WhatIsTheGeneralAppearanceComment;
                        weeklyCompInspectionResponseDTO.FoodStorage_IsThereEnoughDryFood = weeklyCampInspection.FoodStorage_IsThereEnoughDryFood;
                        weeklyCompInspectionResponseDTO.FoodStorage_IsThereEnoughDryFoodComment = weeklyCampInspection.FoodStorage_IsThereEnoughDryFoodComment;
                        weeklyCompInspectionResponseDTO.FoodStorage_IsFoodProperlyStored = weeklyCampInspection.FoodStorage_IsFoodProperlyStored;
                        weeklyCompInspectionResponseDTO.FoodStorage_IsFoodProperlyStoredComment = weeklyCampInspection.FoodStorage_IsFoodProperlyStoredComment;
                        weeklyCompInspectionResponseDTO.FoodStorage_IsFoodProperlyProtectedFromRisk = weeklyCampInspection.FoodStorage_IsFoodProperlyProtectedFromRisk;
                        weeklyCompInspectionResponseDTO.FoodStorage_IsFoodProperlyProtectedFromRiskComment = weeklyCampInspection.FoodStorage_IsFoodProperlyProtectedFromRiskComment;
                        weeklyCompInspectionResponseDTO.FoodStorage_FrozenStoredFood = weeklyCampInspection.FoodStorage_FrozenStoredFood;
                        weeklyCompInspectionResponseDTO.FoodStorage_FrozenStoredFoodComment = weeklyCampInspection.FoodStorage_FrozenStoredFoodComment;
                        weeklyCompInspectionResponseDTO.FoodStorage_AreFrozenFoods = weeklyCampInspection.FoodStorage_AreFrozenFoods;
                        weeklyCompInspectionResponseDTO.FoodStorage_AreFrozenFoodsComment = weeklyCampInspection.FoodStorage_AreFrozenFoodsComment;
                        weeklyCompInspectionResponseDTO.FoodStorage_AreChillerAndFreezerClean = weeklyCampInspection.FoodStorage_AreChillerAndFreezerClean;
                        weeklyCompInspectionResponseDTO.FoodStorage_AreChillerAndFreezerCleanComment = weeklyCampInspection.FoodStorage_AreChillerAndFreezerCleanComment;
                        weeklyCompInspectionResponseDTO.FoodStorage_AreDryFoodsProperlyStored = weeklyCampInspection.FoodStorage_AreDryFoodsProperlyStored;
                        weeklyCompInspectionResponseDTO.FoodStorage_AreDryFoodsProperlyStoredComment = weeklyCampInspection.FoodStorage_AreDryFoodsProperlyStoredComment;

                        weeklyCompInspectionResponseDTO.Laundry_AreAllAppliancesSafety = weeklyCampInspection.Laundry_AreAllAppliancesSafety;
                        weeklyCompInspectionResponseDTO.Laundry_AreAllAppliancesSafetyComment = weeklyCampInspection.Laundry_AreAllAppliancesSafetyComment;
                        weeklyCompInspectionResponseDTO.Laundry_AreAllAppliancesWorking = weeklyCampInspection.Laundry_AreAllAppliancesWorking;
                        weeklyCompInspectionResponseDTO.Laundry_AreAllAppliancesWorkingComment = weeklyCampInspection.Laundry_AreAllAppliancesWorkingComment;
                        weeklyCompInspectionResponseDTO.Laundry_IsLaundryAleanAndTidy = weeklyCampInspection.Laundry_IsLaundryAleanAndTidy;
                        weeklyCompInspectionResponseDTO.Laundry_IsLaundryAleanAndTidyComment = weeklyCampInspection.Laundry_IsLaundryAleanAndTidyComment;
                        weeklyCompInspectionResponseDTO.Laundry_TypesOfChemicalsUsedAreRelevant = weeklyCampInspection.Laundry_TypesOfChemicalsUsedAreRelevant;
                        weeklyCompInspectionResponseDTO.Laundry_TypesOfChemicalsUsedAreRelevantComment = weeklyCampInspection.Laundry_TypesOfChemicalsUsedAreRelevantComment;

                        weeklyCompInspectionResponseDTO.MessHall_AreAllAppliancesWorking = weeklyCampInspection.MessHall_AreAllAppliancesWorking;
                        weeklyCompInspectionResponseDTO.MessHall_AreAllAppliancesWorkingComment = weeklyCampInspection.MessHall_AreAllAppliancesWorkingComment;
                        weeklyCompInspectionResponseDTO.MessHall_AreFlyKillersWorking = weeklyCampInspection.MessHall_AreFlyKillersWorking;
                        weeklyCompInspectionResponseDTO.MessHall_AreFlyKillersWorkingComment = weeklyCampInspection.MessHall_AreFlyKillersWorkingComment;
                        weeklyCompInspectionResponseDTO.MessHall_AreTablesInGoodWorkingCondition = weeklyCampInspection.MessHall_AreTablesInGoodWorkingCondition;
                        weeklyCompInspectionResponseDTO.MessHall_AreTablesInGoodWorkingConditionComment = weeklyCampInspection.MessHall_AreTablesInGoodWorkingConditionComment;
                        weeklyCompInspectionResponseDTO.MessHall_AreWashHandBasins = weeklyCampInspection.MessHall_AreWashHandBasins;
                        weeklyCompInspectionResponseDTO.MessHall_AreWashHandBasinsComment = weeklyCampInspection.MessHall_AreWashHandBasinsComment;
                        weeklyCompInspectionResponseDTO.MessHall_IsMessHallClean = weeklyCampInspection.MessHall_IsMessHallClean;
                        weeklyCompInspectionResponseDTO.MessHall_IsMessHallCleanComment = weeklyCampInspection.MessHall_IsMessHallCleanComment;
                        weeklyCompInspectionResponseDTO.MessHall_RegistersForChangingFoodOil = weeklyCampInspection.MessHall_RegistersForChangingFoodOil;
                        weeklyCompInspectionResponseDTO.MessHall_RegistersForChangingFoodOilComment = weeklyCampInspection.MessHall_RegistersForChangingFoodOilComment;
                        weeklyCompInspectionResponseDTO.MessHall_AllElectricalCables = weeklyCampInspection.MessHall_AllElectricalCables;
                        weeklyCompInspectionResponseDTO.MessHall_AllElectricalCablesComment = weeklyCampInspection.MessHall_AllElectricalCablesComment;

                        weeklyCompInspectionResponseDTO.userName = weeklyCampInspection.user.UserName;
                       // weeklyCompInspectionResponseDTO.userID = weeklyCampInspection.user.Id;

                        newTemp.Add(weeklyCompInspectionResponseDTO);
                    }

                    if (newTemp != null)
                    {
                        result.Message = "Success";
                        result.Statescode = 200;
                        result.Data = newTemp;

                        return result;
                    }
                }
                else if (string.Equals(UserRole, "User", StringComparison.OrdinalIgnoreCase))
                {
                   
                    List<WeeklyCampInspection> temp = WeeklyCampInspectionRepository.getall().Where(a => a.user.Id == UserID).ToList();
                    List<WeeklyCampInspectionsExcelDTO> newTemp = new List<WeeklyCampInspectionsExcelDTO>();
                    foreach (WeeklyCampInspection weeklyCampInspection in temp)
                    {
                        WeeklyCampInspectionsExcelDTO weeklyCompInspectionResponseDTO = new WeeklyCampInspectionsExcelDTO();
                        weeklyCompInspectionResponseDTO.Id = weeklyCampInspection.Id;
                        weeklyCompInspectionResponseDTO.RigId = weeklyCampInspection.Rig.Number;
                        weeklyCompInspectionResponseDTO.Date = weeklyCampInspection.Date;
                        weeklyCompInspectionResponseDTO.GeneralBathRooms_AnyLeaksInPiping = weeklyCampInspection.GeneralBathRooms_AnyLeaksInPiping;
                        weeklyCompInspectionResponseDTO.GeneralBathRooms_AnyLeaksInPipingComment = weeklyCampInspection.GeneralBathRooms_AnyLeaksInPipingComment;
                        weeklyCompInspectionResponseDTO.GeneralBathRooms_AreAllDoorsInGoodWorkingOrder = weeklyCampInspection.GeneralBathRooms_AreAllDoorsInGoodWorkingOrder;
                        weeklyCompInspectionResponseDTO.GeneralBathRooms_AreAllDoorsInGoodWorkingOrderComment = weeklyCampInspection.GeneralBathRooms_AreAllDoorsInGoodWorkingOrderComment;
                        weeklyCompInspectionResponseDTO.GeneralBathRooms_AreAllElectricalFixtures = weeklyCampInspection.GeneralBathRooms_AreAllElectricalFixtures;
                        weeklyCompInspectionResponseDTO.GeneralBathRooms_AreAllElectricalFixturesComment = weeklyCampInspection.GeneralBathRooms_AreAllElectricalFixturesComment;
                        weeklyCompInspectionResponseDTO.GeneralBathRooms_IsTheAreaCleanAndTidy = weeklyCampInspection.GeneralBathRooms_IsTheAreaCleanAndTidy;
                        weeklyCompInspectionResponseDTO.GeneralBathRooms_IsTheAreaCleanAndTidyComment = weeklyCampInspection.GeneralBathRooms_IsTheAreaCleanAndTidyComment;

                        weeklyCompInspectionResponseDTO.General_AreParking = weeklyCampInspection.General_AreParking;
                        weeklyCompInspectionResponseDTO.General_AreParkingComment = weeklyCampInspection.General_AreParkingComment;
                        weeklyCompInspectionResponseDTO.General_IsGenerator = weeklyCampInspection.General_IsGenerator;
                        weeklyCompInspectionResponseDTO.General_IsGeneratorComment = weeklyCampInspection.General_IsGeneratorComment;
                        weeklyCompInspectionResponseDTO.General_IsCampSite = weeklyCampInspection.General_IsCampSite;
                        weeklyCompInspectionResponseDTO.General_IsCampSiteComment = weeklyCampInspection.General_IsCampSiteComment;
                        weeklyCompInspectionResponseDTO.General_IsAllRubbish = weeklyCampInspection.General_IsAllRubbish;
                        weeklyCompInspectionResponseDTO.General_IsAllRubbishComment = weeklyCampInspection.General_IsAllRubbishComment;
                        weeklyCompInspectionResponseDTO.General_AreWater = weeklyCampInspection.General_AreWater;
                        weeklyCompInspectionResponseDTO.General_AreWaterComment = weeklyCampInspection.General_AreWaterComment;
                        weeklyCompInspectionResponseDTO.General_WhatIsGeneralOpinion = weeklyCampInspection.General_WhatIsGeneralOpinion;
                        weeklyCompInspectionResponseDTO.General_WhatIsGeneralOpinionComment = weeklyCampInspection.General_WhatIsGeneralOpinionComment;

                        weeklyCompInspectionResponseDTO.Galley_AreAllAppliancesWorking = weeklyCampInspection.Galley_AreAllAppliancesWorking;
                        weeklyCompInspectionResponseDTO.Galley_AreAllAppliancesWorkingComment = weeklyCampInspection.Galley_AreAllAppliancesWorkingComment;
                        weeklyCompInspectionResponseDTO.Galley_AreDishesAndUtensilsClean = weeklyCampInspection.Galley_AreDishesAndUtensilsClean;
                        weeklyCompInspectionResponseDTO.Galley_AreDishesAndUtensilsCleanComment = weeklyCampInspection.Galley_AreDishesAndUtensilsCleanComment;
                        weeklyCompInspectionResponseDTO.Galley_IsTheGalleyAreaClean = weeklyCampInspection.Galley_IsTheGalleyAreaClean;
                        weeklyCompInspectionResponseDTO.Galley_IsTheGalleyAreaCleanComment = weeklyCampInspection.Galley_IsTheGalleyAreaCleanComment;
                        weeklyCompInspectionResponseDTO.Galley_IsThereWnyWaterLeaks = weeklyCampInspection.Galley_IsThereWnyWaterLeaks;
                        weeklyCompInspectionResponseDTO.Galley_IsThereWnyWaterLeaksComment = weeklyCampInspection.Galley_IsThereWnyWaterLeaksComment;
                        weeklyCompInspectionResponseDTO.Galley_WhatTheConditionOfTheChipPanAndfoodOil = weeklyCampInspection.Galley_WhatTheConditionOfTheChipPanAndfoodOil;
                        weeklyCompInspectionResponseDTO.Galley_WhatTheConditionOfTheChipPanAndfoodOilComment = weeklyCampInspection.Galley_WhatTheConditionOfTheChipPanAndfoodOilComment;
                        weeklyCompInspectionResponseDTO.Galley_WhenWasExhaustFans = weeklyCampInspection.Galley_WhenWasExhaustFans;
                        weeklyCompInspectionResponseDTO.Galley_WhenWasExhaustFansComment = weeklyCampInspection.Galley_WhenWasExhaustFansComment;

                        weeklyCompInspectionResponseDTO.Safety_AreFireEmergency = weeklyCampInspection.Safety_AreFireEmergency;
                        weeklyCompInspectionResponseDTO.Safety_AreFireEmergencyComment = weeklyCampInspection.Safety_AreFireEmergencyComment;
                        weeklyCompInspectionResponseDTO.Safety_AreStaffAwareOfFoodHazards = weeklyCampInspection.Safety_AreStaffAwareOfFoodHazards;
                        weeklyCompInspectionResponseDTO.Safety_AreStaffAwareOfFoodHazardsComment = weeklyCampInspection.Safety_AreStaffAwareOfFoodHazardsComment;
                        weeklyCompInspectionResponseDTO.Safety_AreThereAnyPotentialHazards = weeklyCampInspection.Safety_AreThereAnyPotentialHazards;
                        weeklyCompInspectionResponseDTO.Safety_AreThereAnyPotentialHazardsComment = weeklyCampInspection.Safety_AreThereAnyPotentialHazardsComment;
                        weeklyCompInspectionResponseDTO.Safety_AreThereAnyUnsafe = weeklyCampInspection.Safety_AreThereAnyUnsafe;
                        weeklyCompInspectionResponseDTO.Safety_AreThereAnyUnsafeComment = weeklyCampInspection.Safety_AreThereAnyUnsafeComment;
                        weeklyCompInspectionResponseDTO.Safety_DateOfLastCampfireDrill = weeklyCampInspection.Safety_DateOfLastCampfireDrill;
                        weeklyCompInspectionResponseDTO.Safety_DateOfLastCampfireDrillComment = weeklyCampInspection.Safety_DateOfLastCampfireDrillComment;
                        weeklyCompInspectionResponseDTO.Safety_DateOfLastMedicalDrill = weeklyCampInspection.Safety_DateOfLastMedicalDrill;
                        weeklyCompInspectionResponseDTO.Safety_DateOfLastMedicalDrillComment = weeklyCampInspection.Safety_DateOfLastMedicalDrillComment;
                        weeklyCompInspectionResponseDTO.Safety_FirePumpInGoodCondition = weeklyCampInspection.Safety_FirePumpInGoodCondition;
                        weeklyCompInspectionResponseDTO.Safety_FirePumpInGoodConditionComment = weeklyCampInspection.Safety_FirePumpInGoodConditionComment;
                        weeklyCompInspectionResponseDTO.Safety_IsCampEarthing = weeklyCampInspection.Safety_IsCampEarthing;
                        weeklyCompInspectionResponseDTO.Safety_IsCampEarthingComment = weeklyCampInspection.Safety_IsCampEarthingComment;
                        weeklyCompInspectionResponseDTO.Safety_IsTheDiesel = weeklyCampInspection.Safety_IsTheDiesel;
                        weeklyCompInspectionResponseDTO.Safety_IsTheDieselComment = weeklyCampInspection.Safety_IsTheDieselComment;

                        weeklyCompInspectionResponseDTO.Clinic_IsMedicalStockMaintained = weeklyCampInspection.Clinic_IsMedicalStockMaintained;
                        weeklyCompInspectionResponseDTO.Clinic_IsMedicalStockMaintainedComment = weeklyCampInspection.Clinic_IsMedicalStockMaintainedComment;
                        weeklyCompInspectionResponseDTO.Clinic_IsMedicalApparatus = weeklyCampInspection.Clinic_IsMedicalApparatus;
                        weeklyCompInspectionResponseDTO.Clinic_IsMedicalApparatusComment = weeklyCampInspection.Clinic_IsMedicalApparatusComment;
                        weeklyCompInspectionResponseDTO.Clinic_IsMedicalTreatment = weeklyCampInspection.Clinic_IsMedicalTreatment;
                        weeklyCompInspectionResponseDTO.Clinic_IsMedicalTreatmentComment = weeklyCampInspection.Clinic_IsMedicalTreatmentComment;
                        weeklyCompInspectionResponseDTO.Clinic_IsTheClinicCleanAndTidy = weeklyCampInspection.Clinic_IsTheClinicCleanAndTidy;
                        weeklyCompInspectionResponseDTO.Clinic_IsTheClinicCleanAndTidyComment = weeklyCampInspection.Clinic_IsTheClinicCleanAndTidyComment;
                        weeklyCompInspectionResponseDTO.Clinic_RelevantSdsPresent = weeklyCampInspection.Clinic_RelevantSdsPresent;
                        weeklyCompInspectionResponseDTO.Clinic_RelevantSdsPresentComment = weeklyCampInspection.Clinic_RelevantSdsPresentComment;

                        weeklyCompInspectionResponseDTO.Accomodations_AnyLackInCleaning = weeklyCampInspection.Accomodations_AnyLackInCleaning;
                        weeklyCompInspectionResponseDTO.Accomodations_AnyLackInCleaningComment = weeklyCampInspection.Accomodations_AnyLackInCleaningComment;
                        weeklyCompInspectionResponseDTO.Accomodations_AreDoorHingesAndClosures = weeklyCampInspection.Accomodations_AreDoorHingesAndClosures;
                        weeklyCompInspectionResponseDTO.Accomodations_AreDoorHingesAndClosuresComment = weeklyCampInspection.Accomodations_AreDoorHingesAndClosuresComment;
                        weeklyCompInspectionResponseDTO.Accomodations_LockersOfBathroomsAreInstalledWell = weeklyCampInspection.Accomodations_LockersOfBathroomsAreInstalledWell;
                        weeklyCompInspectionResponseDTO.Accomodations_LockersOfBathroomsAreInstalledWellComment = weeklyCampInspection.Accomodations_LockersOfBathroomsAreInstalledWellComment;
                        weeklyCompInspectionResponseDTO.Accomodations_TypesOfCleaningMaterialsUsed = weeklyCampInspection.Accomodations_TypesOfCleaningMaterialsUsed;
                        weeklyCompInspectionResponseDTO.Accomodations_TypesOfCleaningMaterialsUsedComment = weeklyCampInspection.Accomodations_TypesOfCleaningMaterialsUsedComment;

                        weeklyCompInspectionResponseDTO.WaterTanks_AnyWaterLeaks = weeklyCampInspection.WaterTanks_AnyWaterLeaks;
                        weeklyCompInspectionResponseDTO.WaterTanks_AnyWaterLeaksComment = weeklyCampInspection.WaterTanks_AnyWaterLeaksComment;
                        weeklyCompInspectionResponseDTO.WaterTanks_AreWaterTanksHatchesClean = weeklyCampInspection.WaterTanks_AreWaterTanksHatchesClean;
                        weeklyCompInspectionResponseDTO.WaterTanks_AreWaterTanksHatchesCleanComment = weeklyCampInspection.WaterTanks_AreWaterTanksHatchesCleanComment;
                        weeklyCompInspectionResponseDTO.WaterTanks_IsAreaCleanAndTidy = weeklyCampInspection.WaterTanks_IsAreaCleanAndTidy;
                        weeklyCompInspectionResponseDTO.WaterTanks_IsAreaCleanAndTidyComment = weeklyCampInspection.WaterTanks_IsAreaCleanAndTidyComment;
                        weeklyCompInspectionResponseDTO.WaterTanks_WhatIsTheDateOfLastWaterSample = weeklyCampInspection.WaterTanks_WhatIsTheDateOfLastWaterSample;
                        weeklyCompInspectionResponseDTO.WaterTanks_WhatIsTheDateOfLastWaterSampleComment = weeklyCampInspection.WaterTanks_WhatIsTheDateOfLastWaterSampleComment;

                        weeklyCompInspectionResponseDTO.FoodStorage_WhatIsTheGeneralAppearance = weeklyCampInspection.FoodStorage_WhatIsTheGeneralAppearance;
                        weeklyCompInspectionResponseDTO.FoodStorage_WhatIsTheGeneralAppearanceComment = weeklyCampInspection.FoodStorage_WhatIsTheGeneralAppearanceComment;
                        weeklyCompInspectionResponseDTO.FoodStorage_IsThereEnoughDryFood = weeklyCampInspection.FoodStorage_IsThereEnoughDryFood;
                        weeklyCompInspectionResponseDTO.FoodStorage_IsThereEnoughDryFoodComment = weeklyCampInspection.FoodStorage_IsThereEnoughDryFoodComment;
                        weeklyCompInspectionResponseDTO.FoodStorage_IsFoodProperlyStored = weeklyCampInspection.FoodStorage_IsFoodProperlyStored;
                        weeklyCompInspectionResponseDTO.FoodStorage_IsFoodProperlyStoredComment = weeklyCampInspection.FoodStorage_IsFoodProperlyStoredComment;
                        weeklyCompInspectionResponseDTO.FoodStorage_IsFoodProperlyProtectedFromRisk = weeklyCampInspection.FoodStorage_IsFoodProperlyProtectedFromRisk;
                        weeklyCompInspectionResponseDTO.FoodStorage_IsFoodProperlyProtectedFromRiskComment = weeklyCampInspection.FoodStorage_IsFoodProperlyProtectedFromRiskComment;
                        weeklyCompInspectionResponseDTO.FoodStorage_FrozenStoredFood = weeklyCampInspection.FoodStorage_FrozenStoredFood;
                        weeklyCompInspectionResponseDTO.FoodStorage_FrozenStoredFoodComment = weeklyCampInspection.FoodStorage_FrozenStoredFoodComment;
                        weeklyCompInspectionResponseDTO.FoodStorage_AreFrozenFoods = weeklyCampInspection.FoodStorage_AreFrozenFoods;
                        weeklyCompInspectionResponseDTO.FoodStorage_AreFrozenFoodsComment = weeklyCampInspection.FoodStorage_AreFrozenFoodsComment;
                        weeklyCompInspectionResponseDTO.FoodStorage_AreChillerAndFreezerClean = weeklyCampInspection.FoodStorage_AreChillerAndFreezerClean;
                        weeklyCompInspectionResponseDTO.FoodStorage_AreChillerAndFreezerCleanComment = weeklyCampInspection.FoodStorage_AreChillerAndFreezerCleanComment;
                        weeklyCompInspectionResponseDTO.FoodStorage_AreDryFoodsProperlyStored = weeklyCampInspection.FoodStorage_AreDryFoodsProperlyStored;
                        weeklyCompInspectionResponseDTO.FoodStorage_AreDryFoodsProperlyStoredComment = weeklyCampInspection.FoodStorage_AreDryFoodsProperlyStoredComment;

                        weeklyCompInspectionResponseDTO.Laundry_AreAllAppliancesSafety = weeklyCampInspection.Laundry_AreAllAppliancesSafety;
                        weeklyCompInspectionResponseDTO.Laundry_AreAllAppliancesSafetyComment = weeklyCampInspection.Laundry_AreAllAppliancesSafetyComment;
                        weeklyCompInspectionResponseDTO.Laundry_AreAllAppliancesWorking = weeklyCampInspection.Laundry_AreAllAppliancesWorking;
                        weeklyCompInspectionResponseDTO.Laundry_AreAllAppliancesWorkingComment = weeklyCampInspection.Laundry_AreAllAppliancesWorkingComment;
                        weeklyCompInspectionResponseDTO.Laundry_IsLaundryAleanAndTidy = weeklyCampInspection.Laundry_IsLaundryAleanAndTidy;
                        weeklyCompInspectionResponseDTO.Laundry_IsLaundryAleanAndTidyComment = weeklyCampInspection.Laundry_IsLaundryAleanAndTidyComment;
                        weeklyCompInspectionResponseDTO.Laundry_TypesOfChemicalsUsedAreRelevant = weeklyCampInspection.Laundry_TypesOfChemicalsUsedAreRelevant;
                        weeklyCompInspectionResponseDTO.Laundry_TypesOfChemicalsUsedAreRelevantComment = weeklyCampInspection.Laundry_TypesOfChemicalsUsedAreRelevantComment;

                        weeklyCompInspectionResponseDTO.MessHall_AreAllAppliancesWorking = weeklyCampInspection.MessHall_AreAllAppliancesWorking;
                        weeklyCompInspectionResponseDTO.MessHall_AreAllAppliancesWorkingComment = weeklyCampInspection.MessHall_AreAllAppliancesWorkingComment;
                        weeklyCompInspectionResponseDTO.MessHall_AreFlyKillersWorking = weeklyCampInspection.MessHall_AreFlyKillersWorking;
                        weeklyCompInspectionResponseDTO.MessHall_AreFlyKillersWorkingComment = weeklyCampInspection.MessHall_AreFlyKillersWorkingComment;
                        weeklyCompInspectionResponseDTO.MessHall_AreTablesInGoodWorkingCondition = weeklyCampInspection.MessHall_AreTablesInGoodWorkingCondition;
                        weeklyCompInspectionResponseDTO.MessHall_AreTablesInGoodWorkingConditionComment = weeklyCampInspection.MessHall_AreTablesInGoodWorkingConditionComment;
                        weeklyCompInspectionResponseDTO.MessHall_AreWashHandBasins = weeklyCampInspection.MessHall_AreWashHandBasins;
                        weeklyCompInspectionResponseDTO.MessHall_AreWashHandBasinsComment = weeklyCampInspection.MessHall_AreWashHandBasinsComment;
                        weeklyCompInspectionResponseDTO.MessHall_IsMessHallClean = weeklyCampInspection.MessHall_IsMessHallClean;
                        weeklyCompInspectionResponseDTO.MessHall_IsMessHallCleanComment = weeklyCampInspection.MessHall_IsMessHallCleanComment;
                        weeklyCompInspectionResponseDTO.MessHall_RegistersForChangingFoodOil = weeklyCampInspection.MessHall_RegistersForChangingFoodOil;
                        weeklyCompInspectionResponseDTO.MessHall_RegistersForChangingFoodOilComment = weeklyCampInspection.MessHall_RegistersForChangingFoodOilComment;
                        weeklyCompInspectionResponseDTO.MessHall_AllElectricalCables = weeklyCampInspection.MessHall_AllElectricalCables;
                        weeklyCompInspectionResponseDTO.MessHall_AllElectricalCablesComment = weeklyCampInspection.MessHall_AllElectricalCablesComment;

                        weeklyCompInspectionResponseDTO.userName = weeklyCampInspection.user.UserName;
                        //weeklyCompInspectionResponseDTO.userID = weeklyCampInspection.user.Id;



                        newTemp.Add(weeklyCompInspectionResponseDTO);
                    }

                    if (newTemp != null)
                    {
                        result.Message = "Success";
                        result.Statescode = 200;
                        result.Data = newTemp;

                        return result;
                    }

                }

            }
            catch (Exception ex)
            {
                result.Statescode = 404;
                result.Message = "data not found";
            }

            return result;
        }

        [HttpGet("ByPage/{page:int}")]
        public PageResult<WeeklyCampInspectionsResponseDTO> GettAllWeeklyCampInspectionByPage(string UserId, string UserRole, int? page, int pagesize = 10)
        {

            try
            {
                if (string.Equals(UserRole, "Admin", StringComparison.OrdinalIgnoreCase))
                {
                    List<WeeklyCampInspection> temp = WeeklyCampInspectionRepository.getall();
                    List<WeeklyCampInspectionsResponseDTO> newTemp = new List<WeeklyCampInspectionsResponseDTO>();
                    foreach (WeeklyCampInspection weeklyCampInspection in temp)
                    {
                        WeeklyCampInspectionsResponseDTO weeklyCompInspectionResponseDTO = new WeeklyCampInspectionsResponseDTO();
                        weeklyCompInspectionResponseDTO.Id = weeklyCampInspection.Id;
                        weeklyCompInspectionResponseDTO.RigId = weeklyCampInspection.Rig.Number;
                        weeklyCompInspectionResponseDTO.Date = weeklyCampInspection.Date;
                        weeklyCompInspectionResponseDTO.GeneralBathRooms_AnyLeaksInPiping = weeklyCampInspection.GeneralBathRooms_AnyLeaksInPiping;
                        weeklyCompInspectionResponseDTO.GeneralBathRooms_AnyLeaksInPipingComment = weeklyCampInspection.GeneralBathRooms_AnyLeaksInPipingComment;
                        weeklyCompInspectionResponseDTO.GeneralBathRooms_AreAllDoorsInGoodWorkingOrder = weeklyCampInspection.GeneralBathRooms_AreAllDoorsInGoodWorkingOrder;
                        weeklyCompInspectionResponseDTO.GeneralBathRooms_AreAllDoorsInGoodWorkingOrderComment = weeklyCampInspection.GeneralBathRooms_AreAllDoorsInGoodWorkingOrderComment;
                        weeklyCompInspectionResponseDTO.GeneralBathRooms_AreAllElectricalFixtures = weeklyCampInspection.GeneralBathRooms_AreAllElectricalFixtures;
                        weeklyCompInspectionResponseDTO.GeneralBathRooms_AreAllElectricalFixturesComment = weeklyCampInspection.GeneralBathRooms_AreAllElectricalFixturesComment;
                        weeklyCompInspectionResponseDTO.GeneralBathRooms_IsTheAreaCleanAndTidy = weeklyCampInspection.GeneralBathRooms_IsTheAreaCleanAndTidy;
                        weeklyCompInspectionResponseDTO.GeneralBathRooms_IsTheAreaCleanAndTidyComment = weeklyCampInspection.GeneralBathRooms_IsTheAreaCleanAndTidyComment;

                        weeklyCompInspectionResponseDTO.General_AreParking = weeklyCampInspection.General_AreParking;
                        weeklyCompInspectionResponseDTO.General_AreParkingComment = weeklyCampInspection.General_AreParkingComment;
                        weeklyCompInspectionResponseDTO.General_IsGenerator = weeklyCampInspection.General_IsGenerator;
                        weeklyCompInspectionResponseDTO.General_IsGeneratorComment = weeklyCampInspection.General_IsGeneratorComment;
                        weeklyCompInspectionResponseDTO.General_IsCampSite = weeklyCampInspection.General_IsCampSite;
                        weeklyCompInspectionResponseDTO.General_IsCampSiteComment = weeklyCampInspection.General_IsCampSiteComment;
                        weeklyCompInspectionResponseDTO.General_IsAllRubbish = weeklyCampInspection.General_IsAllRubbish;
                        weeklyCompInspectionResponseDTO.General_IsAllRubbishComment = weeklyCampInspection.General_IsAllRubbishComment;
                        weeklyCompInspectionResponseDTO.General_AreWater = weeklyCampInspection.General_AreWater;
                        weeklyCompInspectionResponseDTO.General_AreWaterComment = weeklyCampInspection.General_AreWaterComment;
                        weeklyCompInspectionResponseDTO.General_WhatIsGeneralOpinion = weeklyCampInspection.General_WhatIsGeneralOpinion;
                        weeklyCompInspectionResponseDTO.General_WhatIsGeneralOpinionComment = weeklyCampInspection.General_WhatIsGeneralOpinionComment;

                        weeklyCompInspectionResponseDTO.Galley_AreAllAppliancesWorking = weeklyCampInspection.Galley_AreAllAppliancesWorking;
                        weeklyCompInspectionResponseDTO.Galley_AreAllAppliancesWorkingComment = weeklyCampInspection.Galley_AreAllAppliancesWorkingComment;
                        weeklyCompInspectionResponseDTO.Galley_AreDishesAndUtensilsClean = weeklyCampInspection.Galley_AreDishesAndUtensilsClean;
                        weeklyCompInspectionResponseDTO.Galley_AreDishesAndUtensilsCleanComment = weeklyCampInspection.Galley_AreDishesAndUtensilsCleanComment;
                        weeklyCompInspectionResponseDTO.Galley_IsTheGalleyAreaClean = weeklyCampInspection.Galley_IsTheGalleyAreaClean;
                        weeklyCompInspectionResponseDTO.Galley_IsTheGalleyAreaCleanComment = weeklyCampInspection.Galley_IsTheGalleyAreaCleanComment;
                        weeklyCompInspectionResponseDTO.Galley_IsThereWnyWaterLeaks = weeklyCampInspection.Galley_IsThereWnyWaterLeaks;
                        weeklyCompInspectionResponseDTO.Galley_IsThereWnyWaterLeaksComment = weeklyCampInspection.Galley_IsThereWnyWaterLeaksComment;
                        weeklyCompInspectionResponseDTO.Galley_WhatTheConditionOfTheChipPanAndfoodOil = weeklyCampInspection.Galley_WhatTheConditionOfTheChipPanAndfoodOil;
                        weeklyCompInspectionResponseDTO.Galley_WhatTheConditionOfTheChipPanAndfoodOilComment = weeklyCampInspection.Galley_WhatTheConditionOfTheChipPanAndfoodOilComment;
                        weeklyCompInspectionResponseDTO.Galley_WhenWasExhaustFans = weeklyCampInspection.Galley_WhenWasExhaustFans;
                        weeklyCompInspectionResponseDTO.Galley_WhenWasExhaustFansComment = weeklyCampInspection.Galley_WhenWasExhaustFansComment;

                        weeklyCompInspectionResponseDTO.Safety_AreFireEmergency = weeklyCampInspection.Safety_AreFireEmergency;
                        weeklyCompInspectionResponseDTO.Safety_AreFireEmergencyComment = weeklyCampInspection.Safety_AreFireEmergencyComment;
                        weeklyCompInspectionResponseDTO.Safety_AreStaffAwareOfFoodHazards = weeklyCampInspection.Safety_AreStaffAwareOfFoodHazards;
                        weeklyCompInspectionResponseDTO.Safety_AreStaffAwareOfFoodHazardsComment = weeklyCampInspection.Safety_AreStaffAwareOfFoodHazardsComment;
                        weeklyCompInspectionResponseDTO.Safety_AreThereAnyPotentialHazards = weeklyCampInspection.Safety_AreThereAnyPotentialHazards;
                        weeklyCompInspectionResponseDTO.Safety_AreThereAnyPotentialHazardsComment = weeklyCampInspection.Safety_AreThereAnyPotentialHazardsComment;
                        weeklyCompInspectionResponseDTO.Safety_AreThereAnyUnsafe = weeklyCampInspection.Safety_AreThereAnyUnsafe;
                        weeklyCompInspectionResponseDTO.Safety_AreThereAnyUnsafeComment = weeklyCampInspection.Safety_AreThereAnyUnsafeComment;
                        weeklyCompInspectionResponseDTO.Safety_DateOfLastCampfireDrill = weeklyCampInspection.Safety_DateOfLastCampfireDrill;
                        weeklyCompInspectionResponseDTO.Safety_DateOfLastCampfireDrillComment = weeklyCampInspection.Safety_DateOfLastCampfireDrillComment;
                        weeklyCompInspectionResponseDTO.Safety_DateOfLastMedicalDrill = weeklyCampInspection.Safety_DateOfLastMedicalDrill;
                        weeklyCompInspectionResponseDTO.Safety_DateOfLastMedicalDrillComment = weeklyCampInspection.Safety_DateOfLastMedicalDrillComment;
                        weeklyCompInspectionResponseDTO.Safety_FirePumpInGoodCondition = weeklyCampInspection.Safety_FirePumpInGoodCondition;
                        weeklyCompInspectionResponseDTO.Safety_FirePumpInGoodConditionComment = weeklyCampInspection.Safety_FirePumpInGoodConditionComment;
                        weeklyCompInspectionResponseDTO.Safety_IsCampEarthing = weeklyCampInspection.Safety_IsCampEarthing;
                        weeklyCompInspectionResponseDTO.Safety_IsCampEarthingComment = weeklyCampInspection.Safety_IsCampEarthingComment;
                        weeklyCompInspectionResponseDTO.Safety_IsTheDiesel = weeklyCampInspection.Safety_IsTheDiesel;
                        weeklyCompInspectionResponseDTO.Safety_IsTheDieselComment = weeklyCampInspection.Safety_IsTheDieselComment;

                        weeklyCompInspectionResponseDTO.Clinic_IsMedicalStockMaintained = weeklyCampInspection.Clinic_IsMedicalStockMaintained;
                        weeklyCompInspectionResponseDTO.Clinic_IsMedicalStockMaintainedComment = weeklyCampInspection.Clinic_IsMedicalStockMaintainedComment;
                        weeklyCompInspectionResponseDTO.Clinic_IsMedicalApparatus = weeklyCampInspection.Clinic_IsMedicalApparatus;
                        weeklyCompInspectionResponseDTO.Clinic_IsMedicalApparatusComment = weeklyCampInspection.Clinic_IsMedicalApparatusComment;
                        weeklyCompInspectionResponseDTO.Clinic_IsMedicalTreatment = weeklyCampInspection.Clinic_IsMedicalTreatment;
                        weeklyCompInspectionResponseDTO.Clinic_IsMedicalTreatmentComment = weeklyCampInspection.Clinic_IsMedicalTreatmentComment;
                        weeklyCompInspectionResponseDTO.Clinic_IsTheClinicCleanAndTidy = weeklyCampInspection.Clinic_IsTheClinicCleanAndTidy;
                        weeklyCompInspectionResponseDTO.Clinic_IsTheClinicCleanAndTidyComment = weeklyCampInspection.Clinic_IsTheClinicCleanAndTidyComment;
                        weeklyCompInspectionResponseDTO.Clinic_RelevantSdsPresent = weeklyCampInspection.Clinic_RelevantSdsPresent;
                        weeklyCompInspectionResponseDTO.Clinic_RelevantSdsPresentComment = weeklyCampInspection.Clinic_RelevantSdsPresentComment;

                        weeklyCompInspectionResponseDTO.Accomodations_AnyLackInCleaning = weeklyCampInspection.Accomodations_AnyLackInCleaning;
                        weeklyCompInspectionResponseDTO.Accomodations_AnyLackInCleaningComment = weeklyCampInspection.Accomodations_AnyLackInCleaningComment;
                        weeklyCompInspectionResponseDTO.Accomodations_AreDoorHingesAndClosures = weeklyCampInspection.Accomodations_AreDoorHingesAndClosures;
                        weeklyCompInspectionResponseDTO.Accomodations_AreDoorHingesAndClosuresComment = weeklyCampInspection.Accomodations_AreDoorHingesAndClosuresComment;
                        weeklyCompInspectionResponseDTO.Accomodations_LockersOfBathroomsAreInstalledWell = weeklyCampInspection.Accomodations_LockersOfBathroomsAreInstalledWell;
                        weeklyCompInspectionResponseDTO.Accomodations_LockersOfBathroomsAreInstalledWellComment = weeklyCampInspection.Accomodations_LockersOfBathroomsAreInstalledWellComment;
                        weeklyCompInspectionResponseDTO.Accomodations_TypesOfCleaningMaterialsUsed = weeklyCampInspection.Accomodations_TypesOfCleaningMaterialsUsed;
                        weeklyCompInspectionResponseDTO.Accomodations_TypesOfCleaningMaterialsUsedComment = weeklyCampInspection.Accomodations_TypesOfCleaningMaterialsUsedComment;

                        weeklyCompInspectionResponseDTO.WaterTanks_AnyWaterLeaks = weeklyCampInspection.WaterTanks_AnyWaterLeaks;
                        weeklyCompInspectionResponseDTO.WaterTanks_AnyWaterLeaksComment = weeklyCampInspection.WaterTanks_AnyWaterLeaksComment;
                        weeklyCompInspectionResponseDTO.WaterTanks_AreWaterTanksHatchesClean = weeklyCampInspection.WaterTanks_AreWaterTanksHatchesClean;
                        weeklyCompInspectionResponseDTO.WaterTanks_AreWaterTanksHatchesCleanComment = weeklyCampInspection.WaterTanks_AreWaterTanksHatchesCleanComment;
                        weeklyCompInspectionResponseDTO.WaterTanks_IsAreaCleanAndTidy = weeklyCampInspection.WaterTanks_IsAreaCleanAndTidy;
                        weeklyCompInspectionResponseDTO.WaterTanks_IsAreaCleanAndTidyComment = weeklyCampInspection.WaterTanks_IsAreaCleanAndTidyComment;
                        weeklyCompInspectionResponseDTO.WaterTanks_WhatIsTheDateOfLastWaterSample = weeklyCampInspection.WaterTanks_WhatIsTheDateOfLastWaterSample;
                        weeklyCompInspectionResponseDTO.WaterTanks_WhatIsTheDateOfLastWaterSampleComment = weeklyCampInspection.WaterTanks_WhatIsTheDateOfLastWaterSampleComment;

                        weeklyCompInspectionResponseDTO.FoodStorage_WhatIsTheGeneralAppearance = weeklyCampInspection.FoodStorage_WhatIsTheGeneralAppearance;
                        weeklyCompInspectionResponseDTO.FoodStorage_WhatIsTheGeneralAppearanceComment = weeklyCampInspection.FoodStorage_WhatIsTheGeneralAppearanceComment;
                        weeklyCompInspectionResponseDTO.FoodStorage_IsThereEnoughDryFood = weeklyCampInspection.FoodStorage_IsThereEnoughDryFood;
                        weeklyCompInspectionResponseDTO.FoodStorage_IsThereEnoughDryFoodComment = weeklyCampInspection.FoodStorage_IsThereEnoughDryFoodComment;
                        weeklyCompInspectionResponseDTO.FoodStorage_IsFoodProperlyStored = weeklyCampInspection.FoodStorage_IsFoodProperlyStored;
                        weeklyCompInspectionResponseDTO.FoodStorage_IsFoodProperlyStoredComment = weeklyCampInspection.FoodStorage_IsFoodProperlyStoredComment;
                        weeklyCompInspectionResponseDTO.FoodStorage_IsFoodProperlyProtectedFromRisk = weeklyCampInspection.FoodStorage_IsFoodProperlyProtectedFromRisk;
                        weeklyCompInspectionResponseDTO.FoodStorage_IsFoodProperlyProtectedFromRiskComment = weeklyCampInspection.FoodStorage_IsFoodProperlyProtectedFromRiskComment;
                        weeklyCompInspectionResponseDTO.FoodStorage_FrozenStoredFood = weeklyCampInspection.FoodStorage_FrozenStoredFood;
                        weeklyCompInspectionResponseDTO.FoodStorage_FrozenStoredFoodComment = weeklyCampInspection.FoodStorage_FrozenStoredFoodComment;
                        weeklyCompInspectionResponseDTO.FoodStorage_AreFrozenFoods = weeklyCampInspection.FoodStorage_AreFrozenFoods;
                        weeklyCompInspectionResponseDTO.FoodStorage_AreFrozenFoodsComment = weeklyCampInspection.FoodStorage_AreFrozenFoodsComment;
                        weeklyCompInspectionResponseDTO.FoodStorage_AreChillerAndFreezerClean = weeklyCampInspection.FoodStorage_AreChillerAndFreezerClean;
                        weeklyCompInspectionResponseDTO.FoodStorage_AreChillerAndFreezerCleanComment = weeklyCampInspection.FoodStorage_AreChillerAndFreezerCleanComment;
                        weeklyCompInspectionResponseDTO.FoodStorage_AreDryFoodsProperlyStored = weeklyCampInspection.FoodStorage_AreDryFoodsProperlyStored;
                        weeklyCompInspectionResponseDTO.FoodStorage_AreDryFoodsProperlyStoredComment = weeklyCampInspection.FoodStorage_AreDryFoodsProperlyStoredComment;

                        weeklyCompInspectionResponseDTO.Laundry_AreAllAppliancesSafety = weeklyCampInspection.Laundry_AreAllAppliancesSafety;
                        weeklyCompInspectionResponseDTO.Laundry_AreAllAppliancesSafetyComment = weeklyCampInspection.Laundry_AreAllAppliancesSafetyComment;
                        weeklyCompInspectionResponseDTO.Laundry_AreAllAppliancesWorking = weeklyCampInspection.Laundry_AreAllAppliancesWorking;
                        weeklyCompInspectionResponseDTO.Laundry_AreAllAppliancesWorkingComment = weeklyCampInspection.Laundry_AreAllAppliancesWorkingComment;
                        weeklyCompInspectionResponseDTO.Laundry_IsLaundryAleanAndTidy = weeklyCampInspection.Laundry_IsLaundryAleanAndTidy;
                        weeklyCompInspectionResponseDTO.Laundry_IsLaundryAleanAndTidyComment = weeklyCampInspection.Laundry_IsLaundryAleanAndTidyComment;
                        weeklyCompInspectionResponseDTO.Laundry_TypesOfChemicalsUsedAreRelevant = weeklyCampInspection.Laundry_TypesOfChemicalsUsedAreRelevant;
                        weeklyCompInspectionResponseDTO.Laundry_TypesOfChemicalsUsedAreRelevantComment = weeklyCampInspection.Laundry_TypesOfChemicalsUsedAreRelevantComment;

                        weeklyCompInspectionResponseDTO.MessHall_AreAllAppliancesWorking = weeklyCampInspection.MessHall_AreAllAppliancesWorking;
                        weeklyCompInspectionResponseDTO.MessHall_AreAllAppliancesWorkingComment = weeklyCampInspection.MessHall_AreAllAppliancesWorkingComment;
                        weeklyCompInspectionResponseDTO.MessHall_AreFlyKillersWorking = weeklyCampInspection.MessHall_AreFlyKillersWorking;
                        weeklyCompInspectionResponseDTO.MessHall_AreFlyKillersWorkingComment = weeklyCampInspection.MessHall_AreFlyKillersWorkingComment;
                        weeklyCompInspectionResponseDTO.MessHall_AreTablesInGoodWorkingCondition = weeklyCampInspection.MessHall_AreTablesInGoodWorkingCondition;
                        weeklyCompInspectionResponseDTO.MessHall_AreTablesInGoodWorkingConditionComment = weeklyCampInspection.MessHall_AreTablesInGoodWorkingConditionComment;
                        weeklyCompInspectionResponseDTO.MessHall_AreWashHandBasins = weeklyCampInspection.MessHall_AreWashHandBasins;
                        weeklyCompInspectionResponseDTO.MessHall_AreWashHandBasinsComment = weeklyCampInspection.MessHall_AreWashHandBasinsComment;
                        weeklyCompInspectionResponseDTO.MessHall_IsMessHallClean = weeklyCampInspection.MessHall_IsMessHallClean;
                        weeklyCompInspectionResponseDTO.MessHall_IsMessHallCleanComment = weeklyCampInspection.MessHall_IsMessHallCleanComment;
                        weeklyCompInspectionResponseDTO.MessHall_RegistersForChangingFoodOil = weeklyCampInspection.MessHall_RegistersForChangingFoodOil;
                        weeklyCompInspectionResponseDTO.MessHall_RegistersForChangingFoodOilComment = weeklyCampInspection.MessHall_RegistersForChangingFoodOilComment;
                        weeklyCompInspectionResponseDTO.MessHall_AllElectricalCables = weeklyCampInspection.MessHall_AllElectricalCables;
                        weeklyCompInspectionResponseDTO.MessHall_AllElectricalCablesComment = weeklyCampInspection.MessHall_AllElectricalCablesComment;

                        weeklyCompInspectionResponseDTO.userName = weeklyCampInspection.user.UserName;
                        weeklyCompInspectionResponseDTO.userID = weeklyCampInspection.user.Id;



                        newTemp.Add(weeklyCompInspectionResponseDTO);
                   
                    }

                    float countDetails = WeeklyCampInspectionRepository .getall().Count();
                    var result = new PageResult<WeeklyCampInspectionsResponseDTO>
                    {
                        Count = (int)Math.Ceiling(countDetails / pagesize),
                        PageIndex = page ?? 1,
                        PageSize = pagesize,
                        Items = newTemp.Skip((page - 1 ?? 0) * pagesize).Take(pagesize).ToList()
                    };

                    return result;

                }
                else if (string.Equals(UserRole, "User", StringComparison.OrdinalIgnoreCase))
                {
        
                    List<WeeklyCampInspection> temp = WeeklyCampInspectionRepository.getall().Where(a => a.user.Id == UserId).ToList();
                    List<WeeklyCampInspectionsResponseDTO> newTemp = new List<WeeklyCampInspectionsResponseDTO>();
                    foreach (WeeklyCampInspection weeklyCampInspection in temp)
                    {
                        WeeklyCampInspectionsResponseDTO weeklyCompInspectionResponseDTO = new WeeklyCampInspectionsResponseDTO();
                        weeklyCompInspectionResponseDTO.Id = weeklyCampInspection.Id;
                        weeklyCompInspectionResponseDTO.RigId = weeklyCampInspection.Rig.Number;
                        weeklyCompInspectionResponseDTO.Date = weeklyCampInspection.Date;
                        weeklyCompInspectionResponseDTO.GeneralBathRooms_AnyLeaksInPiping = weeklyCampInspection.GeneralBathRooms_AnyLeaksInPiping;
                        weeklyCompInspectionResponseDTO.GeneralBathRooms_AnyLeaksInPipingComment = weeklyCampInspection.GeneralBathRooms_AnyLeaksInPipingComment;
                        weeklyCompInspectionResponseDTO.GeneralBathRooms_AreAllDoorsInGoodWorkingOrder = weeklyCampInspection.GeneralBathRooms_AreAllDoorsInGoodWorkingOrder;
                        weeklyCompInspectionResponseDTO.GeneralBathRooms_AreAllDoorsInGoodWorkingOrderComment = weeklyCampInspection.GeneralBathRooms_AreAllDoorsInGoodWorkingOrderComment;
                        weeklyCompInspectionResponseDTO.GeneralBathRooms_AreAllElectricalFixtures = weeklyCampInspection.GeneralBathRooms_AreAllElectricalFixtures;
                        weeklyCompInspectionResponseDTO.GeneralBathRooms_AreAllElectricalFixturesComment = weeklyCampInspection.GeneralBathRooms_AreAllElectricalFixturesComment;
                        weeklyCompInspectionResponseDTO.GeneralBathRooms_IsTheAreaCleanAndTidy = weeklyCampInspection.GeneralBathRooms_IsTheAreaCleanAndTidy;
                        weeklyCompInspectionResponseDTO.GeneralBathRooms_IsTheAreaCleanAndTidyComment = weeklyCampInspection.GeneralBathRooms_IsTheAreaCleanAndTidyComment;

                        weeklyCompInspectionResponseDTO.General_AreParking = weeklyCampInspection.General_AreParking;
                        weeklyCompInspectionResponseDTO.General_AreParkingComment = weeklyCampInspection.General_AreParkingComment;
                        weeklyCompInspectionResponseDTO.General_IsGenerator = weeklyCampInspection.General_IsGenerator;
                        weeklyCompInspectionResponseDTO.General_IsGeneratorComment = weeklyCampInspection.General_IsGeneratorComment;
                        weeklyCompInspectionResponseDTO.General_IsCampSite = weeklyCampInspection.General_IsCampSite;
                        weeklyCompInspectionResponseDTO.General_IsCampSiteComment = weeklyCampInspection.General_IsCampSiteComment;
                        weeklyCompInspectionResponseDTO.General_IsAllRubbish = weeklyCampInspection.General_IsAllRubbish;
                        weeklyCompInspectionResponseDTO.General_IsAllRubbishComment = weeklyCampInspection.General_IsAllRubbishComment;
                        weeklyCompInspectionResponseDTO.General_AreWater = weeklyCampInspection.General_AreWater;
                        weeklyCompInspectionResponseDTO.General_AreWaterComment = weeklyCampInspection.General_AreWaterComment;
                        weeklyCompInspectionResponseDTO.General_WhatIsGeneralOpinion = weeklyCampInspection.General_WhatIsGeneralOpinion;
                        weeklyCompInspectionResponseDTO.General_WhatIsGeneralOpinionComment = weeklyCampInspection.General_WhatIsGeneralOpinionComment;

                        weeklyCompInspectionResponseDTO.Galley_AreAllAppliancesWorking = weeklyCampInspection.Galley_AreAllAppliancesWorking;
                        weeklyCompInspectionResponseDTO.Galley_AreAllAppliancesWorkingComment = weeklyCampInspection.Galley_AreAllAppliancesWorkingComment;
                        weeklyCompInspectionResponseDTO.Galley_AreDishesAndUtensilsClean = weeklyCampInspection.Galley_AreDishesAndUtensilsClean;
                        weeklyCompInspectionResponseDTO.Galley_AreDishesAndUtensilsCleanComment = weeklyCampInspection.Galley_AreDishesAndUtensilsCleanComment;
                        weeklyCompInspectionResponseDTO.Galley_IsTheGalleyAreaClean = weeklyCampInspection.Galley_IsTheGalleyAreaClean;
                        weeklyCompInspectionResponseDTO.Galley_IsTheGalleyAreaCleanComment = weeklyCampInspection.Galley_IsTheGalleyAreaCleanComment;
                        weeklyCompInspectionResponseDTO.Galley_IsThereWnyWaterLeaks = weeklyCampInspection.Galley_IsThereWnyWaterLeaks;
                        weeklyCompInspectionResponseDTO.Galley_IsThereWnyWaterLeaksComment = weeklyCampInspection.Galley_IsThereWnyWaterLeaksComment;
                        weeklyCompInspectionResponseDTO.Galley_WhatTheConditionOfTheChipPanAndfoodOil = weeklyCampInspection.Galley_WhatTheConditionOfTheChipPanAndfoodOil;
                        weeklyCompInspectionResponseDTO.Galley_WhatTheConditionOfTheChipPanAndfoodOilComment = weeklyCampInspection.Galley_WhatTheConditionOfTheChipPanAndfoodOilComment;
                        weeklyCompInspectionResponseDTO.Galley_WhenWasExhaustFans = weeklyCampInspection.Galley_WhenWasExhaustFans;
                        weeklyCompInspectionResponseDTO.Galley_WhenWasExhaustFansComment = weeklyCampInspection.Galley_WhenWasExhaustFansComment;

                        weeklyCompInspectionResponseDTO.Safety_AreFireEmergency = weeklyCampInspection.Safety_AreFireEmergency;
                        weeklyCompInspectionResponseDTO.Safety_AreFireEmergencyComment = weeklyCampInspection.Safety_AreFireEmergencyComment;
                        weeklyCompInspectionResponseDTO.Safety_AreStaffAwareOfFoodHazards = weeklyCampInspection.Safety_AreStaffAwareOfFoodHazards;
                        weeklyCompInspectionResponseDTO.Safety_AreStaffAwareOfFoodHazardsComment = weeklyCampInspection.Safety_AreStaffAwareOfFoodHazardsComment;
                        weeklyCompInspectionResponseDTO.Safety_AreThereAnyPotentialHazards = weeklyCampInspection.Safety_AreThereAnyPotentialHazards;
                        weeklyCompInspectionResponseDTO.Safety_AreThereAnyPotentialHazardsComment = weeklyCampInspection.Safety_AreThereAnyPotentialHazardsComment;
                        weeklyCompInspectionResponseDTO.Safety_AreThereAnyUnsafe = weeklyCampInspection.Safety_AreThereAnyUnsafe;
                        weeklyCompInspectionResponseDTO.Safety_AreThereAnyUnsafeComment = weeklyCampInspection.Safety_AreThereAnyUnsafeComment;
                        weeklyCompInspectionResponseDTO.Safety_DateOfLastCampfireDrill = weeklyCampInspection.Safety_DateOfLastCampfireDrill;
                        weeklyCompInspectionResponseDTO.Safety_DateOfLastCampfireDrillComment = weeklyCampInspection.Safety_DateOfLastCampfireDrillComment;
                        weeklyCompInspectionResponseDTO.Safety_DateOfLastMedicalDrill = weeklyCampInspection.Safety_DateOfLastMedicalDrill;
                        weeklyCompInspectionResponseDTO.Safety_DateOfLastMedicalDrillComment = weeklyCampInspection.Safety_DateOfLastMedicalDrillComment;
                        weeklyCompInspectionResponseDTO.Safety_FirePumpInGoodCondition = weeklyCampInspection.Safety_FirePumpInGoodCondition;
                        weeklyCompInspectionResponseDTO.Safety_FirePumpInGoodConditionComment = weeklyCampInspection.Safety_FirePumpInGoodConditionComment;
                        weeklyCompInspectionResponseDTO.Safety_IsCampEarthing = weeklyCampInspection.Safety_IsCampEarthing;
                        weeklyCompInspectionResponseDTO.Safety_IsCampEarthingComment = weeklyCampInspection.Safety_IsCampEarthingComment;
                        weeklyCompInspectionResponseDTO.Safety_IsTheDiesel = weeklyCampInspection.Safety_IsTheDiesel;
                        weeklyCompInspectionResponseDTO.Safety_IsTheDieselComment = weeklyCampInspection.Safety_IsTheDieselComment;

                        weeklyCompInspectionResponseDTO.Clinic_IsMedicalStockMaintained = weeklyCampInspection.Clinic_IsMedicalStockMaintained;
                        weeklyCompInspectionResponseDTO.Clinic_IsMedicalStockMaintainedComment = weeklyCampInspection.Clinic_IsMedicalStockMaintainedComment;
                        weeklyCompInspectionResponseDTO.Clinic_IsMedicalApparatus = weeklyCampInspection.Clinic_IsMedicalApparatus;
                        weeklyCompInspectionResponseDTO.Clinic_IsMedicalApparatusComment = weeklyCampInspection.Clinic_IsMedicalApparatusComment;
                        weeklyCompInspectionResponseDTO.Clinic_IsMedicalTreatment = weeklyCampInspection.Clinic_IsMedicalTreatment;
                        weeklyCompInspectionResponseDTO.Clinic_IsMedicalTreatmentComment = weeklyCampInspection.Clinic_IsMedicalTreatmentComment;
                        weeklyCompInspectionResponseDTO.Clinic_IsTheClinicCleanAndTidy = weeklyCampInspection.Clinic_IsTheClinicCleanAndTidy;
                        weeklyCompInspectionResponseDTO.Clinic_IsTheClinicCleanAndTidyComment = weeklyCampInspection.Clinic_IsTheClinicCleanAndTidyComment;
                        weeklyCompInspectionResponseDTO.Clinic_RelevantSdsPresent = weeklyCampInspection.Clinic_RelevantSdsPresent;
                        weeklyCompInspectionResponseDTO.Clinic_RelevantSdsPresentComment = weeklyCampInspection.Clinic_RelevantSdsPresentComment;

                        weeklyCompInspectionResponseDTO.Accomodations_AnyLackInCleaning = weeklyCampInspection.Accomodations_AnyLackInCleaning;
                        weeklyCompInspectionResponseDTO.Accomodations_AnyLackInCleaningComment = weeklyCampInspection.Accomodations_AnyLackInCleaningComment;
                        weeklyCompInspectionResponseDTO.Accomodations_AreDoorHingesAndClosures = weeklyCampInspection.Accomodations_AreDoorHingesAndClosures;
                        weeklyCompInspectionResponseDTO.Accomodations_AreDoorHingesAndClosuresComment = weeklyCampInspection.Accomodations_AreDoorHingesAndClosuresComment;
                        weeklyCompInspectionResponseDTO.Accomodations_LockersOfBathroomsAreInstalledWell = weeklyCampInspection.Accomodations_LockersOfBathroomsAreInstalledWell;
                        weeklyCompInspectionResponseDTO.Accomodations_LockersOfBathroomsAreInstalledWellComment = weeklyCampInspection.Accomodations_LockersOfBathroomsAreInstalledWellComment;
                        weeklyCompInspectionResponseDTO.Accomodations_TypesOfCleaningMaterialsUsed = weeklyCampInspection.Accomodations_TypesOfCleaningMaterialsUsed;
                        weeklyCompInspectionResponseDTO.Accomodations_TypesOfCleaningMaterialsUsedComment = weeklyCampInspection.Accomodations_TypesOfCleaningMaterialsUsedComment;

                        weeklyCompInspectionResponseDTO.WaterTanks_AnyWaterLeaks = weeklyCampInspection.WaterTanks_AnyWaterLeaks;
                        weeklyCompInspectionResponseDTO.WaterTanks_AnyWaterLeaksComment = weeklyCampInspection.WaterTanks_AnyWaterLeaksComment;
                        weeklyCompInspectionResponseDTO.WaterTanks_AreWaterTanksHatchesClean = weeklyCampInspection.WaterTanks_AreWaterTanksHatchesClean;
                        weeklyCompInspectionResponseDTO.WaterTanks_AreWaterTanksHatchesCleanComment = weeklyCampInspection.WaterTanks_AreWaterTanksHatchesCleanComment;
                        weeklyCompInspectionResponseDTO.WaterTanks_IsAreaCleanAndTidy = weeklyCampInspection.WaterTanks_IsAreaCleanAndTidy;
                        weeklyCompInspectionResponseDTO.WaterTanks_IsAreaCleanAndTidyComment = weeklyCampInspection.WaterTanks_IsAreaCleanAndTidyComment;
                        weeklyCompInspectionResponseDTO.WaterTanks_WhatIsTheDateOfLastWaterSample = weeklyCampInspection.WaterTanks_WhatIsTheDateOfLastWaterSample;
                        weeklyCompInspectionResponseDTO.WaterTanks_WhatIsTheDateOfLastWaterSampleComment = weeklyCampInspection.WaterTanks_WhatIsTheDateOfLastWaterSampleComment;

                        weeklyCompInspectionResponseDTO.FoodStorage_WhatIsTheGeneralAppearance = weeklyCampInspection.FoodStorage_WhatIsTheGeneralAppearance;
                        weeklyCompInspectionResponseDTO.FoodStorage_WhatIsTheGeneralAppearanceComment = weeklyCampInspection.FoodStorage_WhatIsTheGeneralAppearanceComment;
                        weeklyCompInspectionResponseDTO.FoodStorage_IsThereEnoughDryFood = weeklyCampInspection.FoodStorage_IsThereEnoughDryFood;
                        weeklyCompInspectionResponseDTO.FoodStorage_IsThereEnoughDryFoodComment = weeklyCampInspection.FoodStorage_IsThereEnoughDryFoodComment;
                        weeklyCompInspectionResponseDTO.FoodStorage_IsFoodProperlyStored = weeklyCampInspection.FoodStorage_IsFoodProperlyStored;
                        weeklyCompInspectionResponseDTO.FoodStorage_IsFoodProperlyStoredComment = weeklyCampInspection.FoodStorage_IsFoodProperlyStoredComment;
                        weeklyCompInspectionResponseDTO.FoodStorage_IsFoodProperlyProtectedFromRisk = weeklyCampInspection.FoodStorage_IsFoodProperlyProtectedFromRisk;
                        weeklyCompInspectionResponseDTO.FoodStorage_IsFoodProperlyProtectedFromRiskComment = weeklyCampInspection.FoodStorage_IsFoodProperlyProtectedFromRiskComment;
                        weeklyCompInspectionResponseDTO.FoodStorage_FrozenStoredFood = weeklyCampInspection.FoodStorage_FrozenStoredFood;
                        weeklyCompInspectionResponseDTO.FoodStorage_FrozenStoredFoodComment = weeklyCampInspection.FoodStorage_FrozenStoredFoodComment;
                        weeklyCompInspectionResponseDTO.FoodStorage_AreFrozenFoods = weeklyCampInspection.FoodStorage_AreFrozenFoods;
                        weeklyCompInspectionResponseDTO.FoodStorage_AreFrozenFoodsComment = weeklyCampInspection.FoodStorage_AreFrozenFoodsComment;
                        weeklyCompInspectionResponseDTO.FoodStorage_AreChillerAndFreezerClean = weeklyCampInspection.FoodStorage_AreChillerAndFreezerClean;
                        weeklyCompInspectionResponseDTO.FoodStorage_AreChillerAndFreezerCleanComment = weeklyCampInspection.FoodStorage_AreChillerAndFreezerCleanComment;
                        weeklyCompInspectionResponseDTO.FoodStorage_AreDryFoodsProperlyStored = weeklyCampInspection.FoodStorage_AreDryFoodsProperlyStored;
                        weeklyCompInspectionResponseDTO.FoodStorage_AreDryFoodsProperlyStoredComment = weeklyCampInspection.FoodStorage_AreDryFoodsProperlyStoredComment;

                        weeklyCompInspectionResponseDTO.Laundry_AreAllAppliancesSafety = weeklyCampInspection.Laundry_AreAllAppliancesSafety;
                        weeklyCompInspectionResponseDTO.Laundry_AreAllAppliancesSafetyComment = weeklyCampInspection.Laundry_AreAllAppliancesSafetyComment;
                        weeklyCompInspectionResponseDTO.Laundry_AreAllAppliancesWorking = weeklyCampInspection.Laundry_AreAllAppliancesWorking;
                        weeklyCompInspectionResponseDTO.Laundry_AreAllAppliancesWorkingComment = weeklyCampInspection.Laundry_AreAllAppliancesWorkingComment;
                        weeklyCompInspectionResponseDTO.Laundry_IsLaundryAleanAndTidy = weeklyCampInspection.Laundry_IsLaundryAleanAndTidy;
                        weeklyCompInspectionResponseDTO.Laundry_IsLaundryAleanAndTidyComment = weeklyCampInspection.Laundry_IsLaundryAleanAndTidyComment;
                        weeklyCompInspectionResponseDTO.Laundry_TypesOfChemicalsUsedAreRelevant = weeklyCampInspection.Laundry_TypesOfChemicalsUsedAreRelevant;
                        weeklyCompInspectionResponseDTO.Laundry_TypesOfChemicalsUsedAreRelevantComment = weeklyCampInspection.Laundry_TypesOfChemicalsUsedAreRelevantComment;

                        weeklyCompInspectionResponseDTO.MessHall_AreAllAppliancesWorking = weeklyCampInspection.MessHall_AreAllAppliancesWorking;
                        weeklyCompInspectionResponseDTO.MessHall_AreAllAppliancesWorkingComment = weeklyCampInspection.MessHall_AreAllAppliancesWorkingComment;
                        weeklyCompInspectionResponseDTO.MessHall_AreFlyKillersWorking = weeklyCampInspection.MessHall_AreFlyKillersWorking;
                        weeklyCompInspectionResponseDTO.MessHall_AreFlyKillersWorkingComment = weeklyCampInspection.MessHall_AreFlyKillersWorkingComment;
                        weeklyCompInspectionResponseDTO.MessHall_AreTablesInGoodWorkingCondition = weeklyCampInspection.MessHall_AreTablesInGoodWorkingCondition;
                        weeklyCompInspectionResponseDTO.MessHall_AreTablesInGoodWorkingConditionComment = weeklyCampInspection.MessHall_AreTablesInGoodWorkingConditionComment;
                        weeklyCompInspectionResponseDTO.MessHall_AreWashHandBasins = weeklyCampInspection.MessHall_AreWashHandBasins;
                        weeklyCompInspectionResponseDTO.MessHall_AreWashHandBasinsComment = weeklyCampInspection.MessHall_AreWashHandBasinsComment;
                        weeklyCompInspectionResponseDTO.MessHall_IsMessHallClean = weeklyCampInspection.MessHall_IsMessHallClean;
                        weeklyCompInspectionResponseDTO.MessHall_IsMessHallCleanComment = weeklyCampInspection.MessHall_IsMessHallCleanComment;
                        weeklyCompInspectionResponseDTO.MessHall_RegistersForChangingFoodOil = weeklyCampInspection.MessHall_RegistersForChangingFoodOil;
                        weeklyCompInspectionResponseDTO.MessHall_RegistersForChangingFoodOilComment = weeklyCampInspection.MessHall_RegistersForChangingFoodOilComment;
                        weeklyCompInspectionResponseDTO.MessHall_AllElectricalCables = weeklyCampInspection.MessHall_AllElectricalCables;
                        weeklyCompInspectionResponseDTO.MessHall_AllElectricalCablesComment = weeklyCampInspection.MessHall_AllElectricalCablesComment;

                        weeklyCompInspectionResponseDTO.userName = weeklyCampInspection.user.UserName;
                        weeklyCompInspectionResponseDTO.userID = weeklyCampInspection.user.Id;



                        newTemp.Add(weeklyCompInspectionResponseDTO);
                    }

                    float countDetails = WeeklyCampInspectionRepository.getall().Where(a => a.user.Id == UserId).Count();
                    var result = new PageResult<WeeklyCampInspectionsResponseDTO>
                    {
                        Count = (int)Math.Ceiling(countDetails / pagesize),
                        PageIndex = page ?? 1,
                        PageSize = pagesize,
                        Items = newTemp.Skip((page - 1 ?? 0) * pagesize).Take(pagesize).ToList()
                    };

                    return result;
                }
            }
            catch (Exception ex)
            {
                return new PageResult<WeeklyCampInspectionsResponseDTO >();

            }
            return new PageResult<WeeklyCampInspectionsResponseDTO >();
        }

        [HttpGet("GetDataById/{ID:int}")]
        public ActionResult<ResultDTO> GetAllWithDataByID(int ID, string UserId, string UserRole)
        {
            ResultDTO result = new ResultDTO();


            if (string.Equals(UserRole, "Admin", StringComparison.OrdinalIgnoreCase))
            {
                WeeklyCampInspection  temp = WeeklyCampInspectionRepository.getall().FirstOrDefault(a => a.Id == ID);
                if (temp != null)
                {
                    WeeklyCampInspectionsResponseDTO  weeklyCompInspectionResponseDTO = new WeeklyCampInspectionsResponseDTO ();
                    weeklyCompInspectionResponseDTO.Id = temp.Id;
                    weeklyCompInspectionResponseDTO.RigId = temp.RigId;
                    weeklyCompInspectionResponseDTO.Date = temp.Date;
                    weeklyCompInspectionResponseDTO.GeneralBathRooms_AnyLeaksInPiping = temp.GeneralBathRooms_AnyLeaksInPiping;
                    weeklyCompInspectionResponseDTO.GeneralBathRooms_AnyLeaksInPipingComment = temp.GeneralBathRooms_AnyLeaksInPipingComment;
                    weeklyCompInspectionResponseDTO.GeneralBathRooms_AreAllDoorsInGoodWorkingOrder = temp.GeneralBathRooms_AreAllDoorsInGoodWorkingOrder;
                    weeklyCompInspectionResponseDTO.GeneralBathRooms_AreAllDoorsInGoodWorkingOrderComment = temp.GeneralBathRooms_AreAllDoorsInGoodWorkingOrderComment;
                    weeklyCompInspectionResponseDTO.GeneralBathRooms_AreAllElectricalFixtures = temp.GeneralBathRooms_AreAllElectricalFixtures;
                    weeklyCompInspectionResponseDTO.GeneralBathRooms_AreAllElectricalFixturesComment = temp.GeneralBathRooms_AreAllElectricalFixturesComment;
                    weeklyCompInspectionResponseDTO.GeneralBathRooms_IsTheAreaCleanAndTidy = temp.GeneralBathRooms_IsTheAreaCleanAndTidy;
                    weeklyCompInspectionResponseDTO.GeneralBathRooms_IsTheAreaCleanAndTidyComment = temp.GeneralBathRooms_IsTheAreaCleanAndTidyComment;

                    weeklyCompInspectionResponseDTO.General_AreParking = temp.General_AreParking;
                    weeklyCompInspectionResponseDTO.General_AreParkingComment = temp.General_AreParkingComment;
                    weeklyCompInspectionResponseDTO.General_IsGenerator = temp.General_IsGenerator;
                    weeklyCompInspectionResponseDTO.General_IsGeneratorComment = temp.General_IsGeneratorComment;
                    weeklyCompInspectionResponseDTO.General_IsCampSite = temp.General_IsCampSite;
                    weeklyCompInspectionResponseDTO.General_IsCampSiteComment = temp.General_IsCampSiteComment;
                    weeklyCompInspectionResponseDTO.General_IsAllRubbish = temp.General_IsAllRubbish;
                    weeklyCompInspectionResponseDTO.General_IsAllRubbishComment = temp.General_IsAllRubbishComment;
                    weeklyCompInspectionResponseDTO.General_AreWater = temp.General_AreWater;
                    weeklyCompInspectionResponseDTO.General_AreWaterComment = temp.General_AreWaterComment;
                   
                    weeklyCompInspectionResponseDTO.General_WhatIsGeneralOpinion = temp.General_WhatIsGeneralOpinion;
                    weeklyCompInspectionResponseDTO.General_WhatIsGeneralOpinionComment = temp.General_WhatIsGeneralOpinionComment;

                    weeklyCompInspectionResponseDTO.Galley_AreAllAppliancesWorking = temp.Galley_AreAllAppliancesWorking;
                    weeklyCompInspectionResponseDTO.Galley_AreAllAppliancesWorkingComment = temp.Galley_AreAllAppliancesWorkingComment;
                    weeklyCompInspectionResponseDTO.Galley_AreDishesAndUtensilsClean = temp.Galley_AreDishesAndUtensilsClean;
                    weeklyCompInspectionResponseDTO.Galley_AreDishesAndUtensilsCleanComment = temp.Galley_AreDishesAndUtensilsCleanComment;
                    weeklyCompInspectionResponseDTO.Galley_IsTheGalleyAreaClean = temp.Galley_IsTheGalleyAreaClean;
                    weeklyCompInspectionResponseDTO.Galley_IsTheGalleyAreaCleanComment = temp.Galley_IsTheGalleyAreaCleanComment;
                    weeklyCompInspectionResponseDTO.Galley_IsThereWnyWaterLeaks = temp.Galley_IsThereWnyWaterLeaks;
                    weeklyCompInspectionResponseDTO.Galley_IsThereWnyWaterLeaksComment = temp.Galley_IsThereWnyWaterLeaksComment;
                    weeklyCompInspectionResponseDTO.Galley_WhatTheConditionOfTheChipPanAndfoodOil = temp.Galley_WhatTheConditionOfTheChipPanAndfoodOil;
                    weeklyCompInspectionResponseDTO.Galley_WhatTheConditionOfTheChipPanAndfoodOilComment = temp.Galley_WhatTheConditionOfTheChipPanAndfoodOilComment;
                    weeklyCompInspectionResponseDTO.Galley_WhenWasExhaustFans = temp.Galley_WhenWasExhaustFans;
                    weeklyCompInspectionResponseDTO.Galley_WhenWasExhaustFansComment = temp.Galley_WhenWasExhaustFansComment;

                    weeklyCompInspectionResponseDTO.Safety_AreFireEmergency = temp.Safety_AreFireEmergency;
                    weeklyCompInspectionResponseDTO.Safety_AreFireEmergencyComment = temp.Safety_AreFireEmergencyComment;
                    weeklyCompInspectionResponseDTO.Safety_AreStaffAwareOfFoodHazards = temp.Safety_AreStaffAwareOfFoodHazards;
                    weeklyCompInspectionResponseDTO.Safety_AreStaffAwareOfFoodHazardsComment = temp.Safety_AreStaffAwareOfFoodHazardsComment;
                    weeklyCompInspectionResponseDTO.Safety_AreThereAnyPotentialHazards = temp.Safety_AreThereAnyPotentialHazards;
                    weeklyCompInspectionResponseDTO.Safety_AreThereAnyPotentialHazardsComment = temp.Safety_AreThereAnyPotentialHazardsComment;
                    weeklyCompInspectionResponseDTO.Safety_AreThereAnyUnsafe = temp.Safety_AreThereAnyUnsafe;
                    weeklyCompInspectionResponseDTO.Safety_AreThereAnyUnsafeComment = temp.Safety_AreThereAnyUnsafeComment;
                    weeklyCompInspectionResponseDTO.Safety_DateOfLastCampfireDrill = temp.Safety_DateOfLastCampfireDrill;
                    weeklyCompInspectionResponseDTO.Safety_DateOfLastCampfireDrillComment = temp.Safety_DateOfLastCampfireDrillComment;
                    weeklyCompInspectionResponseDTO.Safety_DateOfLastMedicalDrill = temp.Safety_DateOfLastMedicalDrill;
                    weeklyCompInspectionResponseDTO.Safety_DateOfLastMedicalDrillComment = temp.Safety_DateOfLastMedicalDrillComment;
                    weeklyCompInspectionResponseDTO.Safety_FirePumpInGoodCondition = temp.Safety_FirePumpInGoodCondition;
                    weeklyCompInspectionResponseDTO.Safety_FirePumpInGoodConditionComment = temp.Safety_FirePumpInGoodConditionComment;
                    weeklyCompInspectionResponseDTO.Safety_IsCampEarthing = temp.Safety_IsCampEarthing;
                    weeklyCompInspectionResponseDTO.Safety_IsCampEarthingComment = temp.Safety_IsCampEarthingComment;
                    weeklyCompInspectionResponseDTO.Safety_IsTheDiesel = temp.Safety_IsTheDiesel;
                    weeklyCompInspectionResponseDTO.Safety_IsTheDieselComment = temp.Safety_IsTheDieselComment;

                    weeklyCompInspectionResponseDTO.Clinic_IsMedicalStockMaintained = temp.Clinic_IsMedicalStockMaintained;
                    weeklyCompInspectionResponseDTO.Clinic_IsMedicalStockMaintainedComment = temp.Clinic_IsMedicalStockMaintainedComment;
                    weeklyCompInspectionResponseDTO.Clinic_IsMedicalApparatus = temp.Clinic_IsMedicalApparatus;
                    weeklyCompInspectionResponseDTO.Clinic_IsMedicalApparatusComment = temp.Clinic_IsMedicalApparatusComment;
                    weeklyCompInspectionResponseDTO.Clinic_IsMedicalTreatment = temp.Clinic_IsMedicalTreatment;
                    weeklyCompInspectionResponseDTO.Clinic_IsMedicalTreatmentComment = temp.Clinic_IsMedicalTreatmentComment;

                    weeklyCompInspectionResponseDTO.Clinic_IsTheClinicCleanAndTidy = temp.Clinic_IsTheClinicCleanAndTidy;
                    weeklyCompInspectionResponseDTO.Clinic_IsTheClinicCleanAndTidyComment = temp.Clinic_IsTheClinicCleanAndTidyComment;
                    weeklyCompInspectionResponseDTO.Clinic_RelevantSdsPresent = temp.Clinic_RelevantSdsPresent;
                    weeklyCompInspectionResponseDTO.Clinic_RelevantSdsPresentComment = temp.Clinic_RelevantSdsPresentComment;

                    weeklyCompInspectionResponseDTO.Accomodations_AnyLackInCleaning = temp.Accomodations_AnyLackInCleaning;
                    weeklyCompInspectionResponseDTO.Accomodations_AnyLackInCleaningComment = temp.Accomodations_AnyLackInCleaningComment;
                    weeklyCompInspectionResponseDTO.Accomodations_AreDoorHingesAndClosures = temp.Accomodations_AreDoorHingesAndClosures;
                    weeklyCompInspectionResponseDTO.Accomodations_AreDoorHingesAndClosuresComment = temp.Accomodations_AreDoorHingesAndClosuresComment;
                    weeklyCompInspectionResponseDTO.Accomodations_LockersOfBathroomsAreInstalledWell = temp.Accomodations_LockersOfBathroomsAreInstalledWell;
                    weeklyCompInspectionResponseDTO.Accomodations_LockersOfBathroomsAreInstalledWellComment = temp.Accomodations_LockersOfBathroomsAreInstalledWellComment;
                    weeklyCompInspectionResponseDTO.Accomodations_TypesOfCleaningMaterialsUsed = temp.Accomodations_TypesOfCleaningMaterialsUsed;
                    weeklyCompInspectionResponseDTO.Accomodations_TypesOfCleaningMaterialsUsedComment = temp.Accomodations_TypesOfCleaningMaterialsUsedComment;

                    weeklyCompInspectionResponseDTO.WaterTanks_AnyWaterLeaks = temp.WaterTanks_AnyWaterLeaks;
                    weeklyCompInspectionResponseDTO.WaterTanks_AnyWaterLeaksComment = temp.WaterTanks_AnyWaterLeaksComment;
                    weeklyCompInspectionResponseDTO.WaterTanks_AreWaterTanksHatchesClean = temp.WaterTanks_AreWaterTanksHatchesClean;
                    weeklyCompInspectionResponseDTO.WaterTanks_AreWaterTanksHatchesCleanComment = temp.WaterTanks_AreWaterTanksHatchesCleanComment;
                    weeklyCompInspectionResponseDTO.WaterTanks_IsAreaCleanAndTidy = temp.WaterTanks_IsAreaCleanAndTidy;
                    weeklyCompInspectionResponseDTO.WaterTanks_IsAreaCleanAndTidyComment = temp.WaterTanks_IsAreaCleanAndTidyComment;
                    weeklyCompInspectionResponseDTO.WaterTanks_WhatIsTheDateOfLastWaterSample = temp.WaterTanks_WhatIsTheDateOfLastWaterSample;
                    weeklyCompInspectionResponseDTO.WaterTanks_WhatIsTheDateOfLastWaterSampleComment = temp.WaterTanks_WhatIsTheDateOfLastWaterSampleComment;

                    weeklyCompInspectionResponseDTO.FoodStorage_WhatIsTheGeneralAppearance = temp.FoodStorage_WhatIsTheGeneralAppearance;
                    weeklyCompInspectionResponseDTO.FoodStorage_WhatIsTheGeneralAppearanceComment = temp.FoodStorage_WhatIsTheGeneralAppearanceComment;
                    weeklyCompInspectionResponseDTO.FoodStorage_IsThereEnoughDryFood = temp.FoodStorage_IsThereEnoughDryFood;
                    weeklyCompInspectionResponseDTO.FoodStorage_IsThereEnoughDryFoodComment = temp.FoodStorage_IsThereEnoughDryFoodComment;
                    weeklyCompInspectionResponseDTO.FoodStorage_IsFoodProperlyStored = temp.FoodStorage_IsFoodProperlyStored;
                    weeklyCompInspectionResponseDTO.FoodStorage_IsFoodProperlyStoredComment = temp.FoodStorage_IsFoodProperlyStoredComment;
                    weeklyCompInspectionResponseDTO.FoodStorage_IsFoodProperlyProtectedFromRisk = temp.FoodStorage_IsFoodProperlyProtectedFromRisk;
                    weeklyCompInspectionResponseDTO.FoodStorage_IsFoodProperlyProtectedFromRiskComment = temp.FoodStorage_IsFoodProperlyProtectedFromRiskComment;
                    weeklyCompInspectionResponseDTO.FoodStorage_FrozenStoredFood = temp.FoodStorage_FrozenStoredFood;
                    weeklyCompInspectionResponseDTO.FoodStorage_FrozenStoredFoodComment = temp.FoodStorage_FrozenStoredFoodComment;
                    weeklyCompInspectionResponseDTO.FoodStorage_AreFrozenFoods = temp.FoodStorage_AreFrozenFoods;
                    weeklyCompInspectionResponseDTO.FoodStorage_AreFrozenFoodsComment = temp.FoodStorage_AreFrozenFoodsComment;
                    weeklyCompInspectionResponseDTO.FoodStorage_AreChillerAndFreezerClean = temp.FoodStorage_AreChillerAndFreezerClean;
                    weeklyCompInspectionResponseDTO.FoodStorage_AreChillerAndFreezerCleanComment = temp.FoodStorage_AreChillerAndFreezerCleanComment;
                    weeklyCompInspectionResponseDTO.FoodStorage_AreDryFoodsProperlyStored = temp.FoodStorage_AreDryFoodsProperlyStored;
                    weeklyCompInspectionResponseDTO.FoodStorage_AreDryFoodsProperlyStoredComment = temp.FoodStorage_AreDryFoodsProperlyStoredComment;

                    weeklyCompInspectionResponseDTO.Laundry_AreAllAppliancesSafety = temp.Laundry_AreAllAppliancesSafety;
                    weeklyCompInspectionResponseDTO.Laundry_AreAllAppliancesSafetyComment = temp.Laundry_AreAllAppliancesSafetyComment;
                    weeklyCompInspectionResponseDTO.Laundry_AreAllAppliancesWorking = temp.Laundry_AreAllAppliancesWorking;
                    weeklyCompInspectionResponseDTO.Laundry_AreAllAppliancesWorkingComment = temp.Laundry_AreAllAppliancesWorkingComment;
                    weeklyCompInspectionResponseDTO.Laundry_IsLaundryAleanAndTidy = temp.Laundry_IsLaundryAleanAndTidy;
                    weeklyCompInspectionResponseDTO.Laundry_IsLaundryAleanAndTidyComment = temp.Laundry_IsLaundryAleanAndTidyComment;
                    weeklyCompInspectionResponseDTO.Laundry_TypesOfChemicalsUsedAreRelevant = temp.Laundry_TypesOfChemicalsUsedAreRelevant;
                    weeklyCompInspectionResponseDTO.Laundry_TypesOfChemicalsUsedAreRelevantComment = temp.Laundry_TypesOfChemicalsUsedAreRelevantComment;

                    weeklyCompInspectionResponseDTO.MessHall_AreAllAppliancesWorking = temp.MessHall_AreAllAppliancesWorking;
                    weeklyCompInspectionResponseDTO.MessHall_AreAllAppliancesWorkingComment = temp.MessHall_AreAllAppliancesWorkingComment;
                    weeklyCompInspectionResponseDTO.MessHall_AreFlyKillersWorking = temp.MessHall_AreFlyKillersWorking;
                    weeklyCompInspectionResponseDTO.MessHall_AreFlyKillersWorkingComment = temp.MessHall_AreFlyKillersWorkingComment;
                    weeklyCompInspectionResponseDTO.MessHall_AreTablesInGoodWorkingCondition = temp.MessHall_AreTablesInGoodWorkingCondition;
                    weeklyCompInspectionResponseDTO.MessHall_AreTablesInGoodWorkingConditionComment = temp.MessHall_AreTablesInGoodWorkingConditionComment;
                    weeklyCompInspectionResponseDTO.MessHall_AreWashHandBasins = temp.MessHall_AreWashHandBasins;
                    weeklyCompInspectionResponseDTO.MessHall_AreWashHandBasinsComment = temp.MessHall_AreWashHandBasinsComment;
                    weeklyCompInspectionResponseDTO.MessHall_IsMessHallClean = temp.MessHall_IsMessHallClean;
                    weeklyCompInspectionResponseDTO.MessHall_IsMessHallCleanComment = temp.MessHall_IsMessHallCleanComment;
                    weeklyCompInspectionResponseDTO.MessHall_RegistersForChangingFoodOil = temp.MessHall_RegistersForChangingFoodOil;
                    weeklyCompInspectionResponseDTO.MessHall_RegistersForChangingFoodOilComment = temp.MessHall_RegistersForChangingFoodOilComment;
                    weeklyCompInspectionResponseDTO.MessHall_AllElectricalCables = temp.MessHall_AllElectricalCables;
                    weeklyCompInspectionResponseDTO.MessHall_AllElectricalCablesComment = temp.MessHall_AllElectricalCablesComment;

                    weeklyCompInspectionResponseDTO.userName = temp.user.UserName;
                    weeklyCompInspectionResponseDTO.userID = temp.user.Id;



                    if (weeklyCompInspectionResponseDTO != null)
                    {

                        result.Message = "Success";
                        result.Statescode = 200;
                        result.Data = weeklyCompInspectionResponseDTO;

                        return result;
                    }
                }

            }
            else if (string.Equals(UserRole, "User", StringComparison.OrdinalIgnoreCase))
            {
                WeeklyCampInspection   temp = WeeklyCampInspectionRepository.getall().FirstOrDefault(a => a.Id == ID && a.user.Id == UserId);
                if (temp != null)
                {
                    WeeklyCampInspectionsResponseDTO weeklyCompInspectionResponseDTO = new WeeklyCampInspectionsResponseDTO();
                    weeklyCompInspectionResponseDTO.Id = temp.Id;
                    weeklyCompInspectionResponseDTO.RigId = temp.RigId;
                    weeklyCompInspectionResponseDTO.Date = temp.Date;
                    weeklyCompInspectionResponseDTO.GeneralBathRooms_AnyLeaksInPiping = temp.GeneralBathRooms_AnyLeaksInPiping;
                    weeklyCompInspectionResponseDTO.GeneralBathRooms_AnyLeaksInPipingComment = temp.GeneralBathRooms_AnyLeaksInPipingComment;
                    weeklyCompInspectionResponseDTO.GeneralBathRooms_AreAllDoorsInGoodWorkingOrder = temp.GeneralBathRooms_AreAllDoorsInGoodWorkingOrder;
                    weeklyCompInspectionResponseDTO.GeneralBathRooms_AreAllDoorsInGoodWorkingOrderComment = temp.GeneralBathRooms_AreAllDoorsInGoodWorkingOrderComment;
                    weeklyCompInspectionResponseDTO.GeneralBathRooms_AreAllElectricalFixtures = temp.GeneralBathRooms_AreAllElectricalFixtures;
                    weeklyCompInspectionResponseDTO.GeneralBathRooms_AreAllElectricalFixturesComment = temp.GeneralBathRooms_AreAllElectricalFixturesComment;
                    weeklyCompInspectionResponseDTO.GeneralBathRooms_IsTheAreaCleanAndTidy = temp.GeneralBathRooms_IsTheAreaCleanAndTidy;
                    weeklyCompInspectionResponseDTO.GeneralBathRooms_IsTheAreaCleanAndTidyComment = temp.GeneralBathRooms_IsTheAreaCleanAndTidyComment;

                    weeklyCompInspectionResponseDTO.General_AreParking = temp.General_AreParking;
                    weeklyCompInspectionResponseDTO.General_AreParkingComment = temp.General_AreParkingComment;
                    weeklyCompInspectionResponseDTO.General_IsGenerator = temp.General_IsGenerator;
                    weeklyCompInspectionResponseDTO.General_IsGeneratorComment = temp.General_IsGeneratorComment;
                    weeklyCompInspectionResponseDTO.General_IsCampSite = temp.General_IsCampSite;
                    weeklyCompInspectionResponseDTO.General_IsCampSiteComment = temp.General_IsCampSiteComment;
                    weeklyCompInspectionResponseDTO.General_IsAllRubbish = temp.General_IsAllRubbish;
                    weeklyCompInspectionResponseDTO.General_IsAllRubbishComment = temp.General_IsAllRubbishComment;
                    weeklyCompInspectionResponseDTO.General_AreWater = temp.General_AreWater;
                    weeklyCompInspectionResponseDTO.General_AreWaterComment = temp.General_AreWaterComment;

                    weeklyCompInspectionResponseDTO.General_WhatIsGeneralOpinion = temp.General_WhatIsGeneralOpinion;
                    weeklyCompInspectionResponseDTO.General_WhatIsGeneralOpinionComment = temp.General_WhatIsGeneralOpinionComment;

                    weeklyCompInspectionResponseDTO.Galley_AreAllAppliancesWorking = temp.Galley_AreAllAppliancesWorking;
                    weeklyCompInspectionResponseDTO.Galley_AreAllAppliancesWorkingComment = temp.Galley_AreAllAppliancesWorkingComment;
                    weeklyCompInspectionResponseDTO.Galley_AreDishesAndUtensilsClean = temp.Galley_AreDishesAndUtensilsClean;
                    weeklyCompInspectionResponseDTO.Galley_AreDishesAndUtensilsCleanComment = temp.Galley_AreDishesAndUtensilsCleanComment;
                    weeklyCompInspectionResponseDTO.Galley_IsTheGalleyAreaClean = temp.Galley_IsTheGalleyAreaClean;
                    weeklyCompInspectionResponseDTO.Galley_IsTheGalleyAreaCleanComment = temp.Galley_IsTheGalleyAreaCleanComment;
                    weeklyCompInspectionResponseDTO.Galley_IsThereWnyWaterLeaks = temp.Galley_IsThereWnyWaterLeaks;
                    weeklyCompInspectionResponseDTO.Galley_IsThereWnyWaterLeaksComment = temp.Galley_IsThereWnyWaterLeaksComment;
                    weeklyCompInspectionResponseDTO.Galley_WhatTheConditionOfTheChipPanAndfoodOil = temp.Galley_WhatTheConditionOfTheChipPanAndfoodOil;
                    weeklyCompInspectionResponseDTO.Galley_WhatTheConditionOfTheChipPanAndfoodOilComment = temp.Galley_WhatTheConditionOfTheChipPanAndfoodOilComment;
                    weeklyCompInspectionResponseDTO.Galley_WhenWasExhaustFans = temp.Galley_WhenWasExhaustFans;
                    weeklyCompInspectionResponseDTO.Galley_WhenWasExhaustFansComment = temp.Galley_WhenWasExhaustFansComment;

                    weeklyCompInspectionResponseDTO.Safety_AreFireEmergency = temp.Safety_AreFireEmergency;
                    weeklyCompInspectionResponseDTO.Safety_AreFireEmergencyComment = temp.Safety_AreFireEmergencyComment;
                    weeklyCompInspectionResponseDTO.Safety_AreStaffAwareOfFoodHazards = temp.Safety_AreStaffAwareOfFoodHazards;
                    weeklyCompInspectionResponseDTO.Safety_AreStaffAwareOfFoodHazardsComment = temp.Safety_AreStaffAwareOfFoodHazardsComment;
                    weeklyCompInspectionResponseDTO.Safety_AreThereAnyPotentialHazards = temp.Safety_AreThereAnyPotentialHazards;
                    weeklyCompInspectionResponseDTO.Safety_AreThereAnyPotentialHazardsComment = temp.Safety_AreThereAnyPotentialHazardsComment;
                    weeklyCompInspectionResponseDTO.Safety_AreThereAnyUnsafe = temp.Safety_AreThereAnyUnsafe;
                    weeklyCompInspectionResponseDTO.Safety_AreThereAnyUnsafeComment = temp.Safety_AreThereAnyUnsafeComment;
                    weeklyCompInspectionResponseDTO.Safety_DateOfLastCampfireDrill = temp.Safety_DateOfLastCampfireDrill;
                    weeklyCompInspectionResponseDTO.Safety_DateOfLastCampfireDrillComment = temp.Safety_DateOfLastCampfireDrillComment;
                    weeklyCompInspectionResponseDTO.Safety_DateOfLastMedicalDrill = temp.Safety_DateOfLastMedicalDrill;
                    weeklyCompInspectionResponseDTO.Safety_DateOfLastMedicalDrillComment = temp.Safety_DateOfLastMedicalDrillComment;
                    weeklyCompInspectionResponseDTO.Safety_FirePumpInGoodCondition = temp.Safety_FirePumpInGoodCondition;
                    weeklyCompInspectionResponseDTO.Safety_FirePumpInGoodConditionComment = temp.Safety_FirePumpInGoodConditionComment;
                    weeklyCompInspectionResponseDTO.Safety_IsCampEarthing = temp.Safety_IsCampEarthing;
                    weeklyCompInspectionResponseDTO.Safety_IsCampEarthingComment = temp.Safety_IsCampEarthingComment;
                    weeklyCompInspectionResponseDTO.Safety_IsTheDiesel = temp.Safety_IsTheDiesel;
                    weeklyCompInspectionResponseDTO.Safety_IsTheDieselComment = temp.Safety_IsTheDieselComment;

                    weeklyCompInspectionResponseDTO.Clinic_IsMedicalStockMaintained = temp.Clinic_IsMedicalStockMaintained;
                    weeklyCompInspectionResponseDTO.Clinic_IsMedicalStockMaintainedComment = temp.Clinic_IsMedicalStockMaintainedComment;
                    weeklyCompInspectionResponseDTO.Clinic_IsMedicalApparatus = temp.Clinic_IsMedicalApparatus;
                    weeklyCompInspectionResponseDTO.Clinic_IsMedicalApparatusComment = temp.Clinic_IsMedicalApparatusComment;
                    weeklyCompInspectionResponseDTO.Clinic_IsMedicalTreatment = temp.Clinic_IsMedicalTreatment;
                    weeklyCompInspectionResponseDTO.Clinic_IsMedicalTreatmentComment = temp.Clinic_IsMedicalTreatmentComment;

                    weeklyCompInspectionResponseDTO.Clinic_IsTheClinicCleanAndTidy = temp.Clinic_IsTheClinicCleanAndTidy;
                    weeklyCompInspectionResponseDTO.Clinic_IsTheClinicCleanAndTidyComment = temp.Clinic_IsTheClinicCleanAndTidyComment;
                    weeklyCompInspectionResponseDTO.Clinic_RelevantSdsPresent = temp.Clinic_RelevantSdsPresent;
                    weeklyCompInspectionResponseDTO.Clinic_RelevantSdsPresentComment = temp.Clinic_RelevantSdsPresentComment;

                    weeklyCompInspectionResponseDTO.Accomodations_AnyLackInCleaning = temp.Accomodations_AnyLackInCleaning;
                    weeklyCompInspectionResponseDTO.Accomodations_AnyLackInCleaningComment = temp.Accomodations_AnyLackInCleaningComment;
                    weeklyCompInspectionResponseDTO.Accomodations_AreDoorHingesAndClosures = temp.Accomodations_AreDoorHingesAndClosures;
                    weeklyCompInspectionResponseDTO.Accomodations_AreDoorHingesAndClosuresComment = temp.Accomodations_AreDoorHingesAndClosuresComment;
                    weeklyCompInspectionResponseDTO.Accomodations_LockersOfBathroomsAreInstalledWell = temp.Accomodations_LockersOfBathroomsAreInstalledWell;
                    weeklyCompInspectionResponseDTO.Accomodations_LockersOfBathroomsAreInstalledWellComment = temp.Accomodations_LockersOfBathroomsAreInstalledWellComment;
                    weeklyCompInspectionResponseDTO.Accomodations_TypesOfCleaningMaterialsUsed = temp.Accomodations_TypesOfCleaningMaterialsUsed;
                    weeklyCompInspectionResponseDTO.Accomodations_TypesOfCleaningMaterialsUsedComment = temp.Accomodations_TypesOfCleaningMaterialsUsedComment;

                    weeklyCompInspectionResponseDTO.WaterTanks_AnyWaterLeaks = temp.WaterTanks_AnyWaterLeaks;
                    weeklyCompInspectionResponseDTO.WaterTanks_AnyWaterLeaksComment = temp.WaterTanks_AnyWaterLeaksComment;
                    weeklyCompInspectionResponseDTO.WaterTanks_AreWaterTanksHatchesClean = temp.WaterTanks_AreWaterTanksHatchesClean;
                    weeklyCompInspectionResponseDTO.WaterTanks_AreWaterTanksHatchesCleanComment = temp.WaterTanks_AreWaterTanksHatchesCleanComment;
                    weeklyCompInspectionResponseDTO.WaterTanks_IsAreaCleanAndTidy = temp.WaterTanks_IsAreaCleanAndTidy;
                    weeklyCompInspectionResponseDTO.WaterTanks_IsAreaCleanAndTidyComment = temp.WaterTanks_IsAreaCleanAndTidyComment;
                    weeklyCompInspectionResponseDTO.WaterTanks_WhatIsTheDateOfLastWaterSample = temp.WaterTanks_WhatIsTheDateOfLastWaterSample;
                    weeklyCompInspectionResponseDTO.WaterTanks_WhatIsTheDateOfLastWaterSampleComment = temp.WaterTanks_WhatIsTheDateOfLastWaterSampleComment;

                    weeklyCompInspectionResponseDTO.FoodStorage_WhatIsTheGeneralAppearance = temp.FoodStorage_WhatIsTheGeneralAppearance;
                    weeklyCompInspectionResponseDTO.FoodStorage_WhatIsTheGeneralAppearanceComment = temp.FoodStorage_WhatIsTheGeneralAppearanceComment;
                    weeklyCompInspectionResponseDTO.FoodStorage_IsThereEnoughDryFood = temp.FoodStorage_IsThereEnoughDryFood;
                    weeklyCompInspectionResponseDTO.FoodStorage_IsThereEnoughDryFoodComment = temp.FoodStorage_IsThereEnoughDryFoodComment;
                    weeklyCompInspectionResponseDTO.FoodStorage_IsFoodProperlyStored = temp.FoodStorage_IsFoodProperlyStored;
                    weeklyCompInspectionResponseDTO.FoodStorage_IsFoodProperlyStoredComment = temp.FoodStorage_IsFoodProperlyStoredComment;
                    weeklyCompInspectionResponseDTO.FoodStorage_IsFoodProperlyProtectedFromRisk = temp.FoodStorage_IsFoodProperlyProtectedFromRisk;
                    weeklyCompInspectionResponseDTO.FoodStorage_IsFoodProperlyProtectedFromRiskComment = temp.FoodStorage_IsFoodProperlyProtectedFromRiskComment;
                    weeklyCompInspectionResponseDTO.FoodStorage_FrozenStoredFood = temp.FoodStorage_FrozenStoredFood;
                    weeklyCompInspectionResponseDTO.FoodStorage_FrozenStoredFoodComment = temp.FoodStorage_FrozenStoredFoodComment;
                    weeklyCompInspectionResponseDTO.FoodStorage_AreFrozenFoods = temp.FoodStorage_AreFrozenFoods;
                    weeklyCompInspectionResponseDTO.FoodStorage_AreFrozenFoodsComment = temp.FoodStorage_AreFrozenFoodsComment;
                    weeklyCompInspectionResponseDTO.FoodStorage_AreChillerAndFreezerClean = temp.FoodStorage_AreChillerAndFreezerClean;
                    weeklyCompInspectionResponseDTO.FoodStorage_AreChillerAndFreezerCleanComment = temp.FoodStorage_AreChillerAndFreezerCleanComment;
                    weeklyCompInspectionResponseDTO.FoodStorage_AreDryFoodsProperlyStored = temp.FoodStorage_AreDryFoodsProperlyStored;
                    weeklyCompInspectionResponseDTO.FoodStorage_AreDryFoodsProperlyStoredComment = temp.FoodStorage_AreDryFoodsProperlyStoredComment;

                    weeklyCompInspectionResponseDTO.Laundry_AreAllAppliancesSafety = temp.Laundry_AreAllAppliancesSafety;
                    weeklyCompInspectionResponseDTO.Laundry_AreAllAppliancesSafetyComment = temp.Laundry_AreAllAppliancesSafetyComment;
                    weeklyCompInspectionResponseDTO.Laundry_AreAllAppliancesWorking = temp.Laundry_AreAllAppliancesWorking;
                    weeklyCompInspectionResponseDTO.Laundry_AreAllAppliancesWorkingComment = temp.Laundry_AreAllAppliancesWorkingComment;
                    weeklyCompInspectionResponseDTO.Laundry_IsLaundryAleanAndTidy = temp.Laundry_IsLaundryAleanAndTidy;
                    weeklyCompInspectionResponseDTO.Laundry_IsLaundryAleanAndTidyComment = temp.Laundry_IsLaundryAleanAndTidyComment;
                    weeklyCompInspectionResponseDTO.Laundry_TypesOfChemicalsUsedAreRelevant = temp.Laundry_TypesOfChemicalsUsedAreRelevant;
                    weeklyCompInspectionResponseDTO.Laundry_TypesOfChemicalsUsedAreRelevantComment = temp.Laundry_TypesOfChemicalsUsedAreRelevantComment;

                    weeklyCompInspectionResponseDTO.MessHall_AreAllAppliancesWorking = temp.MessHall_AreAllAppliancesWorking;
                    weeklyCompInspectionResponseDTO.MessHall_AreAllAppliancesWorkingComment = temp.MessHall_AreAllAppliancesWorkingComment;
                    weeklyCompInspectionResponseDTO.MessHall_AreFlyKillersWorking = temp.MessHall_AreFlyKillersWorking;
                    weeklyCompInspectionResponseDTO.MessHall_AreFlyKillersWorkingComment = temp.MessHall_AreFlyKillersWorkingComment;
                    weeklyCompInspectionResponseDTO.MessHall_AreTablesInGoodWorkingCondition = temp.MessHall_AreTablesInGoodWorkingCondition;
                    weeklyCompInspectionResponseDTO.MessHall_AreTablesInGoodWorkingConditionComment = temp.MessHall_AreTablesInGoodWorkingConditionComment;
                    weeklyCompInspectionResponseDTO.MessHall_AreWashHandBasins = temp.MessHall_AreWashHandBasins;
                    weeklyCompInspectionResponseDTO.MessHall_AreWashHandBasinsComment = temp.MessHall_AreWashHandBasinsComment;
                    weeklyCompInspectionResponseDTO.MessHall_IsMessHallClean = temp.MessHall_IsMessHallClean;
                    weeklyCompInspectionResponseDTO.MessHall_IsMessHallCleanComment = temp.MessHall_IsMessHallCleanComment;
                    weeklyCompInspectionResponseDTO.MessHall_RegistersForChangingFoodOil = temp.MessHall_RegistersForChangingFoodOil;
                    weeklyCompInspectionResponseDTO.MessHall_RegistersForChangingFoodOilComment = temp.MessHall_RegistersForChangingFoodOilComment;
                    weeklyCompInspectionResponseDTO.MessHall_AllElectricalCables = temp.MessHall_AllElectricalCables;
                    weeklyCompInspectionResponseDTO.MessHall_AllElectricalCablesComment = temp.MessHall_AllElectricalCablesComment;

                    weeklyCompInspectionResponseDTO.userName = temp.user.UserName;
                    weeklyCompInspectionResponseDTO.userID = temp.user.Id;

                    if (weeklyCompInspectionResponseDTO != null)
                    {

                        result.Message = "Success";
                        result.Statescode = 200;
                        result.Data = weeklyCompInspectionResponseDTO;

                        return result;
                    }
                }

            }

            result.Statescode = 404;
            result.Message = "data not found";
            return result;
        }


		[HttpGet("Print/{ID:int}")]
		public ActionResult<ResultDTO> GetAllWithDataByIDForPrint(int ID, string UserId, string UserRole)
		{
			ResultDTO result = new ResultDTO();


			if (string.Equals(UserRole, "Admin", StringComparison.OrdinalIgnoreCase))
			{
				WeeklyCampInspection temp = WeeklyCampInspectionRepository.getall().FirstOrDefault(a => a.Id == ID);
				if (temp != null)
				{
					WeeklyCampInspectionsResponseDTO weeklyCompInspectionResponseDTO = new WeeklyCampInspectionsResponseDTO();
					weeklyCompInspectionResponseDTO.Id = temp.Id;
					weeklyCompInspectionResponseDTO.RigId = temp.Rig.Number;
					weeklyCompInspectionResponseDTO.Date = temp.Date;
					weeklyCompInspectionResponseDTO.GeneralBathRooms_AnyLeaksInPiping = temp.GeneralBathRooms_AnyLeaksInPiping;
					weeklyCompInspectionResponseDTO.GeneralBathRooms_AnyLeaksInPipingComment = temp.GeneralBathRooms_AnyLeaksInPipingComment;
					weeklyCompInspectionResponseDTO.GeneralBathRooms_AreAllDoorsInGoodWorkingOrder = temp.GeneralBathRooms_AreAllDoorsInGoodWorkingOrder;
					weeklyCompInspectionResponseDTO.GeneralBathRooms_AreAllDoorsInGoodWorkingOrderComment = temp.GeneralBathRooms_AreAllDoorsInGoodWorkingOrderComment;
					weeklyCompInspectionResponseDTO.GeneralBathRooms_AreAllElectricalFixtures = temp.GeneralBathRooms_AreAllElectricalFixtures;
					weeklyCompInspectionResponseDTO.GeneralBathRooms_AreAllElectricalFixturesComment = temp.GeneralBathRooms_AreAllElectricalFixturesComment;
					weeklyCompInspectionResponseDTO.GeneralBathRooms_IsTheAreaCleanAndTidy = temp.GeneralBathRooms_IsTheAreaCleanAndTidy;
					weeklyCompInspectionResponseDTO.GeneralBathRooms_IsTheAreaCleanAndTidyComment = temp.GeneralBathRooms_IsTheAreaCleanAndTidyComment;

					weeklyCompInspectionResponseDTO.General_AreParking = temp.General_AreParking;
					weeklyCompInspectionResponseDTO.General_AreParkingComment = temp.General_AreParkingComment;
					weeklyCompInspectionResponseDTO.General_IsGenerator = temp.General_IsGenerator;
					weeklyCompInspectionResponseDTO.General_IsGeneratorComment = temp.General_IsGeneratorComment;
					weeklyCompInspectionResponseDTO.General_IsCampSite = temp.General_IsCampSite;
					weeklyCompInspectionResponseDTO.General_IsCampSiteComment = temp.General_IsCampSiteComment;
					weeklyCompInspectionResponseDTO.General_IsAllRubbish = temp.General_IsAllRubbish;
					weeklyCompInspectionResponseDTO.General_IsAllRubbishComment = temp.General_IsAllRubbishComment;
					weeklyCompInspectionResponseDTO.General_AreWater = temp.General_AreWater;
					weeklyCompInspectionResponseDTO.General_AreWaterComment = temp.General_AreWaterComment;

					weeklyCompInspectionResponseDTO.General_WhatIsGeneralOpinion = temp.General_WhatIsGeneralOpinion;
					weeklyCompInspectionResponseDTO.General_WhatIsGeneralOpinionComment = temp.General_WhatIsGeneralOpinionComment;

					weeklyCompInspectionResponseDTO.Galley_AreAllAppliancesWorking = temp.Galley_AreAllAppliancesWorking;
					weeklyCompInspectionResponseDTO.Galley_AreAllAppliancesWorkingComment = temp.Galley_AreAllAppliancesWorkingComment;
					weeklyCompInspectionResponseDTO.Galley_AreDishesAndUtensilsClean = temp.Galley_AreDishesAndUtensilsClean;
					weeklyCompInspectionResponseDTO.Galley_AreDishesAndUtensilsCleanComment = temp.Galley_AreDishesAndUtensilsCleanComment;
					weeklyCompInspectionResponseDTO.Galley_IsTheGalleyAreaClean = temp.Galley_IsTheGalleyAreaClean;
					weeklyCompInspectionResponseDTO.Galley_IsTheGalleyAreaCleanComment = temp.Galley_IsTheGalleyAreaCleanComment;
					weeklyCompInspectionResponseDTO.Galley_IsThereWnyWaterLeaks = temp.Galley_IsThereWnyWaterLeaks;
					weeklyCompInspectionResponseDTO.Galley_IsThereWnyWaterLeaksComment = temp.Galley_IsThereWnyWaterLeaksComment;
					weeklyCompInspectionResponseDTO.Galley_WhatTheConditionOfTheChipPanAndfoodOil = temp.Galley_WhatTheConditionOfTheChipPanAndfoodOil;
					weeklyCompInspectionResponseDTO.Galley_WhatTheConditionOfTheChipPanAndfoodOilComment = temp.Galley_WhatTheConditionOfTheChipPanAndfoodOilComment;
					weeklyCompInspectionResponseDTO.Galley_WhenWasExhaustFans = temp.Galley_WhenWasExhaustFans;
					weeklyCompInspectionResponseDTO.Galley_WhenWasExhaustFansComment = temp.Galley_WhenWasExhaustFansComment;

					weeklyCompInspectionResponseDTO.Safety_AreFireEmergency = temp.Safety_AreFireEmergency;
					weeklyCompInspectionResponseDTO.Safety_AreFireEmergencyComment = temp.Safety_AreFireEmergencyComment;
					weeklyCompInspectionResponseDTO.Safety_AreStaffAwareOfFoodHazards = temp.Safety_AreStaffAwareOfFoodHazards;
					weeklyCompInspectionResponseDTO.Safety_AreStaffAwareOfFoodHazardsComment = temp.Safety_AreStaffAwareOfFoodHazardsComment;
					weeklyCompInspectionResponseDTO.Safety_AreThereAnyPotentialHazards = temp.Safety_AreThereAnyPotentialHazards;
					weeklyCompInspectionResponseDTO.Safety_AreThereAnyPotentialHazardsComment = temp.Safety_AreThereAnyPotentialHazardsComment;
					weeklyCompInspectionResponseDTO.Safety_AreThereAnyUnsafe = temp.Safety_AreThereAnyUnsafe;
					weeklyCompInspectionResponseDTO.Safety_AreThereAnyUnsafeComment = temp.Safety_AreThereAnyUnsafeComment;
					weeklyCompInspectionResponseDTO.Safety_DateOfLastCampfireDrill = temp.Safety_DateOfLastCampfireDrill;
					weeklyCompInspectionResponseDTO.Safety_DateOfLastCampfireDrillComment = temp.Safety_DateOfLastCampfireDrillComment;
					weeklyCompInspectionResponseDTO.Safety_DateOfLastMedicalDrill = temp.Safety_DateOfLastMedicalDrill;
					weeklyCompInspectionResponseDTO.Safety_DateOfLastMedicalDrillComment = temp.Safety_DateOfLastMedicalDrillComment;
					weeklyCompInspectionResponseDTO.Safety_FirePumpInGoodCondition = temp.Safety_FirePumpInGoodCondition;
					weeklyCompInspectionResponseDTO.Safety_FirePumpInGoodConditionComment = temp.Safety_FirePumpInGoodConditionComment;
					weeklyCompInspectionResponseDTO.Safety_IsCampEarthing = temp.Safety_IsCampEarthing;
					weeklyCompInspectionResponseDTO.Safety_IsCampEarthingComment = temp.Safety_IsCampEarthingComment;
					weeklyCompInspectionResponseDTO.Safety_IsTheDiesel = temp.Safety_IsTheDiesel;
					weeklyCompInspectionResponseDTO.Safety_IsTheDieselComment = temp.Safety_IsTheDieselComment;

					weeklyCompInspectionResponseDTO.Clinic_IsMedicalStockMaintained = temp.Clinic_IsMedicalStockMaintained;
					weeklyCompInspectionResponseDTO.Clinic_IsMedicalStockMaintainedComment = temp.Clinic_IsMedicalStockMaintainedComment;
					weeklyCompInspectionResponseDTO.Clinic_IsMedicalApparatus = temp.Clinic_IsMedicalApparatus;
					weeklyCompInspectionResponseDTO.Clinic_IsMedicalApparatusComment = temp.Clinic_IsMedicalApparatusComment;
					weeklyCompInspectionResponseDTO.Clinic_IsMedicalTreatment = temp.Clinic_IsMedicalTreatment;
					weeklyCompInspectionResponseDTO.Clinic_IsMedicalTreatmentComment = temp.Clinic_IsMedicalTreatmentComment;

					weeklyCompInspectionResponseDTO.Clinic_IsTheClinicCleanAndTidy = temp.Clinic_IsTheClinicCleanAndTidy;
					weeklyCompInspectionResponseDTO.Clinic_IsTheClinicCleanAndTidyComment = temp.Clinic_IsTheClinicCleanAndTidyComment;
					weeklyCompInspectionResponseDTO.Clinic_RelevantSdsPresent = temp.Clinic_RelevantSdsPresent;
					weeklyCompInspectionResponseDTO.Clinic_RelevantSdsPresentComment = temp.Clinic_RelevantSdsPresentComment;

					weeklyCompInspectionResponseDTO.Accomodations_AnyLackInCleaning = temp.Accomodations_AnyLackInCleaning;
					weeklyCompInspectionResponseDTO.Accomodations_AnyLackInCleaningComment = temp.Accomodations_AnyLackInCleaningComment;
					weeklyCompInspectionResponseDTO.Accomodations_AreDoorHingesAndClosures = temp.Accomodations_AreDoorHingesAndClosures;
					weeklyCompInspectionResponseDTO.Accomodations_AreDoorHingesAndClosuresComment = temp.Accomodations_AreDoorHingesAndClosuresComment;
					weeklyCompInspectionResponseDTO.Accomodations_LockersOfBathroomsAreInstalledWell = temp.Accomodations_LockersOfBathroomsAreInstalledWell;
					weeklyCompInspectionResponseDTO.Accomodations_LockersOfBathroomsAreInstalledWellComment = temp.Accomodations_LockersOfBathroomsAreInstalledWellComment;
					weeklyCompInspectionResponseDTO.Accomodations_TypesOfCleaningMaterialsUsed = temp.Accomodations_TypesOfCleaningMaterialsUsed;
					weeklyCompInspectionResponseDTO.Accomodations_TypesOfCleaningMaterialsUsedComment = temp.Accomodations_TypesOfCleaningMaterialsUsedComment;

					weeklyCompInspectionResponseDTO.WaterTanks_AnyWaterLeaks = temp.WaterTanks_AnyWaterLeaks;
					weeklyCompInspectionResponseDTO.WaterTanks_AnyWaterLeaksComment = temp.WaterTanks_AnyWaterLeaksComment;
					weeklyCompInspectionResponseDTO.WaterTanks_AreWaterTanksHatchesClean = temp.WaterTanks_AreWaterTanksHatchesClean;
					weeklyCompInspectionResponseDTO.WaterTanks_AreWaterTanksHatchesCleanComment = temp.WaterTanks_AreWaterTanksHatchesCleanComment;
					weeklyCompInspectionResponseDTO.WaterTanks_IsAreaCleanAndTidy = temp.WaterTanks_IsAreaCleanAndTidy;
					weeklyCompInspectionResponseDTO.WaterTanks_IsAreaCleanAndTidyComment = temp.WaterTanks_IsAreaCleanAndTidyComment;
					weeklyCompInspectionResponseDTO.WaterTanks_WhatIsTheDateOfLastWaterSample = temp.WaterTanks_WhatIsTheDateOfLastWaterSample;
					weeklyCompInspectionResponseDTO.WaterTanks_WhatIsTheDateOfLastWaterSampleComment = temp.WaterTanks_WhatIsTheDateOfLastWaterSampleComment;

					weeklyCompInspectionResponseDTO.FoodStorage_WhatIsTheGeneralAppearance = temp.FoodStorage_WhatIsTheGeneralAppearance;
					weeklyCompInspectionResponseDTO.FoodStorage_WhatIsTheGeneralAppearanceComment = temp.FoodStorage_WhatIsTheGeneralAppearanceComment;
					weeklyCompInspectionResponseDTO.FoodStorage_IsThereEnoughDryFood = temp.FoodStorage_IsThereEnoughDryFood;
					weeklyCompInspectionResponseDTO.FoodStorage_IsThereEnoughDryFoodComment = temp.FoodStorage_IsThereEnoughDryFoodComment;
					weeklyCompInspectionResponseDTO.FoodStorage_IsFoodProperlyStored = temp.FoodStorage_IsFoodProperlyStored;
					weeklyCompInspectionResponseDTO.FoodStorage_IsFoodProperlyStoredComment = temp.FoodStorage_IsFoodProperlyStoredComment;
					weeklyCompInspectionResponseDTO.FoodStorage_IsFoodProperlyProtectedFromRisk = temp.FoodStorage_IsFoodProperlyProtectedFromRisk;
					weeklyCompInspectionResponseDTO.FoodStorage_IsFoodProperlyProtectedFromRiskComment = temp.FoodStorage_IsFoodProperlyProtectedFromRiskComment;
					weeklyCompInspectionResponseDTO.FoodStorage_FrozenStoredFood = temp.FoodStorage_FrozenStoredFood;
					weeklyCompInspectionResponseDTO.FoodStorage_FrozenStoredFoodComment = temp.FoodStorage_FrozenStoredFoodComment;
					weeklyCompInspectionResponseDTO.FoodStorage_AreFrozenFoods = temp.FoodStorage_AreFrozenFoods;
					weeklyCompInspectionResponseDTO.FoodStorage_AreFrozenFoodsComment = temp.FoodStorage_AreFrozenFoodsComment;
					weeklyCompInspectionResponseDTO.FoodStorage_AreChillerAndFreezerClean = temp.FoodStorage_AreChillerAndFreezerClean;
					weeklyCompInspectionResponseDTO.FoodStorage_AreChillerAndFreezerCleanComment = temp.FoodStorage_AreChillerAndFreezerCleanComment;
					weeklyCompInspectionResponseDTO.FoodStorage_AreDryFoodsProperlyStored = temp.FoodStorage_AreDryFoodsProperlyStored;
					weeklyCompInspectionResponseDTO.FoodStorage_AreDryFoodsProperlyStoredComment = temp.FoodStorage_AreDryFoodsProperlyStoredComment;

					weeklyCompInspectionResponseDTO.Laundry_AreAllAppliancesSafety = temp.Laundry_AreAllAppliancesSafety;
					weeklyCompInspectionResponseDTO.Laundry_AreAllAppliancesSafetyComment = temp.Laundry_AreAllAppliancesSafetyComment;
					weeklyCompInspectionResponseDTO.Laundry_AreAllAppliancesWorking = temp.Laundry_AreAllAppliancesWorking;
					weeklyCompInspectionResponseDTO.Laundry_AreAllAppliancesWorkingComment = temp.Laundry_AreAllAppliancesWorkingComment;
					weeklyCompInspectionResponseDTO.Laundry_IsLaundryAleanAndTidy = temp.Laundry_IsLaundryAleanAndTidy;
					weeklyCompInspectionResponseDTO.Laundry_IsLaundryAleanAndTidyComment = temp.Laundry_IsLaundryAleanAndTidyComment;
					weeklyCompInspectionResponseDTO.Laundry_TypesOfChemicalsUsedAreRelevant = temp.Laundry_TypesOfChemicalsUsedAreRelevant;
					weeklyCompInspectionResponseDTO.Laundry_TypesOfChemicalsUsedAreRelevantComment = temp.Laundry_TypesOfChemicalsUsedAreRelevantComment;

					weeklyCompInspectionResponseDTO.MessHall_AreAllAppliancesWorking = temp.MessHall_AreAllAppliancesWorking;
					weeklyCompInspectionResponseDTO.MessHall_AreAllAppliancesWorkingComment = temp.MessHall_AreAllAppliancesWorkingComment;
					weeklyCompInspectionResponseDTO.MessHall_AreFlyKillersWorking = temp.MessHall_AreFlyKillersWorking;
					weeklyCompInspectionResponseDTO.MessHall_AreFlyKillersWorkingComment = temp.MessHall_AreFlyKillersWorkingComment;
					weeklyCompInspectionResponseDTO.MessHall_AreTablesInGoodWorkingCondition = temp.MessHall_AreTablesInGoodWorkingCondition;
					weeklyCompInspectionResponseDTO.MessHall_AreTablesInGoodWorkingConditionComment = temp.MessHall_AreTablesInGoodWorkingConditionComment;
					weeklyCompInspectionResponseDTO.MessHall_AreWashHandBasins = temp.MessHall_AreWashHandBasins;
					weeklyCompInspectionResponseDTO.MessHall_AreWashHandBasinsComment = temp.MessHall_AreWashHandBasinsComment;
					weeklyCompInspectionResponseDTO.MessHall_IsMessHallClean = temp.MessHall_IsMessHallClean;
					weeklyCompInspectionResponseDTO.MessHall_IsMessHallCleanComment = temp.MessHall_IsMessHallCleanComment;
					weeklyCompInspectionResponseDTO.MessHall_RegistersForChangingFoodOil = temp.MessHall_RegistersForChangingFoodOil;
					weeklyCompInspectionResponseDTO.MessHall_RegistersForChangingFoodOilComment = temp.MessHall_RegistersForChangingFoodOilComment;
					weeklyCompInspectionResponseDTO.MessHall_AllElectricalCables = temp.MessHall_AllElectricalCables;
					weeklyCompInspectionResponseDTO.MessHall_AllElectricalCablesComment = temp.MessHall_AllElectricalCablesComment;

					weeklyCompInspectionResponseDTO.userName = temp.user.UserName;
					weeklyCompInspectionResponseDTO.userID = temp.user.Id;



					if (weeklyCompInspectionResponseDTO != null)
					{

						result.Message = "Success";
						result.Statescode = 200;
						result.Data = weeklyCompInspectionResponseDTO;

						return result;
					}
				}

			}
			else if (string.Equals(UserRole, "User", StringComparison.OrdinalIgnoreCase))
			{
				WeeklyCampInspection temp = WeeklyCampInspectionRepository.getall().FirstOrDefault(a => a.Id == ID && a.user.Id == UserId);
				if (temp != null)
				{
					WeeklyCampInspectionsResponseDTO weeklyCompInspectionResponseDTO = new WeeklyCampInspectionsResponseDTO();
					weeklyCompInspectionResponseDTO.Id = temp.Id;
					weeklyCompInspectionResponseDTO.RigId = temp.Rig.Number;
					weeklyCompInspectionResponseDTO.Date = temp.Date;
					weeklyCompInspectionResponseDTO.GeneralBathRooms_AnyLeaksInPiping = temp.GeneralBathRooms_AnyLeaksInPiping;
					weeklyCompInspectionResponseDTO.GeneralBathRooms_AnyLeaksInPipingComment = temp.GeneralBathRooms_AnyLeaksInPipingComment;
					weeklyCompInspectionResponseDTO.GeneralBathRooms_AreAllDoorsInGoodWorkingOrder = temp.GeneralBathRooms_AreAllDoorsInGoodWorkingOrder;
					weeklyCompInspectionResponseDTO.GeneralBathRooms_AreAllDoorsInGoodWorkingOrderComment = temp.GeneralBathRooms_AreAllDoorsInGoodWorkingOrderComment;
					weeklyCompInspectionResponseDTO.GeneralBathRooms_AreAllElectricalFixtures = temp.GeneralBathRooms_AreAllElectricalFixtures;
					weeklyCompInspectionResponseDTO.GeneralBathRooms_AreAllElectricalFixturesComment = temp.GeneralBathRooms_AreAllElectricalFixturesComment;
					weeklyCompInspectionResponseDTO.GeneralBathRooms_IsTheAreaCleanAndTidy = temp.GeneralBathRooms_IsTheAreaCleanAndTidy;
					weeklyCompInspectionResponseDTO.GeneralBathRooms_IsTheAreaCleanAndTidyComment = temp.GeneralBathRooms_IsTheAreaCleanAndTidyComment;

					weeklyCompInspectionResponseDTO.General_AreParking = temp.General_AreParking;
					weeklyCompInspectionResponseDTO.General_AreParkingComment = temp.General_AreParkingComment;
					weeklyCompInspectionResponseDTO.General_IsGenerator = temp.General_IsGenerator;
					weeklyCompInspectionResponseDTO.General_IsGeneratorComment = temp.General_IsGeneratorComment;
					weeklyCompInspectionResponseDTO.General_IsCampSite = temp.General_IsCampSite;
					weeklyCompInspectionResponseDTO.General_IsCampSiteComment = temp.General_IsCampSiteComment;
					weeklyCompInspectionResponseDTO.General_IsAllRubbish = temp.General_IsAllRubbish;
					weeklyCompInspectionResponseDTO.General_IsAllRubbishComment = temp.General_IsAllRubbishComment;
					weeklyCompInspectionResponseDTO.General_AreWater = temp.General_AreWater;
					weeklyCompInspectionResponseDTO.General_AreWaterComment = temp.General_AreWaterComment;

					weeklyCompInspectionResponseDTO.General_WhatIsGeneralOpinion = temp.General_WhatIsGeneralOpinion;
					weeklyCompInspectionResponseDTO.General_WhatIsGeneralOpinionComment = temp.General_WhatIsGeneralOpinionComment;

					weeklyCompInspectionResponseDTO.Galley_AreAllAppliancesWorking = temp.Galley_AreAllAppliancesWorking;
					weeklyCompInspectionResponseDTO.Galley_AreAllAppliancesWorkingComment = temp.Galley_AreAllAppliancesWorkingComment;
					weeklyCompInspectionResponseDTO.Galley_AreDishesAndUtensilsClean = temp.Galley_AreDishesAndUtensilsClean;
					weeklyCompInspectionResponseDTO.Galley_AreDishesAndUtensilsCleanComment = temp.Galley_AreDishesAndUtensilsCleanComment;
					weeklyCompInspectionResponseDTO.Galley_IsTheGalleyAreaClean = temp.Galley_IsTheGalleyAreaClean;
					weeklyCompInspectionResponseDTO.Galley_IsTheGalleyAreaCleanComment = temp.Galley_IsTheGalleyAreaCleanComment;
					weeklyCompInspectionResponseDTO.Galley_IsThereWnyWaterLeaks = temp.Galley_IsThereWnyWaterLeaks;
					weeklyCompInspectionResponseDTO.Galley_IsThereWnyWaterLeaksComment = temp.Galley_IsThereWnyWaterLeaksComment;
					weeklyCompInspectionResponseDTO.Galley_WhatTheConditionOfTheChipPanAndfoodOil = temp.Galley_WhatTheConditionOfTheChipPanAndfoodOil;
					weeklyCompInspectionResponseDTO.Galley_WhatTheConditionOfTheChipPanAndfoodOilComment = temp.Galley_WhatTheConditionOfTheChipPanAndfoodOilComment;
					weeklyCompInspectionResponseDTO.Galley_WhenWasExhaustFans = temp.Galley_WhenWasExhaustFans;
					weeklyCompInspectionResponseDTO.Galley_WhenWasExhaustFansComment = temp.Galley_WhenWasExhaustFansComment;

					weeklyCompInspectionResponseDTO.Safety_AreFireEmergency = temp.Safety_AreFireEmergency;
					weeklyCompInspectionResponseDTO.Safety_AreFireEmergencyComment = temp.Safety_AreFireEmergencyComment;
					weeklyCompInspectionResponseDTO.Safety_AreStaffAwareOfFoodHazards = temp.Safety_AreStaffAwareOfFoodHazards;
					weeklyCompInspectionResponseDTO.Safety_AreStaffAwareOfFoodHazardsComment = temp.Safety_AreStaffAwareOfFoodHazardsComment;
					weeklyCompInspectionResponseDTO.Safety_AreThereAnyPotentialHazards = temp.Safety_AreThereAnyPotentialHazards;
					weeklyCompInspectionResponseDTO.Safety_AreThereAnyPotentialHazardsComment = temp.Safety_AreThereAnyPotentialHazardsComment;
					weeklyCompInspectionResponseDTO.Safety_AreThereAnyUnsafe = temp.Safety_AreThereAnyUnsafe;
					weeklyCompInspectionResponseDTO.Safety_AreThereAnyUnsafeComment = temp.Safety_AreThereAnyUnsafeComment;
					weeklyCompInspectionResponseDTO.Safety_DateOfLastCampfireDrill = temp.Safety_DateOfLastCampfireDrill;
					weeklyCompInspectionResponseDTO.Safety_DateOfLastCampfireDrillComment = temp.Safety_DateOfLastCampfireDrillComment;
					weeklyCompInspectionResponseDTO.Safety_DateOfLastMedicalDrill = temp.Safety_DateOfLastMedicalDrill;
					weeklyCompInspectionResponseDTO.Safety_DateOfLastMedicalDrillComment = temp.Safety_DateOfLastMedicalDrillComment;
					weeklyCompInspectionResponseDTO.Safety_FirePumpInGoodCondition = temp.Safety_FirePumpInGoodCondition;
					weeklyCompInspectionResponseDTO.Safety_FirePumpInGoodConditionComment = temp.Safety_FirePumpInGoodConditionComment;
					weeklyCompInspectionResponseDTO.Safety_IsCampEarthing = temp.Safety_IsCampEarthing;
					weeklyCompInspectionResponseDTO.Safety_IsCampEarthingComment = temp.Safety_IsCampEarthingComment;
					weeklyCompInspectionResponseDTO.Safety_IsTheDiesel = temp.Safety_IsTheDiesel;
					weeklyCompInspectionResponseDTO.Safety_IsTheDieselComment = temp.Safety_IsTheDieselComment;

					weeklyCompInspectionResponseDTO.Clinic_IsMedicalStockMaintained = temp.Clinic_IsMedicalStockMaintained;
					weeklyCompInspectionResponseDTO.Clinic_IsMedicalStockMaintainedComment = temp.Clinic_IsMedicalStockMaintainedComment;
					weeklyCompInspectionResponseDTO.Clinic_IsMedicalApparatus = temp.Clinic_IsMedicalApparatus;
					weeklyCompInspectionResponseDTO.Clinic_IsMedicalApparatusComment = temp.Clinic_IsMedicalApparatusComment;
					weeklyCompInspectionResponseDTO.Clinic_IsMedicalTreatment = temp.Clinic_IsMedicalTreatment;
					weeklyCompInspectionResponseDTO.Clinic_IsMedicalTreatmentComment = temp.Clinic_IsMedicalTreatmentComment;

					weeklyCompInspectionResponseDTO.Clinic_IsTheClinicCleanAndTidy = temp.Clinic_IsTheClinicCleanAndTidy;
					weeklyCompInspectionResponseDTO.Clinic_IsTheClinicCleanAndTidyComment = temp.Clinic_IsTheClinicCleanAndTidyComment;
					weeklyCompInspectionResponseDTO.Clinic_RelevantSdsPresent = temp.Clinic_RelevantSdsPresent;
					weeklyCompInspectionResponseDTO.Clinic_RelevantSdsPresentComment = temp.Clinic_RelevantSdsPresentComment;

					weeklyCompInspectionResponseDTO.Accomodations_AnyLackInCleaning = temp.Accomodations_AnyLackInCleaning;
					weeklyCompInspectionResponseDTO.Accomodations_AnyLackInCleaningComment = temp.Accomodations_AnyLackInCleaningComment;
					weeklyCompInspectionResponseDTO.Accomodations_AreDoorHingesAndClosures = temp.Accomodations_AreDoorHingesAndClosures;
					weeklyCompInspectionResponseDTO.Accomodations_AreDoorHingesAndClosuresComment = temp.Accomodations_AreDoorHingesAndClosuresComment;
					weeklyCompInspectionResponseDTO.Accomodations_LockersOfBathroomsAreInstalledWell = temp.Accomodations_LockersOfBathroomsAreInstalledWell;
					weeklyCompInspectionResponseDTO.Accomodations_LockersOfBathroomsAreInstalledWellComment = temp.Accomodations_LockersOfBathroomsAreInstalledWellComment;
					weeklyCompInspectionResponseDTO.Accomodations_TypesOfCleaningMaterialsUsed = temp.Accomodations_TypesOfCleaningMaterialsUsed;
					weeklyCompInspectionResponseDTO.Accomodations_TypesOfCleaningMaterialsUsedComment = temp.Accomodations_TypesOfCleaningMaterialsUsedComment;

					weeklyCompInspectionResponseDTO.WaterTanks_AnyWaterLeaks = temp.WaterTanks_AnyWaterLeaks;
					weeklyCompInspectionResponseDTO.WaterTanks_AnyWaterLeaksComment = temp.WaterTanks_AnyWaterLeaksComment;
					weeklyCompInspectionResponseDTO.WaterTanks_AreWaterTanksHatchesClean = temp.WaterTanks_AreWaterTanksHatchesClean;
					weeklyCompInspectionResponseDTO.WaterTanks_AreWaterTanksHatchesCleanComment = temp.WaterTanks_AreWaterTanksHatchesCleanComment;
					weeklyCompInspectionResponseDTO.WaterTanks_IsAreaCleanAndTidy = temp.WaterTanks_IsAreaCleanAndTidy;
					weeklyCompInspectionResponseDTO.WaterTanks_IsAreaCleanAndTidyComment = temp.WaterTanks_IsAreaCleanAndTidyComment;
					weeklyCompInspectionResponseDTO.WaterTanks_WhatIsTheDateOfLastWaterSample = temp.WaterTanks_WhatIsTheDateOfLastWaterSample;
					weeklyCompInspectionResponseDTO.WaterTanks_WhatIsTheDateOfLastWaterSampleComment = temp.WaterTanks_WhatIsTheDateOfLastWaterSampleComment;

					weeklyCompInspectionResponseDTO.FoodStorage_WhatIsTheGeneralAppearance = temp.FoodStorage_WhatIsTheGeneralAppearance;
					weeklyCompInspectionResponseDTO.FoodStorage_WhatIsTheGeneralAppearanceComment = temp.FoodStorage_WhatIsTheGeneralAppearanceComment;
					weeklyCompInspectionResponseDTO.FoodStorage_IsThereEnoughDryFood = temp.FoodStorage_IsThereEnoughDryFood;
					weeklyCompInspectionResponseDTO.FoodStorage_IsThereEnoughDryFoodComment = temp.FoodStorage_IsThereEnoughDryFoodComment;
					weeklyCompInspectionResponseDTO.FoodStorage_IsFoodProperlyStored = temp.FoodStorage_IsFoodProperlyStored;
					weeklyCompInspectionResponseDTO.FoodStorage_IsFoodProperlyStoredComment = temp.FoodStorage_IsFoodProperlyStoredComment;
					weeklyCompInspectionResponseDTO.FoodStorage_IsFoodProperlyProtectedFromRisk = temp.FoodStorage_IsFoodProperlyProtectedFromRisk;
					weeklyCompInspectionResponseDTO.FoodStorage_IsFoodProperlyProtectedFromRiskComment = temp.FoodStorage_IsFoodProperlyProtectedFromRiskComment;
					weeklyCompInspectionResponseDTO.FoodStorage_FrozenStoredFood = temp.FoodStorage_FrozenStoredFood;
					weeklyCompInspectionResponseDTO.FoodStorage_FrozenStoredFoodComment = temp.FoodStorage_FrozenStoredFoodComment;
					weeklyCompInspectionResponseDTO.FoodStorage_AreFrozenFoods = temp.FoodStorage_AreFrozenFoods;
					weeklyCompInspectionResponseDTO.FoodStorage_AreFrozenFoodsComment = temp.FoodStorage_AreFrozenFoodsComment;
					weeklyCompInspectionResponseDTO.FoodStorage_AreChillerAndFreezerClean = temp.FoodStorage_AreChillerAndFreezerClean;
					weeklyCompInspectionResponseDTO.FoodStorage_AreChillerAndFreezerCleanComment = temp.FoodStorage_AreChillerAndFreezerCleanComment;
					weeklyCompInspectionResponseDTO.FoodStorage_AreDryFoodsProperlyStored = temp.FoodStorage_AreDryFoodsProperlyStored;
					weeklyCompInspectionResponseDTO.FoodStorage_AreDryFoodsProperlyStoredComment = temp.FoodStorage_AreDryFoodsProperlyStoredComment;

					weeklyCompInspectionResponseDTO.Laundry_AreAllAppliancesSafety = temp.Laundry_AreAllAppliancesSafety;
					weeklyCompInspectionResponseDTO.Laundry_AreAllAppliancesSafetyComment = temp.Laundry_AreAllAppliancesSafetyComment;
					weeklyCompInspectionResponseDTO.Laundry_AreAllAppliancesWorking = temp.Laundry_AreAllAppliancesWorking;
					weeklyCompInspectionResponseDTO.Laundry_AreAllAppliancesWorkingComment = temp.Laundry_AreAllAppliancesWorkingComment;
					weeklyCompInspectionResponseDTO.Laundry_IsLaundryAleanAndTidy = temp.Laundry_IsLaundryAleanAndTidy;
					weeklyCompInspectionResponseDTO.Laundry_IsLaundryAleanAndTidyComment = temp.Laundry_IsLaundryAleanAndTidyComment;
					weeklyCompInspectionResponseDTO.Laundry_TypesOfChemicalsUsedAreRelevant = temp.Laundry_TypesOfChemicalsUsedAreRelevant;
					weeklyCompInspectionResponseDTO.Laundry_TypesOfChemicalsUsedAreRelevantComment = temp.Laundry_TypesOfChemicalsUsedAreRelevantComment;

					weeklyCompInspectionResponseDTO.MessHall_AreAllAppliancesWorking = temp.MessHall_AreAllAppliancesWorking;
					weeklyCompInspectionResponseDTO.MessHall_AreAllAppliancesWorkingComment = temp.MessHall_AreAllAppliancesWorkingComment;
					weeklyCompInspectionResponseDTO.MessHall_AreFlyKillersWorking = temp.MessHall_AreFlyKillersWorking;
					weeklyCompInspectionResponseDTO.MessHall_AreFlyKillersWorkingComment = temp.MessHall_AreFlyKillersWorkingComment;
					weeklyCompInspectionResponseDTO.MessHall_AreTablesInGoodWorkingCondition = temp.MessHall_AreTablesInGoodWorkingCondition;
					weeklyCompInspectionResponseDTO.MessHall_AreTablesInGoodWorkingConditionComment = temp.MessHall_AreTablesInGoodWorkingConditionComment;
					weeklyCompInspectionResponseDTO.MessHall_AreWashHandBasins = temp.MessHall_AreWashHandBasins;
					weeklyCompInspectionResponseDTO.MessHall_AreWashHandBasinsComment = temp.MessHall_AreWashHandBasinsComment;
					weeklyCompInspectionResponseDTO.MessHall_IsMessHallClean = temp.MessHall_IsMessHallClean;
					weeklyCompInspectionResponseDTO.MessHall_IsMessHallCleanComment = temp.MessHall_IsMessHallCleanComment;
					weeklyCompInspectionResponseDTO.MessHall_RegistersForChangingFoodOil = temp.MessHall_RegistersForChangingFoodOil;
					weeklyCompInspectionResponseDTO.MessHall_RegistersForChangingFoodOilComment = temp.MessHall_RegistersForChangingFoodOilComment;
					weeklyCompInspectionResponseDTO.MessHall_AllElectricalCables = temp.MessHall_AllElectricalCables;
					weeklyCompInspectionResponseDTO.MessHall_AllElectricalCablesComment = temp.MessHall_AllElectricalCablesComment;

					weeklyCompInspectionResponseDTO.userName = temp.user.UserName;
					weeklyCompInspectionResponseDTO.userID = temp.user.Id;

					if (weeklyCompInspectionResponseDTO != null)
					{

						result.Message = "Success";
						result.Statescode = 200;
						result.Data = weeklyCompInspectionResponseDTO;

						return result;
					}
				}

			}

			result.Statescode = 404;
			result.Message = "data not found";
			return result;
		}

		//  ------------------ filter by weeklyCampInspection ------------------------------------------

		[HttpGet("GetAllWithDataByRigNumerAndDate/{UserId}")]
        public ActionResult<ResultDTO> GetAllWithDataByRigNumerAndDate( string UserId, string date , string UserRole, int RigNumber)
        {
            DateTime dateObject = DateTime.Parse(date);
            ResultDTO result = new ResultDTO();

            try
            {
                if (string.Equals(UserRole, "Admin", StringComparison.OrdinalIgnoreCase))
                {
                    List<WeeklyCampInspection> weeklyCampInspections = WeeklyCampInspectionRepository.getall().Where(a =>a.Rig.Number==RigNumber && a.Date== dateObject).ToList();
                    List<WeeklyCampInspectionsResponseDTO> weeklyCompInspectionResponseDTOs  = new List<WeeklyCampInspectionsResponseDTO>();
                    foreach (WeeklyCampInspection  weeklyCampInspection in weeklyCampInspections)
                    {
                        WeeklyCampInspectionsResponseDTO weeklyCompInspectionResponseDTO = new WeeklyCampInspectionsResponseDTO();
                        weeklyCompInspectionResponseDTO.Id = weeklyCampInspection.Id;
                        weeklyCompInspectionResponseDTO.RigId = weeklyCampInspection.Rig.Number;
                        weeklyCompInspectionResponseDTO.Date = weeklyCampInspection.Date;
                        weeklyCompInspectionResponseDTO.GeneralBathRooms_AnyLeaksInPiping = weeklyCampInspection.GeneralBathRooms_AnyLeaksInPiping;
                        weeklyCompInspectionResponseDTO.GeneralBathRooms_AnyLeaksInPipingComment = weeklyCampInspection.GeneralBathRooms_AnyLeaksInPipingComment;
                        weeklyCompInspectionResponseDTO.GeneralBathRooms_AreAllDoorsInGoodWorkingOrder = weeklyCampInspection.GeneralBathRooms_AreAllDoorsInGoodWorkingOrder;
                        weeklyCompInspectionResponseDTO.GeneralBathRooms_AreAllDoorsInGoodWorkingOrderComment = weeklyCampInspection.GeneralBathRooms_AreAllDoorsInGoodWorkingOrderComment;
                        weeklyCompInspectionResponseDTO.GeneralBathRooms_AreAllElectricalFixtures = weeklyCampInspection.GeneralBathRooms_AreAllElectricalFixtures;
                        weeklyCompInspectionResponseDTO.GeneralBathRooms_AreAllElectricalFixturesComment = weeklyCampInspection.GeneralBathRooms_AreAllElectricalFixturesComment;
                        weeklyCompInspectionResponseDTO.GeneralBathRooms_IsTheAreaCleanAndTidy = weeklyCampInspection.GeneralBathRooms_IsTheAreaCleanAndTidy;
                        weeklyCompInspectionResponseDTO.GeneralBathRooms_IsTheAreaCleanAndTidyComment = weeklyCampInspection.GeneralBathRooms_IsTheAreaCleanAndTidyComment;

                        weeklyCompInspectionResponseDTO.General_AreParking = weeklyCampInspection.General_AreParking;
                        weeklyCompInspectionResponseDTO.General_AreParkingComment = weeklyCampInspection.General_AreParkingComment;
                        weeklyCompInspectionResponseDTO.General_IsGenerator = weeklyCampInspection.General_IsGenerator;
                        weeklyCompInspectionResponseDTO.General_IsGeneratorComment = weeklyCampInspection.General_IsGeneratorComment;
                        weeklyCompInspectionResponseDTO.General_IsCampSite = weeklyCampInspection.General_IsCampSite;
                        weeklyCompInspectionResponseDTO.General_IsCampSiteComment = weeklyCampInspection.General_IsCampSiteComment;
                        weeklyCompInspectionResponseDTO.General_IsAllRubbish = weeklyCampInspection.General_IsAllRubbish;
                        weeklyCompInspectionResponseDTO.General_IsAllRubbishComment = weeklyCampInspection.General_IsAllRubbishComment;
                        weeklyCompInspectionResponseDTO.General_AreWater = weeklyCampInspection.General_AreWater;
                        weeklyCompInspectionResponseDTO.General_AreWaterComment = weeklyCampInspection.General_AreWaterComment;

                        weeklyCompInspectionResponseDTO.General_WhatIsGeneralOpinion = weeklyCampInspection.General_WhatIsGeneralOpinion;
                        weeklyCompInspectionResponseDTO.General_WhatIsGeneralOpinionComment = weeklyCampInspection.General_WhatIsGeneralOpinionComment;

                        weeklyCompInspectionResponseDTO.Galley_AreAllAppliancesWorking = weeklyCampInspection.Galley_AreAllAppliancesWorking;
                        weeklyCompInspectionResponseDTO.Galley_AreAllAppliancesWorkingComment = weeklyCampInspection.Galley_AreAllAppliancesWorkingComment;
                        weeklyCompInspectionResponseDTO.Galley_AreDishesAndUtensilsClean = weeklyCampInspection.Galley_AreDishesAndUtensilsClean;
                        weeklyCompInspectionResponseDTO.Galley_AreDishesAndUtensilsCleanComment = weeklyCampInspection.Galley_AreDishesAndUtensilsCleanComment;
                        weeklyCompInspectionResponseDTO.Galley_IsTheGalleyAreaClean = weeklyCampInspection.Galley_IsTheGalleyAreaClean;
                        weeklyCompInspectionResponseDTO.Galley_IsTheGalleyAreaCleanComment = weeklyCampInspection.Galley_IsTheGalleyAreaCleanComment;
                        weeklyCompInspectionResponseDTO.Galley_IsThereWnyWaterLeaks = weeklyCampInspection.Galley_IsThereWnyWaterLeaks;
                        weeklyCompInspectionResponseDTO.Galley_IsThereWnyWaterLeaksComment = weeklyCampInspection.Galley_IsThereWnyWaterLeaksComment;
                        weeklyCompInspectionResponseDTO.Galley_WhatTheConditionOfTheChipPanAndfoodOil = weeklyCampInspection.Galley_WhatTheConditionOfTheChipPanAndfoodOil;
                        weeklyCompInspectionResponseDTO.Galley_WhatTheConditionOfTheChipPanAndfoodOilComment = weeklyCampInspection.Galley_WhatTheConditionOfTheChipPanAndfoodOilComment;
                        weeklyCompInspectionResponseDTO.Galley_WhenWasExhaustFans = weeklyCampInspection.Galley_WhenWasExhaustFans;
                        weeklyCompInspectionResponseDTO.Galley_WhenWasExhaustFansComment = weeklyCampInspection.Galley_WhenWasExhaustFansComment;

                        weeklyCompInspectionResponseDTO.Safety_AreFireEmergency = weeklyCampInspection.Safety_AreFireEmergency;
                        weeklyCompInspectionResponseDTO.Safety_AreFireEmergencyComment = weeklyCampInspection.Safety_AreFireEmergencyComment;
                        weeklyCompInspectionResponseDTO.Safety_AreStaffAwareOfFoodHazards = weeklyCampInspection.Safety_AreStaffAwareOfFoodHazards;
                        weeklyCompInspectionResponseDTO.Safety_AreStaffAwareOfFoodHazardsComment = weeklyCampInspection.Safety_AreStaffAwareOfFoodHazardsComment;
                        weeklyCompInspectionResponseDTO.Safety_AreThereAnyPotentialHazards = weeklyCampInspection.Safety_AreThereAnyPotentialHazards;
                        weeklyCompInspectionResponseDTO.Safety_AreThereAnyPotentialHazardsComment = weeklyCampInspection.Safety_AreThereAnyPotentialHazardsComment;
                        weeklyCompInspectionResponseDTO.Safety_AreThereAnyUnsafe = weeklyCampInspection.Safety_AreThereAnyUnsafe;
                        weeklyCompInspectionResponseDTO.Safety_AreThereAnyUnsafeComment = weeklyCampInspection.Safety_AreThereAnyUnsafeComment;
                        weeklyCompInspectionResponseDTO.Safety_DateOfLastCampfireDrill = weeklyCampInspection.Safety_DateOfLastCampfireDrill;
                        weeklyCompInspectionResponseDTO.Safety_DateOfLastCampfireDrillComment = weeklyCampInspection.Safety_DateOfLastCampfireDrillComment;
                        weeklyCompInspectionResponseDTO.Safety_DateOfLastMedicalDrill = weeklyCampInspection.Safety_DateOfLastMedicalDrill;
                        weeklyCompInspectionResponseDTO.Safety_DateOfLastMedicalDrillComment = weeklyCampInspection.Safety_DateOfLastMedicalDrillComment;
                        weeklyCompInspectionResponseDTO.Safety_FirePumpInGoodCondition = weeklyCampInspection.Safety_FirePumpInGoodCondition;
                        weeklyCompInspectionResponseDTO.Safety_FirePumpInGoodConditionComment = weeklyCampInspection.Safety_FirePumpInGoodConditionComment;
                        weeklyCompInspectionResponseDTO.Safety_IsCampEarthing = weeklyCampInspection.Safety_IsCampEarthing;
                        weeklyCompInspectionResponseDTO.Safety_IsCampEarthingComment = weeklyCampInspection.Safety_IsCampEarthingComment;
                        weeklyCompInspectionResponseDTO.Safety_IsTheDiesel = weeklyCampInspection.Safety_IsTheDiesel;
                        weeklyCompInspectionResponseDTO.Safety_IsTheDieselComment = weeklyCampInspection.Safety_IsTheDieselComment;

                        weeklyCompInspectionResponseDTO.Clinic_IsMedicalStockMaintained = weeklyCampInspection.Clinic_IsMedicalStockMaintained;
                        weeklyCompInspectionResponseDTO.Clinic_IsMedicalStockMaintainedComment = weeklyCampInspection.Clinic_IsMedicalStockMaintainedComment;
                        weeklyCompInspectionResponseDTO.Clinic_IsMedicalApparatus = weeklyCampInspection.Clinic_IsMedicalApparatus;
                        weeklyCompInspectionResponseDTO.Clinic_IsMedicalApparatusComment = weeklyCampInspection.Clinic_IsMedicalApparatusComment;
                        weeklyCompInspectionResponseDTO.Clinic_IsMedicalTreatment = weeklyCampInspection.Clinic_IsMedicalTreatment;
                        weeklyCompInspectionResponseDTO.Clinic_IsMedicalTreatmentComment = weeklyCampInspection.Clinic_IsMedicalTreatmentComment;

                        weeklyCompInspectionResponseDTO.Clinic_IsTheClinicCleanAndTidy = weeklyCampInspection.Clinic_IsTheClinicCleanAndTidy;
                        weeklyCompInspectionResponseDTO.Clinic_IsTheClinicCleanAndTidyComment = weeklyCampInspection.Clinic_IsTheClinicCleanAndTidyComment;
                        weeklyCompInspectionResponseDTO.Clinic_RelevantSdsPresent = weeklyCampInspection.Clinic_RelevantSdsPresent;
                        weeklyCompInspectionResponseDTO.Clinic_RelevantSdsPresentComment = weeklyCampInspection.Clinic_RelevantSdsPresentComment;

                        weeklyCompInspectionResponseDTO.Accomodations_AnyLackInCleaning = weeklyCampInspection.Accomodations_AnyLackInCleaning;
                        weeklyCompInspectionResponseDTO.Accomodations_AnyLackInCleaningComment = weeklyCampInspection.Accomodations_AnyLackInCleaningComment;
                        weeklyCompInspectionResponseDTO.Accomodations_AreDoorHingesAndClosures = weeklyCampInspection.Accomodations_AreDoorHingesAndClosures;
                        weeklyCompInspectionResponseDTO.Accomodations_AreDoorHingesAndClosuresComment = weeklyCampInspection.Accomodations_AreDoorHingesAndClosuresComment;
                        weeklyCompInspectionResponseDTO.Accomodations_LockersOfBathroomsAreInstalledWell = weeklyCampInspection.Accomodations_LockersOfBathroomsAreInstalledWell;
                        weeklyCompInspectionResponseDTO.Accomodations_LockersOfBathroomsAreInstalledWellComment = weeklyCampInspection.Accomodations_LockersOfBathroomsAreInstalledWellComment;
                        weeklyCompInspectionResponseDTO.Accomodations_TypesOfCleaningMaterialsUsed = weeklyCampInspection.Accomodations_TypesOfCleaningMaterialsUsed;
                        weeklyCompInspectionResponseDTO.Accomodations_TypesOfCleaningMaterialsUsedComment = weeklyCampInspection.Accomodations_TypesOfCleaningMaterialsUsedComment;

                        weeklyCompInspectionResponseDTO.WaterTanks_AnyWaterLeaks = weeklyCampInspection.WaterTanks_AnyWaterLeaks;
                        weeklyCompInspectionResponseDTO.WaterTanks_AnyWaterLeaksComment = weeklyCampInspection.WaterTanks_AnyWaterLeaksComment;
                        weeklyCompInspectionResponseDTO.WaterTanks_AreWaterTanksHatchesClean = weeklyCampInspection.WaterTanks_AreWaterTanksHatchesClean;
                        weeklyCompInspectionResponseDTO.WaterTanks_AreWaterTanksHatchesCleanComment = weeklyCampInspection.WaterTanks_AreWaterTanksHatchesCleanComment;
                        weeklyCompInspectionResponseDTO.WaterTanks_IsAreaCleanAndTidy = weeklyCampInspection.WaterTanks_IsAreaCleanAndTidy;
                        weeklyCompInspectionResponseDTO.WaterTanks_IsAreaCleanAndTidyComment = weeklyCampInspection.WaterTanks_IsAreaCleanAndTidyComment;
                        weeklyCompInspectionResponseDTO.WaterTanks_WhatIsTheDateOfLastWaterSample = weeklyCampInspection.WaterTanks_WhatIsTheDateOfLastWaterSample;
                        weeklyCompInspectionResponseDTO.WaterTanks_WhatIsTheDateOfLastWaterSampleComment = weeklyCampInspection.WaterTanks_WhatIsTheDateOfLastWaterSampleComment;

                        weeklyCompInspectionResponseDTO.FoodStorage_WhatIsTheGeneralAppearance = weeklyCampInspection.FoodStorage_WhatIsTheGeneralAppearance;
                        weeklyCompInspectionResponseDTO.FoodStorage_WhatIsTheGeneralAppearanceComment = weeklyCampInspection.FoodStorage_WhatIsTheGeneralAppearanceComment;
                        weeklyCompInspectionResponseDTO.FoodStorage_IsThereEnoughDryFood = weeklyCampInspection.FoodStorage_IsThereEnoughDryFood;
                        weeklyCompInspectionResponseDTO.FoodStorage_IsThereEnoughDryFoodComment = weeklyCampInspection.FoodStorage_IsThereEnoughDryFoodComment;
                        weeklyCompInspectionResponseDTO.FoodStorage_IsFoodProperlyStored = weeklyCampInspection.FoodStorage_IsFoodProperlyStored;
                        weeklyCompInspectionResponseDTO.FoodStorage_IsFoodProperlyStoredComment = weeklyCampInspection.FoodStorage_IsFoodProperlyStoredComment;
                        weeklyCompInspectionResponseDTO.FoodStorage_IsFoodProperlyProtectedFromRisk = weeklyCampInspection.FoodStorage_IsFoodProperlyProtectedFromRisk;
                        weeklyCompInspectionResponseDTO.FoodStorage_IsFoodProperlyProtectedFromRiskComment = weeklyCampInspection.FoodStorage_IsFoodProperlyProtectedFromRiskComment;
                        weeklyCompInspectionResponseDTO.FoodStorage_FrozenStoredFood = weeklyCampInspection.FoodStorage_FrozenStoredFood;
                        weeklyCompInspectionResponseDTO.FoodStorage_FrozenStoredFoodComment = weeklyCampInspection.FoodStorage_FrozenStoredFoodComment;
                        weeklyCompInspectionResponseDTO.FoodStorage_AreFrozenFoods = weeklyCampInspection.FoodStorage_AreFrozenFoods;
                        weeklyCompInspectionResponseDTO.FoodStorage_AreFrozenFoodsComment = weeklyCampInspection.FoodStorage_AreFrozenFoodsComment;
                        weeklyCompInspectionResponseDTO.FoodStorage_AreChillerAndFreezerClean = weeklyCampInspection.FoodStorage_AreChillerAndFreezerClean;
                        weeklyCompInspectionResponseDTO.FoodStorage_AreChillerAndFreezerCleanComment = weeklyCampInspection.FoodStorage_AreChillerAndFreezerCleanComment;
                        weeklyCompInspectionResponseDTO.FoodStorage_AreDryFoodsProperlyStored = weeklyCampInspection.FoodStorage_AreDryFoodsProperlyStored;
                        weeklyCompInspectionResponseDTO.FoodStorage_AreDryFoodsProperlyStoredComment = weeklyCampInspection.FoodStorage_AreDryFoodsProperlyStoredComment;

                        weeklyCompInspectionResponseDTO.Laundry_AreAllAppliancesSafety = weeklyCampInspection.Laundry_AreAllAppliancesSafety;
                        weeklyCompInspectionResponseDTO.Laundry_AreAllAppliancesSafetyComment = weeklyCampInspection.Laundry_AreAllAppliancesSafetyComment;
                        weeklyCompInspectionResponseDTO.Laundry_AreAllAppliancesWorking = weeklyCampInspection.Laundry_AreAllAppliancesWorking;
                        weeklyCompInspectionResponseDTO.Laundry_AreAllAppliancesWorkingComment = weeklyCampInspection.Laundry_AreAllAppliancesWorkingComment;
                        weeklyCompInspectionResponseDTO.Laundry_IsLaundryAleanAndTidy = weeklyCampInspection.Laundry_IsLaundryAleanAndTidy;
                        weeklyCompInspectionResponseDTO.Laundry_IsLaundryAleanAndTidyComment = weeklyCampInspection.Laundry_IsLaundryAleanAndTidyComment;
                        weeklyCompInspectionResponseDTO.Laundry_TypesOfChemicalsUsedAreRelevant = weeklyCampInspection.Laundry_TypesOfChemicalsUsedAreRelevant;
                        weeklyCompInspectionResponseDTO.Laundry_TypesOfChemicalsUsedAreRelevantComment = weeklyCampInspection.Laundry_TypesOfChemicalsUsedAreRelevantComment;

                        weeklyCompInspectionResponseDTO.MessHall_AreAllAppliancesWorking = weeklyCampInspection.MessHall_AreAllAppliancesWorking;
                        weeklyCompInspectionResponseDTO.MessHall_AreAllAppliancesWorkingComment = weeklyCampInspection.MessHall_AreAllAppliancesWorkingComment;
                        weeklyCompInspectionResponseDTO.MessHall_AreFlyKillersWorking = weeklyCampInspection.MessHall_AreFlyKillersWorking;
                        weeklyCompInspectionResponseDTO.MessHall_AreFlyKillersWorkingComment = weeklyCampInspection.MessHall_AreFlyKillersWorkingComment;
                        weeklyCompInspectionResponseDTO.MessHall_AreTablesInGoodWorkingCondition = weeklyCampInspection.MessHall_AreTablesInGoodWorkingCondition;
                        weeklyCompInspectionResponseDTO.MessHall_AreTablesInGoodWorkingConditionComment = weeklyCampInspection.MessHall_AreTablesInGoodWorkingConditionComment;
                        weeklyCompInspectionResponseDTO.MessHall_AreWashHandBasins = weeklyCampInspection.MessHall_AreWashHandBasins;
                        weeklyCompInspectionResponseDTO.MessHall_AreWashHandBasinsComment = weeklyCampInspection.MessHall_AreWashHandBasinsComment;
                        weeklyCompInspectionResponseDTO.MessHall_IsMessHallClean = weeklyCampInspection.MessHall_IsMessHallClean;
                        weeklyCompInspectionResponseDTO.MessHall_IsMessHallCleanComment = weeklyCampInspection.MessHall_IsMessHallCleanComment;
                        weeklyCompInspectionResponseDTO.MessHall_RegistersForChangingFoodOil = weeklyCampInspection.MessHall_RegistersForChangingFoodOil;
                        weeklyCompInspectionResponseDTO.MessHall_RegistersForChangingFoodOilComment = weeklyCampInspection.MessHall_RegistersForChangingFoodOilComment;
                        weeklyCompInspectionResponseDTO.MessHall_AllElectricalCables = weeklyCampInspection.MessHall_AllElectricalCables;
                        weeklyCompInspectionResponseDTO.MessHall_AllElectricalCablesComment = weeklyCampInspection.MessHall_AllElectricalCablesComment;


                        weeklyCompInspectionResponseDTO.userName = weeklyCampInspection.user.UserName;
                        weeklyCompInspectionResponseDTO.userID = weeklyCampInspection.user.Id;


                        weeklyCompInspectionResponseDTOs.Add(weeklyCompInspectionResponseDTO);
                    }


                    result.Message = "Success";
                    result.Data = weeklyCompInspectionResponseDTOs;
                    result.Statescode = 200;
                    return result;
                }
                else if (string.Equals(UserRole, "User", StringComparison.OrdinalIgnoreCase))
                {
                   
                    List<WeeklyCampInspection> weeklyCampInspections = WeeklyCampInspectionRepository.getall().Where(a => a.Rig.Number == RigNumber && a.Date == dateObject && a.user.Id == UserId).ToList();
                    List<WeeklyCampInspectionsResponseDTO> weeklyCompInspectionResponseDTOs = new List<WeeklyCampInspectionsResponseDTO>();
                    foreach (WeeklyCampInspection weeklyCampInspection in weeklyCampInspections)
                    {
                        WeeklyCampInspectionsResponseDTO weeklyCompInspectionResponseDTO = new WeeklyCampInspectionsResponseDTO();
                        weeklyCompInspectionResponseDTO.Id = weeklyCampInspection.Id;
                        weeklyCompInspectionResponseDTO.RigId = weeklyCampInspection.Rig.Number;
                        weeklyCompInspectionResponseDTO.Date = weeklyCampInspection.Date;
                        weeklyCompInspectionResponseDTO.GeneralBathRooms_AnyLeaksInPiping = weeklyCampInspection.GeneralBathRooms_AnyLeaksInPiping;
                        weeklyCompInspectionResponseDTO.GeneralBathRooms_AnyLeaksInPipingComment = weeklyCampInspection.GeneralBathRooms_AnyLeaksInPipingComment;
                        weeklyCompInspectionResponseDTO.GeneralBathRooms_AreAllDoorsInGoodWorkingOrder = weeklyCampInspection.GeneralBathRooms_AreAllDoorsInGoodWorkingOrder;
                        weeklyCompInspectionResponseDTO.GeneralBathRooms_AreAllDoorsInGoodWorkingOrderComment = weeklyCampInspection.GeneralBathRooms_AreAllDoorsInGoodWorkingOrderComment;
                        weeklyCompInspectionResponseDTO.GeneralBathRooms_AreAllElectricalFixtures = weeklyCampInspection.GeneralBathRooms_AreAllElectricalFixtures;
                        weeklyCompInspectionResponseDTO.GeneralBathRooms_AreAllElectricalFixturesComment = weeklyCampInspection.GeneralBathRooms_AreAllElectricalFixturesComment;
                        weeklyCompInspectionResponseDTO.GeneralBathRooms_IsTheAreaCleanAndTidy = weeklyCampInspection.GeneralBathRooms_IsTheAreaCleanAndTidy;
                        weeklyCompInspectionResponseDTO.GeneralBathRooms_IsTheAreaCleanAndTidyComment = weeklyCampInspection.GeneralBathRooms_IsTheAreaCleanAndTidyComment;

                        weeklyCompInspectionResponseDTO.General_AreParking = weeklyCampInspection.General_AreParking;
                        weeklyCompInspectionResponseDTO.General_AreParkingComment = weeklyCampInspection.General_AreParkingComment;
                        weeklyCompInspectionResponseDTO.General_IsGenerator = weeklyCampInspection.General_IsGenerator;
                        weeklyCompInspectionResponseDTO.General_IsGeneratorComment = weeklyCampInspection.General_IsGeneratorComment;
                        weeklyCompInspectionResponseDTO.General_IsCampSite = weeklyCampInspection.General_IsCampSite;
                        weeklyCompInspectionResponseDTO.General_IsCampSiteComment = weeklyCampInspection.General_IsCampSiteComment;
                        weeklyCompInspectionResponseDTO.General_IsAllRubbish = weeklyCampInspection.General_IsAllRubbish;
                        weeklyCompInspectionResponseDTO.General_IsAllRubbishComment = weeklyCampInspection.General_IsAllRubbishComment;
                        weeklyCompInspectionResponseDTO.General_AreWater = weeklyCampInspection.General_AreWater;
                        weeklyCompInspectionResponseDTO.General_AreWaterComment = weeklyCampInspection.General_AreWaterComment;

                        weeklyCompInspectionResponseDTO.General_WhatIsGeneralOpinion = weeklyCampInspection.General_WhatIsGeneralOpinion;
                        weeklyCompInspectionResponseDTO.General_WhatIsGeneralOpinionComment = weeklyCampInspection.General_WhatIsGeneralOpinionComment;

                        weeklyCompInspectionResponseDTO.Galley_AreAllAppliancesWorking = weeklyCampInspection.Galley_AreAllAppliancesWorking;
                        weeklyCompInspectionResponseDTO.Galley_AreAllAppliancesWorkingComment = weeklyCampInspection.Galley_AreAllAppliancesWorkingComment;
                        weeklyCompInspectionResponseDTO.Galley_AreDishesAndUtensilsClean = weeklyCampInspection.Galley_AreDishesAndUtensilsClean;
                        weeklyCompInspectionResponseDTO.Galley_AreDishesAndUtensilsCleanComment = weeklyCampInspection.Galley_AreDishesAndUtensilsCleanComment;
                        weeklyCompInspectionResponseDTO.Galley_IsTheGalleyAreaClean = weeklyCampInspection.Galley_IsTheGalleyAreaClean;
                        weeklyCompInspectionResponseDTO.Galley_IsTheGalleyAreaCleanComment = weeklyCampInspection.Galley_IsTheGalleyAreaCleanComment;
                        weeklyCompInspectionResponseDTO.Galley_IsThereWnyWaterLeaks = weeklyCampInspection.Galley_IsThereWnyWaterLeaks;
                        weeklyCompInspectionResponseDTO.Galley_IsThereWnyWaterLeaksComment = weeklyCampInspection.Galley_IsThereWnyWaterLeaksComment;
                        weeklyCompInspectionResponseDTO.Galley_WhatTheConditionOfTheChipPanAndfoodOil = weeklyCampInspection.Galley_WhatTheConditionOfTheChipPanAndfoodOil;
                        weeklyCompInspectionResponseDTO.Galley_WhatTheConditionOfTheChipPanAndfoodOilComment = weeklyCampInspection.Galley_WhatTheConditionOfTheChipPanAndfoodOilComment;
                        weeklyCompInspectionResponseDTO.Galley_WhenWasExhaustFans = weeklyCampInspection.Galley_WhenWasExhaustFans;
                        weeklyCompInspectionResponseDTO.Galley_WhenWasExhaustFansComment = weeklyCampInspection.Galley_WhenWasExhaustFansComment;

                        weeklyCompInspectionResponseDTO.Safety_AreFireEmergency = weeklyCampInspection.Safety_AreFireEmergency;
                        weeklyCompInspectionResponseDTO.Safety_AreFireEmergencyComment = weeklyCampInspection.Safety_AreFireEmergencyComment;
                        weeklyCompInspectionResponseDTO.Safety_AreStaffAwareOfFoodHazards = weeklyCampInspection.Safety_AreStaffAwareOfFoodHazards;
                        weeklyCompInspectionResponseDTO.Safety_AreStaffAwareOfFoodHazardsComment = weeklyCampInspection.Safety_AreStaffAwareOfFoodHazardsComment;
                        weeklyCompInspectionResponseDTO.Safety_AreThereAnyPotentialHazards = weeklyCampInspection.Safety_AreThereAnyPotentialHazards;
                        weeklyCompInspectionResponseDTO.Safety_AreThereAnyPotentialHazardsComment = weeklyCampInspection.Safety_AreThereAnyPotentialHazardsComment;
                        weeklyCompInspectionResponseDTO.Safety_AreThereAnyUnsafe = weeklyCampInspection.Safety_AreThereAnyUnsafe;
                        weeklyCompInspectionResponseDTO.Safety_AreThereAnyUnsafeComment = weeklyCampInspection.Safety_AreThereAnyUnsafeComment;
                        weeklyCompInspectionResponseDTO.Safety_DateOfLastCampfireDrill = weeklyCampInspection.Safety_DateOfLastCampfireDrill;
                        weeklyCompInspectionResponseDTO.Safety_DateOfLastCampfireDrillComment = weeklyCampInspection.Safety_DateOfLastCampfireDrillComment;
                        weeklyCompInspectionResponseDTO.Safety_DateOfLastMedicalDrill = weeklyCampInspection.Safety_DateOfLastMedicalDrill;
                        weeklyCompInspectionResponseDTO.Safety_DateOfLastMedicalDrillComment = weeklyCampInspection.Safety_DateOfLastMedicalDrillComment;
                        weeklyCompInspectionResponseDTO.Safety_FirePumpInGoodCondition = weeklyCampInspection.Safety_FirePumpInGoodCondition;
                        weeklyCompInspectionResponseDTO.Safety_FirePumpInGoodConditionComment = weeklyCampInspection.Safety_FirePumpInGoodConditionComment;
                        weeklyCompInspectionResponseDTO.Safety_IsCampEarthing = weeklyCampInspection.Safety_IsCampEarthing;
                        weeklyCompInspectionResponseDTO.Safety_IsCampEarthingComment = weeklyCampInspection.Safety_IsCampEarthingComment;
                        weeklyCompInspectionResponseDTO.Safety_IsTheDiesel = weeklyCampInspection.Safety_IsTheDiesel;
                        weeklyCompInspectionResponseDTO.Safety_IsTheDieselComment = weeklyCampInspection.Safety_IsTheDieselComment;

                        weeklyCompInspectionResponseDTO.Clinic_IsMedicalStockMaintained = weeklyCampInspection.Clinic_IsMedicalStockMaintained;
                        weeklyCompInspectionResponseDTO.Clinic_IsMedicalStockMaintainedComment = weeklyCampInspection.Clinic_IsMedicalStockMaintainedComment;
                        weeklyCompInspectionResponseDTO.Clinic_IsMedicalApparatus = weeklyCampInspection.Clinic_IsMedicalApparatus;
                        weeklyCompInspectionResponseDTO.Clinic_IsMedicalApparatusComment = weeklyCampInspection.Clinic_IsMedicalApparatusComment;
                        weeklyCompInspectionResponseDTO.Clinic_IsMedicalTreatment = weeklyCampInspection.Clinic_IsMedicalTreatment;
                        weeklyCompInspectionResponseDTO.Clinic_IsMedicalTreatmentComment = weeklyCampInspection.Clinic_IsMedicalTreatmentComment;

                        weeklyCompInspectionResponseDTO.Clinic_IsTheClinicCleanAndTidy = weeklyCampInspection.Clinic_IsTheClinicCleanAndTidy;
                        weeklyCompInspectionResponseDTO.Clinic_IsTheClinicCleanAndTidyComment = weeklyCampInspection.Clinic_IsTheClinicCleanAndTidyComment;
                        weeklyCompInspectionResponseDTO.Clinic_RelevantSdsPresent = weeklyCampInspection.Clinic_RelevantSdsPresent;
                        weeklyCompInspectionResponseDTO.Clinic_RelevantSdsPresentComment = weeklyCampInspection.Clinic_RelevantSdsPresentComment;

                        weeklyCompInspectionResponseDTO.Accomodations_AnyLackInCleaning = weeklyCampInspection.Accomodations_AnyLackInCleaning;
                        weeklyCompInspectionResponseDTO.Accomodations_AnyLackInCleaningComment = weeklyCampInspection.Accomodations_AnyLackInCleaningComment;
                        weeklyCompInspectionResponseDTO.Accomodations_AreDoorHingesAndClosures = weeklyCampInspection.Accomodations_AreDoorHingesAndClosures;
                        weeklyCompInspectionResponseDTO.Accomodations_AreDoorHingesAndClosuresComment = weeklyCampInspection.Accomodations_AreDoorHingesAndClosuresComment;
                        weeklyCompInspectionResponseDTO.Accomodations_LockersOfBathroomsAreInstalledWell = weeklyCampInspection.Accomodations_LockersOfBathroomsAreInstalledWell;
                        weeklyCompInspectionResponseDTO.Accomodations_LockersOfBathroomsAreInstalledWellComment = weeklyCampInspection.Accomodations_LockersOfBathroomsAreInstalledWellComment;
                        weeklyCompInspectionResponseDTO.Accomodations_TypesOfCleaningMaterialsUsed = weeklyCampInspection.Accomodations_TypesOfCleaningMaterialsUsed;
                        weeklyCompInspectionResponseDTO.Accomodations_TypesOfCleaningMaterialsUsedComment = weeklyCampInspection.Accomodations_TypesOfCleaningMaterialsUsedComment;

                        weeklyCompInspectionResponseDTO.WaterTanks_AnyWaterLeaks = weeklyCampInspection.WaterTanks_AnyWaterLeaks;
                        weeklyCompInspectionResponseDTO.WaterTanks_AnyWaterLeaksComment = weeklyCampInspection.WaterTanks_AnyWaterLeaksComment;
                        weeklyCompInspectionResponseDTO.WaterTanks_AreWaterTanksHatchesClean = weeklyCampInspection.WaterTanks_AreWaterTanksHatchesClean;
                        weeklyCompInspectionResponseDTO.WaterTanks_AreWaterTanksHatchesCleanComment = weeklyCampInspection.WaterTanks_AreWaterTanksHatchesCleanComment;
                        weeklyCompInspectionResponseDTO.WaterTanks_IsAreaCleanAndTidy = weeklyCampInspection.WaterTanks_IsAreaCleanAndTidy;
                        weeklyCompInspectionResponseDTO.WaterTanks_IsAreaCleanAndTidyComment = weeklyCampInspection.WaterTanks_IsAreaCleanAndTidyComment;
                        weeklyCompInspectionResponseDTO.WaterTanks_WhatIsTheDateOfLastWaterSample = weeklyCampInspection.WaterTanks_WhatIsTheDateOfLastWaterSample;
                        weeklyCompInspectionResponseDTO.WaterTanks_WhatIsTheDateOfLastWaterSampleComment = weeklyCampInspection.WaterTanks_WhatIsTheDateOfLastWaterSampleComment;

                        weeklyCompInspectionResponseDTO.FoodStorage_WhatIsTheGeneralAppearance = weeklyCampInspection.FoodStorage_WhatIsTheGeneralAppearance;
                        weeklyCompInspectionResponseDTO.FoodStorage_WhatIsTheGeneralAppearanceComment = weeklyCampInspection.FoodStorage_WhatIsTheGeneralAppearanceComment;
                        weeklyCompInspectionResponseDTO.FoodStorage_IsThereEnoughDryFood = weeklyCampInspection.FoodStorage_IsThereEnoughDryFood;
                        weeklyCompInspectionResponseDTO.FoodStorage_IsThereEnoughDryFoodComment = weeklyCampInspection.FoodStorage_IsThereEnoughDryFoodComment;
                        weeklyCompInspectionResponseDTO.FoodStorage_IsFoodProperlyStored = weeklyCampInspection.FoodStorage_IsFoodProperlyStored;
                        weeklyCompInspectionResponseDTO.FoodStorage_IsFoodProperlyStoredComment = weeklyCampInspection.FoodStorage_IsFoodProperlyStoredComment;
                        weeklyCompInspectionResponseDTO.FoodStorage_IsFoodProperlyProtectedFromRisk = weeklyCampInspection.FoodStorage_IsFoodProperlyProtectedFromRisk;
                        weeklyCompInspectionResponseDTO.FoodStorage_IsFoodProperlyProtectedFromRiskComment = weeklyCampInspection.FoodStorage_IsFoodProperlyProtectedFromRiskComment;
                        weeklyCompInspectionResponseDTO.FoodStorage_FrozenStoredFood = weeklyCampInspection.FoodStorage_FrozenStoredFood;
                        weeklyCompInspectionResponseDTO.FoodStorage_FrozenStoredFoodComment = weeklyCampInspection.FoodStorage_FrozenStoredFoodComment;
                        weeklyCompInspectionResponseDTO.FoodStorage_AreFrozenFoods = weeklyCampInspection.FoodStorage_AreFrozenFoods;
                        weeklyCompInspectionResponseDTO.FoodStorage_AreFrozenFoodsComment = weeklyCampInspection.FoodStorage_AreFrozenFoodsComment;
                        weeklyCompInspectionResponseDTO.FoodStorage_AreChillerAndFreezerClean = weeklyCampInspection.FoodStorage_AreChillerAndFreezerClean;
                        weeklyCompInspectionResponseDTO.FoodStorage_AreChillerAndFreezerCleanComment = weeklyCampInspection.FoodStorage_AreChillerAndFreezerCleanComment;
                        weeklyCompInspectionResponseDTO.FoodStorage_AreDryFoodsProperlyStored = weeklyCampInspection.FoodStorage_AreDryFoodsProperlyStored;
                        weeklyCompInspectionResponseDTO.FoodStorage_AreDryFoodsProperlyStoredComment = weeklyCampInspection.FoodStorage_AreDryFoodsProperlyStoredComment;

                        weeklyCompInspectionResponseDTO.Laundry_AreAllAppliancesSafety = weeklyCampInspection.Laundry_AreAllAppliancesSafety;
                        weeklyCompInspectionResponseDTO.Laundry_AreAllAppliancesSafetyComment = weeklyCampInspection.Laundry_AreAllAppliancesSafetyComment;
                        weeklyCompInspectionResponseDTO.Laundry_AreAllAppliancesWorking = weeklyCampInspection.Laundry_AreAllAppliancesWorking;
                        weeklyCompInspectionResponseDTO.Laundry_AreAllAppliancesWorkingComment = weeklyCampInspection.Laundry_AreAllAppliancesWorkingComment;
                        weeklyCompInspectionResponseDTO.Laundry_IsLaundryAleanAndTidy = weeklyCampInspection.Laundry_IsLaundryAleanAndTidy;
                        weeklyCompInspectionResponseDTO.Laundry_IsLaundryAleanAndTidyComment = weeklyCampInspection.Laundry_IsLaundryAleanAndTidyComment;
                        weeklyCompInspectionResponseDTO.Laundry_TypesOfChemicalsUsedAreRelevant = weeklyCampInspection.Laundry_TypesOfChemicalsUsedAreRelevant;
                        weeklyCompInspectionResponseDTO.Laundry_TypesOfChemicalsUsedAreRelevantComment = weeklyCampInspection.Laundry_TypesOfChemicalsUsedAreRelevantComment;

                        weeklyCompInspectionResponseDTO.MessHall_AreAllAppliancesWorking = weeklyCampInspection.MessHall_AreAllAppliancesWorking;
                        weeklyCompInspectionResponseDTO.MessHall_AreAllAppliancesWorkingComment = weeklyCampInspection.MessHall_AreAllAppliancesWorkingComment;
                        weeklyCompInspectionResponseDTO.MessHall_AreFlyKillersWorking = weeklyCampInspection.MessHall_AreFlyKillersWorking;
                        weeklyCompInspectionResponseDTO.MessHall_AreFlyKillersWorkingComment = weeklyCampInspection.MessHall_AreFlyKillersWorkingComment;
                        weeklyCompInspectionResponseDTO.MessHall_AreTablesInGoodWorkingCondition = weeklyCampInspection.MessHall_AreTablesInGoodWorkingCondition;
                        weeklyCompInspectionResponseDTO.MessHall_AreTablesInGoodWorkingConditionComment = weeklyCampInspection.MessHall_AreTablesInGoodWorkingConditionComment;
                        weeklyCompInspectionResponseDTO.MessHall_AreWashHandBasins = weeklyCampInspection.MessHall_AreWashHandBasins;
                        weeklyCompInspectionResponseDTO.MessHall_AreWashHandBasinsComment = weeklyCampInspection.MessHall_AreWashHandBasinsComment;
                        weeklyCompInspectionResponseDTO.MessHall_IsMessHallClean = weeklyCampInspection.MessHall_IsMessHallClean;
                        weeklyCompInspectionResponseDTO.MessHall_IsMessHallCleanComment = weeklyCampInspection.MessHall_IsMessHallCleanComment;
                        weeklyCompInspectionResponseDTO.MessHall_RegistersForChangingFoodOil = weeklyCampInspection.MessHall_RegistersForChangingFoodOil;
                        weeklyCompInspectionResponseDTO.MessHall_RegistersForChangingFoodOilComment = weeklyCampInspection.MessHall_RegistersForChangingFoodOilComment;
                        weeklyCompInspectionResponseDTO.MessHall_AllElectricalCables = weeklyCampInspection.MessHall_AllElectricalCables;
                        weeklyCompInspectionResponseDTO.MessHall_AllElectricalCablesComment = weeklyCampInspection.MessHall_AllElectricalCablesComment;


                        weeklyCompInspectionResponseDTO.userName = weeklyCampInspection.user.UserName;
                        weeklyCompInspectionResponseDTO.userID = weeklyCampInspection.user.Id;


                        weeklyCompInspectionResponseDTOs.Add(weeklyCompInspectionResponseDTO);
                    }

                    result.Message = "Success";
                    result.Data = weeklyCompInspectionResponseDTOs;
                    result.Statescode = 200;
                    return result;
                }

            }
            catch (Exception ex)
            {
                result.Statescode = 404;
                result.Message = "data not found";
            }

            return result;

        }


        [HttpPost]
        public ActionResult<ResultDTO> AddWeeklyCampInspection([FromForm] WeeklyCampInspectionDTO weeklyCampInspection )
        {
            ResultDTO result = new ResultDTO();

            if (ModelState.IsValid)
            {
                try
                {

                    WeeklyCampInspection weeklyCampInspectionObj = new WeeklyCampInspection();
                    weeklyCampInspectionObj.Id = default;
                    weeklyCampInspectionObj.RigId = weeklyCampInspection.RigId;
                    weeklyCampInspectionObj.Date = weeklyCampInspection.Date;
                    weeklyCampInspectionObj.GeneralBathRooms_AnyLeaksInPiping = weeklyCampInspection.GeneralBathRooms_AnyLeaksInPiping;
                    weeklyCampInspectionObj.GeneralBathRooms_AnyLeaksInPipingComment = weeklyCampInspection.GeneralBathRooms_AnyLeaksInPipingComment;
                    weeklyCampInspectionObj.GeneralBathRooms_AreAllDoorsInGoodWorkingOrder = weeklyCampInspection.GeneralBathRooms_AreAllDoorsInGoodWorkingOrder;
                    weeklyCampInspectionObj.GeneralBathRooms_AreAllDoorsInGoodWorkingOrderComment = weeklyCampInspection.GeneralBathRooms_AreAllDoorsInGoodWorkingOrderComment;
                    weeklyCampInspectionObj.GeneralBathRooms_AreAllElectricalFixtures = weeklyCampInspection.GeneralBathRooms_AreAllElectricalFixtures;
                    weeklyCampInspectionObj.GeneralBathRooms_AreAllElectricalFixturesComment = weeklyCampInspection.GeneralBathRooms_AreAllElectricalFixturesComment;
                    weeklyCampInspectionObj.GeneralBathRooms_IsTheAreaCleanAndTidy = weeklyCampInspection.GeneralBathRooms_IsTheAreaCleanAndTidy;
                    weeklyCampInspectionObj.GeneralBathRooms_IsTheAreaCleanAndTidyComment = weeklyCampInspection.GeneralBathRooms_IsTheAreaCleanAndTidyComment;

                    weeklyCampInspectionObj.General_AreParking = weeklyCampInspection.General_AreParking;
                    weeklyCampInspectionObj.General_AreParkingComment = weeklyCampInspection.General_AreParkingComment;
                    weeklyCampInspectionObj.General_IsGenerator = weeklyCampInspection.General_IsGenerator;
                    weeklyCampInspectionObj.General_IsGeneratorComment = weeklyCampInspection.General_IsGeneratorComment;
                    weeklyCampInspectionObj.General_IsCampSite = weeklyCampInspection.General_IsCampSite;
                    weeklyCampInspectionObj.General_IsCampSiteComment = weeklyCampInspection.General_IsCampSiteComment;
                    weeklyCampInspectionObj.General_IsAllRubbish = weeklyCampInspection.General_IsAllRubbish;
                    weeklyCampInspectionObj.General_IsAllRubbishComment = weeklyCampInspection.General_IsAllRubbishComment;
                    weeklyCampInspectionObj.General_AreWater = weeklyCampInspection.General_AreWater;
                    weeklyCampInspectionObj.General_AreWaterComment = weeklyCampInspection.General_AreWaterComment;
                    weeklyCampInspectionObj.General_WhatIsGeneralOpinion = weeklyCampInspection.General_WhatIsGeneralOpinion;
                    weeklyCampInspectionObj.General_WhatIsGeneralOpinionComment = weeklyCampInspection.General_WhatIsGeneralOpinionComment;

                    weeklyCampInspectionObj.Galley_AreAllAppliancesWorking = weeklyCampInspection.Galley_AreAllAppliancesWorking;
                    weeklyCampInspectionObj.Galley_AreAllAppliancesWorkingComment = weeklyCampInspection.Galley_AreAllAppliancesWorkingComment;
                    weeklyCampInspectionObj.Galley_AreDishesAndUtensilsClean = weeklyCampInspection.Galley_AreDishesAndUtensilsClean;
                    weeklyCampInspectionObj.Galley_AreDishesAndUtensilsCleanComment = weeklyCampInspection.Galley_AreDishesAndUtensilsCleanComment;
                    weeklyCampInspectionObj.Galley_IsTheGalleyAreaClean = weeklyCampInspection.Galley_IsTheGalleyAreaClean;
                    weeklyCampInspectionObj.Galley_IsTheGalleyAreaCleanComment = weeklyCampInspection.Galley_IsTheGalleyAreaCleanComment;
                    weeklyCampInspectionObj.Galley_IsThereWnyWaterLeaks = weeklyCampInspection.Galley_IsThereWnyWaterLeaks;
                    weeklyCampInspectionObj.Galley_IsThereWnyWaterLeaksComment = weeklyCampInspection.Galley_IsThereWnyWaterLeaksComment;
                    weeklyCampInspectionObj.Galley_WhatTheConditionOfTheChipPanAndfoodOil = weeklyCampInspection.Galley_WhatTheConditionOfTheChipPanAndfoodOil;
                    weeklyCampInspectionObj.Galley_WhatTheConditionOfTheChipPanAndfoodOilComment = weeklyCampInspection.Galley_WhatTheConditionOfTheChipPanAndfoodOilComment;
                    weeklyCampInspectionObj.Galley_WhenWasExhaustFans = weeklyCampInspection.Galley_WhenWasExhaustFans;
                    weeklyCampInspectionObj.Galley_WhenWasExhaustFansComment = weeklyCampInspection.Galley_WhenWasExhaustFansComment;

                    weeklyCampInspectionObj.Safety_AreFireEmergency = weeklyCampInspection.Safety_AreFireEmergency;
                    weeklyCampInspectionObj.Safety_AreFireEmergencyComment = weeklyCampInspection.Safety_AreFireEmergencyComment;
                    weeklyCampInspectionObj.Safety_AreStaffAwareOfFoodHazards = weeklyCampInspection.Safety_AreStaffAwareOfFoodHazards;
                    weeklyCampInspectionObj.Safety_AreStaffAwareOfFoodHazardsComment = weeklyCampInspection.Safety_AreStaffAwareOfFoodHazardsComment;
                    weeklyCampInspectionObj.Safety_AreThereAnyPotentialHazards = weeklyCampInspection.Safety_AreThereAnyPotentialHazards;
                    weeklyCampInspectionObj.Safety_AreThereAnyPotentialHazardsComment = weeklyCampInspection.Safety_AreThereAnyPotentialHazardsComment;
                    weeklyCampInspectionObj.Safety_AreThereAnyUnsafe = weeklyCampInspection.Safety_AreThereAnyUnsafe;
                    weeklyCampInspectionObj.Safety_AreThereAnyUnsafeComment = weeklyCampInspection.Safety_AreThereAnyUnsafeComment;
                    weeklyCampInspectionObj.Safety_DateOfLastCampfireDrill = weeklyCampInspection.Safety_DateOfLastCampfireDrill;
                    weeklyCampInspectionObj.Safety_DateOfLastCampfireDrillComment = weeklyCampInspection.Safety_DateOfLastCampfireDrillComment;
                    weeklyCampInspectionObj.Safety_DateOfLastMedicalDrill = weeklyCampInspection.Safety_DateOfLastMedicalDrill;
                    weeklyCampInspectionObj.Safety_DateOfLastMedicalDrillComment = weeklyCampInspection.Safety_DateOfLastMedicalDrillComment;
                    weeklyCampInspectionObj.Safety_FirePumpInGoodCondition = weeklyCampInspection.Safety_FirePumpInGoodCondition;
                    weeklyCampInspectionObj.Safety_FirePumpInGoodConditionComment = weeklyCampInspection.Safety_FirePumpInGoodConditionComment;
                    weeklyCampInspectionObj.Safety_IsCampEarthing = weeklyCampInspection.Safety_IsCampEarthing;
                    weeklyCampInspectionObj.Safety_IsCampEarthingComment = weeklyCampInspection.Safety_IsCampEarthingComment;
                    weeklyCampInspectionObj.Safety_IsTheDiesel = weeklyCampInspection.Safety_IsTheDiesel;
                    weeklyCampInspectionObj.Safety_IsTheDieselComment = weeklyCampInspection.Safety_IsTheDieselComment;

                    weeklyCampInspectionObj.Clinic_IsMedicalStockMaintained = weeklyCampInspection.Clinic_IsMedicalStockMaintained;
                    weeklyCampInspectionObj.Clinic_IsMedicalStockMaintainedComment = weeklyCampInspection.Clinic_IsMedicalStockMaintainedComment;
                    weeklyCampInspectionObj.Clinic_IsMedicalApparatus = weeklyCampInspection.Clinic_IsMedicalApparatus;
                    weeklyCampInspectionObj.Clinic_IsMedicalApparatusComment = weeklyCampInspection.Clinic_IsMedicalApparatusComment;
                    weeklyCampInspectionObj.Clinic_IsMedicalTreatment = weeklyCampInspection.Clinic_IsMedicalTreatment;
                    weeklyCampInspectionObj.Clinic_IsMedicalTreatmentComment = weeklyCampInspection.Clinic_IsMedicalTreatmentComment;


                    weeklyCampInspectionObj.Clinic_IsTheClinicCleanAndTidy = weeklyCampInspection.Clinic_IsTheClinicCleanAndTidy;
                    weeklyCampInspectionObj.Clinic_IsTheClinicCleanAndTidyComment = weeklyCampInspection.Clinic_IsTheClinicCleanAndTidyComment;
                    weeklyCampInspectionObj.Clinic_RelevantSdsPresent = weeklyCampInspection.Clinic_RelevantSdsPresent;
                    weeklyCampInspectionObj.Clinic_RelevantSdsPresentComment = weeklyCampInspection.Clinic_RelevantSdsPresentComment;

                    weeklyCampInspectionObj.Accomodations_AnyLackInCleaning = weeklyCampInspection.Accomodations_AnyLackInCleaning;
                    weeklyCampInspectionObj.Accomodations_AnyLackInCleaningComment = weeklyCampInspection.Accomodations_AnyLackInCleaningComment;
                    weeklyCampInspectionObj.Accomodations_AreDoorHingesAndClosures = weeklyCampInspection.Accomodations_AreDoorHingesAndClosures;
                    weeklyCampInspectionObj.Accomodations_AreDoorHingesAndClosuresComment = weeklyCampInspection.Accomodations_AreDoorHingesAndClosuresComment;
                    weeklyCampInspectionObj.Accomodations_LockersOfBathroomsAreInstalledWell = weeklyCampInspection.Accomodations_LockersOfBathroomsAreInstalledWell;
                    weeklyCampInspectionObj.Accomodations_LockersOfBathroomsAreInstalledWellComment = weeklyCampInspection.Accomodations_LockersOfBathroomsAreInstalledWellComment;
                    weeklyCampInspectionObj.Accomodations_TypesOfCleaningMaterialsUsed = weeklyCampInspection.Accomodations_TypesOfCleaningMaterialsUsed;
                    weeklyCampInspectionObj.Accomodations_TypesOfCleaningMaterialsUsedComment = weeklyCampInspection.Accomodations_TypesOfCleaningMaterialsUsedComment;

                    weeklyCampInspectionObj.WaterTanks_AnyWaterLeaks = weeklyCampInspection.WaterTanks_AnyWaterLeaks;
                    weeklyCampInspectionObj.WaterTanks_AnyWaterLeaksComment = weeklyCampInspection.WaterTanks_AnyWaterLeaksComment;
                    weeklyCampInspectionObj.WaterTanks_AreWaterTanksHatchesClean = weeklyCampInspection.WaterTanks_AreWaterTanksHatchesClean;
                    weeklyCampInspectionObj.WaterTanks_AreWaterTanksHatchesCleanComment = weeklyCampInspection.WaterTanks_AreWaterTanksHatchesCleanComment;
                    weeklyCampInspectionObj.WaterTanks_IsAreaCleanAndTidy = weeklyCampInspection.WaterTanks_IsAreaCleanAndTidy;
                    weeklyCampInspectionObj.WaterTanks_IsAreaCleanAndTidyComment = weeklyCampInspection.WaterTanks_IsAreaCleanAndTidyComment;
                    weeklyCampInspectionObj.WaterTanks_WhatIsTheDateOfLastWaterSample = weeklyCampInspection.WaterTanks_WhatIsTheDateOfLastWaterSample;
                    weeklyCampInspectionObj.WaterTanks_WhatIsTheDateOfLastWaterSampleComment = weeklyCampInspection.WaterTanks_WhatIsTheDateOfLastWaterSampleComment;

                    weeklyCampInspectionObj.FoodStorage_WhatIsTheGeneralAppearance = weeklyCampInspection.FoodStorage_WhatIsTheGeneralAppearance;
                    weeklyCampInspectionObj.FoodStorage_WhatIsTheGeneralAppearanceComment = weeklyCampInspection.FoodStorage_WhatIsTheGeneralAppearanceComment;
                    weeklyCampInspectionObj.FoodStorage_IsThereEnoughDryFood = weeklyCampInspection.FoodStorage_IsThereEnoughDryFood;
                    weeklyCampInspectionObj.FoodStorage_IsThereEnoughDryFoodComment = weeklyCampInspection.FoodStorage_IsThereEnoughDryFoodComment;
                    weeklyCampInspectionObj.FoodStorage_IsFoodProperlyStored = weeklyCampInspection.FoodStorage_IsFoodProperlyStored;
                    weeklyCampInspectionObj.FoodStorage_IsFoodProperlyStoredComment = weeklyCampInspection.FoodStorage_IsFoodProperlyStoredComment;
                    weeklyCampInspectionObj.FoodStorage_IsFoodProperlyProtectedFromRisk = weeklyCampInspection.FoodStorage_IsFoodProperlyProtectedFromRisk;
                    weeklyCampInspectionObj.FoodStorage_IsFoodProperlyProtectedFromRiskComment = weeklyCampInspection.FoodStorage_IsFoodProperlyProtectedFromRiskComment;
                    weeklyCampInspectionObj.FoodStorage_FrozenStoredFood = weeklyCampInspection.FoodStorage_FrozenStoredFood;
                    weeklyCampInspectionObj.FoodStorage_FrozenStoredFoodComment = weeklyCampInspection.FoodStorage_FrozenStoredFoodComment;
                    weeklyCampInspectionObj.FoodStorage_AreFrozenFoods = weeklyCampInspection.FoodStorage_AreFrozenFoods;
                    weeklyCampInspectionObj.FoodStorage_AreFrozenFoodsComment = weeklyCampInspection.FoodStorage_AreFrozenFoodsComment;
                    weeklyCampInspectionObj.FoodStorage_AreChillerAndFreezerClean = weeklyCampInspection.FoodStorage_AreChillerAndFreezerClean;
                    weeklyCampInspectionObj.FoodStorage_AreChillerAndFreezerCleanComment = weeklyCampInspection.FoodStorage_AreChillerAndFreezerCleanComment;
                    weeklyCampInspectionObj.FoodStorage_AreDryFoodsProperlyStored = weeklyCampInspection.FoodStorage_AreDryFoodsProperlyStored;
                    weeklyCampInspectionObj.FoodStorage_AreDryFoodsProperlyStoredComment = weeklyCampInspection.FoodStorage_AreDryFoodsProperlyStoredComment;

                    weeklyCampInspectionObj.Laundry_AreAllAppliancesSafety = weeklyCampInspection.Laundry_AreAllAppliancesSafety;
                    weeklyCampInspectionObj.Laundry_AreAllAppliancesSafetyComment = weeklyCampInspection.Laundry_AreAllAppliancesSafetyComment;
                    weeklyCampInspectionObj.Laundry_AreAllAppliancesWorking = weeklyCampInspection.Laundry_AreAllAppliancesWorking;
                    weeklyCampInspectionObj.Laundry_AreAllAppliancesWorkingComment = weeklyCampInspection.Laundry_AreAllAppliancesWorkingComment;
                    weeklyCampInspectionObj.Laundry_IsLaundryAleanAndTidy = weeklyCampInspection.Laundry_IsLaundryAleanAndTidy;
                    weeklyCampInspectionObj.Laundry_IsLaundryAleanAndTidyComment = weeklyCampInspection.Laundry_IsLaundryAleanAndTidyComment;
                    weeklyCampInspectionObj.Laundry_TypesOfChemicalsUsedAreRelevant = weeklyCampInspection.Laundry_TypesOfChemicalsUsedAreRelevant;
                    weeklyCampInspectionObj.Laundry_TypesOfChemicalsUsedAreRelevantComment = weeklyCampInspection.Laundry_TypesOfChemicalsUsedAreRelevantComment;

                    weeklyCampInspectionObj.MessHall_AreAllAppliancesWorking = weeklyCampInspection.MessHall_AreAllAppliancesWorking;
                    weeklyCampInspectionObj.MessHall_AreAllAppliancesWorkingComment = weeklyCampInspection.MessHall_AreAllAppliancesWorkingComment;
                    weeklyCampInspectionObj.MessHall_AreFlyKillersWorking = weeklyCampInspection.MessHall_AreFlyKillersWorking;
                    weeklyCampInspectionObj.MessHall_AreFlyKillersWorkingComment = weeklyCampInspection.MessHall_AreFlyKillersWorkingComment;
                    weeklyCampInspectionObj.MessHall_AreTablesInGoodWorkingCondition = weeklyCampInspection.MessHall_AreTablesInGoodWorkingCondition;
                    weeklyCampInspectionObj.MessHall_AreTablesInGoodWorkingConditionComment = weeklyCampInspection.MessHall_AreTablesInGoodWorkingConditionComment;
                    weeklyCampInspectionObj.MessHall_AreWashHandBasins = weeklyCampInspection.MessHall_AreWashHandBasins;
                    weeklyCampInspectionObj.MessHall_AreWashHandBasinsComment = weeklyCampInspection.MessHall_AreWashHandBasinsComment;
                    weeklyCampInspectionObj.MessHall_IsMessHallClean = weeklyCampInspection.MessHall_IsMessHallClean;
                    weeklyCampInspectionObj.MessHall_IsMessHallCleanComment = weeklyCampInspection.MessHall_IsMessHallCleanComment;
                    weeklyCampInspectionObj.MessHall_RegistersForChangingFoodOil = weeklyCampInspection.MessHall_RegistersForChangingFoodOil;
                    weeklyCampInspectionObj.MessHall_RegistersForChangingFoodOilComment = weeklyCampInspection.MessHall_RegistersForChangingFoodOilComment;
                    weeklyCampInspectionObj.MessHall_AllElectricalCables = weeklyCampInspection.MessHall_AllElectricalCables;
                    weeklyCampInspectionObj.MessHall_AllElectricalCablesComment = weeklyCampInspection.MessHall_AllElectricalCablesComment;
                   
                    weeklyCampInspectionObj.userID = weeklyCampInspection.userID;

                    WeeklyCampInspectionRepo.create(weeklyCampInspectionObj);


                    result.Message = "Success";
                    result.Data = weeklyCampInspectionObj;
                    result.Statescode = 200;
                }
                catch (Exception ex)
                {
                    result.Message = "Error in inserting";
                    result.Statescode = 400;
                }
            }
            return result;
        }


        [HttpPut("{id:int}")]
        public ActionResult<ResultDTO> Put(int id, [FromForm] WeeklyCampInspectionsResponseDTO   newweeklyCampInspection) //[FromBody] string value)
        {
            ResultDTO result = new ResultDTO();

            if (ModelState.IsValid)
            {
                try
                {
                    WeeklyCampInspection   orgweeklyCampInspection = WeeklyCampInspectionRepo.getbyid(id);

                    newweeklyCampInspection.Id = orgweeklyCampInspection.Id;
                    orgweeklyCampInspection.RigId = newweeklyCampInspection.RigId;
                    orgweeklyCampInspection.Date = newweeklyCampInspection.Date;
                    orgweeklyCampInspection.GeneralBathRooms_AnyLeaksInPiping = newweeklyCampInspection.GeneralBathRooms_AnyLeaksInPiping;
                    orgweeklyCampInspection.GeneralBathRooms_AnyLeaksInPipingComment = newweeklyCampInspection.GeneralBathRooms_AnyLeaksInPipingComment;
                    orgweeklyCampInspection.GeneralBathRooms_AreAllDoorsInGoodWorkingOrder = newweeklyCampInspection.GeneralBathRooms_AreAllDoorsInGoodWorkingOrder;
                    orgweeklyCampInspection.GeneralBathRooms_AreAllDoorsInGoodWorkingOrderComment = newweeklyCampInspection.GeneralBathRooms_AreAllDoorsInGoodWorkingOrderComment;
                    orgweeklyCampInspection.GeneralBathRooms_AreAllElectricalFixtures = newweeklyCampInspection.GeneralBathRooms_AreAllElectricalFixtures;
                    orgweeklyCampInspection.GeneralBathRooms_AreAllElectricalFixturesComment = newweeklyCampInspection.GeneralBathRooms_AreAllElectricalFixturesComment;
                    orgweeklyCampInspection.GeneralBathRooms_IsTheAreaCleanAndTidy = newweeklyCampInspection.GeneralBathRooms_IsTheAreaCleanAndTidy;
                    orgweeklyCampInspection.GeneralBathRooms_IsTheAreaCleanAndTidyComment = newweeklyCampInspection.GeneralBathRooms_IsTheAreaCleanAndTidyComment;

                    orgweeklyCampInspection.General_AreParking = newweeklyCampInspection.General_AreParking;
                    orgweeklyCampInspection.General_AreParkingComment = newweeklyCampInspection.General_AreParkingComment;
                    orgweeklyCampInspection.General_IsGenerator = newweeklyCampInspection.General_IsGenerator;
                    orgweeklyCampInspection.General_IsGeneratorComment = newweeklyCampInspection.General_IsGeneratorComment;
                    orgweeklyCampInspection.General_IsCampSite = newweeklyCampInspection.General_IsCampSite;
                    orgweeklyCampInspection.General_IsCampSiteComment = newweeklyCampInspection.General_IsCampSiteComment;
                    orgweeklyCampInspection.General_IsAllRubbish = newweeklyCampInspection.General_IsAllRubbish;
                    orgweeklyCampInspection.General_IsAllRubbishComment = newweeklyCampInspection.General_IsAllRubbishComment;
                    orgweeklyCampInspection.General_AreWater = newweeklyCampInspection.General_AreWater;
                    orgweeklyCampInspection.General_AreWaterComment = newweeklyCampInspection.General_AreWaterComment;
                    orgweeklyCampInspection.General_WhatIsGeneralOpinion = newweeklyCampInspection.General_WhatIsGeneralOpinion;
                    orgweeklyCampInspection.General_WhatIsGeneralOpinionComment = newweeklyCampInspection.General_WhatIsGeneralOpinionComment;

                    orgweeklyCampInspection.Galley_AreAllAppliancesWorking = newweeklyCampInspection.Galley_AreAllAppliancesWorking;
                    orgweeklyCampInspection.Galley_AreAllAppliancesWorkingComment = newweeklyCampInspection.Galley_AreAllAppliancesWorkingComment;
                    orgweeklyCampInspection.Galley_AreDishesAndUtensilsClean = newweeklyCampInspection.Galley_AreDishesAndUtensilsClean;
                    orgweeklyCampInspection.Galley_AreDishesAndUtensilsCleanComment = newweeklyCampInspection.Galley_AreDishesAndUtensilsCleanComment;
                    orgweeklyCampInspection.Galley_IsTheGalleyAreaClean = newweeklyCampInspection.Galley_IsTheGalleyAreaClean;
                    orgweeklyCampInspection.Galley_IsTheGalleyAreaCleanComment = newweeklyCampInspection.Galley_IsTheGalleyAreaCleanComment;
                    orgweeklyCampInspection.Galley_IsThereWnyWaterLeaks = newweeklyCampInspection.Galley_IsThereWnyWaterLeaks;
                    orgweeklyCampInspection.Galley_IsThereWnyWaterLeaksComment = newweeklyCampInspection.Galley_IsThereWnyWaterLeaksComment;
                    orgweeklyCampInspection.Galley_WhatTheConditionOfTheChipPanAndfoodOil = newweeklyCampInspection.Galley_WhatTheConditionOfTheChipPanAndfoodOil;
                    orgweeklyCampInspection.Galley_WhatTheConditionOfTheChipPanAndfoodOilComment = newweeklyCampInspection.Galley_WhatTheConditionOfTheChipPanAndfoodOilComment;
                    orgweeklyCampInspection.Galley_WhenWasExhaustFans = newweeklyCampInspection.Galley_WhenWasExhaustFans;
                    orgweeklyCampInspection.Galley_WhenWasExhaustFansComment = newweeklyCampInspection.Galley_WhenWasExhaustFansComment;

                    orgweeklyCampInspection.Safety_AreFireEmergency = newweeklyCampInspection.Safety_AreFireEmergency;
                    orgweeklyCampInspection.Safety_AreFireEmergencyComment = newweeklyCampInspection.Safety_AreFireEmergencyComment;
                    orgweeklyCampInspection.Safety_AreStaffAwareOfFoodHazards = newweeklyCampInspection.Safety_AreStaffAwareOfFoodHazards;
                    orgweeklyCampInspection.Safety_AreStaffAwareOfFoodHazardsComment = newweeklyCampInspection.Safety_AreStaffAwareOfFoodHazardsComment;
                    orgweeklyCampInspection.Safety_AreThereAnyPotentialHazards = newweeklyCampInspection.Safety_AreThereAnyPotentialHazards;
                    orgweeklyCampInspection.Safety_AreThereAnyPotentialHazardsComment = newweeklyCampInspection.Safety_AreThereAnyPotentialHazardsComment;
                    orgweeklyCampInspection.Safety_AreThereAnyUnsafe = newweeklyCampInspection.Safety_AreThereAnyUnsafe;
                    orgweeklyCampInspection.Safety_AreThereAnyUnsafeComment = newweeklyCampInspection.Safety_AreThereAnyUnsafeComment;
                    orgweeklyCampInspection.Safety_DateOfLastCampfireDrill = newweeklyCampInspection.Safety_DateOfLastCampfireDrill;
                    orgweeklyCampInspection.Safety_DateOfLastCampfireDrillComment = newweeklyCampInspection.Safety_DateOfLastCampfireDrillComment;
                    orgweeklyCampInspection.Safety_DateOfLastMedicalDrill = newweeklyCampInspection.Safety_DateOfLastMedicalDrill;
                    orgweeklyCampInspection.Safety_DateOfLastMedicalDrillComment = newweeklyCampInspection.Safety_DateOfLastMedicalDrillComment;
                    orgweeklyCampInspection.Safety_FirePumpInGoodCondition = newweeklyCampInspection.Safety_FirePumpInGoodCondition;
                    orgweeklyCampInspection.Safety_FirePumpInGoodConditionComment = newweeklyCampInspection.Safety_FirePumpInGoodConditionComment;
                    orgweeklyCampInspection.Safety_IsCampEarthing = newweeklyCampInspection.Safety_IsCampEarthing;
                    orgweeklyCampInspection.Safety_IsCampEarthingComment = newweeklyCampInspection.Safety_IsCampEarthingComment;
                    orgweeklyCampInspection.Safety_IsTheDiesel = newweeklyCampInspection.Safety_IsTheDiesel;
                    orgweeklyCampInspection.Safety_IsTheDieselComment = newweeklyCampInspection.Safety_IsTheDieselComment;

                    orgweeklyCampInspection.Clinic_IsMedicalStockMaintained = newweeklyCampInspection.Clinic_IsMedicalStockMaintained;
                    orgweeklyCampInspection.Clinic_IsMedicalStockMaintainedComment = newweeklyCampInspection.Clinic_IsMedicalStockMaintainedComment;
                    orgweeklyCampInspection.Clinic_IsMedicalApparatus = newweeklyCampInspection.Clinic_IsMedicalApparatus;
                    orgweeklyCampInspection.Clinic_IsMedicalApparatusComment = newweeklyCampInspection.Clinic_IsMedicalApparatusComment;
                    orgweeklyCampInspection.Clinic_IsMedicalTreatment = newweeklyCampInspection.Clinic_IsMedicalTreatment;
                    orgweeklyCampInspection.Clinic_IsMedicalTreatmentComment = newweeklyCampInspection.Clinic_IsMedicalTreatmentComment;
                    orgweeklyCampInspection.Clinic_IsTheClinicCleanAndTidy = newweeklyCampInspection.Clinic_IsTheClinicCleanAndTidy;
                    orgweeklyCampInspection.Clinic_IsTheClinicCleanAndTidyComment = newweeklyCampInspection.Clinic_IsTheClinicCleanAndTidyComment;
                    orgweeklyCampInspection.Clinic_RelevantSdsPresent = newweeklyCampInspection.Clinic_RelevantSdsPresent;
                    orgweeklyCampInspection.Clinic_RelevantSdsPresentComment = newweeklyCampInspection.Clinic_RelevantSdsPresentComment;

                    orgweeklyCampInspection.Accomodations_AnyLackInCleaning = newweeklyCampInspection.Accomodations_AnyLackInCleaning;
                    orgweeklyCampInspection.Accomodations_AnyLackInCleaningComment = newweeklyCampInspection.Accomodations_AnyLackInCleaningComment;
                    orgweeklyCampInspection.Accomodations_AreDoorHingesAndClosures = newweeklyCampInspection.Accomodations_AreDoorHingesAndClosures;
                    orgweeklyCampInspection.Accomodations_AreDoorHingesAndClosuresComment = newweeklyCampInspection.Accomodations_AreDoorHingesAndClosuresComment;
                    orgweeklyCampInspection.Accomodations_LockersOfBathroomsAreInstalledWell = newweeklyCampInspection.Accomodations_LockersOfBathroomsAreInstalledWell;
                    orgweeklyCampInspection.Accomodations_LockersOfBathroomsAreInstalledWellComment = newweeklyCampInspection.Accomodations_LockersOfBathroomsAreInstalledWellComment;
                    orgweeklyCampInspection.Accomodations_TypesOfCleaningMaterialsUsed = newweeklyCampInspection.Accomodations_TypesOfCleaningMaterialsUsed;
                    orgweeklyCampInspection.Accomodations_TypesOfCleaningMaterialsUsedComment = newweeklyCampInspection.Accomodations_TypesOfCleaningMaterialsUsedComment;

                    orgweeklyCampInspection.WaterTanks_AnyWaterLeaks = newweeklyCampInspection.WaterTanks_AnyWaterLeaks;
                    orgweeklyCampInspection.WaterTanks_AnyWaterLeaksComment = newweeklyCampInspection.WaterTanks_AnyWaterLeaksComment;
                    orgweeklyCampInspection.WaterTanks_AreWaterTanksHatchesClean = newweeklyCampInspection.WaterTanks_AreWaterTanksHatchesClean;
                    orgweeklyCampInspection.WaterTanks_AreWaterTanksHatchesCleanComment = newweeklyCampInspection.WaterTanks_AreWaterTanksHatchesCleanComment;
                    orgweeklyCampInspection.WaterTanks_IsAreaCleanAndTidy = newweeklyCampInspection.WaterTanks_IsAreaCleanAndTidy;
                    orgweeklyCampInspection.WaterTanks_IsAreaCleanAndTidyComment = newweeklyCampInspection.WaterTanks_IsAreaCleanAndTidyComment;
                    orgweeklyCampInspection.WaterTanks_WhatIsTheDateOfLastWaterSample = newweeklyCampInspection.WaterTanks_WhatIsTheDateOfLastWaterSample;
                    orgweeklyCampInspection.WaterTanks_WhatIsTheDateOfLastWaterSampleComment = newweeklyCampInspection.WaterTanks_WhatIsTheDateOfLastWaterSampleComment;

                    orgweeklyCampInspection.FoodStorage_WhatIsTheGeneralAppearance = newweeklyCampInspection.FoodStorage_WhatIsTheGeneralAppearance;
                    orgweeklyCampInspection.FoodStorage_WhatIsTheGeneralAppearanceComment = newweeklyCampInspection.FoodStorage_WhatIsTheGeneralAppearanceComment;
                    orgweeklyCampInspection.FoodStorage_IsThereEnoughDryFood = newweeklyCampInspection.FoodStorage_IsThereEnoughDryFood;
                    orgweeklyCampInspection.FoodStorage_IsThereEnoughDryFoodComment = newweeklyCampInspection.FoodStorage_IsThereEnoughDryFoodComment;
                    orgweeklyCampInspection.FoodStorage_IsFoodProperlyStored = newweeklyCampInspection.FoodStorage_IsFoodProperlyStored;
                    orgweeklyCampInspection.FoodStorage_IsFoodProperlyStoredComment = newweeklyCampInspection.FoodStorage_IsFoodProperlyStoredComment;
                    orgweeklyCampInspection.FoodStorage_IsFoodProperlyProtectedFromRisk = newweeklyCampInspection.FoodStorage_IsFoodProperlyProtectedFromRisk;
                    orgweeklyCampInspection.FoodStorage_IsFoodProperlyProtectedFromRiskComment = newweeklyCampInspection.FoodStorage_IsFoodProperlyProtectedFromRiskComment;
                    orgweeklyCampInspection.FoodStorage_FrozenStoredFood = newweeklyCampInspection.FoodStorage_FrozenStoredFood;
                    orgweeklyCampInspection.FoodStorage_FrozenStoredFoodComment = newweeklyCampInspection.FoodStorage_FrozenStoredFoodComment;
                    orgweeklyCampInspection.FoodStorage_AreFrozenFoods = newweeklyCampInspection.FoodStorage_AreFrozenFoods;
                    orgweeklyCampInspection.FoodStorage_AreFrozenFoodsComment = newweeklyCampInspection.FoodStorage_AreFrozenFoodsComment;
                    orgweeklyCampInspection.FoodStorage_AreChillerAndFreezerClean = newweeklyCampInspection.FoodStorage_AreChillerAndFreezerClean;
                    orgweeklyCampInspection.FoodStorage_AreChillerAndFreezerCleanComment = newweeklyCampInspection.FoodStorage_AreChillerAndFreezerCleanComment;
                    orgweeklyCampInspection.FoodStorage_AreDryFoodsProperlyStored = newweeklyCampInspection.FoodStorage_AreDryFoodsProperlyStored;
                    orgweeklyCampInspection.FoodStorage_AreDryFoodsProperlyStoredComment = newweeklyCampInspection.FoodStorage_AreDryFoodsProperlyStoredComment;

                    orgweeklyCampInspection.Laundry_AreAllAppliancesSafety = newweeklyCampInspection.Laundry_AreAllAppliancesSafety;
                    orgweeklyCampInspection.Laundry_AreAllAppliancesSafetyComment = newweeklyCampInspection.Laundry_AreAllAppliancesSafetyComment;
                    orgweeklyCampInspection.Laundry_AreAllAppliancesWorking = newweeklyCampInspection.Laundry_AreAllAppliancesWorking;
                    orgweeklyCampInspection.Laundry_AreAllAppliancesWorkingComment = newweeklyCampInspection.Laundry_AreAllAppliancesWorkingComment;
                    orgweeklyCampInspection.Laundry_IsLaundryAleanAndTidy = newweeklyCampInspection.Laundry_IsLaundryAleanAndTidy;
                    orgweeklyCampInspection.Laundry_IsLaundryAleanAndTidyComment = newweeklyCampInspection.Laundry_IsLaundryAleanAndTidyComment;
                    orgweeklyCampInspection.Laundry_TypesOfChemicalsUsedAreRelevant = newweeklyCampInspection.Laundry_TypesOfChemicalsUsedAreRelevant;
                    orgweeklyCampInspection.Laundry_TypesOfChemicalsUsedAreRelevantComment = newweeklyCampInspection.Laundry_TypesOfChemicalsUsedAreRelevantComment;

                    orgweeklyCampInspection.MessHall_AreAllAppliancesWorking = newweeklyCampInspection.MessHall_AreAllAppliancesWorking;
                    orgweeklyCampInspection.MessHall_AreAllAppliancesWorkingComment = newweeklyCampInspection.MessHall_AreAllAppliancesWorkingComment;
                    orgweeklyCampInspection.MessHall_AreFlyKillersWorking = newweeklyCampInspection.MessHall_AreFlyKillersWorking;
                    orgweeklyCampInspection.MessHall_AreFlyKillersWorkingComment = newweeklyCampInspection.MessHall_AreFlyKillersWorkingComment;
                    orgweeklyCampInspection.MessHall_AreTablesInGoodWorkingCondition = newweeklyCampInspection.MessHall_AreTablesInGoodWorkingCondition;
                    orgweeklyCampInspection.MessHall_AreTablesInGoodWorkingConditionComment = newweeklyCampInspection.MessHall_AreTablesInGoodWorkingConditionComment;
                    orgweeklyCampInspection.MessHall_AreWashHandBasins = newweeklyCampInspection.MessHall_AreWashHandBasins;
                    orgweeklyCampInspection.MessHall_AreWashHandBasinsComment = newweeklyCampInspection.MessHall_AreWashHandBasinsComment;
                    orgweeklyCampInspection.MessHall_IsMessHallClean = newweeklyCampInspection.MessHall_IsMessHallClean;
                    orgweeklyCampInspection.MessHall_IsMessHallCleanComment = newweeklyCampInspection.MessHall_IsMessHallCleanComment;
                    orgweeklyCampInspection.MessHall_RegistersForChangingFoodOil = newweeklyCampInspection.MessHall_RegistersForChangingFoodOil;
                    orgweeklyCampInspection.MessHall_RegistersForChangingFoodOilComment = newweeklyCampInspection.MessHall_RegistersForChangingFoodOilComment;
                    orgweeklyCampInspection.MessHall_AllElectricalCables = newweeklyCampInspection.MessHall_AllElectricalCables;
                    orgweeklyCampInspection.MessHall_AllElectricalCablesComment = newweeklyCampInspection.MessHall_AllElectricalCablesComment;

                    orgweeklyCampInspection.userID = newweeklyCampInspection.userID;
                    //orgweeklyCampInspection.user.UserName= newweeklyCampInspection.userName;


                    WeeklyCampInspectionRepo.update(orgweeklyCampInspection);
                        result.Data = orgweeklyCampInspection;
                        result.Statescode = 200;
                        return result;

                   
                }
                catch (Exception ex)
                {
                    result.Message = "Error in Updating";
                    result.Statescode = 400;
                    return result;
                }
            }
            return BadRequest(ModelState);
        }

        [HttpPut("Delete/{id:int}")]
        public ActionResult<ResultDTO> Delete(int id) //[FromBody] string value)
        {
            ResultDTO result = new ResultDTO();
            try
            {
                WeeklyCampInspection weeklyCampInspection = WeeklyCampInspectionRepo.getbyid(id);
                weeklyCampInspection.IsDeleted = true;
                WeeklyCampInspectionRepo.update(weeklyCampInspection);
                result.Data = weeklyCampInspection;
                result.Statescode = 200;
                result.Message = "Success";
            }
            catch (Exception ex)
            {
                result.Message = "Error in deleted";
                result.Statescode = 400;
            }

            return result;
        }
    }
}

