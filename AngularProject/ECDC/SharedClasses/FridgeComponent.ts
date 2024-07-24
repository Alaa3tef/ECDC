export class FridgeComponent {
  constructor(
    public id: number,
		public item:string,
		public quantity:number,
		public expireDate:Date,
    public isDeleted: boolean
    ) {
  }
}
