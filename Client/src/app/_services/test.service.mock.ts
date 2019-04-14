import {Injectable} from "@angular/core";
import {ITestService} from "../_interfaces/i.test.service";
import {Observable} from "rxjs";

import {CreateTestResult} from "../_results/create-test.result";
import {TestViewModel} from "../_viewModels/test.view-model";
import {NotImplementedException} from "../_exceptions/not.implemented.exception";

@Injectable()
export class TestServiceMock implements ITestService
{
	create(viewModel: TestViewModel): Observable<CreateTestResult>
	{
		throw new NotImplementedException();
	}
}
