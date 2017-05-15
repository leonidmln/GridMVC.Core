using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Html;

namespace GridMvc
{
    public interface IMasterControl
    {
        /// <summary>
        /// Render details control
        /// </summary>
        /// <param name="parent">Key element</param>
        /// <returns></returns>
        IHtmlContent RenderDetailsGrid(object parent);
    }
}
