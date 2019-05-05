using System;
using System.Collections.Generic;
using System.Text;

namespace Gogogo.IF
{
    public enum TestReportType : int
    {
        Bug,
        Suggestion,
        Improvement
    }

    public enum TaskType : int
    {
        Standard = 100,
        ProjectManagement,
        ArchitectureDesign,
        ProductDesign,
        UIDesign,
        UEDesign,
        Development,
        Research,
        Test,
        Publish,
        Deploy
    }
}
