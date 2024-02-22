import { Component, OnInit } from '@angular/core';
import { AppSettingService } from './shared/service/app-setting.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
  title = 'S-Squared.SpaClient';
  constructor(private appSetting: AppSettingService) {

  }
    ngOnInit(): void {
      this.appSetting.getAppSetting();
    }



}
