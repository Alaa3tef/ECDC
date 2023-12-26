import { ChangeDetectorRef, Component, Input } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, ParamMap, Router } from '@angular/router';
import { AddNewCustomerReportServiceService } from 'Services/add-new-customer-report-service.service';
import { DataService } from 'Services/data.service';
import { LoginService } from 'Services/login.service';
import { IcustomerReport } from 'SharedClasses/ICustomerReport';
import { IRig } from 'SharedClasses/IRig';

@Component({
  selector: 'app-edit-customer-report',
  templateUrl: './edit-customer-report.component.html',
  styleUrls: ['./edit-customer-report.component.scss']
})
export class EditCustomerReportComponent {
  SelectFiles!: File[];
  customerReportId: any;
  customerReport!: IcustomerReport;
  ErrorMessage: string = "";
  customerReportForm!: FormGroup;
  Date: Date = new Date();
  rigList: IRig[] = []
 
  rowTotals: number=0;
  rowTotals1: number=0;
  rowTotals2: number=0;
  rowTotals3: number=0;
  rowTotals4: number=0;
  rowTotals5: number=0;
  rowTotals6: number=0;
  rowTotals7: number=0;
  evaluationResultEquip:number=0


  UserJsonString: any
  UserJsonObj: any
  month1: number = 0;


  fileToEdit!: File;
  User: any;

  constructor(private loginService: LoginService,
    private activatedRoute: ActivatedRoute,
    private dataService: DataService,
    private AddNewCustomerReport: AddNewCustomerReportServiceService,
    private fb: FormBuilder,
    private router: Router,
    private cdr: ChangeDetectorRef) {

  }
  ngOnInit(): void {
    this.User = this.loginService.currentUser.getValue();
    this.activatedRoute.paramMap.subscribe((params: ParamMap) => {
      this.customerReportId = params.get("id");
      console.log(this.customerReportId)
    }),



      this.AddNewCustomerReport.GetCustomerReportByID(this.customerReportId, this.User.ID, this.User.Role).subscribe({
        next: data => {
          this.customerReport = data.data,
            console.log('*************************************************************')
          console.log(this.customerReport);
          this.evaluationResultEquip=data.data.evaluationResult;
        },
        error: (erorr: string) => this.ErrorMessage = erorr
      }),



      this.UserJsonString = JSON.stringify(this.loginService.currentUser.getValue()),
      this.UserJsonObj = JSON.parse(this.UserJsonString),
      this.customerReportForm = this.fb.group(
        {
          id: this.fb.control(
            0,
            [
              Validators.required
            ]
          ),
          rigId: this.fb.control(
            '',
            [
              Validators.required
            ]
          ),
          dateFrom: this.fb.control(
            '',
            [
              Validators.required
            ]
          ),
          dateTo: this.fb.control(
            '',
            [
              Validators.required
            ]
          ),
          clientRepresentative: this.fb.control(
            '',
            [
              Validators.required
            ]
          ),
          client: this.fb.control(
            '',
            [
              Validators.required
            ]
          ),
          month: this.fb.control(
            '',
            [
              Validators.required
            ]
          ),
          year: this.fb.control(
            '',
            [
              Validators.required
            ]
          ),
          location: this.fb.control(
            '',
            [
              Validators.required
            ]
          ),
          comment: this.fb.control(
            '',
            [
              //Validators.required
            ]
          ),
          customerRepresentative: this.fb.control(
            '',
            [
              Validators.required
            ]
          ),
          ecdcRepresentative: this.fb.control(
            '',
            [
              Validators.required
            ]
          ),
          rating: this.fb.control(
            '',
            [
               Validators.required
            ]
          ),
          rating1: this.fb.control(
            '',
            [
               Validators.required
            ]
          ),
          rating2: this.fb.control(
            '',
            [
               Validators.required
            ]
          ),
          rating3: this.fb.control(
            '',
            [
               Validators.required
            ]
          ),
          rating4: this.fb.control(
            '',
            [
               Validators.required
            ]
          ),
          rating5: this.fb.control(
            '',
            [
               Validators.required
            ]
          ),
          rating6: this.fb.control(
            '',
            [
               Validators.required
            ]
          ),
          rating7: this.fb.control(
            '',
            [
               Validators.required
            ]
          ),
          commentEvaluationCriteria: this.fb.control(
            '',
            [
            ]
          ),

          commentEvaluationCriteria1: this.fb.control(
            '',
            [
            ]
          ),
          commentEvaluationCriteria2: this.fb.control(
            '',
            [
            ]
          ),
          commentEvaluationCriteria3: this.fb.control(
            '',
            [
            ]
          ),

          commentEvaluationCriteria4: this.fb.control(
            '',
            [
            ]
          ),
          commentEvaluationCriteria5: this.fb.control(
            '',
            [
            ]
          ),

          commentEvaluationCriteria6: this.fb.control(
            '',
            [
            ]
          ),
          commentEvaluationCriteria7: this.fb.control(
            '',
            [
            ]
          ),
          evaluationResult: this.fb.control(
            '',
            []
          ),
          userID: this.fb.control(this.User.ID, [Validators.required]),
        }
      ),

    
      this.dataService.GetRig().subscribe({
        next: data => {
          this.rigList = data.data,
            console.log(this.rigList)
        },
        error: err => {
          this.ErrorMessage = err,
            console.log(this.ErrorMessage)
        }
      })
  }

  onChangeWithMonth(event: any) {
    const selectedMonthValue = event.target.value;
    const myComboBox = document.getElementById('month') as HTMLSelectElement;
    const selectedOption = myComboBox.options[myComboBox.selectedIndex];
    const selectedText = selectedOption.text;

    // Assuming 'month' is the name of the form control in your FormGroup
    const monthFormControl = this.customerReportForm.get('month');

    if (monthFormControl) {
      monthFormControl.setValue(selectedMonthValue);
      // You can also set additional properties if needed, e.g., month name
      this.customerReportForm.patchValue({ month_Name: selectedText });
    }
  }
  calculateRowTotal(  rating: string) {
    const numericRating = parseInt(rating.replace(/\D/g, ''), 10);
    const total = numericRating * 5;
    console.log(`Rating: ${numericRating}, Total: ${total}`);
    this.rowTotals = total;
    this.updateOverallTotal();
  }
  
  calculateRow1Total(  rating: string) {
    const numericRating = parseInt(rating.replace(/\D/g, ''), 10);
    const total = numericRating * 4;
    console.log(`Rating: ${numericRating}, Total: ${total}`);
    this.rowTotals1= total;
    this.updateOverallTotal();
  }
  
  calculateRow2Total(  rating: string) {
    const numericRating = parseInt(rating.replace(/\D/g, ''), 10);
    const total = numericRating * 2;
    console.log(`Rating: ${numericRating}, Total: ${total}`);
    this.rowTotals2 = total;
    this.updateOverallTotal();
  }
  calculateRow3Total(  rating: string) {
    const numericRating = parseInt(rating.replace(/\D/g, ''), 10);
    const total = numericRating * 2;
    console.log(`Rating: ${numericRating}, Total: ${total}`);
    this.rowTotals3 = total;
    this.updateOverallTotal();
  }
  calculateRow4Total(  rating: string) {
    const numericRating = parseInt(rating.replace(/\D/g, ''), 10);
    const total = numericRating * 2;
    console.log(`Rating: ${numericRating}, Total: ${total}`);
    this.rowTotals4 = total;
    this.updateOverallTotal();
  }
  calculateRow5Total(  rating: string) {
    const numericRating = parseInt(rating.replace(/\D/g, ''), 10);
    const total = numericRating * 2;
    console.log(`Rating: ${numericRating}, Total: ${total}`);
    this.rowTotals5 = total;
    this.updateOverallTotal();
  }
  calculateRow6Total(  rating: string) {
    const numericRating = parseInt(rating.replace(/\D/g, ''), 10);
    const total = numericRating * 2;
    console.log(`Rating: ${numericRating}, Total: ${total}`);
    this.rowTotals6 = total;
    this.updateOverallTotal();
  }
  calculateRow7Total(  rating: string) {
    const numericRating = parseInt(rating.replace(/\D/g, ''), 10);
    const total = numericRating * 1;
    console.log(`Rating: ${numericRating}, Total: ${total}`);
    this.rowTotals7 = total;
    this.updateOverallTotal();
  }
  
  updateOverallTotal() {
    const TotalRasults=this.rowTotals+this.rowTotals1+this.rowTotals2+this.rowTotals3+this.rowTotals4+this.rowTotals5+this.rowTotals6+this.rowTotals7

    this.evaluationResultEquip = TotalRasults;
    console.log("The TotalRasults:  ", this.rowTotals+this.rowTotals1+this.rowTotals2+this.rowTotals3+this.rowTotals4+this.rowTotals5+this.rowTotals6+this.rowTotals7
    );
    this.cdr.detectChanges();
  }
  get id() {
    return this.customerReportForm.get('id');
  }
  get rigId() {
    return this.customerReportForm.get('rigId');
  }
  get dateFrom() {
    return this.customerReportForm.get('dateFrom');
  }
  get dateTo() {
    return this.customerReportForm.get('dateTo');
  }

  get clientRepresentative() {
    return this.customerReportForm.get('clientRepresentative');
  }
  get client() {
    return this.customerReportForm.get('client');
  }
  get month() {
    return this.customerReportForm.get('month');
  }
  get year() {
    return this.customerReportForm.get('year');
  }
  get location() {
    return this.customerReportForm.get('location');
  }
  get comment() {
    return this.customerReportForm.get('comment');
  }
  get customerRepresentative() {
    return this.customerReportForm.get('customerRepresentative');
  }
  get evaluationResult() {
    return this.customerReportForm.get('evaluationResult');
  }
  get ecdcRepresentative() {
    return this.customerReportForm.get('ecdcRepresentative');
  }
  get commentEvaluationCriteria() {
    return this.customerReportForm.get('commentEvaluationCriteria');
  }
  get commentEvaluationCriteria1() {
    return this.customerReportForm.get('commentEvaluationCriteria1');
  }
  get commentEvaluationCriteria2() {
    return this.customerReportForm.get('commentEvaluationCriteria2');
  }

  get commentEvaluationCriteria3() {
    return this.customerReportForm.get('commentEvaluationCriteria3');
  }
  get commentEvaluationCriteria4() {
    return this.customerReportForm.get('commentEvaluationCriteria4');
  }
  get commentEvaluationCriteria5() {
    return this.customerReportForm.get('commentEvaluationCriteria5');
  }

  get commentEvaluationCriteria6() {
    return this.customerReportForm.get('commentEvaluationCriteria6');
  }
  get commentEvaluationCriteria7() {
    return this.customerReportForm.get('commentEvaluationCriteria7');
  }
  get rating() {
    return this.customerReportForm.get('rating');
  }
  get rating1() {
    return this.customerReportForm.get('rating1');
  }
  get rating2() {
    return this.customerReportForm.get('rating2');
  }

  get rating3() {
    return this.customerReportForm.get('rating3');
  }
  get rating4() {
    return this.customerReportForm.get('rating4');
  }
  get rating5() {
    return this.customerReportForm.get('rating5');
  }

  get rating6() {
    return this.customerReportForm.get('rating6');
  }
  get rating7() {
    return this.customerReportForm.get('rating7');
  }
  submitData() {

    if (this.customerReportForm.valid) {

      const Formdata = new FormData()
      console.log("fforrrrrrrmmmmmmmmm", Formdata)

      Formdata.append('rigId', this.rigId?.value);
      Formdata.append('dateTo', this.dateTo?.value);
      Formdata.append('dateFrom', this.dateFrom?.value);

      // Formdata.append('ratingId', this.ratingId?.value);
      Formdata.append('clientRepresentative', this.clientRepresentative?.value);

      Formdata.append('client', this.client?.value);
      Formdata.append('month', this.month?.value);
      Formdata.append('year', this.year?.value);

      Formdata.append('location', this.location?.value);
      Formdata.append('comment', this.comment?.value);
      Formdata.append('customerRepresentative', this.customerRepresentative?.value);

      Formdata.append('evaluationResult', this.evaluationResult?.value);
      Formdata.append('ecdcRepresentative', this.ecdcRepresentative?.value);

      Formdata.append('commentEvaluationCriteria', this.commentEvaluationCriteria?.value);
      Formdata.append('commentEvaluationCriteria1', this.commentEvaluationCriteria1?.value);
      Formdata.append('commentEvaluationCriteria2', this.commentEvaluationCriteria2?.value);
      Formdata.append('commentEvaluationCriteria3', this.commentEvaluationCriteria3?.value);

      Formdata.append('commentEvaluationCriteria4', this.commentEvaluationCriteria4?.value);
      Formdata.append('commentEvaluationCriteria5', this.commentEvaluationCriteria5?.value);
      Formdata.append('commentEvaluationCriteria6', this.commentEvaluationCriteria6?.value);
      Formdata.append('commentEvaluationCriteria7', this.commentEvaluationCriteria7?.value);

      Formdata.append('rating', this.rating?.value);
      Formdata.append('rating1', this.rating1?.value);
      Formdata.append('rating2', this.rating2?.value);
      Formdata.append('rating3', this.rating3?.value);

      Formdata.append('rating4', this.rating4?.value);
      Formdata.append('rating5', this.rating5?.value);
      Formdata.append('rating6', this.rating6?.value);
      Formdata.append('rating7', this.rating7?.value);

      Formdata.append('userID', this.UserJsonObj.ID);
      console.log(Formdata);
      console.log('after formData')
      this.AddNewCustomerReport.EditCustomerReport(Formdata, this.customerReportId).subscribe({
        next: data => {
          console.log(data)
          this.router.navigate(['/Dashboard/Customer']);
        },
        error: error => console.log(error)
      });
     }
  }
}

