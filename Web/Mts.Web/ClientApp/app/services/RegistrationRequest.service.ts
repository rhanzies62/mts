import { Injectable } from '@angular/core';
import { Http, Headers } from '@angular/http';
import { Observable } from 'rxjs/Rx';
import { RegistrationRequest } from '../dto/RegiestrationRequest';
import { ApiResponse } from '../dto/ApiResponse';
import { User } from '../dto/User';

@Injectable()
export class RegistrationRequestService {
    private apiUrl = "http://localhost:62758/api/";
    constructor(private http: Http) { }

    SubmitRegistration(model: RegistrationRequest): Observable<ApiResponse> {
        return this.http.post(this.apiUrl + "registrationrequest", model)
            .map(res => res.json() as ApiResponse)
            .catch((error: any) => Observable.throw(error.json().error || 'Server error'));
    }

    Register(model: User): Observable<ApiResponse>{
        return this.http.post(this.apiUrl + "registration", model)
            .map(res => res.json() as ApiResponse)
            .catch((error: any) => Observable.throw(error.json().error || 'Server error'));
    }
}
