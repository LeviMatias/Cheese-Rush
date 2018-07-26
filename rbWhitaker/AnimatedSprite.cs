using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace rbWhitaker
{
   public class AnimatedSprite
    {
        public Texture2D Texture { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        public int Height;
        public int Width;


        private int currentFrame;
        private int totalFrames;

        private int buffer = 0;
        private int maxBuffer = 8;

        public AnimatedSprite(Texture2D texture, int rows, int columns)
        {
            Texture = texture;
            Rows = rows;
            Columns = columns;
            currentFrame = 0;
            totalFrames = rows * columns;
            Width = Texture.Width / Columns;
            Height = Texture.Height / Rows;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {

            int row = (int)((float)currentFrame / (float)Columns);
            int column = currentFrame % Columns;

            Rectangle sourceRectangle = new Rectangle(Width * column, Height * row, Width, Height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, Width, Height);

            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
        }

        public void Update(bool isMoving)
        {
            if (!isMoving)
            {
                buffer = 0;
                currentFrame = 0;
                return;
            }

            buffer++;
            if (buffer == maxBuffer)
            {
                buffer = 0;
                currentFrame++;
                if (currentFrame == totalFrames)
                {
                    currentFrame = 0;
                }
            }
        }

    }
}
