# IncomeTaxCalculatorAWS

**IncomeTaxCalculator** is an **AWS Lambda Function** developed in Visual Studio 2019 using **AWS Lambda Project Template**. The main purpose of this function is to calculate the income tax one hase to pay based on a number of tax bands. The project has the following specifications:

- the tax bands are stored in an **Amazon RDS SQL Server database**
  
  ![image](https://user-images.githubusercontent.com/9264427/116779852-711a8a80-aa81-11eb-8bb7-563fa50133e9.png)

- the database connection string used to get the tax bands data is stored in a **Secret Key** created with **AWS Secrets Manager**
  
  ![image](https://user-images.githubusercontent.com/9264427/116779961-fef67580-aa81-11eb-932e-b5f003a6f1c6.png)

- the Lambda function is exposed through a **Gateway API**
  
  ![image](https://user-images.githubusercontent.com/9264427/116779737-c1ddb380-aa80-11eb-9ec5-25f1b907678b.png)

- you can access the API at the following URL:
  
  **https://xbalo2zy2l.execute-api.us-east-1.amazonaws.com/test**
  
    Usage example:
    
    HTTP Method: **POST**
    Request template 
          {
              "Income": 52000,
              "Detailed": true
          }
  
  **Detailed** parameter is optional, and it's default value is false
  
  I have used Postman to trigger this Lambda function like in the below example:
  
  ![image](https://user-images.githubusercontent.com/9264427/116780119-1c780f00-aa83-11eb-82c7-2fed2ea1c44f.png)

  
