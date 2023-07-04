using dot7.API.Crud.Data;
using dot7.API.Crud.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace dot7.API.Crud.Controllers;

[ApiController]
[Route("[controller]")]
public class StudentsController : ControllerBase
{
    private readonly MyWorldDbContext _myWorldDbContext;
    public StudentsController(MyWorldDbContext myWorldDbContext)
    {
        _myWorldDbContext = myWorldDbContext;
    }


    [HttpGet]
    public async Task<IActionResult> GetAsync()
    {
        var students = await _myWorldDbContext.tblStudents.ToListAsync();
        return Ok(students);
    }
    [HttpGet]
    [Route("get-student-by-id")]
    public async Task<IActionResult> GetStudentByIdAsync(int id)
    {
        var student = await _myWorldDbContext.tblStudents.FindAsync(id);
        return Ok(student);
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync(tblStudent student)
    {
        _myWorldDbContext.tblStudents.Add (student);
        await _myWorldDbContext.SaveChangesAsync();
        return Created($"/get-student-by-id?id={student.Id}", student);
    }

    [HttpPut]
    public async Task<IActionResult> PutAsync(tblStudent studentToUpdate)
    {
        _myWorldDbContext.tblStudents.Update(studentToUpdate);
        await _myWorldDbContext.SaveChangesAsync();
        return NoContent();
    }

    [Route("{id}")]
    [HttpDelete]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var studentToDelete = await _myWorldDbContext.tblStudents.FindAsync(id);
        if (studentToDelete == null)
        {
            return NotFound();
        }
        _myWorldDbContext.tblStudents.Remove(studentToDelete);
        await _myWorldDbContext.SaveChangesAsync();
        return NoContent();
    }
}