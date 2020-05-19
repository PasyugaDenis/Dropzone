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
        var token = localStorage.getItem('app_token');
        var userId = localStorage.getItem('userId');
        var roleId = localStorage.getItem('roleId');

        if (token != null && userId != null) {
            this.goToMain(token, userId, roleId);
        }
    };

    signIn(): any {
        this.userService.authorization(this.user).subscribe((data: any) => { 
            if (data.isSuccess) {
                alert(data.errorMessage);
            }
            else {
                this.goToMain(data.token, data.userId, data.roleId);
            }
        });
    };

    signUp(): any {
        if (this.newUser.password != this.confirmPassword) {
            this.isPasswordsConfirmed = false;
            return;
        }
            
        this.createUser();
    };

    private createUser(): any {
        this.userService.register(this.newUser).subscribe((userData: any) => { 
            if (userData.isSuccess) {
                console.log(userData.errorMessage);
            }
            else {
                this.goToMain(userData.token, userData.userId, userData.roleId);
            }
        });
    };

    private goToMain(token: string, userId: string, roleId: string): any {
        localStorage.setItem('app_token', token);
        localStorage.setItem('userId', userId);
        localStorage.setItem('roleId', roleId);

        this.router.navigate(['home']);
    };
}