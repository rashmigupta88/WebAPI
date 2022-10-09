# WebAPI

![image](https://user-images.githubusercontent.com/44660748/194773093-7410b4f7-7073-4539-9a90-bea57438cf9b.png)

Step 1: Create a Remote VM on Azure that will have a ansible installed and configured . Port 22 will be open so that VM connection via SSH is possible . Azure modules will be installed on the ansible VM and authentication to azure subscription will be achieved via secret file created in Ansible VM . 

Step 2 : Create a Azure DEvops Organisation and and establish Service connection between Ansible VM via SSH and rsa private key . 

Step 3 : Build pipeline will be executed to build the .net project and using Nuget restore . After building the package it will store the package on azure artifact . Along with this it will copy the webapp.yml file used by ansible to build the Infrastructure needed to deploy my application on azure and then deploy my .net packge on the webapp . 

Step 4: Ansible playbbok willl run remotely on ansible VM . It will first create azure SP , webapp , SQL database and firewall rule to allow azure webapp to access SQL database . Once infra is ready the pipeline wil start pick up the packge and deploy the packge to the webapp which is package file and extracting all the files on the web app so the web app now has all my application deploying. Then this application wil use the SQL database . 

Step 5 : Now I can open the application from the browser and see the time stamp created in database whever accessed . 


Making Web app Elastic in Nature : 


Azure App Services currently provides two workflows for scaling: scale up and scale out.

Scale up: Get more CPU, memory, disk space, and extra features. You scale up by changing the pricing tier of the App Service plan that your app belongs to.
Scale out: Increase the number of VM instances that run your app. You can scale out to as many as 30 instances, depending on your pricing tier. App Service Environments in Isolated tier further increases your scale-out count to 100 instances. You can scale manually or automatically based on predefined rules and schedules.

Automatic scaling is available only for Azure App Services Premium Pv2 and Pv3 SKUs

Option 1 :

Step1 :
This option enables automatic scaling for your existing app service plan and web apps within this plan. We can set the value of maximum automatic scale for the app service plan using this step.

 

az appservice plan update --name <<app service plan name>> --resource-group "resource group name" --elastic-scale true | false --max-elastic-worker-count <<max number of workers for app service plan automatic scale >>

Step2:
This step enables minimum number of instances that your web app will always be available on (per app scaling) and also enables the number of pre-warmed instances readily available for your web app to scale (buffer instances).

 

az webapp update -g <<resource group name>> -n <<web app name>> --minimum-elastic-instance-count <<number of always available instances for the web app>> --prewarmed-instance-count <<number of buffer instances available for the web app >>

 

 az webapp update -g sampleResourceGroup -n sampleWebApp  --minimum-elastic-instance-count 5 --prewarmed-instance-count 1 [This configures 5 as the minimum number of instances that your web app will always be available on (per app scaling) and also configures 1 as the number of pre-warmed instances readily available for your web app to scale (buffer instances).
 
 
 


 
 
