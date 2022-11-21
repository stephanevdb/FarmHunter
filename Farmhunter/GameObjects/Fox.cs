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
        SpriteEffects s = SpriteEffects.None;
        //textures
        Texture2D _foxIdleTexture;
        Texture2D _foxWalkTexture;
        Texture2D _foxSitTexture;
        Texture2D _foxCrouchTexture;
        //animations
        Animation _foxIdleAnimation;
        Animation _foxWalkAnimation;
        Animation _foxSitAnimation;
        Animation _foxCrouchAnimation;
        TimeSpan _foxIdleTime = TimeSpan.Zero;
        private Vector2 _foxPosition = new Vector2(100, 100);
        private Vector2 _foxVelocity = new Vector2(0, 0);
        private Vector2 _foxSpeed = new Vector2(3, 0);
        private double gravity = 9.8;
        public IInputReader _inputReader;
        private Vector2 screenDimensions = new Vector2(800, 480);
        
            
        public Fox(Texture2D foxIdleTexture, Texture2D foxWalkTexture , Texture2D foxSitTexture, Texture2D foxCrouchTexture , IInputReader inputReader)
        {
            _foxIdleTexture = foxIdleTexture; 
            _foxWalkTexture = foxWalkTexture;
            _foxSitTexture = foxSitTexture;
            _foxCrouchTexture = foxCrouchTexture;
            _inputReader = inputReader;
            // Idle animation
            _foxIdleAnimation = new Animation(10);
            int idleFramecount = 8;
            for (int i = 0; i < idleFramecount; i++)
            {
                _foxIdleAnimation.AddFrame(new AnimationFrame(new Rectangle(0+(i*60),0, 60,60)));
            }
            // Walk animation
            _foxWalkAnimation = new Animation(15);
            int walkFramecount = 8;
            for (int i = 0; i < walkFramecount; i++)
            {
                _foxWalkAnimation.AddFrame(new AnimationFrame(new Rectangle(0+(i*60),0, 60,60)));
            }
            // Sit animation
            _foxSitAnimation = new Animation(8);
            int sitFramecount = 24;
            for (int i = 0; i < sitFramecount; i++)
            {
                _foxSitAnimation.AddFrame(new AnimationFrame(new Rectangle(0+(i*60),0, 60,60)));
            }
            // crouch animation
            _foxCrouchAnimation = new Animation(10);
            int crouchFramecount = 8;
            for (int i = 0; i < crouchFramecount; i++)
            {
                _foxCrouchAnimation.AddFrame(new AnimationFrame(new Rectangle(0+(i*60),0, 60,60)));
            }

        }

    
        public void Move()
        {
            Vector2 direction = _inputReader.InputReader();
            if (direction.X > 0)
            {
                if (_foxPosition.X > 0 || _foxPosition.X < screenDimensions.X-60)
                {
                    s = SpriteEffects.None;
                    _foxPosition.X += _foxSpeed.X;
                }
                
            }
            else if (direction.X < 0)
            {
                if (_foxPosition.X > 0 || _foxPosition.X < screenDimensions.X)
                {
                    s = SpriteEffects.FlipHorizontally;
                    _foxPosition.X -= _foxSpeed.X;
                }
                
            }

        }
        public void Update(GameTime gameTime)
        {
            Move();
           _foxIdleAnimation.Update(gameTime);
           _foxWalkAnimation.Update(gameTime);
           _foxSitAnimation.Update(gameTime);
           Vector2 direction3 = _inputReader.InputReader();
           if (direction3.X == 0 )
           {
               _foxIdleTime += gameTime.ElapsedGameTime;
           }
           else
           {
               _foxIdleTime = TimeSpan.Zero;

           }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Animation foxFinalAnimation = _foxIdleAnimation;
            Texture2D foxFinalTexture = _foxIdleTexture;
            Vector2 direction2 = _inputReader.InputReader();
            if (direction2.X != 0)
            {
                foxFinalAnimation = _foxWalkAnimation;
                foxFinalTexture = _foxWalkTexture;
            }
            if (_foxIdleTime > TimeSpan.FromSeconds(5))
            {
                foxFinalAnimation = _foxSitAnimation;
                foxFinalTexture = _foxSitTexture;
            }
            if (direction2.Y < 0)
            {
                foxFinalAnimation = _foxCrouchAnimation;
                foxFinalTexture = _foxCrouchTexture;
            }
            
            
            
            spriteBatch.Draw(foxFinalTexture, _foxPosition , foxFinalAnimation.CurrentFrame.SourceRectangle, Color.White, 0f, Vector2.Zero, 1f, s, 0f);
            
        }
    }
}
