import {NgModule} from '@angular/core';
import {Routes, RouterModule} from '@angular/router';

import {HomeComponent} from "./_components/home/home.component";
import {NewComponent} from "./_components/new/new.component";
import {UnsavedDataGuard} from "./_guards/unsaved-data.guard";
import {SignedUserOnlyGuard} from "./_guards/signed-user-only.guard";
import {PassComponent} from "./_components/pass/pass.component";
import {TestPolygonComponent} from "./_components/test-polygon/test-polygon.component";
import {ResultComponent} from "./_components/result/result.component";

const routes: Routes =
	[
		{
			path: '',
			component: HomeComponent
		},
		{
			path: 'new',
			component: NewComponent,
			canDeactivate: [UnsavedDataGuard],
			canActivate: [SignedUserOnlyGuard]
		},
		{
			path: 'pass/:id',
			component: PassComponent,
			canDeactivate: [UnsavedDataGuard],
			canActivate: [SignedUserOnlyGuard]
		},
		{
			path: 'result/:id',
			component: ResultComponent,
			canActivate: [SignedUserOnlyGuard]
		},
		{
			path: 'polygon',
			component: TestPolygonComponent
		}
	];


@NgModule({
	imports: [RouterModule.forRoot(routes)],
	exports: [RouterModule]
})
export class AppRoutingModule {}
