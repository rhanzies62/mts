import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, Params } from '@angular/router';
import { ValidateTokenService } from '../../services/ValidateToken.service';
import { RegistrationRequest } from '../../dto/RegiestrationRequest';
import { ApiResponse } from '../../dto/ApiResponse';
import { User } from '../../dto/User';
import { RegistrationRequestService } from '../../services/RegistrationRequest.service';

@Component({
    selector: 'registration',
    templateUrl: './Registration.Component.html',
    styleUrls: ['./Registration.Component.css']
})
export class RegistrationComponent implements OnInit {
    model = new User();
    public requestResult: ApiResponse;
    public registrationResult: ApiResponse;
    public isTokenValidated: boolean;
    public isProcessing: boolean;
    public showSuccess: boolean;
    public showResult: boolean;

    constructor(private activatedRoute: ActivatedRoute,
        private validateTokenService: ValidateTokenService,
        private RegistrationRequestService: RegistrationRequestService,
        private router: Router) {
        this.isTokenValidated = false;
        this.isProcessing = false;
        this.registrationResult = new ApiResponse();
        this.registrationResult.success = true;
        this.showSuccess = false;
        this.showResult = true;
    }

    ngOnInit() {
        var _model = new RegistrationRequest();
        _model.Token = this.activatedRoute.snapshot.queryParams["t"];
        _model.Email = this.activatedRoute.snapshot.queryParams["e"];
        if (_model.Token === undefined || _model.Token === "" || _model.Email === "" || _model.Email === undefined) {
            this.router.navigateByUrl("home");
        } else {
            this.validateTokenService.Validate(_model).subscribe(res => {
                this.isTokenValidated = true;
                this.requestResult = res;
                if (this.requestResult.success) {
                    this.model.Email = _model.Email;
                }
            });
        }
    }

    submitForm(_model: User) {
        this.isProcessing = true;
        this.RegistrationRequestService.Register(_model).subscribe(res => {
            this.registrationResult = res;
            this.showSuccess = true;
            this.showResult = false;
        });
    }
}
