export class HSEInventory{
  constructor(
    public id:number,

		public item:string,

		public stockAtStorage:number,

		public releasedFromStorage:number,

		public newlyRecieved:number,

		public handoverId:number,

		public isDeleted:boolean
  ){}
}
