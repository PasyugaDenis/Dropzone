import { Injectable } from '@angular/core';
import { UserModel } from '../models/users/user.model';
import { HttpService } from './http.service';

@Injectable()
export class UserService{

    constructor(private httpService: HttpService) { };

    authorization (user: UserModel): any {
        return this.httpService.postData('Authorize', user);
    };

    register (user: UserModel): any {
        return this.httpService.postData('Register', user);
    };
}