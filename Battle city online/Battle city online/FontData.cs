using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battle_city_online
{
    class FontData
    {
        public string name = "";
        public string texture = "";
        public enum Spacing
        {
            CONSTANT_NUMBER,
            CONSTANT_DIMENSION,
            DYNAMIC_DIMENSION
        }
        public Spacing spacing = Spacing.CONSTANT_NUMBER;
        public int spacingX = 0, spacingY = 0;
        public string characterMap = "";
    }
}
