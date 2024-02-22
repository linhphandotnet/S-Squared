import { Component, OnInit } from '@angular/core';
import { AppSettingService } from '../shared/service/app-setting.service';
import { Employee } from './data.model';
import { EmployeeService } from './employee.service';

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.css']
})
export class EmployeeComponent implements OnInit {
  employees: Employee[] = [];
  managers: Employee[] = [];
  constructor(private employeeService: EmployeeService, private appSetting: AppSettingService) {
  }

  ngOnInit(): void {
    if (this.appSetting.isReady) {
        this.getEmployees();
        this.getManagerList();
    }
    else {
      this.appSetting.settingLoaded$.subscribe(r => {
        this.getEmployees();
        this.getManagerList();
      })
    }
  }

  getEmployees() {
    this.employeeService.getEmployees().subscribe(res => {
      this.employees = res;
    })
  }

  getEmployeesByManager(managerId:number|null) {
    this.employeeService.getEmployeeByManager(managerId).subscribe(res => {
      this.employees = res;
    })
  }

  getManagerList() {
    this.employeeService.getManagers().subscribe(m => {
      this.managers = m;
    })
  }

  managerOnChange(event: any) {
    let managerId = event.target.value;
    this.getEmployeesByManager(managerId);
  }
}
