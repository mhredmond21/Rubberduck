﻿using System.Linq;
using Microsoft.Vbe.Interop;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Rubberduck.Inspections;
using Rubberduck.Parsing.VBA;
using Rubberduck.VBEditor.Extensions;
using Rubberduck.VBEditor.VBEHost;
using Rubberduck.VBEditor.VBEInterfaces.RubberduckCodePane;
using RubberduckTests.Mocks;

namespace RubberduckTests.Inspections
{
//    [TestClass]
//    public class ImplicitByRefParameterInspectionTests
//    {
//        [TestMethod]
//        public void ImplicitByRefParameter_ReturnsResult()
//        {
//            const string inputCode =
//@"Sub Foo(arg1 As Integer)
//End Sub";

//            //Arrange
//            var builder = new MockVbeBuilder();
//            var project = builder.ProjectBuilder("TestProject1", vbext_ProjectProtection.vbext_pp_none)
//                .AddComponent("Class1", vbext_ComponentType.vbext_ct_ClassModule, inputCode)
//                .Build().Object;

//            var codePaneFactory = new CodePaneWrapperFactory();
//            var mockHost = new Mock<IHostApplication>();
//            mockHost.SetupAllProperties();
//            var parseResult = new RubberduckParser().Parse(project);

//            var inspection = new ImplicitByRefParameterInspection();
//            var inspectionResults = inspection.GetInspectionResults(parseResult);

//            Assert.AreEqual(1, inspectionResults.Count());
//        }

//        [TestMethod]
//        public void ImplicitByRefParameter_ReturnsResult_MultipleParams()
//        {
//            const string inputCode =
//@"Sub Foo(arg1 As Integer, arg2 As Date)
//End Sub";

//            //Arrange
//            var builder = new MockVbeBuilder();
//            var project = builder.ProjectBuilder("TestProject1", vbext_ProjectProtection.vbext_pp_none)
//                .AddComponent("Class1", vbext_ComponentType.vbext_ct_ClassModule, inputCode)
//                .Build().Object;

//            var codePaneFactory = new CodePaneWrapperFactory();
//            var mockHost = new Mock<IHostApplication>();
//            mockHost.SetupAllProperties();
//            var parseResult = new RubberduckParser().Parse(project);

//            var inspection = new ImplicitByRefParameterInspection();
//            var inspectionResults = inspection.GetInspectionResults(parseResult);

//            Assert.AreEqual(2, inspectionResults.Count());
//        }

//        [TestMethod]
//        public void ImplicitByRefParameter_DoesNotReturnResult_ByRef()
//        {
//            const string inputCode =
//@"Sub Foo(ByRef arg1 As Integer)
//End Sub";

//            //Arrange
//            var builder = new MockVbeBuilder();
//            var project = builder.ProjectBuilder("TestProject1", vbext_ProjectProtection.vbext_pp_none)
//                .AddComponent("Class1", vbext_ComponentType.vbext_ct_ClassModule, inputCode)
//                .Build().Object;

//            var codePaneFactory = new CodePaneWrapperFactory();
//            var mockHost = new Mock<IHostApplication>();
//            mockHost.SetupAllProperties();
//            var parseResult = new RubberduckParser().Parse(project);

//            var inspection = new ImplicitByRefParameterInspection();
//            var inspectionResults = inspection.GetInspectionResults(parseResult);

//            Assert.AreEqual(0, inspectionResults.Count());
//        }

//        [TestMethod]
//        public void ImplicitByRefParameter_DoesNotReturnResult_ByVal()
//        {
//            const string inputCode =
//@"Sub Foo(ByVal arg1 As Integer)
//End Sub";

//            //Arrange
//            var builder = new MockVbeBuilder();
//            var project = builder.ProjectBuilder("TestProject1", vbext_ProjectProtection.vbext_pp_none)
//                .AddComponent("Class1", vbext_ComponentType.vbext_ct_ClassModule, inputCode)
//                .Build().Object;

//            var codePaneFactory = new CodePaneWrapperFactory();
//            var mockHost = new Mock<IHostApplication>();
//            mockHost.SetupAllProperties();
//            var parseResult = new RubberduckParser().Parse(project);

//            var inspection = new ImplicitByRefParameterInspection();
//            var inspectionResults = inspection.GetInspectionResults(parseResult);

//            Assert.AreEqual(0, inspectionResults.Count());
//        }

//        [TestMethod]
//        public void ImplicitByRefParameter_ReturnsResult_SomePassedByRefImplicitely()
//        {
//            const string inputCode =
//@"Sub Foo(ByVal arg1 As Integer, arg2 As Date)
//End Sub";

//            //Arrange
//            var builder = new MockVbeBuilder();
//            var project = builder.ProjectBuilder("TestProject1", vbext_ProjectProtection.vbext_pp_none)
//                .AddComponent("Class1", vbext_ComponentType.vbext_ct_ClassModule, inputCode)
//                .Build().Object;

//            var codePaneFactory = new CodePaneWrapperFactory();
//            var mockHost = new Mock<IHostApplication>();
//            mockHost.SetupAllProperties();
//            var parseResult = new RubberduckParser().Parse(project);

//            var inspection = new ImplicitByRefParameterInspection();
//            var inspectionResults = inspection.GetInspectionResults(parseResult);

//            Assert.AreEqual(1, inspectionResults.Count());
//        }

//        [TestMethod]
//        public void ImplicitByRefParameter_ReturnsResult_InterfaceImplementation()
//        {
//            //Input
//            const string inputCode1 =
//@"Sub Foo(arg1 As Integer)
//End Sub";
//            const string inputCode2 =
//@"Implements IClass1
//
//Sub IClass1_Foo(arg1 As Integer)
//End Sub";

//            //Arrange
//            var builder = new MockVbeBuilder();
//            var project = builder.ProjectBuilder("TestProject1", vbext_ProjectProtection.vbext_pp_none)
//                .AddComponent("IClass1", vbext_ComponentType.vbext_ct_ClassModule, inputCode1)
//                .AddComponent("Class1", vbext_ComponentType.vbext_ct_ClassModule, inputCode2)
//                .Build().Object;

//            var codePaneFactory = new CodePaneWrapperFactory();
//            var mockHost = new Mock<IHostApplication>();
//            mockHost.SetupAllProperties();
//            var parseResult = new RubberduckParser().Parse(project);

//            var inspection = new ImplicitByRefParameterInspection();
//            var inspectionResults = inspection.GetInspectionResults(parseResult);

//            Assert.AreEqual(1, inspectionResults.Count());
//        }

//        [TestMethod]
//        public void ImplicitByRefParameter_QuickFixWorks_PassByRef()
//        {
//            const string inputCode =
//@"Sub Foo(arg1 As Integer)
//End Sub";

//            const string expectedCode =
//@"Sub Foo(ByRef arg1 As Integer)
//End Sub";

//            //Arrange
//            var builder = new MockVbeBuilder();
//            var project = builder.ProjectBuilder("TestProject1", vbext_ProjectProtection.vbext_pp_none)
//                .AddComponent("Class1", vbext_ComponentType.vbext_ct_ClassModule, inputCode)
//                .Build().Object;
//            var module = project.VBComponents.Item(0).CodeModule;

//            var codePaneFactory = new CodePaneWrapperFactory();
//            var mockHost = new Mock<IHostApplication>();
//            mockHost.SetupAllProperties();
//            var parseResult = new RubberduckParser().Parse(project);

//            var inspection = new ImplicitByRefParameterInspection();
//            var inspectionResults = inspection.GetInspectionResults(parseResult);

//            inspectionResults.First().QuickFixes.First().Fix();

//            Assert.AreEqual(expectedCode, module.Lines());
//        }

//        [TestMethod]
//        public void ImplicitByRefParameter_QuickFixWorks_ParamArrayMustBePassedByRef()
//        {
//            const string inputCode =
//@"Sub Foo(ParamArray arg1 As Integer)
//End Sub";

//            //Arrange
//            var builder = new MockVbeBuilder();
//            var project = builder.ProjectBuilder("TestProject1", vbext_ProjectProtection.vbext_pp_none)
//                .AddComponent("Class1", vbext_ComponentType.vbext_ct_ClassModule, inputCode)
//                .Build().Object;

//            var codePaneFactory = new CodePaneWrapperFactory();
//            var mockHost = new Mock<IHostApplication>();
//            mockHost.SetupAllProperties();
//            var parseResult = new RubberduckParser().Parse(project);

//            var inspection = new ImplicitByRefParameterInspection();
//            var inspectionResults = inspection.GetInspectionResults(parseResult);

//            Assert.AreEqual(1, inspectionResults.First().QuickFixes.Count());
//        }

//        [TestMethod]
//        public void InspectionType()
//        {
//            var inspection = new ImplicitByRefParameterInspection();
//            Assert.AreEqual(CodeInspectionType.CodeQualityIssues, inspection.InspectionType);
//        }

//        [TestMethod]
//        public void InspectionName()
//        {
//            const string inspectionName = "ImplicitByRefParameterInspection";
//            var inspection = new ImplicitByRefParameterInspection();

//            Assert.AreEqual(inspectionName, inspection.Name);
//        }
//    }
}