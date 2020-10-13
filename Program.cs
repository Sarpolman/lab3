using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lab3
{
   
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

            System.Console.WriteLine( "\nSimpleList");
            SimpleList<GeomFigure> simpleList = new SimpleList<GeomFigure>();

            simpleList.Add(circle);
            simpleList.Add(rectangle);
            simpleList.Add(square);

            foreach(var x in simpleList)
            {
                System.Console.WriteLine(x);
            }

            System.Console.WriteLine("\nСорт.SimpleList");
            simpleList.Sort();
            foreach(var x in simpleList)
            {
                System.Console.WriteLine(x);
            }
            
            System.Console.WriteLine("\nSimpleStack");
            SimpleStack<GeomFigure> simplestack = new SimpleStack<GeomFigure>();

            simplestack.push(circle);
            simplestack.push(rectangle);
            simplestack.push(square);

            foreach(var x in simplestack)
            {
                System.Console.WriteLine(x);
            }

            System.Console.WriteLine("\nSimpleStack popping out");

            while (simplestack.Count > 0)
            {
                GeomFigure f = simplestack.pop();
                Console.WriteLine(f);
            }
        }
    }
}

