# WebApi.Base.Framework

Following features are implemented :
a) Swagger
b) Owin Self Hosting. [WebApi.Owin.SelfHost]
c) Filter Provider.
d) Model Validator.
f) In Memory Database.
g) Unity IOC

Pending features : 
a) Model Binder
b) Message Handler.
c) MongoDB 
d) Authentication / Authorization

How to access customer service ?
Get :
http://localhost:50950/api/customer
http://localhost:50950/api/customer/1

How to access Swagger ?
http://localhost:50950/swagger/ui/index


How to setup owinself host application as Windows Service ?

-- Install Windows Service
C:\Windows\Microsoft.NET\Framework\v4.0.30319>InstallUtil.exe 

"C:\Users\Aditya\Documents\Visual Studio 2015\Projects\WebApi.Base.Framework\WebApi.Owin.SelfHost\bin\Debug\WebApi.Owin.SelfHost.exe"

-- Uninstall Windows Service
C:\Windows\Microsoft.NET\Framework\v4.0.30319>InstallUtil.exe /u 
"C:\Users\Aditya\Documents\Visual Studio 2015\Projects\WebApi.Base.Framework\WebApi.Owin.SelfHost\bin\Debug\WebApi.Owin.SelfHost.exe"
