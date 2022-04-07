using System.Collections.Generic;
using System;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;

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
        public Texture2D Newspaper { get; set; }
        public Texture2D Taxi { get; set; }
        // player
        public Texture2D WalkingPoodle { get; set; }
        public Texture2D DeadPoodle { get; set; }
        public Texture2D FlyingPoodle { get; set; }

        // ice
        public Texture2D ArcticSky { get; set; }
        public Texture2D ArcticSun { get; set; }
        public Texture2D ArcticCloud { get; set; }
        public Texture2D ArcticBack { get; set; }
        public Texture2D ArcticMiddle { get; set; }
        public Texture2D ArcticClose { get; set; }
        public Texture2D ArcticForeground { get; set; }
        //player
        public Texture2D WalkingPenguin { get; set; }
        public Texture2D WalkingPenguin2 { get; set; }
        public Texture2D WalkingPenguin3 { get; set; }
        public Texture2D DeadPenguin { get; set; }
        public Texture2D IdlePenguin { get; set; }
        public Texture2D JumpingPenguin { get; set; }
        public Texture2D Snowball { get; set; }

        // Savannah
        public Texture2D SavannahSky { get; set; }
        public Texture2D SavannahSun { get; set; }
        public Texture2D SavannahGrass { get; set; }
        public Texture2D DistantTrees { get; set; }
        public Texture2D DistantGrass { get; set; }
        public Texture2D CloseTree { get; set; }
        public Texture2D CoveringGrass { get; set; }
        public Texture2D SavannahForegrund { get; set; }
        //player 
        public Texture2D KangarooDeath { get; set; }
        public Texture2D KangarooRun { get; set; }
        public Texture2D KangarooIdle { get; set; }
        public Texture2D KangarooJump { get; set; }
        // obstacle
        public Texture2D Tumbleweed { get; set; }
        public Texture2D BurnBarrel { get; set; }
        public Texture2D DeadBush { get; set; }
        public Texture2D Bird { get; set; }

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
        public Texture2D Arrow { get; set; }
        public Texture2D DangerPlant { get; set; }


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
            CityForeground = content.Load<Texture2D>("City/Background/CityForeground");
            Houses = content.Load<Texture2D>("City/Background/Houses");
            BackgroundHousesColored = content.Load<Texture2D>("City/Background/BackgroundHousesColored");
            BackgroundHousesGreys = content.Load<Texture2D>("City/Background/BackgroundHousesGreys");
            CityCloudsHigh = content.Load<Texture2D>("City/Background/CityCloudsHigh");
            CityCloudsLow = content.Load<Texture2D>("City/Background/CityCloudsLow");
            CitySky = content.Load<Texture2D>("City/Background/CitySky");
            //obstacles
            Firepost = content.Load<Texture2D>("City/Obstacles/Firepost");
            Newspaper = content.Load<Texture2D>("City/Obstacles/Newspaper");
            //Taxi = content.Load<Texture2D>("Idle/Obstacles/taxi");
            //player
            WalkingPoodle = content.Load<Texture2D>("City/Player/WalkingPoodle");
            DeadPoodle = content.Load<Texture2D>("City/Player/DeadPoodle");
            FlyingPoodle = content.Load<Texture2D>("City/Player/poodleflyfast");


            //arctic
            ArcticSky = content.Load<Texture2D>("Arctic/Background/ArcticSky");
            ArcticSun = content.Load<Texture2D>("Arctic/Background/ArcticSun"); 
            ArcticCloud = content.Load<Texture2D>("Arctic/Background/ArcticCloud");
            ArcticBack = content.Load<Texture2D>("Arctic/Background/ArcticBack");
            ArcticMiddle = content.Load<Texture2D>("Arctic/Background/ArcticMiddle");
            ArcticClose = content.Load<Texture2D>("Arctic/Background/ArcticClose");
            ArcticForeground = content.Load<Texture2D>("Arctic/Background/ArcticForeground");
            //player
            WalkingPenguin = content.Load<Texture2D>("Arctic/Player/WalkingPenguin");
            WalkingPenguin2 = content.Load<Texture2D>("Arctic/Player/PenguinWalking2");//pingvin 2
            WalkingPenguin3 = content.Load<Texture2D>("Arctic/Player/PenguinWalkingAlternate");//pingvin 3
            DeadPenguin = content.Load<Texture2D>("Arctic/Player/DeadPenguin");
            IdlePenguin = content.Load<Texture2D>("Arctic/Player/IdlePenguin");
            JumpingPenguin = content.Load<Texture2D>("Arctic/Player/PenguinBackflip");
            //obstacles
            Snowball = content.Load<Texture2D>("Arctic/Obstacles/Snowball"); // för stor och bakofram

            // Savannah
            SavannahSky = content.Load<Texture2D>("Savannah/Background/SavannahSky");
            SavannahSun = content.Load<Texture2D>("Savannah/Background/SavannahSun");
            SavannahGrass = content.Load<Texture2D>("Savannah/Background/SavannahGrass");
            DistantTrees = content.Load<Texture2D>("Savannah/Background/DistantTrees");
            DistantGrass = content.Load<Texture2D>("Savannah/Background/DistantGrass");
            CloseTree = content.Load<Texture2D>("Savannah/Background/CloseTree");
            CoveringGrass = content.Load<Texture2D>("Savannah/Background/CoveringGrass");
            SavannahForegrund = content.Load<Texture2D>("Savannah/Background/SavannahForegrund");
            //player
            KangarooRun = content.Load<Texture2D>("Savannah/Player/KangarooRun");
            KangarooDeath = content.Load<Texture2D>("Savannah/Player/KangarooDeath");
            KangarooIdle = content.Load<Texture2D>("Savannah/Player/KangarooIdle");
            KangarooJump = content.Load<Texture2D>("Savannah/Player/kangaroojump");
            //obstacles
            Tumbleweed = content.Load<Texture2D>("Savannah/Obstacles/Tumbleweed");
            BurnBarrel = content.Load<Texture2D>("Savannah/Obstacles/burnbarrel");
            DeadBush = content.Load<Texture2D>("Savannah/Obstacles/DeadBush");
            Bird = content.Load<Texture2D>("Savannah/Obstacles/spookybird");


            // Jungle
            BackgroundFog = content.Load<Texture2D>("Jungle/Background/BackgroundFog");
            BackgroundDistant = content.Load<Texture2D>("Jungle/Background/BackgroundDistant");
            BackgroundMiddle = content.Load<Texture2D>("Jungle/Background/BackgroundMiddle");
            BackgroundClose = content.Load<Texture2D>("Jungle/Background/BackgroundClose");
            JungleForeground = content.Load<Texture2D>("Jungle/Background/JungleForeground");
            //player
            MonkeyDeath = content.Load<Texture2D>("Jungle/Player/monke death (3)");
            MonkeyRun = content.Load<Texture2D>("Jungle/Player/MonkeyRun");
            MonkeyIdle = content.Load<Texture2D>("Jungle/Player/MonkeyIdle");
            //obstacles
            Arrow = content.Load<Texture2D>("Jungle/Obstacles/Arrow");
            DangerPlant = content.Load<Texture2D>("Jungle/Obstacles/dangerplant");
        }

        public Texture2D GetTexture(TextureType type, int v = 0) ///
        {
            switch (type)
            {
                case TextureType.Player:
                    return GetPlayerTexture(v);
                case TextureType.Obstacle:
                    return GetObsticleTexture(v);
                case TextureType.PlayerDeath:
                    return GetPlayerDeathTexture();
                case TextureType.PlayerResting:
                    return GetPlayerRestingTexture();
                case TextureType.PlayerJumping:
                    return GetPlayerJumpingTexture();
            }
            return GetPlayerTexture();
        }

        public int GetTextureAnimationFrames(TextureType type, int v = 0) /////
        {
            switch (type)
            {
                case TextureType.Player:
                    return GetPlayerTextureAnimationFrames(v);
                case TextureType.PlayerDeath:
                    return GetPlayerDeathTextureAnimationFrames();
                case TextureType.PlayerResting:
                    return GetPlayerRestingTextureAnimationFrames();
                case TextureType.PlayerJumping:
                    return GetPlayerJumpingTextureAnimationFrames();
                case TextureType.Obstacle:
                    return GetObstacleTextureAnimationFrames(v);
            }
            return GetPlayerTextureAnimationFrames();
        }

        public Texture2D GetPlayerTexture(int v = 0)
        {
            switch (Theme)
            {
                case 1:
                    return WalkingPoodle;
                case 2:
                    if (v == 1) return WalkingPenguin2;
                    if (v == 2) return WalkingPenguin3;
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
                    return FlyingPoodle;
                case 2:
                    return JumpingPenguin; 
                case 3:
                    return KangarooJump;
                case 4:
                    return MonkeyRun;
                default:
                    return MonkeyRun;
            }
        }
        public int GetPlayerTextureAnimationFrames(int v = 0)
        {
            switch (Theme)
            {
                case 1:
                    return 6;
                case 2:
                    if (v == 2) return 4;
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
                    return 11;
                case 2:
                    return 13;
                case 3:
                    return 5;
                case 4:
                    return 4;
                default:
                    return 4;
            }
        }
        public Texture2D GetObsticleTexture(int v = 0) ////////////////
        {
            switch (Theme)
            {
                case 1:
                    if (v == 1) return Firepost;
                    //if (v == 2) return Taxi;
                    return Newspaper;
                case 2:
                    return Snowball;
                case 3:
                    if (v == 1) return BurnBarrel;
                    if (v == 2) return DeadBush;
                    if (v == 3) return Bird;
                    return Tumbleweed;
                case 4:
                    if (v == 1) return DangerPlant;
                    return Arrow;
                default:
                    return Tumbleweed;
            }
        }
        public int GetObstacleTextureAnimationFrames(int v = 0) ///////////
        {
            switch (Theme)
            {
                case 1:
                    if (v == 1) return 1;
                    //if (v == 2) return 1;
                    return 17;
                case 2:
                    return 12;
                case 3:
                    if (v == 1) return 6;
                    if (v == 2) return 1;
                    if (v == 3) return 2;
                    return 8;
                case 4:
                    if (v == 1) return 4;
                    return 5;
                default:
                    return 1;
            }
        }

        public int GetPlayerAnimationSpeed()
        {
            switch (Theme)
            {
                case 1: return 5;
                case 2: return 5;
                default: return 10;
            }
        }

            public float GetPlayerJumpSpeed()
        {
            switch (Theme)
            {
                case 1:
                    return 8f; // krävs 9 för att hoppa över firepost // 6 för tidning
                case 2:
                    return 8f;
                case 3:
                    return 12f;
                case 4:
                    return 10f;
                default:
                    return 8f;
            }
        }

    }
}