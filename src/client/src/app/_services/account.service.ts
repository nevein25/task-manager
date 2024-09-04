import { HttpClient } from '@angular/common/http';
import { inject, Injectable, signal } from '@angular/core';
import { environment } from '../../environments/environment';
import { User } from '../_models/user';
import { UserLogin } from '../_models/user-login';
import { map } from 'rxjs';
import { UserRegister } from '../_models/user-register';

@Injectable({
  providedIn: 'root'
})
export class AccountService {

  private http = inject(HttpClient);
  currentUser = signal<User | null>(null); 
  baseUrl = environment.apiUrl;


  
  login(model: UserLogin) {
    return this.http.post<User>(this.baseUrl + 'auth/login', model).pipe(
      map(user => {
        if (user) {
          this.setCurrentUser(user);
        }
      })
    )
  }

  register(model: UserRegister) {
    return this.http.post<User>(this.baseUrl + 'auth/register', model).pipe(
      map(user => {
        //if (user)
        //this.setCurrentUser(user);

        return user;
      })
    )
  }

  setCurrentUser(user: User) {
    localStorage.setItem('user', JSON.stringify(user));
    this.currentUser.set(user);
  }

  logout() {
    localStorage.removeItem('user');
    this.currentUser.set(null);
  }

  setCurrentUserOnOpenApp() {
    const userString = localStorage.getItem('user');
    if (!userString) return;
    const user = JSON.parse(userString);
    this.setCurrentUser(user);
  }


}
