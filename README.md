# NETReactorTest_DN45CrossAssembly

**The Goal: All internal class names and members should be obfuscated/renamed.**

Input assemblies for obfuscation:
1. Library1.dll (Contains InternalClass.cs and [assembly: InternalsVisibleTo("Library2")] in AssemblyInfo.cs)
2. Library2.dll (Uses the Library1.InternalClass class)

**Running the ConsoleAppTest in Visual Studio2022**
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
```

**Obfuscation Test: NETReactorTest1.nrproj:**
1. Open NETReactorTest1.nrproj in .NET Reactor app
2. Note:
    - Library1.dll and Library2.dll are input files for obfuscation
    - String encryption is off
    - Ignore InternalsVisibleTo is *not* checked
3. Click "Protect" to build obfuscated assemblies to folder NETReactor1_Output
4. In a command window navigate to the NETReactor1_Ouput folder and run ConsoleAppTest.
5. Console output:
```
ConsoleAppTest...
Hello World from Library1.PublicClass
Hello World from Library1.InternalClass
```
6. FAIL: This test runs but in NETReactor1_Output\Library1.dll the InternalClass1 name and its method SaySomething are not obfuscated\renamed.

**Obfuscation Test: NETReactorTest2_IgnoreInternalsVisibleTo.nrproj:**
1. Open NETReactorTest1.nrproj in .NET Reactor app
2. Note:
    - Library1.dll and Library2.dll are input files for obfuscation
    - String encryption is off
    - Ignore InternalsVisibleTo *IS* checked
3. Click "Protect" to build obfuscated assemblies to folder NETReactor2_Output
4. In a command window navigate to the NETReactor2_Ouput folder and run ConsoleAppTest.
5. Console output:
```
ConsoleAppTest...
Hello World from Library1.PublicClass

Unhandled Exception: System.TypeLoadException: Could not load type 'Library1.InternalClass' from assembly 'Library1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'.
   at Library2.PublicClass.Library1InternalClass_SaySomething()
   at ConsoleAppTest.Program.Main(String[] args)
```
6. FAIL: This test does not run. However, in NETReactor2_Output\Library1.dll the InternalClass1 name and its method SaySomething *are* obfuscated\renamed.

**Obfuscation Test: NETReactorTest3_StringEncryption.nrproj:**
1. Open NETReactorTest1.nrproj in .NET Reactor app
2. Note:
    - Library1.dll and Library2.dll are input files for obfuscation
    - String encryption is *ON*
    - Ignore InternalsVisibleTo is *not* checked
3. Click "Protect" to build obfuscated assemblies to folder NETReactor3_Output
4. In a command window navigate to the NETReactor3_Ouput folder and run ConsoleAppTest.
5. Console output:
```
ConsoleAppTest...
Hello World from Library1.PublicClass

Unhandled Exception: System.TypeLoadException: Could not load type 'Library1.InternalClass' from assembly 'Library1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'.
   at Library2.PublicClass.Library1InternalClass_SaySomething()
   at ConsoleAppTest.Program.Main(String[] args)
```
6. FAIL: This test does not run. The good news is in NETReactor1_Output\Library1.dll the InternalClass1 name and its method SaySomething *are* obfuscated\renamed.
