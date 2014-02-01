using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
namespace Battle_city_online
{
    public class TestScreen:Screen
    {
        NamedSpriteObject obj;
        long time = 0;
        override public void LoadContent()
        {
            base.LoadContent();
            this.obj = new NamedSpriteObject();
            this.obj.LoadContent(this.ContentManager, "workdir/slike/BattleCitySheet1.png", "workdir/slike/Sheet.xml");
            this.obj.Movement.Direction = Movement.DIRECTION.RIGHT;
            this.obj.Scale += new Vector2(3,3);
            this.obj.setSprite("Tank1GreenRight1");
        }
        override public void UnloadContent()
        {
            base.UnloadContent();
            obj.UnloadContent();
        }
        override public void Update(GameTime time)
        {
            this.time = (long)time.TotalGameTime.TotalMilliseconds/10;
            if (this.time % 10 > 5)
            {
                this.obj.setSprite("Tank1GreenRight1");
            } else
            {
                this.obj.setSprite("Tank1GreenRight2");
            }
        }
        override public void Draw(SpriteBatch batch)
        {
            obj.Draw(batch, time);
        }
    }
}
