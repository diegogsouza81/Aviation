import { Component, Injector, OnInit } from '@angular/core';
import { MatDialogRef, MatCheckboxChange } from '@angular/material';
import { finalize } from 'rxjs/operators';
import * as _ from 'lodash';
import { AppComponentBase } from '@shared/app-component-base';
import {
    AirplaneServiceProxy,
    AirplaneDto,
    CreateAirplaneDto
} from '@shared/service-proxies/service-proxies';

@Component({
    templateUrl: 'create-airplane-dialog.component.html',
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
export class CreateAirplaneDialogComponent extends AppComponentBase
    implements OnInit {
    saving = false;
    airplane: AirplaneDto = new AirplaneDto();

   

    constructor(
        injector: Injector,
        private _airplaneService: AirplaneServiceProxy,
        private _dialogRef: MatDialogRef<CreateAirplaneDialogComponent>
    ) {
        super(injector);
    }

    ngOnInit(): void {
       
    }

   

    

 

    

    save(): void {
        this.saving = true;

       

        const airplane_ = new CreateAirplaneDto();
        airplane_.init(this.airplane);

        this._airplaneService
            .create(airplane_)
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
