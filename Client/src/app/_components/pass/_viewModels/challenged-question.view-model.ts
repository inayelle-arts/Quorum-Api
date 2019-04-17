import {ChallengedAnswerViewModel} from "./challenged-answer.view-model";

export interface ChallengedQuestionViewModel
{
	sourceQuestionId: number;
	answers: ChallengedAnswerViewModel[];
}