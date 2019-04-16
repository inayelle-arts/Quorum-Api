import {Component} from '@angular/core';
import {ComponentBase} from "../../_base/component.base";
import {MatBottomSheet, MatSnackBar} from "@angular/material";

import {SignUpComponent} from "../sign-up/sign-up.component";
import {SignInComponent} from "../sign-in/sign-in.component";
import {IUserService} from "../../_interfaces/i.user.service";
import {NotificationsService} from "../../_services/notifications.service";

@Component({
	           selector: 'app-menu-button',
	           templateUrl: './menu-button.component.html',
	           styleUrls: ['./menu-button.component.scss']
           })
export class MenuButtonComponent extends ComponentBase
{
	private readonly _bottomMenu: MatBottomSheet;
	private readonly _notificationService: NotificationsService;
	
	public readonly _userService: IUserService;
	
	public constructor(
		bottomMenu: MatBottomSheet,
		userService: IUserService,
		notificationService: NotificationsService
	)
	{
		super();
		
		this._bottomMenu = bottomMenu;
		this._userService = userService;
		this._notificationService = notificationService;
	}
	
	public onSignInClick(): void
	{
		this._bottomMenu.open(SignInComponent);
	}
	
	public onSignUpClick(): void
	{
		this._bottomMenu.open(SignUpComponent);
	}
	
	public onLogoutClick(): void
	{
		this._userService.logout();
		this._notificationService.message('See you soon :)');
	}
}
