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
            if (placeBottom)
                Position = new Vector2(positionx, Game1.ScreenHeight - texture.Height - 50);
            else
                //Position = new Vector2(positionx, 500); //720
                //Position = new Vector2(positionx, rnd.Next(400, 700));
                pos = rnd.Next(4, 7);
                Position = new Vector2(positionx, pos*100); // 4 5 6

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