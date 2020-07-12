import { Component, OnInit, OnDestroy } from '@angular/core';
import { AuthService } from '../services/auth.service';
import { Router } from '@angular/router';
import { Observable, Subject, Subscription } from 'rxjs';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css'],
})
export class HeaderComponent implements OnInit, OnDestroy {
  collapsed = true;
  isLoggedIn = false;

  loggedInObservable: Subscription;

  constructor(private authService: AuthService, private router: Router) {}

  ngOnInit(): void {
    this.loggedInObservable = this.authService.loginSubject.subscribe(
      (response: boolean) => {
        this.isLoggedIn = response;
      }
    );
    let token = this.authService.getToken();
    if (token) this.isLoggedIn = true;
  }

  logoff() {
    this.authService.logoff();
    this.router.navigate(['/auth']);
    this.isLoggedIn = false;
  }

  ngOnDestroy(): void {
    this.loggedInObservable.unsubscribe();
  }
}
