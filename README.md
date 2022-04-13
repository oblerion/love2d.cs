love2d.cs is love2d in monogame, easy to use api

## fast start
copy love2d.cs in your monogame project<br>
edit Game1.cs like this, remplace testing to your project's namespace
```cs
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using love2d;
namespace testing
{

    public class Game1 : love
    {
        public Game1()
        {

        }
        public override void load()
        {
            // set width and height of window
            this.window_setmode(800,480);

        }
        public override void update(GameTime gameTime)
        {

        }
        public override void draw(GameTime gameTime)
        {

        }
    } 
 
}
```
all main function of monogame are in love2d.cs,<br>
you can use load, update and draw same at it
