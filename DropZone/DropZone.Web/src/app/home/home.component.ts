import { Component, OnInit, NgZone } from '@angular/core';
import { Router } from '@angular/router';

import { UserService } from '../../services/user.service';
import { HttpService } from '../../services/http.service';

@Component({
    selector: 'home-app',
    templateUrl: './home.component.html',
    providers: [
        HttpService,
        UserService
    ]
})
export class HomeComponent implements OnInit { 
    
    constructor(
        private router: Router,
        private zone: NgZone) 
    {
        
    };

    ngOnInit(): any {

    };
}