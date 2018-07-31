using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using rbWhitaker.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rbWhitaker.World
{
    internal class ImageLabelWithItem : ImageLabel
    {
        public GameItem Item;

        public ImageLabelWithItem(Texture2D tex, Vector2 pos) : base(tex, pos)
        {

        }

        public void AddItem(GameItem item)
        {
            Item = item;
        }
    }
}
