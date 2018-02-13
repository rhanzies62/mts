import { Injectable } from '@angular/core';
import { Http, Headers } from '@angular/http';
import { Observable } from 'rxjs/Rx';
import { RegistrationRequest } from '../dto/RegiestrationRequest';
import { ApiResponse, LoginApiResponse } from '../dto/ApiResponse';
import { User } from '../dto/User';

@Injectable()
export class AuthenticationService {
    private apiUrl = "http://localhost:62758/api/";
    constructor(private http: Http) { }

    Login(model: User): Observable<LoginApiResponse> {
        return this.http.post(this.apiUrl + "authenticate", model)
            .map(res => res.json() as LoginApiResponse)
            .catch((error: any) => Observable.throw(error.json().error || 'Server error'));
    }
}
