using BiblioCore;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    /// <summary>
    /// CRUD operation manager
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class LibriController : ControllerBase
    {
        private readonly IMainBL mainBL;
        public LibriController(IMainBL mainBL)
        {
            this.mainBL = mainBL;
        }

        #region Operazioni sui libri

        /// <summary>
        /// Get all books
        /// </summary>
        /// <returns>Status 200</returns>
        [HttpGet]
        public IActionResult GetAllLibri()
        {
            var result = mainBL.GetAllLibri();
            return Ok(result);
        } // fatto

        [HttpGet("libri/{id}")]
        public IActionResult GetLibroById(int id)
        {
            if (id <= 0)
                return BadRequest("invalid id");

            var libro = mainBL.GetLibroById(id);

            if (libro == null)
                return NotFound("id not found");

            return Ok(libro);
        } // fatto

        [HttpGet("libri/isbn/{isbn}")]
        public IActionResult GetLibroByIsbn(string isbn)
        {
            var libro = mainBL.GetLibroByIsbn(isbn);
            if (libro == null)
                return NotFound("isbn not found");
            return Ok(libro);
        } // fatto

        [HttpPost("libri")]
        public IActionResult CreateNewLibro([FromBody] Libro newLibro)
        {
            if (newLibro == null)
                return BadRequest("invalid data");

            mainBL.AddNewLibro(newLibro);

            return CreatedAtAction(nameof(CreateNewLibro), newLibro);

            /*
             *      TEST CREATE JSON
             * {
                "isbn": "0000-1212-2323",
                "titolo": "titolo1",
                "sommario": "asd",
                "autore": "autore1"
                }
             */
        } // fatto

        [HttpPost("libri/update/")]
        public IActionResult UpdateLibro([FromBody] Libro l)
        {
            if (l.Id <= 0)
                return BadRequest("invalid id");

            var result = mainBL.EditLibro(l);

            if (!result)
                return StatusCode(500, "cannot update this book");

            return CreatedAtAction(nameof(UpdateLibro), l);

            /*
             * {
                "id": 3,
                "isbn": "5783-1199-0023",
                "titolo": "La gabbianella e il gatto nero",
                "sommario": "asdfghjkl",
                "autore": "Luis Sepulveda",
                "prestito": null
}
             */
        } // fatto

        [HttpDelete("libri/{id}")]
        public IActionResult DeleteLibroById(int id)
        {
            if (id <= 0)
                return BadRequest("invalid id");

            var result = mainBL.DeleteLibro(id);
            return Ok(result);
        } // fatto

        ////api/Libri/[numero]
        //[HttpPatch("{id}")]
        //public IActionResult PatchLibro(int id, [FromBody] JsonPatchDocument<Libro> patchDoc)
        //{
        //    if (patchDoc == null || id <= 0)
        //        return BadRequest("invalid data");

        //    var libroToPatch = mainBL.GetLibroById(id);

        //    if (libroToPatch == null)
        //        return NotFound("id not found");

        //    patchDoc.ApplyTo(libroToPatch, ModelState);

        //    if (!ModelState.IsValid)
        //        return StatusCode(500, "cannot patch Libro");

        //    var result = mainBL.AddNewLibro(libroToPatch);

        //    if (!result)
        //        return StatusCode(500);

        //    return Ok(libroToPatch);
        //}

        #endregion

        #region Operazioni su Utenti

        [HttpGet("utenti")]
        public IActionResult GetUsers()
        {
            var result = mainBL.GetAllUtenti();
            return Ok(result);
        }

        [HttpPost("utenti/add")]
        public IActionResult AddUser([FromBody] Utente newUtente)
        {
            if (newUtente == null)
                return BadRequest("invalid data");

            mainBL.AddNewUtente(newUtente);

            return CreatedAtAction(nameof(AddUser), newUtente);
        }

        [HttpPost("utenti/edit")]
        public IActionResult EditUser([FromBody] Utente utente)
        {
            if (utente.Id <= 0)
                return BadRequest();

            var result = mainBL.EditUtente(utente);

            if (!result)
                return BadRequest();

            return Ok(result);
        }

        [HttpDelete("utenti/{id}")]
        public IActionResult DeleteUser(int id)
        {
            if (id <= 0)
                return BadRequest("invalid id");

            var result = mainBL.DeleteUtente(id);
            return Ok(result);
        }

        #endregion

        /*
        // api/employees    GET
        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            var results = this.mainBL.GetAllEmployees();

            return Ok(results);
        }

        // api/employees/5  GET
        [HttpGet("{id}")]
        public IActionResult GetEmployeeById(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid Employee Id.");

            var emp = this.mainBL.GetEmployeeById(id);

            if (emp == null)
                return NotFound("Employee not found.");

            return Ok(emp);
        }

        // api/employees  POST
        [HttpPost]
        public IActionResult CreateNewEmployee(Employee newEmployee)    // Model Binding
        {
            if (newEmployee == null)
                return BadRequest("Invalid data received.");

            // save data (BL to be added)

            return CreatedAtAction(nameof(GetEmployeeById), new { id = newEmployee.Id }, newEmployee);
        }

        // api/employees/5  PUT
        [HttpPut("{id}")]
        public IActionResult UpdateEmployee(int id, Employee updatedEmployee)   // Model Binding
        {
            if (id <= 0)
                return BadRequest("Invalid Employee Id.");

            if (id != updatedEmployee.Id)
                return BadRequest("Employee IDs not matching.");

            return Ok();
        }

        // api/employees/5  DELETE
        [HttpDelete("{id}")]
        public IActionResult DeleteEmployeeById(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid Employee Id.");

            return Ok();
        }

        */ // (employees)
    }
}
