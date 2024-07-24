import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { Observable } from 'rxjs';
import { formatDate } from '@angular/common';
import { IAPIResult } from 'SharedClasses/IAPIResult';

@Injectable({
  providedIn: 'root'
})
export class AddNewMedicalHistoryService {

  constructor(private http:HttpClient) { }

  AddMedicalHistory(Formdata:FormData):Observable<any>{
return this.http.post<FormData>(`http://localhost:5000/api/MedicalHistoryReport`,Formdata)
  }

  EditMedicalHistory(MedicalHistory:FormData,Id:number){
return this.http.put<FormData>(`http://localhost:5000/api/MedicalHistoryReport/${Id}`,MedicalHistory)
  }

  GetMedicalHistoryByID(Id:number,userId:string,userRole:string){
return this.http.get<IAPIResult>(`http://localhost:5000/api/MedicalHistoryReport/GetDataById/${Id}?UserId=${userId}&UserRole=${userRole}`)
  }

  GetMedicalHistoryByIDForPrint(Id:number,userId:string,userRole:string){
return this.http.get<IAPIResult>(`http://localhost:5000/api/MedicalHistoryReport/Print/${Id}?UserId=${userId}&UserRole=${userRole}`)
  }

  GetMedicalHistoryByRigNumerAndJopAndName(RigNumber:number,Name:string,Jop:string,UserId:string,userRole:string){
    return this.http.get<IAPIResult>(`http://localhost:5000/api/MedicalHistoryReport/GetDataByRigAndDateAndName?Name=${Name}&UserId=${UserId}&UserRole=${userRole}&RigNumber=${RigNumber}&Jop=${Jop}`)
  }

  GetSearchByDieases(Diseases: string, userRole: string): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(
        `http://localhost:5000/api/MedicalHistoryReport/SearchByDieases?Diseases=${Diseases}&UserRole=${userRole}`
    );
}


}
