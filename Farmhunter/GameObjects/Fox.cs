using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Farmhunter.Control;
using Farmhunter.Output;

namespace Farmhunter.GameObjects
{
    public class Fox : IGameObject
    {
        Texture2D _foxTexture;
        Animation _foxIdleAnimation;
        private Vector2 _foxPosition = new Vector2(100, 100);
        private Vector2 _foxVelocity = new Vector2(0, 0);
        private double gravity = 9.8;
        public IInputReader _inputReader;
        private Vector2 screenDimensions = new Vector2(800, 480);
        
            
        public Fox(Texture2D foxTexture, IInputReader inputReader)
        {
            _foxTexture = foxTexture; 
            _inputReader = inputReader;
            // Idle animation
            _foxIdleAnimation = new Animation(15);
            int idleFramecount = 8;
            for (int i = 0; i < idleFramecount; i++)
            {
                _foxIdleAnimation.AddFrame(new AnimationFrame(new Rectangle(0+(i*60),0, 60,60)));
            }

        }

    
        public void Move()
        {
            Vector2 direction = _inputReader.InputReader();
            if (direction.X > 0)
            {
                if (_foxPosition.X > 0 || _foxPosition.X < screenDimensions.X-60)
                {
                    _foxPosition.X++;
                }
                
            }
            else if (direction.X < 0)
            {
                if (_foxPosition.X > 0 || _foxPosition.X < screenDimensions.X)
                {
                    _foxPosition.X--;
                }
                
            }

        }
        public void Update(GameTime gameTime)
        {
            Move();
           _foxIdleAnimation.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_foxTexture, _foxPosition , _foxIdleAnimation.CurrentFrame.SourceRectangle, Color.White);
            
        }
    }
}
