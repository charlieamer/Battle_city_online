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
        private Screen CurrentScreen, NewScreen;
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

        public void UnloadContent()
        {
            this.CurrentScreen.UnloadContent();
        }

        public void LoadContent(ContentManager Content)
        {
            this.Content = Content;
            this.ServiceProvider = Content.ServiceProvider;
        }



        public void Update(GameTime gameTime)
        {
            if (this.NewScreen != null)
            {
                if (this.CurrentScreen != null)
                    this.CurrentScreen.UnloadContent();
                this.CurrentScreen = this.NewScreen;
                this.CurrentScreen.LoadContent();
                this.NewScreen = null;
                this.ScreenTime = gameTime.TotalGameTime;
                gameTime.TotalGameTime -= this.ScreenTime;
            }
            if (this.CurrentScreen != null)
            {
                this.CurrentScreen.Update(gameTime);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullNone);

            if (this.CurrentScreen != null)
                this.CurrentScreen.Draw(spriteBatch);

            spriteBatch.End();
        }

        public void SetNewScreen(Screen NewScreen)
        {
            this.NewScreen = NewScreen;
        }

        public void SetNewScreen(Screen NewScreen, String text)
        {
            this.NewScreen = new TransitionScreen(NewScreen,text);

        }
    }
}
