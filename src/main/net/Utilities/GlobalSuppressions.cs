// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage(
    "Assertion",
    "NUnit2005:Consider using Assert.That(actual, Is.EqualTo(expected)) instead of Assert.AreEqual(expected, actual)",
    Justification = "<Pending>",
    Scope = "member",
    Target = "~M:CSharpSeleniumFramework.Tests.Tests.Test1"
)]

[assembly: SuppressMessage(
    "Structure",
    "NUnit1002:The TestCaseSource should use nameof operator to specify target",
    Justification = "<Pending>",
    Scope = "member",
    Target = "~M:CSharpSeleniumFramework.Tests.LoginPageTest.LoginPageDemo4(System.String,System.String)"
    )]

[assembly: SuppressMessage
    ("Style",
    "IDE0044:Add readonly modifier",
    Justification = "<Pending>",
    Scope = "member",
    Target = "~F:CSharpSeleniumFramework.PageObjects.ProductsPageObjects.driver"
    )]
