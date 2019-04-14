import {Component, OnInit} from '@angular/core';
import {ComponentBase} from "../../_base/component.base";
import {FormBuilder, FormControl, FormGroup, Validators} from "@angular/forms";

import {UserType} from "../../_enums/usertype";
import {IUserService} from "../../_interfaces/i.user.service";
import {SignUpViewModel} from "../../_viewModels/sign.up.view.model";

@Component({
	           selector: 'app-sign-up',
	           templateUrl: './sign-up.component.html',
	           styleUrls: ['./sign-up.component.scss']
           })
export class SignUpComponent extends ComponentBase implements OnInit
{
	private readonly _userService: IUserService;
	private readonly _formBuilder: FormBuilder;
	private _userTypes: UserType[];
	
	public readonly form: FormGroup;
	
	public constructor(formBuilder: FormBuilder, userService: IUserService)
	{
		super();
		this._userService = userService;
		this._formBuilder = formBuilder;
		
		this.form = this._createForm();
	}
	
	public ngOnInit(): void
	{
		this._userTypes = this._userService.getUserTypes();
	}
	
	public get userTypes(): UserType[]
	{
		return this._userTypes;
	}
	
	public get userType(): FormControl
	{
		return this.form.controls['data']['controls']['userType'] as FormControl;
	}
	
	public get email(): FormControl
	{
		return this.form.controls['data']['controls']['email'] as FormControl;
	}
	
	public get password(): FormControl
	{
		return this.form.controls['data']['controls']['password'] as FormControl;
	}
	
	public get confirmPassword(): FormControl
	{
		return this.form.controls['confirmPassword'] as FormControl;
	}
	
	public onSubmit(): void
	{
		this._userService
		    .signUp(this.form.value['data'] as SignUpViewModel)
		    .subscribe(result => {
			    console.log(result);
		    });
	}
	
	private _createForm(): FormGroup
	{
		const b = this._formBuilder;
		
		const dataGroup = b.group(
			{
				userType: ['', Validators.required],
				email: ['', [Validators.required, Validators.email]],
				password: ['', [Validators.required, Validators.minLength(8)]]
			}
		);
		
		return b.group(
			{
				data: dataGroup,
				confirmPassword: ['', [Validators.required]]
			}
		);
	}
}
