import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';
import { AppSetting } from '../models/app-setting';
import { StorageService } from './storage.service';

@Injectable({
  providedIn: 'root'
})
export class AppSettingService {
  settingUrl: string = "/assets/appsetting.json";
  appSetting: AppSetting = <AppSetting>{};
  private appSettingLoadedSource = new Subject<void>();
  settingLoaded$ = this.appSettingLoadedSource.asObservable();
  isReady: boolean = false;
  constructor(private httpClient: HttpClient, private storageService: StorageService) { }

  getAppSetting() {
    this.httpClient.get(this.settingUrl).subscribe(res => {
      this.appSetting = res as AppSetting;
      this.storageService.set("EmployeeUrl", this.appSetting.employeeUrl);
      this.isReady = true;
      this.appSettingLoadedSource.next();
    });
  }

}
