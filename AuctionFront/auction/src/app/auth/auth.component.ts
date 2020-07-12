import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-auth',
  templateUrl: './auth.component.html',
})
export class AuthComponent implements OnInit {
  loginForm: FormGroup;

  isLogged = false;

  constructor(private authService: AuthService) {}

  ngOnInit(): void {
    this.loginForm = new FormGroup({
      userName: new FormControl(null, Validators.required),
      password: new FormControl(null, Validators.required),
    });

    this.authService.loginSubject.subscribe((response: boolean) => {
      this.isLogged = response;
    });
  }

  login() {
    this.isLogged = true;
    this.authService.login(
      this.loginForm.value.userName,
      this.loginForm.value.password
    );
  }
}
