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
                    //City
                    var foreground = new ScrollingBackgroundLayer(TextureHandler.Instance.Foreground, 61f, 0.99f);
                    backgrounds.Add(foreground);

                    var houses = new ScrollingBackgroundLayer(TextureHandler.Instance.Houses, 60f, 0.9f);
                    backgrounds.Add(houses);

                    var backhouses1 = new ScrollingBackgroundLayer(TextureHandler.Instance.Backhouses1, 40f, .8f);
                    backgrounds.Add(backhouses1);

                    var clouds2 = new ScrollingBackgroundLayer(TextureHandler.Instance.Clouds2, 30f, .79f, true);
                    backgrounds.Add(clouds2);

                    var backhouses2 = new ScrollingBackgroundLayer(TextureHandler.Instance.Backhouses2, 25f, .78f);
                    backgrounds.Add(backhouses2);

                    var clouds1 = new ScrollingBackgroundLayer(TextureHandler.Instance.Clouds1, 10f, .7f, true, false);
                    backgrounds.Add(clouds1);

                    var skybox = new ScrollingBackgroundLayer(TextureHandler.Instance.Skybox, 0f, .1f);
                    backgrounds.Add(skybox);
                    break;
                case 2:
                    //Ice
                    var background = new ScrollingBackgroundLayer(TextureHandler.Instance.Background, 0f, .1f);
                    backgrounds.Add(background);

                    var sun = new ScrollingBackgroundLayer(TextureHandler.Instance.Sun, 0f, .4f);
                    backgrounds.Add(sun);

                    var back = new ScrollingBackgroundLayer(TextureHandler.Instance.Back, 25f, .5f);
                    backgrounds.Add(back);

                    var clouds = new ScrollingBackgroundLayer(TextureHandler.Instance.Clouds, 30f, .6f, true);
                    backgrounds.Add(clouds);

                    var middle = new ScrollingBackgroundLayer(TextureHandler.Instance.Middle, 50f, .8f);
                    backgrounds.Add(middle);

                    var front = new ScrollingBackgroundLayer(TextureHandler.Instance.Front, 60f, .9f);
                    backgrounds.Add(front);

                    var path = new ScrollingBackgroundLayer(TextureHandler.Instance.Path, 61f, .99f);
                    backgrounds.Add(path);
                    break;
                case 3:
                    // Savannah
                    var sky = new ScrollingBackgroundLayer(TextureHandler.Instance.Sky, 0f, .1f);
                    backgrounds.Add(sky);

                    var sun1 = new ScrollingBackgroundLayer(TextureHandler.Instance.Sun1, 0f, .2f);
                    backgrounds.Add(sun1);

                    var ground = new ScrollingBackgroundLayer(TextureHandler.Instance.Ground, 61f, 0.3f);
                    backgrounds.Add(ground);

                    var treesBack = new ScrollingBackgroundLayer(TextureHandler.Instance.TreesBack, 40f, .4f);
                    backgrounds.Add(treesBack);

                    var grassBack = new ScrollingBackgroundLayer(TextureHandler.Instance.GrassBack, 61f, .5f);
                    backgrounds.Add(grassBack);

                    var treeFront = new ScrollingBackgroundLayer(TextureHandler.Instance.TreeFront, 61f, .6f);
                    backgrounds.Add(treeFront);

                    var grassFront = new ScrollingBackgroundLayer(TextureHandler.Instance.GrassFront, 61f, .7f);
                    backgrounds.Add(grassFront);

                    var walkingPath = new ScrollingBackgroundLayer(TextureHandler.Instance.WalkingPath, 61f, .8f);
                    backgrounds.Add(walkingPath);
                    break;
                case 4:
                    var backGround = new ScrollingBackgroundLayer(TextureHandler.Instance.BackGround, 0f, .1f);
                    backgrounds.Add(backGround);

                    var back3 = new ScrollingBackgroundLayer(TextureHandler.Instance.Back3, 25f, .2f);
                    backgrounds.Add(back3);

                    var back2 = new ScrollingBackgroundLayer(TextureHandler.Instance.Back2, 30f, .3f);
                    backgrounds.Add(back2);

                    var back1 = new ScrollingBackgroundLayer(TextureHandler.Instance.Back1, 50f, .4f);
                    backgrounds.Add(back1);

                    var foreGround = new ScrollingBackgroundLayer(TextureHandler.Instance.ForeGround, 61f, .5f);
                    backgrounds.Add(foreGround);
                    break;
                default:
                    break;
            }
        }
        internal void Update(GameTime gameTime, float playerVelocityX)
        {
            //foreach (var backgroundLayer in backgrounds) backgroundLayer.Update(gameTime, playerVelocityX);
        }
        internal void Draw(SpriteBatch spriteBatch, Vector2 cameraPosition)
        {
            foreach (var backgroundLayer in backgrounds.OrderBy(x => x.Layer)) backgroundLayer.Draw(spriteBatch, cameraPosition);
        }
    }
}
