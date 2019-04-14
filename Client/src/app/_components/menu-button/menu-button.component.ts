import {Component} from '@angular/core';
import {ComponentBase} from "../../_base/component.base";
import {MatBottomSheet} from "@angular/material";

import {SignUpComponent} from "../sign-up/sign-up.component";
import {SignInComponent} from "../sign-in/sign-in.component";
import {IUserService} from "../../_interfaces/i.user.service";

@Component({
	           selector: 'app-menu-button',
	           templateUrl: './menu-button.component.html',
	           styleUrls: ['./menu-button.component.scss']
           })
export class MenuButtonComponent extends ComponentBase
{
	public readonly _userService: IUserService;
	private readonly _bottomMenu: MatBottomSheet;
	
	constructor(bottomMenu: MatBottomSheet, userService: IUserService)
	{
		super();
		
		this._bottomMenu = bottomMenu;
		this._userService = userService;
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
	}
}
