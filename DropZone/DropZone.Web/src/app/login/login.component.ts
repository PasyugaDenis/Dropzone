import { Component, OnInit } from '@angular/core';
import { UserService } from '../../services/user.service';
import { HttpService } from '../../services/http.service';
import { Router } from '@angular/router';
import { UserModel } from '../../models/users/user.model';
  
@Component({
    selector: 'login-app',
    templateUrl: './login.component.html',
    providers: [
        UserService, 
        HttpService
    ]
})
export class LoginComponent implements OnInit { 
    isRegistration: boolean;
    isPasswordsConfirmed: boolean;

    confirmPassword: string;

    user: UserModel;  
    newUser: UserModel;

    constructor(
        private router: Router,
        private userService: UserService) 
    {  
        this.isRegistration = false;
        this.isPasswordsConfirmed = true;

        this.user = new UserModel();
        this.newUser = new UserModel();
    }

    ngOnInit() {
        var token = sessionStorage.getItem('app_token');
        var userId = sessionStorage.getItem('userId');
        var roleId = sessionStorage.getItem('roleId');

        if (token != null && userId != null) {
            this.goToMain(token, userId, roleId);
        }
    };

    signIn(): any {
        this.userService.authorization(this.user).subscribe((data: any) => { 
            console.log(data);
            if (!data.IsSuccess) {
                alert(data.ErrorMessage);
            }
            else {
                this.goToMain(data.Token, data.UserId, data.RoleId);
            }
        });
    };

    signUp(): any {
        if (this.newUser.Password != this.confirmPassword) {
            this.isPasswordsConfirmed = false;
            return;
        }
            
        this.userService.register(this.newUser).subscribe((data: any) => { 
            if (!data.IsSuccess) {
                alert(data.ErrorMessage);
            }
            else {
                this.goToMain(data.Token, data.UserId, data.RoleId);
            }
        });
    };

    private goToMain(token: string, userId: string, roleId: string): any {
        console.log("To main");

        sessionStorage.setItem('app_token', token);
        sessionStorage.setItem('userId', userId);
        sessionStorage.setItem('roleId', roleId);

        this.router.navigate(['home']);
    };
}