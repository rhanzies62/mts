import { Injectable } from '@angular/core';
import { Http, Headers } from '@angular/http';
import { Observable } from 'rxjs/Rx';
import { RegistrationRequest } from '../dto/RegiestrationRequest';
import { ApiResponse } from '../dto/ApiResponse';

@Injectable()
export class ValidateTokenService {
    private apiUrl = "http://localhost:62758/api/validatetoken";
    constructor(private http: Http) { }

    Validate(model: RegistrationRequest): Observable<ApiResponse> {
        return this.http.post(this.apiUrl, model)
            .map(res => res.json() as ApiResponse)
            .catch((error: any) => Observable.throw(error.json().error || 'Server err'));
    }
}
