import { PrintRMPEByIdComponent } from './Print_Reports/print-rmpeby-id/print-rmpeby-id.component';

import { RegisterComponent } from './Other_Components/register/register.component';
import { LoginComponent } from './Other_Components/login/login.component';
import { AccidentTableComponent } from './Report_Data/accident-table/accident-table.component';
import { StopcardTableComponent } from './Report_Data/stopcard-table/stopcard-table.component';
import { ReportAccidentComponent } from './Print_Reports/report-accident/report-accident.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AccidentFormComponent } from './Reports/accident-form/accident-form.component';
import { HomeComponent } from './Other_Components/home/home.component';
import { PageNotFoundComponent } from './Other_Components/page-not-found/page-not-found.component';
import { StopcardComponent } from './Reports/stopcard/stopcard.component';
import { StopCardReportComponent } from './Print_Reports/stop-card-report/stop-card-report.component';
import { DashboardComponent } from './Other_Components/dashboard/dashboard.component';
import { ProfileComponent } from './Other_Components/profile/profile.component';
import { ContactUsComponent } from './Other_Components/contact-us/contact-us.component';
import { JMPFormComponent } from './Reports/jmpform/jmpform.component';
import { JMPReportComponent } from './Print_Reports/jmpreport/jmpreport.component';
import { JMPTableComponent } from './Report_Data/jmptable/jmptable.component';
import { EditAccidentComponent } from './EditReports/edit-accident/edit-accident.component';
import { AddAccidentCausesComponent } from './Add_Data/add-accident-causes/add-accident-causes.component';
import { AccidentCausesComponent } from './Items_In_SubDashboard/accident-causes/accident-causes.component';
import { AddClassificationComponent } from './Add_Data/add-classification/add-classification.component';
import { ClassificationsComponent } from './Items_In_SubDashboard/classifications/classifications.component';
import { AddclassificationOfAccdComponent } from './Add_Data/addclassification-of-accd/addclassification-of-accd.component';
import { ClassificationOfAccidentComponent } from './Items_In_SubDashboard/classification-of-accident/classification-of-accident.component';
import { ComminucationMethodComponent } from './Items_In_SubDashboard/comminucation-method/comminucation-method.component';
import { AddComminucationMethodComponent } from './Add_Data/add-comminucation-method/add-comminucation-method.component';
import { AddDriverComponent } from './Add_Data/add-driver/add-driver.component';
import { DriverComponent } from './Items_In_SubDashboard/driver/driver.component';
import { AddPassengersComponent } from './Add_Data/add-passengers/add-passengers.component';
import { PassengersComponent } from './Items_In_SubDashboard/passengers/passengers.component';
import { AddPreventionCategoriesComponent } from './Add_Data/add-prevention-categories/add-prevention-categories.component';
import { PreventionCategoriesComponent } from './Items_In_SubDashboard/prevention-categories/prevention-categories.component';
import { AddQHSEPositionsComponent } from './Add_Data/add-qhsepositions/add-qhsepositions.component';
import { QHSEPositionsComponent } from './Items_In_SubDashboard/qhsepositions/qhsepositions.component';
import { AddQHSENamesComponent } from './Add_Data/add-qhsenames/add-qhsenames.component';
import { QHSENamesComponent } from './Items_In_SubDashboard/qhsenames/qhsenames.component';
import { AddReportedByNamesComponent } from './Add_Data/add-reported-by-names/add-reported-by-names.component';
import { ReportedByNamesComponent } from './Items_In_SubDashboard/reported-by-names/reported-by-names.component';
import { AddReportedByPositionsComponent } from './Add_Data/add-reported-by-positions/add-reported-by-positions.component';
import { ReportedByPositionsComponent } from './Items_In_SubDashboard/reported-by-positions/reported-by-positions.component';
import { AddRigsComponent } from './Add_Data/add-rigs/add-rigs.component';
import { RigsComponent } from './Items_In_SubDashboard/rigs/rigs.component';
import { AddRouteNamesComponent } from './Add_Data/add-route-names/add-route-names.component';
import { RouteNamesComponent } from './Items_In_SubDashboard/route-names/route-names.component';
import { AddToolPusherPositionsComponent } from './Add_Data/add-tool-pusher-positions/add-tool-pusher-positions.component';
import { ToolPusherPositionsComponent } from './Items_In_SubDashboard/tool-pusher-positions/tool-pusher-positions.component';
import { AddToolPusherNamesComponent } from './Add_Data/add-tool-pusher-names/add-tool-pusher-names.component';
import { ToolPusherNamesComponent } from './Items_In_SubDashboard/tool-pusher-names/tool-pusher-names.component';
import { AddTypeofInjuriesComponent } from './Add_Data/add-typeof-injuries/add-typeof-injuries.component';
import { TypeofInjuriesComponent } from './Items_In_SubDashboard/typeof-injuries/typeof-injuries.component';
import { AddTypeofObserviationComponent } from './Add_Data/add-typeof-observiation/add-typeof-observiation.component';
import { TypeofObserviationComponent } from './Items_In_SubDashboard/typeof-observiation/typeof-observiation.component';
import { AddVehiclesComponent } from './Add_Data/add-vehicles/add-vehicles.component';
import { VehiclesComponent } from './Items_In_SubDashboard/vehicles/vehicles.component';
import { AddViolationCategoriesComponent } from './Add_Data/add-violation-categories/add-violation-categories.component';
import { ViolationCategoriesComponent } from './Items_In_SubDashboard/violation-categories/violation-categories.component';
import { EditStopCardComponent } from './EditReports/edit-stop-card/edit-stop-card.component';
import { EditAccidentCausesComponent } from './EditReports/edit-accident-causes/edit-accident-causes.component';
import { EditClassificationComponent } from './EditReports/edit-classification/edit-classification.component';
import { EditClassificationOfAccidentComponent } from './EditReports/edit-classification-of-accident/edit-classification-of-accident.component';
import { EditComminucationMethodComponent } from './EditReports/edit-comminucation-method/edit-comminucation-method.component';
import { EditDriverComponent } from './EditReports/edit-driver/edit-driver.component';
import { EditPassengerComponent } from './EditReports/edit-passenger/edit-passenger.component';
import { EditPreventionCategoryComponent } from './EditReports/edit-prevention-category/edit-prevention-category.component';
import { EditQHSEPositionComponent } from './EditReports/edit-qhseposition/edit-qhseposition.component';
import { EditQHSEPositionNameComponent } from './EditReports/edit-qhseposition-name/edit-qhseposition-name.component';
import { EditReportedByNameComponent } from './EditReports/edit-reported-by-name/edit-reported-by-name.component';
import { EditReportedByPositionComponent } from './EditReports/edit-reported-by-position/edit-reported-by-position.component';
import { EditRigComponent } from './EditReports/edit-rig/edit-rig.component';
import { EditRouteNameComponent } from './EditReports/edit-route-name/edit-route-name.component';
import { EditToolPusherPositionComponent } from './EditReports/edit-tool-pusher-position/edit-tool-pusher-position.component';
import { EditToolPusherPositionNameComponent } from './EditReports/edit-tool-pusher-position-name/edit-tool-pusher-position-name.component';
import { EditTypeOfInjuryComponent } from './EditReports/edit-type-of-injury/edit-type-of-injury.component';
import { EditTypeOfObservationCategoryComponent } from './EditReports/edit-type-of-observation-category/edit-type-of-observation-category.component';
import { EditVehicleComponent } from './EditReports/edit-vehicle/edit-vehicle.component';
import { EditViolationCategoryComponent } from './EditReports/edit-violation-category/edit-violation-category.component';
import { EditJMLFormComponent } from './EditReports/edit-jmlform/edit-jmlform.component';
import { AuthGuard } from './auth.guard';
import { ChangepasswordComponent } from './Other_Components/changepassword/changepassword.component';
import { StopCardChartComponent } from './Charts_Of_Reports/stop-card-chart/stop-card-chart.component';
import { NotificationsComponent } from './Other_Components/notifications/notifications.component';
import { RadioauthGuard } from './radioauth.guard';
import { UserauthGuard } from './userauth.guard';
import { ArrivalStatusSJPComponent } from './Other_Components/arrival-status-sjp/arrival-status-sjp.component';
import { StopCardCompareChartComponent } from './Charts_Of_Reports/stop-card-compare-chart/stop-card-compare-chart.component';
import { HeathComponent } from './UpLoadFiles/heath/heath.component';
import { SafetyComponent } from './UpLoadFiles/safety/safety.component';
import { EnvironmentComponent } from './UpLoadFiles/environment/environment.component';
import { QualityComponent } from './UpLoadFiles/quality/quality.component';
import { ClincFormsComponent } from './UpLoadFiles/clinc-forms/clinc-forms.component';
import { QSHEFormsComponent } from './UpLoadFiles/qsheforms/qsheforms.component';
import { PolicyComponent } from './UpLoadFiles/policy/policy.component';
import { AddRigMovePerformanceEvaluationComponent } from './Reports/add-rig-move-performance-evaluation/add-rig-move-performance-evaluation.component';
import { EditRigMovePerformanceEvaluationComponent } from './EditReports/edit-rig-move-performance-evaluation/edit-rig-move-performance-evaluation.component';
import { RigMovePerformanceEvaluationComponent } from './Report_Data/rig-move-performance-evaluation/rig-move-performance-evaluation.component';
import { PrintRigPerformanceComponent } from './Print_Reports/print-rig-performance/print-rig-performance.component';
import { RigPerformanceChartComponent } from './Charts_Of_Reports/rig-performance-chart/rig-performance-chart.component';
import { SubDashboardComponent } from './Items_In_SubDashboard/sub-dashboard/sub-dashboard.component';
import { RigPerformanceCompareChartsComponent } from './Charts_Of_Reports/rig-performance-compare-charts/rig-performance-compare-charts.component';
import { AllAuthGuardGuard } from './all-auth-guard.guard';
import { AddPTSMComponent } from './Reports/add-ptsm/add-ptsm.component';
import { PTSMComponent } from './Report_Data/ptsm/ptsm.component';
import { EditPTSMComponent } from './EditReports/edit-ptsm/edit-ptsm.component';
import { PrintPTSMComponent } from './Print_Reports/print-ptsm/print-ptsm.component';
import { BOPComponent } from './Reports/bop/bop.component';

import { EditBOPComponent } from './EditReports/edit-bop/edit-bop.component';
import { BopTableComponent } from './Report_Data/bop-table/bop-table.component';
import { PrintBopComponent } from './Print_Reports/print-bop/print-bop.component';
import { EmpCodeComponent } from './Items_In_SubDashboard/emp-code/emp-code.component';
import { AddEmpCodeComponent } from './Add_Data/add-emp-code/add-emp-code.component';
import { EditEmpCodeComponent } from './EditReports/edit-emp-code/edit-emp-code.component';
import { PositionComponent } from './Items_In_SubDashboard/position/position.component';
import { AddPostionComponent } from './Add_Data/add-postion/add-postion.component';
import { EditPositionComponent } from './EditReports/edit-position/edit-position.component';
import { EmployeeCompetencyEvaluationComponent } from './Reports/employee-competency-evaluation/employee-competency-evaluation.component';
import { EditEmployeeCompetencyEvaluationComponent } from './EditReports/edit-employee-competency-evaluation/edit-employee-competency-evaluation.component';
import { EmployeeCompetencyEvaluationTableComponent } from './Report_Data/employee-competency-evaluation-table/employee-competency-evaluation-table.component';
import { PrintEmployeeCompetencyEvaluationComponent } from './Print_Reports/print-employee-competency-evaluation/print-employee-competency-evaluation.component';
import { AddSubjectListComponent } from './Add_Data/add-subject-list/add-subject-list.component';
import { SubjectListEmployeeCompetencyEvaluationComponent } from './Items_In_SubDashboard/subject-list-employee-competency-evaluation/subject-list-employee-competency-evaluation.component';
import { EditSubjectListEmployeeCompetencyEvaluationComponent } from './EditReports/edit-subject-list-employee-competency-evaluation/edit-subject-list-employee-competency-evaluation.component';
import { PotentialHazardComponent } from './Reports/potential-hazard/potential-hazard.component';
import { EditPotentialHazardComponent } from './EditReports/edit-potential-hazard/edit-potential-hazard.component';
import { PotentialHazardTableComponent } from './Report_Data/potential-hazard-table/potential-hazard-table.component';
import { PrintPotentialHazardComponent } from './Print_Reports/print-potential-hazard/print-potential-hazard.component';
import { ResponsibilityComponent } from './Items_In_SubDashboard/responsibility/responsibility.component';
import { AddResponsibilityComponent } from './Add_Data/add-responsibility/add-responsibility.component';
import { EditResponsibilityComponent } from './EditReports/edit-responsibility/edit-responsibility.component';
import { AddPPEReceivingComponent } from './Reports/add-ppereceiving/add-ppereceiving.component';
import { EditPPEReceivingComponent } from './EditReports/edit-ppereceiving/edit-ppereceiving.component';
import { PPEReceivingTableComponent } from './Report_Data/ppereceiving-table/ppereceiving-table.component';
import { PrintPPEReceivingComponent } from './Print_Reports/print-ppereceiving/print-ppereceiving.component';
import { PPEsComponent } from './Items_In_SubDashboard/ppes/ppes.component';
import { AddPPEsComponent } from './Add_Data/add-ppes/add-ppes.component';
import { EditPPEsComponent } from './EditReports/edit-ppes/edit-ppes.component';

// -----------Drills REPORT------------------
import { DrillComponent } from './Reports/drill/drill.component';
import { DrillTableComponent } from './Report_Data/drill-table/drill-table.component';
import { EditDrillComponent } from './EditReports/edit-drill/edit-drill.component';
import { PrintDrillComponent } from './Print_Reports/print-drill/print-drill.component';
import { DrillTypesComponent } from './Items_In_SubDashboard/drill-types/drill-types.component';
import { AddDrillTypesComponent } from './Add_Data/add-drill-types/add-drill-types.component';
import { EditDrillTypesComponent } from './EditReports/edit-drill-types/edit-drill-types.component';
import { PotentialHazardChartsComponent } from './Charts_Of_Reports/potential-hazard-charts/potential-hazard-charts.component';
import { ChartWithDrillTypeComponent } from './Charts_Of_Reports/chart-with-drill-type/chart-with-drill-type.component';
import { ChartDrillWitManagerNameComponent } from './Charts_Of_Reports/chart-drill-wit-manager-name/chart-drill-wit-manager-name.component';
import { DrillsCompareByRigsComponent } from './Charts_Of_Reports/drills-compare-by-rigs/drills-compare-by-rigs.component';
import { PrintDrillByIdComponent } from './Print_Reports/print-drill-by-id/print-drill-by-id.component';

import { ClientComponent } from './Items_In_SubDashboard/client/client.component';
import { AddClientComponent } from './Add_Data/add-client/add-client.component';
import { EditClientComponent } from './EditReports/edit-client/edit-client.component';
import { LeaderShipVisitComponent } from './Items_In_SubDashboard/leader-ship-visit/leader-ship-visit.component';
import { AddLeaderShipVisitComponent } from './Add_Data/add-leader-ship-visit/add-leader-ship-visit.component';
import { EditLeaderShipVisitComponent } from './EditReports/edit-leader-ship-visit/edit-leader-ship-visit.component';
import { CrewComponent } from './Items_In_SubDashboard/crew/crew.component';
import { AddCrewComponent } from './Add_Data/add-crew/add-crew.component';
import { EditCrewComponent } from './EditReports/edit-crew/edit-crew.component';
import { DaysScienceNoLTIComponent } from './Items_In_SubDashboard/days-science-no-lti/days-science-no-lti.component';
import { AddDaysScienceNoLTIComponent } from './Add_Data/add-days-science-no-lti/add-days-science-no-lti.component';
import { EditDaysScienceNoLTIComponent } from './EditReports/edit-days-science-no-lti/edit-days-science-no-lti.component';
import { DaysSinceNoFatalityComponent } from './Items_In_SubDashboard/days-since-no-fatality/days-since-no-fatality.component';
import { AddDaysSinceNoFatalityComponent } from './Add_Data/add-days-since-no-fatality/add-days-since-no-fatality.component';
import { EditDaysSinceNoFatalityComponent } from './EditReports/edit-days-since-no-fatality/edit-days-since-no-fatality.component';
import { QHSEDailyComponent } from './Report_Data/qhsedaily/qhsedaily.component';
import { AddQHSEDailyComponent } from './Reports/add-qhsedaily/add-qhsedaily.component';
import { EditQHSEDailyComponent } from './EditReports/edit-qhsedaily/edit-qhsedaily.component';
import { PrintQHSEDailyComponent } from './Print_Reports/print-qhsedaily/print-qhsedaily.component';
import { UserOnlyAuthGardGuard } from './user-only-auth-gard.guard';
import { UserChartQHSEDailyByMonthComponent } from './Charts_Of_Reports/QHSEDailyCharts/user-chart-qhsedaily-by-month/user-chart-qhsedaily-by-month.component';
import { UserChartQHSEDailyByYearComponent } from './Charts_Of_Reports/QHSEDailyCharts/user-chart-qhsedaily-by-year/user-chart-qhsedaily-by-year.component';
import { AdminChartQHSEDailyByYearComponent } from './Charts_Of_Reports/QHSEDailyCharts/admin-chart-qhsedaily-by-year/admin-chart-qhsedaily-by-year.component';
import { AdminChartQHSEDailyByMonthComponent } from './Charts_Of_Reports/QHSEDailyCharts/admin-chart-qhsedaily-by-month/admin-chart-qhsedaily-by-month.component';
import { QHSEDailyPrintByIdComponent } from './Print_Reports/qhsedaily-print-by-id/qhsedaily-print-by-id.component';
import { PrintAccidentByIdComponent } from './Print_Reports/print-accident-by-id/print-accident-by-id.component';
import { PrintStopCardByIdComponent } from './Print_Reports/print-stop-card-by-id/print-stop-card-by-id.component';
import { PrintSJPByIdComponent } from './Print_Reports/print-sjpby-id/print-sjpby-id.component';
import { PrintPOBByIdComponent } from './Print_Reports/print-pobby-id/print-pobby-id.component';
import { PrintPTSMByIdComponent } from './Print_Reports/print-ptsmby-id/print-ptsmby-id.component';
import { PrintEmployeeCompetencyEvaluationtByIdComponent } from './Print_Reports/print-employee-competency-evaluationt-by-id/print-employee-competency-evaluationt-by-id.component';
import { PrintPPEReceivingByIdComponent } from './Print_Reports/print-ppereceiving-by-id/print-ppereceiving-by-id.component';
import { PrintPotentialHazardByIdComponent } from './Print_Reports/print-potential-hazard-by-id/print-potential-hazard-by-id.component';

//********************* Customer Satisfaction Evaluation Report  */
import { CustomerReportComponent } from './Reports/customer-report/customer-report.component';
import { CustomerReportTableComponent } from './Report_Data/customer-report-table/customer-report-table.component';
import { EditCustomerReportComponent } from './EditReports/edit-customer-report/edit-customer-report.component';
import { PrintCustomerReportComponent } from './Print_Reports/print-customer-report/print-customer-report.component';
import { PrintCustomerReportByIdComponent } from './Print_Reports/print-customer-report-by-id/print-customer-report-by-id.component';
import { AddStandardComponent } from './Add_Data/add-standard/add-standard.component';
import { AddCorrectiveObservationComponent } from './Add_Data/add-corrective-observation/add-corrective-observation.component';
import { AddRootCauseComponent } from './Add_Data/add-root-cause/add-root-cause.component';
import { RootCauseComponent } from './Items_In_SubDashboard/root-cause/root-cause.component';
import { EditRootCauseComponent } from './EditReports/edit-root-cause/edit-root-cause.component';
import { StandardComponent } from './Items_In_SubDashboard/standard/standard.component';
import { CorrectiveObservationComponent } from './Items_In_SubDashboard/corrective-observation/corrective-observation.component';
import { EditStandardComponent } from './EditReports/edit-standard/edit-standard.component';
import { EditCorrectiveObservationComponent } from './EditReports/edit-corrective-observation/edit-corrective-observation.component';
import { AddCorrectiveActionComponent } from './Reports/add-corrective-action/add-corrective-action.component';
import { CorrectiveActionTableComponent } from './Report_Data/corrective-action-table/corrective-action-table.component';
import { EditCorrectiveActionComponent } from './EditReports/edit-corrective-action/edit-corrective-action.component';
import { PrintCorrectiveByIdComponent } from './Print_Reports/print-corrective-by-id/print-corrective-by-id.component';
import { PrintCorrectiveComponent } from './Print_Reports/print-corrective/print-corrective.component';
import { CorrectiveChartComponent } from './Charts_Of_Reports/Corrective/corrective-chart/corrective-chart.component';
import { CustomerCompareAllRigsByMonthComponent } from './Charts_Of_Reports/CustomerCharts/Admin/customer-compare-all-rigs-by-month/customer-compare-all-rigs-by-month.component';
import { CustomerCompareAllRigsByYearComponent } from './Charts_Of_Reports/CustomerCharts/Admin/customer-compare-all-rigs-by-year/customer-compare-all-rigs-by-year.component';
import { CustomerCompareTwoRigByYearComponent } from './Charts_Of_Reports/CustomerCharts/Admin/customer-compare-two-rig-by-year/customer-compare-two-rig-by-year.component';
import { CustomerCompareByMonthUserComponent } from './Charts_Of_Reports/CustomerCharts/UserCharts/customer-compare-by-month-user/customer-compare-by-month-user.component';
import { AddCraneComponent } from './Reports/add-crane/add-crane.component';
import { AddForkliftComponent } from './Reports/add-forklift/add-forklift.component';
import { EditForkliftComponent } from './EditReports/edit-forklift/edit-forklift.component';
import { EditCraneComponent } from './EditReports/edit-crane/edit-crane.component';
import { CraneComponent } from './Report_Data/crane/crane.component';
import { ForkliftComponent } from './Report_Data/forklift/forklift.component';
import { PrintCraneComponent } from './Print_Reports/print-crane/print-crane.component';
import { PrintCraneByIdComponent } from './Print_Reports/print-crane-by-id/print-crane-by-id.component';
import { PrintForkliftComponent } from './Print_Reports/print-forklift/print-forklift.component';
import { PrintForkliftByIdComponent } from './Print_Reports/print-forklift-by-id/print-forklift-by-id.component';
import { WeeklyInspectionComponent } from './Reports/weekly-inspection/weekly-inspection.component';
import { WeeklyInspectionTableComponent } from './Report_Data/weekly-inspection-table/weekly-inspection-table.component';
import { EditWeeklyInspectionComponent } from './EditReports/edit-weekly-inspection/edit-weekly-inspection.component';
import { WeeklyInspectionByIdComponent } from './Print_Reports/weekly-inspection-by-id/weekly-inspection-by-id.component';
import { PrintWeeklyInspectionComponent } from './Print_Reports/print-weekly-inspection/print-weekly-inspection.component';
import { WeeklyCampInspectionComponent } from './Reports/weekly-camp-inspection/weekly-camp-inspection.component';
import { WeeklyCampInspectionTableComponent } from './Report_Data/weekly-camp-inspection-table/weekly-camp-inspection-table.component';
import { EditweeklyCampInspectionComponent } from './EditReports/editweekly-camp-inspection/editweekly-camp-inspection.component';
import { PrintweeklyCampInspectionByIDComponent } from './Print_Reports/printweekly-camp-inspection-by-id/printweekly-camp-inspection-by-id.component';
import { PrintweeklyCampInspectionComponent } from './Print_Reports/printweekly-camp-inspection/printweekly-camp-inspection.component';
import { AddCorrectiveResponsabilityComponent } from './Add_Data/add-corrective-responsability/add-corrective-responsability.component';
import { EditCorrectiveResponsabilityComponent } from './EditReports/edit-corrective-responsability/edit-corrective-responsability.component';
import { CorrectiveResponsabilityComponent } from './Items_In_SubDashboard/corrective-responsability/corrective-responsability.component';
import { CorrectiveByResponsabilityComponent } from './Charts_Of_Reports/Corrective/corrective-by-responsability/corrective-by-responsability.component';
import { CorrectiveByObservationComponent } from './Charts_Of_Reports/Corrective/corrective-by-observation/corrective-by-observation.component';
import { CorrectiveByStandardComponent } from './Charts_Of_Reports/Corrective/corrective-by-standard/corrective-by-standard.component';
import { CorrectiveBySuggestedDateComponent } from './Charts_Of_Reports/Corrective/corrective-by-suggested-date/corrective-by-suggested-date.component';
import { AddWeeklyClinicComponent } from './Reports/add-weekly-clinic/add-weekly-clinic.component';
import { EditWeeklyClinicComponent } from './EditReports/edit-weekly-clinic/edit-weekly-clinic.component';
import { WeeklyClinicComponent } from './Report_Data/weekly-clinic/weekly-clinic.component';
import { PrintWeeklyClinicComponent } from './Print_Reports/print-weekly-clinic/print-weekly-clinic.component';
import { PrintWeeklyClinicByIdComponent } from './Print_Reports/print-weekly-clinic-by-id/print-weekly-clinic-by-id.component';
import { WeeklyClinicChartComponent } from './Charts_Of_Reports/weekly-clinic-chart/weekly-clinic-chart.component';
import { AddHandoverComponent } from './Reports/add-handover/add-handover.component';
import { EditHandoverComponent } from './EditReports/edit-handover/edit-handover.component';
import { HandoverComponent } from './Report_Data/handover/handover.component';
import { PrintHandoverComponent } from './Print_Reports/print-handover/print-handover.component';
import { PrintHandoverByIdComponent } from './Print_Reports/print-handover-by-id/print-handover-by-id.component';
import { HandoverChartComponent } from './Charts_Of_Reports/handover-chart/handover-chart.component';
import { AddMedicalReportComponent } from './Reports/add-medical-report/add-medical-report.component';
import { EditMedicalReportComponent } from './EditReports/edit-medical-report/edit-medical-report.component';
import { MedicalReportTableComponent } from './Report_Data/medical-report-table/medical-report-table.component';
import { PrintMedicalReportComponent } from './Print_Reports/print-medical-report/print-medical-report.component';
import { PrintMedicalReportByIdComponent } from './Print_Reports/print-medical-report-by-id/print-medical-report-by-id.component';
import { AddMedicalHistoryReportComponent } from './Reports/add-medical-history-report/add-medical-history-report.component';
import { EditMedicalHistoryComponent } from './EditReports/edit-medical-history/edit-medical-history.component';
import { PrintMedicalHistoryByIdComponent } from './Print_Reports/print-medical-history-by-id/print-medical-history-by-id.component';
import { MedicalHistoryReportTableComponent } from './Report_Data/medical-history-report-table/medical-history-report-table.component';
import { PrintMedicalHistoryComponent } from './Print_Reports/print-medical-history/print-medical-history.component';
import { GetMedicalReportByYearWithChartComponent } from './Charts_Of_Reports/MedicalReportCharts/get-medical-report-by-year-with-chart/get-medical-report-by-year-with-chart.component';
import { GetMedicalReportByMonthWithChartComponent } from './Charts_Of_Reports/MedicalReportCharts/get-medical-report-by-month-with-chart/get-medical-report-by-month-with-chart.component';
import { GetMedicalHistoryReportByYearWithChartComponent } from './Charts_Of_Reports/get-medical-history-report-by-year-with-chart/get-medical-history-report-by-year-with-chart.component';
import { AddRigCertificatesComponent } from './Reports/add-rig-certificates/add-rig-certificates.component';
import { RigCertificatesComponent } from './Report_Data/rig-certificates/rig-certificates.component';
import { EditRigCertificatesComponent } from './EditReports/edit-rig-certificates/edit-rig-certificates.component';
import { PrintRigCertificatesByIdComponent } from './Print_Reports/print-rig-certificates-by-id/print-rig-certificates-by-id.component';
import { PrintRigCertificatesComponent } from './Print_Reports/print-rig-certificates/print-rig-certificates.component';
import { HSEEquipmentListComponent } from './Items_In_SubDashboard/hseequipment-list/hseequipment-list.component';
import { AddHSEEquipmentListComponent } from './Add_Data/add-hseequipment-list/add-hseequipment-list.component';
import { EditHSEEquipmentListComponent } from './EditReports/edit-hseequipment-list/edit-hseequipment-list.component';
import { AddCraneDailyLiftingReportsComponent } from './Add_Data/add-crane-daily-lifting-reports/add-crane-daily-lifting-reports.component';
import { CraneDailyLiftingReportsComponent } from './Items_In_SubDashboard/crane-daily-lifting-reports/crane-daily-lifting-reports.component';
import { AddForkliftDailyLeftingComponent } from './Add_Data/add-forklift-daily-lefting/add-forklift-daily-lefting.component';
import { ForkliftDailyLeftingComponent } from './Items_In_SubDashboard/forklift-daily-lefting/forklift-daily-lefting.component';
import { EditMobileCraneDailyLeftingComponent } from './EditReports/edit-mobile-crane-daily-lefting/edit-mobile-crane-daily-lefting.component';
import { EditDailyLiftingReportComponent } from './EditReports/edit-daily-lifting-report/edit-daily-lifting-report.component';
import { EditForkliftDailyLeftingComponent } from './EditReports/edit-forklift-daily-lefting/edit-forklift-daily-lefting.component';
import { PrintDailyLiftingReportByIdComponent } from './Print_Reports/print-daily-lifting-report-by-id/print-daily-lifting-report-by-id.component';
import { PrintDailyLiftingReportComponent } from './Print_Reports/print-daily-lifting-report/print-daily-lifting-report.component';
import { DailyLiftingReportTableComponent } from './Report_Data/daily-lifting-report-table/daily-lifting-report-table.component';
import { AddDailyLiftingReportComponent } from './Reports/add-daily-lifting-report/add-daily-lifting-report.component';
import { EditVehicleWeeklyChecklistReportComponent } from './EditReports/edit-vehicle-weekly-checklist-report/edit-vehicle-weekly-checklist-report.component';
import { PrintVehicleWeeklyChecklistReportByIdComponent } from './Print_Reports/print-vehicle-weekly-checklist-report-by-id/print-vehicle-weekly-checklist-report-by-id.component';
import { PrintVehicleWeeklyChecklistReportComponent } from './Print_Reports/print-vehicle-weekly-checklist-report/print-vehicle-weekly-checklist-report.component';
import { VehicleWeeklyChecklistReportTableComponent } from './Report_Data/vehicle-weekly-checklist-report-table/vehicle-weekly-checklist-report-table.component';
import { AddVehicleWeeklyChecklistReportComponent } from './Reports/add-vehicle-weekly-checklist-report/add-vehicle-weekly-checklist-report.component';
import { UserEditGuard } from './user-edit.guard';
import { CertificatesTypeComponent } from './Items_In_SubDashboard/certificates-type/certificates-type.component';
import { AddCertificatesTypeComponent } from './Add_Data/add-certificates-type/add-certificates-type.component';
import { EditCertificatesTypeComponent } from './EditReports/edit-certificates-type/edit-certificates-type.component';
import { AllEditGuard } from './all-edit.guard';


const routes: Routes = [
  { path: '', redirectTo: '/Login', pathMatch: 'full' },
  { path: 'Login', component: LoginComponent },
  { path: 'Register', canActivate: [AuthGuard], component: RegisterComponent },
  { path: 'Notifications', canActivate: [AuthGuard], component: NotificationsComponent },
  { path: 'ArrivalStatusSJP', canActivate: [AllAuthGuardGuard], component: ArrivalStatusSJPComponent },
  { path: 'Dashboard/Accidents', canActivate: [AllAuthGuardGuard], component: AccidentTableComponent },
  { path: 'Dashboard/EmployeeCompetencyEvaluations', canActivate: [UserauthGuard], component: EmployeeCompetencyEvaluationTableComponent },

  { path: 'Home', canActivate: [AllAuthGuardGuard], component: HomeComponent },
  { path: 'Accident', canActivate: [UserauthGuard], component: AccidentFormComponent },
  { path: 'Accident/Edit/:id/:reportDate', canActivate: [UserEditGuard], component: EditAccidentComponent },
  { path: 'StopCard/Edit/:id/:reportDate', canActivate: [UserauthGuard], component: EditStopCardComponent },
  { path: 'SJP/Edit/:id/:reportDate', canActivate: [AllEditGuard], component: EditJMLFormComponent },
  { path: 'Dashboard/AccidentCauses/Add', canActivate: [UserauthGuard], component: AddAccidentCausesComponent },
  { path: 'Dashboard/AccidentCauses/Edit/:id', canActivate: [AuthGuard], component: EditAccidentCausesComponent },
  { path: 'Dashboard/AccidentCauses', canActivate: [UserauthGuard], component: AccidentCausesComponent },

  { path: 'Dashboard/SubjectList/Add', canActivate: [UserauthGuard], component: AddSubjectListComponent },
  { path: 'Dashboard/SubjectList/Edit/:id', canActivate: [AuthGuard], component: EditSubjectListEmployeeCompetencyEvaluationComponent },
  { path: 'Dashboard/SubjectList', canActivate: [UserauthGuard], component: SubjectListEmployeeCompetencyEvaluationComponent },

  { path: 'PotentialHazard/Add', canActivate: [UserauthGuard], component: PotentialHazardComponent },
  { path: 'PotentialHazard/Edit/:id/:reportDate', canActivate: [UserEditGuard], component: EditPotentialHazardComponent },
  { path: 'PotentialHazard', canActivate: [UserauthGuard], component: PotentialHazardTableComponent },
  { path: 'PrintPotentialHazard', canActivate: [UserauthGuard], component: PrintPotentialHazardComponent },

  { path: 'Dashboard/Responsibility', canActivate: [UserauthGuard], component: ResponsibilityComponent },
  { path: 'Dashboard/Responsibility/Add', canActivate: [UserauthGuard], component: AddResponsibilityComponent },
  { path: 'Dashboard/Responsibility/Edit/:id', canActivate: [UserauthGuard], component: EditResponsibilityComponent },
  { path: 'Dashboard/ClassificationOfAccident/Add', canActivate: [UserauthGuard], component: AddclassificationOfAccdComponent },
  { path: 'Dashboard/ClassificationOfAccident/Edit/:id', canActivate: [AuthGuard], component: EditClassificationOfAccidentComponent },
  { path: 'Dashboard/ClassificationOfAccident', canActivate: [UserauthGuard], component: ClassificationOfAccidentComponent },
  { path: 'Dashboard/ComminucationMethod/Add', canActivate: [UserauthGuard], component: AddComminucationMethodComponent },
  { path: 'Dashboard/ComminucationMethod/Edit/:id', canActivate: [AuthGuard], component: EditComminucationMethodComponent },
  { path: 'Dashboard/ComminucationMethod', canActivate: [UserauthGuard], component: ComminucationMethodComponent },
  { path: 'Dashboard/Driver/Add', canActivate: [AllAuthGuardGuard], component: AddDriverComponent },
  { path: 'Dashboard/Driver/Edit/:id', canActivate: [RadioauthGuard], component: EditDriverComponent },
  { path: 'Dashboard/Driver', canActivate: [AllAuthGuardGuard], component: DriverComponent },
  { path: 'Dashboard/Passenger/Add', canActivate: [UserauthGuard], component: AddPassengersComponent },
  { path: 'Dashboard/Passenger/Edit/:id', canActivate: [AuthGuard], component: EditPassengerComponent },
  { path: 'Dashboard/Passenger', canActivate: [UserauthGuard], component: PassengersComponent },
  { path: 'Dashboard/PreventionCategory/Add', canActivate: [UserauthGuard], component: AddPreventionCategoriesComponent },
  { path: 'Dashboard/PreventionCategory/Edit/:id', canActivate: [AuthGuard], component: EditPreventionCategoryComponent },
  { path: 'Dashboard/PreventionCategory', canActivate: [UserauthGuard], component: PreventionCategoriesComponent },
  { path: 'Dashboard/QHSEPosition/Add', canActivate: [UserauthGuard], component: AddQHSEPositionsComponent },
  { path: 'Dashboard/QHSEPosition/Edit/:id', canActivate: [AuthGuard], component: EditQHSEPositionComponent },
  { path: 'Dashboard/QHSEPosition', canActivate: [UserauthGuard], component: QHSEPositionsComponent },
  { path: 'Dashboard/QHSEPositionName/Add', canActivate: [UserauthGuard], component: AddQHSENamesComponent },
  { path: 'Dashboard/QHSEPositionName/Edit/:id', canActivate: [AuthGuard], component: EditQHSEPositionNameComponent },
  { path: 'Dashboard/QHSEPositionName', canActivate: [UserauthGuard], component: QHSENamesComponent },
  { path: 'Dashboard/ReportedByName/Add', canActivate: [UserauthGuard], component: AddReportedByNamesComponent },
  { path: 'Dashboard/ReportedByName/Edit/:id', canActivate: [AuthGuard], component: EditReportedByNameComponent },
  { path: 'Dashboard/ReportedByName', canActivate: [UserauthGuard], component: ReportedByNamesComponent },
  { path: 'Dashboard/ReportedByPosition/Add', canActivate: [UserauthGuard], component: AddReportedByPositionsComponent },
  { path: 'Dashboard/ReportedByPosition/Edit/:id', canActivate: [AuthGuard], component: EditReportedByPositionComponent },
  { path: 'Dashboard/ReportedByPosition', canActivate: [UserauthGuard], component: ReportedByPositionsComponent },
  { path: 'Dashboard/Rig/Add', canActivate: [UserauthGuard], component: AddRigsComponent },
  { path: 'Dashboard/Rig/Edit/:id', canActivate: [AuthGuard], component: EditRigComponent },
  { path: 'Dashboard/Rig', canActivate: [UserauthGuard], component: RigsComponent },
  { path: 'Dashboard/RouteName/Add', canActivate: [AllAuthGuardGuard], component: AddRouteNamesComponent },
  { path: 'Dashboard/RouteName/Edit/:id', canActivate: [RadioauthGuard], component: EditRouteNameComponent },
  { path: 'Dashboard/RouteName', canActivate: [AllAuthGuardGuard], component: RouteNamesComponent },
  { path: 'Dashboard/ToolPusherPosition/Add', canActivate: [UserauthGuard], component: AddToolPusherPositionsComponent },
  { path: 'Dashboard/ToolPusherPosition/Edit/:id', canActivate: [AuthGuard], component: EditToolPusherPositionComponent },
  { path: 'Dashboard/ToolPusherPosition', canActivate: [UserauthGuard], component: ToolPusherPositionsComponent },
  { path: 'Dashboard/ToolPusherPositionName/Add', canActivate: [UserauthGuard], component: AddToolPusherNamesComponent },
  { path: 'Dashboard/ToolPusherPositionName/Edit/:id', canActivate: [AuthGuard], component: EditToolPusherPositionNameComponent },
  { path: 'Dashboard/ToolPusherPositionName', canActivate: [UserauthGuard], component: ToolPusherNamesComponent },
  { path: 'Dashboard/TypeOfInjury/Add', canActivate: [UserauthGuard], component: AddTypeofInjuriesComponent },
  { path: 'Dashboard/TypeOfInjury/Edit/:id', canActivate: [AuthGuard], component: EditTypeOfInjuryComponent },
  { path: 'Dashboard/TypeOfInjury', canActivate: [UserauthGuard], component: TypeofInjuriesComponent },
  { path: 'Dashboard/TypeOfObserviationCategory/Add', canActivate: [UserauthGuard], component: AddTypeofObserviationComponent },
  { path: 'Dashboard/TypeOfObserviationCategory/Edit/:id', canActivate: [AuthGuard], component: EditTypeOfObservationCategoryComponent },
  { path: 'Dashboard/TypeOfObserviationCategory', canActivate: [UserauthGuard], component: TypeofObserviationComponent },
  { path: 'Dashboard/Vehicle/Add', canActivate: [AllAuthGuardGuard], component: AddVehiclesComponent },
  { path: 'Dashboard/Vehicle/Edit/:id', canActivate: [RadioauthGuard], component: EditVehicleComponent },
  { path: 'Dashboard/Vehicle', canActivate: [AllAuthGuardGuard], component: VehiclesComponent },
  { path: 'Dashboard/ViolationCategory/Add', canActivate: [UserauthGuard], component: AddViolationCategoriesComponent },
  { path: 'Dashboard/ViolationCategory/Edit/:id', canActivate: [AuthGuard], component: EditViolationCategoryComponent },
  { path: 'Dashboard/ViolationCategory', canActivate: [UserauthGuard], component: ViolationCategoriesComponent },
  { path: 'Dashboard/Classification/Add', canActivate: [UserauthGuard], component: AddClassificationComponent },
  { path: 'Dashboard/Classification/Edit/:id', canActivate: [AuthGuard], component: EditClassificationComponent },
  { path: 'Dashboard/Classification', canActivate: [UserauthGuard], component: ClassificationsComponent },
  { path: 'Dashboard/PTSM', canActivate: [UserauthGuard], component: PTSMComponent },
  { path: 'Dashboard/PTSM/Add', canActivate: [UserauthGuard], component: AddPTSMComponent },
  { path: 'Dashboard/PTSM/Edit/:id/:reportDate', canActivate: [AllEditGuard], component: EditPTSMComponent },
  { path: 'Dashboard/EmpCode', canActivate: [UserauthGuard], component: EmpCodeComponent },
  { path: 'Dashboard/EmpCode/Add', canActivate: [UserauthGuard], component: AddEmpCodeComponent },
  { path: 'Dashboard/EmpCode/Edit/:id', canActivate: [AuthGuard], component: EditEmpCodeComponent },

  { path: 'Dashboard/BOP', canActivate: [UserauthGuard], component: BOPComponent },
  { path: 'Dashboard/BOP/Add', canActivate: [UserauthGuard], component: BOPComponent },
  { path: 'Dashboard/BOP/Edit/:id/:reportDate', canActivate: [UserEditGuard], component: EditBOPComponent },
  { path: 'PrintBOP', canActivate: [UserauthGuard], component: PrintBopComponent },
  { path: 'Dashboard/Position', canActivate: [UserauthGuard], component: PositionComponent },
  { path: 'Dashboard/Position/Add', canActivate: [UserauthGuard], component: AddPostionComponent },
  { path: 'Dashboard/Position/Edit/:id', canActivate: [AuthGuard], component: EditPositionComponent },


  { path: 'Dashboard/EmployeeCompetencyEvaluation/Edit/:id/:reportDate', canActivate: [UserEditGuard], component: EditEmployeeCompetencyEvaluationComponent },

  { path: 'PrintEmployeeCompetencyEvaluation', canActivate: [UserauthGuard], component: PrintEmployeeCompetencyEvaluationComponent },

  { path: 'PrintAccident', canActivate: [UserauthGuard], component: ReportAccidentComponent },
  { path: 'StopCard', canActivate: [UserauthGuard], component: StopcardComponent },
  { path: 'PrintStopCard', canActivate: [UserauthGuard], component: StopCardReportComponent },
  { path: 'PrintPTSM', canActivate: [UserauthGuard], component: PrintPTSMComponent },
  { path: 'Dashboard/Stopcard', canActivate: [UserauthGuard], component: StopcardTableComponent },
  { path: 'AccidentTable', canActivate: [UserauthGuard], component: AccidentTableComponent },
  { path: 'BopTable', canActivate: [UserauthGuard], component: BopTableComponent },
  { path: 'Dashboard', canActivate: [UserauthGuard], component: DashboardComponent },
  { path: 'SubDashboard', canActivate: [AllAuthGuardGuard], component: SubDashboardComponent },
  { path: 'Profile', canActivate: [AllAuthGuardGuard], component: ProfileComponent },
  { path: 'Health', canActivate: [UserauthGuard], component: HeathComponent },
  { path: 'Safety', canActivate: [UserauthGuard], component: SafetyComponent },
  { path: 'Environment', canActivate: [UserauthGuard], component: EnvironmentComponent },
  { path: 'Quality', canActivate: [UserauthGuard], component: QualityComponent },
  { path: 'AboutUs', canActivate: [AllAuthGuardGuard], component: ContactUsComponent },
  { path: 'SJP', canActivate: [AllAuthGuardGuard], component: JMPFormComponent },
  { path: 'PrintSJP', canActivate: [AllAuthGuardGuard], component: JMPReportComponent },
  { path: 'Dashboard/SJPTable', canActivate: [AllAuthGuardGuard], component: JMPTableComponent },
  { path: 'changepassword', canActivate: [AllAuthGuardGuard], component: ChangepasswordComponent },
  { path: 'stopCardCharts', canActivate: [UserauthGuard], component: StopCardChartComponent },
  { path: 'PotentialHazardCharts', canActivate: [AuthGuard], component: PotentialHazardChartsComponent },
  { path: 'DrillCompareWithRigsCharts', canActivate: [AuthGuard], component: DrillsCompareByRigsComponent },
  { path: 'RigMovePerformanceCharts', canActivate: [UserauthGuard], component: RigPerformanceChartComponent },
  { path: 'stopCardCompareCharts', canActivate: [UserauthGuard], component: StopCardCompareChartComponent },
  { path: 'RigMovePerformanceCompareCharts', canActivate: [UserauthGuard], component: RigPerformanceCompareChartsComponent },
  { path: 'RigPerformance/Add', canActivate: [UserauthGuard], component: AddRigMovePerformanceEvaluationComponent },
  { path: 'RigPerformance/Edit/:id/:reportDate', canActivate: [UserEditGuard], component: EditRigMovePerformanceEvaluationComponent },
  { path: 'RigPerformance', canActivate: [UserauthGuard], component: RigMovePerformanceEvaluationComponent },
  { path: 'PrintRigPerformance', canActivate: [UserauthGuard], component: PrintRigPerformanceComponent },
  { path: 'Clinc', canActivate: [UserauthGuard], component: ClincFormsComponent },
  { path: 'QHSE', canActivate: [UserauthGuard], component: QSHEFormsComponent },
  { path: 'Policy', canActivate: [UserauthGuard], component: PolicyComponent },
  { path: 'EmployeeCompetencyEvaluation/Add', canActivate: [UserauthGuard], component: EmployeeCompetencyEvaluationComponent },
  { path: 'Dashboard/PPE/Add', canActivate: [AllAuthGuardGuard], component: AddPPEsComponent },
  { path: 'Dashboard/PPE/Edit/:id', canActivate: [AllAuthGuardGuard], component: EditPPEsComponent },
  { path: 'Dashboard/PPE', canActivate: [AllAuthGuardGuard], component: PPEsComponent },
  { path: 'Dashboard/Responsibility/Add', canActivate: [AllAuthGuardGuard], component: AddResponsibilityComponent },
  { path: 'Dashboard/Responsibility/Edit/:id', canActivate: [AllAuthGuardGuard], component: EditResponsibilityComponent },
  { path: 'Dashboard/Responsibility', canActivate: [AllAuthGuardGuard], component: ResponsibilityComponent },
  { path: 'PPEReceiving/Add', canActivate: [UserauthGuard], component: AddPPEReceivingComponent },
  { path: 'PPEReceiving/Edit/:id/:reportDate', canActivate: [UserEditGuard], component: EditPPEReceivingComponent },
  { path: 'PPEReceiving', canActivate: [UserauthGuard], component: PPEReceivingTableComponent },
  { path: 'PrintPPEReceiving', canActivate: [UserauthGuard], component: PrintPPEReceivingComponent },
  { path: 'Dashboard/Client', canActivate: [AllAuthGuardGuard], component: ClientComponent },
  { path: 'Dashboard/Client/Add', canActivate: [AllAuthGuardGuard], component: AddClientComponent },
  { path: 'Dashboard/Client/Edit/:id', canActivate: [AllAuthGuardGuard], component: EditClientComponent },
  { path: 'Dashboard/LeadershipVisit', canActivate: [AllAuthGuardGuard], component: LeaderShipVisitComponent },
  { path: 'Dashboard/LeadershipVisit/Add', canActivate: [AllAuthGuardGuard], component: AddLeaderShipVisitComponent },
  { path: 'Dashboard/LeadershipVisit/Edit/:id', canActivate: [AllAuthGuardGuard], component: EditLeaderShipVisitComponent },
  { path: 'Dashboard/Crew', canActivate: [AllAuthGuardGuard], component: CrewComponent },
  { path: 'Dashboard/Crew/Add', canActivate: [AllAuthGuardGuard], component: AddCrewComponent },
  { path: 'Dashboard/Crew/Edit/:id', canActivate: [AllAuthGuardGuard], component: EditCrewComponent },
  { path: 'Dashboard/DaysSinceNoLTI', canActivate: [AllAuthGuardGuard], component: DaysScienceNoLTIComponent },
  { path: 'Dashboard/DaysSinceNoLTI/Add', canActivate: [AllAuthGuardGuard], component: AddDaysScienceNoLTIComponent },
  { path: 'Dashboard/DaysSinceNoLTI/Edit/:id', canActivate: [AllAuthGuardGuard], component: EditDaysScienceNoLTIComponent },
  { path: 'Dashboard/DaysSinceNoFatality', canActivate: [AllAuthGuardGuard], component: DaysSinceNoFatalityComponent },
  { path: 'Dashboard/DaysSinceNoFatality/Add', canActivate: [AllAuthGuardGuard], component: AddDaysSinceNoFatalityComponent },
  { path: 'Dashboard/DaysSinceNoFatality/Edit/:id', canActivate: [AllAuthGuardGuard], component: EditDaysSinceNoFatalityComponent },
  { path: 'QHSEDaily', canActivate: [UserauthGuard], component: QHSEDailyComponent },
  { path: 'QHSEDaily/Add', canActivate: [AllAuthGuardGuard], component: AddQHSEDailyComponent },
  { path: 'QHSEDaily/Edit/:id/:reportDate', canActivate: [AllEditGuard], component: EditQHSEDailyComponent },
  { path: 'PrintQHSEDaily', canActivate: [AllAuthGuardGuard], component: PrintQHSEDailyComponent },
  { path: 'QHSEChartByMonth', canActivate: [UserOnlyAuthGardGuard], component: UserChartQHSEDailyByMonthComponent },
  { path: 'QHSEChartByYear', canActivate: [UserOnlyAuthGardGuard], component: UserChartQHSEDailyByYearComponent },
  { path: 'QHSEChartByYearAllRigs', canActivate: [AuthGuard], component: AdminChartQHSEDailyByYearComponent },
  { path: 'QHSEChartByMonthAllRigs', canActivate: [AuthGuard], component: AdminChartQHSEDailyByMonthComponent },
  { path: 'QHSEDailyPrintById/:id', canActivate: [UserauthGuard], component: QHSEDailyPrintByIdComponent },
  { path: 'PrintAccidentById/:id', canActivate: [UserauthGuard], component: PrintAccidentByIdComponent },
  { path: 'PrintStopCardById/:id', canActivate: [UserauthGuard], component: PrintStopCardByIdComponent },
  { path: 'PrintSJPById/:id', canActivate: [UserauthGuard], component: PrintSJPByIdComponent },
  { path: 'PrintRMPEById/:id', canActivate: [UserauthGuard], component: PrintRMPEByIdComponent },
  { path: 'PrintPOBById/:id', canActivate: [UserauthGuard], component: PrintPOBByIdComponent },
  { path: 'PrintPTSMById/:id', canActivate: [UserauthGuard], component: PrintPTSMByIdComponent },
  { path: 'PrintEmployeeCompetencyEvaluationById/:id', canActivate: [UserauthGuard], component: PrintEmployeeCompetencyEvaluationtByIdComponent },
  { path: 'PrintPPEReceivingById/:id', canActivate: [UserauthGuard], component: PrintPPEReceivingByIdComponent },
  { path: 'PrintPotentialHazardById/:id', canActivate: [UserauthGuard], component: PrintPotentialHazardByIdComponent },

  // ------------------DRIILS---------

  { path: 'Drill/Add', canActivate: [UserauthGuard], component: DrillComponent },
  { path: 'Drill/Edit/:id/:reportDate', canActivate: [UserEditGuard], component: EditDrillComponent },
  { path: 'Dashboard/Drill', canActivate: [AllAuthGuardGuard], component: DrillTableComponent },
  { path: 'PrintDrill', canActivate: [UserauthGuard], component: PrintDrillComponent },
  { path: 'PrintDrillById/:id', canActivate: [UserauthGuard], component: PrintDrillByIdComponent },

  { path: 'DrillChart', canActivate: [UserauthGuard], component: ChartWithDrillTypeComponent },
  { path: 'DrillCompareCharts', canActivate: [UserauthGuard], component: ChartDrillWitManagerNameComponent },

  //----------------Drill Types-----------------------------------
  { path: 'Dashboard/DrillType/Add', canActivate: [AllAuthGuardGuard], component: AddDrillTypesComponent },
  { path: 'Dashboard/DrillType/Edit/:id', canActivate: [AuthGuard], component: EditDrillTypesComponent },
  { path: 'Dashboard/DrillType', canActivate: [UserauthGuard], component: DrillTypesComponent },

  //***************** Customer Satisfaction Evaluation Report  */
  { path: 'Customer/Add', canActivate: [UserauthGuard], component: CustomerReportComponent },
  { path: 'Dashboard/Customer', canActivate: [AllAuthGuardGuard], component: CustomerReportTableComponent },
  { path: 'Customer/Edit/:id/:reportDate', canActivate: [UserEditGuard], component: EditCustomerReportComponent },
  { path: 'PrintCustomer', canActivate: [UserauthGuard], component: PrintCustomerReportComponent },
  { path: 'PrintCustomerById/:id', canActivate: [UserauthGuard], component: PrintCustomerReportByIdComponent },

  ////***Charts******************************** */
  { path: 'CustomerChartByYearAllRigs', canActivate: [AuthGuard], component: CustomerCompareAllRigsByYearComponent },
  { path: 'CustomerChartByMonthAllRigs', canActivate: [AuthGuard], component: CustomerCompareAllRigsByMonthComponent },
  { path: 'CustomerChartByYearTwoRigs', canActivate: [AuthGuard], component: CustomerCompareTwoRigByYearComponent },
  { path: 'CustomerChartByMonthUser', canActivate: [UserOnlyAuthGardGuard], component: CustomerCompareByMonthUserComponent },

  //***************** End The Customer Satisfaction Evaluation Report  */

  //******************** CorrectiveAction *****************************
  //Standard
  { path: 'Dashboard/Standard/Add', canActivate: [UserauthGuard], component: AddStandardComponent },
  { path: 'Dashboard/Standard', canActivate: [AllAuthGuardGuard], component: StandardComponent },
  { path: 'Dashboard/Standard/Edit/:id', canActivate: [AuthGuard], component: EditStandardComponent },

  //CorrectiveResponsability
  { path: 'Dashboard/CorrectiveResponsability/Add', canActivate: [UserauthGuard], component: AddCorrectiveResponsabilityComponent },
  { path: 'Dashboard/CorrectiveResponsability', canActivate: [AllAuthGuardGuard], component: CorrectiveResponsabilityComponent },
  { path: 'Dashboard/CorrectiveResponsability/Edit/:id', canActivate: [AuthGuard], component: EditCorrectiveResponsabilityComponent },

  //CorrectiveObservation
  { path: 'Dashboard/CorrectiveObservation/Add', canActivate: [UserauthGuard], component: AddCorrectiveObservationComponent },
  { path: 'Dashboard/CorrectiveObservation', canActivate: [AllAuthGuardGuard], component: CorrectiveObservationComponent },
  { path: 'Dashboard/CorrectiveObservation/Edit/:id', canActivate: [AuthGuard], component: EditCorrectiveObservationComponent },

  //RootCause
  { path: 'Dashboard/RootCause/Add', canActivate: [UserauthGuard], component: AddRootCauseComponent },
  { path: 'Dashboard/RootCause', canActivate: [AllAuthGuardGuard], component: RootCauseComponent },
  { path: 'Dashboard/RootCause/Edit/:id', canActivate: [AuthGuard], component: EditRootCauseComponent },

  //correctiveAction
  { path: 'Dashboard/CorrectiveAction/Add', canActivate: [UserauthGuard], component: AddCorrectiveActionComponent },
  { path: 'Dashboard/CorrectiveAction', canActivate: [AllAuthGuardGuard], component: CorrectiveActionTableComponent },
  { path: 'Dashboard/CorrectiveAction/Edit/:id/:reportDate', canActivate: [UserEditGuard], component: EditCorrectiveActionComponent },
  { path: 'Dashboard/CorrectiveAction/Print', canActivate: [UserauthGuard], component: PrintCorrectiveComponent },
  { path: 'Dashboard/CorrectiveAction/Print/:id', canActivate: [UserauthGuard], component: PrintCorrectiveByIdComponent },
  { path: 'Dashboard/CorrectiveAction/StatusChart', canActivate: [UserauthGuard], component: CorrectiveChartComponent },
  { path: 'Dashboard/CorrectiveAction/ResponsabilityChart', canActivate: [UserauthGuard], component: CorrectiveByResponsabilityComponent },
  { path: 'Dashboard/CorrectiveAction/ObservationChart', canActivate: [UserauthGuard], component: CorrectiveByObservationComponent },
  { path: 'Dashboard/CorrectiveAction/StandardChart', canActivate: [UserauthGuard], component: CorrectiveByStandardComponent },
  { path: 'Dashboard/CorrectiveAction/SuggestedDateChart', canActivate: [UserauthGuard], component: CorrectiveBySuggestedDateComponent },

  //Crane
  { path: 'Dashboard/Crane/Add', canActivate: [UserauthGuard], component: AddCraneComponent },
  { path: 'Dashboard/Crane', canActivate: [AllAuthGuardGuard], component: CraneComponent },
  { path: 'Dashboard/Crane/Edit/:id/:reportDate', canActivate: [UserEditGuard], component: EditCraneComponent },
  { path: 'Dashboard/Crane/Print', canActivate: [UserauthGuard], component: PrintCraneComponent },
  { path: 'Dashboard/Crane/Print/:id', canActivate: [UserauthGuard], component: PrintCraneByIdComponent },
  // { path: 'Dashboard/CorrectiveAction/Chart' ,canActivate: [UserauthGuard],component: CorrectiveChartComponent },

  //Forklift
  { path: 'Dashboard/Forklift/Add', canActivate: [UserauthGuard], component: AddForkliftComponent },
  { path: 'Dashboard/Forklift', canActivate: [AllAuthGuardGuard], component: ForkliftComponent },
  { path: 'Dashboard/Forklift/Edit/:id/:reportDate', canActivate: [UserEditGuard], component: EditForkliftComponent },
  { path: 'Dashboard/Forklift/Print', canActivate: [UserauthGuard], component: PrintForkliftComponent },
  { path: 'Dashboard/Forklift/Print/:id', canActivate: [UserauthGuard], component: PrintForkliftByIdComponent },
  // { path: 'Dashboard/CorrectiveAction/Chart' ,canActivate: [UserauthGuard],component: CorrectiveChartComponent },

  //WeeklyClinic
  { path: 'Dashboard/WeeklyClinic/Add', canActivate: [UserauthGuard], component: AddWeeklyClinicComponent },
  { path: 'Dashboard/WeeklyClinic', canActivate: [AllAuthGuardGuard], component: WeeklyClinicComponent },
  // { path: 'Dashboard/WeeklyClinic/Edit/:id/:reportDate', canActivate: [UserauthGuard], component: EditWeeklyClinicComponent },
  { path: 'Dashboard/WeeklyClinic/Edit/:id/:reportDate', canActivate: [UserEditGuard], component: EditWeeklyClinicComponent },
  { path: 'Dashboard/WeeklyClinic/Print', canActivate: [UserauthGuard], component: PrintWeeklyClinicComponent },
  { path: 'Dashboard/WeeklyClinic/Print/:id', canActivate: [UserauthGuard], component: PrintWeeklyClinicByIdComponent },
  { path: 'Dashboard/WeeklyClinic/Chart', canActivate: [UserauthGuard], component: WeeklyClinicChartComponent },

  //Handover
  { path: 'Dashboard/Handover/Add', canActivate: [UserauthGuard], component: AddHandoverComponent },
  { path: 'Dashboard/Handover', canActivate: [AllAuthGuardGuard], component: HandoverComponent },
  { path: 'Dashboard/Handover/Edit/:id', canActivate: [UserauthGuard], component: EditHandoverComponent },
  { path: 'Dashboard/Handover/Print', canActivate: [UserauthGuard], component: PrintHandoverComponent },
  { path: 'Dashboard/Handover/Print/:id', canActivate: [UserauthGuard], component: PrintHandoverByIdComponent },
  { path: 'Dashboard/Handover/Chart', canActivate: [UserauthGuard], component: HandoverChartComponent },

  //RigCertificates
  { path: 'Dashboard/RigCertificates/Add', canActivate: [UserauthGuard], component: AddRigCertificatesComponent },
  { path: 'Dashboard/RigCertificates', canActivate: [AllAuthGuardGuard], component: RigCertificatesComponent },
  { path: 'Dashboard/RigCertificates/Edit/:id/:reportDate', canActivate: [UserauthGuard], component: EditRigCertificatesComponent },
  { path: 'Dashboard/RigCertificates/Print', canActivate: [UserauthGuard], component: PrintRigCertificatesComponent },
  { path: 'Dashboard/RigCertificates/Print/:id', canActivate: [UserauthGuard], component: PrintRigCertificatesByIdComponent },

  //Certificatestype
  { path: 'Dashboard/CertificatesType/Add', canActivate: [UserauthGuard], component: AddCertificatesTypeComponent },
  { path: 'Dashboard/CertificatesType', canActivate: [AllAuthGuardGuard], component: CertificatesTypeComponent },
  { path: 'Dashboard/CertificatesType/Edit/:id', canActivate: [AuthGuard], component: EditCertificatesTypeComponent },

  //HSEEquipmentList
  { path: 'Dashboard/HSEEquipmentList/Add', canActivate: [UserauthGuard], component: AddHSEEquipmentListComponent },
  { path: 'Dashboard/HSEEquipmentList/Edit/:id', canActivate: [AuthGuard], component: EditHSEEquipmentListComponent },
  { path: 'Dashboard/HSEEquipmentList', canActivate: [UserauthGuard], component: HSEEquipmentListComponent },


  //***************** Weekly Inspection Report  */
  { path: 'WeeklyInspection/Add', canActivate: [UserauthGuard], component: WeeklyInspectionComponent },
  { path: 'Dashboard/WeeklyInspection', canActivate: [AllAuthGuardGuard], component: WeeklyInspectionTableComponent },
  { path: 'WeeklyInspection/Edit/:id/:reportDate', canActivate: [UserEditGuard], component: EditWeeklyInspectionComponent },
  { path: 'PrintWeeklyInspection', canActivate: [UserauthGuard], component: PrintWeeklyInspectionComponent },
  { path: 'PrintWeeklyInspectionById/:id', canActivate: [UserauthGuard], component: WeeklyInspectionByIdComponent },

  //***************** Weekly Camp Inspection Report  */
  { path: 'WeeklyCampInspection/Add', canActivate: [UserauthGuard], component: WeeklyCampInspectionComponent },
  { path: 'Dashboard/WeeklyCampInspection', canActivate: [AllAuthGuardGuard], component: WeeklyCampInspectionTableComponent },
  { path: 'WeeklyCampInspection/Edit/:id/:reportDate', canActivate: [UserEditGuard], component: EditweeklyCampInspectionComponent },
  { path: 'PrintWeeklyCampInspection', canActivate: [UserauthGuard], component: PrintweeklyCampInspectionComponent },
  { path: 'PrintWeeklyCampInspectionById/:id', canActivate: [UserauthGuard], component: PrintweeklyCampInspectionByIDComponent },

  //***************** Medical Report  */
  { path: 'MedicalReport/Add', canActivate: [UserauthGuard], component: AddMedicalReportComponent },
  { path: 'Dashboard/MedicalReport', canActivate: [AllAuthGuardGuard], component: MedicalReportTableComponent },
  { path: 'MedicalReport/Edit/:id/:reportDate', canActivate: [UserEditGuard], component: EditMedicalReportComponent },
  { path: 'PrintMedicalReport', canActivate: [UserauthGuard], component: PrintMedicalReportComponent },
  { path: 'PrintMedicalReportById/:id', canActivate: [UserauthGuard], component: PrintMedicalReportByIdComponent },
  { path: 'MedicalReportChartByYear', canActivate: [AllAuthGuardGuard], component: GetMedicalReportByYearWithChartComponent },
  { path: 'MedicalReportChartByMonth', canActivate: [AllAuthGuardGuard], component: GetMedicalReportByMonthWithChartComponent },

  //***************** Medical History Report */
  { path: 'MedicalHistory/Add', canActivate: [UserauthGuard], component: AddMedicalHistoryReportComponent },
  { path: 'MedicalHistory/Edit/:id/:reportDate', canActivate: [UserEditGuard], component: EditMedicalHistoryComponent },

  { path: 'PrintMedicalHistoryById/:id', canActivate: [UserauthGuard], component: PrintMedicalHistoryByIdComponent },
  { path: 'PrintMedicalHistory', canActivate: [UserauthGuard], component: PrintMedicalHistoryComponent },
  { path: 'MedicalHistoryReportChartByYear', canActivate: [AllAuthGuardGuard], component: GetMedicalHistoryReportByYearWithChartComponent },

  { path: 'Dashboard/MedicalHistory', canActivate: [AllAuthGuardGuard], component: MedicalHistoryReportTableComponent },

  // *********************************** Daily Lifting Report ***********************************************
  { path: 'Dashboard/CraneDailyReports/Add', canActivate: [UserauthGuard], component: AddCraneDailyLiftingReportsComponent },
  { path: 'Dashboard/CraneDailyReports', canActivate: [UserauthGuard], component: CraneDailyLiftingReportsComponent },
  { path: 'Dashboard/CraneDailyReports/Edit/:id', canActivate: [AuthGuard], component: EditMobileCraneDailyLeftingComponent },
  { path: 'Dashboard/ForkliftDailyReports/Add', canActivate: [UserauthGuard], component: AddForkliftDailyLeftingComponent },
  { path: 'Dashboard/ForkliftDailyReports', canActivate: [UserauthGuard], component: ForkliftDailyLeftingComponent },
  { path: 'Dashboard/ForkliftDailyReports/Edit/:id', canActivate: [AuthGuard], component: EditForkliftDailyLeftingComponent },

  { path: 'DailyLifting/Add', canActivate: [UserauthGuard], component: AddDailyLiftingReportComponent },
  { path: 'DailyLifting/Edit/:id/:reportDate', canActivate: [UserEditGuard], component: EditDailyLiftingReportComponent },
  { path: 'Dashboard/DailyLifting', canActivate: [UserauthGuard], component: DailyLiftingReportTableComponent },
  { path: 'DailyLiftingReport/Print', canActivate: [UserauthGuard], component: PrintDailyLiftingReportComponent },
  { path: 'DailyLiftingReport/Print/:id', canActivate: [UserauthGuard], component: PrintDailyLiftingReportByIdComponent },

  // ********************************* Vehicle Weekly Check Report *********************************************

  { path: 'VehicleWeeklyCheck/Add', canActivate: [UserauthGuard], component: AddVehicleWeeklyChecklistReportComponent },
  { path: 'VehicleWeeklyChecklist/Edit/:id/:reportDate', canActivate: [UserEditGuard], component: EditVehicleWeeklyChecklistReportComponent },
  { path: 'Dashboard/VehicleWeeklyChecklist', canActivate: [AllAuthGuardGuard], component: VehicleWeeklyChecklistReportTableComponent },
  { path: 'PrintVehicleWeeklyChecklist', canActivate: [UserauthGuard], component: PrintVehicleWeeklyChecklistReportComponent },
  { path: 'PrintVehicleWeeklyChecklistById/:id', canActivate: [UserauthGuard], component: PrintVehicleWeeklyChecklistReportByIdComponent },


  { path: '**', component: PageNotFoundComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
