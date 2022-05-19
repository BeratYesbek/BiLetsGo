# Bilet's Go
#### BiLet's Go Backend Web API Application
###### About BiLet's GO
Aims of "BileLet's Go" to sell concert, theater and cinema tickets on online. You can buy easily and safely to tickets on Mobile and Web app clients which developed using Android SDK - Kotlin and React

#### About Backend API Application
This application has been being developed using the best way and technic. N-layer architecture has been implemented the best way. Each layer depends on other layer except CORE layer which implementable on every project easily. Core layer includes some independent process which usable on each project generally. These are cross-cutting concerns, aspects and utilities. For instance Core layer Contains Logging, Caching, Validation, Performance and Transaction as Cross Cutting Concern. Utilities contain Interceptors which can use attributes with Class and methods. **MethodInterceptor** class includes special methods that are able to run and override methods which are success, before, after and exception. **MethodInterceptor** inherited from **MethodInterceptionBaseAttribute** which has some configuration about attributes. Inside this application has been being implemented IOC container, SOLID , Aspect Oriented Programming, Object oriented programming and many other design patterns and some technics as well.

As seen, the most important two things all the process. 
**Scalability**
**Readability**

#### Scalability
We have to know which layer present which purpose. And what is time complexity for each of the methods, is it fast? Or is it slow? Calculate every single possibility for now and future to scale it. Now we have small data to manage but in the future process we might have billions of data we can't know that. This is the reason In every single step Scalability is the most important principle. What is the space complexity? What is the time complexity? What is the cost?

#### Readablity
The code could change every time. Maybe someone wants to understand the code who doesn't know well programming. The code should be designed very well. Even if your grandmother looks code, she  must understand easily. That's way SOLID and design principle are significantly essential during the process

#### Layers
**Business** : It contains some business logic and rules. For instance, validation rules and custom rules. It depends on Core, Data Access and Entity Layers
**Core** It contains cross-cutting concerns, aspects interceptor, utilities, IOC and some extensions
**DataAccess** It can access the database using db-context class
**Entity** It includes some entities of db and DTO
**WebAPI** It handles coming requests to controllers (API), GET PUT POST DELETE etc.
