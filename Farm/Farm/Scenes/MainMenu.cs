using Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Components;

namespace Scenes
{
    class MainMenu : Scene
    {
        private bool exit;
        Vector2 screen;

        public MainMenu(ContentManager Content, SpriteBatch spriteBatch, Vector2 screen) : base(Content, spriteBatch)
        {
            this.screen = screen;
            Drawable.initCamera(new Vector2(0, 0), screen, 1.0f, 0.5f, 4.0f);
        }

        public override Scene change()
        {
            if (exit)
            {
                return new Farm(this.Content, this.spriteBatch, screen);
            }
            return null;
        }

        public override void draw()
        {
            
        }

        public override void load()
        {
            create(new Switcher());
        }

        public override void unload()
        {
            destroyContent();
        }

        public override void update(GameTime gameTime, InputListener input)
        {
            
        }
    }
}
