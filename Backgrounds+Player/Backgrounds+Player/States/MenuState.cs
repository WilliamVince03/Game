using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using Backgrounds_Player.Controls;
using BackgroundsPlayer.States;

namespace Backgrounds_Player.States
{
    public class MenuState: State
    {
        private List<Components> _components;
        private Button[] _buttons = new Button[5];
        private bool levelSelect = false;


        public MenuState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content) : base(game, graphicsDevice, content)
        {
            var StartTexture = _content.Load<Texture2D>("Menu/StartGame");
            var LevelSelectTexture = _content.Load<Texture2D>("Menu/LevelSelect");
            var QuitGameTexture = _content.Load<Texture2D>("Menu/QuitGame");
            var ArcticTexture = _content.Load<Texture2D>("Menu/Arctic");
            var DowntownTexture = _content.Load<Texture2D>("Menu/Downtown");
            var JungleTexture = _content.Load<Texture2D>("Menu/Jungle");
            var SavannahTexture = _content.Load<Texture2D>("Menu/Savannah");
            var titleTexture = _content.Load<Texture2D>("Menu/Logo");
            _components = new List<Components>();

            var title = new Title(titleTexture) 
            { 
                Position = new Vector2(420, 20) 
            };


            var newGameButton = new Button(StartTexture)
            {
                Position = new Vector2(400, 200),
            };

            newGameButton.Click += NewGameButton_Click;

            var levelSelectButton = new Button(LevelSelectTexture)
            {
                Position = new Vector2(400, 350),
            };

            levelSelectButton.Click += levelSelectButton_Click;

            var quitGameButton = new Button(QuitGameTexture)
            {
                Position = new Vector2(400, 490),
            };

            quitGameButton.Click += QuitGameButton_Click;


            var DowntownButton = new Button(DowntownTexture)
            {
                Position = new Vector2(400, 0),
            };
            _buttons[0] = DowntownButton;

            DowntownButton.Click += DowntownButton_Click;


            var SavannahButton = new Button(SavannahTexture)
            {
                Position = new Vector2(350, 230),
            };
            _buttons[1] = SavannahButton;

            SavannahButton.Click += SavannahButton_Click;


            var ArcticButton = new Button(ArcticTexture)
            {
                Position = new Vector2(400, 380),
            };
            _buttons[2] = ArcticButton;

            ArcticButton.Click += ArcticButton_Click;


            var JungleButton = new Button(JungleTexture)
            {
                Position = new Vector2(400, 530),
            };
            _buttons[3] = JungleButton;

            JungleButton.Click += JungleButton_Click;


            if (levelSelect == false)
            {
                if(_components.Count > 0) {
                    _components.Clear();
                }

                _components.AddRange(new Components[]
                {
                    title,
                    newGameButton,
                    levelSelectButton,
                    quitGameButton,
                });  
            }
            else
            {
                _components.Clear();
                _components.AddRange(new Components[]
                {
                    DowntownButton,
                    SavannahButton,
                    ArcticButton,
                    JungleButton,
                });

            }

        }

        
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            foreach (var component in _components)
                component.Draw(gameTime, spriteBatch);

            spriteBatch.End();
        }

        private void levelSelectButton_Click(object sender, EventArgs e)
        {
            levelSelect = true;
            _components.Clear();
            _components.AddRange(new Components[]
            {
                    _buttons[0],
                    _buttons[1],
                    _buttons[2],
                    _buttons[3],
            });
        }

        private void NewGameButton_Click(object sender, EventArgs e)
        {
            _game.ChangeState(new GameState(_game, _graphicsDevice, _content));
        }

        public override void PostUpdate(GameTime gameTime)
        {
            // Remove sprites if they're not needed
        }

        public override void Update(GameTime gameTime)
        {
            try
            {
                foreach (var component in _components)
                component.Update(gameTime);
            }
            catch
            {

            }
        }

        private void QuitGameButton_Click(object sender, EventArgs e)
        {
            _game.Exit();
        }

        private void DowntownButton_Click(object sender, EventArgs e)
        {
            _game.ThemeChanger(1);
            _components.Clear();
        }

        private void SavannahButton_Click(object sender, EventArgs e)
        {
            _game.ThemeChanger(3);
            _components.Clear();
        }

        private void ArcticButton_Click(object sender, EventArgs e)
        {
            _game.ThemeChanger(2);
            _components.Clear();
        }

        private void JungleButton_Click(object sender, EventArgs e)
        {
            _game.ThemeChanger(4);
            _components.Clear();
        }
    }
}
