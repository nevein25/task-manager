import { Component, inject } from '@angular/core';
import { Router, RouterLink } from '@angular/router';
import { AccountService } from '../_services/account.service';

@Component({
  selector: 'app-nav',
  standalone: true,
  imports: [RouterLink],
  templateUrl: './nav.component.html',
  styleUrl: './nav.component.css'
})
export class NavComponent {
  
  accountService = inject(AccountService);
  router = inject(Router);


  ngOnInit(): void {
    this.accountService.setCurrentUserOnOpenApp();
  }

  logout() {
    this.accountService.logout();
    this.router.navigate(['/', 'home']);
  }
}
