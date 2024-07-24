export class HSEEquipment{
  constructor(
    public id:number,

		public item:string,

		public onSite:number,

		public sentForMaintenance:number,

		public handoverId:number,


		public isDeleted:boolean
  ){}
}
