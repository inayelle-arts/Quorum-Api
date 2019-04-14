import {Directive, HostListener} from "@angular/core";

@Directive({selector: '[click-stop-propagation]'})
export class StopPropagationDirective
{
	@HostListener('click', ['$event'])
	public onClick(event: Event): boolean
	{
		event.preventDefault();
		
		return false;
	}
}
