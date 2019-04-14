import {Component} from '@angular/core';
import CONFIGURATION from "../../_configurations/app.config";
import {ComponentBase} from "../../_base/component.base";

@Component({
	selector: 'app-header',
	templateUrl: './header.component.html',
	styleUrls: ['./header.component.scss']
})
export class HeaderComponent extends ComponentBase
{
	public readonly githubLink: string = CONFIGURATION.githubLink;
}
