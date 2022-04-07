using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Backgrounds_Player
{
    public class ObstacleHandler
    {
        public List<Obstacles> obstacles = new List<Obstacles>();
        public ObstacleHandler(int theme, int positionx, bool toggle)
        {
            //obstacles.Clear();
            if(toggle == true)
            {
                ObstacleAssigner(theme, positionx);

            }
        }
        internal void ObstacleAssigner(int theme, int positionx)
        {
            var texture = TextureHandler.Instance.GetTexture(TextureType.Obstacle);
            var numOfFrames = TextureHandler.Instance.GetTextureAnimationFrames(TextureType.Obstacle);
            switch (theme)
            {
                case 1:
                    //City
                    var newspaper = new Obstacles(texture, numOfFrames, positionx, true);
                    obstacles.Add(newspaper);
                    break;
                case 2:
                    //ice
                    var snowball = new Obstacles(texture, numOfFrames, positionx, true, false);
                    obstacles.Add(snowball);
                    break;
                //case 3:
                //    // Savannah
                //    break;
                case 4:
                    //djungle
                    var arrow = new Obstacles(texture, numOfFrames, positionx, true, false);
                    obstacles.Add(arrow);
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

            obstacles.RemoveAll(o=>o.Position.X < cameraPosition.X - 200);
        }
        internal void Draw(SpriteBatch spriteBatch, Vector2 cameraPosition)
        {
            foreach (var obstacle in obstacles) obstacle.Draw(spriteBatch, cameraPosition);   
        }


    }
}