using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OOPASU.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace OOPASU.Infrastructure.Repository.impl
{
    public class ClassRepositoryTest
    {
        [Fact]
        public void GetClasses()
        {
            Class c = new Class();
            c.ClassId = 1;
            c.Topic = "Изучение фреймворка Asp.Net";
            c.StartDate = Convert.ToDateTime("2022-01-03T13:00:00");
            c.EndDate = Convert.ToDateTime("2022-01-03T14:00:00");
            c.Status = "Закончилось";

            var dbContextMock = new Mock<Context>();
            var dbSetMock = new Mock<DbSet<Class>>();
            dbSetMock.Setup(s => s.ToList()).Returns(new List<Class>() { c });
            dbContextMock.Setup(s => s.Set<Class>()).Returns(dbSetMock.Object);

            var classRepository = new ClassRepository(dbContextMock.Object);

            var classes = classRepository.GetClasses();

            Assert.IsNotNull(classes);
            Assert.Equals(1, classes.Count());
            Assert.Equals(1, classes.First().ClassId);
        }

        [Fact]
        public void GetClassById()
        {
            Class c = new Class();
            c.ClassId = 1;
            c.Topic = "Изучение фреймворка Asp.Net";
            c.StartDate = Convert.ToDateTime("2022-01-03T13:00:00");
            c.EndDate = Convert.ToDateTime("2022-01-03T14:00:00");
            c.Status = "Закончилось";

            var dbContextMock = new Mock<Context>();
            var dbSetMock = new Mock<DbSet<Class>>();
            dbSetMock.Setup(s => s.Find(1)).Returns(c);
            dbContextMock.Setup(s => s.Set<Class>()).Returns(dbSetMock.Object);

            var classRepository = new ClassRepository(dbContextMock.Object);

            var classObj = classRepository.GetClassByID(1);

            Assert.IsNotNull(classObj);
            Assert.Equals(1, classObj.ClassId);
        }

        [Fact]
        public void AddClass()
        {
            Class c = new Class();
            c.ClassId = 1;
            c.Topic = "Изучение фреймворка Asp.Net";
            c.StartDate = Convert.ToDateTime("2022-01-03T13:00:00");
            c.EndDate = Convert.ToDateTime("2022-01-03T14:00:00");
            c.Status = "Закончилось";

            var dbContextMock = new Mock<Context>();
            var dbSetMock = new Mock<DbSet<Class>>();
            dbContextMock.Setup(s => s.Set<Class>()).Returns(dbSetMock.Object);

            var classRepository = new ClassRepository(dbContextMock.Object);
            classRepository.AddClass(c);

            dbContextMock.Verify(c => c.Classes.Add(It.IsAny<Class>()), Times.Once);
            dbContextMock.Verify(c => c.SaveChanges(), Times.Once);
        }

        [Fact]
        public void UpdateClass()
        {
            Class cObj = new Class();
            cObj.ClassId = 1;
            cObj.Topic = "Обновлен";
            cObj.StartDate = Convert.ToDateTime("2022-01-03T13:00:00");
            cObj.EndDate = Convert.ToDateTime("2022-01-03T14:00:00");
            cObj.Status = "Закончилось";

            var dbContextMock = new Mock<Context>();
            var dbSetMock = new Mock<DbSet<Class>>();
            dbSetMock.Setup(s => s.Find(1)).Returns(cObj);
            dbContextMock.Setup(s => s.Set<Class>()).Returns(dbSetMock.Object);

            var classRepository = new ClassRepository(dbContextMock.Object);
            classRepository.UpdateClass(1, cObj);

            dbContextMock.Verify(c => c.Classes.Find(1), Times.Once);
            dbContextMock.Verify(c => c.Classes.Update(cObj), Times.Once);
            dbContextMock.Verify(c => c.SaveChanges(), Times.Once);
        }

        [Fact]
        public void DeleteClass()
        {
            Class cObj = new Class();
            cObj.ClassId = 1;
            cObj.Topic = "Обновлен";
            cObj.StartDate = Convert.ToDateTime("2022-01-03T13:00:00");
            cObj.EndDate = Convert.ToDateTime("2022-01-03T14:00:00");
            cObj.Status = "Закончилось";

            var dbContextMock = new Mock<Context>();
            var dbSetMock = new Mock<DbSet<Class>>();
            dbSetMock.Setup(s => s.Find(1)).Returns(cObj);
            dbContextMock.Setup(s => s.Set<Class>()).Returns(dbSetMock.Object);

            var classRepository = new ClassRepository(dbContextMock.Object);
            classRepository.DeleteClass(1);

            dbContextMock.Verify(c => c.Classes.Find(1), Times.Once);
            dbContextMock.Verify(c => c.Classes.Remove(cObj), Times.Once);
            dbContextMock.Verify(c => c.SaveChanges(), Times.Once);
        }
    }
}
