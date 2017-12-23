namespace SkiResorts.Services
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface IPdfGenerator
    {
        byte[] GeneratePdfFromHtml(string html);
    }
}
