import {Component, OnInit} from '@angular/core';
import {ComponentBase} from '../../_base/component.base';
import {ITestService} from '../../_interfaces/i.test.service';
import {FormBuilder, FormGroup} from '@angular/forms';
import {PassTestViewModel} from '../../_viewModels/pass-test.view-model';
import {ActivatedRoute} from '@angular/router';
import {PassQuestionViewModel} from '../../_viewModels/pass-question.view-model';
import {PassAnswerViewModel} from '../../_viewModels/pass-answer.view-model';

@Component({
	           selector: 'app-pass',
	           templateUrl: './pass.component.html',
	           styleUrls: ['./pass.component.scss']
           })
export class PassComponent extends ComponentBase implements OnInit
{
	private readonly _builderService: FormBuilder;
	private readonly _route: ActivatedRoute;
	private readonly _testService: ITestService;
	
	private _viewModel: PassTestViewModel;
	private _loaded: boolean;
	
	public form: FormGroup;
	
	public constructor(
		builderService: FormBuilder,
		route: ActivatedRoute,
		testService: ITestService
	)
	{
		super();
		
		this._builderService = builderService;
		this._route = route;
		this._testService = testService;
		this._loaded = false;
	}
	
	public ngOnInit(): void
	{
		this._testService
		    .challenge(this._route.data['id'])
		    .subscribe(result => this._onTestLoaded(result));
	}
	
	public onSubmit(): void
	{
		console.log(this.form.value);
	}
	
	public get loaded(): boolean
	{
		return this._loaded;
	}
	
	public get hasUnsavedData(): boolean
	{
		return true;
	}
	
	public get viewModel(): PassTestViewModel
	{
		return this._viewModel;
	}
	
	private _onTestLoaded(viewModel: PassTestViewModel): void
	{
		this._viewModel = viewModel;
		
		this.form = this._createFormGroup(viewModel);
		
		this._loaded = true;
	}
	
	private _createFormGroup(test: PassTestViewModel): FormGroup
	{
		const questions = this._builderService.array([]);
		
		test.questions.forEach(q =>
		                       {
			                       questions.push(this._createQuestionGroup(q));
		                       });
		
		return this._builderService
		           .group(
			           {
				           id: test.id,
				           time: 0,
				           questions: questions
			           });
	}
	
	private _createQuestionGroup(q: PassQuestionViewModel): FormGroup
	{
		const answers = this._builderService.array([]);
		
		q.answers.forEach(a =>
		                  {
			                  answers.push(this._createAnswerGroup(a));
		                  });
		
		return this._builderService.group(
			{
				id: q.id,
				answers: answers
			}
		);
	}
	
	private _createAnswerGroup(a: PassAnswerViewModel): FormGroup
	{
		return this._builderService.group(
			{
				id: a.id,
				isCorrect: false
			}
		);
	}
}
