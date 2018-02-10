import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';

//page components
import { AppComponent } from './components/app/app.component';
import { LandingComponent } from './components/landing/landing.component';
import { RegistrationRequestComponent } from './components/registrationrequest/RegistrationRequest.Component';
import { RegistrationComponent } from './components/registration/Registration.Component';

//api components
import { RegistrationRequestService } from '../app/services/RegistrationRequest.service';
import { ValidateTokenService } from '../app/services/ValidateToken.service';

//ui components

@NgModule({
    declarations: [
        AppComponent,
        LandingComponent,
        RegistrationRequestComponent,
        RegistrationComponent
    ],
    providers: [
        RegistrationRequestService,
        ValidateTokenService
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: LandingComponent },
            { path: 'request', component: RegistrationRequestComponent },
            { path: 'register', component: RegistrationComponent },
            { path: '**', redirectTo: 'home' }
        ])
    ]
})
export class AppModuleShared {
}
