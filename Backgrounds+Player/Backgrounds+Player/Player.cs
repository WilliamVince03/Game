using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;

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
        public PlayerState State = PlayerState.Idle; // helst som private men...
        public float JumpSpeed { get; set; } = 8f;
        private int _ticks = 1000;
        public bool key { get; set; } = false;

        public List<PlayerTexture> Textures { get; set; } = new List<PlayerTexture>();

        public Player(Texture2D texture, int numOfFrames)
            : base(texture)
        {
            SetTexture(numOfFrames);
        }
        public void ChangeState(PlayerState newState)
        {
            var playerTextures = Textures.Where(x => x.State == newState).ToArray();
            if (playerTextures.Any())
            {
                var rnd = new Random();
                var playerTexture = playerTextures[rnd.Next(0, playerTextures.Length)];
                SetTexture(playerTexture.NumOfFrames, -1, playerTexture.Texture);
            }
            State = newState;
        }
        public new void Update()
        {
            if (key == true)
            {
                                 //flyttat till Game1.StartGame()
                //if (Keyboard.GetState().IsKeyDown(Keys.Right) && Velocity.X == 0)
                //{
                //    ChangeState(PlayerState.Running);
                //    Velocity.X = 10f; //orig 3f
                //}

                if (Position.Y >= 670 - Rectangle.Height)
                {
                    if (State == PlayerState.Jumping)
                    {
                        ChangeState(PlayerState.Running);
                    }
                    Velocity.Y = 0f;
                }
                else
                    Velocity.Y += 0.25f;

                Position += Velocity;

                if (State == PlayerState.Dying || State == PlayerState.Jumping) Repeatable = false;
                else Repeatable = true;

                if (_ticks-- < 0)
                {
                    Velocity.X += 0.001f;
                }
            }
            base.Update();
        }
    }
}