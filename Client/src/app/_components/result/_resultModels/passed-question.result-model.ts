import {PassedAnswerResultModel} from "./passed-answer.result-model";

export interface PassedQuestionResultModel
{
	content: string;
	maximumScore: number;
	userScore: number;
	answers: PassedAnswerResultModel[];
}