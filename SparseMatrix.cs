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

        int maxZ;

        IMatrixCheckEmpty<T> checkEmpty;

        public Matrix(int px, int py,int pz, IMatrixCheckEmpty<T> checkEmptyParam)
        {
            this.maxX = px;
            this.maxY = py;
            this.maxZ = pz;
            this.checkEmpty = checkEmptyParam;
        }

        public T this[int x, int y, int z]
        {
            set
            {
                CheckBounds(x,y,z);
                string key =DictKey(x,y,z);
                this._matrix.Add(key,value);
            }
            get
            {
                CheckBounds(x,y,z);
                string key = DictKey(x,y,z);
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

            void CheckBounds(int x, int y, int z)
        {
            if(x<0 || x>=this.maxX)
            {
                throw new ArgumentOutOfRangeException("x","x="+x+" выходит за границы");
            }
            
            if(y<0 || y>=this.maxY)
            {
                throw new ArgumentOutOfRangeException("y","y="+y+" выходит за границы");
            }

            if(z<0 || z>=this.maxZ)
            {
                throw new ArgumentOutOfRangeException("z","z="+z+" выходит за границы");
            }
        }

        string DictKey(int x, int y,int z)
        {
            return x.ToString() + "_" + y.ToString()+ "_" + z.ToString();
        }

        public override string ToString()
        {
            StringBuilder b =new StringBuilder();
            for(int k=0; k<this.maxZ;k++){
                for (int j=0; j< this.maxX; j++)
                {
                    b.Append("[");
                    for (int i=0; i< this.maxX; i++)
                    {
                        if (i>0)
                        {
                            b.Append("\t");
                        }
                        if (!this.checkEmpty.checkEmptyElement(this[i,j,k]))
                        {
                            b.Append(this[i,j,k].ToString());
                        }
                        else
                        {
                            b.Append("-");
                        }
                    }
                    b.Append("]\n");
                }
                b.Append("\n");
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