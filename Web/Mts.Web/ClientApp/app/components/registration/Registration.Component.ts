import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, Params } from '@angular/router';
import { ValidateTokenService } from '../../services/ValidateToken.service';
import { RegistrationRequest } from '../../dto/RegiestrationRequest';
import { ApiResponse } from '../../dto/ApiResponse';
import { User } from '../../dto/User';

@Component({
    selector: 'registration',
    templateUrl: './Registration.Component.html',
    styleUrls: ['./Registration.Component.css']
})
export class RegistrationComponent implements OnInit {
    model = new User();
    public requestResult: ApiResponse;
    public isTokenValidated: boolean;

    constructor(private activatedRoute: ActivatedRoute,
        private validateTokenService: ValidateTokenService,
        private router: Router) {
        this.isTokenValidated = false;
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
}
