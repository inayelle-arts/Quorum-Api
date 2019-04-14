import {Injectable} from "@angular/core";
import {ActivatedRouteSnapshot, CanActivate, RouterStateSnapshot, UrlTree} from "@angular/router";
import {Observable} from "rxjs";
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
	): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree
	{
		return this._userService.current !== null;
	}
}
