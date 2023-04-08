//Parallilisation Scope
using CSharpSeleniumFramework.src.main.net.Utilities;

[assembly: Parallelizable(ParallelScope.All)]

//Set this value to the Maximum amount of VMs that you have in Sauce Labs
[assembly: LevelOfParallelism(5)]