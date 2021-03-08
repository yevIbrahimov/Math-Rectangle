using System;
using System.Collections.Generic;

namespace Rectangle.Impl
{
	public static class Service
	{
		public static Rectangle FindRectangle(List<Point> points)
		{
			if (points == null || points.Count < 2)
			{
				foreach (var point in points)
				{
					if (point == null)
					{
						throw new ArgumentNullException();
					}
				}
			}
			Point cornerPoint = points[0];

			for (int i = 1; i < points.Count; i++)
			{
				bool temp = Math.Sqrt(points[i].X * points[i].X + points[i].Y * points[i].Y) 
					> Math.Sqrt(cornerPoint.X * cornerPoint.X + cornerPoint.Y * cornerPoint.Y);
				if (temp)
				{
					cornerPoint = points[i];
				}
			}
			points.Remove(cornerPoint);

			Point startPoint = points[0];

			List<int> xPoints = new List<int>();
			foreach (var point in points)
			{
				xPoints.Add(point.X);
			}
			xPoints.Sort();

			List<int> yPoints = new List<int>();
			foreach (var point in points)
			{
				xPoints.Add(point.Y);
			}
			yPoints.Sort();

			Rectangle rectangle = new Rectangle()
			{
				X = xPoints[0],
				Y = yPoints[0],
				Width = xPoints[xPoints.Count - 1] - xPoints[0],
				Height = yPoints[yPoints.Count - 1] - yPoints[0]
			};

			return rectangle;
		}
	}
}
