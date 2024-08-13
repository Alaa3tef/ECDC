
export interface IMedicalReport {
  id: number,
  rigId: number,
  date: Date,
  isTheIllHealth: boolean,
  typeOfIncidentId: number,
  company: string,
  job: string,
  code: string,
  name: string,
  address: string,
  telephoneNumber: number,
  age: number,
  dateOfBirth: Date,
  rigManager: string,
  qhseEngineer: string,
  rigDoctor: string,
  doctorRecommendation: string,
  doctorComment: string,
  diagnosis: string,
  userID: string,
  isDeleted: boolean

}
