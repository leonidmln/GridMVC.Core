using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Html;

namespace GridMvc
{
    public interface IDetailsControl<TKey>
    {
        IHtmlContent RenderDetailsControl(TKey parent);
        
    }
}
