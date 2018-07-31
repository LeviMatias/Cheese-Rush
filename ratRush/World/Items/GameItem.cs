using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rbWhitaker.World
{
    public abstract class GameItem
    {
        protected Texture2D texture;
        public Rectangle Hitbox;

        public abstract void Draw(SpriteBatch spriteBatch);


    }
}
