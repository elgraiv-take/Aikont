using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elgraiv.Aikont
{
    public class CommonData : BindableBase
    {
        private int _size;
        public int Size
        {
            get => _size;
            set => SetProperty(ref _size, value);
        }


        private float _defaultImageSize;
        public float DefaultImageSize
        {
            get => _defaultImageSize;
            set => SetProperty(ref _defaultImageSize, value);
        }

    }
}
