import {Injectable} from "@angular/core";
import {MatSnackBar} from "@angular/material";

@Injectable()
export class NotificationsService
{
	private readonly _snackBar: MatSnackBar;
	
	public constructor(snackBar: MatSnackBar)
	{
		this._snackBar = snackBar;
	}
	
	public message(message: string): void
	{
		this._snackBar.open(message, 'Dismiss', {duration: 3000});
	}
}
