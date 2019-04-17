import {Component} from '@angular/core';
import {ComponentBase} from "../../_base/component.base";
import {
	FormArray,
	FormBuilder,
	FormControl,
	FormGroup,
	Validators
} from "@angular/forms";
import {MatChipInputEvent} from "@angular/material";
import {ITestService} from "../../_interfaces/i.test.service";
import {TestViewModel} from "../../_viewModels/test.view-model";
import {TagViewModel} from "../../_viewModels/tag.view-model";
import {NotificationsService} from "../../_services/notifications.service";

@Component({
	selector: 'app-new',
	templateUrl: './new.component.html',
	styleUrls: ['./new.component.scss']
})
export class NewComponent extends ComponentBase
{
	private readonly _testService: ITestService;
	private readonly _notifyService: NotificationsService;
	
	private readonly _builder: FormBuilder;
	
	private _isSent: boolean = false;
	
	public readonly form: FormGroup;
	
	public readonly tags: TagViewModel[] = new Array<TagViewModel>();
	
	public constructor(builder: FormBuilder, testService: ITestService, notifyService: NotificationsService)
	{
		super();
		
		this._testService = testService;
		this._notifyService = notifyService;
		
		this.tags = new Array<TagViewModel>();
		
		this._builder = builder;
		this.form = this._createForm();
		
		this.addQuestion();
	}
	
	public get hasUnsavedData(): boolean
	{
		return this.form.touched;
	}
	
	public get name(): FormControl
	{
		return this.form.controls['name'] as FormControl;
	}
	
	public get time(): FormControl
	{
		return this.form.controls['time'] as FormControl;
	}
	
	public addTag(event: MatChipInputEvent): void
	{
		this.tags.push(
			{
				content: event.value.trim()
			});
		
		event.input.value = '';
	}
	
	public removeTag(tag: TagViewModel): void
	{
		const index = this.tags.indexOf(tag);
		
		if (index >= 0)
		{
			this.tags.splice(index, 1);
		}
	}
	
	public get questions(): FormArray
	{
		return this.form.controls['questions'] as FormArray;
	}
	
	public answersAt(questionIndex: number): FormArray
	{
		return this.questions.get('' + questionIndex).get('answers') as FormArray;
	}
	
	public addQuestion(): void
	{
		const question = this._builder.group(
			{
				content: ['', Validators.required],
				answers: this._builder.array(
					[
						this._builder.group(
							{
								content: ['', Validators.required],
								isCorrect: [false]
							}
						),
						this._builder.group(
							{
								content: ['', Validators.required],
								isCorrect: [false]
							}
						)
					]
				)
			}
		);
		
		this.questions.push(question);
	}
	
	public addAnswer(questionId: number): void
	{
		const answer = this._builder.group(
			{
				content: ['', Validators.required],
				isCorrect: [false, Validators.required]
			}
		);
		
		this.answersAt(questionId).push(answer);
	}
	
	public get totalAnswersCount(): number
	{
		let count: number = 0;
		
		this.questions.controls.forEach(q =>
		{
			count += q.value['answers'].length;
		});
		
		return count;
	}
	
	public get isSent() : boolean
	{
		return this._isSent;
	}
	
	public onSubmit(): void
	{
		this._isSent = true;
		
		const viewModel = Object.assign(this.form.value, {tags: this.tags}) as TestViewModel;
		
		this._notifyService.message('Creating your test...');
		
		this._testService.create(viewModel)
			.subscribe(result =>
			{
				this._notifyService.message('Success!');
				
				//TODO: redirect to test overview
			});
	}
	
	public removeQuestion(questionId: number): void
	{
		if (this.questions.length == 1)
		{
			alert('At least one question should be provided');
			return;
		}
		
		this.questions.removeAt(questionId);
	}
	
	public get submitTooltip(): string
	{
		if (this.form.valid)
		{
			return '';
		}
		
		return 'Your test has uncompleted fields...'
	}
	
	public removeAnswer(questionIndex: number, answerIndex: number): void
	{
		this.answersAt(questionIndex).removeAt(answerIndex);
	}
	
	private _createForm(): FormGroup
	{
		return this._builder.group(
			{
				name: ['', [Validators.required, Validators.minLength(5)]],
				time: ['', [Validators.required, Validators.min(1)]],
				tags: [''],
				questions: this._builder.array([])
			}
		);
	}
}
