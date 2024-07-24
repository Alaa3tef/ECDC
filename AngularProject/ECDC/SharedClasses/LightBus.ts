export class LightBus {
  constructor(
   public id: number,
  public  inspectionItem: string,
  public item:string,
   public status: string,
   public remarks: string,
    public isDeleted: boolean
    ) {
  }
}
