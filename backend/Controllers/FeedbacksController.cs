using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AngularBigBang.Models;
using AngularBigBang.Interfaces;

namespace AngularBigBang.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbacksController : ControllerBase
    {
        private readonly IFeedbackService _iFeedbackService;

        public FeedbacksController(IFeedbackService iFeedbackService)
        {
      _iFeedbackService = iFeedbackService;
        }

        // GET: api/Feedbacks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Feedback>>> GetFeedbacks()
        {
          
            var feedbacks = await _iFeedbackService.GetFeedbacks();
      return Ok(feedbacks);
        }

        


        // POST: api/Feedbacks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Feedback>> PostFeedback(Feedback feedback)
        {
          var feedbacks = _iFeedbackService.PostFeedback(feedback);
      return Ok(feedbacks);
    }

    

      
    }
}
