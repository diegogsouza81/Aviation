import { Component, Injector, Inject, OnInit, Optional } from '@angular/core';
import {
    MatDialogRef,
    MAT_DIALOG_DATA,
    MatCheckboxChange
} from '@angular/material';
import { finalize } from 'rxjs/operators';
import * as _ from 'lodash';
import { AppComponentBase } from '@shared/app-component-base';
import {
    AirplaneServiceProxy,
    GetAirplaneForEditOutput,
    AirplaneDto
} from '@shared/service-proxies/service-proxies';

@Component({
    templateUrl: 'edit-airplane-dialog.component.html',
    styles: [
        `
      mat-form-field {
        width: 100%;
      }
      mat-checkbox {
        padding-bottom: 5px;
      }
    `
    ]
})
export class EditAirplaneDialogComponent extends AppComponentBase
    implements OnInit {
    saving = false;
    airplane: AirplaneDto = new AirplaneDto();

  

    constructor(
        injector: Injector,
        private _airplaneService: AirplaneServiceProxy,
        private _dialogRef: MatDialogRef<EditAirplaneDialogComponent>,
        @Optional() @Inject(MAT_DIALOG_DATA) private _id: number
    ) {
        super(injector);
    }

    ngOnInit(): void {
        this._airplaneService
            .getAirplaneForEdit(this._id)
            .subscribe((result: GetAirplaneForEditOutput) => {
                this.airplane.init(result.airplane);


            });
    }


    

    save(): void {
        this.saving = true;



        this._airplaneService
            .update(this.airplane)
            .pipe(
                finalize(() => {
                    this.saving = false;
                })
            )
            .subscribe(() => {
                this.notify.info(this.l('SavedSuccessfully'));
                this.close(true);
            });
    }

    close(result: any): void {
        this._dialogRef.close(result);
    }
}
