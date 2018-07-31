using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using rbWhitaker.World;
using rbWhitaker.World.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rbWhitaker
{
    public class Cheese : GameItem
    {
        private int cheeseLife = 0;
        private int MAX_CHEESE_LIFE = 200;


        internal Cheese(Texture2D texture, int x, int y)
        {
            this.texture = texture;
            Hitbox = new Rectangle(x, y, texture.Width, texture.Height);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, Hitbox, Color.White);
        }

        internal void Update()
        {
            cheeseLife++;
            if(cheeseLife == MAX_CHEESE_LIFE)
            {
                OnCheeseExpired(EventArgs.Empty);
            }
        }

        protected virtual void OnCheeseExpired(EventArgs e)
        {
            CheeseExpired?.Invoke(this, e);
        }

        public event EventHandler CheeseExpired;
    }
}
