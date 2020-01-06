using Satis.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Satis.DAL
{
    public static class HelperUsers
    {
        public static (Users, bool) CUD(Users us, EntityState state)
        {
            using (SatisEntities se = new SatisEntities())
            {
                se.Entry(us).State = state;
                if (se.SaveChanges() > 0)
                {
                    return (us, true);
                }
                else
                {
                    return (us, false);
                }
            }
        }
        public static Users GetByName(string _userName)
        {
            using (SatisEntities se = new SatisEntities())
            {
                return se.Users.Where(x => x.userName == _userName).FirstOrDefault();
            }
        }
    }
}
