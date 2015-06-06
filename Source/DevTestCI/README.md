<h1>Geek Quiz Dev/Test and Continuous Integration</h1>

<p>[Description]</p>

<h2>Objectives</h2>

<ol>
<li>Demonstrate Continuous Integration between Visual Studio Online (TFS) with Windows Azure Web Sites</li>
<li>How to achieve continuous integration when leveraging continuous delivery from GitHub</li>
<li>How to Configure multiple environments for Dev/Test using branching</li>
</ol>

<h2>Prerequisites</h2>

<ol>
<li>Git Source Control Managemenet</li>
<li>Visual Studio Online Account</li>
<li>Windows Azure Xplat CLI Tools</li>
</ol>

<h2>Pre-Configuration</h2>

<p>Follow these steps to setup your environment prior to your presentation.</p>

<h3>Demonstrate Continuous Integration between Visual Studio Online (TFS) with Windows Azure Web Sites</h3>

<ol>
<li>Checking in the GeekQuiz Application</li>
<li>Create a Branch of GeekQuiz</li>
</ol>

<h4>Checking in the GeekQuiz Application</h4>

<ol>
<li>Sign into your <a href="http://tfs.visualstudio.com">Visual Studio Online</a> account.</li>
<li> Create a new Team Project

<ol>
<li>Click on New Team Project</li>
<li>Enter a Name, Description</li>
<li>Select TFVS Source Control</li>
<li>Click Create.</li>
</ol></li>
<li>Connect to your team project in Visual Studio

<ol>
<li>Open the <strong>Team</strong> menu</li>
<li>Select <strong>Connect to Source Control</strong></li>
<li>Click on Servers...</li>
<li>Enter your Visual Studio Online URL (e.g. [username].visualstudio.com)</li>
<li>Click OK</li>
<li>Select the GeekQuiz Team Project which was created in step 2.</li>
<li>Map the Team Project to a local Workspace </li>
</ol></li>
<li>Check-in the GeekQuiz Application

<ol>
<li>Source Code Explorer</li>
<li>Open the GeekQuiz Node</li>
<li>Right-click on GeekQuiz, Select Add Files.</li>
<li>Create a new folder called GeekQuiz in the Repository</li>
<li>Browse to the source directory for this lab (e.g. C:\WCTK\Demos\Dev-Test-CI\source)</li>
<li>Add all of the files contained in Source to the GeekQuiz directory.</li>
<li>Click Check-in</li>
</ol></li>
</ol>

<h4>Create a branch of GeekQuiz</h4>

<ol>
<li></li>
<li></li>
</ol>

<h3>How to achieve continuous integration when leveraging continuous delivery from GitHub</h3>

<ol>
<li>Check-in the GeekQuiz Application to GitHub</li>
<li>Create a GitHub connected Windows Azure Web Site</li>
</ol>

<h4>Check-in the GeekQuiz Application to GitHub</h4>

<ol>
<li>Sign into <a href="https://github.com">GitHub</a></li>
<li>Create a New Repository</li>
<li>Copy the SSH or HTTPS url for your repository to the clipboard</li>
<li>Navigate to the source directory</li>
<li><p>Execute the following commands:</p>

<pre>
git init
git remote add origin [paste repo url here]
git add -A
git commit -m "initial commit"
git push origin master
</pre></li>
</ol>

<h4>Create a GitHub connected Windows Azure Web Site</h4>

<ol>
<li><p>Execute the following command:</p>

<pre>
azure site create [unique-dns-name] --github --githubusername [username] --githubpassword [password] --location [datacenter-to-deploy]
</pre></li>
<li><p>Enter the number for the Repository to connect to (created in previous step)</p></li>
</ol>

<h3>How to Configure multiple environments for Dev/Test using branching</h3>

<ol>
<li><p>Create a new branch of your GeekQuiz Repository:</p>

<pre>
git checkout -b dev
git push origin dev
</pre></li>
<li><p>Follow instructions for **Create a GitHub connected Windows Azure Web Site' add <code>-dev</code> to the end of the DNS name and select the same repository as before</p></li>
</ol>

<h2>Demo Walk-through</h2>

<h3>Demonstrate Continuous Integration between Visual Studio Online (TFS) with Windows Azure Web Sites</h3>

<ol>
<li>Create a Visual Studio Online connected Windows Azure Web Site</li>
<li>Check-in a Code Change</li>
<li>Show Visual Studio Online TFS Environment</li>
</ol>

<h4>Create a Visual Studio Online connected Windows Azure Web Site</h4>

<ol>
<li>Sign into the <a href="http://manage.windowsazure.com">Windows Azure Management Portal</a></li>
<li>Click <strong>New +</strong></li>
<li>Hover over Web Site</li>
<li>Click on <strong>Custom Create</strong></li>
<li>Enter a DNS name</li>
<li>Select a Data Center to deploy to (preferably the closest one to your present location)</li>
<li>Check the Deploy from Source Control checkbox</li>
<li>Click the arrow to navigate to the next screen</li>
<li>Select TFS from the list of source control options</li>
<li>Click the arrow to navigate to the next screen</li>
<li>Enter the name of your Visual Studio Online account</li>
<li>Click validate</li>
<li>Select the GeekQuiz Team Project</li>
<li>Click the checkmark to Create the new Site.</li>
</ol>

<h4>Check-in a Code Change</h4>

<ol>
<li>In Visual Studio modify <code>~/Views/Home/Index.cshtml</code></li>
<li>Click on Team Explorer, under Solution Explorer</li>
<li>Click on Pending Changes</li>
<li>Add a commit message</li>
<li>Press Check-in</li>
</ol>

<h4>Show Visual Studio Online TFS Environment</h4>

<ol>
<li>Switch to your Browser with Visual Studio Online open</li>
<li>Navigate to the <strong>Code</strong> tab</li>
<li>Navigate to the <strong>Build</strong> tab</li>
</ol>

<h3>How to achieve continuous integration when leveraging continuous delivery from GitHub</h3>

<ol>
<li>Generate Custom Deployment Script using Xplat CLI Tools</li>
<li>Customize Deployment Script to run MSTest Unit Tests</li>
<li>Check-in/Push Deployment Script to GitHub to Deploy </li>
<li>Show Deployment Log</li>
</ol>

<h4>Generate Custom Deployment Script using Xplat CLI Tools</h4>

<ol>
<li>Open a Command Shell Window</li>
<li>Change the PWD to the GeekQuiz Solution (.sln) folder</li>
<li>Show off the ASCII Art by executing the <code>azure</code> command</li>
<li><p>Generate a customer deployment script by running the following command:</p>

<pre>
azure site deploymentscript --aspWAP ..\GeekQuiz\GeekQuiz.csproj -s GeekQuiz.sln 
</pre></li>
</ol>

<h4>Customize Deployment Script to run MSTest Unit Tests</h4>

<ol>
<li><p>Add the following lines of code at line 72 in the Deploy.cmd file</p>

<pre>
:: 2. Build the Unit Test Project.
%MSBUILD_PATH% "%DEPLOYMENT_SOURCE%\GeekQuiz.Tests\GeekQuiz.Tests.csproj" /t:Build /p:Configuration=Release
IF !ERRORLEVEL! NEQ 0 goto error

:: 3. Run Unit Test Project
vstest.console.exe "%DEPLOYMENT_SOURCE%\GeekQuiz.Tests\bin\Release\GeekQuiz.Tests.dll
IF !ERRORLEVEL! NEQ 0 goto error
</pre></li>
<li><p>Save &amp; Close the file</p></li>
</ol>

<h4>Check-in/Push Deployment Script to GitHub to Deploy</h4>

<ol>
<li><p>Run the following commands to Check-in and Push the deployment scripts to GitHub</p>

<pre>
git add -A
git commit -m "added custom deployment script"
git push origin master
</pre></li>
</ol>

<h4>Show Deployment Log</h4>

<ol>
<li>Open the Windows Azure Management Portal</li>
<li>Navigate to the Deployment Tab of the Web Site</li>
<li>Click on the active deployment</li>
<li>Click on the glyph</li>
<li>Under Running Custom Deployment Script, click <strong>View Log</strong></li>
<li>Scroll down the logs until you can show the Unit Tests Passing</li>
</ol>

<h3>How to Configure multiple environments for Dev/Test using branching</h3>

<ol>
<li>Configure Windows Azure Web Site to Deploy from a branch (GitHub)</li>
<li>Modify the TFS Deployment Script to Deploy from a branch in Windows Azure Web Sites</li>
</ol>

<h4>Configure Windows Azure Web Site to Deploy from a branch (GitHub)</h4>

<ol>
<li>Navigate to the Configuration tab of the '-dev' (pre-configured) Web Site</li>
<li>Scroll down too <strong>Branch to deploy</strong></li>
<li>Change the branch name in the text box from <strong>master</strong> to <strong>dev</strong></li>
<li>Click on the Save button in the command bar</li>
</ol>

<h4>Modify the TFS Deployment Script to Deploy from a branch in Windows Azure Web Sites</h4>

<ol>
<li></li>
</ol>
