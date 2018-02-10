import { Business } from "./Business";

export class User {
    constructor() {
        this.Business = new Business();
    }

    public FirstName: string;
    public LastName: string;
    public Password: string;
    public ConfirmPassword: string;
    public Email: string;
    public Business: Business;
}