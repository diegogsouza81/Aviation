import { Component, Injector } from '@angular/core';
import { MatDialog } from '@angular/material';
import { finalize } from 'rxjs/operators';
import { appModuleAnimation } from '@shared/animations/routerTransition';

import {
    PagedListingComponentBase,
    PagedRequestDto
} from '@shared/paged-listing-component-base';
import {
    AirplaneServiceProxy,
    AirplaneDto,
    PagedResultDtoOfAirplaneDto
} from '@shared/service-proxies/service-proxies';
import { CreateAirplaneDialogComponent } from './create-airplane/create-airplane-dialog.component';
import { EditAirplaneDialogComponent } from './edit-airplane/edit-airplane-dialog.component';

class PagedAirplaneRequestDto extends PagedRequestDto {
    keyword: string;
}

@Component({
    templateUrl: './airplane.component.html',
    animations: [appModuleAnimation()],
    styles: [
        `
          mat-form-field {
            padding: 10px;
          }
        `
    ]
})
export class AirplaneComponent extends PagedListingComponentBase<AirplaneDto> {
    airplanes: AirplaneDto[] = [];

    keyword = '';

    constructor(
        injector: Injector,
        private _airplaneService: AirplaneServiceProxy,
        private _dialog: MatDialog
    ) {
        super(injector);
    }

    list(
        request: PagedAirplaneRequestDto,
        pageNumber: number,
        finishedCallback: Function
    ): void {

        request.keyword = this.keyword;

        this._airplaneService
            .getAll(request.keyword, request.skipCount, request.maxResultCount)
            .pipe(
                finalize(() => {
                    finishedCallback();
                })
            )
            .subscribe((result: PagedResultDtoOfAirplaneDto) => {
                this.airplanes = result.items;
                this.showPaging(result, pageNumber);
            });
    }

    delete(airplane: AirplaneDto): void {
        abp.message.confirm(
            this.l('AirplaneDeleteWarningMessage', airplane.name),
            (result: boolean) => {
                if (result) {
                    this._airplaneService
                        .delete(airplane.id)
                        .pipe(
                            finalize(() => {
                                abp.notify.success(this.l('SuccessfullyDeleted'));
                                this.refresh();
                            })
                        )
                        .subscribe(() => { });
                }
            }
        );
    }

    createAirplane(): void {
        this.showCreateOrEditAirplaneDialog();
    }

    editAirplane(airplane: AirplaneDto): void {
        this.showCreateOrEditAirplaneDialog(airplane.id);
    }

    showCreateOrEditAirplaneDialog(id?: number): void {
        let createOrEditAirplaneDialog;
        if (id === undefined || id <= 0) {
            createOrEditAirplaneDialog = this._dialog.open(CreateAirplaneDialogComponent);
        } else {
            //todo: fix update
            createOrEditAirplaneDialog = this._dialog.open(EditAirplaneDialogComponent, {
                data: id
            });
        }

        createOrEditAirplaneDialog.afterClosed().subscribe(result => {
            if (result) {
                this.refresh();
            }
        });
    }
}
