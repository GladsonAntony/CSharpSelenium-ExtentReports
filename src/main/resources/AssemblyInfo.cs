//Parallilisation Scope
[assembly: Parallelizable(ParallelScope.All)]

//Set this value to the Maximum amount of VMs that you have in Sauce Labs
[assembly: LevelOfParallelism(5)]