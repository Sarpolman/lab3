using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lab3
{
    interface IPrint
    {
        void Print();
    }
    public abstract class GeomFigure: IComparable
    {
        public abstract double Area();

        public int CompareTo(object o)
        {
            GeomFigure p= o as GeomFigure;
            if(this.Area()>p.Area())
                return 1;
            else if (this.Area()==p.Area())
                return 0;
            else
                return -1;
        }
    }
    class Rectangle : GeomFigure, IPrint
    {
        public double width { get; set; }
        public double height { get; set; }


        public Rectangle(double width, double height)
        {
            this.width = width;
            this.height = height;
        }

        public override double Area()
        {
            return width * height;
        }
        public override string ToString()
        {
            return $"Ширина:{width} Высота:{height} Площадь прямоугольника:{Area()}";
        }

        public void Print()
        {
            Console.WriteLine(this.ToString());
        }

    }

    class Square : Rectangle, IPrint
    {

        public Square(double width) : base(width, width)
        {
        }
        public override double Area()
        {
            return width * width;
        }

        public override string ToString()
        {
            return $"Длина стороны:{width}  Площадь квадрата:{Area()}";
        }
        new public void Print()
        {
            Console.WriteLine(this.ToString());
        }
    }

    class Circle : GeomFigure, IPrint
    {

        public double radius { get; set; }

        public Circle(double radius)
        {
            this.radius = radius;
        }

        public override double Area()
        {
            return Math.PI * radius * radius;
        }

        public override string ToString()
        {
            return $"Радиус:{radius}  Площадь круга:{Area()}";
        }
        public void Print()
        {
            Console.WriteLine(this.ToString());
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Rectangle rectangle=new Rectangle(2,5);
            Square square=new Square(4);
            Circle circle =new Circle(4);

            System.Console.WriteLine("\nArrayList");
            ArrayList arrayList= new ArrayList();
            arrayList.Add(circle);
            arrayList.Add(rectangle);
            arrayList.Add(square);
            foreach (GeomFigure o in arrayList){
                Console.WriteLine(o.ToString());
            }

            System.Console.WriteLine("\nСорт.ArrayList");
            arrayList.Sort();
            foreach (GeomFigure o in arrayList){
                Console.WriteLine(o.ToString());
            }

            System.Console.WriteLine("\nЛист");
            List<GeomFigure> FiguresList=new List<GeomFigure>();
            FiguresList.Add(circle);
            FiguresList.Add(rectangle);
            FiguresList.Add(square);
            foreach (GeomFigure o in FiguresList){
                Console.WriteLine(o.ToString());
            }

            System.Console.WriteLine("\nСорт.Лист");
            FiguresList.Sort();
            foreach (GeomFigure o in FiguresList){
                Console.WriteLine(o.ToString());
            }

            System.Console.WriteLine("\nМатрица");
            Matrix <GeomFigure> matrix = new Matrix<GeomFigure>(3,3,3,new GeomFigureMatrixCheckEmpty());

            matrix[0, 0,0] = rectangle;
            matrix[1,1,1] = square;
            matrix[2,2,2]=circle;
            System.Console.WriteLine(matrix.ToString());

        }
    }
}

