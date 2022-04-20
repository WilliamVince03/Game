using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Backgrounds_Player
{
    public class ObstacleAnimation
    {
        protected float _layer { get; set; }
        protected Texture2D _texture;
        public float Layer
        {
            get { return _layer; }
            set
            {
                _layer = value;
            }
        }
        private int _ticks = 0;
        private int _frameWidth = 0;
        private int _frameHeight = 0;
        private int _numOfFrames = 0;
        public Vector2 Position = Vector2.Zero;

        public SpriteEffects Orientation = SpriteEffects.None;
        public int Row { get; set; } = 0;
        public int _currentFrame { get; set; } = 0;
        public int AnimationSpeed { get; set; } = 10;
        private Random rnd = new Random();
        private int pos;

        public ObstacleAnimation(Texture2D texture, int positionx, bool placeBottom = true)
        {
            _texture = texture;
            var bodyheight = Game1.ScreenHeight - texture.Height;
            if (placeBottom)
                Position = new Vector2(positionx, bodyheight - 40);//50
            else
            {
                var n = rnd.Next(1, 100);
                // för låg sannorlikhet med höga
                //if (n < 70) pos = bodyheight - 50;
                //else if (n < 90) pos = bodyheight - 70;
                //else pos = bodyheight - texture.Height*5; //200 bra för duckning
                if (n < 25) pos = bodyheight - 50;
                else if (n < 50) pos = bodyheight - 70;
                else pos = bodyheight - 320; //200 bra för duckning
                Position = new Vector2(positionx, pos);
            }
        }

        public void Update()
        {
            if (_ticks-- < 0)
            {
                _ticks = AnimationSpeed;
                _currentFrame++;
                if (_currentFrame >= _numOfFrames) _currentFrame = 0;
            }
        }

        public void SetTexture(int numOfFrames, int frameHeight = -1, Texture2D texture = null)
        {
            if (texture != null)
            {
                _texture = texture;
            }
            _numOfFrames = numOfFrames;
            _frameWidth = (_texture.Width / numOfFrames);
            if (frameHeight < 0) _frameHeight = _texture.Height;
            else
            {
                _frameHeight = frameHeight;
            }
        }
        public Rectangle Rectangle => new Rectangle((int)Position.X, (int)Position.Y, _frameWidth, _frameHeight);

        public void Draw(SpriteBatch spriteBatch, Vector2 cameraPosition)
        {
            spriteBatch.Draw(_texture, Position - cameraPosition, new Rectangle(_frameWidth * _currentFrame, Row * _frameHeight, _frameWidth, _frameHeight), Color.White, 0, new Vector2(0, 0), 1, Orientation, Layer);
        }
    }
}