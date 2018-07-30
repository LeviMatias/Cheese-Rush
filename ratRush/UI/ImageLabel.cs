using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rbWhitaker.UI
{
    public class ImageLabel
    {
        public Vector2 Position;
        public Texture2D Texture;


        public ImageLabel(Texture2D tex, Vector2 pos)
        {
            Position = pos;
            Texture = tex;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, Color.White);
        }

    }
}
