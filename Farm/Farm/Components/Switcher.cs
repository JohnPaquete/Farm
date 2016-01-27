using Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Components
{
    class Switcher : Component
    {
        bool exit;

        public Switcher()
        {

        }
        public override void destroy()
        {
            
        }

        public override void draw(SpriteBatch spriteBatch)
        {
            
        }

        public override void load()
        {
            
        }

        public override void update(GameTime gameTime, InputListener input)
        {
            if (input.isKeyPressed(Keys.Enter))
                exit = true;
        }
    }
}
