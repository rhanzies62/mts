import { Component } from '@angular/core';
import { AuthenticationService } from '../../services/Authentication.service';
import { User } from '../../dto/User';
import { CookieService, CookieOptions } from 'ngx-cookie';
import { LoginApiResponse } from '../../dto/ApiResponse';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
    selector: 'login',
    templateUrl: './Login.Component.html',
    styleUrls: ['./Login.Component.css']
})
export class LoginComponent {
    model = new User();
    public loginResult: LoginApiResponse;
    public isProcessing: boolean;

    private redirect: string;

    constructor(private authenticationService: AuthenticationService,
        private cookieService: CookieService,
        private router: Router,
        private activatedRoute: ActivatedRoute) {

        this.isProcessing = false;
        this.loginResult = new LoginApiResponse();
        this.loginResult.success = true;
        this.redirect = this.activatedRoute.snapshot.queryParams["redirect"];

    }

    public Login(_model: User) {
        this.authenticationService.Login(_model).subscribe(res => {
            if (res.success) {
                let cookieOptions = { secure: true, httpOnly: true } as CookieOptions
                this.cookieService.putObject("authTicket", res.dataResponse);
                if(this.redirect == "")
                    this.router.navigateByUrl("home");
                else
                    this.router.navigateByUrl(this.redirect);
            } else {
                this.loginResult = res;
            }
        });
    }
}
