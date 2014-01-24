using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace Battle_city_online
{
    class TextObject : GameObject
    {
        public string Text = "";
        public Color Color { get; set; }
        private string fontName;
        public TextObject(string fontName)
        {
            this.fontName = fontName;
            this.Color = Color.White;
        }
        public TextObject(string fontName, Color color)
        {
            this.fontName = fontName;
            this.Color = color;
        }
        public override void Draw(SpriteBatch batch)
        {
            if (this.visible)
            TextManager.Instance.Draw(this.fontName, this.Text, this.Position, batch, this.Color);
        }
    }
}
