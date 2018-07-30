using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rbWhitaker.UI
{

    class Screen
    {
        //private List<Button> buttons;
        private List<ImageLabel> imageLabels;
        private Texture2D background;
        private Rectangle bounds;

        public Screen(Texture2D background)
        {
            //buttons = new List<Button>();
            imageLabels = new List<ImageLabel>();
            this.background = background;
            bounds = new Rectangle(0, 0, 800, 600);
        }

        private void AddButton(Button button)
        {
            //buttons.Add(button);
        }

        public void AddImageLabel(ImageLabel imgLabel)
        {
            imageLabels.Add(imgLabel);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(background, bounds, Color.White);

           /*/ foreach(Button button in buttons)
            {
                button.Draw(spriteBatch);
            }
            /*/

            foreach (ImageLabel imgLabel in imageLabels)
            {
                imgLabel.Draw(spriteBatch);
            }
        }
    }
}
