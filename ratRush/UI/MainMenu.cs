using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rbWhitaker.UI
{
    class MainMenu
    {
        private Screen screen;
        public Button playButton;
        private SpriteFont font;

        public MainMenu(ContentManager content, SpriteBatch spriteBatch, SpriteFont font)
        {
            Texture2D texture = new Texture2D(spriteBatch.GraphicsDevice, 1,1);
            texture.SetData(new Color[] { Color.LightGoldenrodYellow });
            screen = new Screen(texture);
            this.font = font;

            screen.AddImageLabel(new ImageLabel(content.Load<Texture2D>("Cheese"), new Vector2(380, 200)));

            playButton = new Button("PLAY", font, 325, 400, 150, 50);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            screen.Draw(spriteBatch);
            playButton.Draw(spriteBatch);
            spriteBatch.DrawString(font, "CHEESE RUSH", new Vector2(285, 100), Color.Black);
        }

        public void Update()
        {
            playButton.Update(Mouse.GetState());
        }

    }
}
