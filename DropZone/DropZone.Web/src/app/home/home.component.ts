import { Component, OnInit, NgZone } from '@angular/core';
import { Router } from '@angular/router';

import { UserService } from '../../services/user.service';
import { HttpService } from '../../services/http.service';
import { UserModel } from '../../models/users/user.model';
import { JumpBookModel } from '../../models/jumps/jumpBook.model';
import { DropZoneModel } from '../../models/dropzones/dropzone.model';
import { AircraftModel } from '../../models/aircrafts/aircraft.model';
import { DropZoneService } from '../../services/dropZone.service';
import { AircraftService } from '../../services/aircraft.service';

@Component({
    selector: 'home-app',
    templateUrl: './home.component.html',
    providers: [
        HttpService,
        UserService,
        DropZoneService,
        AircraftService
    ]
})
export class HomeComponent implements OnInit { 
    userId: number;
    roleId: number;
    selectedTab: string;
    claims: any = {
        writeDropZone: false,
        writeParachutes: false,
        writeAircrafts: false,
        writeUsers: false
    };

    user: UserModel;
    selectedUser: UserModel;
    users: UserModel[];
    jumpBook: JumpBookModel;
    confirmPassword: string;

    dropZone: DropZoneModel;
    dropZones: DropZoneModel[];
    isCreateDropZone: boolean;
    newDropZoneAdminEmail: string;

    aircraft: AircraftModel;
    aircrafts: AircraftModel[];
    isCreateAircraft: boolean;

    constructor(
        private router: Router,
        private zone: NgZone,
        private userService: UserService,
        private dropZoneService: DropZoneService,
        private aircraftService: AircraftService) 
    { 

    };

    ngOnInit(): any {
        this.userId = +sessionStorage.getItem('roleId');
        this.roleId = +sessionStorage.getItem('userId');

        this.setClaims(this.roleId);
        
        this.goToProfile();
    };

    //#region Profile
    goToProfile(): any {
        this.selectedTab = "Profile";

        this.getUser(this.userId);
        this.getUserJumpBook(this.userId);
    };

    getUser(userId: number): any {
        this.userService.getUserById(userId).subscribe((data: any) => { 
            console.log("Get User");
            console.log(data);
            
            if (!data.IsSuccess) {
                alert(data.ErrorMessage);
            }
            else {
                this.user = data;
            }
        });
    };

    getUserJumpBook(userId: number): any {
        this.userService.getUserJumpBook(userId).subscribe((data: any) => { 
            console.log("Get User JumpBook");
            console.log(data);
            
            if (!data.IsSuccess) {
                alert(data.ErrorMessage);
            }
            else {
                this.jumpBook = data.JumpBook;
            }
        });
    };

    editProfile(): any {
        this.userService.editUser(this.user).subscribe((data: any) => { 
            console.log("Edit User");
            console.log(data);

            if (!data.IsSuccess) {
                alert(data.ErrorMessage);
            }
            else {
                this.user = data;
            }
        });
    };

    changePassword(): any {
        if (this.user.password != this.confirmPassword) {
            alert("Password is not confirmed!");
            return;
        }

        this.userService.changeUserPassword(this.user).subscribe((data: any) => { 
            console.log("Change password");
            console.log(data);

            if (!data.IsSuccess) {
                alert(data.ErrorMessage);
            }
            else {
                this.user.password = null;
                this.confirmPassword = null;
            }
        });    
    };
    //#endregion

    //#region DropZones
    goToDropZone(): any {
        this.selectedTab = "DropZones";

        this.dropZone = null;
        this.isCreateDropZone = false;
        this.newDropZoneAdminEmail = null;

        this.getDropZones();
    };

    private getDropZones(): any {
        this.dropZoneService.getDropZones().subscribe((data: any) => { 
            console.log("Get DropZones");
            console.log(data);

            if (!data.IsSuccess) {
                alert(data.ErrorMessage);
            }
            else {
                this.dropZones = data;
            }
        });
    };

    getDropZone(dropZoneId: number): any {
        this.dropZone = null;
        this.isCreateDropZone = false;
        this.newDropZoneAdminEmail = null;

        this.dropZoneService.getDropZoneById(dropZoneId).subscribe((data: any) => { 
            console.log("Get DropZone");
            console.log(data);

            if (!data.IsSuccess) {
                alert(data.ErrorMessage);
            }
            else {
                this.dropZone = data;
            }
        });
    };

    setNewDropZone(): any {
        this.dropZone = new DropZoneModel();
        this.isCreateDropZone = true;
    };

    createDropZone(): any {
        let createDropZoneModel: any = {
            dropZone: this.dropZone,
            adminEmail: this.newDropZoneAdminEmail
        };

        this.dropZoneService.createDropZone(createDropZoneModel).subscribe((data: any) => { 
            console.log("Create DropZone");
            console.log(data);

            if (!data.IsSuccess) {
                alert(data.ErrorMessage);
            }
            else {
                this.dropZone = data;
                this.isCreateDropZone = false;
                this.newDropZoneAdminEmail = null;   

                this.getDropZones();
            }     
        });
    };

    editDropZone(): any {
        this.dropZoneService.editDropZone(this.dropZone).subscribe((data: any) => { 
            console.log("Edit DropZone");
            console.log(data);

            if (!data.IsSuccess) {
                alert(data.ErrorMessage);
            }
            else {
                this.dropZone = data;                  
                this.isCreateDropZone = false;   
                this.newDropZoneAdminEmail = null;   

                this.getDropZones();
            }      
        });
    };
    //#endregion

    //#region Aircrafts 
    goToAircrafts(): any {
        this.selectedTab = "Aircrafts";

        this.aircraft = null;
        this.isCreateAircraft = false;

        this.getAircrafts();
    };

    getAircrafts(): any {
        this.aircraftService.getAircrafts().subscribe((data: any) => { 
            console.log("Get Aircrafts");
            console.log(data);

            if (!data.IsSuccess) {
                alert(data.ErrorMessage);
            }
            else {
                this.aircrafts = data;
            }
        });
    };

    getDropZoneAircrafts(dropZoneId: number): any {
        this.aircraftService.getDropZoneAircrafts(dropZoneId).subscribe((data: any) => { 
            console.log("Get DropZone Aircrafts");
            console.log(data);

            if (!data.IsSuccess) {
                alert(data.ErrorMessage);
            }
            else {
                this.aircrafts = data;
            }
        });
    };

    getAircraft(aircraftId: number): any {
        this.aircraft = null;
        this.isCreateAircraft = false;

        this.aircraftService.getAircraftById(aircraftId).subscribe((data: any) => { 
            console.log("Get Aircraft");
            console.log(data);

            if (!data.IsSuccess) {
                alert(data.ErrorMessage);
            }
            else {
                this.aircraft = data;
            }
        });
    };

    setNewAircraft(): any {
        this.aircraft = new AircraftModel();
        this.isCreateAircraft = true;
    };

    createAircraft(): any {
        this.aircraftService.createAircraft(this.aircraft).subscribe((data: any) => { 
            console.log("Create Aircraft");
            console.log(data);

            if (!data.IsSuccess) {
                alert(data.ErrorMessage);
            }
            else {
                this.aircraft = data;
                this.isCreateAircraft = false;   

                this.getAircrafts();
            }     
        });
    };

    editAircraft(): any {
        this.aircraftService.editAircraft(this.aircraft).subscribe((data: any) => { 
            console.log("Edit Aircraft");
            console.log(data);

            if (!data.IsSuccess) {
                alert(data.ErrorMessage);
            }
            else {
                this.aircraft = data;  
                this.isCreateAircraft = false;   

                this.getAircrafts();
            }      
        });
    };

    deleteAircraft(aircraftId: number): any {
        if (!confirm("Do you want to delete aircraft?")) {
            return;
        }
        
        this.aircraftService.deleteAircraft(aircraftId).subscribe((data: any) => { 
            console.log("Delete Aircraft");
            console.log(data);

            if (!data.IsSuccess) {
                alert(data.ErrorMessage);
            }
            else {
                this.aircraft = null;  
                this.isCreateAircraft = false;   

                this.getAircrafts();
            }      
        });
    };
    //#endregion

    //#region Users
    goToUsers(): any {
        this.selectedTab = "Users";

        this.selectedUser = null;

        this.getUsers();
    };

    getUsers(): any {
        this.userService.getUsers().subscribe((data: any) => { 
            console.log("Get Users");
            console.log(data);

            if (!data.IsSuccess) {
                alert(data.ErrorMessage);
            }
            else {
                this.users = data;
            }
        });
    };

    getDropZoneUsers(dropZoneId: number): any {
        this.userService.getDropZoneUsers(dropZoneId).subscribe((data: any) => { 
            console.log("Get DropZone Users");
            console.log(data);

            if (!data.IsSuccess) {
                alert(data.ErrorMessage);
            }
            else {
                this.users = data;
            }
        });
    };

    getSportsmen(): any {
        this.userService.getSportsmen().subscribe((data: any) => { 
            console.log("Get Sportsmen");
            console.log(data);

            if (!data.IsSuccess) {
                alert(data.ErrorMessage);
            }
            else {
                this.users = data;
            }
        });
    };

    setSportsmanRole(): any {
        let userRoleModel: any = {
            userId: this.selectedUser.id,
            roleId: 10
        };

        this.userService.setRole(userRoleModel).subscribe((data: any) => { 
            console.log("Get Role");
            console.log(data);

            if (!data.IsSuccess) {
                alert(data.ErrorMessage);
            }
            else {
                this.selectedUser = null;

                this.getUsers();
            }
        });
    };

    setPackerRole(): any {
        let userRoleModel: any = {
            userId: this.selectedUser.id,
            roleId: 9
        };

        this.userService.setRole(userRoleModel).subscribe((data: any) => { 
            console.log("Get Role");
            console.log(data);

            if (!data.IsSuccess) {
                alert(data.ErrorMessage);
            }
            else {
                this.selectedUser = null;

                this.getUsers();
            }
        });
    };

    setManagerRole(): any {
        let userRoleModel: any = {
            userId: this.selectedUser.id,
            roleId: 8
        };

        this.userService.setRole(userRoleModel).subscribe((data: any) => { 
            console.log("Get Role");
            console.log(data);

            if (!data.IsSuccess) {
                alert(data.ErrorMessage);
            }
            else {
                this.selectedUser = null;

                this.getUsers();
            }
        });
    };

    setAdminRole(): any {
        let userRoleModel: any = {
            userId: this.selectedUser.id,
            roleId: 7
        };

        this.userService.setRole(userRoleModel).subscribe((data: any) => { 
            console.log("Get Role");
            console.log(data);

            if (!data.IsSuccess) {
                alert(data.ErrorMessage);
            }
            else {
                this.selectedUser = null;

                this.getUsers();
            }
        });
    };

    deleteUser(userId: number): any {
        if (!confirm("Do you want to delete user?")) {
            return;
        }
        
        this.userService.deleteUser(userId).subscribe((data: any) => { 
            console.log("Delete User");
            console.log(data);

            if (!data.IsSuccess) {
                alert(data.ErrorMessage);
            }
            else {
                this.selectedUser = null;  

                this.getUsers();
            }      
        });
    };

    //utilities
    private setClaims(roleId: number): any {
        switch(roleId){
            case 6:
            case 7:
                this.claims.writeDropZone = true;
                this.claims.writeParachutes = true;
                this.claims.writeAircrafts = true;
                this.claims.writeUsers = true;
                break;
            case 8:
                this.claims.writeUsers = true;
                this.claims.writeAircrafts = true;
                break;
            case 9:
                this.claims.writeParachutes = true;
                break;
            case 10:
            default:
                break;
        };
    };

    logout(): any {
        console.log("Logout");

        sessionStorage.removeItem('app_token');
        sessionStorage.removeItem('userId');
        sessionStorage.removeItem('roleId');

        this.router.navigate(['*']);
    };
}