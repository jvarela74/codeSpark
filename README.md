# codeSpark
Application Tools Developer Test

This project requires Visual Studio 2019 and MongoDB Compass Community in a Windows environment.

Download all three folders:

- codeSpark - This folder contains the main solution file (codeSpark.sln) and csproj file for the main application.
- codeSpark_Utility - This folder contains the codeSpark_Utility.dll code .
                      This contains all necessary functions to access and display the codespark database.
- database - This folder contains both json and csv files of the mongodb dump.

Install MongoDB. (https://docs.mongodb.com/manual/tutorial/install-mongodb-on-windows/)

Open MongoDB Compass Community and create a local database called 'codespark'.

Create the following collections:
- student
- teacher
- user

Import the corresponding json file to populate each of the collections:
- Import student.json to codespark.student
- Import teacher.json to codespark.teacher
- Import user.json to codespark.user

Note the HOST value of the local connection.

Open the codeSpark.sln file. The solution should contain two projects:
- codeSpark
- codeSpark_Utility

Restore NuGet packages at the solution level.

In the codeSpark_Utility project, locate the following line:
  private const string CONNECTION_STRING = "mongodb://localhost:27017";

Replace the CONNECTION_STRING value with your appropriate local HOST value.

Build and Run.

