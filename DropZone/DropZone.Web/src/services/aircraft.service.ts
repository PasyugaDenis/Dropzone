import { Injectable } from '@angular/core';
import { HttpService } from './http.service';
import { AircraftModel } from '../models/aircrafts/aircraft.model';

@Injectable()
export class AircraftService{ //ADD
    controllerPrefix = 'Aircrafts/';

    constructor(private httpService: HttpService) { };

    //#region POST
    createAircraft (model: AircraftModel): any { //ADD
        return this.httpService.postData(this.controllerPrefix + 'Create', model);
    };

    editAircraft (model: AircraftModel): any { //ADD
        return this.httpService.postData(this.controllerPrefix + 'Edit', model);
    };

    deleteAircraft (id: number): any { //ADD
        return this.httpService.postData(this.controllerPrefix + 'Delete', id);
    };
    //#endregion

    //#region GET
    getAircrafts (): any { //ADD
        return this.httpService.getData(this.controllerPrefix);
    };

    getDropZoneAircrafts (id: number): any { //ADD
        return this.httpService.getData(this.controllerPrefix + 'DropZone/' + id);
    };

    getAircraftById (id: number): any { //ADD
        return this.httpService.getData(this.controllerPrefix + id);
    };
    //#endregion
}