using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Circle : Shape
{

    private int x;
	private int y;
	private int size;

    public Circle(int x, int y, int size, Color color)
    {
		this.x = x;
		this.y = y;
		this.size = size;
        this.color = color;
    }

    public override void Draw(GeneralGraphics Canvas)
    {
        Canvas.DrawEllipse(color, this.x, this.y, this.size, this.size);
    }

}
