namespace Farmhunter.GameObjects.TileMaps;

public class Map
{
    private int[,] _map;
    private int width;
    private int height;
    private int tileWidth = 128;
    private int tileHeight = 128;
    
    
    public Map(int width, int height)
    {
        this.width = width;
        this.height = height;
        this._map = new int[this.height, this.width];
    }
}