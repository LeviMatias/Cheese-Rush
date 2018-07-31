using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using rbWhitaker.World.Items;

namespace rbWhitaker.World
{
     public class ItemFactory
    {
        private Texture2D cheeseTexture;
        private static ItemFactory instance;
        static readonly object padlock = new object();

        public static ItemFactory Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new ItemFactory();
                    }
                    return instance;
                }
            }
        }

        public  GameItem NewCheese(float x, float y)
        {
            return new Cheese(cheeseTexture, (int)x, (int)y);
        }

        public void LoadItems(ContentManager content)
        {
            cheeseTexture = content.Load<Texture2D>("Cheese"); 
        }
    }

}
