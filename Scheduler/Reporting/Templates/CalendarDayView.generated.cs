﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Scheduler.Reporting.Templates
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    #line 4 "..\..\Reporting\Templates\CalendarDayView.cshtml"
    using Scheduler;
    
    #line default
    #line hidden
    
    #line 5 "..\..\Reporting\Templates\CalendarDayView.cshtml"
    using Scheduler.Reporting.Templates;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    public partial class CalendarDayView : RazorGenerator.Templating.RazorTemplateBase
    {
#line hidden

        #line 7 "..\..\Reporting\Templates\CalendarDayView.cshtml"

    public string DayNumber { get; set; }

    public List<CalendarDayActivityView> Activities { get; private set; } = new List<CalendarDayActivityView>();

        #line default
        #line hidden

        public override void Execute()
        {


WriteLiteral("\r\n");



WriteLiteral("\r\n");


WriteLiteral("\r\n\r\n");


            
            #line 13 "..\..\Reporting\Templates\CalendarDayView.cshtml"
  



            
            #line default
            #line hidden
WriteLiteral("\r\n<div class=\"Day\">\r\n    <div class=\"DayLabel\">");


            
            #line 18 "..\..\Reporting\Templates\CalendarDayView.cshtml"
                     Write(DayNumber);

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n\r\n");


            
            #line 20 "..\..\Reporting\Templates\CalendarDayView.cshtml"
     foreach (var item in Activities) {
        
            
            #line default
            #line hidden
            
            #line 21 "..\..\Reporting\Templates\CalendarDayView.cshtml"
   Write(item.TransformText());

            
            #line default
            #line hidden
            
            #line 21 "..\..\Reporting\Templates\CalendarDayView.cshtml"
                             
    }

            
            #line default
            #line hidden
WriteLiteral("</div>");


        }
    }
}
#pragma warning restore 1591
