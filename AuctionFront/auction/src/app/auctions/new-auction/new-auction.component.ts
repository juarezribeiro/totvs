import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { AuctionsService } from 'src/app/services/auctions.service';
import { UsersService } from 'src/app/services/users.service';

@Component({
  selector: 'app-new-auction',
  templateUrl: './new-auction.component.html',
  styleUrls: ['./new-auction.component.css']
})
export class NewAuctionComponent implements OnInit {
  conditions = ['new', 'used'];
  users = [];
  auctionForm: FormGroup;
  isLoading = false;

  constructor(private route: ActivatedRoute, private auctionService: AuctionsService,
    private userService: UsersService, private router: Router) { }

  ngOnInit(): void {
    this.auctionForm = new FormGroup({
      'auctionName': new FormControl(null, Validators.required),
      'initialValue': new FormControl(null, Validators.required),
      'condition': new FormControl(null, Validators.required),
      'auctionOwner': new FormControl(null, Validators.required),
      'openingDate': new FormControl(null, Validators.required),
      'closingDate': new FormControl(null, Validators.required),
    });

    this.route.params.subscribe((params: Params) => {
      this.isLoading = true;
      this.userService.getUsers().subscribe((response: any) => {
        this.isLoading = false;
        this.users = response;
      });
    });
  }

  get f() { return this.auctionForm.controls; }

  newAuction() {
    let auctionObject = {
      "Title": this.auctionForm.value.auctionName,
      "InitialValue": this.auctionForm.value.initialValue,
      "Start": this.auctionForm.value.openingDate,
      "End": this.auctionForm.value.closingDate,
      "Status": true,
      "auctionList": [
        {
          "userID": this.auctionForm.value.auctionOwner,
          "condition": this.auctionForm.value.condition
        }
      ]
    }

    this.auctionService.postAuction(auctionObject).subscribe((response: any) => {
      this.router.navigate(["/auctions"], { state: { sucessMessage: "Auction was created!" } })
    });
  }

  deleteAuction(id: number) {

  }

}
