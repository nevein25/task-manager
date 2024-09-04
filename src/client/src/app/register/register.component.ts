import { NgIf } from '@angular/common';
import { Component, inject } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { RouterLink, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { UserRegister } from '../_models/user-register';
import { AccountService } from '../_services/account.service';

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [FormsModule, RouterLink, NgIf],
  templateUrl: './register.component.html',
  styleUrl: './register.component.css'
})
export class RegisterComponent {
  private accountService = inject(AccountService);
  private toastr = inject(ToastrService);
  router = inject(Router);


  model: UserRegister = {
    email: '',
    username: '',
    password: '',
  }

  register() {
    this.accountService.register(this.model).subscribe({
      next: response => {
        console.log(response);
        this.toastr.success("Registration Successful!");
        this.router.navigate(['/', 'login']);


      },
      error: error => {
        console.log(error);
        if (error.error.errors) {
          const validationErrors = error.error.errors;

          for (let key in validationErrors) {
            if (validationErrors.hasOwnProperty(key)) {
              validationErrors[key].forEach((errorMessage: string) => {
                this.toastr.error(errorMessage);
              });
            }
          }
        } 
        else {
          this.toastr.error(error.error);
        }
      }
    });
  }

  validatePassword(control: any): { [key: string]: boolean } | null {
    const value = control.value;
    if (!value) {
      return null;
    }

    const hasUpperCase = /[A-Z]+/.test(value);
    const hasLowerCase = /[a-z]+/.test(value);
    const hasNumeric = /[0-9]+/.test(value);
    const validLength = value.length >= 6 && value.length <= 12;

    const passwordValid = hasUpperCase && hasLowerCase && hasNumeric && validLength;

    return !passwordValid ? { passwordStrength: true } : null;
  }


}
