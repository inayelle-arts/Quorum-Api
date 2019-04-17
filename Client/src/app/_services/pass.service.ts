import {IPassService} from "../_interfaces/pass.service.interface";
import {Observable} from "rxjs";
import {HttpServiceBase} from "../_base/http-service.base";
import {ChallengeTestResultModel} from "../_components/pass/_resultModels/challenge-test.result-model";
import {ChallengedTestViewModel} from "../_components/pass/_viewModels/challenged-test.view-model";

export class PassService extends HttpServiceBase implements IPassService
{
	private readonly url = '/api/pass';
	
	public getById(id: number): Observable<ChallengeTestResultModel>
	{
		const url = this.combineUrl(this.url, id);
		
		return this.http.get<ChallengeTestResultModel>(url);
	}
	
	public postChallengeResult(viewModel: ChallengedTestViewModel) : Observable<number>
	{
		return this.http.post<number>(this.url, viewModel);
	}
}