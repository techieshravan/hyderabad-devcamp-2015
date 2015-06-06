
# Scaling a production web site

## Overview

In this demo you will go through the steps required to configure auto-scaling in a _Azure Web Site_ and demostrate this feature using a Visual Studio Load test. Additionally, you will see how to scale a site using _Azure Storage_.

### Goals

In this demo, you will see how to:

1.  Configure auto-scaling for a website using the _Azure portal_
2.  Create and configure a load test project in _Visual Studio_
3.  Use _Azure Storage_ to scale a website

### Key Technologies

* [Microsoft Visual Studio 2013](http://www.microsoft.com/visualstudio/eng/visual-studio-2013)
* [Azure](http://www.windowsazure.com)

### Setup and Configuration

Follow these steps to setup your environment for the demo.

1. Follow the steps detailed in [this link](http://docs.nuget.org/docs/creating-packages/hosting-your-own-nuget-feeds) to setup local sources for the following directories:

    1.  **C:\Program Files (x86)\Microsoft Web Tools\Packages**
    2.  **C:\Program Files (x86)\Microsoft ASP.NET\ASP.NET Web Stack 5\Packages**

    ![NuGet Sources](images/nuget-sources.png?raw=true)

3.  Create a _Azure storage account_ (e.g. _geekquizstorage_), create a blob container named _images_ and upload the **logo-big.png** image located inside the **source\assets** folder.

4.  Open the **GeekQuiz.sln** solution located under the **source\end** folder. Find the '<system.webserver>' element in the **web.config** file and change the url of the **Redirect** action using the _Azure storage account_ you have just created.</system.webserver>

    ![Updating the Rewrite Rule](images/highlighting-rewrite-rule.png?raw=true "Updating the Rewrite Rule")

    _Updating the Rewrite Rule_

5.  Create a (free) web site in Azure and deploy the web site that is part of the **GeekQuiz.sln** solution located under the **source\end** folder.

6.  Register a new user account.

7.  Open the **StressGeekQuiz.sln** solution located under **source\end**.

8.  In the **Solution Explorer**, double-click **WebTest1.webtest**.

9.  Select the **[http://geekquizdemo.azurewebsites.net](http://geekquizdemo.azurewebsites.net)** node, as shown in the following figure.

    ![Selecting the Loop child node](images/node-selection.png?raw=true "Selecting the Loop child node")

    _Selecting the Loop child node_

10.  In the **Properties** window, update the **Url** field to point to the site you just created.

    ![Changing the Url](images/url-change.png?raw=true "Changing the Url")

    _Changing the Url_

11.  Save all files and close the solution.

## Demo

This demo is composed of the following segments:

1.  [Configuring auto-scaling](#segment1)
2.  [Load testing with Visual Studio](#segment2)
3.  [Scaling GeekQuiz using Azure storage](#segment3)
4.  [Auto-scaling result](#segment4)

### Configuring auto-scaling

1. Open the [Azure Management portal](https://manage.windowsazure.com/) and log in with your credentials.

2.  Select the **WEB SITES** tab.

    ![Opening the Web site tab](images/web-sites.png?raw=true "Opening the Web site tab")

    _Opening the Web site tab_

3.  Click the website where you deployed GeekQuiz during the setup steps.

4.  Open the scaling configuration page.

    ![Opening the Scaling configuration page](images/scale.png?raw=true "Opening the Scaling configuration page")

    _Opening the Scaling configuration page_

5.  Change the web site's mode to **Standard**.

    ![Changing the web site's mode to Standard](images/web-site-mode.png?raw=true "Changing the web site's mode to Standard")

    _Changing the web site's mode to Standard_

6.  Clear all other web sites from the list of sites to be updated.

    ![Clearing all other Web Sites](images/clear-web-sites.png?raw=true "Clearing all other Web Sites")

    _Clearing all other Web Sites_

7.  Show that there is only one instance.

    ![Showing that there is only one instance](images/one-instance.png?raw=true "Showing that there is only one instance")

    _Showing that there is only one instance_

8.  Select the **CPU** metric for scaling.

    ![Selecting the CPU metric for scaling](images/cpu-scaling.png?raw=true "Selecting the CPU metric for scaling")

    _Selecting the CPU metric for scaling_

9.  Change the target CPU to **20**-**40**.

    ![Changing the target CPU](images/target-cpu.png?raw=true "Changing the target CPU")

    _Changing the target CPU_

    > **Speaking point:** Explain that this is done as we cannot ensure that a bigger load is generated with VS.

10.  Save the changes.

    > **Note:** Don't close the management portal.

### Load testing with Visual Studio

1.  Open the **StressGeekQuiz.sln** solution located under **source\end**.

2.  In the **Solution Explorer**, double-click **LoadTest1.loadtest**.

3.  Run the load test.

    ![Running the load test](images/run-load-test.png?raw=true "Running the load test")

    _Running the load test_

4.  Open a new instance of Visual Studio.

    > **Speaking point:** Let's take a look at how that solution can be built.

5.  Open the **New Project** dialog.

6.  Select **Test** in the templates tree, and select **Web Performance and Load Test project**.

    ![Creating the new load test project](images/test-project.png?raw=true)

    _Creating the new load test project_

7.  Click **OK**.

8.  Right-click **WebTest1** and select **Add Request**.

    ![Adding a request](images/add-request.png?raw=true "Adding a request")

    _Adding a request_

9.  Select the new node.

10.  In the **Properties** window, update the **Url** field to point to the Azure web site.

    ![Changing the Url property](images/url-change.png?raw=true "Changing the Url property")

    _Changing the Url property_

11.  Right-click **WebTest1** and select **Add Loop...**.

    ![Adding a loop](images/add-loop.png?raw=true "Adding a loop")

    _Adding a loop_

12.  Select the **For Loop** rule.

    ![Selecting the For Loop](images/for-loop.png?raw=true "Selecting the For Loop")

    _Selecting the For Loop_

13.  Update the following values:

    1.  **Terminating value:** 1000.
    2.  **Context Parameter Name:** Iterator.
    3.  **Increment Value:** 1.

    ![Updating the configuration values](images/values.png?raw=true "Updating the configuration values")

    _Updating the configuration values_

14.  Select the GeekQuiz request as the first and last item of the loop.

    ![Selecting the items for the loop](images/items.png?raw=true "Selecting the items for the loop")

    _Selecting the items for the loop_

15.  Click **OK**.

16.  In the **Solution Explorer**, right-click the **WebAndLoadTestProject1** project, expand the **Add** menu and select **Load Test...**. A wizard will start.

    ![Adding a Load Test](images/load-test.png?raw=true "Adding a Load Test")

    _Adding a Load Test_

17.  In the **New Load Test Wizard** dialog, click **Next**.

18.  Select **Do not use think times** and click **Next**.

    ![Selecting not to use Think times](images/think-times.png?raw=true "Selecting not to use Think times")

    _Selecting not to use Think times_

19.  Change the **User Count** to **250** users and click **Next**.

    ![Changing the user count](images/user-count.png?raw=true "Changing the user count")

    _Changing the user count_

20.  Select **Based on sequential test order** and click **Next**.

    ![Selecting the test mix model](images/text-mix.png?raw=true "Selecting the test mix model")

    _Selecting the test mix model_

21.  Click **Add...**.

22.  Double-click **Web Test 1** and click **OK**.

    ![Adding the test](images/add-tests.png?raw=true "Adding the test")

    _Adding the test_

23.  Click **Next**.

24.  In the **Network Mix** page, click **Next**.

25.  Select **Internet Explorer 10.0** as the browser type and click **Next**.

    ![Selecting the Browser Type](images/browser-type.png?raw=true "Selecting the Browser Type")

    _Selecting the Browser Type_

26.  In the **Counter Sets** page, click **Next**.

27.  Set the load test duration to 5 minutes and click **Finish**.

    ![Setting the load test duration](images/load-test-duration.png?raw=true "Setting the load test duration")

    _Setting the load test duration_

28.  Close the current instance of **Visual Studio**.

### Scaling GeekQuiz using Azure storage

1. Open _Internet Explorer_.
   
2. Navigate to the image that you uploaded to Azure Storage during setup. For example, if the name of the storage account is _geekquizstorage_ the URL for the image will be [http://geekquizstorage.blob.core.windows.net/images/logo-big.png](http://geekquizstorage.blob.core.windows.net/images/logo-big.png).

    ![Showing the logo](images/logo-big.png?raw=true "Showing the logo")

    _Showing the logo_

3.  Open the **GeekQuilz.sln** solution located under **source\end**.

4.  Open the site's **web.config** file for edition.

5.  Find the `<system.webServer>` element.

6.  Highlight the URL rewrite rule as shown in the following figure.

    ![Highlighting the Rewrite Rule](images/highlighting-rewrite-rule.png?raw=true "Highlighting the Rewrite Rule")

    _Highlighting the Rewrite Rule_

7.  Back in Internet Explorer, open the deployed GeekQuiz site (log in if necessary).

    ![Showing the Geek Quiz website with the image](images/geek-quiz-with-image.png?raw=true "Showing the Geek Quiz website with the image")

    _Showing the Geek Quiz website with the image_

8.  Press **F12** to launch the development tools, select the **Network** tab and start recording.

    ![Starting the network recording](images/start-recording.png?raw=true "Starting the network recording")

    _Starting the network recording_

9.  Press **CTRL + F5** to refresh the web page.

10.  Once the page has finished loading, switch back to the development tools and show that the request for the image was redirected to _Azure storage_.

    ![Showing the redirect in Dev Tools](images/redirect-in-dev-tools.png?raw=true "Showing the redirect in Dev Tools")

    _Showing the redirect in Dev Tools_

### Auto-scaling result

1.  Back in the management portal, press **CTRL + F5** to refresh the page.

2.  Show that a new instance was automatically deployed.

    ![Showing that the new instance](images/new-instance.png?raw=true "Showing that the new instance")

    _Showing that the new instance_

## Summary

By completing this demo you should have:

1.  Configured auto-scaling for a website using the _Azure portal_
2.  Created a load test project in _Visual Studio_
3.  Used _Azure Storage_ to scale the static content of a web site
