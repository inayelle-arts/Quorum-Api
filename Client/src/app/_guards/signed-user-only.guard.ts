import {Injectable} from "@angular/core";
import {ActivatedRouteSnapshot, CanActivate, RouterStateSnapshot} from "@angular/router";
import {IUserService} from "../_interfaces/i.user.service";

@Injectable()
export class SignedUserOnlyGuard implements CanActivate
{
	private readonly _userService: IUserService;
	
	public constructor(userService: IUserService)
	{
		this._userService = userService;
	}
	
	public canActivate(
		route: ActivatedRouteSnapshot,
		state: RouterStateSnapshot
	): boolean
	{
		return this._userService.isUser;
	}
}
