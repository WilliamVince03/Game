using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace Backgrounds_Player
{
    public class ObstacleHandler
    {
        private Random rnd = new Random();
        public List<Obstacles> obstacles = new List<Obstacles>();
        public ObstacleHandler(int theme, int positionx, bool toggle)
        {
            if(toggle == true)
            {
                ObstacleAssigner(theme, positionx);
                obstacles.Clear();

            }
        }
        internal void ObstacleAssigner(int theme, int positionx)
        {
            var texture = TextureHandler.Instance.GetTexture(TextureType.Obstacle);
            var texture2 = TextureHandler.Instance.GetTexture(TextureType.Obstacle, 1);
            var texture3 = TextureHandler.Instance.GetTexture(TextureType.Obstacle, 2);
            var texture4 = TextureHandler.Instance.GetTexture(TextureType.Obstacle, 3);
            var numOfFrames = TextureHandler.Instance.GetTextureAnimationFrames(TextureType.Obstacle);
            var numOfFrames2 = TextureHandler.Instance.GetTextureAnimationFrames(TextureType.Obstacle, 1);
            var numOfFrames3 = TextureHandler.Instance.GetTextureAnimationFrames(TextureType.Obstacle, 2);
            var numOfFrames4 = TextureHandler.Instance.GetTextureAnimationFrames(TextureType.Obstacle, 3);
            switch (theme)
            {
                case 1:
                    //Idle
                    var r = rnd.NextDouble();
                    if (r < .5)
                    {
                        var newspaper = new Obstacles(texture, numOfFrames, positionx, true, false);
                        obstacles.Add(newspaper);
                    }
                    else if (r < .85)
                    {
                        var firepost = new Obstacles(texture2, numOfFrames2, positionx);
                        obstacles.Add(firepost);
                    }
                    else
                    {
                        var taxi = new Obstacles(texture3, numOfFrames3, positionx, true);
                        taxi.Layer = 0.1f; 
                        obstacles.Add(taxi);
                    }
                    break;
                case 2:
                    //ice
                    var snowball = new Obstacles(texture, numOfFrames, positionx, true, false);
                    obstacles.Add(snowball);
                    break;
                case 3:
                    //savannah
                    var v = rnd.NextDouble();
                    if (v < .25)
                    {
                        var burnBarrel = new Obstacles(texture2, numOfFrames2, positionx);
                        obstacles.Add(burnBarrel);
                    }
                    else if (v < .5)
                    {
                        var deadBush = new Obstacles(texture3, numOfFrames3, positionx);
                        obstacles.Add(deadBush);
                    }
                    else if (v < .75)
                    {
                        var tumbleweed = new Obstacles(texture, numOfFrames, positionx, true);
                        obstacles.Add(tumbleweed);
                    }
                    else
                    {
                        var bird = new Obstacles(texture4, numOfFrames4, positionx, true, false);
                        obstacles.Add(bird);
                    }
                    break;
                case 4:
                    //djungle
                    if (rnd.NextDouble() < .5)
                    {
                        var stone = new Obstacles(texture2, numOfFrames2, positionx);
                        obstacles.Add(stone);
                    }
                    else
                    {
                        var arrow = new Obstacles(texture, numOfFrames, positionx, true, false);
                        obstacles.Add(arrow);
                    }
                    break;
                default:
                    var obstacle = new Obstacles(texture, numOfFrames, positionx);
                    obstacles.Add(obstacle);

                    break;
            }
        }
        internal void Update(GameTime gameTime, float playerVelocityX, Vector2 cameraPosition)
        {

            foreach (var obstacle in obstacles) obstacle.Update(gameTime, playerVelocityX);

            obstacles.RemoveAll(o => o.Position.X < cameraPosition.X - 200);
        }
        internal void Draw(SpriteBatch spriteBatch, Vector2 cameraPosition)
        {
            foreach (var obstacle in obstacles) obstacle.Draw(spriteBatch, cameraPosition);
        }


    }
}