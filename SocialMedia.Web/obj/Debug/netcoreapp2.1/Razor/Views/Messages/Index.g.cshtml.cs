#pragma checksum "C:\Users\Tgyka\Desktop\socialmediawebsite\SocialMedia\SocialMedia.Web\Views\Messages\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fb458a61060df7d0043a7def61a3931a02ec83fc"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Messages_Index), @"mvc.1.0.view", @"/Views/Messages/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Messages/Index.cshtml", typeof(AspNetCore.Views_Messages_Index))]
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
#line 1 "C:\Users\Tgyka\Desktop\socialmediawebsite\SocialMedia\SocialMedia.Web\Views\_ViewImports.cshtml"
using SocialMedia.Web;

#line default
#line hidden
#line 2 "C:\Users\Tgyka\Desktop\socialmediawebsite\SocialMedia\SocialMedia.Web\Views\_ViewImports.cshtml"
using SocialMedia.Web.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fb458a61060df7d0043a7def61a3931a02ec83fc", @"/Views/Messages/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ce49073865ba1b7c6c31e75692433b6d618edb98", @"/Views/_ViewImports.cshtml")]
    public class Views_Messages_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<SocialMedia.Web.Models.IndexMessages>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "InsertMessageForPopup", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Messages", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("PP"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("width", new global::Microsoft.AspNetCore.Html.HtmlString("60"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("height", new global::Microsoft.AspNetCore.Html.HtmlString("60"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("width", new global::Microsoft.AspNetCore.Html.HtmlString("50"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("height", new global::Microsoft.AspNetCore.Html.HtmlString("50"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Users\Tgyka\Desktop\socialmediawebsite\SocialMedia\SocialMedia.Web\Views\Messages\Index.cshtml"
  
    ViewData["Title"] = "Messages";

#line default
#line hidden
            BeginContext(89, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            DefineSection("styles", async() => {
                BeginContext(108, 6376, true);
                WriteLiteral(@"
    <style>
        .messages {
            display: grid;
            grid-template-columns: 1fr 3fr;
            grid-gap: 20px;
        }

            .messages .messages-left {
                width: 100%;
                height: 85vh;
            }

                .messages .messages-left .messages-left-header {
                    width: 100%;
                    display: flex;
                    padding: 3% 3% 3% 3%;
                    justify-content: flex-start;
                    align-items: center;
                }

                    .messages .messages-left .messages-left-header img {
                        border-radius: 50%;
                        margin: 0 5px 0 0;
                    }

                    .messages .messages-left .messages-left-header h2 {
                        margin: 0;
                    }

                    .messages .messages-left .messages-left-header .messages-left-header-buttons {
                        width: 100%;
   ");
                WriteLiteral(@"                     display: flex;
                        justify-content: flex-end;
                        align-items: center;
                    }

                        .messages .messages-left .messages-left-header .messages-left-header-buttons button {
                            border: none;
                            padding: 7%;
                            text-align: center;
                            border-radius: 50%;
                        }

                .messages .messages-left .messages-left-search {
                    padding: 1% 0;
                }

                    .messages .messages-left .messages-left-search input {
                        width: 100%;
                        background: #e6e6e6;
                        padding: 3% 5%;
                        border: none;
                        border-radius: 15px;
                    }

                .messages .messages-left .messages-left-messagelist {
                    max-height: 65vh");
                WriteLiteral(@";
                    width: 100%;
                }

                    .messages .messages-left .messages-left-messagelist .messages-left-listitem {
                        width: 100%;
                        padding: 2% 3%;
                        display: flex;
                        justify-content: flex-start;
                        align-items: center;
                    }

                        .messages .messages-left .messages-left-messagelist .messages-left-listitem:hover {
                            background: #fff;
                            border-radius: 5px;
                            cursor: pointer;
                        }

                        .messages .messages-left .messages-left-messagelist .messages-left-listitem img {
                            border-radius: 50%;
                            margin-right: 5px;
                        }

                        .messages .messages-left .messages-left-messagelist .messages-left-listitem .messages-");
                WriteLiteral(@"left-listitem-titles {
                            width: 100%;
                            line-height: 1.3;
                            display: grid;
                        }

                            .messages .messages-left .messages-left-messagelist .messages-left-listitem .messages-left-listitem-titles a {
                                font-size: 16px;
                            }

            .messages .messages-right {
                width: 100%;
                height: 85vh;
                border-left: 1px solid rgba(0,0,0,0.2);
            }

                .messages .messages-right .messages-right-header {
                    width: 100%;
                    padding: 1% 1% 1% 1%;
                    display: flex;
                    justify-content: flex-start;
                    align-items: center;
                    border-bottom: 1px solid rgba(0,0,0,0.2);
                }

                    .messages .messages-right .messages-right-header img {
      ");
                WriteLiteral(@"                  border-radius: 50%;
                        margin-right: 5px;
                    }

                .messages .messages-right .messages-right-messages {
                    width: 100%;
                    min-height: 65vh;
                    max-height: 65vh;
                    padding: 1%;
                    overflow: scroll;
                }

                    .messages .messages-right .messages-right-messages .messages-right-messages-left {
                        width: 100%;
                        display: flex;
                        justify-content: flex-start;
                    }

                        .messages .messages-right .messages-right-messages .messages-right-messages-left span {
                            min-width: 30%;
                            max-width: 60%;
                            background: #e4e4e4;
                            border-radius: 5px;
                            padding: 1%;
                            margin:");
                WriteLiteral(@" 0.5% 0;
                        }

                    .messages .messages-right .messages-right-messages .messages-right-messages-right {
                        width: 100%;
                        display: flex;
                        justify-content: flex-end;
                    }

                        .messages .messages-right .messages-right-messages .messages-right-messages-right span {
                            min-width: 30%;
                            max-width: 60%;
                            background: #e4e4e4;
                            border-radius: 5px;
                            padding: 1%;
                            margin: 0.5% 0;
                        }

                .messages .messages-right .messages-right-sendmessage {
                    width: 100%;
                    padding: 1%;
                }

                    .messages .messages-right .messages-right-sendmessage textarea {
                        width: 100%;
                    ");
                WriteLiteral("    height: 35px;\r\n                        border: none;\r\n                        border-radius: 10px;\r\n                        padding: 0.5% 1%;\r\n                        background: #e4e4e4;\r\n                    }\r\n    </style>\r\n\r\n");
                EndContext();
            }
            );
            BeginContext(6487, 628, true);
            WriteLiteral(@"
    <div class=""modal fade"" id=""exampleModalCenter"" tabindex=""-1"" role=""dialog"" aria-labelledby=""exampleModalCenterTitle"" aria-hidden=""true"">
        <div class=""modal-dialog modal-dialog-centered"" role=""document"">
            <div class=""modal-content"">
                <div class=""modal-header"">
                    <h5 class=""modal-title"" id=""exampleModalLongTitle"">Talk friends</h5>
                    <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                        <span aria-hidden=""true"">&times;</span>
                    </button>
                </div>
                ");
            EndContext();
            BeginContext(7115, 916, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a21d94c8049b4efe8b01691c5293b51d", async() => {
                BeginContext(7197, 827, true);
                WriteLiteral(@"

                    <div class=""modal-body"">
                        <div class=""form-group"">
                            <label for=""nickname-text"" class=""col-form-label"">Nickname:</label>
                            <input type=""text"" name=""username"" class=""form-control"" id=""txtUsername"">
                        </div>
                        <div class=""form-group"">
                            <label for=""message-text"" class=""col-form-label"">Message:</label>
                            <textarea class=""form-control"" name=""text"" id=""txtMessagetxt""></textarea>
                        </div>

                    </div>
                    <div class=""modal-footer"">
                        <button type=""submit"" class=""btn btn-primary"">Save changes</button>
                    </div>
                ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(8031, 171, true);
            WriteLiteral("\r\n\r\n            </div>\r\n        </div>\r\n    </div>\r\n\r\n\r\n\r\n<div class=\"messages\">\r\n    <div class=\"messages-left\">\r\n        <div class=\"messages-left-header\">\r\n            ");
            EndContext();
            BeginContext(8202, 84, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "2de2140e2a804f68bd8ea2adac7e3557", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 8212, "~/images/", 8212, 9, true);
#line 207 "C:\Users\Tgyka\Desktop\socialmediawebsite\SocialMedia\SocialMedia.Web\Views\Messages\Index.cshtml"
AddHtmlAttributeValue("", 8221, Model.PPPath, 8221, 13, false);

#line default
#line hidden
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(8286, 445, true);
            WriteLiteral(@"
            <h2>Talks</h2>
            <div class=""messages-left-header-buttons"">
                <button data-toggle=""modal"" data-target=""#exampleModalCenter"">
                    <i class=""fas fa-reply""></i>
                </button>
            </div>
        </div>
        <div class=""messages-left-search"">
            <input placeholder=""Search in messenger"" />
        </div>
        <div class=""messages-left-messagelist"">
");
            EndContext();
#line 220 "C:\Users\Tgyka\Desktop\socialmediawebsite\SocialMedia\SocialMedia.Web\Views\Messages\Index.cshtml"
             foreach (var item in Model.UserList)
            {

#line default
#line hidden
            BeginContext(8797, 20, true);
            WriteLiteral("                <div");
            EndContext();
            BeginWriteAttribute("itemid", " itemid=\"", 8817, "\"", 8834, 1);
#line 222 "C:\Users\Tgyka\Desktop\socialmediawebsite\SocialMedia\SocialMedia.Web\Views\Messages\Index.cshtml"
WriteAttributeValue("", 8826, item.Id, 8826, 8, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(8835, 54, true);
            WriteLiteral(" class=\"messages-left-listitem\">\r\n                    ");
            EndContext();
            BeginContext(8889, 94, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "05ec43ae3ba64a3d80e85dbf47f46c6f", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 8899, "~/images/", 8899, 9, true);
#line 223 "C:\Users\Tgyka\Desktop\socialmediawebsite\SocialMedia\SocialMedia.Web\Views\Messages\Index.cshtml"
AddHtmlAttributeValue("", 8908, item.PhotoPath, 8908, 15, false);

#line default
#line hidden
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(8983, 96, true);
            WriteLiteral("\r\n                    <div class=\"messages-left-listitem-titles\">\r\n                      <span> ");
            EndContext();
            BeginContext(9080, 9, false);
#line 226 "C:\Users\Tgyka\Desktop\socialmediawebsite\SocialMedia\SocialMedia.Web\Views\Messages\Index.cshtml"
                        Write(item.Name);

#line default
#line hidden
            EndContext();
            BeginContext(9089, 1, true);
            WriteLiteral(" ");
            EndContext();
            BeginContext(9091, 12, false);
#line 226 "C:\Users\Tgyka\Desktop\socialmediawebsite\SocialMedia\SocialMedia.Web\Views\Messages\Index.cshtml"
                                   Write(item.Surname);

#line default
#line hidden
            EndContext();
            BeginContext(9103, 41, true);
            WriteLiteral("</span>\r\n                        <span>\r\n");
            EndContext();
#line 228 "C:\Users\Tgyka\Desktop\socialmediawebsite\SocialMedia\SocialMedia.Web\Views\Messages\Index.cshtml"
                             if (item.ToMessages.Count() != 0 && item.FromMessages.Count() != 0)
                            {
                                

#line default
#line hidden
#line 230 "C:\Users\Tgyka\Desktop\socialmediawebsite\SocialMedia\SocialMedia.Web\Views\Messages\Index.cshtml"
                                 if (item.ToMessages.Last().Time < item.FromMessages.Last().Time)
                                {
                                    

#line default
#line hidden
            BeginContext(9444, 29, false);
#line 232 "C:\Users\Tgyka\Desktop\socialmediawebsite\SocialMedia\SocialMedia.Web\Views\Messages\Index.cshtml"
                               Write(item.FromMessages.Last().Text);

#line default
#line hidden
            EndContext();
#line 232 "C:\Users\Tgyka\Desktop\socialmediawebsite\SocialMedia\SocialMedia.Web\Views\Messages\Index.cshtml"
                                                                  
                                }
                                else
                                {
                                    

#line default
#line hidden
            BeginContext(9620, 27, false);
#line 236 "C:\Users\Tgyka\Desktop\socialmediawebsite\SocialMedia\SocialMedia.Web\Views\Messages\Index.cshtml"
                               Write(item.ToMessages.Last().Text);

#line default
#line hidden
            EndContext();
#line 236 "C:\Users\Tgyka\Desktop\socialmediawebsite\SocialMedia\SocialMedia.Web\Views\Messages\Index.cshtml"
                                                                

                                }

#line default
#line hidden
#line 238 "C:\Users\Tgyka\Desktop\socialmediawebsite\SocialMedia\SocialMedia.Web\Views\Messages\Index.cshtml"
                                 

                            }
                            else if (item.ToMessages.Count() != 0 && item.FromMessages.Count() == 0)
                            {
                                

#line default
#line hidden
            BeginContext(9885, 27, false);
#line 243 "C:\Users\Tgyka\Desktop\socialmediawebsite\SocialMedia\SocialMedia.Web\Views\Messages\Index.cshtml"
                           Write(item.ToMessages.Last().Text);

#line default
#line hidden
            EndContext();
#line 243 "C:\Users\Tgyka\Desktop\socialmediawebsite\SocialMedia\SocialMedia.Web\Views\Messages\Index.cshtml"
                                                            
                            }
                            else if (item.FromMessages.Count() != 0 && item.ToMessages.Count() == 0)
                            {
                                

#line default
#line hidden
            BeginContext(10111, 29, false);
#line 247 "C:\Users\Tgyka\Desktop\socialmediawebsite\SocialMedia\SocialMedia.Web\Views\Messages\Index.cshtml"
                           Write(item.FromMessages.Last().Text);

#line default
#line hidden
            EndContext();
#line 247 "C:\Users\Tgyka\Desktop\socialmediawebsite\SocialMedia\SocialMedia.Web\Views\Messages\Index.cshtml"
                                                              
                            }

#line default
#line hidden
            BeginContext(10173, 89, true);
            WriteLiteral("\r\n\r\n                        </span>\r\n                    </div>\r\n                </div>\r\n");
            EndContext();
#line 254 "C:\Users\Tgyka\Desktop\socialmediawebsite\SocialMedia\SocialMedia.Web\Views\Messages\Index.cshtml"

            }

#line default
#line hidden
            BeginContext(10279, 390, true);
            WriteLiteral(@"           

        </div>
    </div>
    <div class=""messages-right"">
        <div class=""messages-right-header"">
            
        </div>
        <div class=""messages-right-messages"">
         
        </div>
        <div class=""messages-right-sendmessage"">
            <textarea id=""txtMessage"" placeholder=""Type a message""></textarea>
        </div>
    </div>



");
            EndContext();
            DefineSection("scripts", async() => {
                BeginContext(10691, 3620, true);
                WriteLiteral(@"
        <script>
            $(document).ready(function () {
                var targetId;
                var token = $('[name=__RequestVerificationToken]').val();

                $("".messages-left-listitem"").click(function () {
                    var div = $(this);
                    targetId = parseInt($(this).attr('itemId'), 10);
                    console.log(targetId);
                    $.ajax({
                        url: '/Messages/GetMessages',
                        type: 'POST',
                        data: { __RequestVerificationToken: token, targetId: targetId },
                        success: function (result) {

                            console.log(result);
                            $("".messages-right-header"").html(""<img src='/images/"" + result.user.photoPath + ""'"" +
                                ""alt = 'PP' width = '50' height = '50' >"" +
                                ""<h3>"" + result.user.name + "" "" + result.user.surname + ""</h3>"");

                  ");
                WriteLiteral(@"          $("".messages-right-messages"").html("""");

                            $.each(result.messagesList, function (index, val) {
                                console.log(val);
                                if (targetId == val.fromUserId) {
                                    $("".messages-right-messages"").append(

                                        ""<div class='messages-right-messages-left'>"" +
                                        ""<span>"" + val.text + ""</span>"" +
                                        ""</div >""
                                    );
                                }

                                else if (targetId == val.toUserId) {
                                    $("".messages-right-messages"").append(

                                        ""<div class='messages-right-messages-right'>"" +
                                        ""<span>"" + val.text + ""</span>"" +
                                        ""</div >""
                                    );
  ");
                WriteLiteral(@"                              }

                            });
                        }
                    });

                });

                $(document).on('keypress', '#txtMessage', function (event) {
                    var keycode = (event.keyCode ? event.keyCode : event.which);
                    var text = $(this).val();
                    var messagelist = $(this).parent().parent().children('.messages-right-messages');

                    if (keycode == '13') {

                        if (event.shiftKey) {
                            console.log(messagelist);
                            console.log(""shiftenter"");
                        } else {
                            $.ajax({
                                url: '/Messages/InsertMessage',
                                type: 'POST',
                                data: { __RequestVerificationToken: token, targetId: targetId, text: text },
                                success: function (result) {
       ");
                WriteLiteral(@"                             messagelist.append(""<div class='messages-right-messages-right'>"" +
                                        ""<span>"" + text + ""</span>"" +
                                        ""</div >"");
                                }
                            });
                            $(this).val('');


                        }
                    }
                });


                function GetResult(result) {
                   
                }

            });


        </script>

    ");
                EndContext();
            }
            );
            BeginContext(14314, 2, true);
            WriteLiteral("\r\n");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<SocialMedia.Web.Models.IndexMessages> Html { get; private set; }
    }
}
#pragma warning restore 1591