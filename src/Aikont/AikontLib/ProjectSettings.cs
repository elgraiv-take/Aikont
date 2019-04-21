using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elgraiv.Aikont
{
    public class ProjectSettings: BindableBase
    {
        private uint _startCharCode= 0xE000;
        public uint StartCharCode
        {
            get => _startCharCode;
            set => SetProperty(ref _startCharCode, value);
        }
    }
}
