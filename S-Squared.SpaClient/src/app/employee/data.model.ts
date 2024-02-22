export interface Employee {
  id: number;
  employeeId: string;
  lastName: string;
  firstName: string;
  managerId: number;
  isManager: boolean;
  roles: EmployeeRole[];
}

export interface Role {
  id: number;
  roleName: string;
}

export interface EmployeeRole {
  roleId: number;
  employeeId: number;
}

export interface Manager {
  id: number;
  fullName: string;
}
