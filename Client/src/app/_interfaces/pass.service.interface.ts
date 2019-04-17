import {Observable} from "rxjs";
import {ChallengeTestResultModel} from "../_components/pass/_resultModels/challenge-test.result-model";
import {ChallengedTestViewModel} from "../_components/pass/_viewModels/challenged-test.view-model";

export abstract class IPassService
{
	public abstract getById(id: number) : Observable<ChallengeTestResultModel>;
	
	public abstract postChallengeResult(viewModel: ChallengedTestViewModel) : Observable<number>
}