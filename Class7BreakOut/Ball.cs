using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGameLibrary.Sprite;
using MonoGameLibrary.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class7BreakOut
{
    public class Ball : DrawableSprite
    {
        GameConsole console;
        
        public Ball(Game game) : base(game)
        {
            this.Direction = new Vector2(1, 1);
            this.Speed = 200;

            //Lazy load game console
            console = (GameConsole)this.Game.Services.GetService<IGameConsole>();
            if(console == null)
            {
                console = new GameConsole(this.Game);
                this.Game.Components.Add(console);
            }
        }

        protected override void LoadContent()
        {
            this.spriteTexture = this.Game.Content.Load<Texture2D>("ballSmall");
            base.LoadContent();
            //TODO probabluy need to put this on the paddle as soon as I have a paddle
            this.Location = new Vector2(200, 200); 
        }

        /// <summary>
        /// private time between frames
        /// </summary>
        float time;

        public override void Update(GameTime gameTime)
        {
            time = (float)gameTime.ElapsedGameTime.Milliseconds / 1000;
            this.keepBallOnScreen();
            this.Location += this.Direction * (this.Speed * time);
            base.Update(gameTime);

            //Log Ball location to console
            console.Log("Ball Location", this.Location.ToString());
        }

        private void keepBallOnScreen()
        {
            //Left and Right
            if ((this.Location.X < 0) 
                |
                (this.Location.X > this.GraphicsDevice.Viewport.Width - this.spriteTexture.Width))
                this.Direction.X *= -1;
            //Left and Right
            if ((this.Location.Y < 0)
                |
                (this.Location.Y > this.GraphicsDevice.Viewport.Height - this.spriteTexture.Height))
                this.Direction.Y *= -1;

        }
    }
}
