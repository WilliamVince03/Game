using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backgrounds_Player
{
    public class PlayerAnimation 
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

        public PlayerAnimation(Texture2D texture)
        {
            _texture = texture;
        }

        //private Texture2D _texture;
        private int _ticks = 0;
        private int _frameWidth = 0;
        private int _frameHeight = 0;
        private int _numOfFrames = 0;
        //public Vector2 Position = new Vector2(0, Game1.ScreenHeight - _texture.Height);
        public Vector2 Position = new Vector2(0, 500);

        public SpriteEffects Orientation = SpriteEffects.None;
        public int Row { get; set; } = 0;
        public int _currentFrame { get; set; } = 0;
        public int AnimationSpeed { get; set; } = 10;
        public bool Repeatable { get; set; } = true;


        public void Update() //bool repeatable = true
        {
            if (_ticks-- < 0)
            {
                _ticks = AnimationSpeed;
                _currentFrame++;
                if (Repeatable)
                { if (_currentFrame >= _numOfFrames) _currentFrame = 0; }
                else
                    if (_currentFrame >= _numOfFrames) _currentFrame = _numOfFrames-1;
            }
        }

        public void SetTexture( int numOfFrames, int frameHeight = -1, Texture2D texture = null)
        {
            if(texture != null)
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
        public Rectangle Rectangle => new Rectangle((int)Position.X+50, (int)Position.Y, _frameWidth, _frameHeight);

        public void Draw(SpriteBatch spriteBatch, Vector2 cameraPosition)
        {
            //spriteBatch.Draw(_texture, Position, new Rectangle(_frameWidth * _currentFrame, Row * _frameHeight, _frameWidth, _frameHeight), Color.White, 0, new Vector2(_frameWidth / 2, _frameHeight / 2), 1, Orientation, Layer);
            spriteBatch.Draw(_texture, Position - cameraPosition + new Vector2(50, 0), new Rectangle(_frameWidth * _currentFrame, Row * _frameHeight, _frameWidth, _frameHeight), Color.White, 0, new Vector2(0, 0), 1, Orientation, Layer);
        }
    }
}