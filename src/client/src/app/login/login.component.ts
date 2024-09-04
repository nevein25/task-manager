import { Component, inject } from '@angular/core';
import { Router, RouterLink } from '@angular/router';
import { UserLogin } from '../_models/user-login';
import { AccountService } from '../_services/account.service';
import { ToastrService } from 'ngx-toastr';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [FormsModule, RouterLink],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  accountService = inject(AccountService);
  private toastr = inject(ToastrService);
  router = inject(Router);


  model: UserLogin = {
    username: '',
    password: ''
  };

  login() {
    if (!this.model.username || !this.model.password) {
      console.log('Form is incomplete');
      return;
    }

    this.accountService.login(this.model).subscribe({
      next: _ => {
        this.router.navigate(['/', 'all-tasks']);
        this.toastr.success("Login Successful!");
      },
      error: error => this.toastr.error(error.error)

    });
  }
}
