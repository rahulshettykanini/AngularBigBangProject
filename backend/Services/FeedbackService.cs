using AngularBigBang.Interfaces;
using AngularBigBang.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AngularBigBang.Services
{
  public class FeedbackService  : IFeedbackService
  {
    private readonly AngularBigBangContext _context;

    public FeedbackService(AngularBigBangContext context)
    {
      _context = context;
    }

    public async Task<List<Feedback>> GetFeedbacks()
    {
      var feedbacks = await _context.Feedbacks.ToListAsync();
      return feedbacks;
    }


    public async Task<List<Feedback>> PostFeedback(Feedback feedback)
    {


      _context.Feedbacks.Add(feedback);
      await _context.SaveChangesAsync();
      return await _context.Feedbacks.ToListAsync();
     
    }
  }
}
