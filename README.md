# MarvelFlow [SP]

+ **Category**: School Project
+ **Status**: Discontinued

## **Overview**

This project was a school assignement in team of 2.  
It was an introduction to C# .NET, OOP and graphical application.  
We made an application to see all characters and movies or the Marvel Cinematic Universe (MCU). Each movie would list all characters that were part of it and each character would be linked to any movie it was appearing in.  
There are no data directly integrated in the application but we could easily import it as json from any WEB-API.

This project is working and was a great experience. There are room to a lot of improvement but it was our first real project.

## **Goal / Requirements**

We had to make a master-detail application, with interactive part to display information and link different things together.  
We were mostly advised to do some kind of listing application, so our idea was right in the theme.  
We had to use various part of .NET and WPF (binding, Linq, etc...).
A detail about the evaluation criterias can be found [here](./evaluation).  
Particular care had to be given to documentation (first documentation we ever wrote: API documentation, UML etc...).  

## **Technologies**

+ C#
+ .NET
+ WPF
+ JSON
+ SQL Server
+ MVVM architectural pattern

There were no particular specification about the architectural design pattern. We chose and successfully implemented a MVVM pattern with the help of MVVM light nugget package.  

We also created a login system (account system) though a SQL Server database.  

We implemented a full history system with memory of each step (page we went through) that allows us to hit the return button as much as we want. This was not implemented with any pattern that can be usually found for history but with a custom solution due to our lack of knowledge. Nonetheless it worked pretty good.

All our data are being imported through JSON files (implementation of factories etc...)
