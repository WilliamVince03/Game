using System.Collections.Generic;
using System;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Backgrounds_Player
{
    public enum TextureType { Player, Background, Obstacle, PlayerDeath, PlayerResting, PlayerJumping }
    public class TextureHandler
    {
        private static TextureHandler _instance = null;
        public int Theme { get; set; } = 1;

        // ta bort sen
        public Texture2D BoyTexture { get; set; }
        public Texture2D BoyTexture1 { get; set; }
        public Texture2D BoyTexture2 { get; set; }
        public Texture2D PoodelTexture { get; set; }
        public Texture2D PoodelDeath { get; set; }


        // city
        public Texture2D Houses { get; set; }
        public Texture2D Backhouses1 { get; set; }
        public Texture2D Backhouses2 { get; set; }
        public Texture2D Foreground { get; set; }
        public Texture2D Clouds1 { get; set; }
        public Texture2D Clouds2 { get; set; }
        public Texture2D Skybox { get; set; }
            //obstacles
            public Texture2D Firepost { get; set; }
            public Texture2D Newspaper { get; set; }

        // ice
        public Texture2D Background { get; set; }
        public Texture2D Sun { get; set; }
        public Texture2D Clouds { get; set; }
        public Texture2D Back { get; set; }
        public Texture2D Middle { get; set; }
        public Texture2D Front { get; set; }
        public Texture2D Path { get; set; }
            //player
            public Texture2D Penguin { get; set; }
            public Texture2D PenguinDeath { get; set; }
            public Texture2D PenguinResting { get; set; }
        public Texture2D SnowBall { get; set; }

        // Savannah
        public Texture2D Sky { get; set; }
        public Texture2D Sun1 { get; set; }
        public Texture2D Ground { get; set; }
        public Texture2D TreesBack { get; set; }
        public Texture2D GrassBack { get; set; }
        public Texture2D TreeFront { get; set; }
        public Texture2D GrassFront { get; set; }
        public Texture2D WalkingPath { get; set; }
            public Texture2D KangarooDeath { get; set; }
        public Texture2D Kangaroo { get; set; }
        public Texture2D KangarooIdle { get; set; }

        // Jungle
        public Texture2D BackGround { get; set; }
        public Texture2D Back3 { get; set; }
        public Texture2D Back2 { get; set; }
        public Texture2D Back1 { get; set; }
        public Texture2D ForeGround { get; set; }
            //player
            public Texture2D MonkeyDeath { get; set; }
            public Texture2D Monkey { get; set; }
            public Texture2D MonkeyResting { get; set; }
            //Obstacles
            public Texture2D Log { get; set; }
            public Texture2D Arrow { get; set; }



    public static TextureHandler Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new TextureHandler();
                }
                return _instance;
            }
        }

        private TextureHandler(){ }

        public void LoadTextures(ContentManager content) {

            // ta bort
            BoyTexture1 = content.Load<Texture2D>("boy");
            BoyTexture2 = content.Load<Texture2D>("boy");
            BoyTexture = content.Load<Texture2D>("boy");


            //city
            Foreground = content.Load<Texture2D>("foreground");
            Houses = content.Load<Texture2D>("houses");
            Backhouses1 = content.Load<Texture2D>("_backhouses1");
            Backhouses2 = content.Load<Texture2D>("backhouses2");
            Clouds1 = content.Load<Texture2D>("clouds1 (3)");
            Clouds2 = content.Load<Texture2D>("clouds2 (3)");
            Skybox = content.Load<Texture2D>("skybox");
                //obstacles
            Firepost = content.Load<Texture2D>("firepost");
            Newspaper = content.Load<Texture2D>("newspaper_blowing_in_the_wind_GIF");
            //player
            PoodelTexture = content.Load<Texture2D>("poodel_walking");
            PoodelDeath = content.Load<Texture2D>("poodel_death");


            //ice
            Background = content.Load<Texture2D>("Lager 0");
            Sun = content.Load<Texture2D>("Sol");
            Clouds = content.Load<Texture2D>("Måln");
            Back = content.Load<Texture2D>("Längst bak");
            Middle = content.Load<Texture2D>("Fram");
            Front = content.Load<Texture2D>("Allra längst fram");
            Path = content.Load<Texture2D>("Springbana");
                //player
                Penguin = content.Load<Texture2D>("penguin_walking_sprites (2)");
                PenguinDeath = content.Load<Texture2D>("Död pingvin");
            PenguinResting = content.Load<Texture2D>("penguin_idle (2)");
            SnowBall = content.Load<Texture2D>("Snowball");

            // Savannah
            Sky = content.Load<Texture2D>("Himmel");
            Sun1 = content.Load<Texture2D>("Sol");
            Ground = content.Load<Texture2D>("Mark");
            TreesBack = content.Load<Texture2D>("Träd längst bak2");
            GrassBack = content.Load<Texture2D>("Extra gräs bak");
            TreeFront= content.Load<Texture2D>("Träd2");
            GrassFront = content.Load<Texture2D>("gräs främre träd");
            WalkingPath = content.Load<Texture2D>("Springbana2");
            Kangaroo = content.Load<Texture2D>("kangarooo (1)");
            KangarooDeath = content.Load<Texture2D>("kangarooodeath (1)");
            KangarooIdle = content.Load<Texture2D>("kangaroooidle (2)");

            // Jungle
            BackGround = content.Load<Texture2D>("background");
            Back3 = content.Load<Texture2D>("back3");
            Back2 = content.Load<Texture2D>("back2");
            Back1 = content.Load<Texture2D>("back1");
            ForeGround = content.Load<Texture2D>("front");
            MonkeyDeath = content.Load<Texture2D>("monke death (1)");// lite off
            Monkey = content.Load<Texture2D>("Apa springer");
            MonkeyResting = content.Load<Texture2D>("Apa vila");
            //obstacles
            Arrow = content.Load<Texture2D>("arrow (5)");
                //Log = content.Load<Texture2D>("stock");
        }

        public Texture2D GetTexture(TextureType type)
        {
            switch (type)
            {
                case TextureType.Player:
                    return GetPlayerTexture();
                case TextureType.Obstacle:
                    return GetObsticleTexture();
                case TextureType.PlayerDeath:
                    return GetPlayerDeathTexture();
                case TextureType.PlayerResting:
                    return GetPlayerRestingTexture();
                case TextureType.PlayerJumping:
                    return GetPlayerJumpingTexture();
            }
            return GetPlayerTexture();
        }
        public int GetTextureAnimationFrames(TextureType type)
        {
            switch (type)
            {
                case TextureType.Player:
                    return GetPlayerTextureAnimationFrames();
                case TextureType.PlayerDeath:
                    return GetPlayerDeathTextureAnimationFrames();
                case TextureType.PlayerResting:
                    return GetPlayerRestingTextureAnimationFrames();
                case TextureType.PlayerJumping:
                    return GetPlayerJumpingTextureAnimationFrames();
                case TextureType.Obstacle:
                    return GetObstacleTextureAnimationFrames();
            }
            return GetPlayerTextureAnimationFrames();
        }

        public Texture2D GetPlayerTexture() 
        {
            switch (Theme)
            {
                case 1:
                    return PoodelTexture;
                case 2:
                    return Penguin;
                case 3:
                    return Kangaroo;
                case 4:
                    return Monkey;
                default:
                    return Monkey;
            }
        }
        public Texture2D GetPlayerDeathTexture()
        {
            switch (Theme)
            {
                case 1:
                    return PoodelDeath;
                case 2:
                    return PenguinDeath;
                case 3:
                    return KangarooDeath;
                case 4:
                    return MonkeyDeath;
                default:
                    return Monkey;
            }
        }
        public Texture2D GetPlayerRestingTexture()
        {
            switch (Theme)
            {
                case 1:
                    return PoodelTexture;
                case 2:
                    return PenguinResting;
                case 3:
                    return KangarooIdle;
                case 4:
                    return MonkeyResting;
                default:
                    return MonkeyResting;
            }
        }
        public Texture2D GetPlayerJumpingTexture()
        {
            switch (Theme)
            {
                case 1:
                    return PoodelTexture;
                case 2:
                    return Penguin;
                case 3:
                    return Kangaroo;
                case 4:
                    return Monkey;
                default:
                    return Monkey;
            }
        }
            public int GetPlayerTextureAnimationFrames()
        {
            switch (Theme)
            {
                case 1:
                    return 6;
                case 2:
                    return 6;
                case 3:
                    return 4;
                case 4:
                    return 4;
                default:
                    return 4;
            }
        }
        public int GetPlayerDeathTextureAnimationFrames()
        {
            switch (Theme)
            {
                case 1:
                    return 7;
                case 2:
                    return 4;
                case 3:
                    return 7;
                case 4:
                    return 3;
                default:
                    return 4;
            }
        }
        public int GetPlayerRestingTextureAnimationFrames()
        {
            switch (Theme)
            {
                case 1:
                    return 6;
                case 2:
                    return 12;
                case 3:
                    return 9;
                case 4:
                    return 8;
                default:
                    return 4;
            }
        }
        public int GetPlayerJumpingTextureAnimationFrames()
        {
            switch (Theme)
            {
                case 1:
                    return 6;
                case 2:
                    return 6;
                case 3:
                    return 4;
                case 4:
                    return 4;
                default:
                    return 4;
            }
        }
        public Texture2D GetObsticleTexture()
        {
            switch (Theme)
            {
                case 1:
                    return Newspaper;//Firepost;
                case 2:
                    //return Firepost;
                    return SnowBall;
                case 4:
                    return Arrow;
                default:
                    return BoyTexture;
            }
        }
        public int GetObstacleTextureAnimationFrames()
        {
            switch (Theme)
            {
                case 1:
                    return 17;
                case 2:
                    return 12;
                case 3:
                    return 1;
                case 4:
                    return 5;
                default:
                    return 1;
            }
        }

    }
}
