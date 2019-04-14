import {UserType} from "../_enums/usertype";
import {Observable} from "rxjs";

import {SignUpResult} from "../_results/sign.up.result";
import {SignInResult} from "../_results/sign.in.result";

import {SignInViewModel} from "../_viewModels/sign.in.view.model";
import {SignUpViewModel} from "../_viewModels/sign.up.view.model";

import {User} from "../_entities/user";

export abstract class IUserService
{
	public abstract getUserTypes(): UserType[];
	
	public abstract signIn(viewModel: SignInViewModel): Observable<SignInResult>;
	
	public abstract signUp(viewModel: SignUpViewModel): Observable<SignUpResult>;
	
	public abstract logout() : void;
	
	public abstract get current(): User;
}
