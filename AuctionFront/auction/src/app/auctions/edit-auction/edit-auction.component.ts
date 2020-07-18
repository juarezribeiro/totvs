import { Component, OnInit } from "@angular/core";
import { FormGroup, FormControl, Validators } from "@angular/forms";
import { ActivatedRoute, Params, Router } from "@angular/router";
import { AuctionsService } from "src/app/services/auctions.service";
import { UsersService } from "src/app/services/users.service";
import { formatDate } from "@angular/common";

@Component({
  selector: "app-edit-auction",
  templateUrl: "./edit-auction.component.html",
  styleUrls: ["./edit-auction.component.css"],
})
export class EditAuctionComponent implements OnInit {
  auctionId: number;
  auctionListId: number;
  conditions = ["new", "used"];
  users = [];
  auctionForm: FormGroup;
  formatDate = "yyyy-MM-dd";
  locale = "pt";
  isLoading = false;

  constructor(
    private route: ActivatedRoute,
    private auctionService: AuctionsService,
    private userService: UsersService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.auctionForm = new FormGroup({
      auctionName: new FormControl(null, Validators.required),
      initialValue: new FormControl(null, Validators.required),
      condition: new FormControl(null, Validators.required),
      auctionOwner: new FormControl(null, Validators.required),
      openingDate: new FormControl(null, Validators.required),
      closingDate: new FormControl(null, Validators.required),
    });

    this.route.params.subscribe((params: Params) => {
      this.auctionId = params["id"];
      this.isLoading = true;
      this.userService.getUsers().subscribe((response: any) => {
        this.users = response;

        this.auctionService
          .getAuction(this.auctionId)
          .subscribe((response: any) => {
            let conditionId = response.auctionList[0]
              ? response.auctionList[0].condition
              : 0;
            let userId = response.auctionList[0]
              ? response.auctionList[0].user.userID
              : "";
            this.auctionListId = response.auctionList[0].auctionListID;
            this.isLoading = false;

            this.auctionForm.setValue({
              auctionName: response.title,
              initialValue: response.initialValue,
              condition: this.conditions[conditionId],
              auctionOwner: userId,
              openingDate: formatDate(
                response.start,
                this.formatDate,
                this.locale
              ),
              closingDate: formatDate(
                response.end,
                this.formatDate,
                this.locale
              ),
            });
          });
      });
    });
  }

  get f() {
    return this.auctionForm.controls;
  }

  updateAuction() {
    let auctionObject = {
      Id: this.auctionId,
      Title: this.auctionForm.value.auctionName,
      InitialValue: this.auctionForm.value.initialValue,
      Start: this.auctionForm.value.openingDate,
      End: this.auctionForm.value.closingDate,
      Status: true,
      auctionList: [
        {
          auctionListID: this.auctionListId,
          userID: this.auctionForm.value.auctionOwner,
          condition: this.auctionForm.value.condition,
        },
      ],
    };

    this.auctionService
      .putAuction(this.auctionId, auctionObject)
      .subscribe((response: any) => {
        this.router.navigate(["/auctions"], {
          state: { sucessMessage: "Auction was edited!" },
        });
      });
  }
}
