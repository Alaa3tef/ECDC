import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AddDataService } from 'Services/add-data.service';
import { LoginService } from 'Services/login.service';

@Component({
  selector: 'app-add-hseequipment-list',
  templateUrl: './add-hseequipment-list.component.html',
  styleUrls: ['./add-hseequipment-list.component.scss']
})
export class AddHSEEquipmentListComponent {
  HSEEquipmentListForm!: FormGroup;
  ErrorMessage = '';
  // json_data: any[] = [];
  UserJsonString:any
  UserJsonObj:any

  constructor(
    private loginService:LoginService,
    private addDataService:AddDataService,
    private fb: FormBuilder,
    private router: Router) {

  }

  ngOnInit() {
    this.HSEEquipmentListForm = this.fb.group(
      {
        id: this.fb.control(
          0,
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
    ),
    this.UserJsonString=JSON.stringify(this.loginService.currentUser.getValue())
    this.UserJsonObj=JSON.parse(this.UserJsonString);
  }

  get id() {
    return this.HSEEquipmentListForm.get('id');
  }
  get equipment() {
    return this.HSEEquipmentListForm.get('equipment');
  }

  submitData() {
    if (this.HSEEquipmentListForm.valid) {
      this.addDataService.AddHSEEquipmentList(this.HSEEquipmentListForm.value).subscribe({
        next: data => {
          console.log('from service')
          console.log(data)
          location.reload();
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
