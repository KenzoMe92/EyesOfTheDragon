using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SharedProject.Controls
{
    public class LinkLabel : Control
    {
        #region Field and Properties

        Color selectedColor = Color.Red;

        public Color SelectedColor
        {
            get { return selectedColor; } 
            set {  selectedColor = value;} 
        }

        #endregion

        #region Constructor Region

        public LinkLabel()
        {
            TabStop = true;
            HasFocus = false;
            Position = Vector2.Zero;
        }

        #endregion

        #region Abstract Methods

        public override void Update(GameTime gameTime)
        {
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (HasFocus)
            {
                spriteBatch.DrawString(SpriteFont, Text, Position, SelectedColor);
            }
            else
            {
                spriteBatch.DrawString(SpriteFont, Text, Position, Color);
            }
        }

        public override void HandleInput(PlayerIndex playerIndex)
        {
            if (!HasFocus)
            {
                return;
            }

            if (Xin.WasKeyReleased(Keys.Enter))
            {
                base.OnSelected(null);
                return;
            }

            if (Xin.WasMouseReleased(MouseButtons.Left))
            {
                size = SpriteFont.MeasureString(Text);

                Rectangle r = new(
                    (int)Position.X,
                    (int)Position.Y,
                    (int)Size.X,
                    (int)Size.Y);

                if (r.Contains(Xin.MouseAtPoint))
                {
                    base.OnSelected(null);
                }
            }
        }

        #endregion

    }
}
