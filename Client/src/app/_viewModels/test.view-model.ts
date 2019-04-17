import {QuestionViewModel} from "./question.view-model";
import {TagViewModel} from "./tag.view-model";

export interface TestViewModel
{
	name: string;
	time: number;
	tags: TagViewModel[];
	questions: QuestionViewModel[];
}
