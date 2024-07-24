export class MaterialRequested {
  constructor(
    public id: number,
    public pr: string,
    public requiredItem: string,
    public handoverId: number,
    public isDeleted: boolean) { }
}
