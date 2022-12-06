using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Farmhunter.Control;
using Farmhunter.Output;

namespace Farmhunter.GameObjects;

public class Tile : IGameObject
{
    private Texture2D _tileTexture;
    private Vector2 _tilePosition;
    
    
    public void Update(GameTime gameTime)
    {
        
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(_tileTexture, _tilePosition, Color.White);
    }
}