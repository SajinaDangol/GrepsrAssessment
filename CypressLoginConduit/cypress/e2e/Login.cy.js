/// <reference types= "cypress"/>

import { LoginPage } from "./Pages/LoginPage";
import { SettingsPage } from "./Pages/SettingsPage";

const loginPage = new LoginPage();
const settingsPage = new SettingsPage();

describe('LoginTestCases', function () {
    it('Signin and Signout', function () {

        loginPage.enterEmail('sajina@gmail.com');
        loginPage.enterPassword('123456');
        loginPage.clickLoginBtn();
        cy.get('.feed-toggle > .nav > :nth-child(1) > .nav-link');
        settingsPage.clickSettingsLink();
        settingsPage.clickLogoutBtn();
    });

    it('ValidSignin', function () {

        loginPage.enterEmail('sajina@gmail.com');
        loginPage.enterPassword('123456');
        loginPage.clickLoginBtn();
        cy.get('.feed-toggle > .nav > :nth-child(1) > .nav-link');
    });

    it('InvalidSignin', function () {

        loginPage.enterEmail('sajina@gmai.com');
        loginPage.enterPassword('123456');
        loginPage.clickLoginBtn();

    });
});

describe("Update Test Cases", function () {
    beforeEach(function () {
        cy.visit('/');
        cy.contains('Sign in').click();
    });

    it('updateSettings', function () {

        loginPage.enterEmail('sajina@gmail.com');
        loginPage.enterPassword('123456');
        loginPage.clickLoginBtn();
        cy.get('.feed-toggle > .nav > :nth-child(1) > .nav-link');
        settingsPage.clickSettingsLink();
        settingsPage.updateUsername('Updated Sajina');
        settingsPage.clickUpdateSettingsBtn();
        settingsPage.clickSettingsLink();
        settingsPage.clickLogoutBtn();
    });
});
