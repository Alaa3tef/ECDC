export class PermitsToWorkList{
  constructor(
    public id:number,
	public permitsToWorkListName: string,
	public dailyLiftingReportId: number,
	public isDeleted:boolean
  ){}
}
