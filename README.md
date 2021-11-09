# NETReactorTest_DN45CrossAssembly

**The Goal: All internal class names and members should be obfuscated/renamed.**

Input assemblies for obfuscation:
1. Library1.dll (Contains InternalClass.cs and [assembly: InternalsVisibleTo("Library2")] in AssemblyInfo.cs)
2. Library2.dll (Uses the Library1.InternalClass class)

**Test in Visual Studio2022**
1. Open NETReactorTest_DN45CrossAssembly.sln
2. Set to release configuration and build solution
4. Set ConsoleAppTest as Startup Project
5. Ctrl+F5. 
6. Console output:

```
ConsoleAppTest...
Hello World from Library1.PublicClass
Hello World from Library1.InternalClass
Press any key to continue . . .

**Test NETReactorTest1.nrproj: The test below runs, but open NETReactor1_Ouput\Library1.dll in ildasm.exe and you will see no obfuscation renaming for InternalClass1 and Internalclass1.Saysomething . **
1. Open NETReactorTest1.nrproj in .NET Reactor app
2. Note:
    - Library1.dll and Library2.dll are input files for obfuscation
    - String encryption is off
    - Ignore InternalsVisibleTo is *not* checked
3. Click "Protect" to build obfuscated assemblies to folder NETReactor1_Ouput
4. In a command window navigate to the NETReactor1_Ouput folder and run ConsoleAppTest.
6. Console output:
```
ConsoleAppTest...
Hello World from Library1.PublicClass
Hello World from Library1.InternalClass
```
