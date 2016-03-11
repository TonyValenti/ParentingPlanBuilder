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
    
    #line 4 "..\..\Reporting\Templates\MonthView.cshtml"
    using Scheduler;
    
    #line default
    #line hidden
    
    #line 5 "..\..\Reporting\Templates\MonthView.cshtml"
    using Scheduler.Reporting.Templates;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    public partial class MonthView : RazorGenerator.Templating.RazorTemplateBase
    {
#line hidden

        #line 7 "..\..\Reporting\Templates\MonthView.cshtml"

    public Scheduler.Reporting.MonthReport Report { get; set; }

    private string ActivityTimeFormat = "ddd, MMM d @ h:mm tt";

        #line default
        #line hidden

        public override void Execute()
        {


WriteLiteral("\r\n");



WriteLiteral("\r\n");


WriteLiteral("\r\n\r\n");


            
            #line 13 "..\..\Reporting\Templates\MonthView.cshtml"
  
    var Overnights = new OvernightCalculationsView();
    Overnights.Overnights = Report.Overnights;

    var CalendarMonthView = new CalendarMonthView();
    CalendarMonthView.Report = this.Report;


            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n\r\n<div class=\"Calendar\">\r\n        <table>\r\n            <tr>\r\n                " +
"<td colspan=\"2\">\r\n                    <h1>");


            
            #line 27 "..\..\Reporting\Templates\MonthView.cshtml"
                   Write(MonthsOfYearExtensions.GetMonth(Report.Month));

            
            #line default
            #line hidden
WriteLiteral(" ");


            
            #line 27 "..\..\Reporting\Templates\MonthView.cshtml"
                                                                  Write(Report.Year);

            
            #line default
            #line hidden
WriteLiteral("</h1>\r\n                </td>\r\n            </tr>\r\n            <tr>\r\n              " +
"  <td>\r\n                    ");


            
            #line 32 "..\..\Reporting\Templates\MonthView.cshtml"
               Write(CalendarMonthView.TransformText());

            
            #line default
            #line hidden
WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    <div class=\"Ma" +
"thView\">\r\n                        ");


            
            #line 36 "..\..\Reporting\Templates\MonthView.cshtml"
                   Write(Overnights.TransformText());

            
            #line default
            #line hidden
WriteLiteral(@"
                    </div>
                </td>
            </tr>
            <tr>
                <td colspan=""2"">
                    <div class=""MonthView"">
                        <table>
                            <thead>
                                <tr>
                                    <td>Description</td>
                                    <td>From</td>
                                    <td>Till</td>
                                </tr>
                            </thead>
                            <tbody>
");


            
            #line 52 "..\..\Reporting\Templates\MonthView.cshtml"
                                 foreach (var item in this.Report.Items) {

            
            #line default
            #line hidden
WriteLiteral("                                    <tr>\r\n                                       " +
" <td><div class=\"");


            
            #line 54 "..\..\Reporting\Templates\MonthView.cshtml"
                                                    Write(item.Owner);

            
            #line default
            #line hidden
WriteLiteral("Box\"></div>");


            
            #line 54 "..\..\Reporting\Templates\MonthView.cshtml"
                                                                           Write(item.Name);

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n                                        <td>");


            
            #line 55 "..\..\Reporting\Templates\MonthView.cshtml"
                                       Write(item.Duration.StartDate.ToString(ActivityTimeFormat));

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n                                        <td>");


            
            #line 56 "..\..\Reporting\Templates\MonthView.cshtml"
                                       Write(item.Duration.EndDate.ToString(ActivityTimeFormat));

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n                                    </tr>\r\n");


            
            #line 58 "..\..\Reporting\Templates\MonthView.cshtml"
                                }

            
            #line default
            #line hidden
WriteLiteral("\r\n                            </tbody>\r\n                        </table>\r\n       " +
"             </div>\r\n                </td>\r\n            </tr>\r\n        </table>\r" +
"\n\r\n\r\n\r\n</div>\r\n\r\n<div class=\"PageBreak\"></div>");


        }
    }
}
#pragma warning restore 1591