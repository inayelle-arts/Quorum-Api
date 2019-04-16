import {ActivatedRouteSnapshot, CanDeactivate, RouterStateSnapshot, UrlTree} from "@angular/router";
import {ComponentBase} from "../_base/component.base";
import {Injectable} from "@angular/core";
import {MatDialog} from "@angular/material";
import {
	LeaveConfirmationDialogComponent,
	LeaveConfirmationDialogResult
} from "../_components/leave-confirmation-dialog/leave-confirmation-dialog.component";

@Injectable()
export class UnsavedDataGuard implements CanDeactivate<ComponentBase>
{
	public constructor(private readonly dialog: MatDialog)
	{
	}
	
	public async canDeactivate(
		component: ComponentBase,
		currentRoute: ActivatedRouteSnapshot,
		currentState: RouterStateSnapshot,
		nextState?: RouterStateSnapshot
	): Promise<boolean | UrlTree>
	{
		if (!component.hasUnsavedData)
		{
			return true;
		}
		
		const dialogRef = this.dialog.open(LeaveConfirmationDialogComponent);
		
		const result = (await dialogRef.afterClosed().toPromise()) as LeaveConfirmationDialogResult;
		
		return result.wantToLeave;
	}
	
}
