# WAAD Authentication

1.  File / New / Configure WAAD in a new project.
2.  Show the GeekQuiz solution with WAAD Authentication.
3.  Deploy and show portal configuration.

### Goals

In this demo, you will see how to:

1.  Create an application in Visual Studio that is automatically integrated with a Windows Azure Active Directory tenant.
2.  Deploy an existing application using Visual Studio to an Azure web site and have it automaitically integrate with a WAAD tenant.

### Key Technologies

*   Windows Azure Active Directory
*   Visual Studio 2013

### Setup and Configuration

Follow these steps to setup your environment for the demo.

1.  Follow the steps detailed in this link to setup local sources for the following directories:

    1.  **C:\Program Files (x86)\Microsoft Web Tools\Packages**
    2.  **C:\Program Files (x86)\Microsoft ASP.NET\ASP.NET Web Stack 5\Packages**

    ![NuGet Sources](images/nuget-sources.png?raw=true)

2.  Create a new Windows Azure Active Directory tenant.

3.  Create a new website in Windows Azure.

4.  Add a database as a linked **Linked Resource**.

5.  Download the publishing profile. This is be required for segment #2.

    > **Important:** At the time of writing, you can only create one AD per subscription and it cannot be deleted.

6.  Open Visual Studio 2013.

## Demo

This demo is composed of the following segments:

1.  Adding a new website to an organization.
2.  Running the organization's GeekQuiz.

### Adding a new website to an organization

1.  Open the **File / New Project** dialog and select the **Visual C# / Web** templates.

2.  Name the application _GeekQuiz_ and click **OK**.

    ![Creating a new project](images/creating-a-new-project.png?raw=true "Creating a new project")

    _Creating a new project_

3.  Select the **MVC** template and enable **Web API**.

4.  Click **Change Authentication**.

    ![Updating the authentication method](images/updating-the-authentication-method.png?raw=true "Updating the authentication method")

    _Updating the authentication method_

    > **Speaking Point:** VS tooling allows you to enable WAAD authentication easily. All you need is to provide your tenant domain name and administrator credentials, the two-way trust between your WAAD tenant and your web application is automatically configured.

5.  In the **Change Authentication** dialog, select **Organizational Accounts**.

    ![Selecting the Organizational Accounts option](images/selecting-organizational-accounts.png?raw=true "Selecting the Organizational Accounts option")

    _Selecting Organizational Accounts_

6.  Expand the first combo box to show the different options.

    ![Showing the organization account types](images/showing-the-organization-types.png?raw=true "Showing the organization account types")

    _Showing the organization account types_

7.  Expand the **Access Level** combo box to show the different options.

    ![Showing the access level posibilities](images/showing-the-access-level-options.png?raw=true "Showing the access level posibilities")

    _Showing the access level posibilities_

8.  Enter your domain (e.g.: "mydomainname.onmicrosoft.com") as **Domain**.

    ![Setting the domain name](images/updating-the-domain.png?raw=true "TODO")

    _Setting the domain name_

9.  Click the button with the chevron to see more options.

    ![Showing more options](images/showing-more-options.png?raw=true "Showing more options")

    _Showing more options_

10.  Click **OK** to continue.

    ![Completing the authentication update](images/completing-the-authentication-update.png?raw=true "Completing the authentication update")

    _Completing the authentication update_

11.  Sign in using an admin account for your organization (e.g.: "admin@mydomainname.onmicrosoft.com")

    ![Signing in with an organization admin account](images/signing-in-with-an-organization-admin-account.png?raw=true "Signing in with an organization admin account")

    _Signing in with an organization admin account_

12.  Back in the **New ASP.Net Project** dialog, click **OK**.

    ![Completing the project creation](images/creating-the-project.png?raw=true "Completing the project creation")

    _Completing the project creation_

    > **Speaking Point:** VS tooling configures two-way trust relationship between your app and your WAAD tenant. Your app is registered as a Relying Party in the tenant; and the tenant is configured as an Identity Provider for the app.

13.  Press **CTRL+F5** to run the web site.

14.  If a certificate error is displayed, click **Continue to this website**.

15.  Sign in using a user account for your organization (ex. "user@mydomainname.onmicrosoft.com").

    ![Signing in using one of the organization's user account](images/logging-in-with-an-organization-user.png?raw=true "Signing in using one of the organization's user account")

    _Signing in using one of the organization's user account_

16.  Show that you are logged as the organization's user.

    ![Showing that you are logged as the organization's user](images/showing-the-organization-user-logged.png?raw=true "Showing that you are logged as the organization's user")

    _Showing that you are logged as the organization's user_

17.  Close the browser.

### Running the organization's GeekQuiz

1.  Open the **GeekQuiz.sln** solution located under **source\end-segment2**.

2.  Right-click the **GeekQuiz** project and select **Publish…**

    ![Publishing the Website](images/publishing-the-site.png?raw=true "Publishing the Website")

    _Publishing the Website_

3.  In the Publish dialog box, click **Import…**.

    ![Importing the publish profile](images/selecting-the-profile.png?raw=true "Importing the publish profile")

    _Importing the publish profile_

4.  In the **Import Publish Profile** dialog select **Import from a publish profile file** and click **Browse...** to select the previously downloaded publish profile file.

    ![Selecting the publish profile file](images/selecting-import-publish-profile.png?raw=true "Selecting the publish profile file")

    _Selecting the publish profile file_

5.  Back in the **Import Publish Profile** dialog click **OK**.

6.  Back in the **Publish Web** dialog, click **Next**.

    ![Reviewing the connection settings to deploy](images/reviewing-the-connection-settings-to-deploy.png?raw=true "Reviewing the connection settings to deploy")

    _Reviewing the connection settings to deploy_

7.  In the settings tab, show the Organizational Authentication configuration.

    ![Showing the organizational authentication configuration](images/showing-the-organizational-auth-config.png?raw=true "Showing the organizational authentication configuration")

    _Showing the organizational authentication configuration_

8.  Select the connection string for the **TriviaContext** and click **Publish** to publish the site.

9.  Once the browser is opened, sign in using an admin account for your organization (e.g.: "admin@mydomainname.onmicrosoft.com")

    ![Signing in with an organization admin account](images/signing-in-with-an-organization-admin-account.png?raw=true "Signing in with an organization admin account")

    _Signing in with an organization admin account_

10.  When the deployment is completed, sign in using a user account for your organization (e.g.: "user@mydomainname.onmicrosoft.com").

    ![Signing in using one of the organization's user account](images/logging-in-with-an-organization-user.png?raw=true "Signing in using one of the organization's user account")

    _Signing in using one of the organization's user account_

11.  Show that you are logged as the organization's user.

    ![Showing that you are logged as the organization's user](images/showing-the-geekquiz-with-waad.png?raw=true "Showing that you are logged as the organization's user")

    _Showing that you are logged as the organization's user_

12.  Switch to the _Windows Azure Management Portal_.

13.  Navigate to the **Active Directory** section and select the one used for this demo.

    ![Selecting your active directory](images/selecting-your-active-directory.png?raw=true "Selecting your active directory")

    _Selecting your active directory_

14.  Navigate to the **USERS** tab and show the users that you used for the demo.

    ![Showing the organization's users](images/showing-the-organization-users.png?raw=true "Showing the organization's users")

    _Showing the organization's users_

15.  Navigate to the **APPLICATIONS** tab and show the new two applications, which were automatically created.

    ![Showing the organization's applications](images/showing-the-geekquiz-application-in-the-portal.png?raw=true "Showing the organization's applications")

    _Showing the organization's applications_

## Summary

By completing this demo you learned how to integrate your website with an existing WAAD tenant.