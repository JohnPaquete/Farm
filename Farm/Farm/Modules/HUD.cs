using Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using System.Drawing;

namespace Engine.Modules
{
    public class HUD : Drawable
    {
        static Texture2D [] plant;

        bool isActive;

        public HUD ()
        {
            
        }
        
        public override void draw(SpriteBatch spriteBatch)
        {
            if (isActive)
            {
                Draw(spriteBatch, plant[0], new RectangleF(100, 100, 64, 64));
                Draw(spriteBatch, plant[1], new RectangleF(200, 100, 64, 64));
                Draw(spriteBatch, plant[2], new RectangleF(300, 100, 64, 64));
                Draw(spriteBatch, plant[3], new RectangleF(400, 100, 64, 64));
                Draw(spriteBatch, plant[4], new RectangleF(500, 100, 64, 64));
            }
        }

        public override void load()
        {
            isActive = true;
        }

        public static void loadResource(ContentManager Content)
        {
            plant = new Texture2D[5];
            plant[0] = Content.Load<Texture2D>("UI/carrotIcon");
            plant[1] = Content.Load<Texture2D>("UI/tomatoIcon");
            plant[2] = Content.Load<Texture2D>("UI/eggplantIcon");
            plant[3] = Content.Load<Texture2D>("UI/bananaIcon");
            plant[4] = Content.Load<Texture2D>("UI/watermelonIcon");
        }

        public override void update(GameTime gameTime, InputListener input)
        {

            if (input.isKeyPressed(Keys.Tab))
            {
                isActive = !isActive;
            }
            if (isActive)
            {
                
            }
                

        }

        int mod(int x, int m)
        {
            return (x % m + m) % m;
        }



        public override void destroy(){}
    }
}
