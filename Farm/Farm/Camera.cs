using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Engine
{
    public class Camera
    {
        public float zoom, maxZoom, minZoom;
        public Vector2 position, dimensions;
        public RectangleF screen;

        public Camera(float x, float y, float width, float height, float zoom, float minZoom, float maxZoom)
        {
            this.position = new Vector2(x, y);
            this.dimensions = new Vector2(width, height);
            this.zoom = zoom;
            this.minZoom = minZoom;
            this.maxZoom = maxZoom;
            this.screen = new RectangleF(x, y, width/zoom, height/zoom);
        }

        public Camera(Vector2 position, Vector2 dimensions, float zoom, float minZoom, float maxZoom)
        {
            this.position = position;
            this.dimensions = dimensions;
            this.zoom = zoom;
            this.minZoom = minZoom;
            this.maxZoom = maxZoom;
            this.screen = new RectangleF(position.X, position.Y, dimensions.X / zoom, dimensions.Y / zoom);
        }

        public void setPos(float x, float y, float zoom)
        {
            this.position.X = x;
            this.position.Y = y;
            this.zoom = zoom;
            this.screen.X = x;
            this.screen.Y = y;
            this.screen.Width = dimensions.X / zoom;
            this.screen.Height = dimensions.Y / zoom;
        }

        public void setPos(Vector2 pos)
        {
            this.position.X = pos.X;
            this.position.Y = pos.Y;
            this.screen.X = pos.X;
            this.screen.Y = pos.Y;
        }        

        public void addPos (Vector2 deltaPos)
        {
            this.position.X += deltaPos.X;
            this.position.Y += deltaPos.Y;
            this.screen.X += deltaPos.X;
            this.screen.Y += deltaPos.Y;
        }

        public Vector2 getPos ()
        {
            return this.position;
        }

        public Microsoft.Xna.Framework.Rectangle transform(RectangleF rect)
        {
            return new Microsoft.Xna.Framework.Rectangle ((int)Math.Round(((rect.X - position.X) * zoom) - 1), 
                                                          (int)Math.Round(((rect.Y - position.Y) * zoom) - 1), 
                                                          (int)Math.Round(rect.Width * zoom + 2), 
                                                          (int)Math.Round(rect.Height * zoom + 2));
        }

        public RectangleF transformF(RectangleF rect)
        {
            return new RectangleF((float)Math.Round(((rect.X - position.X) * zoom) - 1),
                                                          (float)Math.Round(((rect.Y - position.Y) * zoom) - 1),
                                                          (float)Math.Round(rect.Width * zoom + 2),
                                                          (float)Math.Round(rect.Height * zoom + 2));
        }

        public Vector2 transformF(Vector2 pos)
        {
            return new Vector2((float)Math.Round((pos.X - position.X) * zoom),
                               (float)Math.Round((pos.Y - position.Y) * zoom));
        }

        public void setZoom(float zoom)
        {
            this.zoom = zoom;
            this.screen.Width = dimensions.X / zoom;
            this.screen.Height = dimensions.Y / zoom;

            if (this.zoom < minZoom)
            {
                this.zoom = minZoom;
                this.screen.Width = dimensions.X / this.zoom;
                this.screen.Height = dimensions.Y / this.zoom;
            }
            else if (this.zoom > maxZoom)
            {
                this.zoom = maxZoom;
                this.screen.Width = dimensions.X / this.zoom;
                this.screen.Height = dimensions.Y / this.zoom;
            }
        }

        public void addZoom(float deltaZoom)
        {
            setZoom(this.zoom + deltaZoom);
        }

        public float getZoom()
        {
            return zoom;
        }

        public bool isOnScreen(RectangleF rect)
        {
            if (RectangleF.Intersect(rect, screen) == RectangleF.Empty)
                return false;
            return true;
        }
    }
}
