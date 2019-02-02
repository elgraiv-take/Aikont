using Elgraiv.Aikont.Ttx;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Elgraiv.Aikont.Cli
{

    class Program
    {
        static void Main(string[] args)
        {
            ProjectConverter.Convert(args[0], args[1]);
        }


    }
}
