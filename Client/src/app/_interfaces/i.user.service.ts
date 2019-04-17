import {UserType} from "../_enums/usertype";
import {Observable} from "rxjs";

import {SignInViewModel} from "../_viewModels/sign-in.view-model";
import {SignUpViewModel} from "../_viewModels/sign-up.view-model";
import {SignInResult} from "../_results/sign-in.result";
import {SignUpResult} from "../_results/sign-up.result";

export abstract class IUserService
{
	public abstract currentUser(): any;
	
	public abstract getUserTypes(): UserType[];
	
	public abstract signIn(viewModel: SignInViewModel): Observable<SignInResult>;
	
	public abstract signUp(viewModel: SignUpViewModel): Observable<SignUpResult>;
	
	public abstract logout(): void;
	
	public abstract get isUser(): boolean;
	
	public abstract get isAnonymous(): boolean;
}
