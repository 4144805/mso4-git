using System;
using System.Drawing;

public abstract class Shape
{
    protected Color color;

	public Shape()
	{
	}

    public abstract void Draw(GeneralGraphics Canvas);
	
}