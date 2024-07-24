export class CorrectiveDataTable {
  constructor(
    public id: number,
    public sn: number,
    public correctiveActionSelected: string,
    public action: string,
    public responsible: string,
    public suggestedDate: Date,
    public achievementDate: Date,
    public followUpAudit: string,
    public status: boolean,
    public isDeleted: boolean,
  ) {
  }
}
