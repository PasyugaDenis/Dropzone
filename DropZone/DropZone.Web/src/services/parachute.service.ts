import { Injectable } from '@angular/core';
import { UserModel } from '../models/users/user.model';
import { HttpService } from './http.service';

@Injectable()
export class ParachuteService{
    controllerPrefix: string = 'Parachutes/';

    constructor(private httpService: HttpService) { };

    //#region POST
    editParachute (model: any): any {
        return this.httpService.postData('Edit', model);
    };

    createParachute (model: any): any {
        return this.httpService.postData('Create', model);
    };
    //#endregion

    //#region GET
    getParachuteById (id: number): any { //ADD
        return this.httpService.getData(this.controllerPrefix + id);
    };

    getParachutes (): any { //ADD
        return this.httpService.getData(this.controllerPrefix);
    };
    //#endregion
}