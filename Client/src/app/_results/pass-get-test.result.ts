import {PassGetQuestionResult} from "./pass-get-question.result";

export interface PassGetTestResult
{
	id: number;
	name: string;
	time: number;
	tags: any[];
	questions: PassGetQuestionResult[];
}