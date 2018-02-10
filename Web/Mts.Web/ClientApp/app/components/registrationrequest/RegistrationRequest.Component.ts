import { Component } from '@angular/core';
import { RegistrationRequest } from '../../dto/RegiestrationRequest';
import { RegistrationRequestService } from '../../services/RegistrationRequest.service';

@Component({
    selector: 'registrationrequest',
    templateUrl: './RegistrationRequest.Component.html',
    styleUrls : ['./RegistrationRequest.Component.css']
})
export class RegistrationRequestComponent {
    model = new RegistrationRequest();
    public Message: string;
    public ShowResult: boolean;
    public Loading: boolean;

    constructor(private registrationRequestService: RegistrationRequestService) {
        this.Message = "Please provide your email address and we will send you a exclusive registration link to your email.";
        this.ShowResult = false;
        this.Loading = false;
    }

    submitRequest() {
        this.Loading = true;
        this.registrationRequestService
            .SubmitRegistration(this.model)
            .subscribe(response => {
                console.log(response);
                if (response.success) {
                    this.Message = "We just sent registration link on your email. Please check your email and click the link below to proceed on your registration";
                } else {
                    response.errorMesssage.forEach(i => {
                        this.Message = i;
                    });
                }
                this.Loading = false;
                this.ShowResult = true;
            }, error => {
                this.Message = "Sorry something is wrong when sending a request. Please try again later";
                this.Loading = false;
                this.ShowResult = true;
            });
    }
}
