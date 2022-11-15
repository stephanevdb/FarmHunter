using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Farmhunter.Output
{
    public class Animation
    {
        public AnimationFrame CurrentFrame { get; set; }
        private List<AnimationFrame> frames;
        private int counter;

        public Animation()
        {
            this.frames = new List<AnimationFrame>();
        }

        public void AddFrame(AnimationFrame frame)
        {
            frames.Add(frame);
            CurrentFrame = frames[0];
        }
        public void update(GameTime gameTime)
        {
            CurrentFrame = frames[counter];
            counter++;

            if (counter >= frames.Count)
            {
                counter = 0;
            }
        }

    }
}
