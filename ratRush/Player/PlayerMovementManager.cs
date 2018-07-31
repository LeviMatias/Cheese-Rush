using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rbWhitaker
{
    class PlayerMovementManager
    {
        private const int walkSpeed = 5;

        enum YMovementKeys {W = -walkSpeed, S = walkSpeed }
        enum XMovementKeys {A = -walkSpeed, D = walkSpeed }

        public bool IsMoving = false;

        public Vector2 ProcessMovement(KeyboardState state)
        {

            float X = 0;
            float Y = 0;
            IsMoving = false;

            foreach (int i in Enum.GetValues(typeof(YMovementKeys)))
            {
                string name = Enum.GetName(typeof(YMovementKeys), i);
                if (state.IsKeyDown((Keys)Convert.ToChar(name))){
                    Y = Y + i;
                    IsMoving = true;
                }
            }

            foreach (int i in Enum.GetValues(typeof(XMovementKeys)))
            {
                string name = Enum.GetName(typeof(XMovementKeys), i);
                if (state.IsKeyDown((Keys)Convert.ToChar(name)))
                {
                    X = X + i;
                    IsMoving = true;
                }
            }

            float sum = Math.Abs(X) + Math.Abs(Y);
            if (sum == 2 * walkSpeed) {
                X = X / 1.5f;
                Y = Y / 1.5f;
            }

            return new Vector2(X, Y);

        }

    }
}
