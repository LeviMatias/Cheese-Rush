using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rbWhitaker.World
{
    class LaneManager
    {
        private static LaneManager instance;
        private readonly List<Lane> lanes = new List<Lane>();
        private static readonly object padlock = new object();

        public const int NUMBER_OF_LANES = 3;

        public static LaneManager Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new LaneManager();
                    }
                    return instance;
                }
            }
        }

        public void LoadContent(ContentManager content)
        {
            for(int i = 0; i< NUMBER_OF_LANES; i++)
            {
                lanes.Add(new Lane(content,220*i + 15));
            }
        }

        public void Update()
        {
            foreach(Lane lane in lanes)
            {
                lane.Update(4);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Lane lane in lanes)
            {
                lane.Draw(spriteBatch);
            }
        }
    }
}
