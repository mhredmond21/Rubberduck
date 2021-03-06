﻿using System.Collections.Generic;
using System.Linq;
using Rubberduck.Parsing.VBA;

namespace Rubberduck.Inspections
{
    public sealed class SelfAssignedDeclarationInspection : InspectionBase
    {
        public SelfAssignedDeclarationInspection(RubberduckParserState state)
            : base(state)
        {
            Severity = CodeInspectionSeverity.Warning;
        }

        public override string Description { get { return InspectionsUI.SelfAssignedDeclarationInspection; } }
        public override CodeInspectionType InspectionType { get { return CodeInspectionType.CodeQualityIssues; } }

        public override IEnumerable<CodeInspectionResultBase> GetInspectionResults()
        {
            return UserDeclarations
                .Where(declaration => declaration.IsSelfAssigned)
                .Select(issue => new SelfAssignedDeclarationInspectionResult(this, issue));
        }
    }
}
