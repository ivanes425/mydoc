using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for IProspect
/// </summary>
public interface IListBuilder
{
    Dictionary<string, string> BuildListOfValues();

    Dictionary<string, string> BuildListOfValues(DataTable dt);
}
