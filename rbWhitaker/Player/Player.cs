using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rbWhitaker
{
    public class Player
    {
        private AnimatedSprite sprite;
        private PlayerMovementManager movement;

        public Vector2 MovementDir;
        public Vector2 Position;
        public bool Moving;
        public Rectangle Hitbox;

        public Player(AnimatedSprite sprite, Vector2 location)
        {
            movement = new PlayerMovementManager();
            this.sprite = sprite;
            Position = location;

            Hitbox = new Rectangle((int)location.X, (int)location.Y, (int)(sprite.Width*.8f), (int)(sprite.Height * .8f));
        }

        public void Update(KeyboardState state)
        {
            MovementDir = movement.ProcessMovement(state);
            Position = Position + MovementDir;
            Moving = movement.IsMoving;
            Hitbox.X = (int)Position.X;
            Hitbox.Y = (int)Position.Y;

            sprite.Update(Moving);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
               sprite.Draw(spriteBatch, Position);
        }


    }
}
