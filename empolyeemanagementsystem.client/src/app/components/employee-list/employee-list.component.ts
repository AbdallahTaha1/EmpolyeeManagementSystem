import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Router, RouterModule } from '@angular/router';
import { EmployeeService } from '../../services/employee.service';
import { Employee } from '../../models/employee.model';

@Component({
  selector: 'app-employee-list',
  standalone: true,
  imports: [CommonModule, RouterModule],
  templateUrl: './employee-list.component.html',
  styleUrls: ['./employee-list.component.css'],
})
export class EmployeeListComponent implements OnInit {
  employees: Employee[] = [];
  currentPage = 1;
  totalPages = 1;
  hasPreviousPage = false;
  hasNextPage = false;

  constructor(
    private employeeService: EmployeeService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.loadEmployees();
  }

  loadEmployees(page: number = 1): void {
    this.employeeService.getPaged(page, 4).subscribe({
      next: (data) => {
        this.employees = data.items;
        this.currentPage = data.currentPage;
        this.totalPages = data.totalPages;
        this.hasPreviousPage = data.hasPreviousPage;
        this.hasNextPage = data.hasNextPage;
      },
      error: (err) => console.error(err),
    });
  }

  onDelete(id: number): void {
    if (confirm('Are you sure you want to delete this employee?')) {
      this.employeeService.delete(id).subscribe(() => {
        this.loadEmployees(); // Refresh list
      });
    }
  }

  onEdit(id: number): void {
    this.router.navigate(['/edit', id]);
  }

  goToPage(page: number): void {
    this.loadEmployees(page);
  }
}
