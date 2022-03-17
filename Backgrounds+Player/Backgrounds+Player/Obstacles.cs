using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Backgrounds_Player
{
    public class Obstacles : ObstacleAnimation
    {
        private bool _constantSpeed; //

        //private Texture2D _texture;
        public Obstacles(Texture2D texture, int numOfFrames, int positionx, bool constantSpeed = false, bool placeBottom = true)
            : base(texture, positionx, placeBottom)
        {
            SetTexture(numOfFrames);

            _texture = texture;
            _constantSpeed = constantSpeed;
        }

        public void Update(GameTime gameTime, float playerSpeedX) 
        {
            Update();
            if (_constantSpeed) Position.X -= 3;
        }

        //public Rectangle Rectangle => new Rectangle((int)Position.X, (int)Position.Y, _texture.Width, _texture.Height);

        //public void Draw(SpriteBatch spriteBatch, Vector2 cameraPosition)
        //{

                //spriteBatch.Draw(_texture, Position - cameraPosition, null, Color.White, 0, new Vector2(0, 0), 1f, SpriteEffects.None, 1);

        //}
    }
}

// här är varje del i listan
