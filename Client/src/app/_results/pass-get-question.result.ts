import {PassGetAnswerResult} from "./pass-get-answer.result";

export interface PassGetQuestionResult
{
	id: number;
	content: string;
	answers: PassGetAnswerResult[];
}