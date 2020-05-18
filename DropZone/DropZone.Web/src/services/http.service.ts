import {Injectable} from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';

@Injectable()
export class HttpService{
    basePath: string;

    constructor(private http: HttpClient) { 
        this.basePath = 'http://localhost:8010/api/';
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
        var token = localStorage.getItem('token');     
        var headers = new HttpHeaders();

        headers.append('Content-Type', 'application/json');
        headers.append('authentication', token);

        return headers;
    };
}