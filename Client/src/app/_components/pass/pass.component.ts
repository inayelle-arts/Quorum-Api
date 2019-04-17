import {Component, OnInit} from '@angular/core';
import {ComponentBase} from '../../_base/component.base';
import {FormBuilder, FormGroup} from '@angular/forms';
import {ActivatedRoute, Router} from '@angular/router';
import {IPassService} from "../../_interfaces/pass.service.interface";
import {ChallengeTestResultModel} from "./_resultModels/challenge-test.result-model";
import {ChallengeQuestionResultModel} from "./_resultModels/challenge-question.result-model";
import {ChallengeAnswerResultModel} from "./_resultModels/challenge-answer.result-model";
import {NotificationsService} from "../../_services/notifications.service";
import {ChallengedTestViewModel} from "./_viewModels/challenged-test.view-model";

@Component({
	selector: 'app-pass',
	templateUrl: './pass.component.html',
	styleUrls: ['./pass.component.scss']
})
export class PassComponent extends ComponentBase implements OnInit
{
	private readonly _passService: IPassService;
	private readonly _notifyService: NotificationsService;
	
	private readonly _builderService: FormBuilder;
	private readonly _route: ActivatedRoute;
	private readonly _router: Router;
	
	
	private _viewModel: ChallengeTestResultModel;
	private _loaded: boolean = false;
	private _isSent: boolean = false;
	
	public form: FormGroup;
	
	public constructor(
		passService: IPassService,
		notifyService: NotificationsService,
		builderService: FormBuilder,
		route: ActivatedRoute,
		router: Router
	)
	{
		super();
		
		this._passService = passService;
		this._notifyService = notifyService;
		this._builderService = builderService;
		this._route = route;
		this._router = router;
	}
	
	public ngOnInit(): void
	{
		const params = this._route.snapshot.paramMap;
		
		this._passService
			.getById(Number(params.get('id')))
			.subscribe(result => this._onTestLoaded(result));
	}
	
	public onSubmit(): void
	{
		this._isSent = true;
		const viewModel = this.form.value as ChallengedTestViewModel;
		
		viewModel.timeSpent = 0;
		
		this._notifyService.message('Posting your results...');
		
		this._passService.postChallengeResult(viewModel)
			.subscribe(result =>
			{
				this._notifyService.message(`Success!`);
				this._router.navigate([`/result/${result}`]);
			});
	}
	
	public get loaded(): boolean
	{
		return this._loaded;
	}
	
	public get isSent(): boolean
	{
		return this._isSent;
	}
	
	public get hasUnsavedData(): boolean
	{
		return !this.isSent;
	}
	
	public get viewModel(): ChallengeTestResultModel
	{
		return this._viewModel;
	}
	
	private _onTestLoaded(viewModel: ChallengeTestResultModel): void
	{
		this._viewModel = viewModel;
		
		this.form = this._createFormGroup(viewModel);
		
		this._loaded = true;
	}
	
	private _createFormGroup(test: ChallengeTestResultModel): FormGroup
	{
		const questions = this._builderService.array([]);
		
		test.questions.forEach(q =>
		{
			questions.push(this._createQuestionGroup(q));
		});
		
		return this._builderService
			.group(
				{
					sourceTestId: test.id,
					timeSpent: 0,
					questions: questions
				});
	}
	
	private _createQuestionGroup(q: ChallengeQuestionResultModel): FormGroup
	{
		const answers = this._builderService.array([]);
		
		q.answers.forEach(a =>
		{
			answers.push(this._createAnswerGroup(a));
		});
		
		return this._builderService.group(
			{
				sourceQuestionId: q.id,
				answers: answers
			}
		);
	}
	
	private _createAnswerGroup(a: ChallengeAnswerResultModel): FormGroup
	{
		return this._builderService.group(
			{
				sourceAnswerId: a.id,
				isCorrect: false
			}
		);
	}
}
