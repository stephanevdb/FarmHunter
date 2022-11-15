using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Farmhunter.Output;

namespace Farmhunter.GameObjects
{
    internal class Fox : IGameObject
    {
        private Texture2D _foxTexture;
        private Vector2 position;
        private Animation _currentAnimation;
        private Rectangle _spriteRectangle;
        private int x = 1;
        //Animation animation;

        public Fox(Texture2D foxTexture)
        {
            this._foxTexture = foxTexture;
            //animation = new Animation();
            
        }
        public void Update(GameTime gameTime)
        {
            x++;
            x=x%(8*4);
            _spriteRectangle = new Rectangle(60*(x/4), 0, 60, 60);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_foxTexture, new Vector2(100, 100), _spriteRectangle, Color.White);
            
        }
    }
}
