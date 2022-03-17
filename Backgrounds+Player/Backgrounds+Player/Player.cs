using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Backgrounds_Player
{
    public class PlayerTexture
    {
        public Texture2D Texture { get; set; }
        public int NumOfFrames { get; set; }
        public PlayerState State { get; set; }
    }

    public enum PlayerState { Idle, Running, Jumping, Dying }
    public class Player : PlayerAnimation
    {
        public Vector2 Velocity;
        private PlayerState state = PlayerState.Idle;

        public List<PlayerTexture> Textures { get; set; } = new List<PlayerTexture>();

        public Player(Texture2D texture, int numOfFrames)
            : base(texture)
        {
            SetTexture(numOfFrames);
        }
        public void ChangeState(PlayerState newState)
        {
            var playerTexture = Textures.FirstOrDefault(x => x.State == newState);

            if (playerTexture != null)
            {
                SetTexture(playerTexture.NumOfFrames, -1, playerTexture.Texture);
            }
            state = newState;
        }
        public new void Update()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Right) && Velocity.X == 0)
            {
                ChangeState(PlayerState.Running);
                Velocity.X = 5f; //orig 3f
            }
            else            // bara att ta bort else om man inte ska kunna stå stilla!
                //Velocity.X = 0f;

            if (Keyboard.GetState().IsKeyDown(Keys.Space) && state != PlayerState.Jumping || Keyboard.GetState().IsKeyDown(Keys.Up) && state != PlayerState.Jumping)
            {
                ChangeState(PlayerState.Jumping);
                Position.Y -= 10f;
                Velocity.Y = -5f;
                state = PlayerState.Jumping;
            }

            if (Position.Y >= 670 - Rectangle.Height && state == PlayerState.Jumping) // 720 tot / 50 från marken / >670-heigth
            {
                ChangeState(PlayerState.Running);
                state = PlayerState.Running;
            }

            if (state == PlayerState.Jumping) 
                Velocity.Y += 0.08f;
            else 
                Velocity.Y = 0f;

            Position += Velocity;

            if (state == PlayerState.Dying && Position.Y <= 670 - Rectangle.Height)
            {
                Position.Y += 10f;
                Velocity.Y = -5f;
            }

            if (state == PlayerState.Dying) Repeatable = false;
            else Repeatable = true;

            base.Update();
        }
    }
}