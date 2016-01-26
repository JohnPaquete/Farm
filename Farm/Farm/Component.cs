using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Engine
{
    public abstract class Component
    { 
        public Boolean isDrawable = false;
        public Boolean isSolid = false;

        public AssetManager manager;

        abstract public void load();
        abstract public void update(GameTime gameTime, InputListener input);
        abstract public void draw(SpriteBatch spriteBatch);
        abstract public void destroy();
    }
}
