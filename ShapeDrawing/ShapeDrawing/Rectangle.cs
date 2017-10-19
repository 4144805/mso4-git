using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class Rectangle : Shape
{

    private int x;
	private int y;
	private int width;
	private int height;

    public Rectangle(int x, int y, int width, int height)
    {
		this.x = x;
		this.y = y;
		this.width = width;
		this.height = height;
    }
    
	public override void Draw(GeneralGraphics Canvas)
    {
        Color color = Color.Black;
		Canvas.DrawLine(color,x,y,x + width,y);
		Canvas.DrawLine(color, x+width,y,x+width,y+height);
		Canvas.DrawLine(color, x+width,y+height,x,y+height);
		Canvas.DrawLine(color, x,y+height,x,y);
    }
}

