import {UserType} from "../_enums/usertype";
import {IUserService} from "../_interfaces/i.user.service";
import {Observable} from "rxjs";
import {HttpClient} from "@angular/common/http";
import API_URLS from "../_configurations/app.api.urls";
import {NotImplementedException} from "../_exceptions/not.implemented.exception";

import {Injectable} from "@angular/core";
import {SignUpViewModel} from "../_viewModels/sign-up.view-model";
import {SignInViewModel} from "../_viewModels/sign-in.view-model";
import {SignUpResult} from "../_results/sign-up.result";
import {SignInResult} from "../_results/sign-in.result";

@Injectable()
export class UserServiceMock implements IUserService
{
	private readonly url: string = API_URLS.user;
	
	private _currentUser = {email: 'inayelle.arts@gmail.com'};
	
	constructor(private readonly http: HttpClient)
	{
		
	}
	
	public getUserTypes(): UserType[]
	{
		return [{value: 0, label: 'Student'}, {value: 1, label: 'Tutor'}];
	}
	
	public signUp(viewModel: SignUpViewModel): Observable<SignUpResult>
	{
		throw new NotImplementedException();
	}
	
	public signIn(viewModel: SignInViewModel): Observable<SignInResult>
	{
		throw new NotImplementedException();
	}
	
	public logout(): void
	{
		this._currentUser = null;
	}
	
	public get currentUser(): any
	{
		return this._currentUser;
	}
	
	public get isUser(): boolean
	{
		return this._currentUser != null;
	}
	
	public get isAnonymous(): boolean
	{
		return !this.isUser;
	}
}
