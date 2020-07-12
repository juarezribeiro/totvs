import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private baseUrl = 'https://localhost:44366/api/';

  loginSubject = new Subject();

  constructor(private http: HttpClient, private router: Router) {}

  login(userName: string, password: string) {
    return this.http
      .post(this.baseUrl + 'users/login', { userName, password })
      .subscribe(
        (response) => {
          localStorage.setItem('userData', JSON.stringify(response));
          this.loginSubject.next(true);
          this.router.navigate(['']);
        },
        (error) => {
          this.loginSubject.next(false);
          alert('Invalid user or password.');
        }
      );
  }

  getToken() {
    let userData = JSON.parse(localStorage.getItem('userData'));
    return userData ? userData.token : null;
  }

  logoff() {
    localStorage.clear();
    this.loginSubject.next(false);
  }
}
