using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmhunter.Control
{
    internal class KeyboardReader : IInputReader
    {
        public Vector2 InputReader()
        {
            KeyboardState state = Keyboard.GetState();
            Vector2 direction = Vector2.Zero;
            GamePadCapabilities capabilities = GamePad.GetCapabilities(PlayerIndex.One);
            if (capabilities.HasDPadDownButton)
            {
                GamePadState controllerState = GamePad.GetState(PlayerIndex.One);
                if (controllerState.IsButtonDown(Buttons.DPadLeft) || controllerState.ThumbSticks.Left.X < 0)
                {
                    if (controllerState.ThumbSticks.Left.X == 0)
                    {
                        direction.X -= 100;
                    }
                    else
                    {
                        direction.X -= controllerState.ThumbSticks.Left.X*100;
                    }
                }
                if (controllerState.IsButtonDown(Buttons.DPadRight) || controllerState.ThumbSticks.Left.X > 0)
                {
                    if (controllerState.ThumbSticks.Left.X == 0)
                    {
                        direction.X += 100;
                    }
                    else
                    {
                        direction.X += controllerState.ThumbSticks.Left.X*100;
                    }
                }

                if (controllerState.IsButtonDown(Buttons.RightShoulder))
                {
                    direction.Y -= 100;
                }
                if (controllerState.IsButtonDown(Buttons.A))
                {
                    direction.Y += 100;
                }
            }
            if (state.IsKeyDown(Keys.Left))
            {
                direction.X -= 100;
            }
            if (state.IsKeyDown(Keys.Right))
            {
                direction.X += 100;
            }

            if (state.IsKeyDown(Keys.Space))
            {
                direction.Y += 100;
            }

            if (state.IsKeyDown(Keys.C))
            {
                direction.Y -= 100;
            }
            return direction;
        }
    }
}
