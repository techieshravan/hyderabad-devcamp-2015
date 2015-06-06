# Geek Quiz Dev/Test and Continuous Integration

## Objectives

1.  Demonstrate Continuous Integration between Visual Studio Online (TFS) with Windows Azure Web Sites
2.  How to achieve continuous integration when leveraging continuous delivery from GitHub
3.  How to Configure multiple environments for Dev/Test using branching

## Prerequisites

1.  Git Source Control Managemenet
2.  Visual Studio Online Account
3.  Windows Azure Xplat CLI Tools

## Pre-Configuration

Follow these steps to setup your environment prior to your presentation.

### Demonstrate Continuous Integration between Visual Studio Online (TFS) with Windows Azure Web Sites

1.  Checking in the GeekQuiz Application
2.  Create a Branch of GeekQuiz

#### Checking in the GeekQuiz Application

1.  Sign into your [Visual Studio Online](http://tfs.visualstudio.com) account.
2.  Create a new Team Project
    1.  Click on New Team Project
    2.  Enter a Name, Description
    3.  Select TFVS Source Control
    4.  Click Create.
3.  Connect to your team project in Visual Studio
    1.  Open the **Team** menu
    2.  Select **Connect to Source Control**
    3.  Click on Servers...
    4.  Enter your Visual Studio Online URL (e.g. [username].visualstudio.com)
    5.  Click OK
    6.  Select the GeekQuiz Team Project which was created in step 2.
    7.  Map the Team Project to a local Workspace
4.  Check-in the GeekQuiz Application
    1.  Source Code Explorer
    2.  Open the GeekQuiz Node
    3.  Right-click on GeekQuiz, Select Add Files.
    4.  Create a new folder called GeekQuiz in the Repository
    5.  Browse to the source directory for this lab (e.g. C:\WCTK\Demos\Dev-Test-CI\source)
    6.  Add all of the files contained in Source to the GeekQuiz directory.
    7.  Click Check-in

#### Create a branch of GeekQuiz

### How to achieve continuous integration when leveraging continuous delivery from GitHub

1.  Check-in the GeekQuiz Application to GitHub
2.  Create a GitHub connected Windows Azure Web Site

#### Check-in the GeekQuiz Application to GitHub

1.  Sign into [GitHub](https://github.com)
2.  Create a New Repository
3.  Copy the SSH or HTTPS url for your repository to the clipboard
4.  Navigate to the source directory
5.  Execute the following commands:

    <pre>
    $ git init
    $ git remote add origin [paste repo url here]
    $ git add -A
    $ git commit -m "initial commit"
    $ git push origin master
    </pre>

#### Create a GitHub connected Windows Azure Web Site

1.  Execute the following command:

    <pre>azure site create [unique-dns-name] --github --githubusername [username] --githubpassword [password] --location [datacenter-to-deploy]
    </pre>

2.  Enter the number for the Repository to connect to (created in previous step)

### How to Configure multiple environments for Dev/Test using branching

1.  Create a new branch of your GeekQuiz Repository:

    <pre>
    $ git checkout -b dev
    $ git push origin dev
    </pre>

2.  Follow instructions for **Create a GitHub connected Windows Azure Web Site' add `-dev` to the end of the DNS name and select the same repository as before

## Demo Walk-through

### Demonstrate Continuous Integration between Visual Studio Online (TFS) with Windows Azure Web Sites

1.  Create a Visual Studio Online connected Windows Azure Web Site
2.  Check-in a Code Change
3.  Show Visual Studio Online TFS Environment

#### Create a Visual Studio Online connected Windows Azure Web Site

1.  Sign into the [Windows Azure Management Portal](http://manage.windowsazure.com)
2.  Click **New +**
3.  Hover over Web Site
4.  Click on **Custom Create**
5.  Enter a DNS name
6.  Select a Data Center to deploy to (preferably the closest one to your present location)
7.  Check the Deploy from Source Control checkbox
8.  Click the arrow to navigate to the next screen
9.  Select TFS from the list of source control options
10.  Click the arrow to navigate to the next screen
11.  Enter the name of your Visual Studio Online account
12.  Click validate
13.  Select the GeekQuiz Team Project
14.  Click the checkmark to Create the new Site.

#### Check-in a Code Change

1.  In Visual Studio modify `~/Views/Home/Index.cshtml`
2.  Click on Team Explorer, under Solution Explorer
3.  Click on Pending Changes
4.  Add a commit message
5.  Press Check-in

#### Show Visual Studio Online TFS Environment

1.  Switch to your Browser with Visual Studio Online open
2.  Navigate to the **Code** tab
3.  Navigate to the **Build** tab

### How to achieve continuous integration when leveraging continuous delivery from GitHub

1.  Generate Custom Deployment Script using Xplat CLI Tools
2.  Customize Deployment Script to run MSTest Unit Tests
3.  Check-in/Push Deployment Script to GitHub to Deploy
4.  Show Deployment Log

#### Generate Custom Deployment Script using Xplat CLI Tools

1.  Open a Command Shell Window
2.  Change the PWD to the GeekQuiz Solution (.sln) folder
3.  Show off the ASCII Art by executing the `azure` command
4.  Generate a customer deployment script by running the following command:

    <pre>azure site deploymentscript --aspWAP ..\GeekQuiz\GeekQuiz.csproj -s GeekQuiz.sln 
    </pre>

#### Customize Deployment Script to run MSTest Unit Tests

1.  Add the following lines of code at line 72 in the Deploy.cmd file

    <pre>
    :: 2\. Build the Unit Test Project.
    %MSBUILD_PATH% "%DEPLOYMENT_SOURCE%\GeekQuiz.Tests\GeekQuiz.Tests.csproj" /t:Build /p:Configuration=Release
    IF !ERRORLEVEL! NEQ 0 goto error

    :: 3\. Run Unit Test Project
    vstest.console.exe "%DEPLOYMENT_SOURCE%\GeekQuiz.Tests\bin\Release\GeekQuiz.Tests.dll
    IF !ERRORLEVEL! NEQ 0 goto error
    </pre>

2.  Save & Close the file

#### Check-in/Push Deployment Script to GitHub to Deploy

1.  Run the following commands to Check-in and Push the deployment scripts to GitHub

    <pre>
    $ git add -A
    $ git commit -m "added custom deployment script"
    $ git push origin master
    </pre>

#### Show Deployment Log

1.  Open the Windows Azure Management Portal
2.  Navigate to the Deployment Tab of the Web Site
3.  Click on the active deployment
4.  Click on the glyph
5.  Under Running Custom Deployment Script, click **View Log**
6.  Scroll down the logs until you can show the Unit Tests Passing

### How to Configure multiple environments for Dev/Test using branching

1.  Configure Windows Azure Web Site to Deploy from a branch (GitHub)
2.  Modify the TFS Deployment Script to Deploy from a branch in Windows Azure Web Sites

#### Configure Windows Azure Web Site to Deploy from a branch (GitHub)

1.  Navigate to the Configuration tab of the '-dev' (pre-configured) Web Site
2.  Scroll down too **Branch to deploy**
3.  Change the branch name in the text box from **master** to **dev**
4.  Click on the Save button in the command bar
