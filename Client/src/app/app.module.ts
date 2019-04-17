import {NgModule} from '@angular/core';
import {BrowserModule} from '@angular/platform-browser';
import {AppRoutingModule} from './app-routing.module';
import {HttpClientModule} from "@angular/common/http";
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import {BrowserAnimationsModule} from "@angular/platform-browser/animations";

import
{
	AppComponent,
	HeaderComponent,
	HomeComponent,
	NewComponent,
	SignInComponent,
	SignUpComponent,
	MenuButtonComponent,
	TestPolygonComponent,
	LeaveConfirmationDialogComponent,
	ResultComponent
} from "./_components/components";

import {NotificationsService} from "./_services/notifications.service";
import {IUserService} from "./_interfaces/i.user.service";
import {FlexLayoutModule} from "@angular/flex-layout";
import {StopPropagationDirective} from "./_directives/stop-propagation.directive";
import {UserServiceMock} from "./_services/user.service.mock";
import {ITestService} from "./_interfaces/i.test.service";
import {TestServiceMock} from "./_services/test.service.mock";
import {UnsavedDataGuard} from "./_guards/unsaved-data.guard";
import {SignedUserOnlyGuard} from "./_guards/signed-user-only.guard";
import {MaterialModule} from "./_modules/material.module";
import {PassComponent} from './_components/pass/pass.component';
import {IPassService} from "./_interfaces/pass.service.interface";
import {PassService} from "./_services/pass.service";
import {ResultService} from "./_services/result.service";

@NgModule({
	declarations: [
		AppComponent,
		HeaderComponent,
		HomeComponent,
		NewComponent,
		SignInComponent,
		SignUpComponent,
		MenuButtonComponent,
		TestPolygonComponent,
		StopPropagationDirective,
		LeaveConfirmationDialogComponent,
		PassComponent,
		ResultComponent,
	],
	imports: [
		BrowserModule,
		BrowserAnimationsModule,
		AppRoutingModule,
		HttpClientModule,
		ReactiveFormsModule,
		FlexLayoutModule,
		MaterialModule,
		FormsModule
	],
	providers: [
		{provide: IUserService, useClass: UserServiceMock},
		{provide: ITestService, useClass: TestServiceMock},
		{provide: IPassService, useClass: PassService},
		ResultService,
		NotificationsService,
		UnsavedDataGuard,
		SignedUserOnlyGuard
	],
	entryComponents: [
		SignInComponent,
		SignUpComponent,
		LeaveConfirmationDialogComponent
	],
	bootstrap: [AppComponent]
})
export class AppModule
{
}
