import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AuctionsComponent } from './auctions/auctions.component';
import { HeaderComponent } from './header/header.component';
import { HomeComponent } from './home/home.component';
import { AuthComponent } from './auth/auth.component';

import { AuctionsService } from './services/auctions.service';
import { UsersService } from './services/users.service';
import { AuthService } from './services/auth.service';
import { AuthInterceptorService } from './auth/auth-interceptor.service';

import { NewAuctionComponent } from './auctions/new-auction/new-auction.component';
import { EditAuctionComponent } from './auctions/edit-auction/edit-auction.component';
import { LoadingSpinnerComponent } from './shared/loading-spinner/loading-spinner.component';

import { LOCALE_ID } from '@angular/core';
import { registerLocaleData } from '@angular/common';
import localePt from '@angular/common/locales/global/pt';

registerLocaleData(localePt, 'pt-BR');

@NgModule({
  declarations: [
    AppComponent,
    AuctionsComponent,
    HeaderComponent,
    HomeComponent,
    NewAuctionComponent,
    EditAuctionComponent,
    LoadingSpinnerComponent,
    AuthComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule,
    FormsModule,
  ],
  providers: [
    AuctionsService,
    UsersService,
    AuthService,
    { provide: LOCALE_ID, useValue: 'pt-BR' },
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthInterceptorService,
      multi: true,
    },
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
