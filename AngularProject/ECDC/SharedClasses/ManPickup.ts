export class ManPickup {
  constructor(
   public id: number,
   public  inspectionItem: string,
   public status: string,
   public remarks: string,
   public item:string,

   public isDeleted: boolean
    ) {
  }
}
