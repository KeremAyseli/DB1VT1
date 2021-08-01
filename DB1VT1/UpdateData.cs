using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DB1VT1
{
    class UpdateData<T>
    {
        private List<T> AnlıkVeriler;
        IQueryable<T> aranan;
        public void update(Expression<Func<T, bool>> ArananVeriler, string anahtarKelime)
        {
            DataRead<T> dataRead = new DataRead<T>();
            List<T> BulunanDegerler = dataRead.ReadJsonWithList(anahtarKelime);
            aranan = BulunanDegerler.AsQueryable();
            AnlıkVeriler = aranan.Where(ArananVeriler).ToList();

        }
    }
}
