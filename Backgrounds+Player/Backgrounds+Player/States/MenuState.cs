using Backgrounds_Player.Controls;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace Backgrounds_Player.States
{
    public class MenuState : State
    {
        private List<Components> _components;
        private Button startGameButton;
        private Button levelSelectButton;
        private Button quitGameButton;
        private Button DowntownButton;
        private Button SavannahButton;
        private Button ArcticButton;
        private Button JungleButton;
        private Title title;

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

            title = new Title(titleTexture) 
            { 
                Position = new Vector2(420, 20) 
            };


            startGameButton = new Button(StartTexture)
            {
                Position = new Vector2(400, 200),
            };
            startGameButton.Click += StartGameButton_Click;

            levelSelectButton = new Button(LevelSelectTexture)
            {
                Position = new Vector2(400, 350),
            };
            levelSelectButton.Click += LevelSelectButton_Click;

            quitGameButton = new Button(QuitGameTexture)
            {
                Position = new Vector2(400, 490),
            };
            quitGameButton.Click += QuitGameButton_Click;


            DowntownButton = new Button(DowntownTexture)
            {
                Position = new Vector2(400, 0),
            };

            DowntownButton.Click += DowntownButton_Click;


            SavannahButton = new Button(SavannahTexture)
            {
                Position = new Vector2(350, 230),
            };

            SavannahButton.Click += SavannahButton_Click;


            ArcticButton = new Button(ArcticTexture)
            {
                Position = new Vector2(400, 380),
            };

            ArcticButton.Click += ArcticButton_Click;


            JungleButton = new Button(JungleTexture)
            {
                Position = new Vector2(400, 530),
            };

            JungleButton.Click += JungleButton_Click;

            MainMenu();

        }

        
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            foreach (var component in _components)
                component.Draw(gameTime, spriteBatch);

            spriteBatch.End();
        }

        public  void MainMenu()
        {
            _components.AddRange(new Components[]
            {
                    title,
                    startGameButton,
                    levelSelectButton,
                    quitGameButton,
            });
        }

        private void LevelSelectButton_Click(object sender, EventArgs e)
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

        private void StartGameButton_Click(object sender, EventArgs e)
        {
            _game.StartGame();
            _components.Clear();
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
                // ska förbli tom
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
