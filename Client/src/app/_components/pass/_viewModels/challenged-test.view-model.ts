import {ChallengedQuestionViewModel} from "./challenged-question.view-model";

export interface ChallengedTestViewModel
{
	sourceTestId: number;
	timeSpent: number;
	questions: ChallengedQuestionViewModel[];
}