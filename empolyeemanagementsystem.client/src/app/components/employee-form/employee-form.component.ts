import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { EmployeeService } from '../../services/employee.service';
import { Employee } from '../../models/employee.model';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-employee-form',
  standalone: false,
  templateUrl: './employee-form.component.html',
  styleUrl: './employee-form.component.css',
})
export class EmployeeFormComponent implements OnInit {
  employeeForm!: FormGroup;
  isEditMode = false;
  employeeId!: number;

  constructor(
    private fb: FormBuilder,
    private employeeService: EmployeeService,
    private router: Router,
    private route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.employeeForm = this.fb.group({
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      position: ['', Validators.required],
    });

    const id = this.route.snapshot.paramMap.get('id');
    if (id) {
      this.isEditMode = true;
      this.employeeId = +id;
      this.employeeService.getById(this.employeeId).subscribe((emp) => {
        this.employeeForm.patchValue(emp);
      });
    }
  }

  onSubmit(): void {
    if (this.employeeForm.invalid) return;

    const employee: Employee = {
      id: this.employeeId,
      ...this.employeeForm.value,
    };

    let request: Observable<any>;

    if (this.isEditMode) {
      request = this.employeeService.update(employee);
    } else {
      request = this.employeeService.create(employee);
    }

    request.subscribe(() => this.router.navigate(['/']));
  }
}
