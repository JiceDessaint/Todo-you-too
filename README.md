Todo-you-too
============
Sample application  showing an example of usage of some Func Testing framework.
It provides a really minimalistic "Todo" application, and provides quick and easy way to run framework described below.
To run the solution, you will need Visual Studio 2013 and .Net framework 4.5.

Func Testing examples included in this project are :

 - Fitnesse
 - SpecFlow (planned)
 - Concordion (planned)

Requirements
============
 - [Visual Studio] (http://www.visualstudio.com/)
 - [Java](https://www.java.com/fr/download)
 - [Testdriven](http://testdriven.net/)
 -   ...
 
Installation
============

 - clone [this repository](https://github.com/JiceDessaint/Todo-you-too) 
 - run .\InstallFitnesse.bat
 - open the solution in visual studio
 - get the dependencies with nugget
 - built it

How to run Fitnesse ?
=====================
Some batch files are provided to install everything very easily:
 
 - Launch "InstallFitnesse.bat" located on the root of the project
 - Open the solution, and rebuild it
 - Launch "LaunchFitnesse.bat"
 - Enjoy
 
 How to run Concordion ?
 =======================
 
 You will need to run Nunit test, unfortunately, it doesn't work properly with Nunit adapter. You have to use [TestDriven](http://testdriven.net/), you can also use Galio or nunit in command line
 
  - install [TestDriven](http://testdriven.net/)
  - copy the the lib from .\lib\Concordion.Nunit.dll to <Install path of testDriven>\NUnit\2.6\addins
  - run the test with testDriven (right click on the project -> run test...)
  - you will find the generated html file here .\Concordion.Specs\Concordion\Specs\Tests\