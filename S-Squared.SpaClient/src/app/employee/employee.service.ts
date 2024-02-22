import { Injectable } from '@angular/core';
import { Observable, retry } from 'rxjs';
import { observableToBeFn } from 'rxjs/internal/testing/TestScheduler';
import { AppSettingService } from '../shared/service/app-setting.service';
import { DataService } from '../shared/service/data.service';
import { Employee, Manager } from './data.model';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {
  baseUrl: string = "";
  constructor(private dataService: DataService, private appSetting: AppSettingService) {
    if (appSetting.isReady) {
      this.baseUrl = appSetting.appSetting.employeeUrl + "/api/employees";
    }
    else {
      appSetting.settingLoaded$.subscribe(res => {
        this.baseUrl = appSetting.appSetting.employeeUrl + "/api/employees";
      })
    }
  }

  getEmployees() {
    return this.dataService.getData(this.baseUrl).pipe<Employee[]>(res => {
      return res;
    })
  }
  getEmployeeByManager(managerId:number|null) : Observable<Employee[]>{
    return this.dataService.getData(this.baseUrl + "/managerid/" + managerId).pipe<Employee[]>(res => {
      return res;
    })
  }

  getManagers(): Observable<Employee[]>{
    return this.dataService.getData(this.baseUrl + "/managers").pipe<Employee[]>(res => {
      return res;
    })
  }

  checkEmployeeExited(empId: string): any {
    return this.dataService.getData(this.baseUrl + "check?id=" + empId).subscribe(r => {
    //  if (r)
    //    return true;
    //  else {
    //    return false;
    //  }
      return r == true;
    })
  }

  createEmployee(data: Employee): Observable<boolean> {
    return this.dataService.postData(this.baseUrl, data).pipe<boolean>(res => {
      return res;
    })
  }
}
