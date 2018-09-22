using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparkle.Handlers
{
    class KeysStroke
    {
        public static KeyboardState oldKState, KState;
        public static MouseState oldMState, MState;

        public enum Buttons { Left, Right, Middle }

        public static bool isMouseMoving;

        public static void Update()
        {
            KState = Keyboard.GetState();
            MState = Mouse.GetState();

            if(oldMState.Position != MState.Position)
            {
                isMouseMoving = true;
            }
            else
            {
                isMouseMoving = false;
            }
        }

        public static void oldUpdate()
        {
            oldKState = KState;
            oldMState = MState;
        }

        public static bool isKeyDown(Keys key)
        {
            if (KState.IsKeyDown(key))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool isKeyUp(Keys key)
        {
            if (KState.IsKeyUp(key))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static bool wasKeyDown(Keys key)

        {
            if (oldKState.IsKeyDown(key))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static bool wasKeyUp(Keys key)
        {
            if (oldKState.IsKeyUp(key))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool keyPressed(Keys key)
        {
            if (wasKeyUp(key) && isKeyDown(key))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool keyDePressed(Keys key)
        {
            if (wasKeyDown(key) && isKeyUp(key))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool isButtonDown(Buttons button)
        {
            switch (button)
            {
                case Buttons.Left:
                    if (MState.LeftButton == ButtonState.Pressed)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case Buttons.Right:
                    if (MState.RightButton == ButtonState.Pressed)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case Buttons.Middle:
                    if (MState.MiddleButton == ButtonState.Pressed)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                default:
                    return false;

            }
        }

        public static bool isButtonUp(Buttons button)
        {
            switch (button)
            {
                case Buttons.Left:
                    if (MState.LeftButton == ButtonState.Pressed)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case Buttons.Right:
                    if (MState.RightButton == ButtonState.Pressed)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case Buttons.Middle:
                    if (MState.MiddleButton == ButtonState.Pressed)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                default:
                    return false;
            }
        }

        static bool wasButtonDown(Buttons button)
        {
            switch (button)
            {
                case Buttons.Left:
                    if (oldMState.LeftButton == ButtonState.Pressed)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case Buttons.Right:
                    if (oldMState.RightButton == ButtonState.Pressed)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case Buttons.Middle:
                    if (oldMState.MiddleButton == ButtonState.Pressed)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                default:
                    return false;
            }
        }

        static bool wasButtonUp(Buttons button)
        {
            switch (button)
            {
                case Buttons.Left:
                    if (oldMState.LeftButton == ButtonState.Pressed)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case Buttons.Right:
                    if (oldMState.RightButton == ButtonState.Pressed)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case Buttons.Middle:
                    if (oldMState.MiddleButton == ButtonState.Pressed)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                default:
                    return false;
            }
        }

        public static bool scrollUp()
        {
            if (MState.ScrollWheelValue > oldMState.ScrollWheelValue)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool scrollDown()
        {
            if (MState.ScrollWheelValue < oldMState.ScrollWheelValue)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


    }
}
