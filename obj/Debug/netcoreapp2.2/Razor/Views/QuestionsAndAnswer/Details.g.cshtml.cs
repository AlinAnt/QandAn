#pragma checksum "/home/alina/QandAn/Views/QuestionsAndAnswer/Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "dbfaa6129016310d16c64de0411050fb65ced5f1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_QuestionsAndAnswer_Details), @"mvc.1.0.view", @"/Views/QuestionsAndAnswer/Details.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/QuestionsAndAnswer/Details.cshtml", typeof(AspNetCore.Views_QuestionsAndAnswer_Details))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "/home/alina/QandAn/Views/_ViewImports.cshtml"
using QandAn;

#line default
#line hidden
#line 2 "/home/alina/QandAn/Views/_ViewImports.cshtml"
using QandAn.Models;

#line default
#line hidden
#line 1 "/home/alina/QandAn/Views/QuestionsAndAnswer/Details.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"dbfaa6129016310d16c64de0411050fb65ced5f1", @"/Views/QuestionsAndAnswer/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e1e506e8497dcfe2b780b4a532e7ada4ccabedc0", @"/Views/_ViewImports.cshtml")]
    public class Views_QuestionsAndAnswer_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<QandAn.Models.Question>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-warning btn-sm"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("display: block; margin-left:auto; "), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "DeleteAnswer", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/signalr/dist/browser/signalr.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(218, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 6 "/home/alina/QandAn/Views/QuestionsAndAnswer/Details.cshtml"
  
     ViewData["Title"] = "Details";

#line default
#line hidden
            BeginContext(264, 38, true);
            WriteLiteral("\r\n<h1>Details</h1>\r\n\r\n<div>\r\n    <h4> ");
            EndContext();
            BeginContext(303, 45, false);
#line 13 "/home/alina/QandAn/Views/QuestionsAndAnswer/Details.cshtml"
    Write(Html.DisplayFor(model => model.QuestionTitle));

#line default
#line hidden
            EndContext();
            BeginContext(348, 86, true);
            WriteLiteral("</h4>\r\n    <hr />\r\n    <dl class=\"row\">\r\n        <dt class = \"col-sm-6\">\r\n            ");
            EndContext();
            BeginContext(435, 40, false);
#line 17 "/home/alina/QandAn/Views/QuestionsAndAnswer/Details.cshtml"
       Write(Html.DisplayNameFor(model => model.User));

#line default
#line hidden
            EndContext();
            BeginContext(475, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(539, 41, false);
#line 20 "/home/alina/QandAn/Views/QuestionsAndAnswer/Details.cshtml"
       Write(Html.DisplayFor(model => model.User.Name));

#line default
#line hidden
            EndContext();
            BeginContext(580, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-6\">\r\n            ");
            EndContext();
            BeginContext(643, 51, false);
#line 23 "/home/alina/QandAn/Views/QuestionsAndAnswer/Details.cshtml"
       Write(Html.DisplayNameFor(model => model.QuestionContent));

#line default
#line hidden
            EndContext();
            BeginContext(694, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(758, 47, false);
#line 26 "/home/alina/QandAn/Views/QuestionsAndAnswer/Details.cshtml"
       Write(Html.DisplayFor(model => model.QuestionContent));

#line default
#line hidden
            EndContext();
            BeginContext(805, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-6\">\r\n            ");
            EndContext();
            BeginContext(868, 54, false);
#line 29 "/home/alina/QandAn/Views/QuestionsAndAnswer/Details.cshtml"
       Write(Html.DisplayNameFor(model => model.QuestionCreateTime));

#line default
#line hidden
            EndContext();
            BeginContext(922, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(986, 50, false);
#line 32 "/home/alina/QandAn/Views/QuestionsAndAnswer/Details.cshtml"
       Write(Html.DisplayFor(model => model.QuestionCreateTime));

#line default
#line hidden
            EndContext();
            BeginContext(1036, 57, true);
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n</div>\r\n<div>\r\n    <br>\r\n    ");
            EndContext();
            BeginContext(1093, 38, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "dbfaa6129016310d16c64de0411050fb65ced5f18212", async() => {
                BeginContext(1115, 12, true);
                WriteLiteral("Back to List");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1131, 10, true);
            WriteLiteral("\r\n</div>\r\n");
            EndContext();
#line 40 "/home/alina/QandAn/Views/QuestionsAndAnswer/Details.cshtml"
 if(SignInManager.IsSignedIn(User))
{

#line default
#line hidden
            BeginContext(1181, 165, true);
            WriteLiteral("    <div class=\"CreateAnswer\">\r\n        <div class=\"input_answer\">\r\n            <label class=\"control-label\"></label>\r\n            <input type=\"hidden\" id=\"username\"");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 1346, "\"", 1426, 1);
#line 45 "/home/alina/QandAn/Views/QuestionsAndAnswer/Details.cshtml"
WriteAttributeValue("", 1354, dbContext.Users.FirstOrDefault(u => u.Email == User.Identity.Name).Name, 1354, 72, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1427, 36, true);
            WriteLiteral(" >\r\n            <input type=\"hidden\"");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 1463, "\"", 1480, 1);
#line 46 "/home/alina/QandAn/Views/QuestionsAndAnswer/Details.cshtml"
WriteAttributeValue("", 1471, Model.ID, 1471, 9, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1481, 376, true);
            WriteLiteral(@" id=""questionId"" />
            <input class=""form-control"" id = ""answer"" name=""AnswerContent"" placeholder=""Только для зарегистрированных пользователей""/>
            <div class=""form-group"">
                <br>
                <button class=""btn btn-warning"" name=""answerButton""  id=""answerButton"">Create answer</button>
            </div>
        </div>
    </div>
");
            EndContext();
#line 54 "/home/alina/QandAn/Views/QuestionsAndAnswer/Details.cshtml"
}
else {

#line default
#line hidden
            BeginContext(1868, 98, true);
            WriteLiteral("    <div class=\"contener\" style=\"text-align:center\">\r\n    <h3>Answers</h3>\r\n    <br>\r\n    </div>\r\n");
            EndContext();
#line 60 "/home/alina/QandAn/Views/QuestionsAndAnswer/Details.cshtml"
}

#line default
#line hidden
            BeginContext(1969, 108, true);
            WriteLiteral("\r\n\r\n<nav aria-label=\"breadcrumb\">\r\n    <div id= \"list-example\" class=\"list\">\r\n        <ul id=\"answerList\">\r\n");
            EndContext();
#line 66 "/home/alina/QandAn/Views/QuestionsAndAnswer/Details.cshtml"
         foreach (var ans in Model.Answers)
        {    

#line default
#line hidden
            BeginContext(2137, 53, true);
            WriteLiteral("            <ol class=\"breadcrumb\">\r\n                ");
            EndContext();
            BeginContext(2191, 13, false);
#line 69 "/home/alina/QandAn/Views/QuestionsAndAnswer/Details.cshtml"
           Write(ans.User.Name);

#line default
#line hidden
            EndContext();
            BeginContext(2204, 22, true);
            WriteLiteral("<br>\r\n                ");
            EndContext();
            BeginContext(2227, 14, false);
#line 70 "/home/alina/QandAn/Views/QuestionsAndAnswer/Details.cshtml"
           Write(ans.AnswerTime);

#line default
#line hidden
            EndContext();
            BeginContext(2241, 95, true);
            WriteLiteral(" \r\n               \r\n                <li class=\"breadcrumb-item active\" aria-current=\"page\" ><b>");
            EndContext();
            BeginContext(2337, 17, false);
#line 72 "/home/alina/QandAn/Views/QuestionsAndAnswer/Details.cshtml"
                                                                      Write(ans.AnswerContent);

#line default
#line hidden
            EndContext();
            BeginContext(2354, 21, true);
            WriteLiteral("</b></li>\r\n        \r\n");
            EndContext();
#line 74 "/home/alina/QandAn/Views/QuestionsAndAnswer/Details.cshtml"
             if(User.IsInRole("Admin"))
            {

#line default
#line hidden
            BeginContext(2431, 16, true);
            WriteLiteral("                ");
            EndContext();
            BeginContext(2447, 144, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "dbfaa6129016310d16c64de0411050fb65ced5f113557", async() => {
                BeginContext(2574, 13, true);
                WriteLiteral("<b>Delete</b>");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 76 "/home/alina/QandAn/Views/QuestionsAndAnswer/Details.cshtml"
                                                                                                                         WriteLiteral(ans.ID);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2591, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 77 "/home/alina/QandAn/Views/QuestionsAndAnswer/Details.cshtml"
            }

#line default
#line hidden
            BeginContext(2608, 19, true);
            WriteLiteral("            </ol>\r\n");
            EndContext();
#line 79 "/home/alina/QandAn/Views/QuestionsAndAnswer/Details.cshtml"
        }

#line default
#line hidden
            BeginContext(2638, 39, true);
            WriteLiteral("        </ul>\r\n    </div>\r\n</nav>\r\n\r\n\r\n");
            EndContext();
            BeginContext(2677, 61, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "dbfaa6129016310d16c64de0411050fb65ced5f116571", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2738, 675, true);
            WriteLiteral(@"
<script>
    const hubConnection = new signalR.HubConnectionBuilder()
            .withUrl(""/answerHub"")
            .configureLogging(signalR.LogLevel.Information)
            .build();
        

    document.getElementById(""answerButton"").addEventListener(""click"", function(e){
        
        let answer = document.getElementById(""answer"").value;
        document.getElementById(""answer"").value = "" "";
        let question = document.getElementById(""questionId"").value;
        let username = document.getElementById(""username"").value;
     
        hubConnection.invoke(""Send"", question, answer, username);
        
        $.ajax({
            url: '");
            EndContext();
            BeginContext(3414, 26, false);
#line 103 "/home/alina/QandAn/Views/QuestionsAndAnswer/Details.cshtml"
             Write(Url.Action("CreateAnswer"));

#line default
#line hidden
            EndContext();
            BeginContext(3440, 828, true);
            WriteLiteral(@"',
            type:""POST"",
            data: { AnswerContent: answer, questionId: parseInt(question, 10)},
            dataType: ""text""
            
        }); 
    });

    hubConnection.on(""Receive"", function(answer, username, datetime){
       
        var ol = document.createElement(""ol"");
        ol.className = ""breadcrumb""
        ol.innerHTML = `
                ${username}<br>
                ${datetime}
                &nbsp
                <li style=""color:black;""><b>${answer}</b></li>`
        
        document.getElementById(""answerList"").appendChild(ol);
       
    });
    hubConnection.start().then(() => {
        hubConnection.invoke('JoinGroup', document.getElementById(""questionId"").value).catch(err => console.error(err.toString()));
        
    });
    
</script>



");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public QandAn.Data.ApplicationDbContext dbContext { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public SignInManager<QandAn.Areas.Identity.Pages.Account.RegisterModel.AlinUser> SignInManager { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<QandAn.Models.Question> Html { get; private set; }
    }
}
#pragma warning restore 1591
