using Backgrounds_Player.States;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Backgrounds_Player
{

    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        public static int ScreenWidth = 1280;
        public static int ScreenHeight = 720;
        private Random rnd = new Random();
        private int _theme;
        private int _highscore = 0;
        private BackgroundHandler backgroundHandler;
        private Player _player;
        private ObstacleHandler obstacleHandler;
        private Vector2 _camera = Vector2.Zero;
        private bool toggle = false;
        private MenuState _currentState;
        private MenuState _nextState;
        private bool key = true;

        //private State _currentState;
        //private State _nextState;

        private Song _lobbyMusic;
        private Song _cityBackgroundMusic;
        private Song _arcticBackgroundMusic;
        private Song _savannahBackgroundMusic;
        private Song _jungleBackgroundMusic;
        private List<SoundEffects> _soundEffects { get; set; } = new List<SoundEffects>();

        private float _currentTime = 0f; ///////
        private float countDuration = 1f; //////   antal sekunder mellan varje poäng 

        //public void ChangeState(State State)
        //{
        //    _nextState = State;
        //}


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

            _theme = rnd.Next(1, 5);
            //_theme = 3;

            PlayerSetup();
            ThemeCycler();
        }
        void PlayerSetup()
        {
            TextureHandler.Instance.Theme = _theme;
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
                NumOfFrames = TextureHandler.Instance.GetTextureAnimationFrames(TextureType.Player),
                State = PlayerState.Running
            });
            _player.Textures.Add(new PlayerTexture
            {
                Texture = TextureHandler.Instance.GetTexture(TextureType.Player, 1),
                NumOfFrames = TextureHandler.Instance.GetTextureAnimationFrames(TextureType.Player, 1),
                State = PlayerState.Running
            });
            _player.Textures.Add(new PlayerTexture
            {
                Texture = TextureHandler.Instance.GetTexture(TextureType.Player, 2),
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

        public class SoundEffects
        {
            public SoundEffect SoundEffect { get; set; }
            public SoundState State { get; set; }
            public SoundTheme Theme { get; set; }

        }
        private SoundTheme getTheme()
        {
            switch (_theme)
            {
                case 1: return SoundTheme.City;
                case 2: return SoundTheme.Arctic;
                case 3: return SoundTheme.Savannah;
                case 4: return SoundTheme.Jungle;
                default: return SoundTheme.City; // måste ha default
            }
        }
        public enum SoundState { Idle, Running, Jumping, Dying }
        public enum SoundTheme { City, Arctic, Savannah, Jungle }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            TextureHandler.Instance.LoadTextures(this.Content);

            _currentState = new MenuState(this, _graphics.GraphicsDevice, Content);

            _lobbyMusic = Content.Load<Song>("Music/Astro2");
            _cityBackgroundMusic = Content.Load<Song>("Music/CityBackgroundMusic");
            _arcticBackgroundMusic = Content.Load<Song>("Music/ArcticBackgroundMusic");
            _savannahBackgroundMusic = Content.Load<Song>("Music/SavannahBackgroundMusic");
            _jungleBackgroundMusic = Content.Load<Song>("Music/JungleBackgroundMusic");

            _soundEffects.Add(new SoundEffects
            {
                SoundEffect = Content.Load<SoundEffect>("SoundEffects/Jungle/MonkeyJumpingSound"),
                State = SoundState.Jumping,
                Theme = SoundTheme.Jungle
            }); _soundEffects.Add(new SoundEffects
            {
                SoundEffect = Content.Load<SoundEffect>("SoundEffects/Jungle/MonkeyJumpingSound2"),
                State = SoundState.Jumping,
                Theme = SoundTheme.Jungle
            }); _soundEffects.Add(new SoundEffects
            {
                SoundEffect = Content.Load<SoundEffect>("SoundEffects/Jungle/MonkeyJumpingSound3"),
                State = SoundState.Jumping,
                Theme = SoundTheme.Jungle
            }); _soundEffects.Add(new SoundEffects
            {
                SoundEffect = Content.Load<SoundEffect>("SoundEffects/Jungle/MonkeyJumpingSound4"),
                State = SoundState.Jumping,
                Theme = SoundTheme.Jungle
            }); _soundEffects.Add(new SoundEffects
            {
                SoundEffect = Content.Load<SoundEffect>("SoundEffects/Jungle/MonkeyDeathSound"),
                State = SoundState.Dying,
                Theme = SoundTheme.Jungle
            }); _soundEffects.Add(new SoundEffects
            {
                SoundEffect = Content.Load<SoundEffect>("SoundEffects/Arctic/PenguinJumpingSound"),
                State = SoundState.Jumping,
                Theme = SoundTheme.Arctic
            }); _soundEffects.Add(new SoundEffects
            {
                SoundEffect = Content.Load<SoundEffect>("SoundEffects/Arctic/PenguinJumpingSound2"),
                State = SoundState.Jumping,
                Theme = SoundTheme.Arctic
            }); _soundEffects.Add(new SoundEffects
            {
                SoundEffect = Content.Load<SoundEffect>("SoundEffects/Arctic/PenguinJumpingSound3"),
                State = SoundState.Jumping,
                Theme = SoundTheme.Arctic
            }); _soundEffects.Add(new SoundEffects
            {
                SoundEffect = Content.Load<SoundEffect>("SoundEffects/Arctic/PenguinJumpingSound4"),
                State = SoundState.Jumping,
                Theme = SoundTheme.Arctic
            }); _soundEffects.Add(new SoundEffects
            {
                SoundEffect = Content.Load<SoundEffect>("SoundEffects/Arctic/PenguinJumpingSound5"),
                State = SoundState.Jumping,
                Theme = SoundTheme.Arctic
            }); _soundEffects.Add(new SoundEffects
            {
                SoundEffect = Content.Load<SoundEffect>("SoundEffects/Arctic/PenguinDyingSound"),
                State = SoundState.Dying,
                Theme = SoundTheme.Arctic
            }); _soundEffects.Add(new SoundEffects
            {
                SoundEffect = Content.Load<SoundEffect>("SoundEffects/City/PoodleJumpingSound"),
                State = SoundState.Jumping,
                Theme = SoundTheme.City
            }); _soundEffects.Add(new SoundEffects
            {
                SoundEffect = Content.Load<SoundEffect>("SoundEffects/City/PoodleDyingSound"),
                State = SoundState.Dying,
                Theme = SoundTheme.City
            }); _soundEffects.Add(new SoundEffects
            {
                SoundEffect = Content.Load<SoundEffect>("SoundEffects/Savannah/KangarooDyingSound1"),
                State = SoundState.Dying,
                Theme = SoundTheme.Savannah
            }); _soundEffects.Add(new SoundEffects
            {
                SoundEffect = Content.Load<SoundEffect>("SoundEffects/Savannah/KangarooDyingSound2"),
                State = SoundState.Dying,
                Theme = SoundTheme.Savannah
            }); _soundEffects.Add(new SoundEffects
            {
                SoundEffect = Content.Load<SoundEffect>("SoundEffects/Savannah/KangarooDyingSound3"),
                State = SoundState.Dying,
                Theme = SoundTheme.Savannah
            }); _soundEffects.Add(new SoundEffects
            {
                SoundEffect = Content.Load<SoundEffect>("SoundEffects/Savannah/KangarooJumpingSound1"),
                State = SoundState.Jumping,
                Theme = SoundTheme.Savannah
            }); _soundEffects.Add(new SoundEffects
            {
                SoundEffect = Content.Load<SoundEffect>("SoundEffects/Savannah/KangarooJumpingSound2"),
                State = SoundState.Jumping,
                Theme = SoundTheme.Savannah
            }); _soundEffects.Add(new SoundEffects
            {
                SoundEffect = Content.Load<SoundEffect>("SoundEffects/Savannah/KangarooJumpingSound3"),
                State = SoundState.Jumping,
                Theme = SoundTheme.Savannah
            }); _soundEffects.Add(new SoundEffects
            {
                SoundEffect = Content.Load<SoundEffect>("SoundEffects/Savannah/KangarooJumpingSound4"),
                State = SoundState.Jumping,
                Theme = SoundTheme.Savannah
            });

            //music
            MediaPlayer.Play(_lobbyMusic);
            MediaPlayer.IsRepeating = true;
            //MediaPlayer.MediaStateChanged += MediaPlayer_MediaStateChanged;
            // MediaStateChanged event handler  will be called when the song completes,
            // --> decreasing the volume and playing the song again.
        }
        void MediaPlayer_MediaStateChanged(object sender, System.EventArgs e)
        {
            // 0.0f is silent, 1.0f is full volume
            MediaPlayer.Volume -= 0.1f;
            MediaPlayer.Play(_lobbyMusic);
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
            if (toggle == true)
            {
                if (!obstacleHandler.obstacles.Any(o => o.Position.X > _camera.X + 500)) // kolla om avstånden är bra
                {
                    obstacleHandler.ObstacleAssigner(_theme, (int)_camera.X + rnd.Next(2000, 3000));
                }
            }

            foreach (Obstacles obstacle in obstacleHandler.obstacles)
            {
                if (_player.Rectangle.Intersects(obstacle.Rectangle) && _player.State != PlayerState.Dying)
                {
                    if(key == true)
                    {
                        var sounds = _soundEffects.Where(x => (x.State == SoundState.Dying) && (x.Theme == getTheme())).ToArray();
                        if (sounds.Any())
                        {
                            var rnd = new Random();
                            sounds[rnd.Next(0, sounds.Length)].SoundEffect.Play();
                        }
                        _player.ChangeState(PlayerState.Dying);
                        _player.Velocity.X = 0;
                        StopGame();
                        key = false;
                    }
                    
                }
            }

            if ((Keyboard.GetState().IsKeyDown(Keys.Space) || Keyboard.GetState().IsKeyDown(Keys.Up)) && _player.State != PlayerState.Jumping && _player.State != PlayerState.Dying) //behövs dying?
            {
                var sounds = _soundEffects.Where(x => (x.State == SoundState.Jumping) && (x.Theme == getTheme())).ToArray();
                if (sounds.Any())
                {
                    var rnd = new Random();
                    sounds[rnd.Next(0, sounds.Length)].SoundEffect.Play();
                }
                _player.ChangeState(PlayerState.Jumping);
                _player.Position.Y -= 10f;
                _player.Velocity.Y = -_player.JumpSpeed;
            }

            if (_nextState != null)
            {
                _currentState = _nextState;

                _nextState = null;
            }


            _currentState.Update(gameTime);

            _currentState.PostUpdate(gameTime);



            ////////////////
            _currentTime += (float)gameTime.ElapsedGameTime.TotalSeconds; //Time passed since last Update() 

            
            
                
                //if (_currentTime >= countDuration)
                if (_currentTime >= countDuration && _player.State != PlayerState.Dying && _player.key == true)
                {
                    _highscore++;
                    _currentTime -= countDuration;

                }
                // lös en text i övre hörnet med high score
                // nollställ när man börjar om
            

            Window.Title = _player.Velocity.X.ToString() + "        " + _highscore.ToString() + _player.timer;


            base.Update(gameTime);
        }

        public void StartGame()
        {
            MediaPlayer.Stop();
            switch (_theme)
            {
                case 1:
                    MediaPlayer.Play(_cityBackgroundMusic);
                    break;
                case 2:
                    MediaPlayer.Play(_arcticBackgroundMusic);
                    break;
                case 3:
                    MediaPlayer.Play(_savannahBackgroundMusic);
                    break;
                case 4:
                    MediaPlayer.Play(_jungleBackgroundMusic);
                    break;
            }
            _player.key = true;
            toggle = true;
            _player.ChangeState(PlayerState.Running);
            _player.Velocity.X = 10f;
        }

        public void StopGame()
        {
            _player.key = false;
            toggle = false;
            ThemeCycler();
            _currentState.MainMenu();
        }
        public void ThemeCycler()
        {
            backgroundHandler = new BackgroundHandler(_theme);
            obstacleHandler = new ObstacleHandler(_theme, 2000, toggle);
        }

        public void ThemeChanger(int select)
        {
            _theme = select;
            ThemeCycler();
            PlayerSetup();
            StartGame();
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
