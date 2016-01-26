using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Engine
{
    public class AssetManager //comment
    {
        public Physics physics;

        public ContentManager Content;
        public SpriteBatch spriteBatch;

        public List<Component> common;
        public List<Drawable> drawable;

        public List<Component> addComponent;
        public List<Component> remComponent;

        public AssetManager (ContentManager Content, SpriteBatch spriteBatch)
        {
            this.Content = Content;
            this.spriteBatch = spriteBatch;

            this.common = new List<Component>();
            this.drawable = new List<Drawable>();

            this.addComponent = new List<Component>();
            this.remComponent = new List<Component>();
        }

        public void create(Component component)
        {
            component.load();
            common.Add(component);

            if (component.isDrawable)
            {
                drawable.Add((Drawable)component);
                if (component.isSolid)
                {
                    physics.colliders.Add(((Solid)component).collision);
                }
            }
        }

        public void destroy(Component component)
        {
            common.Remove(component);

            if (component.isDrawable)
            {
                drawable.Remove((Drawable)component);
                if (component.isSolid)
                {
                    physics.colliders.Remove(((Solid)component).collision);
                }
            }
        }

        public void render()
        {
            foreach (Drawable component in drawable)
            {
                component.draw(this.spriteBatch);
            }
        }

        public void logic(GameTime gameTime, InputListener input)
        {
            foreach (Component component in common)
            {
                component.update(gameTime, input);
            }
            foreach (Component component in addComponent)
            {
                create(component);
            }
            foreach (Component component in remComponent)
            {
                destroy(component);
            }
            addComponent.Clear();
            remComponent.Clear();
        }

        public void loadContent(ContentManager Content, Texture2D texture, string name)
        {
            texture = Content.Load<Texture2D>(name);
        }
        public void destroyContent(ContentManager Content)
        {
            Content.Dispose();
        }
        public void destroyContent(Texture2D texture)
        {
            texture.Dispose();
        }
        public void destroyContent()
        {
            Content.Dispose();
            foreach (Drawable component in common)
            {
                component.destroy();
            }
            Drawable.destroyCamera();
        }
    }
}
