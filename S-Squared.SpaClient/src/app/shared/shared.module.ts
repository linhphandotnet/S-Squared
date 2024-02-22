import { ModuleWithProviders, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
//import { ListViewComponent } from './components/list-view/list-view.component';
import { DataService } from './service/data.service';
import { AppSettingService } from './service/app-setting.service';
//import { ListViewComponent } from './components/list-view/list-view.component';



@NgModule({
  declarations: [
    //ListViewComponent
  ],
  imports: [
    CommonModule
  ],
  providers: [
    DataService,
    AppSettingService
  ]
})
export class SharedModule {
  static forRoot(): ModuleWithProviders<SharedModule> {
    return {
      ngModule: SharedModule,
      providers: [
        DataService,
        AppSettingService,
      ]
    };
  }
}
