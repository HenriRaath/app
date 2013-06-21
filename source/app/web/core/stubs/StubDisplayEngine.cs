﻿using System.Web;

namespace app.web.core.stubs
{
  public class StubDisplayEngine : IDisplayInformation
  {
    public void display<ReportModel>(ReportModel report)
    {
      HttpContext.Current.Items["report"] = report;
      HttpContext.Current.Server.Transfer("~/views/DepartmentBrowser.aspx");
    }
  }
}