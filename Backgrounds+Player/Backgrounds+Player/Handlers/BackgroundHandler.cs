using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Backgrounds_Player
{
    public class BackgroundHandler
    {
        public List<ScrollingBackgroundLayer> backgrounds = new List<ScrollingBackgroundLayer>();

        public BackgroundHandler(int theme)
        {
            switch (theme)
            {
                case 1:
                    //Idle
                    var foreground = new ScrollingBackgroundLayer(TextureHandler.Instance.CityForeground, 61f, 0.99f);
                    backgrounds.Add(foreground);

                    var houses = new ScrollingBackgroundLayer(TextureHandler.Instance.Houses, 60f, 0.9f);
                    backgrounds.Add(houses);

                    var backhouses1 = new ScrollingBackgroundLayer(TextureHandler.Instance.BackgroundHousesColored, 40f, .8f);
                    backgrounds.Add(backhouses1);

                    var clouds2 = new ScrollingBackgroundLayer(TextureHandler.Instance.CityCloudsLow, 30f, .79f, true);
                    backgrounds.Add(clouds2);

                    var backhouses2 = new ScrollingBackgroundLayer(TextureHandler.Instance.BackgroundHousesGreys, 25f, .78f);
                    backgrounds.Add(backhouses2);

                    var clouds1 = new ScrollingBackgroundLayer(TextureHandler.Instance.CityCloudsHigh, 10f, .7f, true, false);
                    backgrounds.Add(clouds1);

                    var skybox = new ScrollingBackgroundLayer(TextureHandler.Instance.CitySky, 0f, .1f);
                    backgrounds.Add(skybox);
                    break;
                case 2:
                    //Ice
                    var background = new ScrollingBackgroundLayer(TextureHandler.Instance.ArcticSky, 0f, .1f);
                    backgrounds.Add(background);

                    var sun = new ScrollingBackgroundLayer(TextureHandler.Instance.ArcticSun, 0f, .4f);
                    backgrounds.Add(sun);

                    var back = new ScrollingBackgroundLayer(TextureHandler.Instance.ArcticBack, 25f, .5f);
                    backgrounds.Add(back);

                    var clouds = new ScrollingBackgroundLayer(TextureHandler.Instance.ArcticCloud, 30f, .6f, true);
                    backgrounds.Add(clouds);

                    var middle = new ScrollingBackgroundLayer(TextureHandler.Instance.ArcticMiddle, 50f, .8f);
                    backgrounds.Add(middle);

                    var front = new ScrollingBackgroundLayer(TextureHandler.Instance.ArcticClose, 60f, .9f);
                    backgrounds.Add(front);

                    var path = new ScrollingBackgroundLayer(TextureHandler.Instance.ArcticForeground, 61f, .99f);
                    backgrounds.Add(path);
                    break;
                case 3:
                    // Savannah
                    var sky = new ScrollingBackgroundLayer(TextureHandler.Instance.SavannahSky, 0f, .1f);
                    backgrounds.Add(sky);

                    var sun1 = new ScrollingBackgroundLayer(TextureHandler.Instance.SavannahSun, 0f, .2f);
                    backgrounds.Add(sun1);

                    var ground = new ScrollingBackgroundLayer(TextureHandler.Instance.SavannahGrass, 61f, 0.3f);
                    backgrounds.Add(ground);

                    var treesBack = new ScrollingBackgroundLayer(TextureHandler.Instance.DistantTrees, 40f, .4f);
                    backgrounds.Add(treesBack);

                    var grassBack = new ScrollingBackgroundLayer(TextureHandler.Instance.DistantGrass, 61f, .5f);
                    backgrounds.Add(grassBack);

                    var treeFront = new ScrollingBackgroundLayer(TextureHandler.Instance.CloseTree, 61f, .6f);
                    backgrounds.Add(treeFront);

                    var grassFront = new ScrollingBackgroundLayer(TextureHandler.Instance.CoveringGrass, 61f, .7f);
                    backgrounds.Add(grassFront);

                    var walkingPath = new ScrollingBackgroundLayer(TextureHandler.Instance.SavannahForegrund, 61f, .8f);
                    backgrounds.Add(walkingPath);
                    break;
                case 4:
                    //Jungle
                    var backGround = new ScrollingBackgroundLayer(TextureHandler.Instance.BackgroundFog, 0f, .1f);
                    backgrounds.Add(backGround);

                    var back3 = new ScrollingBackgroundLayer(TextureHandler.Instance.BackgroundDistant, 25f, .2f);
                    backgrounds.Add(back3);

                    var back2 = new ScrollingBackgroundLayer(TextureHandler.Instance.BackgroundMiddle, 30f, .3f);
                    backgrounds.Add(back2);

                    var back1 = new ScrollingBackgroundLayer(TextureHandler.Instance.BackgroundClose, 50f, .4f);
                    backgrounds.Add(back1);

                    var foreGround = new ScrollingBackgroundLayer(TextureHandler.Instance.JungleForeground, 61f, .5f);
                    backgrounds.Add(foreGround);
                    break;
                default:
                    break;
            }
        }

        internal void Draw(SpriteBatch spriteBatch, Vector2 cameraPosition)
        {
            foreach (var backgroundLayer in backgrounds.OrderBy(x => x.Layer)) backgroundLayer.Draw(spriteBatch, cameraPosition);
        }
    }
}
