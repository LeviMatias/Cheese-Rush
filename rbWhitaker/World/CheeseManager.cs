using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rbWhitaker
{
    //Singleton design patter
    public  class CheeseManager
    {
        private static CheeseManager instance;
        private List<Cheese> CheeseList  = new List<Cheese>();
        static readonly object padlock = new object();
        private const int MAX_CHEESES = 5;

         CheeseManager()
        {

        }

        public static CheeseManager Instance
        {
            get
            {
                lock (padlock)
                { 
                    if (instance == null)
                    {
                        instance = new CheeseManager();
                    }
                return instance;
                }
            }
        }

        public void CreateNewCheese(ContentManager content ,int maxX, int maxY)
        {
            if (CheeseList.Count() == MAX_CHEESES) return;

            int x = RandomNumberGenerator.NumberBetween(0, maxX);
            int y = RandomNumberGenerator.NumberBetween(0,maxY);
            Texture2D texture = content.Load<Texture2D>("Cheese");
            Cheese cheese = new Cheese(texture, x, y);

            cheese.CheeseExpired += CheeseExpired;
            CheeseList.Add(cheese);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Cheese cheese in CheeseList.ToList())
            {
                cheese.Draw(spriteBatch);
            }
        }

        public void Update()
        {
            foreach (Cheese cheese in CheeseList.ToList())
            {
                cheese.Update();
            }
        }

        public int PlayerTouchesCheese(Player player){

            int cheeseTouched = 0;
            foreach(Cheese cheese in CheeseList.ToList())
            {
                if (cheese.Hitbox.Intersects(player.Hitbox))
                {
                    ExpireCheese(cheese);
                    cheeseTouched++;
                }
            }

            return cheeseTouched;
        }

        private void ExpireCheese(Cheese cheese)
        {
            cheese.CheeseExpired -= CheeseExpired;
            CheeseList.Remove(cheese);

            cheese = null;
        }

        private void CheeseExpired(Object sender, EventArgs e)
        {
            Cheese cheese = (Cheese)sender;
            ExpireCheese(cheese);
        }
    }
}
