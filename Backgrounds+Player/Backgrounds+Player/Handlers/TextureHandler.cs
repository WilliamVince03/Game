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
        public Texture2D WalkingPoodle { get; set; }
        public Texture2D DeadPoodle { get; set; }


        // city
        public Texture2D Houses { get; set; }
        public Texture2D BackgroundHousesColored { get; set; }
        public Texture2D BackgroundHousesGreys { get; set; }
        public Texture2D CityForeground { get; set; }
        public Texture2D CityCloudsHigh { get; set; }
        public Texture2D CityCloudsLow { get; set; }
        public Texture2D CitySky { get; set; }
        //obstacles
        public Texture2D Firepost { get; set; }
        public Texture2D NewspaperInFlight { get; set; }

        // ice
        public Texture2D ArcticSky { get; set; }
        public Texture2D Sun { get; set; }
        public Texture2D ArcticCloud { get; set; }
        public Texture2D ArcticBack { get; set; }
        public Texture2D ArcticMiddle { get; set; }
        public Texture2D ArcticClose { get; set; }
        public Texture2D ArcticForeground { get; set; }
        //player
        public Texture2D WalkingPenguin { get; set; }
        public Texture2D DeadPenguin { get; set; }
        public Texture2D IdlePenguin { get; set; }
        public Texture2D Snowball { get; set; }

        // Savannah
        public Texture2D SavannahSky { get; set; }
        public Texture2D SavannahSun { get; set; }
        public Texture2D SannahGrass { get; set; }
        public Texture2D DistantTrees { get; set; }
        public Texture2D DistantGrass { get; set; }
        public Texture2D CloseTree { get; set; }
        public Texture2D CoveringGrass { get; set; }
        public Texture2D SavannahForegrund { get; set; }
        public Texture2D KangarooDeath { get; set; }
        public Texture2D KangarooRun { get; set; }
        public Texture2D KangarooIdle { get; set; }

        // Jungle
        public Texture2D BackgroundFog { get; set; }
        public Texture2D BackgroundDistant { get; set; }
        public Texture2D BackgroundMiddle { get; set; }
        public Texture2D BackgroundClose { get; set; }
        public Texture2D JungleForeground { get; set; }
        //player
        public Texture2D MonkeyDeath { get; set; }
        public Texture2D MonkeyRun { get; set; }
        public Texture2D MonkeyIdle { get; set; }
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

        private TextureHandler() { }

        public void LoadTextures(ContentManager content)
        {

            // ta bort
            BoyTexture1 = content.Load<Texture2D>("boy");
            BoyTexture2 = content.Load<Texture2D>("boy");
            BoyTexture = content.Load<Texture2D>("boy");


            //city
            CityForeground = content.Load<Texture2D>("CityForeground");
            Houses = content.Load<Texture2D>("Houses");
            BackgroundHousesColored = content.Load<Texture2D>("BackgroundHousesColored");
            BackgroundHousesGreys = content.Load<Texture2D>("BackgroundHousesGreys");
            CityCloudsHigh = content.Load<Texture2D>("CityCloudsHigh");
            CityCloudsLow = content.Load<Texture2D>("CityCloudsLow");
            CitySky = content.Load<Texture2D>("CitySky");
            //obstacles
            Firepost = content.Load<Texture2D>("Firepost");
            NewspaperInFlight = content.Load<Texture2D>("NewspaperInFlight");
            //player
            WalkingPoodle = content.Load<Texture2D>("WalkingPoodle");
            DeadPoodle = content.Load<Texture2D>("DeadPoodle");


            //arctic
            ArcticSky = content.Load<Texture2D>("ArcticSky");
            Sun = content.Load<Texture2D>("Sol"); // Fixa rätt sol
            ArcticCloud = content.Load<Texture2D>("ArcticCloud");
            ArcticBack = content.Load<Texture2D>("ArcticBack");
            ArcticMiddle = content.Load<Texture2D>("ArcticMiddle");
            ArcticClose = content.Load<Texture2D>("ArcticClose");
            ArcticForeground = content.Load<Texture2D>("ArcticForeground");
            //player
            WalkingPenguin = content.Load<Texture2D>("WalkingPenguin");
            DeadPenguin = content.Load<Texture2D>("DeadPenguin");
            IdlePenguin = content.Load<Texture2D>("IdlePenguin");
            //obstacles
            Snowball = content.Load<Texture2D>("Snowball");

            // Savannah
            SavannahSky = content.Load<Texture2D>("SavannahSky");
            SavannahSun = content.Load<Texture2D>("SavannahSun");
            SannahGrass = content.Load<Texture2D>("SannahGrass");
            DistantTrees = content.Load<Texture2D>("DistantTrees");
            DistantGrass = content.Load<Texture2D>("DistantGrass");
            CloseTree = content.Load<Texture2D>("CloseTree");
            CoveringGrass = content.Load<Texture2D>("CoveringGrass");
            SavannahForegrund = content.Load<Texture2D>("SavannahForegrund");
            //player
            KangarooRun = content.Load<Texture2D>("KangarooRun");
            KangarooDeath = content.Load<Texture2D>("KangarooDeath");
            KangarooIdle = content.Load<Texture2D>("KangarooIdle");

            // Jungle
            BackgroundFog = content.Load<Texture2D>("BackgroundFog");
            BackgroundDistant = content.Load<Texture2D>("BackgroundDistant");
            BackgroundMiddle = content.Load<Texture2D>("BackgroundMiddle");
            BackgroundClose = content.Load<Texture2D>("BackgroundClose");
            JungleForeground = content.Load<Texture2D>("JungleForeground");
            //player
            MonkeyDeath = content.Load<Texture2D>("MonkeyDeath");// lite off
            MonkeyRun = content.Load<Texture2D>("MonkeyRun");
            MonkeyIdle = content.Load<Texture2D>("MonkeyIdle");
            //obstacles
            Arrow = content.Load<Texture2D>("Arrow");
            //Log = content.Load<Texture2D>("Log");
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
                    return WalkingPoodle;
                case 2:
                    return WalkingPenguin;
                case 3:
                    return KangarooRun;
                case 4:
                    return MonkeyRun;
                default:
                    return MonkeyRun;
            }
        }
        public Texture2D GetPlayerDeathTexture()
        {
            switch (Theme)
            {
                case 1:
                    return DeadPoodle;
                case 2:
                    return DeadPenguin;
                case 3:
                    return KangarooDeath;
                case 4:
                    return MonkeyDeath;
                default:
                    return MonkeyRun;
            }
        }
        public Texture2D GetPlayerRestingTexture()
        {
            switch (Theme)
            {
                case 1:
                    return WalkingPoodle;
                case 2:
                    return IdlePenguin;
                case 3:
                    return KangarooIdle;
                case 4:
                    return MonkeyIdle;
                default:
                    return MonkeyIdle;
            }
        }
        public Texture2D GetPlayerJumpingTexture()
        {
            switch (Theme)
            {
                case 1:
                    return WalkingPoodle;
                case 2:
                    return WalkingPenguin;
                case 3:
                    return KangarooRun;
                case 4:
                    return MonkeyRun;
                default:
                    return MonkeyRun;
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
                    return NewspaperInFlight;//Firepost;
                case 2:
                    //return Firepost;
                    return Snowball;
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