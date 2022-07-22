using Geometry;

Random random_number = new Random();
GeometricShape shape = new GeometricShape(Convert.ToInt16(random_number.Next(2,6)));
shape.Show();
shape.HowManyCorners();