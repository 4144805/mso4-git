using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;


abstract public class GeneralGraphics
{
    public abstract void DrawLine(Color color, int x1, int y1, int x2, int y2);

    public abstract void DrawEllipse(Color color, int x, int y, int height, int width);
}

class FormGraphics : GeneralGraphics
{
    Graphics graphics;

    public FormGraphics(Graphics graphics)
    {
        this.graphics = graphics;
    }

    public override void DrawLine(Color color, int x1, int y1, int x2, int y2)
    {
        graphics.DrawLine(new Pen(color), x1, y1, x2, y2);
    }

    public override void DrawEllipse(Color color, int x, int y, int width, int height)
    {
        graphics.DrawEllipse(new Pen(color), x, y, width, height);
    }
}

class SVG : GeneralGraphics
{
    public override void DrawLine(Color color, int x1, int y1, int x2, int y2)
    {

    }

    public override void DrawEllipse(Color color, int x, int y, int height, int width)
    {

    }
}

