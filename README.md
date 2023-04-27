## Impinj Coding Assesment:

```
TIME:            2-3 hours
LANGUAGES:       C# preferred
FRAMEWORKS:      NET or NET CORE preferred,
TEST FRAMEWORKS: MS BUILD/NUNIT/XUNIT preferred
TYPE:            Web Api
FILES:           In repository
TESTS:           preferred
SUBMIT:          ZipFile, Github Repository Link
```

## Overview:
This exercise is to asses a candidates ability to design and implement a solution to a problem in a given period of time.

We want to see a demonstration of your thought process, skills and development experiences.

This solution should be able to run locally.

_Be prepared to explain your design decisions and architecture!_


## Problem:
Create a web API that can parse a sales record file into an object. The API should return an object with the following fields:
* The median Unit Cost
* The most common Region
* The first and last Order Date and the days between them
* The total revenue


## Included:
* Sample input at `Input\SalesRecords.csv`
* A git ignore file for a C# project
* A git attributes file

<br></br>

_Hint: a web api skeleton can be created with `dotnet new webapi`_

## Solution:
To run this solution effectively, make sure that the following requirements are met on the local host:
* Download and Install .NET SDK preferably version 7.0 (_https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/sdk-7.0.203-windows-x64-installer_)
* Download and install the CSV Helper package:
        `dotnet add package CsvHelper --version 30.0.1`

Start the web server by running the folowing command inside the project folder (cmd or powershell window):
`dotnet watch run`

use the following command in a CLI (powershell or cmd) to query the api and obeserve the response message:
`curl http://localhost:5276/api/SalesAnalysis`
