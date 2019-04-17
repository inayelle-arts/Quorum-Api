import {Component, OnInit} from '@angular/core';
import {ResultService} from "../../_services/result.service";
import {ComponentBase} from "../../_base/component.base";
import {PassedTestResultModel} from "./_resultModels/passed-test.result-model";
import {ActivatedRoute} from "@angular/router";

@Component({
	selector: 'app-result',
	templateUrl: './result.component.html',
	styleUrls: ['./result.component.scss']
})
export class ResultComponent extends ComponentBase implements OnInit
{
	private readonly _resultService: ResultService;
	private readonly _route: ActivatedRoute;
	
	private _resultModel: PassedTestResultModel;
	private _isLoaded: boolean = false;
	
	public constructor(resultService: ResultService, route: ActivatedRoute)
	{
		super();
		this._resultService = resultService;
		this._route = route;
	}
	
	public get resultModel(): PassedTestResultModel
	{
		return this._resultModel;
	}
	
	public get loaded() :boolean
	{
		return this._isLoaded;
	}
	
	public ngOnInit()
	{
		const params = this._route.snapshot.paramMap;
		
		this._resultService.get(Number(params.get('id')))
			.subscribe(result =>
			{
				this._resultModel = result;
				this._isLoaded = true;
				
				console.log(result);
			});
	}
}
