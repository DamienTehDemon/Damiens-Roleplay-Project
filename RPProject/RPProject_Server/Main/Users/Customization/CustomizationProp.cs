﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace roleplay.Main.Users.Customization
{
    public class CustomizationProp
    {
        public int Prop = 0;
        public int Drawable = 0;
        public int Texture = 0;
        public int Pallet = 0;

        public CustomizationProp(int prop, int drawable, int texture, int pallet)
        {
            Prop = prop;
            Drawable = drawable;
            Texture = texture;
            Pallet = pallet;
        }
    }
}
