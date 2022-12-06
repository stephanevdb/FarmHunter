using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Farmhunter.GameObjects.TileMaps;

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