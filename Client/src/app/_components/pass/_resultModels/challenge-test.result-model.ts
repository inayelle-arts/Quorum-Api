import {ChallengeQuestionResultModel} from "./challenge-question.result-model";

export interface ChallengeTestResultModel
{
	id: number;
	name: string;
	timeLimit: boolean;
	questions: ChallengeQuestionResultModel[];
}