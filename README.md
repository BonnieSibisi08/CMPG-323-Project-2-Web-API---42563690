# Project 2 Web API - 42563690

# Overview
This project involves developing a RESTful API designed to track and manage telemetry data related to automation processes. The core objective is to measure the time saved by each automation run and associate this with a cost, grouping the results by project and client.  

The RESTful API will facilitate the management of this data through a set of standard HTTP methods (GET, POST, PATCH, and DELETE) to handle Create, Read, Update, and Delete (CRUD) operations. This API will connect to a database where telemetry data is stored, allowing for efficient data retrieval and manipulation.  

The use of RESTful APIs ensures that the system adheres to industry best practices for longevity and integration, enabling the NWU Tech Trends Management System to be managed effectively through cloud-based services.  

# How to use the API  
1. Firstly navigate to the following site: [Project 2 Web API](https://project2webapi-42563690.azurewebsites.net)  
2. After you will be taken the following screen:   
![Screenshot 2024-08-12 131734](https://github.com/user-attachments/assets/21d10a76-7163-4301-818e-857a98d527bb)  
3. Under Categories as shown in the screen is where you can Get, Create, Update, and Delete records but firslty you would have to login.
4. Under Authenticate there are three post methods. The first one is used to login, provided that you already have an account. The remaining two methods are to register an account as normal user or admin.
5. To login select  the "/login" post method the click 'Try it out': Use the following credentials to login "username: vusi12" and "password: Vusi@1297" then click execute.
![Screenshot 2024-08-12 132956](https://github.com/user-attachments/assets/292473bd-3da2-4e6e-92a6-caf3b46b557a)
6. After you have logged in successfully, scroll down a bit a token will be generated. Copy that token
![Screenshot 2024-08-12 133942](https://github.com/user-attachments/assets/1278450e-8dbe-4888-bec0-a578cb49d14e)
7. At the top you will find "Authorize" click on it
   ![Screenshot 2024-08-12 134054](https://github.com/user-attachments/assets/ffee9621-8b6d-4fb8-9db3-ada96ef98f1b)
8. A screen will appear, then on "Value:" enter the token you have just copied, then click authorize.
![Screenshot 2024-08-12 134133](https://github.com/user-attachments/assets/d21e4997-de1e-417f-bc29-5ea746fd54ba)
9. After you have successfully authorized yourself, all the locks on the screeen will be now closed.
![Screenshot 2024-08-12 134633](https://github.com/user-attachments/assets/b9e24c7b-7872-4ab5-9a3d-0b030a1d29fd)
10. Now you will be able to access all the methods in the categories.

