using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Farmhunter.Animation;

namespace Farmhunter.GameObjects
{
    internal class Fox : IGameObject
    {
        private Texture2D _foxTexture;
        private Vector2 position;
        //Animation animation;

        public Fox(Texture2D foxTexture)
        {
            this._foxTexture = foxTexture;
            //animation = new Animation();
            
        }
        public void Update(GameTime gameTime)
        {
            throw new NotImplementedException();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            
            throw new NotImplementedException();
        }
    }
}
