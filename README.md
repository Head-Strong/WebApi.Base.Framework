# WebApi.Base.Framework

Following features are implemented :

a) Swagger

b) Owin Self Hosting. [WebApi.Owin.SelfHost]

c) Filter Provider.

d) Model Validator.

f) In Memory Database.

g) Unity IOC.

h) Model Binder.

i) Message Handler.

j) Basic Authentication.

k) Identity Server 3 Setup is done.

l) Identity Server Authentication / Authorization
 
Pending features : 

a) MongoDB 



Request Header :

content-type: application/json

Authorization: YWRpdHlhOnRlc3Q=


How to access customer service ?

Get :

http://localhost:50950/api/customer

http://localhost:50950/api/customer/1

Async Methods : 

GET:  http://localhost:50950/api/customer/async

GET:  http://localhost:50950/api/customer/async/1

POST: http://localhost:50950/api/customer/async

DELETE: http://localhost:50950/api/customer/async/1


How to access Swagger ?

http://localhost:50950/swagger/ui/index

How to save customer ?

Url : http://localhost:50950/api/customer/post

Body :

{

      "Name":"XYZ",
      
      "LastName":"ABC",
      
      "Id":-1
      
}


Url : http://localhost:2020/connect/token

OAuth2 Identity Server Settings : 
---------------------------------
client_id : oauth2_api
client_secret : oauth2apiservicessecret
grant_type : password
scope : openid profile roles email
username : aditya
password : test

x-www-form-urlencoded



How to setup owinself host application as Windows Service ?

-- Install Windows Service
C:\Windows\Microsoft.NET\Framework\v4.0.30319>InstallUtil.exe 

"C:\Users\Aditya\Documents\Visual Studio 2015\Projects\WebApi.Base.Framework\WebApi.Owin.SelfHost\bin\Debug\WebApi.Owin.SelfHost.exe"

-- Uninstall Windows Service
C:\Windows\Microsoft.NET\Framework\v4.0.30319>InstallUtil.exe /u 
"C:\Users\Aditya\Documents\Visual Studio 2015\Projects\WebApi.Base.Framework\WebApi.Owin.SelfHost\bin\Debug\WebApi.Owin.SelfHost.exe"
