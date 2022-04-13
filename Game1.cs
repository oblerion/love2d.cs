using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using love2d;
namespace testing
{

    public class Game1 : love
    {
        Texture2D test;
        SpriteFont font;
        public Game1()
        {

        }
        public override void load()
        {
            this.set_mode(800,480);
            test = graphics_newimage("persos");
            font = graphics_newfont("font");
        }
        public override void update(GameTime gameTime)
        {

        }
        public override void draw(GameTime gameTime)
        {
            if(mouse_isDown(1))
            // Console.WriteLine("mouse r {0}",love.ms.RightButton);
            graphics_rect("fill",mouse_getX(),mouse_getY(),100,100);
            graphics_setColor(Color.Green);
            graphics_rect("fill",143,123,100,10);
            graphics_setColor(Color.Red);
            graphics_rect("line",13,153,10,100);
            graphics_draw(test,1,123,124);
            graphics_setColor(Color.White);
            graphics_print(font,"Hhello0978756",153,123,0,5);

        }
    } 
 
}


