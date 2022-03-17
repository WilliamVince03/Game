using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Backgrounds_Player
{
    public class ScrollingBackgroundLayer
    {

        private bool _constantSpeed;
        private float _scrollingSpeed;

        private Texture2D _texture;
        private Vector2 _position;

        public float Layer { get; set; }

        public ScrollingBackgroundLayer(Texture2D texture, float scrollingSpeed, float layer, bool constantSpeed = false, bool placeBottom = true)
        {
            Layer = layer;
            _texture = texture;
            _scrollingSpeed = scrollingSpeed;
            _constantSpeed = constantSpeed;
            if (placeBottom)
                _position = new Vector2(0, Game1.ScreenHeight - texture.Height);
            else
                _position = new Vector2(0, 0);
        }

        public void Update(GameTime gameTime, float playerSpeedX) //
        {
            var speed = (float)(_scrollingSpeed * gameTime.ElapsedGameTime.TotalSeconds);

            if (!_constantSpeed || playerSpeedX != 0)
                speed *= playerSpeedX;

            _position.X -= speed;
            _position.X %= _texture.Width;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 cameraPosition)
        {
            var position = _position - _scrollingSpeed * cameraPosition / 61;
            position.X = _position.X - (_scrollingSpeed * cameraPosition.X / 61) % _texture.Width;
            spriteBatch.Draw(_texture, position, null, Color.White, 0, new Vector2(0, 0), 1f, SpriteEffects.None, Layer);
            spriteBatch.Draw(_texture, position + new Vector2(_texture.Width, 0), null, Color.White, 0, new Vector2(0, 0), 1f, SpriteEffects.None, Layer);
            spriteBatch.Draw(_texture, position + new Vector2(_texture.Width*2, 0), null, Color.White, 0, new Vector2(0, 0), 1f, SpriteEffects.None, Layer);
        }
    }
}