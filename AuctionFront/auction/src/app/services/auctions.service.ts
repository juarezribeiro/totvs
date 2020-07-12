import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class AuctionsService {
  private baseUrl = 'https://localhost:44366/api/';

  constructor(private http: HttpClient) {}

  getAuctions() {
    return this.http.get(this.baseUrl + 'auctions');
  }

  getAuction(id: number) {
    return this.http.get(this.baseUrl + 'auctions' + '/' + id);
  }

  postAuction(data: any) {
    return this.http.post(this.baseUrl + 'auctions', data);
  }

  putAuction(id: number, data: any) {
    return this.http.put(this.baseUrl + 'auctions/' + id, data);
  }

  deleteAuction(id: number) {
    return this.http.delete(this.baseUrl + 'auctions/' + id);
  }

  getLanguage() {
    return 'pt';
  }
}
