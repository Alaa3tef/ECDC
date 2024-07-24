
export interface IcustomerReport {
  id: number,
  rigId: number,
  dateFrom: Date,
  dateTo: Date,
  clientRepresentative: string,
  client: string,
  month: number,
  year: number,
  evaluationResult:number ,
  location: number,
  comment: string,
  customerRepresentative: string,
  ecdcRepresentative: string,
  //  ratingId: number,


  commentEvaluationCriteria: string,
  commentEvaluationCriteria1: string,
  commentEvaluationCriteria2: string,
  commentEvaluationCriteria3: string,
  commentEvaluationCriteria4: string,
  commentEvaluationCriteria5: string,
  commentEvaluationCriteria6: string,
  commentEvaluationCriteria7: string,
  
     rating : string,
     rating1 : string,
     rating2 : string,
     rating3 : string,
     rating4 : string,
     rating5 : string,
     rating6 : string,
     rating7 : string,
  
  userID: string,
  isDeleted: boolean

}
