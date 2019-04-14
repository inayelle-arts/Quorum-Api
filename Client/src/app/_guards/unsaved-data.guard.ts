import {ActivatedRouteSnapshot, CanDeactivate, RouterStateSnapshot, UrlTree} from "@angular/router";
import {ComponentBase} from "../_base/component.base";
import {Observable} from "rxjs";
import {Injectable} from "@angular/core";

@Injectable()
export class UnsavedDataGuard implements CanDeactivate<ComponentBase>
{
	canDeactivate(component: ComponentBase,
	              currentRoute: ActivatedRouteSnapshot,
	              currentState: RouterStateSnapshot,
	              nextState?: RouterStateSnapshot
	): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree
	{
		if (component.hasUnsavedData)
		{
			return confirm('Are you sure to leave unsaved progress?');
		}
		
		return true;
	}
	
}
