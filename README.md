# NETReactorTest_DN45CrossAssembly
Testing InternalsVisibleTo cross assembly obfuscation with .NET Reactor

The Goal: All internal class names and members should be obfuscated.
Input assemblies for obfuscation:
  Library1.dll (Contains InternalClass.cs and [assembly: InternalsVisibleTo("Library2")] in AssemblyInfo.cs)
  Library2.dll (Uses the Library1.InternalClass class)


**Test in Visual Studio2022**
1. Open NETReactorTest_DN45CrossAssembly.sln
2. Set to release configuration and build solution
4. Set ConsoleAppTest as Startup Project
5. Ctrl+F5. 
6. This is the console output:

```
ConsoleAppTest...
Hello World from Library1.PublicClass
Hello World from Library1.InternalClass
Press any key to continue . . .
```

Note: Building NETReactorTest_DN45CrossAssembly.sln calls copyConsoleApp.bat which copies ConsoleAppTest.exe to the folders used in the test below.

**Test NETReactorTest1.nrproj**
1. Open NETReactorTest1.nrproj in .NET Reactor app
2. Note:
    - Library1.dll and Library2.dll are input files for obfuscation
    - String encryption is off
    - Ignore InternalsVisibleTo is *not* checked
3. Click "Protect" to build obfuscated assemblies to folder NETReactor1_Ouput
4. In a command window navigate to the NETReactor1_Ouput folder.
5. At command prompt run ConsoleAppTest.
6. This is the console output:
7. 
8. 
