using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparkle.Handlers
{
    class ContentLoader : Main
    {
        public static T Load<T>(string name)
        {
            return content.Load<T>(name);
        }
    }
}
