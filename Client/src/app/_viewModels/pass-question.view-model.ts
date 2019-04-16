import {PassAnswerViewModel} from "./pass-answer.view-model";

export interface PassQuestionViewModel
{
	id: number;
	content: string;
	answers: PassAnswerViewModel[];
}
