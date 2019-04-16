import {TestViewModel} from "../_viewModels/test.view-model";
import {Observable} from "rxjs";
import {CreateTestResult} from "../_results/create-test.result";
import {PassTestViewModel} from "../_viewModels/pass-test.view-model";

export abstract class ITestService
{
	public abstract create(viewModel: TestViewModel): Observable<CreateTestResult>;
	
	public abstract challenge(id: number) : Observable<PassTestViewModel>;
}
