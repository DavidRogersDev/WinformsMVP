# WinformsMVP
A simple Model View Presenter framework for the Winforms platform.
  
Based on the excellent Web Forms MVP, WinForms MVP is a simple Model View Presenter framework for the Winforms platform. To get started, my [CodeProject article](https://www.codeproject.com/Articles/522809/WinForms-MVP-An-MVP-Framework-for-WinForms) on this framework sets out the basics.  
  
## Why? 
I was recently deployed on a maintenance gig with lots of small WinForms apps which comprised a larger system. None of the existing apps followed any kind of best practice. It was all code-behind, with business logic mixed in with the View.   
  
A light weight MVP framework would have been perfect for these small apps. Something like the excellent Web Forms MVP, but for WinForms. And hence my decision to create such a framework.  

## Update ##
Visual Studio Designer support is achievable if you use the non-generic MvpForm and MvpUserControl, rather than their generic counterparts. Or, if you follow the instructions at this discussion https://winformsmvp.codeplex.com/discussions/467178  

There is a samples folder which demonstrates the usage of this framework.

## Ideal Usage ##
WinFormsMVP is ideal for smaller applications. I believe that no application is too small for good coding practice (with separations of concerns etc.). Just because your app only has 5 - 10 screens, it does not mean you should treat your code-behind like a themepark. Applications with 10,000 - 50,0000 lines of code and/or up to 50 screens is the sweet spot for this framework. (However, I would be interested to hear whether people have used it in larger enterprise applications, and what their experience was like).  
  
WinFormsMVP is also ideal for students of design patterns. People who are learning how to code to patterns. It is a simple framework, so learners will not be overwhelmed by a plethora of features which would detract from their core purpose of learning about how MVP works.  
  
## Absent Featuers ##
There are a number of features in Web Forms MVP (the origin project for most of the code in this framework) which I have stripped out. I will look at adding those features back in, once I'm satisfied that the core framework is solid. This has been a learning process for me, so I've tried to keep things simple, for now.  
