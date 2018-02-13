import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';
import { CookieModule } from 'ngx-cookie';

//page components
import { AppComponent } from './components/app/app.component';
import { LandingComponent } from './components/landing/landing.component';
import { RegistrationRequestComponent } from './components/registrationrequest/RegistrationRequest.Component';
import { RegistrationComponent } from './components/registration/Registration.Component';
import { LoginComponent } from './components/login/Login.Component';

//api components
import { RegistrationRequestService } from '../app/services/RegistrationRequest.service';
import { ValidateTokenService } from '../app/services/ValidateToken.service';
import { AuthenticationService } from './services/Authentication.service';
import { AuthGuard } from './services/AuthGuard';
import { DashboardComponent } from './components/dashboard/Dashboard.Component';
import { UnAuthAccessOnly } from './services/UnAuthAccessOnly';

//ui components

@NgModule({
    declarations: [
        AppComponent,
        LandingComponent,
        RegistrationRequestComponent,
        RegistrationComponent,
        LoginComponent,
        DashboardComponent
    ],
    providers: [
        RegistrationRequestService,
        ValidateTokenService,
        AuthenticationService,
        AuthGuard,
        UnAuthAccessOnly
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        CookieModule.forRoot(),
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: LandingComponent },
            { path: 'request', component: RegistrationRequestComponent },
            { path: 'register', component: RegistrationComponent },
            { path: 'login', component: LoginComponent, canActivate: [UnAuthAccessOnly]},
            { path: 'dashboard', component: DashboardComponent, canActivate: [AuthGuard] },
            { path: '**', redirectTo: 'home' }
        ])
    ]
})
export class AppModuleShared {
}
