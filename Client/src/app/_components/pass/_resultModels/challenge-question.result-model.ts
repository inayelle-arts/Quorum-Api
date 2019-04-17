import {ChallengeAnswerResultModel} from "./challenge-answer.result-model";

export interface ChallengeQuestionResultModel
{
	id: number;
	content: string;
	answers: ChallengeAnswerResultModel[];
}