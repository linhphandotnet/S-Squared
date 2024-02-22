import { Component, Input } from '@angular/core';
import { Employee } from '../../../employee/data.model';

@Component({
  selector: 'app-list-view',
  templateUrl: './list-view.component.html',
  styleUrls: ['./list-view.component.css']
})
export class ListViewComponent {
  @Input() empdata: Employee[] = []; 
}
