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
        public int timer { get; set; } = 420; // ta bort get set efter felsökning
        int step = 1;
        public bool key { get; set; } = false;
        public bool jumpKey = false;
        public bool killSwitch { get; set; } = false;

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
        public void MenuAnimation()
        {
            if(key == false && killSwitch == false)
            {
                if (step == 1)
                {
                    if(timer == 180)
                    {
                        ChangeState(PlayerState.Running);
                        Velocity.X = 2f;
                    }
                    if (timer == 0)
                    {
                        timer = 400;
                        if (GetRandom(0,2) == 1)
                        {
                            jumpKey = true;
                        }
                        step = 2;
                    }

                }
                else if (step == 2)
                {
                    if(Velocity.X < 5f)
                    {
                        Velocity.X += 0.01f;
                    }
                    if (Velocity.X >= 5f && timer == 0)
                    {
                        step = 3;
                        timer = 210;
                        Velocity.X = 5f;
                        if (GetRandom(0,2) == 0)
                        {
                            jumpKey = true;
                        }
                    }
                   
                }
                else if (step == 3)
                {
                    Velocity.X -= 0.01f;

                    

                    if (Velocity.X <= 0)
                    {
                        ChangeState(PlayerState.Idle);
                        timer = 320;
                        step = 1;
                    }
                    
                }
                if (jumpKey == true)
                {
                    Jump();
                    jumpKey = false;
                }

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
            }
            
            

            Position += Velocity;
            timer--;
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


                if (_ticks-- < 0 && State != PlayerState.Dying)
                {
                    Velocity.X += 0.001f;
                }
            }
            else
            {
                MenuAnimation();
            }

            if (State == PlayerState.Dying || State == PlayerState.Jumping) Repeatable = false;
            else Repeatable = true;
            
            base.Update();

        }
        private static Random random = new Random();

        private static int GetRandom(int min, int max)
        {
            return random.Next(min, max);
        }

        public void Jump()
        {
            if (State != PlayerState.Jumping)
            {
                ChangeState(PlayerState.Jumping);
                Position.Y -= 10f;
                Velocity.Y = -JumpSpeed;
            }
        }
    }
}