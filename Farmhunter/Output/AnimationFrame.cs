using Microsoft.Xna.Framework;

namespace Farmhunter.Output
{
    public class AnimationFrame
    {
        private Rectangle _sourceRectangle;
        public Rectangle SourceRectangle { get => this._sourceRectangle; set => this._sourceRectangle = value; }
        public AnimationFrame(Rectangle sourceRectangle)
        {
            this._sourceRectangle = sourceRectangle;
        }
    }
}
