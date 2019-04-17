import {TestViewModel} from "../_viewModels/test.view-model";
import {Observable} from "rxjs";
import {CreateTestResult} from "../_results/create-test.result";

export abstract class ITestService
{
	public abstract create(viewModel: TestViewModel): Observable<CreateTestResult>;
}
