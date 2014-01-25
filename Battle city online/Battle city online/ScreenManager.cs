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
    public class ScreenManager
    {
        private static ScreenManager instance;
        private ContentManager Content;

        public Vector2 Dimensions{private set; get;}
        public IServiceProvider ServiceProvider;

        private TimeSpan ScreenTime;

        private ScreenManager()
        {
            Dimensions = new Vector2(1024, 768); //Dimenzije ekrana
        }

        public static ScreenManager Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new ScreenManager();
                }
                return instance;
            }
        }
        public void LoadContent(ContentManager Content)
        {
            this.Content = Content;
            this.ServiceProvider = Content.ServiceProvider;
        }



        public void Update(GameTime gameTime)
        {
            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.Opaque, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullNone);

            if (this.CurrentScreen != null)
                this.CurrentScreen.Draw(spriteBatch);

            spriteBatch.End();
        }

        public void SetNewScreen(Screen NewScreen)
        {
            this.NewScreen = NewScreen;
        }
    }
}
