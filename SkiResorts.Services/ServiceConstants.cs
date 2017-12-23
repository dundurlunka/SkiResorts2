namespace SkiResorts.Services
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ServiceConstants
    {
        public const string PdfLiftCardFormat = @"
<h1>Lift card</h1>
<h2>Bought on: {0}</h2>
<h2>To be used on: {1}</h2>
<br />
<h2>Lift card ID: {2}</h2>
<h3>User ID - {3}</h3>
<h4>Total: {4} BGN</h4>
";
    }
}
