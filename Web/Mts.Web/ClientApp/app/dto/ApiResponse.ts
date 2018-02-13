export class ApiResponse {
    public success: boolean;
    public errorMesssage: string[];
}

export class LoginApiResponse {
    public success: boolean;
    public errorMessage: string[];
    public dataResponse: AuthToken;
}

export class AuthToken {
    public token: string;
    public refreshToken: string;
}