#pragma checksum "D:\WorkSpace\WePoem\WePoem\Views\Poem\Creative.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "72ad4cb19c1921542c9952d17212bb5883bdbf96"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Poem_Creative), @"mvc.1.0.view", @"/Views/Poem/Creative.cshtml")]
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
#nullable restore
#line 1 "D:\WorkSpace\WePoem\WePoem\Views\Poem\Creative.cshtml"
using WePoem.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"72ad4cb19c1921542c9952d17212bb5883bdbf96", @"/Views/Poem/Creative.cshtml")]
    public class Views_Poem_Creative : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/bootstrap/dist/js/bootstrap.bundle.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "D:\WorkSpace\WePoem\WePoem\Views\Poem\Creative.cshtml"
  
    ViewData["Title"] = "Creative";
    Layout = "~/Views/Shared/PCBack.cshtml";

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "72ad4cb19c1921542c9952d17212bb5883bdbf963275", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n<div class=\"container\" style=\"width:100%;height:100%;position:relative\">\r\n    <div style=\"width:100%;height:5%;\">\r\n        <span style=\"position:absolute;left:0px;top:0px\" class=\"btn btn-primary\"");
            BeginWriteAttribute("onclick", " onclick=\"", 398, "\"", 487, 3);
            WriteAttributeValue("", 408, "window.location.href=\'", 408, 22, true);
#nullable restore
#line 10 "D:\WorkSpace\WePoem\WePoem\Views\Poem\Creative.cshtml"
WriteAttributeValue("", 430, Model.Poem==null?"/Poem/Index":"/Poem/PoemCollection", 430, 56, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 486, "\'", 486, 1, true);
            EndWriteAttribute();
            WriteLiteral(@"> 返回 </span>
        <span style=""position:absolute;right:0px;top:0px"" class=""btn btn-primary"" onclick=""SaveCreative()"">保存</span>
    </div>
    <br />
    <div id=""PoemTitle"" style=""width:100%;height:5%;background-color:white;"" contenteditable=""true"">
        ");
#nullable restore
#line 15 "D:\WorkSpace\WePoem\WePoem\Views\Poem\Creative.cshtml"
    Write(Model.Poem == null ? "" : Model.Poem.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n    <br />\r\n    <textarea id=\"PoemContent\" class=\"form-control\" style=\"width:100%;height:80%;background-color:white;\">\r\n            ");
#nullable restore
#line 19 "D:\WorkSpace\WePoem\WePoem\Views\Poem\Creative.cshtml"
        Write(Model.Poem == null ? "" : Model.Poem.Content.Replace("###***","\r\n"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
        </textarea>
</div>
<style>
    .test {
        background-color: lightblue;
        border: 1px black solid;
    }
</style>
<script>
    //保存诗歌
    function SaveCreative() {
        var title = $('#PoemTitle')[0].innerHTML;
        if ($.trim(title) == '') {
            $('#PoemTitle').attr('data-original-title', '标题不能为空');
            $('#PoemTitle').tooltip('show');
            setTimeout(function () { $('#PoemTitle').tooltip('dispose') }, 2000);
            return;
        }
        var content = $('#PoemContent').val();
        if ($.trim(content) == '') {
            $('#PoemContent').attr('data-original-title', '内容不能为空');
            $('#PoemContent').tooltip('show');
            setTimeout(function () { $('#PoemTitle').tooltip('dispose') }, 2000);
            return;
        }
        $.ajax({
            url: '/Poem/Creative',
            type: 'POST',
            data: {
                'title': title,
                'content': content,
                'id':'");
#nullable restore
#line 51 "D:\WorkSpace\WePoem\WePoem\Views\Poem\Creative.cshtml"
                  Write(Model.Poem == null ? "" : Model.Poem.PoemID.ToString());

#line default
#line hidden
#nullable disable
            WriteLiteral(@"'
            },
            success: function (data) {
                if (data.code == 200) {
                    window.location.href = '/Poem/Index?msg='+data.msg;
                }else if(data.code == 201) {
                    PopDialog('保存成功', data.msg);
                }else {
                    PopDialog('保存失败', data.msg);
                }
            }
        });
    }
</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
