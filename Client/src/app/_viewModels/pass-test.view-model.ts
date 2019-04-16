import {PassQuestionViewModel} from "./pass-question.view-model";

export interface PassTestViewModel
{
	id: number;
	name: string;
	time: number;
	questions: PassQuestionViewModel[];
}
