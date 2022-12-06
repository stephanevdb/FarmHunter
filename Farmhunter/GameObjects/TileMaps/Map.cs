using System.IO;
using Microsoft.Xna.Framework.Graphics;

namespace Farmhunter.GameObjects.TileMaps;

public class Map
{
    private int[,] _map;
    private int width;
    private int height;
    private int tileWidth = 128;
    private int tileHeight = 128;
    private Texture2D mapTexture;
    
    
    public Map(int width, int height, string csvPath,Texture2D mapTexture)
    {
        this.width = width;
        this.height = height;
        this._map = new int[this.height, this.width];
        this._map = File.ReadLines(csvPath).Select(x => x.Split(',')).ToArray();
        this.mapTexture = mapTexture;
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(mapTexture, new Vector2(0, 0), Color.White);
    }
}

