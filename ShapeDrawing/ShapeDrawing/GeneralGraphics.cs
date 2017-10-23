using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;


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
    List<string> vormen = new List<string>();
    public List<string> document = new List<string>();

    Point? eersteCoordinaat = null;
    string nieuwePolyline;

    public override void DrawLine(Color color, int x1, int y1, int x2, int y2)
    {
        if (eersteCoordinaat == null)
        {
            eersteCoordinaat = new Point(x1, y1);
            nieuwePolyline = "<polyline points=\"" + x1 + "," + y1;
        }

        nieuwePolyline += " " + x2 + "," + y2;

        if (new Point(x2, y2) == eersteCoordinaat)
        {
            nieuwePolyline += "\" style=\"fill:none;stroke:" + color.ToString().ToLower().Substring(7).TrimEnd(']') + ";stroke-width:1\" />";
            vormen.Add(nieuwePolyline);
            eersteCoordinaat = null;
        }
    }

    public override void DrawEllipse(Color color, int x, int y, int height, int width)
    {
        string nieuweCirkel = "<circle cx=\"" + (x + (height / 2)) + "\" cy=\"" + (y + (height / 2)) + "\" r=\"" + (height / 2) + "\" stroke-width=\"1\" fill=\"none\" stroke=\"" + color.ToString().ToLower().Substring(7).TrimEnd(']') + "\" />";
        vormen.Add(nieuweCirkel);
    }

    public void Export()
    {
        document.Add("<?xml version=\"1.0\" standalone=\"no\"?>");
        document.Add("<!DOCTYPE svg PUBLIC \"-//W3C//DTD SVG 1.1//EN\" \"http://www.w3.org/Graphics/SVG/1.1/DTD/svg11.dtd\">");
        document.Add("<svg xmlns=\"http://www.w3.org/2000/svg\" version=\"1.1\">");
        foreach (string vorm in vormen)
        {
            document.Add(vorm);
        }
        document.Add("</svg>");

        //FolderBrowserDialog browse = new FolderBrowserDialog();
        //browse.ShowDialog();

        //System.IO.File.WriteAllLines(@"D:\School\Modelleren en Systeemontwikkeling\kaas.svg", document);
    }

    public List<string> Document
    {
        get { return document; }
    }
}

