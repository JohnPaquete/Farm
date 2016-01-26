using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Engine
{
    public abstract class Scene : AssetManager
    {
        public Scene (ContentManager Content, SpriteBatch spriteBatch) : base(Content, spriteBatch)
        {

        }

        abstract public void load();
        abstract public void update(GameTime gameTime, InputListener input);
        abstract public void draw();
        abstract public void unload();
        abstract public Scene change();
        
    }
}
