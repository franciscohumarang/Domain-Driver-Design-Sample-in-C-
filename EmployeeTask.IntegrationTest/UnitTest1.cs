using NUnit.Framework;
using Domain.Entities;
using Domain.Repositories;
using System;
using System.Threading.Tasks;
 
using Infrastructure.Data;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
 
using Infrastructure.Data.Repository;

namespace EmployeeTask.IntegrationTest
{
    [TestFixture]
    public class Tests  
    {
     
 


 

        [Test]
        public async Task   AddTaskTest()
        {
            var taskEntry = new TaskEntry();
            taskEntry.Name = "TEST";
            taskEntry.LoggedDate = DateTime.Now;
            taskEntry.EmployeeId = 1;
            taskEntry.EndTime = Convert.ToDateTime(DateTime.Now.AddHours(2).ToLongTimeString() );
            taskEntry.StartTime = Convert.ToDateTime(DateTime.Now.ToLongTimeString());
            taskEntry.ProjectId = 1;
            taskEntry.TaskTypeId = 1;
            taskEntry.IsBillable = false;
            taskEntry.ClientId = 1;
            // arrange
          


            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
          .UseInMemoryDatabase(databaseName: "tasks")
           .Options;

            var context = new ApplicationDbContext(options);

            var taskRepo = new TasksRepositoryAsync(context);

            var task = await taskRepo.AddAsync(taskEntry);

            Assert.IsNotNull(task);

        }

        [Test]
        public async Task DeleteaskTest()
        {
            var taskEntry = new TaskEntry();
            taskEntry.Name = "TEST";
            taskEntry.LoggedDate = DateTime.Now;
            taskEntry.EmployeeId = 1;
            taskEntry.EndTime = Convert.ToDateTime(DateTime.Now.AddHours(2).ToLongTimeString());
            taskEntry.StartTime = Convert.ToDateTime(DateTime.Now.ToLongTimeString());
            taskEntry.ProjectId = 1;
            taskEntry.TaskTypeId = 1;
            taskEntry.IsBillable = false;
            taskEntry.ClientId = 1;
            // arrange



            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
          .UseInMemoryDatabase(databaseName: "tasks")
           .Options;

            var context = new ApplicationDbContext(options);

            var taskRepo = new TasksRepositoryAsync(context);

             var t= await   taskRepo.AddAsync(taskEntry);

             Assert.DoesNotThrowAsync(() =>  taskRepo.DeleteAsync(t));

        }

        [Test]
        public async Task Queryest()
        {



            var taskEntry= new TaskEntry();
            taskEntry.Name = "TEST";
            taskEntry.LoggedDate = DateTime.Now;
            taskEntry.EmployeeId = 1;
            taskEntry.EndTime = Convert.ToDateTime(DateTime.Now.AddHours(2).ToLongTimeString());
            taskEntry.StartTime = Convert.ToDateTime(DateTime.Now.ToLongTimeString());
            taskEntry.ProjectId = 1;
            taskEntry.TaskTypeId = 1;
            taskEntry.IsBillable = false;
            taskEntry.ClientId = 1;

            var taskEntry2 = new TaskEntry();
            taskEntry2.Name = "TEST2";
            taskEntry2.LoggedDate = DateTime.Now;
            taskEntry2.EmployeeId = 1;
            taskEntry2.EndTime = Convert.ToDateTime(DateTime.Now.AddHours(2).ToLongTimeString());
            taskEntry2.StartTime = Convert.ToDateTime(DateTime.Now.ToLongTimeString());
            taskEntry2.ProjectId =3;
            taskEntry2.TaskTypeId = 1;
            taskEntry2.IsBillable = false;
            taskEntry2.ClientId = 1;
            // arrange

            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
          .UseInMemoryDatabase(databaseName: "tasks")
           .Options;

            var context = new ApplicationDbContext(options);

            var taskRepo = new TasksRepositoryAsync(context);
            var t = await taskRepo.AddAsync(taskEntry);
            var t2 = await taskRepo.AddAsync(taskEntry2);

            var t3 = await taskRepo.GetDailyTaskEntriesAsync(1);

            Assert.IsNotNull(t3);

        }
    }
}