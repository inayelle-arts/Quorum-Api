import {Component} from '@angular/core';
import {ComponentBase} from "../../_base/component.base";
import {FormBuilder, FormControl, FormGroup, Validators} from "@angular/forms";
import {IUserService} from "../../_interfaces/i.user.service";
import {SignInViewModel} from "../../_viewModels/sign-in.view-model";

@Component({
	           selector: 'app-sign-in',
	           templateUrl: './sign-in.component.html',
	           styleUrls: ['./sign-in.component.scss']
           })
export class SignInComponent extends ComponentBase
{
	private readonly _userService: IUserService;
	public readonly form: FormGroup;
	
	public constructor(builder: FormBuilder, userService: IUserService)
	{
		super();
		this._userService = userService;
		
		this.form = SignInComponent._createForm(builder);
	}
	
	public get email(): FormControl
	{
		return this.form.controls['email'] as FormControl;
	}
	
	public get password(): FormControl
	{
		return this.form.controls['password'] as FormControl;
	}
	
	public onSubmit() : void
	{
		const viewModel = this.form.value as SignInViewModel;
		
		console.log(viewModel);
		
		//TODO: api sign in
//		this._userService.signIn(viewModel);
	}
	
	private static _createForm(builder: FormBuilder): FormGroup
	{
		return builder.group(
			{
				email: ['', [Validators.required, Validators.email]],
				password: ['', Validators.required]
			}
		);
	}
}
