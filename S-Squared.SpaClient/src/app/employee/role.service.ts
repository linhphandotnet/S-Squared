import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AppSettingService } from '../shared/service/app-setting.service';
import { DataService } from '../shared/service/data.service';
import { Role } from './data.model';

@Injectable({
  providedIn: 'root'
})
export class RoleService {
  baseUrl: string = "";
  constructor(private dataService: DataService, private appSetting: AppSettingService) {
    if (appSetting.isReady) {
      this.baseUrl = appSetting.appSetting.employeeUrl + "/api/roles";
    }
    else {
      appSetting.settingLoaded$.subscribe(res => {
        this.baseUrl = appSetting.appSetting.employeeUrl + "/api/roles";
      })
    }
  }

  getRoles() : Observable<Role[]>{
    return this.dataService.getData(this.baseUrl).pipe<Role[]>(res => {
      return res;
    })
  }
}
