using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;  
using Microsoft.Xna.Framework.Content;  
using Microsoft.Xna.Framework.Media;
namespace love2d
{
    public class love : Game
    {
        private MouseState ms; 
        private KeyboardState ks;
        private Color curant_color;
        private SpriteFont curant_font;
        private SpriteBatch sb;
        private GraphicsDevice gd;
        private GraphicsDeviceManager gdm;

        public love()
        {
            this.gdm = new GraphicsDeviceManager(this);
            this.Content.RootDirectory = "Content";
            this.IsMouseVisible = true;
        }
        public void window_setmode(int pw,int ph)
        {
            this.gdm.PreferredBackBufferWidth = pw;
            this.gdm.PreferredBackBufferHeight = ph;
            this.gdm.ApplyChanges();
        }
        public int math_floor(float f)
        {
            return (int)(f*10)/10;
        }
        public bool keyboard_isDown(Keys k)
        {
            return this.ks.IsKeyDown(k);
        }
        public bool keyboard_isUp(Keys k)
        {
            return this.ks.IsKeyUp(k);
        }
        public int mouse_getX()
        {
            return this.ms.X;
        }
        public int mouse_getY()
        {
            return this.ms.Y;            
        }
        public bool mouse_isDown(int b)
        { 
            if(b==2 && this.ms.RightButton == ButtonState.Pressed)
                return true;
            else if(b==1 && this.ms.LeftButton == ButtonState.Pressed)
                return true;
            else if(b==3 && this.ms.MiddleButton == ButtonState.Pressed)
                return true;
            return false;
        }
        public Song audio_newsource(string name)
        {
            return this.Content.Load<Song>(name);
        }
        public SpriteFont graphics_newfont(string name)
        {
            return this.Content.Load<SpriteFont>(name);
        }
        public Texture2D graphics_newimage(string name)
        {
            return this.Content.Load<Texture2D>(name);
        }
        public void graphics_draw(Texture2D t,int x,int y)
        {
            Vector2 v2 = new Vector2(x,y);
            this.sb.Begin();
            this.sb.Draw(t,v2,this.curant_color);
            this.sb.End();
        }
        public void graphics_draw(Texture2D t,int id,int x,int y)
        {
            Rectangle r1= new Rectangle(x,y,t.Height,t.Height);
            Rectangle r2= new Rectangle(id*t.Height,0,t.Height,t.Height);
            if(id > 0 && id <= t.Width/t.Height)
            {
                this.sb.Begin();
                this.sb.Draw(t,r1,r2,this.curant_color);
                this.sb.End();
            }
            else Console.WriteLine("WARNING: graphics_draw(t,id,x,y) id <= 0 or id > max");
        }
        public void graphics_print(string text,int x,int y)
        {
            Vector2 v2 = new Vector2(x,y);
            this.sb.Begin();
            this.sb.DrawString(curant_font, text, v2, this.curant_color);
            this.sb.End();
        }
        public void graphics_print(string text,int x,int y,float rotation,float scale)
        {
            Vector2 v2 = new Vector2(x,y);
            Vector2 FontOrigin= new Vector2(0,0);//font.MeasureString(text) / 2;
            //this.sb.Begin(samplerState : SamplerState.PointClamp);//
            this.sb.Begin(samplerState : SamplerState.PointWrap);
            //this.sb.Begin();
            this.sb.DrawString(curant_font, text, v2, this.curant_color,
                  rotation, FontOrigin, scale, SpriteEffects.None, 0);
            this.sb.End();
        }
        public void graphics_setfont(SpriteFont sf)
        {
            this.curant_font = sf;
        }
        public void graphics_setColor(Color col)
        {
            this.curant_color = col;
        }
        public void graphics_setColor()
        {
            this.curant_color = Color.White;
        }
        public void graphics_setAlpha(float a)
        {
            this.curant_color *= a;
        }
        public void graphics_rect(string type,int x,int y,int w,int h)
        {
            Texture2D rect = new Texture2D(this.gd, w, h);
            Color[] data = new Color[w*h];
            Vector2 coor = new Vector2(x, y);
            int i;
            if(type == "fill")
            {
                 for(i=0; i < data.Length; i++) 
                    data[i] = this.curant_color;
                 rect.SetData(data);
            }
            else if(type == "line")
            {
                for(i=0; i < data.Length; i++) 
                {
                    if(i<w || i%w == 0 || 
                    (i-w+1)%w == 0 || i>(w*h)-w)  
                    {
                        data[i] = this.curant_color;
                    }
                } 
                rect.SetData(data);
            }
            this.sb.Begin();
            this.sb.Draw(rect,coor,Color.White);
            this.sb.End();
        }
        public void graphics_clear(Color col)
        {
            this.gd.Clear(col);
        }
        
        public int collide (int x,int y,int w,int h,int x2,int y2, int w2,int h2)
        {
            if(x+w>x2 && x2+w2>x  && y+h>y2 && y2+h2>y)
            {
                return 1;
            }
            return 0;
        }
        // public class Button
        // {
        //     private int x;
        //     private int y;
        //     private int w;
        //     private int h;
        //     public Button()
        //     {

        //     }
        // }
        public virtual void load(){}
        public virtual void update(GameTime gameTime){}
        public virtual void draw(GameTime gameTime){}
//-----------------------------------------------------------
        protected override void Initialize()
        {
            this.gd = this.GraphicsDevice;
            this.sb = new SpriteBatch(this.GraphicsDevice);
            this.graphics_setColor(Color.White);
            // TODO: Add your initialization logic here
            base.Initialize();
        }

        protected override void LoadContent()
        {
            this.load();
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            this.ms = Mouse.GetState();
            this.ks = Keyboard.GetState();
            this.update(gameTime);
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            this.graphics_clear(Color.Black);
            this.graphics_setColor(Color.White);
            this.draw(gameTime);
            base.Draw(gameTime);
        }
    }
}
