using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Backgrounds_Player.States;

namespace Backgrounds_Player
{

    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        public static int ScreenWidth = 1280;
        public static int ScreenHeight = 720;
        private Random rnd = new Random();
        private int theme;
        private BackgroundHandler backgroundHandler;
        private Player _player;
        private ObstacleHandler obstacleHandler;
        private Vector2 _camera = Vector2.Zero;

        private State _currentState;
        private State _nextState;

        public void ChangeState(State state)
        {
            _nextState = state;
        }



        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }
        
        protected override void Initialize()
        {
            _graphics.PreferredBackBufferWidth = ScreenWidth;
            _graphics.PreferredBackBufferHeight = ScreenHeight;
            _graphics.ApplyChanges();

            IsMouseVisible = true;


            base.Initialize();

            theme = rnd.Next(1, 5);
            theme = 2;

            Setup();
            backgroundHandler = new BackgroundHandler(theme);
            obstacleHandler = new ObstacleHandler(theme, 2000); 

        }
        void Setup()
        {
            TextureHandler.Instance.Theme = theme;
            _player = new Player(TextureHandler.Instance.GetTexture(TextureType.PlayerResting), TextureHandler.Instance.GetTextureAnimationFrames(TextureType.PlayerResting))
            {
                Position = new Vector2(50, ScreenHeight - TextureHandler.Instance.GetPlayerTexture().Height - 50),
                Layer = 1f,
            };
            _player.Textures.Add(new PlayerTexture
            {
                Texture = TextureHandler.Instance.GetTexture(TextureType.PlayerResting),
                NumOfFrames = TextureHandler.Instance.GetTextureAnimationFrames(TextureType.PlayerResting),
                State = PlayerState.Idle
            });
            _player.Textures.Add(new PlayerTexture
            {
                Texture = TextureHandler.Instance.GetTexture(TextureType.PlayerJumping),
                NumOfFrames = TextureHandler.Instance.GetTextureAnimationFrames(TextureType.PlayerJumping),
                State = PlayerState.Jumping
            });
            _player.Textures.Add(new PlayerTexture
            {
                Texture = TextureHandler.Instance.GetTexture(TextureType.Player),
                //Texture2 = TextureHandler.Instance.GetTexture(TextureType.Player, 1),
                NumOfFrames = TextureHandler.Instance.GetTextureAnimationFrames(TextureType.Player),
                State = PlayerState.Running
            });
            _player.Textures.Add(new PlayerTexture
            {
                Texture = TextureHandler.Instance.GetTexture(TextureType.Player, 1),
                //Texture2 = TextureHandler.Instance.GetTexture(TextureType.Player, 1),
                NumOfFrames = TextureHandler.Instance.GetTextureAnimationFrames(TextureType.Player, 1),
                State = PlayerState.Running
            });
            _player.Textures.Add(new PlayerTexture
            {
                Texture = TextureHandler.Instance.GetTexture(TextureType.Player, 2),
                //Texture2 = TextureHandler.Instance.GetTexture(TextureType.Player, 1),
                NumOfFrames = TextureHandler.Instance.GetTextureAnimationFrames(TextureType.Player, 2),
                State = PlayerState.Running
            });
            _player.Textures.Add(new PlayerTexture
            {
                Texture = TextureHandler.Instance.GetTexture(TextureType.PlayerDeath),
                NumOfFrames = TextureHandler.Instance.GetTextureAnimationFrames(TextureType.PlayerDeath),
                State = PlayerState.Dying
            });
            _player.JumpSpeed = TextureHandler.Instance.GetPlayerJumpSpeed();
            _player.AnimationSpeed = TextureHandler.Instance.GetPlayerAnimationSpeed();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            TextureHandler.Instance.LoadTextures(this.Content);

            _currentState = new MenuState(this, _graphics.GraphicsDevice, Content);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            _player.Update();
            _camera.X = _player.Position.X;
            //_camera.X = Math.Min(_camera.X, 500);
            backgroundHandler.Update(gameTime, _player.Velocity.X); 
            obstacleHandler.Update(gameTime, _player.Velocity.X, _camera);

            if (!obstacleHandler.obstacles.Any(o => o.Position.X > _camera.X + 500)) // kolla om avstånden är bra
            {
                obstacleHandler.ObstacleAssigner(theme, (int)_camera.X + rnd.Next(1300, 2400));
            }

            foreach (Obstacles obstacle in obstacleHandler.obstacles)
            {
                if(_player.Rectangle.Intersects(obstacle.Rectangle))
                {
                    _player.ChangeState(PlayerState.Dying);
                    _player.Velocity.X = 0;
                }
            }

            if (_nextState != null)
            {
                _currentState = _nextState;

                _nextState = null;
            }

            _currentState.Update(gameTime);

            _currentState.PostUpdate(gameTime);


            Window.Title = _player.Velocity.X.ToString();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();

            backgroundHandler.Draw(_spriteBatch, _camera);
            obstacleHandler.Draw(_spriteBatch, _camera);
            _player.Draw(_spriteBatch, _camera);
            _spriteBatch.End();
            _currentState.Draw(gameTime, _spriteBatch);


            base.Draw(gameTime);
        }
    }
}
