export class LoginPage {

    email_textbox = ':nth-child(1) > .form-control';
    password_textbox = ':nth-child(2) > .form-control';
    login_button = '.btn';

    enterEmail(Email) {
        cy.get(this.email_textbox).type(Email);
    }
    enterPassword(Password) {
        cy.get(this.password_textbox).type(Password);
    }
    clickLoginBtn() {
        cy.get(this.login_button).click();
    }
}
