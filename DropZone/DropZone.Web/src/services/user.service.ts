import { Injectable } from '@angular/core';
import { UserModel } from '../models/users/user.model';
import { HttpService } from './http.service';

@Injectable()
export class UserService{
    controllerPrefix: string = 'Users/';

    constructor(private httpService: HttpService) { };

    //#region POST
    authorization (model: UserModel): any {
        return this.httpService.postData('Authorize', model);
    };

    register (model: UserModel): any {
        return this.httpService.postData('Register', model);
    };

    editUser (model: UserModel): any { //ADD
        return this.httpService.postData(this.controllerPrefix + 'Edit', model);
    };

    changeUserPassword (model: UserModel): any { //ADD
        return this.httpService.postData(this.controllerPrefix + 'ChangePassword', model);
    };

    setRole (model: any): any { //ADD
        return this.httpService.postData(this.controllerPrefix + 'Role/Edit', model);
    };

    deleteUser (id: number): any { //ADD
        return this.httpService.postData(this.controllerPrefix + 'Delete', id);
    };
    //#endregion

    //#region GET
    getUserById (id: number): any { //ADD
        return this.httpService.getData(this.controllerPrefix + id);
    };
    
    getUserJumpBook (id: number): any { //ADD
        return this.httpService.getData(this.controllerPrefix + 'JumpBook/' + id);
    };

    getUsers (): any { //ADD
        return this.httpService.getData(this.controllerPrefix);
    };

    getDropZoneUsers (id: number): any { //ADD
        return this.httpService.getData(this.controllerPrefix + 'DropZone' + id);
    };

    getSportsmen (): any { //ADD
        return this.httpService.getData(this.controllerPrefix + 'Sportsmen');
    };
    //#endregion
}