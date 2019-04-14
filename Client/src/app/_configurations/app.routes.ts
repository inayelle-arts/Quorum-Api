import {Routes} from "@angular/router";

import
{
	HomeComponent,
	NewTestComponent,
	TestPolygonComponent
} from "../_components/components";

import {UnsavedDataGuard} from "../_guards/unsaved-data.guard";
import {SignedUserOnlyGuard} from "../_guards/signed-user-only.guard";

export const ROUTES: Routes =
	[
		{
			path: '',
			component: HomeComponent
		},
		{
			path: 'new',
			component: NewTestComponent,
			canDeactivate: [UnsavedDataGuard],
			canActivate: [SignedUserOnlyGuard]
		},
		{
			path: 'polygon',
			component: TestPolygonComponent
		}
	];

export default ROUTES;
