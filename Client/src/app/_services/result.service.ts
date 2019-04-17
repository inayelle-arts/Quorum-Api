import {HttpServiceBase} from "../_base/http-service.base";
import {Observable} from "rxjs";
import {PassedTestResultModel} from "../_components/result/_resultModels/passed-test.result-model";

export class ResultService extends HttpServiceBase
{
	private readonly url: string = '/api/result';
	
	public get(id: number): Observable<PassedTestResultModel>
	{
		const url = this.combineUrl(this.url, id);
		
		return this.http.get<PassedTestResultModel>(url);
	}
}