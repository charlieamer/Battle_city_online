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
        MovableObject obj;
        long time = 0;
        override public void LoadContent()
        {
            base.LoadContent();
            this.obj = new MovableObject();
            this.obj.LoadContent(this.ContentManager, "workdir/slike/BattleCitySheet1.bmp");
            this.obj.Movement.Direction = Movement.DIRECTION.RIGHT;
        }
        override public void UnloadContent()
        {
            base.UnloadContent();
            obj.UnloadContent();
        }
        override public void Update(GameTime time)
        {
            this.time = (long)time.TotalGameTime.TotalMilliseconds/10;
        }
        override public void Draw(SpriteBatch batch)
        {
            obj.Draw(batch, this.time);
        }
    }
}
