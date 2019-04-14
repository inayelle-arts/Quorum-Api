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
	MenuButtonComponent,
	TestPolygonComponent
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
	MatSelectModule,
	MatTreeModule,
	MatStepperModule,
	MatBadgeModule,
	MatCardModule,
	MatTooltipModule,
	MatCheckboxModule,
	MatSlideToggleModule, MatDividerModule, MatListModule, MatChipsModule
} from "@angular/material";

import {NotificationsService} from "./_services/notifications.service";
import {IUserService} from "./_interfaces/i.user.service";
import {FlexLayoutModule} from "@angular/flex-layout";
import {StopPropagationDirective} from "./_directives/stop-propagation.directive";
import {UserServiceMock} from "./_services/user.service.mock";
import {ITestService} from "./_interfaces/i.test.service";
import {TestServiceMock} from "./_services/test.service.mock";
import {UnsavedDataGuard} from "./_guards/unsaved-data.guard";
import {SignedUserOnlyGuard} from "./_guards/signed-user-only.guard";

@NgModule({
	          declarations: [
		          AppComponent,
		          HeaderComponent,
		          HomeComponent,
		          NewTestComponent,
		          SignInComponent,
		          SignUpComponent,
		          MenuButtonComponent,
		          TestPolygonComponent,
		          StopPropagationDirective
	          ],
	          imports: [
		          BrowserModule,
		          BrowserAnimationsModule,
		          AppRoutingModule,
		          HttpClientModule,
		          ReactiveFormsModule,
		          FlexLayoutModule,
		          MatButtonModule,
		          MatMenuModule,
		          MatIconModule,
		          MatTabsModule,
		          MatFormFieldModule,
		          MatInputModule,
		          MatBottomSheetModule,
		          MatSelectModule,
		          MatTreeModule,
		          MatStepperModule,
		          MatBadgeModule,
		          MatCardModule,
		          MatTooltipModule,
		          MatCheckboxModule,
		          MatSlideToggleModule,
		          MatDividerModule,
		          MatListModule,
		          MatChipsModule
	          ],
	          providers: [
		          {provide: IUserService, useClass: UserServiceMock},
		          {provide: ITestService, useClass: TestServiceMock},
		          NotificationsService,
		          UnsavedDataGuard,
		          SignedUserOnlyGuard
	          ],
	          entryComponents: [
		          SignInComponent,
		          SignUpComponent
	          ],
	          bootstrap: [AppComponent]
          })
export class AppModule
{
}
