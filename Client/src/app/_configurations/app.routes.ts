import {Routes} from "@angular/router";

import
{
	HomeComponent,
	NewTestComponent
} from "../_components/components";

const ROUTES: Routes =
	[
		{
			path: '',
			component: HomeComponent
		},
		{
			path: 'new',
			component: NewTestComponent
		}
	];

export default ROUTES;
