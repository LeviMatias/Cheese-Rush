using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using rbWhitaker.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using rbWhitaker.World.Items;

namespace rbWhitaker.World
{
    public class ImageLabelWithItem : ImageLabel
    {
        public GameItem Item;

        public ImageLabelWithItem(Texture2D tex, Vector2 pos) : base(tex, pos)
        {

        }

        public void AddItem(GameItem item)
        {
            Item = item;
        }

        public new void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            if (Item != null)
            {
                Item.Draw(spriteBatch);
            }
        }

        public new void ChangePosition(Vector2 pos)
        {
            if(Item != null)
            {
                Item.Hitbox.X = (int)pos.X;
            }
            base.ChangePosition(pos); 
        }
    }
}
