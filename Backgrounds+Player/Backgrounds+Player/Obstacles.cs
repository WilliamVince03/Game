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
        private bool _constantSpeed; 

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

    }
}