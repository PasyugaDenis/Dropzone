import {Injectable} from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';

@Injectable()
export class HttpService{
    basePath: string;

    constructor(private http: HttpClient) { 
        this.basePath = 'http://localhost:54896/';
    };
      
    postData(path: string, model: any) {      
        var headers = this.setHeaders();

        return this.http.post(this.basePath + path, model, { headers: headers });
    };

    getData(path: string) {
        var headers = this.setHeaders();

        return this.http.get(this.basePath + path, { headers: headers }); 
    };

    private setHeaders(): HttpHeaders {
        var headers = new HttpHeaders();
        var token = sessionStorage.getItem('token');

        if (token) {
            headers.append('Authorization ', 'Bearer ' + token);
        }

        headers.append('Content-Type', 'application/json');

        return headers;
    };
}