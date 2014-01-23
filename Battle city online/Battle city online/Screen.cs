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
    abstract public class Screen
    {
        protected ContentManager ContentManager;
        virtual public void LoadContent()
        {
            this.ContentManager = new ContentManager(ScreenManager.Instance.ServiceProvider);
        }
        virtual public void UnloadContent()
        {
            this.ContentManager.Unload();
        }
        virtual public void Update(GameTime time)
        {

        }
        virtual public void Draw(SpriteBatch batch)
        {

        }
    }
}
