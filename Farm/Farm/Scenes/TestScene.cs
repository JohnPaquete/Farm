using System;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Engine;
using Microsoft.Xna.Framework.Audio;
using Engine.Modules;

namespace Scenes
{
    class TestScene : Scene
    {
        public TestScene(ContentManager Content, SpriteBatch spriteBatch, Vector2 screen) : base(Content, spriteBatch)//help
        {
            physics = new Physics();
            Drawable.initCamera(new Vector2(0, 0), screen, 1.0f, 0.5f, 4.0f);
            load();
        }
        public override void load()
        {
            HUD.loadResource(Content);

            create(new HUD());
        }
        public override void draw()
        {
            render();
        }
        public override void update(GameTime gameTime, InputListener input)
        {
            logic(gameTime, input);
        }
        public override void unload()
        {
            destroyContent();
        }

        public override Scene change()
        {
            return null;
        }
    }
}
