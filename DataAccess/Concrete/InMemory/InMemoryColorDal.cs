using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryColorDal : IColorDal
    {
        List<Color> _colors;
        public InMemoryColorDal()
        {
            _colors = new List<Color>
            {
                new Color { ColorID = 1, ColorName = "Kirmizi" },
                new Color { ColorID = 2, ColorName = "Yesil" },
                new Color { ColorID = 3, ColorName = "Mavi" },
                new Color { ColorID = 4, ColorName = "Siyah" },
                new Color { ColorID = 5, ColorName = "Beyaz" },
                new Color { ColorID = 6, ColorName = "Metalik Gri" },
            };
        }

        public void Add(Color color)
        {
            Console.WriteLine($"Color Added: {0}", color.ColorName);
        }

        public void Delete(Color color)
        {
            Color colorToDelete;
            colorToDelete = _colors.SingleOrDefault(c => c.ColorID == color.ColorID);
            _colors.Remove(colorToDelete);
            Console.WriteLine($"Color Deleted {0}", color.ColorName);
        }

        public List<Color> GetAll(Expression<Func<Color, bool>> filter = null)
        {
            return _colors;
        }

        public Color Get(Expression<Func<Color, bool>> filter)
        {
            return _colors.Single();
            //return _colors.Set<Color>().SingleOrDefault(filter);
        }

        public void Update(Color color)
        {
            Color colorToUpdate;
            colorToUpdate = _colors.SingleOrDefault(c => c.ColorID == color.ColorID);
            colorToUpdate.ColorID = color.ColorID;
            colorToUpdate.ColorName = color.ColorName;
        }
    }
}
