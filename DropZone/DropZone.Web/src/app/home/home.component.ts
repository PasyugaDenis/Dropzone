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
import { RoleModel } from '../../models/users/role.model';
import { ParachuteSystemModel } from '../../models/parachuteSystems/parachuteSystem.model';
import { ParachuteModel } from '../../models/parachutes/parachute.model';
import { AADModel } from '../../models/aads/aad.model';
import { AADTypeModel } from '../../models/aads/aadType.model';
import { SatchelModel } from '../../models/satchels/satchel.model';
import { ParachuteService } from '../../services/parachute.service';

@Component({
    selector: 'home-app',
    templateUrl: './home.component.html',
    providers: [
        HttpService,
        UserService,
        DropZoneService,
        AircraftService,
        ParachuteService
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
    userList: UserModel[];
    jumpBook: JumpBookModel;
    confirmPassword: string;

    dropZone: DropZoneModel;
    dropZones: DropZoneModel[];
    isCreateDropZone: boolean;
    newDropZoneAdminEmail: string;

    aircraft: AircraftModel;
    aircrafts: AircraftModel[];
    isCreateAircraft: boolean;

    parachute: ParachuteSystemModel;
    parachutes: ParachuteSystemModel[];
    isCreateParachute: boolean;

    plannedUser: any;
    plannedUsers: any[];
    plannedFlight: any;
    plannedFlights: any[];

    constructor(
        private router: Router,
        private zone: NgZone,
        private userService: UserService,
        private dropZoneService: DropZoneService,
        private aircraftService: AircraftService,
        private parachuteService: ParachuteService) 
    { 
        this.user = new UserModel();
        this.user.Role = new RoleModel();
        this.jumpBook = new JumpBookModel();
        this.jumpBook.Jumps = [];

        this.dropZone = new DropZoneModel();
        this.dropZones = [];

        this.aircraft = new AircraftModel();
        this.aircrafts = [];

        this.selectedUser = new UserModel();
        this.userList = [];

        this.parachute = new ParachuteSystemModel();
        this.parachute.MainParachute = new ParachuteModel();
        this.parachute.ReserveParachute = new ParachuteModel();
        this.parachute.AAD = new AADModel();
        this.parachute.AAD.AADType = new AADTypeModel();
        this.parachute.Satchel = new SatchelModel();
        this.parachutes = [];
    };

    ngOnInit(): any {
        this.userId = +sessionStorage.getItem('userId');
        this.roleId = +sessionStorage.getItem('roleId');

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
            this.zone.run(() => {
                console.log("Get User");

                this.user = data;
    
                console.log(this.user);
            });
        });
    };

    getUserJumpBook(userId: number): any {
        this.userService.getUserJumpBook(userId).subscribe((data: any) => { 
            this.zone.run(() => {
                console.log("Get User JumpBook");
                
                this.jumpBook = data;

                console.log(this.jumpBook);
            });
        });
    };

    editProfile(): any {
        this.userService.editUser(this.user).subscribe((data: any) => { 
            this.zone.run(() => {
                console.log("Edit User");
        
                this.user = data;
    
                console.log(this.user);
            });
        });
    };

    changePassword(): any {
        if (this.user.Password != this.confirmPassword) {
            alert("Password is not confirmed!");
            return;
        }

        this.userService.changeUserPassword(this.user).subscribe((data: any) => { 
            console.log("Change password");
            console.log(data);

            this.user.Password = null;
            this.confirmPassword = null;
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

            this.dropZones = data;

            console.log(this.dropZones);
        });
    };

    getDropZone(dropZoneId: number): any {
        this.dropZone = null;
        this.isCreateDropZone = false;
        this.newDropZoneAdminEmail = null;

        this.dropZoneService.getDropZoneById(dropZoneId).subscribe((data: any) => { 
            console.log("Get DropZone");

            this.dropZone = data;
            this.dropZone.Aircrafts = [];
            this.dropZone.Users = [];

            console.log(this.dropZone);
        });
    };

    setNewDropZone(): any {
        this.dropZone = new DropZoneModel();
        this.dropZone.Aircrafts = [];
        this.dropZone.Users = [];
        this.isCreateDropZone = true;
    };

    createDropZone(): any {
        let createDropZoneModel: any = {
            DropZone: this.dropZone,
            AdminEmail: this.newDropZoneAdminEmail
        };

        console.log(createDropZoneModel);

        this.dropZoneService.createDropZone(createDropZoneModel).subscribe((data: any) => { 
            console.log("Create DropZone");

            this.dropZone = null;

            console.log(this.dropZone);

            this.isCreateDropZone = false;
            this.newDropZoneAdminEmail = null;   

            this.getDropZones();    
        });
    };

    changeDropZone(): any {
        console.log(this.dropZone);

        this.dropZoneService.editDropZone(this.dropZone).subscribe((data: any) => { 
            console.log("Edit DropZone");

            this.dropZone = data;  
            
            console.log(this.dropZone);

            this.isCreateDropZone = false;   
            this.newDropZoneAdminEmail = null;   

            this.getDropZones();
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

            this.aircrafts = data;

            console.log(this.aircrafts);
        });
    };

    getDropZoneAircrafts(dropZoneId: number): any {
        this.aircraftService.getDropZoneAircrafts(dropZoneId).subscribe((data: any) => { 
            console.log("Get DropZone Aircrafts");
                
            this.aircrafts = data;

            console.log(this.aircrafts);
        });
    };

    getAircraft(aircraftId: number): any {
        this.aircraft = null;
        this.isCreateAircraft = false;

        this.aircraftService.getAircraftById(aircraftId).subscribe((data: any) => { 
            console.log("Get Aircraft");
                
            this.aircraft = data;

            console.log(this.aircraft);
        });
    };

    setNewAircraft(): any {
        this.aircraft = new AircraftModel();
        this.isCreateAircraft = true;
    };

    createAircraft(): any {
        this.aircraftService.createAircraft(this.aircraft).subscribe((data: any) => { 
            console.log("Create Aircraft");

            this.aircraft = data;
    
            console.log(this.aircraft);

            this.isCreateAircraft = false;   

            this.getAircrafts();
        });
    };

    editAircraft(): any {
        this.aircraftService.editAircraft(this.aircraft).subscribe((data: any) => { 
            console.log("Edit Aircraft");
            
            this.aircraft = data;

            console.log(this.aircraft);
 
            this.isCreateAircraft = false;   

            this.getAircrafts();
        });
    };

    deleteAircraft(aircraftId: number): any {
        if (!confirm("Do you want to delete aircraft?")) {
            return;
        }
        
        this.aircraftService.deleteAircraft(aircraftId).subscribe((data: any) => { 
            console.log("Delete Aircraft");

            this.aircraft = null;  
            this.isCreateAircraft = false;   

            this.getAircrafts();
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

            this.userList = data;

            console.log(this.userList);
        });
    };

    getSelectedUser(userId: number): any {
        this.userService.getUserById(userId).subscribe((data: any) => { 
            this.zone.run(() => {
                console.log("Get User");

                this.selectedUser = data;
    
                console.log(this.selectedUser);
            });
        });
    };

    getDropZoneUsers(dropZoneId: number): any {
        this.userService.getDropZoneUsers(dropZoneId).subscribe((data: any) => { 
            console.log("Get DropZone Users");
            console.log(data);

            this.userList = data;
        });
    };

    getSportsmen(): any {
        this.userService.getSportsmen().subscribe((data: any) => { 
            console.log("Get Sportsmen");
            console.log(data);

            this.userList = data;
        });
    };

    setSportsmanRole(): any {
        let userRoleModel: any = {
            userId: this.selectedUser.Id,
            roleId: 10
        };

        this.userService.setRole(userRoleModel).subscribe((data: any) => { 
            console.log("Get Role");
            console.log(data);

            this.selectedUser = null;

            this.getUsers();
        });
    };

    setPackerRole(): any {
        let userRoleModel: any = {
            userId: this.selectedUser.Id,
            roleId: 9
        };

        this.userService.setRole(userRoleModel).subscribe((data: any) => { 
            console.log("Get Role");
            console.log(data);

            this.selectedUser = null;

            this.getUsers();
        });
    };

    setManagerRole(): any {
        let userRoleModel: any = {
            userId: this.selectedUser.Id,
            roleId: 8
        };

        this.userService.setRole(userRoleModel).subscribe((data: any) => { 
            console.log("Get Role");
            console.log(data);

            this.selectedUser = null;

            this.getUsers();
        });
    };

    setAdminRole(): any {
        let userRoleModel: any = {
            userId: this.selectedUser.Id,
            roleId: 7
        };

        this.userService.setRole(userRoleModel).subscribe((data: any) => { 
            console.log("Get Role");
            console.log(data);

            this.selectedUser = null;

            this.getUsers();
        });
    };

    deleteUser(userId: number): any {
        if (!confirm("Do you want to delete user?")) {
            return;
        }
        
        this.userService.deleteUser(userId).subscribe((data: any) => { 
            console.log("Delete User");
            console.log(data);

            this.selectedUser = null;  

            this.getUsers();
        });
    };
    //#endregion

    //#region Parachutes
    goToParachutes(): any {
        this.selectedTab = "Parachutes";

        this.parachute = null;

        this.getParachutes();
    };

    getParachutes(): any {
        this.parachuteService.getParachutes().subscribe((data: any) => { 
            console.log("Get Parachutes");

            this.parachutes = data;

            console.log(this.parachutes);
        });
    };

    getParachute(id: number): any {
        this.parachuteService.getParachuteById(id).subscribe((data: any) => { 
            console.log("Get Parachute");

            this.parachute = data;

            console.log(this.parachute);
        });
    };
        
    editParachute(): any {
        this.isCreateParachute = false;

        this.parachuteService.editParachute(this.parachute).subscribe((data: any) => { 
            console.log("Edit Parachute");

            this.parachute = null;

            this.getParachutes();
        });
    };
        
    createParachute(): any {
        this.isCreateParachute = false;

        this.parachuteService.createParachute(this.parachute).subscribe((data: any) => { 
            console.log("Create Parachute");

            this.parachute = null;

            this.getParachutes();
        });
    };
        
    setNewParachute(): any {
        this.parachute = new ParachuteSystemModel();
        this.parachute.MainParachute = new ParachuteModel();
        this.parachute.ReserveParachute = new ParachuteModel();
        this.parachute.AAD = new AADModel();
        this.parachute.AAD.AADType = new AADTypeModel();
        this.parachute.Satchel = new SatchelModel();

        this.isCreateParachute = true;
    };
    //#endregion

    //#region Flights
    goToFlights(): any {
        this.selectedTab = "Flight";

        this.plannedUsers = [];
        this.plannedFlights = [];
        this.plannedFlight = {
            Aircraft: AircraftModel,
            Users: []
        };
        this.plannedUser = {
            User: UserModel,
            Jumps: 0
        };
    };

    planneUser(): any {
        this.plannedUsers.forEach(element => {
            if (element.User.Id == this.plannedUser.User.Id){
                return;
            }
        });

        this.plannedUsers.push(this.plannedUser);

        this.plannedUser = {
            User: UserModel,
            Jumps: 0
        };    

    };

    addUserToFlight(item: any): any {
        item.Jumps--;

        this.plannedFlight.Users.push(item.User);
    };

    deletePlannedUser(index: number): any {
        this.plannedUsers.splice(index, 1);
    };

    deleteUserFromFlight(index: number): any {
        this.plannedFlight.Users.splice(index, 1);
    };

    formFlight(): any {
        this.plannedFlights.push(this.plannedFlight);

        this.plannedFlight = {
            Aircraft: AircraftModel,
            Users: []
        };
    };

    deleteFlight(index: number): any {
        this.plannedFlights.splice(index, 1);
    };
    //#endregion

    //utilities
    private setClaims(roleId: number): any {
        switch(roleId){
            case 5:
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
        sessionStorage.removeItem('app_token');
        sessionStorage.removeItem('userId');
        sessionStorage.removeItem('roleId');

        this.router.navigate(['']);
    };
}