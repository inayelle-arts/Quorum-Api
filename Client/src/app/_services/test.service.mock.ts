import {Injectable} from "@angular/core";
import {ITestService} from "../_interfaces/i.test.service";
import {Observable, of} from "rxjs";

import {CreateTestResult} from "../_results/create-test.result";
import {TestViewModel} from "../_viewModels/test.view-model";
import {NotImplementedException} from "../_exceptions/not.implemented.exception";
import {PassTestViewModel} from "../_viewModels/pass-test.view-model";

@Injectable()
export class TestServiceMock implements ITestService
{
	create(viewModel: TestViewModel): Observable<CreateTestResult>
	{
		throw new NotImplementedException();
	}
	
	challenge(id: number): Observable<PassTestViewModel>
	{
		const test: PassTestViewModel =
			{
				id: 1,
				name: "Test name",
				time: 10,
				questions:
					[
						{
							id: 1,
							content: 'What color does sky have?',
							answers: [
								{
									id: 1,
									content: 'blue',
									isCorrect: true
								},
								{
									id: 2,
									content: 'yellow',
									isCorrect: false
								}
							]
						},
						{
							id: 2,
							content: 'What color does cat have?',
							answers: [
								{
									id: 3,
									content: 'blue',
									isCorrect: false
								},
								{
									id: 4,
									content: 'yellow',
									isCorrect: false
								},
								{
									id: 4,
									content: 'brown',
									isCorrect: true
								}
							]
						}
					]
			};
		
		return of(test);
	}
}
