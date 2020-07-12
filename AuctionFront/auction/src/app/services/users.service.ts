import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
    providedIn: 'root',
})
export class UsersService {
    private baseUrl = 'https://localhost:44366/api/';

    constructor(private http: HttpClient) { }

    getUsers() {
        return this.http.get(this.baseUrl + 'users');
    }
}

