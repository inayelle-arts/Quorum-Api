import {NgModule} from '@angular/core';
import
{
	MatBadgeModule,
	MatBottomSheetModule,
	MatButtonModule, MatButtonToggleModule,
	MatCardModule,
	MatCheckboxModule,
	MatChipsModule,
	MatDialogModule,
	MatDividerModule,
	MatFormFieldModule,
	MatIconModule,
	MatInputModule,
	MatListModule,
	MatMenuModule,
	MatProgressSpinnerModule,
	MatSelectModule,
	MatSlideToggleModule,
	MatSnackBarModule,
	MatStepperModule,
	MatTabsModule,
	MatTooltipModule,
	MatTreeModule
} from '@angular/material';

const modules = [
	MatButtonModule,
	MatMenuModule,
	MatIconModule,
	MatTabsModule,
	MatFormFieldModule,
	MatInputModule,
	MatBottomSheetModule,
	MatSelectModule,
	MatTreeModule,
	MatStepperModule,
	MatBadgeModule,
	MatCardModule,
	MatTooltipModule,
	MatCheckboxModule,
	MatSlideToggleModule,
	MatDividerModule,
	MatListModule,
	MatChipsModule,
	MatDialogModule,
	MatSnackBarModule,
	MatProgressSpinnerModule,
	MatButtonToggleModule
];

@NgModule(
	{
		imports: modules,
		exports: modules
	}
)
export class MaterialModule
{
}
