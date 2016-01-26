using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Engine
{
    public abstract class Solid : Drawable
    {
        public RectangleF collision;

        public Solid ()
        {
            this.isSolid = true;
        }
    }
}
