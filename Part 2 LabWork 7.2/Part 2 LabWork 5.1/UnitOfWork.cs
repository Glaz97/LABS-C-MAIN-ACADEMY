using Part_2_LabWork_7._2.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Part_2_LabWork_7._2
{ 
        public class UnitOfWork : IDisposable
        {
            private DBContext db = new DBContext();
            private Book2Repository bookRepository;

            public Book2Repository Books
            {
                get
                {
                    if (bookRepository == null)
                        bookRepository = new Book2Repository(db);
                    return bookRepository;
                }
            }

            public void Save()
            {
                db.SaveChanges();
            }

            private bool disposed = false;

            public virtual void Dispose(bool disposing)
            {
                if (!disposed)
                {
                    if (disposing)
                    {
                        db.Dispose();
                    }
                    disposed = true;
                }
            }

            public void Dispose()
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }
        }
    }
