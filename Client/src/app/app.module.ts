import {NgModule} from '@angular/core';
import {BrowserModule} from '@angular/platform-browser';
import {AppRoutingModule} from './app-routing.module';
import {HttpClientModule} from "@angular/common/http";
import {ReactiveFormsModule} from "@angular/forms";
import {BrowserAnimationsModule} from "@angular/platform-browser/animations";

import
{
	AppComponent,
	HeaderComponent,
	HomeComponent,
	NewTestComponent,
	SignInComponent,
	SignUpComponent,
	MenuButtonComponent
} from "./_components/components";

import
{
	MatButtonModule,
	MatIconModule,
	MatMenuModule,
	MatTabsModule,
	MatFormFieldModule,
	MatInputModule,
	MatBottomSheetModule,
	MatSelectModule
} from "@angular/material";

import {NotificationsService} from "./_services/notifications.service";
import {IUserService} from "./_interfaces/i.user.service";
import {UserServiceMock} from "./_services/user.service.mock.service";

@NgModule({
	declarations: [
		AppComponent,
		HeaderComponent,
		HomeComponent,
		NewTestComponent,
		SignInComponent,
		SignUpComponent,
		MenuButtonComponent,
	],
	imports: [
		BrowserModule,
		BrowserAnimationsModule,
		AppRoutingModule,
		HttpClientModule,
		ReactiveFormsModule,
		MatButtonModule,
		MatMenuModule,
		MatIconModule,
		MatTabsModule,
		MatFormFieldModule,
		MatInputModule,
		MatBottomSheetModule,
		MatSelectModule
	],
	providers: [
		{provide: IUserService, useClass: UserServiceMock},
		NotificationsService
	],
	entryComponents: [
		SignUpComponent,
		SignInComponent
	],
	bootstrap: [AppComponent]
})
export class AppModule {}
