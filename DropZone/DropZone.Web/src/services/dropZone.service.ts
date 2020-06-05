import { Injectable } from '@angular/core';
import { HttpService } from './http.service';
import { DropZoneModel } from '../models/dropzones/dropzone.model';

@Injectable()
export class DropZoneService{ //ADD
    controllerPrefix = 'DropZones/';

    constructor(private httpService: HttpService) { };

    //#region POST
    createDropZone (model: DropZoneModel): any { //ADD
        return this.httpService.postData(this.controllerPrefix + 'Create', model);
    };

    editDropZone (model: DropZoneModel): any { //ADD
        return this.httpService.postData(this.controllerPrefix + 'Edit', model);
    };
    //#endregion

    //#region GET
    getDropZones (): any { //ADD
        return this.httpService.getData(this.controllerPrefix);
    };

    getDropZoneById (id: number): any { //ADD
        return this.httpService.getData(this.controllerPrefix + id);
    };
    //#endregion
}