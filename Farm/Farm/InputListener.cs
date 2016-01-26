using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Engine
{
    public class InputListener
    {
        GamePadState oldStateG,
                  currentStateG;

        KeyboardState oldStateK,
                  currentStateK;

        MouseState oldStateM,
                  currentStateM;

        public void update()
        {
            oldStateG = currentStateG;
            currentStateG = GamePad.GetState(PlayerIndex.One);
            oldStateK = currentStateK;
            currentStateK = Keyboard.GetState();
            oldStateM = currentStateM;
            currentStateM = Mouse.GetState();
        }

        /*
            Keyboard input methods
        */
        public Boolean isKeyDown(Keys key)
        {
            return currentStateK.IsKeyDown(key);
        }
        public Boolean isKeyPressed(Keys key)
        {
            return (isKeyDown(key) && !oldStateK.IsKeyDown(key));
        }
        public Boolean isKeyReleased(Keys key)
        {
            return (!isKeyDown(key) && oldStateK.IsKeyDown(key));
        }

        /*
            Mouse input methods
        */
        public Vector2 mouseXY()
        {
            return new Vector2(currentStateM.X, currentStateM.Y);
        }
        public Vector2 mouseDelta()
        {
            return new Vector2(currentStateM.X - oldStateM.X, currentStateM.Y - oldStateM.Y);
        }

        public Boolean isLeftDown()
        {
            return (currentStateM.LeftButton == ButtonState.Pressed);
        }
        public Boolean isLeftPressed()
        {
            return (isLeftDown() && !(oldStateM.LeftButton == ButtonState.Pressed));
        }
        public Boolean isLeftReleased()
        {
            return (!isLeftDown() && (oldStateM.LeftButton == ButtonState.Pressed));
        }

        public Boolean isRightDown()
        {
            return (currentStateM.RightButton == ButtonState.Pressed);
        }
        public Boolean isRightPressed()
        {
            return (isRightDown() && !(oldStateM.RightButton == ButtonState.Pressed));
        }
        public Boolean isRightReleased()
        {
            return (!isRightDown() && (oldStateM.RightButton == ButtonState.Pressed));
        }

        public Boolean isMiddleDown()
        {
            return (currentStateM.MiddleButton == ButtonState.Pressed);
        }
        public Boolean isMiddlePressed()
        {
            return (isMiddleDown() && !(oldStateM.MiddleButton == ButtonState.Pressed));
        }
        public Boolean isMiddleReleased()
        {
            return (!isMiddleDown() && (oldStateM.MiddleButton == ButtonState.Pressed));
        }

        public int deltaRotation()
        {
            return currentStateM.ScrollWheelValue - oldStateM.ScrollWheelValue;
        }

    }
}
