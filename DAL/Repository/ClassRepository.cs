using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.Entities;

namespace DAL.Repository
{
    public class ClassRepository : GenericRepository<Class>
    {
        private readonly DBContext _context;

        public ClassRepository(DBContext context) : base(context)
        {
            _context = context;
        }

        public void AssignInstructorToClass(int instructorId, int classId)
        {
            Class @class = _dbSet.Find(classId);
            if (@class == null) throw new Exception("Class not found");

            Instructor instructor = _context.Instructors.Find(instructorId);
            if (instructor == null) throw new Exception("Instructor not found");
            if (!@class.Instructors.Contains(instructor))
            {
                @class.Instructors.Add(instructor);
                _context.SaveChanges();
            }
            else throw new Exception("Instructor was already in class");
        }
        public void RegisterCustomerToClass(int customerId, int classId)
        {
            Class @class = GetById(classId);
            if (@class == null)
            {
                throw new Exception("Class not found");
            }
            Customer customer = _context.Set<Customer>().Find(customerId);
            if (customer == null)
            {
                throw new Exception("Customer not found");
            }
            if (!@class.Customers.Contains(customer))
            {
                @class.Customers.Add(customer);
                _context.SaveChanges();
            }
            else throw new Exception("Customer was already in class");
        }
    }
}