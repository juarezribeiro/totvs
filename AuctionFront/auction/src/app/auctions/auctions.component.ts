import { Component, OnInit } from '@angular/core';
import { AuctionsService } from '../services/auctions.service';
import { Router } from '@angular/router';
import { DatePipe, formatDate } from '@angular/common';

@Component({
  selector: 'app-auctions',
  templateUrl: './auctions.component.html',
  styleUrls: ['./auctions.component.css'],
})
export class AuctionsComponent implements OnInit {
  auctions: any;
  routeState: any;
  sucessMessage: string;
  isLoading = false;

  conditions = ['new', 'used'];

  constructor(private auctionService: AuctionsService, private router: Router) {
    this.routeState = this.router.getCurrentNavigation();
    if (this.routeState.extras.state)
      this.sucessMessage = this.routeState.extras.state.sucessMessage;
  }

  ngOnInit(): void {
    this.getAuctions();
  }

  getAuctions() {
    this.isLoading = true;
    this.auctionService.getAuctions().subscribe((response) => {
      this.auctions = response;
      this.isLoading = false;
    });
  }

  deleteAuction(id: number) {
    if (confirm('Are you sure to delete?')) {
      this.auctionService.deleteAuction(id).subscribe((response) => {
        this.sucessMessage = 'Auction was deleted!';
        this.getAuctions();
      });
    }
  }

  dataFormat(data: string) {
    return formatDate(data, 'yyyy-MM-dd', 'pt');
  }
}
