using Microsoft.Xna.Framework;
using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Engine
{
    public class Physics
    {
        public List<RectangleF> colliders;  //all colliders

        public Physics ()
        {
            colliders = new List<RectangleF>();
        }
        public void transform(Vector2 move, ref Vector2 position, ref RectangleF collider)
        {
            transform(move, ref position, ref collider, this.colliders);
        }
        public void transform(Vector2 move, ref Vector2 position, ref RectangleF collider, List<RectangleF> colliders)
        {
            RectangleF temp = new RectangleF(collider.X + move.X, collider.Y + move.Y, collider.Width, collider.Height);

            colliders.Remove(collider);

            if (move.X != 0 || move.Y != 0)
            {
                foreach (RectangleF rect in colliders)
                {
                    RectangleF collision = RectangleF.Intersect(temp, rect);

                    if (!collision.IsEmpty)
                    {
                        if (move.X == 0 || move.Y == 0)
                        {
                            move.X -= (float)collision.Width * (float)Math.Sign(move.X);
                            move.Y -= (float)collision.Height * (float)Math.Sign(move.Y);
                        }
                        else
                        {
                            float y1 = 0, x1 = 0;//rect corner
                            float y2 = 0, x2 = 0;//component corner

                            if (move.X > 0.0f && move.Y > 0.0f)//down right
                            {
                                y1 = rect.Y;
                                x1 = rect.X;

                                y2 = collider.Y + collider.Height;
                                x2 = collider.X + collider.Width;
                            }
                            else if(move.X > 0.0f && move.Y < 0.0f)//up right
                            {
                                y1 = rect.Y + rect.Height;
                                x1 = rect.X;

                                y2 = collider.Y;
                                x2 = collider.X + collider.Width;
                            }
                            else if(move.X < 0.0f && move.Y > 0.0f)//down left
                            {
                                y1 = rect.Y;
                                x1 = rect.X + rect.Width;

                                y2 = collider.Y + collider.Height;
                                x2 = collider.X;
                            }
                            else if(move.X < 0.0f && move.Y < 0.0f)//up left
                            {
                                y1 = rect.Y + rect.Height;
                                x1 = rect.X + rect.Width;

                                y2 = collider.Y;
                                x2 = collider.X;
                            }

                            float hitX, m;
                            m = move.Y / move.X;

                            float ydiff = y1 - y2;

                            hitX = x2 + ((float)ydiff / m);

                            if ((move.X > 0.0f && hitX >= x1) || (move.X < 0.0f && hitX <= x1))
                            {
                                move.Y -= (float)collision.Height * (float)Math.Sign(move.Y);
                            }
                            
                            else
                            {
                                move.X -= (float)collision.Width * (float)Math.Sign(move.X);
                            }
                        }
                    }

                }

                position.X += move.X;
                position.Y += move.Y;

                collider.X = position.X;
                collider.Y = position.Y;
            }

            colliders.Add(collider);

        }
        public Boolean isColliding(Vector2 dir, RectangleF collider)
        {
            RectangleF temp = new RectangleF(collider.X + dir.X, collider.Y + dir.Y, collider.Width, collider.Height);

            Boolean contains = colliders.Contains(collider);
            if (contains)
                colliders.Remove(collider);

            foreach (RectangleF rect in colliders)
            {
                RectangleF collide = RectangleF.Intersect(temp, rect);
                if (!collide.IsEmpty) {
                    return true;
                }
            }
            if (contains)
                colliders.Add(collider);

            return false;
        }
        public static RectangleF BoundingBox(Vector2 position, float width, float height)
        {
            return new RectangleF(position.X, position.Y, width, height);
        }
        public RectangleF boundingBox(Vector2 position, float width, float height)
        {
            return new RectangleF(position.X, position.Y, width, height);
        }
    }
}
