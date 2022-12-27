using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using PSP.Enums;
using PSP.Exceptions;
using PSP.Interfaces;
using PSP.Models;

namespace PSP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountCodesController : ControllerBase
    {
        private readonly IDiscountCodeService _discountCodeService;

        public DiscountCodesController(IDiscountCodeService entityService)
        {
            _discountCodeService = entityService;
        }

        // POST: api/DiscountCodes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<DiscountCode> PostDiscountCode(DiscountCode discountCode)
        {
            try
            {
                return _discountCodeService.Create(discountCode);
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/DiscountCodes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{code}")]
        public ActionResult<DiscountCode> PutDiscountCode(string code, DiscountCode discountCode)
        {
            try
            {
                return _discountCodeService.Update(code, discountCode);
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/DiscountCodes/5/status/statusEnum
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{code}/status/{status}")]
        public ActionResult<DiscountCode> PutDiscountCode(string code, DiscountCodeStatus status)
        {
            //var statusEnum = (DiscountCodeStatus)Enum.Parse(typeof(DiscountCodeStatus), status, true);
            try
            {
                return _discountCodeService.UpdateStatus(code, status);
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
