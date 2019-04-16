import {Component, Inject, OnDestroy, OnInit} from '@angular/core';
import {ComponentBase} from "../../_base/component.base";
import {MAT_DIALOG_DATA, MatDialogRef} from "@angular/material";

@Component({
	           selector: 'app-leave-confirmation-dialog',
	           templateUrl: './leave-confirmation-dialog.component.html',
	           styleUrls: ['./leave-confirmation-dialog.component.scss']
           })
export class LeaveConfirmationDialogComponent extends ComponentBase implements OnDestroy
{
	private readonly _dialogResult: LeaveConfirmationDialogResult;
	
	constructor(private readonly dialogRef: MatDialogRef<LeaveConfirmationDialogComponent>)
	{
		super();
		this._dialogResult = {wantToLeave: false};
	}
	
	public onLeaveClick(): void
	{
		this._dialogResult.wantToLeave = true;
		this._close();
	}
	
	public onStayClick(): void
	{
		this._dialogResult.wantToLeave = false;
		this._close();
	}
	
	public ngOnDestroy(): void
	{
		this._close();
	}
	
	private _close(): void
	{
		this.dialogRef.close(this._dialogResult);
	}
}

export interface LeaveConfirmationDialogResult
{
	wantToLeave: boolean;
}
