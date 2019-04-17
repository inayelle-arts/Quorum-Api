import {Injectable} from "@angular/core";
import {ITestService} from "../_interfaces/i.test.service";
import {Observable} from "rxjs";

import {CreateTestResult} from "../_results/create-test.result";
import {TestViewModel} from "../_viewModels/test.view-model";
import {HttpClient} from "@angular/common/http";
import API_URLS from "../_configurations/app.api.urls";

@Injectable()
export class TestServiceMock implements ITestService
{
	private readonly url = API_URLS.test;
	
	public constructor(private readonly http: HttpClient)
	{
	}
	
	public create(viewModel: TestViewModel): Observable<CreateTestResult>
	{
		return this.http.post<CreateTestResult>(this.url, viewModel);
	}
}
