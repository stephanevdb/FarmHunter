﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Farmhunter.GameObjects;
using Farmhunter.Control;

namespace Farmhunter
{
    public class Game : Microsoft.Xna.Framework.Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Texture2D _foxIdleTexture;
        private Texture2D _foxWalkTexture;
        private Texture2D _foxSitTexture;
        private Texture2D _foxCrouchTexture;
        private Fox fox;
        public Game()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
         
            base.Initialize();
            fox = new Fox(_foxIdleTexture,_foxWalkTexture,_foxSitTexture ,_foxCrouchTexture, new KeyboardReader());
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _foxIdleTexture = Content.Load<Texture2D>("Fox/fox_idle_strip8");
            _foxWalkTexture = Content.Load<Texture2D>("Fox/fox_run_strip8");
            _foxSitTexture = Content.Load<Texture2D>("Fox/fox_sit02_strip24");
            _foxCrouchTexture = Content.Load<Texture2D>("Fox/fox_crouch_strip8");
            
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            
            fox.Update(gameTime);
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.HotPink);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            fox.Draw(_spriteBatch);
            _spriteBatch.End();
   
            
            base.Draw(gameTime);
        }
    }
}