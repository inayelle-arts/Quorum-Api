import {HttpClient} from "@angular/common/http";
import {Injectable} from "@angular/core";

@Injectable()
export abstract class HttpServiceBase
{
	private readonly _http: HttpClient;
	
	public constructor(http: HttpClient)
	{
		this._http = http;
	}
	
	protected get http(): HttpClient
	{
		return this._http;
	}
	
	protected toJson(object: any): string
	{
		return JSON.stringify(object);
	}
	
	protected fromJson<TResult>(json: string): TResult
	{
		return JSON.parse(json) as TResult;
	}
	
	protected combineUrl(...parts: any[]): string
	{
		return parts.join('/').padEnd(1);
	}
	
	
	
	// TODO:
	// protected get<TResult = any, TViewModel = any>(url: string, viewModel: TViewModel) : TResult
	// {
	//	
	// }
}