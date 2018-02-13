import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';
import { CookieService } from 'ngx-cookie';
import { AuthToken } from '../dto/ApiResponse';
import { JwtHelper } from 'angular2-jwt';

@Injectable()
export class AuthGuard implements CanActivate {

    constructor(private cookieService: CookieService,
                private router: Router) { }

    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {
        var toks = this.cookieService.getObject("authTicket") as AuthToken;
        var helper = new JwtHelper();
        var path = route.url[0].path;
        var result = false;

        if (toks != undefined) {
            if (!helper.isTokenExpired(toks.token)) {
                result = true;
            }
        }

        if (!result)
            this.router.navigateByUrl("login?redirect=" + path);

        return result;
    }
}