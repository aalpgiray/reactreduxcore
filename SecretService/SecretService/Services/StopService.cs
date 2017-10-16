using SecretService.Data;
using SecretService.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Reflection;
using System.Spatial;

namespace SecretService.Services
{
    public class StopService : Repository<Stop>
    {
        SecretServiceContext _context { get; set; }

        public StopService(SecretServiceContext context) : base(context.Stops)
        {
            _context = context;
        }

        public override IEnumerable<Stop> Get()
        {
            using (_context)
            {
                using (var command = _context.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = "Select Id,IsDeleted,RouteId,StopType, Geometry.ToString() Geometry from Stops";
                    command.CommandType = CommandType.Text;
                    _context.Database.OpenConnection();

                    using (var result = command.ExecuteReader())
                    {
                        List<Stop> list = new List<Stop>();
                        while (result.Read())
                        {
                            Stop obj = new Stop();
                            foreach (PropertyInfo prop in obj.GetType().GetProperties())
                            {
                                if (prop.GetType().IsValueType && !object.Equals(result[prop.Name], DBNull.Value))
                                {
                                    prop.SetValue(obj, result[prop.Name], null);
                                }
                            }
                            list.Add(obj);
                        }
                        return list;
                    }
                }
            }
        }
    }
}
