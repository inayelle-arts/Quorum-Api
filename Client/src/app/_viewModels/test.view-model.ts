import {QuestionViewModel} from "./question.view-model";

export interface TestViewModel
{
	name: string;
	time: number;
	questions: QuestionViewModel[];
}
