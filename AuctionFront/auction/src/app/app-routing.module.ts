import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { AuctionsComponent } from './auctions/auctions.component';
import { HomeComponent } from './home/home.component';
import { EditAuctionComponent } from './auctions/edit-auction/edit-auction.component';
import { NewAuctionComponent } from './auctions/new-auction/new-auction.component';
import { AuthComponent } from './auth/auth.component';
import { AuthGuard } from './auth/auth-guard';

const routes: Routes = [
  {
    path: '',
    component: HomeComponent,
    pathMatch: 'full',
    canActivate: [AuthGuard],
  },
  { path: 'auctions', component: AuctionsComponent, canActivate: [AuthGuard] },
  {
    path: 'auctions/edit/:id',
    component: EditAuctionComponent,
    canActivate: [AuthGuard],
  },
  {
    path: 'newauction',
    component: NewAuctionComponent,
    canActivate: [AuthGuard],
  },
  { path: 'auth', component: AuthComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes, { useHash: true })],
  exports: [RouterModule],
})
export class AppRoutingModule {}
