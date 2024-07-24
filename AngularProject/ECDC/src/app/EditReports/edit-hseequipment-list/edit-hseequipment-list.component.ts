import { Component } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router, ParamMap } from '@angular/router';
import { EditDataService } from 'Services/edit-data.service';
import { LoginService } from 'Services/login.service';
import { IHSEEquipmentList } from 'SharedClasses/IHSEEquipmentList';

@Component({
  selector: 'app-edit-hseequipment-list',
  templateUrl: './edit-hseequipment-list.component.html',
  styleUrls: ['./edit-hseequipment-list.component.scss']
})
export class EditHSEEquipmentListComponent {
  HSEEquipmentListId:any;
  HSEEquipmentList!:IHSEEquipmentList;
  HSEEquipmentListForm!: FormGroup;
  ErrorMessage = '';
  // json_data: any[] = [];
  UserJsonString:any
  UserJsonObj:any

  constructor(private activatedRoute:ActivatedRoute,private loginService:LoginService,private editDataService:EditDataService,private fb: FormBuilder, private router: Router) {

  }

  ngOnInit() {
    this.activatedRoute.paramMap.subscribe((params: ParamMap) => {
      this.HSEEquipmentListId = params.get("id");
      console.log(this.HSEEquipmentListId)
    }),
    this.editDataService.GetHSEEquipmentListById(this.HSEEquipmentListId).subscribe({
      next: data => {
        this.HSEEquipmentList = data.data,
        this.HSEEquipmentListForm.patchValue({
          id:data.data.id,
          equipment:data.data.equipment,
          isDeleted:data.data.isDeleted
        })
        console.log('*************************************************************')
        console.log(this.HSEEquipmentList)
        console.log('###################################################')
      },
      error: (erorr: string) => this.ErrorMessage = erorr
    }),
    this.UserJsonString=JSON.stringify(this.loginService.currentUser.getValue())
    this.UserJsonObj=JSON.parse(this.UserJsonString);
    this.HSEEquipmentListForm = this.fb.group(
      {
        id: this.fb.control(
          this.HSEEquipmentListId,
          [
            Validators.required
          ]
        ),
        equipment: this.fb.control(
          '',
          [
            Validators.required
          ]
        ),
        isDeleted: this.fb.control(
          false,
          [
            Validators.required
          ]
        )
      }
    )
  }

  get id() {
    return this.HSEEquipmentListForm.get('id');
  }
  get equipment() {
    return this.HSEEquipmentListForm.get('equipment');
  }

  submitData() {
    if (this.HSEEquipmentListForm.valid) {
      this.editDataService.EditHSEEquipmentList(this.HSEEquipmentListForm.value).subscribe({
        next: data => {
          console.log('from service')
          console.log(data)
          this.router.navigate(['Dashboard/HSEEquipmentList']);
        },
        error: error => {
          console.log("from Error")
          console.log(error)
        }
      });
    }
    else {
      console.log("E+++++====error in : ");
      console.log(this.HSEEquipmentListForm);
    }
  }

}
