import {Component, ViewChildren} from '@angular/core';
import {ComponentBase} from "../../_base/component.base";
import {
	AbstractControl,
	FormArray,
	FormBuilder,
	FormControl,
	FormGroup,
	Validators
} from "@angular/forms";
import {forEach} from "@angular/router/src/utils/collection";
import {MatChipInputEvent} from "@angular/material";

@Component({
	           selector: 'app-new-test',
	           templateUrl: './new-test.component.html',
	           styleUrls: ['./new-test.component.scss']
           })
export class NewTestComponent extends ComponentBase
{
	private readonly _builder: FormBuilder;
	public readonly form: FormGroup;
	
	public readonly tags: string[];
	
	public constructor(builder: FormBuilder)
	{
		super();
		
		this.tags = new Array<string>();
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
		this.tags.push(event.value.trim());
		
		event.input.value = '';
	}
	
	public removeTag(tag: string): void
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
		
		this.questions.controls.forEach(q => {
			count = q.value['answers'].length;
		});
		
		return count;
	}
	
	public onSubmit(): void
	{
		const viewModel = Object.assign(this.form.value, {tags: this.tags});
		
		console.log(viewModel);
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
