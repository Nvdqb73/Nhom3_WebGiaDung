//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ASP {
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Security;
using System.Web.UI;
using System.Web.WebPages;
using System.Web.WebPages.Html;

public class _Page_Delete_cshtml : System.Web.WebPages.WebPage {
private static object @__o;
#line hidden
public _Page_Delete_cshtml() {
}
protected System.Web.HttpApplication ApplicationInstance {
get {
return ((System.Web.HttpApplication)(Context.ApplicationInstance));
}
}
public override void Execute() {

#line 1 "C:\Users\ASUS\AppData\Local\Temp\1B295748BBE8BAC1F0A311D6DBDAA25C87B5\5\LTW\Areas\Admin\Views\Loais\Delete.cshtml"
__o = model;


#line default
#line hidden

#line 2 "C:\Users\ASUS\AppData\Local\Temp\1B295748BBE8BAC1F0A311D6DBDAA25C87B5\5\LTW\Areas\Admin\Views\Loais\Delete.cshtml"
  
    ViewBag.Title = "Delete";
    Layout = "~/Areas/Admin/Views/Shared/_Layout.cshtml";


#line default
#line hidden

#line 3 "C:\Users\ASUS\AppData\Local\Temp\1B295748BBE8BAC1F0A311D6DBDAA25C87B5\5\LTW\Areas\Admin\Views\Loais\Delete.cshtml"
       __o = Html.DisplayNameFor(model => model.TenLoai);


#line default
#line hidden

#line 4 "C:\Users\ASUS\AppData\Local\Temp\1B295748BBE8BAC1F0A311D6DBDAA25C87B5\5\LTW\Areas\Admin\Views\Loais\Delete.cshtml"
       __o = Html.DisplayFor(model => model.TenLoai);


#line default
#line hidden

#line 5 "C:\Users\ASUS\AppData\Local\Temp\1B295748BBE8BAC1F0A311D6DBDAA25C87B5\5\LTW\Areas\Admin\Views\Loais\Delete.cshtml"
       __o = Html.DisplayNameFor(model => model.Hinh);


#line default
#line hidden

#line 6 "C:\Users\ASUS\AppData\Local\Temp\1B295748BBE8BAC1F0A311D6DBDAA25C87B5\5\LTW\Areas\Admin\Views\Loais\Delete.cshtml"
                __o = Url.Content("~/" +  @Html.DisplayFor(model => model.Hinh));


#line default
#line hidden

#line 7 "C:\Users\ASUS\AppData\Local\Temp\1B295748BBE8BAC1F0A311D6DBDAA25C87B5\5\LTW\Areas\Admin\Views\Loais\Delete.cshtml"
    using (Html.BeginForm()) {
        

#line default
#line hidden

#line 8 "C:\Users\ASUS\AppData\Local\Temp\1B295748BBE8BAC1F0A311D6DBDAA25C87B5\5\LTW\Areas\Admin\Views\Loais\Delete.cshtml"
   __o = Html.AntiForgeryToken();


#line default
#line hidden

#line 9 "C:\Users\ASUS\AppData\Local\Temp\1B295748BBE8BAC1F0A311D6DBDAA25C87B5\5\LTW\Areas\Admin\Views\Loais\Delete.cshtml"
                                

        

#line default
#line hidden

#line 10 "C:\Users\ASUS\AppData\Local\Temp\1B295748BBE8BAC1F0A311D6DBDAA25C87B5\5\LTW\Areas\Admin\Views\Loais\Delete.cshtml"
       __o = Html.ActionLink("Back to List", "Index");


#line default
#line hidden

#line 11 "C:\Users\ASUS\AppData\Local\Temp\1B295748BBE8BAC1F0A311D6DBDAA25C87B5\5\LTW\Areas\Admin\Views\Loais\Delete.cshtml"
              
    }

#line default
#line hidden
}
}
}