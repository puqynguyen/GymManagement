using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
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
        public IEnumerable<Class> GetAllAvailableClass()
        {
            return _context.Database.SqlQuery<Class>("SELECT * FROM GetAllAvailableClass").ToList();
        }
        public IEnumerable<Customer> GetCustomersInClass(int classId)
        {
            return _context.Database.SqlQuery<Customer>(
                "EXEC GetCustomersInClass @ClassId",
                new SqlParameter("@ClassId", classId)
            ).ToList();
        }
        public IEnumerable<Instructor> GetInstructorsInClass(int classId)
        {
            return _context.Database.SqlQuery<Instructor>(
                "EXEC GetInstructorsInClass @ClassId",
                new SqlParameter("@ClassId", classId)
            ).ToList();
        }
        public IEnumerable<Customer> GetCustomersNotInClass(int classId)
        {
            return _context.Database.SqlQuery<Customer>(
                "EXEC GetCusNotRegisToClass @ClassId",
                new SqlParameter("@ClassId", classId)
            ).ToList();
        }
        public IEnumerable<Instructor> GetInstructorsNotInClass(int classId)
        {
            return _context.Database.SqlQuery<Instructor>(
                "EXEC GetInstructorsNotInClass @ClassId",
                new SqlParameter("@ClassId", classId)
            ).ToList();
        }
        public void RemoveCustomerFromClass(int customerId, int classId)
        {
            // Find the class by ID
            Class @class = _dbSet.Find(classId);
            if (@class == null) throw new Exception("Class not found");

            // Find the customer by ID
            Customer customer = _context.Set<Customer>().Find(customerId);
            if (customer == null) throw new Exception("Customer not found");

            // Check if the customer is already in the class
            if (@class.Customers.Contains(customer))
            {
                // Remove the customer from the class
                @class.Customers.Remove(customer);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Customer is not in this class");
            }
        }
        public void RemoveInstructorFromClass(int instructorId, int classId)
        {
            // Find the class by ID
            Class @class = _dbSet.Find(classId);
            if (@class == null) throw new Exception("Class not found");

            // Find the instructor by ID
            Instructor instructor = _context.Set<Instructor>().Find(instructorId);
            if (instructor == null) throw new Exception("Instructor not found");

            // Check if the instructor is already in the class
            if (@class.Instructors.Contains(instructor))
            {
                // Remove the instructor from the class
                @class.Instructors.Remove(instructor);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Instructor is not in this class");
            }
        }

    }
}