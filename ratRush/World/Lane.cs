using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using rbWhitaker.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rbWhitaker.World
{
    public class Lane
    {
        private readonly List<ImageLabelWithItem> path = new List<ImageLabelWithItem>();

        public Lane(ContentManager content, int y)
        {
            Texture2D texture = content.Load <Texture2D>("Brick");
            int max = (int)Math.Ceiling((800d / texture.Width));
            for (int i = 0; i < max + 1; i++)
            {
                path.Add(new ImageLabelWithItem(texture,new Vector2(texture.Width*(i-1), y)));
            }
        }

        public void Update(int speed)
        {
            foreach (ImageLabelWithItem img in path)
            {
                if (img.Position.X == 800)
                {
                    img.ChangePosition(new Vector2(0 - img.Texture.Width, img.Position.Y));
                }
                else
                {
                    img.ChangePosition(new Vector2(img.Position.X + speed, img.Position.Y));
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (ImageLabelWithItem img in path)
            {
                img.Draw(spriteBatch);
            }
        }
    }
}
