
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Engine
{
    public abstract class Drawable : Component 
    {
        static Camera camera;

        public Drawable ()
        {
            isDrawable = true;
        }

        public static void initCamera (Vector2 position, Vector2 dimensions, float zoom, float minZoom, float maxZoom)
        {
            camera = new Camera(position, dimensions, zoom, minZoom, maxZoom);
        }

        public static void destroyCamera ()
        {
            camera = null;
        }

        public static void setCamPos(Vector2 position)
        {
            camera.setPos(position);
        }

        public static void addCamPos(Vector2 position)
        {
            camera.addPos(position);
        }

        public static void setCamZoom(float zoom)
        {
            camera.setZoom(zoom);
        }

        public static void addCamZoom(float zoom)
        {
            camera.addZoom(zoom);
        }

        public static float getCamZoom()
        {
            return camera.getZoom();
        }

        public static Vector2 getCamPos()
        {
            return camera.position;
        }

        public static RectangleF getCamRect()
        {
            return camera.screen;
        }

        public void Draw(SpriteBatch spriteBatch, Texture2D texture, RectangleF rect)
        {
            spriteBatch.Draw(texture, camera.transform(rect), null, Microsoft.Xna.Framework.Color.White);
        }

        public void Draw(SpriteBatch spriteBatch, Texture2D texture, RectangleF rect, Microsoft.Xna.Framework.Color color)
        {
            spriteBatch.Draw(texture, camera.transform(rect), null, color);
        }

        public void Draw(SpriteBatch spriteBatch, Texture2D texture, RectangleF rect, float angle, Vector2 origin)
        {
            spriteBatch.Draw(texture, camera.transform(rect), null, Microsoft.Xna.Framework.Color.White, angle, origin, SpriteEffects.None, 0.0f);
        }

        public void absDraw(SpriteBatch spriteBatch, Texture2D texture, RectangleF rect, Microsoft.Xna.Framework.Color color)
        {
            spriteBatch.Draw(texture, new Microsoft.Xna.Framework.Rectangle((int)rect.X, (int)rect.Y, (int)rect.Width, (int)rect.Height), null, color);
        }

        public void absDraw(SpriteBatch spriteBatch, Texture2D texture, Vector2 position, float angle)
        {
            spriteBatch.Draw(texture, position, null, Microsoft.Xna.Framework.Color.White, angle, new Vector2(texture.Width / 2, texture.Height / 2), 1.0f, SpriteEffects.None, 0f);
        }

        public void absDraw(SpriteBatch spriteBatch, Texture2D texture, Microsoft.Xna.Framework.Color color, Vector2 position, float angle, float scale)
        {
            spriteBatch.Draw(texture, position, null, color, angle, new Vector2(texture.Width / 2, texture.Height / 2), scale, SpriteEffects.None, 0f);
        }

        public void absDraw(SpriteBatch spriteBatch, Texture2D texture, RectangleF rect, float angle, Vector2 origin)
        {
            spriteBatch.Draw(texture, new Microsoft.Xna.Framework.Rectangle((int)rect.X + (int)rect.Width, (int)rect.Y + (int)rect.Height, (int)rect.Width, (int)rect.Height), null, Microsoft.Xna.Framework.Color.White, angle, origin, SpriteEffects.None, 0.0f);
        }

        public void absDraw(SpriteBatch spriteBatch, Texture2D texture, Microsoft.Xna.Framework.Color color, Vector2 position)
        {
            spriteBatch.Draw(texture, position, color);
        }

        // FOR ALL YOUR HEXAGON DRAWING NEEDS :D
        public void hexDraw(SpriteBatch spriteBatch, Texture2D texture, int x, int y, float tileSizeX, float tileSizeY, Microsoft.Xna.Framework.Color color)
        {
            Draw(spriteBatch, texture, new RectangleF(x * tileSizeX - tileSizeX / 8,
                                                     (y + (float)(mod(x, 2)) / 2) * tileSizeY,
                                                     tileSizeX * 4 / 3,
                                                     tileSizeY)
                                          , Microsoft.Xna.Framework.Color.White);
        }

        int mod(int x, int m)
        {
            return (x % m + m) % m;
        }

    }
}
