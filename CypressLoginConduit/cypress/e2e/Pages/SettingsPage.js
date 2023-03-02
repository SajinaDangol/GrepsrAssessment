export class SettingsPage {

    update_username_textbox = ':nth-child(2) > .form-control';
    update_bio_textbox = ':nth-child(3) > .form-control';
    update_email_textbox = ':nth-child(4) > .form-control';
    update_password_textbox = ':nth-child(5) > .form-control';
    update_Settings_button = 'form > :nth-child(1) > .btn';
    logout_btn = '.btn-outline-danger';

    clickSettingsLink() {
        cy.get(':nth-child(3) > .nav-link').click();
    }
    updateUsername(newUsername) {
        cy.get(this.update_username_textbox).clear().type(newUsername);
    }
    updateBio() {
        cy.get(this.update_bio_textbox).clear().type('This is update case from cypress');
    }
    updateEmail() {
        cy.get(this.updateEmail).clear().type('test@gmail.com');
    }
    updatePassword() {
        cy.get(this.updatePassword).clear().type('123123');
    }
    clickUpdateSettingsBtn() {
        cy.get(this.update_Settings_button).click();
    }
    clickLogoutBtn() {
        cy.get(this.logout_btn).click();
    }
}
