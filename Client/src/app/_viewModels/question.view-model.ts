import {AnswerViewModel} from "./answer.view-model";

export interface QuestionViewModel
{
	content: string;
	answers: AnswerViewModel[];
}
