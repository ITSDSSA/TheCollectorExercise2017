using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Collectables;

namespace Sprites
{
    public class Player
    {
        public Texture2D Image;
        public Vector2 Position;
        public Rectangle BoundingRect;
        public int Score;
        public List<Collectable> collected;

        // Constructor expects to see a loaded Texture
        // and a start position
        public Player( Texture2D spriteImage,
                            Vector2 startPosition)
        {
            //
            // Take a copy of the texture passed down
            Image = spriteImage;
            // Take a copy of the start position
            Position = startPosition;
            // Calculate the bounding rectangle
            BoundingRect = new Rectangle((int)startPosition.X, (int)startPosition.Y, Image.Width, Image.Height);
            collected = new List<Collectable>();
        }

        public void draw(SpriteFont font, SpriteBatch sp)
        {
            if (Image != null)
            {
                int halfx = (int)Position.X + Image.Width / 2;
                int y = (int)Position.Y - 20;
                sp.DrawString(font, Score.ToString(), new Vector2(halfx, y), Color.White);
                sp.Draw(Image, Position, Color.White);
            }
        }

        public void Update()
        {
            BoundingRect = new Rectangle(Position.ToPoint(), Image.Bounds.Size);
        }

        public void Move(Vector2 delta)
        {
            Position += delta;
            BoundingRect = new Rectangle((int)Position.X, (int)Position.Y, Image.Width, Image.Height);
            BoundingRect.X = (int)Position.X;
            BoundingRect.Y = (int)Position.Y;
        }

    }
}
