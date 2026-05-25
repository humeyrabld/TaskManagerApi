using TaskManagerApi.Data;
using TaskManagerApi.Models;
using Microsoft.EntityFrameworkCore;


public class TaskService
{
   private readonly AppDbContext _context;


   public TaskService(AppDbContext context)
   {
       _context = context;
   }


   public async Task<List<TaskItem>> GetAll()
   {
       return await _context.Tasks.ToListAsync();
   }


   public async Task<TaskItem?> GetById(int id)
   {
       return await _context.Tasks.FindAsync(id);
   }


   public async Task<TaskItem> Create(TaskItem task)
   {
       _context.Tasks.Add(task);
       await _context.SaveChangesAsync();
       return task;
   }


   public async Task<bool> Update(int id, TaskItem updated)
   {
       var task = await _context.Tasks.FindAsync(id);
       if (task == null) return false;


       task.Title = updated.Title;
       task.IsDone = updated.IsDone;


       await _context.SaveChangesAsync();
       return true;
   }


   public async Task<bool> Delete(int id)
   {
       var task = await _context.Tasks.FindAsync(id);
       if (task == null) return false;


       _context.Tasks.Remove(task);
       await _context.SaveChangesAsync();
       return true;
   }
}
