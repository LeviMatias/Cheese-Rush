using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rbWhitaker.UI
{
    public class Button
    {
        public Rectangle Hitbox;
        private Texture2D _texture;
        private SpriteFont _font;
        private MouseState oldState;


        public string Text;

        public Button(string text, SpriteFont font, int x, int y, int width, int height)
        {
            Text = text;
            Hitbox = new Rectangle(x, y, width, height);
            _font = font;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (_texture == null)
            {
                _texture = new Texture2D(spriteBatch.GraphicsDevice, 1, 1);
                _texture.SetData(new Color[] { Color.DarkSlateGray });
            }
            spriteBatch.Draw(_texture,Hitbox,Color.White);
            spriteBatch.DrawString(_font, $"{Text}", 
                new Vector2( Hitbox.Location.X + Hitbox.Size.X/4 , Hitbox.Location.Y + Hitbox.Size.Y / 4),
                Color.White);
        }

        public void Update(MouseState mouseState)//Mouse.GetState()
        {
            if (Hitbox.Contains(mouseState.Position))
            {
                if (mouseState.LeftButton == ButtonState.Pressed && oldState.LeftButton == ButtonState.Released)
                {
                    OnMouseClick(EventArgs.Empty);
                }
            }

            oldState = mouseState;
        }

        protected virtual void OnMouseClick(EventArgs e)
        {
            MouseClick?.Invoke(this, e);
        }

        public event EventHandler MouseClick;
    }
}
