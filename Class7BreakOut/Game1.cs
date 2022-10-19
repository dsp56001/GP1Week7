﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGameLibrary.Util;

namespace Class7BreakOut
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        GameConsole console;

        MonogameBlock block;
        Ball ball;
        Paddle paddle;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            console = new GameConsole(this);
            this.Components.Add(console);

            block = new MonogameBlock(this);
            this.Components.Add(block);

            ball = new Ball(this);
            this.Components.Add(ball);

            paddle = new Paddle(this, ball);
            this.Components.Add(paddle);
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            //DEVTEST hit by ball
            if(ball.Intersects(block))
            {
                console.GameConsoleWrite("Ball hit block" + gameTime.TotalGameTime.TotalMilliseconds);
                if(ball.PerPixelCollision(block))
                {
                    console.GameConsoleWrite("Ball hit block per pices" + +gameTime.TotalGameTime.TotalMilliseconds);
                    block.HitByBall();
                }
            }
            

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}