import {PassedQuestionResultModel} from "./passed-question.result-model";

export interface PassedTestResultModel
{
	id: number;
	name: string;
	maximumScore: number;
	userScore: number;
	questions: PassedQuestionResultModel[];
}