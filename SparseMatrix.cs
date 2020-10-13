using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lab3
{
    public interface IMatrixCheckEmpty<T>
    {
        T getEmptyElement();

        bool checkEmptyElement(T element);
    }
    public class Matrix<T>
    {
        Dictionary<string, T> _matrix = new Dictionary<String,T>();
        int maxX;
        int maxY;

        IMatrixCheckEmpty<T> checkEmpty;

        public Matrix(int px, int py, IMatrixCheckEmpty<T> checkEmptyParam)
        {
            this.maxX = px;
            this.maxY = py;
            this.checkEmpty = checkEmptyParam;
        }

        public T this[int x, int y]
        {
            set
            {
                CheckBounds(x,y);
                string key =DictKey(x,y);
                this._matrix.Add(key,value);
            }
            get
            {
                CheckBounds(x,y);
                string key = DictKey(x,y);
                if (this._matrix.ContainsKey(key))
                {
                    return this._matrix[key];
                }
                else
                {
                    return this.checkEmpty.getEmptyElement();
                }

            }
        }

            void CheckBounds(int x, int y)
        {
            if(x<0 || x>=this.maxX)
            {
                throw new ArgumentOutOfRangeException("x","x="+x+" выходит за границы");
            }
            
            if(y<0 || y>=this.maxY)
            {
                throw new ArgumentOutOfRangeException("y","y="+x+" выходит за границы");
            }
        }

        string DictKey(int x, int y)
        {
            return x.ToString() + "_" + y.ToString();
        }

        public override string ToString()
        {
            StringBuilder b =new StringBuilder();
            for (int j=0; j< this.maxX; j++)
            {
                b.Append("[");
                for (int i=0; i< this.maxX; i++)
                {
                    if (i>0)
                    {
                        b.Append("\t");
                    }
                    if (!this.checkEmpty.checkEmptyElement(this[i,j]))
                    {
                        b.Append(this[i,j].ToString());
                    }
                    else
                    {
                        b.Append("-");
                    }
                }
                b.Append("]\n");
            }
            return b.ToString();
        }

    }

    class GeomFigureMatrixCheckEmpty : IMatrixCheckEmpty<GeomFigure>
    {
        public GeomFigure getEmptyElement()
        {
            return null;
        }

        public bool checkEmptyElement(GeomFigure element)
        {
            bool Result = false;
            if(element == null)
            {
                Result = true;
            }
            return Result;
        }
    }

}