using System.Diagnostics.CodeAnalysis;

// This file is used by Code Analysis to maintain SuppressMessage attributes that are applied to this project. Project-level
// suppressions either have no target or are given a specific target and scoped to a namespace, type, member, etc.
//
// To add a suppression to this file, right-click the message in the Code Analysis results, point to "Suppress Message", and click 
// "In Suppression File". You do not need to add suppressions to this file manually.
[assembly: SuppressMessage("Microsoft.Design", "CA2210:AssembliesShouldHaveValidStrongNames",
    Justification = "Not provide any security benefits, since code is Open Source and therefor the 'private' key would be freely available")]
[assembly: SuppressMessage("Microsoft.Design", "CA1020:AvoidNamespacesWithFewTypes", Scope = "namespace", Target = "NodaMoney.Extensions",
    Justification = "NodaMoney just doesn't have many types at the moment.")]
[assembly: SuppressMessage("Microsoft.Design", "CA1020:AvoidNamespacesWithFewTypes", Scope = "namespace", Target = "NodaMoney",
    Justification = "NodaMoney just doesn't have many types at the moment.")]
[assembly: SuppressMessage("Microsoft.Usage", "CA2243:AttributeStringLiteralsShouldParseCorrectly",
    Justification = "CA2243 doens't apply to AssemblyInformationalVersion. Known bug in Code Analysis.")]
[assembly: SuppressMessage("Microsoft.Design", "CA1020:AvoidNamespacesWithFewTypes", Scope = "namespace", Target = "NodaMoney.Serialization.JsonNet",
    Justification = "Needs to be in a seperate namespace, otherwise it conflits with the JavaScriptSerializer.")]
