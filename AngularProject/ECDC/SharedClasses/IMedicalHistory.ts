export interface IMedicalHistory{
    id:number ,

     rigId:number ,

      date:Date ,
      company:string ,
     code:string ,
      name:string ,
      jop:string ,
      address:string ,

     dateOfBirth:Date ,
      contact:string ,
     telephoneNumber:number ,
       socia_DoYouSmokeAnswer:string ,
        socia_DoYouSmokeComment:string ,

       socia_DoYouExerciseRegularlyAnswer:string ,
        socia_DoYouExerciseRegularlyComment:string ,

       socia_HaveYouBeenExposedAnswer:string ,
        socia_HaveYouBeenExposedComment:string ,

       socia_HaveYouEverDevelopedAnswer:string ,
        socia_HaveYouEverDevelopedComment :string,

       socia_HaveYouSufferedAnswer :string,
        socia_HaveYouSufferedComment :string,

      family_AreYouCurrentlyBeingTreatedAnswer:string ,
       family_AreYouCurrentlyBeingTreatedComment :string,

      family_AreYouCurrentlyReceivingAnyMedicalAnswer :string,
       family_AreYouCurrentlyReceivingAnyMedicalComment :string,

      family_HighBloodPressureAnswer :string,
       family_HighBloodPressureComment :string,

      family_HeartDiseaseAnswer :string,
       family_HeartDiseaseComment :string,

      family_COPDAnswer :string,
       family_COPDComment :string,

      family_DiabetesAnswer :string,
       family_DiabetesComment :string,

      family_GITAnswer :string,
       family_GITComment :string,

      family_KidneyAnswer :string,
       family_KidneyComment :string,

      family_NeurologicalAnswer :string,
       family_NeurologicalComment :string,

      family_InfectiousAnswer :string,
       family_InfectiousComment :string,

      family_DizzinessAnswer :string,
       family_DizzinessComment :string,

      family_DiscProlapseAnswer :string,
       family_DiscProlapseComment :string,

      family_AllergyAnswer :string,
       family_AllergyComment :string,

      family_HospitalizationAnswer :string,
       family_HospitalizationComment :string,

      family_SurgeryAnswer :string,
       family_SurgeryComment :string,

      family_DepressionAnswer :string,
       family_DepressionComment :string,

      family_DoAnyOfYour1stDegreeFamilyAnswer :string,
       family_DoAnyOfYour1stDegreeFamilyComment :string,

      generalExamination_Weight :number,
      generalExamination_Height :number,
      generalExamination_BloodPressure :number,
      generalExamination_HeartRate :number,

       doctorComments :string,
      doctorName :string,

     isDeleted:boolean ,

      userID:number ,
}
