using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneToMany_Relationship.DesignPattern.SingletonPattern
{
    class DBTool
    {
        DBTool() { }
        private static ECommerceDbContext _eCommerceDbContext;
        public static ECommerceDbContext Instance {
            get
            {
                if (_eCommerceDbContext == null) _eCommerceDbContext = new ECommerceDbContext();
                return _eCommerceDbContext;
            }
            set { } 
        }
    }
}
