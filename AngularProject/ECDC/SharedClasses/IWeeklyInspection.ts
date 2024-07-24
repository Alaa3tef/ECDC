
export interface IWeeklyInspection  {
  id: number,
  rigId: number,
  date: Date,
    wellName :string,
    client :string,

    eyeStatus :string,
    eyeWeeklyFindings :string,

    firstAidStatus :string,
    firstAidWeeklyFindings :string,

    scbaStatus :string,
    scbaWeeklyFindings :string,
   scba30min :number,
   scba15min :number,
   scba10min :number,

    portableGasStatus :string,
    portableGasWeeklyFindings :string,
   portableGasMuti :number,
   portableGasSingle :number,
   expeiryDate :Date,

    firePumpStatus :string,
    firePumpWeeklyFindings :string,

    weldingStatus :string,
    weldingWeeklyFindings :string,

    windStatus :string,
    windWeeklyFindings :string,

    smokeStatus :string,
    smokeWeeklyFindings :string,

    fireExtinguishersStatus :string,
    fireExtinguishersWeeklyFindings :string,

    derrickmanStatus :string,
    derrickmanWeeklyFindings :string,

    workingStatus :string,
    workingWeeklyFindings :string,

    portableLadderStatus :string,
    portableLadderWeeklyFindings :string,

    safetyStatus :string,
    safetyWeeklyFindings :string,

    fallStatus :string,
    fallWeeklyFindings :string,

    craneStatus :string,
    craneWeeklyFindings :string,

    forkStatus :string,
    forkWeeklyFindings :string,

    droppedInspectionStatus :string,
    droppedInspectionWeeklyFindings :string,

    electricalStatus :string,
    electricalWeeklyFindings :string,

    circuitStatus :string,
    circuitWeeklyFindings :string,

    earthingStatus :string,
    earthingWeeklyFindings :string,
   earthingMaximum :number,
   earthingMin :number,

   code :number,
    positionName :string,
    name :string,

  userID: string,
  isDeleted: boolean

}
