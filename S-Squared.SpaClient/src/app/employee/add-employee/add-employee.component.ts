import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AppSettingService } from '../../shared/service/app-setting.service';
import { Employee, EmployeeRole, Role } from '../data.model';
import { EmployeeService } from '../employee.service';
import { RoleService } from '../role.service';

@Component({
  selector: 'app-add-employee',
  templateUrl: './add-employee.component.html',
  styleUrls: ['./add-employee.component.css']
})
export class AddEmployeeComponent {
  addForm!: FormGroup;
  baseUrl: string = "";
  roles: Role[] = [];
  employee: Employee = <Employee>{};
  managers: Employee[] = [];
  firstLoaded: boolean = true;
  constructor(private employeeService: EmployeeService, private roleService: RoleService, private formBuilder: FormBuilder, private router: Router, private appSetting: AppSettingService) {
    this.addForm = formBuilder.group({
      employeeId: ['', Validators.required],
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      isManager: false,
      managerId: 0,
      roles: [[], Validators.required]
    });

    if (appSetting.isReady) {
      this.getRoleList();
      this.getManagerList();
    }
    else {
      appSetting.settingLoaded$.subscribe(r => {
        this.getRoleList();
        this.getManagerList();
      })
    }
  }

  getRoleList() {
    let url = this.baseUrl + "/api/role";
    this.roleService.getRoles().subscribe(r => {
      this.roles = r;
    })
  }
  getManagerList() {
    this.employeeService.getManagers().subscribe(m => {
      this.managers = m;
    })
  }

  onSubmit() {
    if (this.addForm.invalid) {
      this.firstLoaded = false;
      return;
    }


    let data = this.addForm.getRawValue();
    //let roles: EmployeeRole[] = [];

    if (data.roles.lenght > 0) {
      let roleArr: any[] = data.roles;
      roleArr.forEach(r => {
        this.employee.roles.push({employeeId:0, roleId:r});
      })
    }
    this.employee.employeeId = data.employeeId;
    this.employee.firstName = data.firstName;
    this.employee.lastName = data.lastName;
    this.employee.isManager = data.isManager;
    this.employee.managerId = data.managerId;

    this.employeeService.createEmployee(this.employee).subscribe(r => {
      if (r) {
        this.router.navigate(['employee']);
      }
      else {
        alert('Create employee fail!. Please check data and try again');
      }
    })
  }
}
