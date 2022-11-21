using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Farmhunter.Output
{
    public class Animation
    {
        public AnimationFrame CurrentFrame { get; set; }
        private List<AnimationFrame> _frames;
        

        private int _counter;
        private double _frameIndex;
        private int fps;

        public Animation(int fps)
        {
            _frames = new List<AnimationFrame>();
            this.fps = fps;
        }
        public void AddFrame(AnimationFrame aframe)
        {
            _frames.Add(aframe);
            CurrentFrame = _frames[0];
        }
        public void Update(GameTime gameTime)
        {
            CurrentFrame = _frames[_counter];
            _frameIndex += gameTime.ElapsedGameTime.TotalSeconds;

            if (_frameIndex >= 1d/ fps)
            {
                _frameIndex = 0;
                _counter++;
            }

            if (_counter >= _frames.Count)
            {
                _counter = 0;
            }
        }

    }
}
